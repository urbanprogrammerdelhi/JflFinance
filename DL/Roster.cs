// ***********************************************************************
// Assembly         : DL
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
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Transactions;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class Roster.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Roster
    {

        #region Function Related to Create Pattern Screen For Employee Wise Scheduling
        /// <summary>
        /// To Get the site post of assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic unique identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt unique identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="sytemParameterValue">The sytem parameter value.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtSitePostGet(string locationAutoId, string clientCode, string asmtId, string postCode, string sytemParameterValue, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[7];

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Status, sytemParameterValue);
            objParam[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_PostDeploment_get", objParam);
            return ds;
        }


        /// <summary>
        /// To Get pattern sequence of assignment.
        /// </summary>
        /// <param name="locationAutoId">The locationAutoId.</param>
        /// <param name="asmtCode">The asmtCode.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPatternSequenceGet(String locationAutoId, String asmtCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AsmtPatternSeq_get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get shift patterrn of assignment.
        /// </summary>
        /// <param name="locationAutoId">The locationAutoId.</param>
        /// <param name="asmtCode">The asmtCode.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftPatternGet(String locationAutoId, String asmtCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Asmtshiftpattern_get", objParam);
            return ds;
        }
        /// <summary>
        /// Update Pattern Sequence
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="patternSeqAutoId">The pattern seq automatic identifier.</param>
        /// <param name="isActive">The is active.</param>
        /// <returns>DataSet</returns>
        public DataSet PatternsSequenceUpdate(String locationAutoId, String patternSeqAutoId, Boolean isActive)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.PatternSeqAutoID, patternSeqAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPatternsSequenceUpdate", objParam);
            return ds;
        }
        /// <summary>
        /// To Get shift pattern of assignment
        /// </summary>
        /// <param name="locationAutoId">The locationAutoId.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="showAllStatus">The show all status.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftPatternGetAll(string locationAutoId, string clientCode, string asmtId, string postCode, string showAllStatus)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Status, showAllStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Asmtshiftpattern_getAll", objParam);
            return ds;
        }
        /// <summary>
        /// To Get pattern sequence on the basis of sequence Id
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="patternSequenceAutoId">The pattern seq auto ID.</param>
        /// <param name="locationAutoId">The location auto ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftPatternSequenceGet(string clientCode, string asmtId, string patternSequenceAutoId, string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PatternSeqAutoID, patternSequenceAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPatternSeq_get", objParam);
            return ds;
        }

        /// <summary>
        /// To Create a new shift pattern
        /// </summary>
        /// <param name="locationAutoId">The locationAutoId.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="shiftPatternId">The shift pattern ID.</param>
        /// <param name="shiftPattern">The shift pattern.</param>
        /// <param name="shiftPatternCode">The shift P attern code.</param>
        /// <param name="action">The STR action.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftPatternSave(string locationAutoId, string clientCode, string asmtId, string shiftPatternId, string shiftPattern, string shiftPatternCode, string action, string status, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ShiftPatternID, shiftPatternId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ShiftPattern, shiftPattern);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Action, action);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ShiftPattern_Save", objParam);
            return ds;
        }
        /// <summary>
        /// To Create new shift pattern sequence
        /// </summary>
        /// <param name="locationAutoId">The locationAutoId.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="patternSequenceAutoId">The pattern seq auto ID.</param>
        /// <param name="patternSequenceCode">The pattern seq code.</param>
        /// <param name="shiftPatternSequence">The shift pattern seq.</param>
        /// <param name="action">The STR action.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftPatternSequenceSave(string locationAutoId, string clientCode, string asmtId, string patternSequenceAutoId, string patternSequenceCode, string shiftPatternSequence, string action, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PatternSeqAutoID, long.Parse(patternSequenceAutoId));
            objParam[4] = new SqlParameter(DL.Properties.Resources.PatternSeqCode, patternSequenceCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PatternSeq, shiftPatternSequence);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Action, action);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ShiftPatternSeq_Save", objParam);
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
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.PatternSeqAutoID, long.Parse(patternSequenceAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ShiftPatternSeqDelete", objParam);
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
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPatternSequenceGet", objParam);
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
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.PatternSeqAutoID, patternSeqAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSplitPatternsFromSequence", objParam);
            return ds;
        }
        /// <summary>
        /// To Create a new shift pattern from existing shift pattern using copy
        /// </summary>
        /// <param name="locationAutoId">The locationAutoId.</param>
        /// <param name="asmtCode">The asmt no.</param>
        /// <param name="shiftPatternId">The shift pattern ID.</param>
        /// <param name="userShiftPattern">The STR user shift pattern.</param>
        /// <param name="copyToAsmt">The copy to asmt.</param>
        /// <param name="flag">The STR flag.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtCopyShiftPatternSave(string locationAutoId, string asmtCode, string shiftPatternId, string userShiftPattern, string copyToAsmt, string flag)
        {

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FromAsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ShiftPattern, shiftPatternId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.UserShiftPattern, userShiftPattern);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToAsmtCode, copyToAsmt);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Flag, int.Parse(flag));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CopyAsmtshiftpattern", objParam);
            return ds;
        }


        /// <summary>
        /// To Delete existing shift pattern
        /// </summary>
        /// <param name="shiftPattern">The shift pattern.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftPatternDelete(string shiftPattern, string clientCode, string asmtId, int locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ShiftPattern, shiftPattern);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AsmtShiftPattern_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Shift Code and PDLine No Based on Shift Pattern ID.
        /// </summary>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="shiftPatternId">The STR shift pattern ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftPatternGet(string locationAutoId, string clientCode, string asmtId, string shiftPatternId)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ShiftPatternID, shiftPatternId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AsmtShiftPattern_GetShiftCodeAndSoLineNo", objParam);
            return ds;
        }
        #endregion

        #region Function Related to New Scheduling Screen Employee Wise
        /// <summary>
        /// To Insert Data in Scheduling by applying Pattern
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
        /// <param name="post">The post.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="weekNo">The week no.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeScheduleInsert(string asmtCode, string fromDate, string toDate, bool defaultSite, string employeeNumber, string designationCode, string shiftPatternCode, int patternPosition, string soRank, string locationAutoId, string modifiedBy, int rowNumber, string post, string sessionId, string weekNo)
        {

            //SqlParameter[] objParm = new SqlParameter[15];
            //objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            //objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            //objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            //objParm[3] = new SqlParameter(DL.Properties.Resources.DefaultSite, defaultSite);
            //objParm[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            //objParm[5] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            //objParm[6] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            //objParm[7] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            //objParm[8] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            //objParm[9] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            //objParm[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            //objParm[11] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            //objParm[12] = new SqlParameter(DL.Properties.Resources.Post, post);
            //objParm[13] = new SqlParameter(DL.Properties.Resources.SessionID, sessionId);
            //objParm[14] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_Insert", objParm);
            //return ds;

            SqlParameter[] objParm = new SqlParameter[12];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParm[6] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[8] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[9] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParm[10] = new SqlParameter(DL.Properties.Resources.SessionID, sessionId);
            objParm[11] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_Insert", objParm);
            return ds;

        }

        /// <summary>
        /// Insert Data Single Date DATA in Scheduling Screen..
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="weekNo">The int week.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The STR designation code.</param>
        /// <param name="shiftPatternCode">The STR shift pattern code.</param>
        /// <param name="patternPosition">The STR pattern position.</param>
        /// <param name="defaultSite">The STR default site.</param>
        /// <param name="operationShift">The STR OPS shift.</param>
        /// <param name="soRank">The STR SO rank.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="scheduleRosterAutoId">The int schedule roster auto ID.</param>
        /// <param name="pdLineNo">The PD line no.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="post">The STR post.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="sessionValue">The STR session value.</param>
        /// <returns>DataSet.</returns>
        public DataSet NewScheduleRosterInsert(string asmtCode, string employeeNumber, string dutyDate, string shiftCode, int weekNo, string roleCode, string designationCode, string shiftPatternCode, string patternPosition, string defaultSite, string operationShift, string soRank, string timeFrom, string timeTo, string dutyTypeCode, int scheduleRosterAutoId, int pdLineNo, string locationAutoId, string modifiedBy, int rowNumber, string post, string fromDate, string toDate, string sessionValue)
        {

            SqlParameter[] objParm = new SqlParameter[24];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[8] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParm[9] = new SqlParameter(DL.Properties.Resources.DefaultSite, defaultSite);
            objParm[10] = new SqlParameter(DL.Properties.Resources.OPSShift, operationShift);
            objParm[11] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParm[12] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[13] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[14] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[15] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[16] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[17] = new SqlParameter(DL.Properties.Resources.LocationAutoId, int.Parse(locationAutoId));
            objParm[18] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[19] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[20] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParm[21] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[22] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[23] = new SqlParameter(DL.Properties.Resources.SessionID, sessionValue);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_NewScheduleRoster_Insert", objParm);
            return ds;

        }

        /// <summary>
        /// Function to overwrite Shift.
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="weekNo">The int week.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The STR designation code.</param>
        /// <param name="shiftPatternCode">The STR shift pattern code.</param>
        /// <param name="patternPosition">The STR pattern position.</param>
        /// <param name="defaultSite">The STR default site.</param>
        /// <param name="operationShift">The STR OPS shift.</param>
        /// <param name="soRank">The STR SO rank.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="scheduleRosterAutoId">The int schedule roster auto ID.</param>
        /// <param name="pdLineNo">The PD line no.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="duplicateScheduleRosterAutoId">The STR dup SCH roster auto ID.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <returns>DataSet.</returns>
        public DataSet NewScheduleRosterShiftOverwrite(string asmtCode, string employeeNumber, string dutyDate, string shiftCode, int weekNo, string roleCode, string designationCode, string shiftPatternCode, string patternPosition, string defaultSite, string operationShift, string soRank, string timeFrom, string timeTo, string dutyTypeCode, int scheduleRosterAutoId, int pdLineNo, string locationAutoId, string modifiedBy, string duplicateScheduleRosterAutoId, int rowNumber, string fromDate, string toDate)
        {

            SqlParameter[] objParm = new SqlParameter[23];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[8] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParm[9] = new SqlParameter(DL.Properties.Resources.DefaultSite, defaultSite);
            objParm[10] = new SqlParameter(DL.Properties.Resources.OPSShift, operationShift);
            objParm[11] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParm[12] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[13] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[14] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[15] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[16] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[17] = new SqlParameter(DL.Properties.Resources.LocationAutoId, int.Parse(locationAutoId));
            objParm[18] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[19] = new SqlParameter(DL.Properties.Resources.DupSchRosterAutoId, duplicateScheduleRosterAutoId);
            objParm[20] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[21] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[22] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_NewScheduleRoster_OverWriteShift", objParm);
            return ds;

        }

        /// <summary>
        /// To Delete a single record of schedule on the basis of Id
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster auto ID.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet NewScheduleRosterDelete(string scheduleRosterAutoId, int rowNumber)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_NewScheduleRoster_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To Delete schedule row of an employee
        /// </summary>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="shiftPatternCode">The STR shift pattern code.</param>
        /// <param name="patternPosition">The int pattern position.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWiseScheduleDelete(string employeeNumber, string asmtCode, string fromDate, string toDate, string shiftPatternCode, int patternPosition, int rowNumber)
        {

            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParam[6] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_EmployeeWiseSchedule_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// To Get schedule record(s) of an employee
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="fromDate">The dt from date.</param>
        /// <param name="toDate">The dt to date.</param>
        /// <param name="post">The STR post.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="searchEmployeeNumber">The search employee number.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>


        public DataSet EmployeeWiseScheduleRosterGetAll(string clientCode, string asmtId, string locationAutoId, string fromDate, string toDate, string post, string attendanceType, string searchEmployeeNumber, string pageNumber, string areaId, string areaIncharge, string isAreaIncharge)
        {

            SqlParameter[] objParm = new SqlParameter[12];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, searchEmployeeNumber);
            objParm[7] = new SqlParameter(DL.Properties.Resources.PageNumber, pageNumber);
            objParm[8] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[9] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[10] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[11] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetAll", objParm);
            return ds;
        }


        /// <summary>
        /// To Get list of shift names of an assignment
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="weekNo">The STR week no.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleRosterEmployeeWiseGetShift(string asmtCode, string locationAutoId, string dutyDate, string weekNo)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetShift", objParm);

            return ds;
        }
        /// <summary>
        /// To Get total schedule hours of an employee
        /// </summary>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="employeeNumber">The STR emp number.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <returns>DataTable.</returns>
        public DataTable TotalHoursOfEmployeeGet(string fromDate, string toDate, string employeeNumber, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            return SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetTotalHoursOfEmployee", objParm);

        }

        /// <summary>
        /// To Get system parameter values
        /// </summary>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <param name="selectedMonthStartDate">The STR selected month start date.</param>
        /// <param name="scheduleType">Type of the STR schedule.</param>
        /// <returns>DataTable.</returns>
        public DataTable SystemParametersGet(string companyCode, string hrLocationCode, string locationCode, string selectedMonthStartDate, string scheduleType)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.StartDate, selectedMonthStartDate);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ScheduleType, scheduleType);
            return SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetSystemParameters", objParm);

        }

        /// <summary>
        /// To get the Allow Borrow Employee System Parameters Value
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataTable.</returns>
        public DataTable AllowBorrowEmployeeSystemParametersGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            return SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpAllowBorrowEmployeeSystemParameterGet", objParm);
        }

        /// <summary>
        /// Get Max Duty Min in A week
        /// </summary>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MaxDutyMinutesInWeekGet(string companyCode, string hrLocationCode, string locationCode)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_MaxDutyMinInWeek", objParm);
            return ds;

        }

        /// <summary>
        /// Get Max Duty Min in A week
        /// </summary>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetOTAndMaxDutyMinutesInWeekGet(string companyCode, string hrLocationCode, string locationCode)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetOTAndMaxDutyMinInWeek", objParm);
            return ds;

        }

        /// <summary>
        /// To Get all Break Hrs of the Employee on a given Date.
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR SCH roster auto ID.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="areaId">The STR area ID.</param>
        /// <param name="areaIncharge">The STR area incharge.</param>
        /// <param name="isAreaIncharge">The STR is area incharge.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <returns>DataSet.</returns>
        public DataSet BreakHoursGetAll(string scheduleRosterAutoId, string companyCode, string hrLocationCode, string locationCode, string attendanceType, string areaId, string areaIncharge, string isAreaIncharge, string fromDate)
        {


            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[7] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[8] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(fromDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_BreakHoursGetAll", objParm);
            return ds;
        }



        /// <summary>
        /// To Insert Break Hrs..
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR schedule roster auto ID.</param>
        /// <param name="newEmployeeScheduleRosterAutoId">The STR new emp SCH roster auto ID.</param>
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
        /// <param name="breakHourAutoId">The break hour auto ID.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="assignmentName">Name of the assignment.</param>
        /// <param name="postDesc">The post desc.</param>
        /// <param name="weekNo">The week no.</param>
        /// <returns>DataSet.</returns>
        public DataSet BreakHoursInsert(string scheduleRosterAutoId, string newEmployeeScheduleRosterAutoId, string employeeNumber, string employeeNumberReplace, string dutyDate, string timeFrom, string timeTo, string status, bool isPayable, string modifiedBy, string attendanceType, string operationType, string breakHourAutoId, string clientCode, string asmtId, string postCode, string clientName, string assignmentName, string postDesc, string weekNo)
        {

            SqlParameter[] objParm = new SqlParameter[20];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumberRep, employeeNumberReplace);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeFrom,  DL.Common.DateFormat(timeFrom));
            objParm[5] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[6] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[7] = new SqlParameter(DL.Properties.Resources.IsPayable, isPayable);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[9] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[10] = new SqlParameter(DL.Properties.Resources.OperationType, operationType);
            objParm[11] = new SqlParameter(DL.Properties.Resources.NewEmpSchRosterAutoId, newEmployeeScheduleRosterAutoId);
            objParm[12] = new SqlParameter(DL.Properties.Resources.BreakHourAutoId, breakHourAutoId);
            objParm[13] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[14] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[15] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[16] = new SqlParameter(DL.Properties.Resources.ClientName, clientName);
            objParm[17] = new SqlParameter(DL.Properties.Resources.Assignment, assignmentName);
            objParm[18] = new SqlParameter(DL.Properties.Resources.PostDesc, postDesc);
            objParm[19] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_BreakHoursInsert", objParm);
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
        public DataSet CheckBreakHoursRule(string scheduleRosterAutoId, string timeFrom, string timeTo, string maxBreakHours, string breakAutoID, string attendanceType)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[2] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[3] = new SqlParameter(DL.Properties.Resources.BreakHrs, maxBreakHours);
            objParm[4] = new SqlParameter(DL.Properties.Resources.BreakHourAutoId, breakAutoID);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_CheckBreakHoursRule", objParm);
            return ds;
        }

        /// <summary>
        /// Breaks the hours update.
        /// </summary>
        /// <param name="scheduleRosterAutoId">The schedule roster automatic identifier.</param>
        /// <param name="replacedScheduleRosterAutoId">The replaced schedule roster automatic identifier.</param>
        /// <param name="newEmployeeNumber">The new employee number.</param>
        /// <param name="fromTime">From time.</param>
        /// <param name="toTime">To time.</param>
        /// <param name="isPayable">if set to <c>true</c> [is payable].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="breakHourAutoId">The break hour automatic identifier.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet BreakHoursUpdate(string scheduleRosterAutoId, string replacedScheduleRosterAutoId, string newEmployeeNumber, string fromTime, string toTime, bool isPayable, string modifiedBy, string attendanceType, string breakHourAutoId, string dutyDate)
        {
            if (string.IsNullOrEmpty(replacedScheduleRosterAutoId))
            {
                replacedScheduleRosterAutoId = "0";
            }
            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ReplacedSchRosterAutoId, replacedScheduleRosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.NewEmployeeNumber, newEmployeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, fromTime);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, toTime);
            objParm[5] = new SqlParameter(DL.Properties.Resources.IsPayable, isPayable);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[8] = new SqlParameter(DL.Properties.Resources.BreakHourAutoId, breakHourAutoId);
            objParm[9] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            DataSet dsUpdate = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_BreakHoursUpdate", objParm);
            return dsUpdate;
        }

        /// <summary>
        /// Delete Break Hours.
        /// </summary>
        /// <param name="breakHourAutoId">The break hour auto ID.</param>
        /// <param name="scheduleRosterAutoId">The schedule roster auto ID.</param>
        /// <param name="replacedScheduleRosterAutoId">The replaced SCH roster auto ID.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet BreakHoursDelete(string breakHourAutoId, string scheduleRosterAutoId, string replacedScheduleRosterAutoId, string attendanceType)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BreakHourAutoId, breakHourAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ReplacedSchRosterAutoId, replacedScheduleRosterAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);

            DataSet dsDelete = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_BreakHoursDelete", objParm);
            return dsDelete;
        }
        /// <summary>
        /// To get monthly schedule
        /// </summary>
        /// <param name="month">The STR month.</param>
        /// <param name="year">The STR year.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleEmployeeWiseGet(string month, string year)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Month, month);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Year, year);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetBiMonthlyDates", objParm);
            return ds;
        }

        /// <summary>
        /// ToGet Role transaction and Role MAster based on Area ID.
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR SCH roster auto ID.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="areaId">The STR area ID.</param>
        /// <param name="areaIncharge">The STR area incharge.</param>
        /// <param name="isAreaIncharge">The STR is area incharge.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleGetAll(string scheduleRosterAutoId, string companyCode, string hrLocationCode, string locationCode, string attendanceType, string areaId, string areaIncharge, string isAreaIncharge, string fromDate)
        {

            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[7] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[8] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(fromDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_RoleGetAll", objParm);
            return ds;
        }

        /// <summary>
        /// To Insert duty Role of employee
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR schedule roster auto ID.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleInsert(string scheduleRosterAutoId, string roleCode, string timeFrom, string timeTo, string dutyDate, string locationAutoId, string modifiedBy, string attendanceType)
        {

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[4] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);

            //SqlDataReader objReader = SqlHelper.ExecuteReader("udpTransaction_ScheduleEmpWise_RoleInsert", false, objParm);
            //dt.Load(objReader);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_RoleInsert", objParm);
            return ds;
        }

        /// <summary>
        /// To update employee duty Role
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR schedule roster auto ID.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="roleAutoId">The STR role auto ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleUpdate(string scheduleRosterAutoId, string roleCode, string timeFrom, string timeTo, string dutyDate, string locationAutoId, string modifiedBy, string attendanceType, string roleAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[4] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[8] = new SqlParameter(DL.Properties.Resources.RoleAutoId, roleAutoId);

            //SqlDataReader objReader = SqlHelper.ExecuteReader("udpTransaction_ScheduleEmpWise_RoleInsert", false, objParm);
            //dt.Load(objReader);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_RoleUpdate", objParm);
            return ds;
        }

        /// <summary>
        /// To Delete Role
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR SCH roster auto ID.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="roleAutoId">The STR role auto ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleDelete(string scheduleRosterAutoId, string dutyDate, string attendanceType, string roleAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[3] = new SqlParameter(DL.Properties.Resources.RoleAutoId, roleAutoId);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_RoleDelete", objParm);
            return ds;
        }
        #region Task Master Related Objects
        /// <summary>
        /// ToGet Task transaction and Task MAster based on Area ID.
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR SCH roster auto ID.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="hrLocationCode">The STR hr location code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <param name="attendanceType">Type of the STR attendance.</param>
        /// <param name="areaId">The STR area ID.</param>
        /// <param name="areaIncharge">The STR area incharge.</param>
        /// <param name="isAreaIncharge">The STR is area incharge.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <returns>DataSet.</returns>
        public DataSet TaskGetAll(string scheduleRosterAutoId, string companyCode, string hrLocationCode, string locationCode, string attendanceType, string areaId, string areaIncharge, string isAreaIncharge, string fromDate)
        {

            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[7] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[8] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(fromDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_TaskGetAll", objParm);
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TaskAutoId, taskAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.trnTaskAutoID, trnTaskAutoID);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_TaskDelete", objParm);
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

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[2] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[6] = new SqlParameter(DL.Properties.Resources.TaskAutoId, taskAutoId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.trnTaskAutoID, trnTaskAutoID);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_TaskUpdate", objParm);
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

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.TaskAutoId, taskAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[4] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_TaskInsert", objParm);
            return ds;
        }
        #endregion
        /// <summary>
        /// To Get posts of an assignmnet.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt id.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostGetAll(string clientCode, string asmtId, string locationAutoId, string fromDate, string toDate)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetAllPost", objParm);
            return ds;
        }

        /// <summary>
        /// Get Borrowed Employees Details.
        /// </summary>
        /// <param name="employeeNumber">The emp number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="postcode">The post code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="maxDate">The maximum date.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet BorrowedEmployeeDetailsGet(string employeeNumber, string clientCode, string asmtId, string locationAutoId, string postcode, string fromDate, string toDate, string maxDate, string areaId, string areaIncharge, string isAreaIncharge)
        {

            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.MaxToDate, DL.Common.DateFormat(maxDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[9] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[10] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetBorrowedEmployeeDetails", objParm);
            return ds;
        }
        #endregion

        #region Function Related to New Rota Screen Employee Wise
        /// <summary>
        /// To Get roster (attendance) of post.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="fromDate">The dt from date.</param>
        /// <param name="toDate">The dt to date.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="searchEmployeeNumber">The search employee number.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>


        public DataSet RosterEmployeeWiseGetAll(string clientCode, string asmtId, string locationAutoId, string fromDate, string toDate, string postcode, string attendanceType, string searchEmployeeNumber, string pageNumber, string areaId, string areaIncharge, string isAreaIncharge)
        {


            SqlParameter[] objParm = new SqlParameter[12];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.Post, postcode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, searchEmployeeNumber);
            objParm[7] = new SqlParameter(DL.Properties.Resources.PageNumber, pageNumber);
            objParm[8] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[9] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[10] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[11] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_RosterEmpWise_GetAll", objParm);
            return ds;
        }


        /// <summary>
        /// To Insert Single Shift In Actual Mode.
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="weekNo">The int week.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The STR designation code.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="rosterAutoId">The int roster auto ID.</param>
        /// <param name="pdLineNo">The PD line no.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="post">The STR post.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="sessionId">The STR session ID.</param>
        /// <param name="ShiftPatternCode">The shift pattern code.</param>
        /// <param name="PatternPosition">The pattern position.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterEmployeeWiseInsert(string asmtCode, string employeeNumber, string dutyDate, string shiftCode, int weekNo, string roleCode, string designationCode, string timeFrom, string timeTo, string dutyTypeCode, int rosterAutoId, int pdLineNo, string locationAutoId, string modifiedBy, int rowNumber, string post, string fromDate, string toDate, string sessionId, string ShiftPatternCode, string PatternPosition)
        {

            SqlParameter[] objParm = new SqlParameter[21];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[8] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[9] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[10] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[11] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[12] = new SqlParameter(DL.Properties.Resources.LocationAutoId, int.Parse(locationAutoId));
            objParm[13] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[14] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[15] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParm[16] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[17] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[18] = new SqlParameter(DL.Properties.Resources.SessionID, sessionId);
            objParm[19] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, ShiftPatternCode);
            objParm[20] = new SqlParameter(DL.Properties.Resources.PatternPosition, PatternPosition);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_RotaEmpWise_Insert", objParm);
            return ds;

        }

        /// <summary>
        /// To OverWrite duplicates schedule records
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="shiftCode">The STR shift code.</param>
        /// <param name="weekNo">The int week.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The STR designation code.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="rosterAutoId">The int roster auto ID.</param>
        /// <param name="pdLineNo">The PD line no.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="duplicateRosterAutoId">The dup roster auto ID.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverwriteDuplicateRota(string asmtCode, string employeeNumber, string dutyDate, string shiftCode, int weekNo, string roleCode, string designationCode, string timeFrom, string timeTo, string dutyTypeCode, int rosterAutoId, int pdLineNo, string locationAutoId, string modifiedBy, string duplicateRosterAutoId, int rowNumber, string fromDate, string toDate)
        {

            SqlParameter[] objParm = new SqlParameter[18];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[8] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[9] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[10] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[11] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[12] = new SqlParameter(DL.Properties.Resources.LocationAutoId, int.Parse(locationAutoId));
            objParm[13] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[14] = new SqlParameter(DL.Properties.Resources.DupRosterAutoId, duplicateRosterAutoId);
            objParm[15] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[16] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[17] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_RotaEmpWise_OverWriteDuplicateRecord", objParm);
            return ds;
        }

        /// <summary>
        /// Delete Rota
        /// </summary>
        /// <param name="rosterAutoId">The roster auto ID.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet NewRosterDelete(string rosterAutoId, int rowNumber, string dutyDate, string employeeNumber, string locationAutoId, string asmtCode)
        {

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_NewRoster_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To Delete Rota
        /// </summary>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWiseRotaDelete(string employeeNumber, string asmtCode, string fromDate, string toDate, int rowNumber)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_EmployeeWiseRota_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To Insert rota     patternwise
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="designationCode">The STR designation code.</param>
        /// <param name="shiftPatternCode">The STR shift pattern code.</param>
        /// <param name="patternPosition">The int pattern position.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="post">The STR post.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterEmployeeWiseInsertPattern(string asmtCode, string fromDate, string toDate, string employeeNumber, string designationCode, string shiftPatternCode, int patternPosition, string locationAutoId, string modifiedBy, int rowNumber, string post)
        {

            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParm[7] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[9] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[10] = new SqlParameter(DL.Properties.Resources.Post, post);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_RotaEmpWise_InsertPatternWise", objParm);
            return ds;

        }

        /// <summary>
        /// To Get total Additional Hours
        /// </summary>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="postcode">The STR post code.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWiseTotalAdditionalHoursGet(string fromDate, string toDate, string clientCode, string asmtCode, string postcode, string locationAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_RosterEmpWise_GetTotalAdditionalHours", objParm);
            return ds;

        }
        /// <summary>
        /// To Search Employee who match or who dont match the Skills entered in Sale Order
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postcode">The post code.</param>
        /// <param name="locationAutoId">The location auto ID.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaId">The area ID.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="searchEmployeeNumber">The search employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleEmployeeWiseSkillsMatchMismatchGet(string asmtCode, string postcode, string locationAutoId, string fromDate, string toDate, string areaId, string isAreaIncharge, string areaIncharge, string pageNumber, string pageSize, string searchEmployeeNumber)
        {

            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[8] = new SqlParameter(DL.Properties.Resources.PageNumber, pageNumber);
            objParm[9] = new SqlParameter(DL.Properties.Resources.PageSize, pageSize);
            objParm[10] = new SqlParameter(DL.Properties.Resources.SearchEmployeeNumber, searchEmployeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_SkillsMatchMismatchGet", objParm);
            return ds;
        }
        #endregion

        #region Function Related To Schedule
        #region Function related to get data
        #region Get Required manpawer of a assignment for scheduling

        /// <summary>
        /// To Get Req Hrs/Count.
        /// </summary>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="asmtMasterAutoId">The int asmt master auto id.</param>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="postcode">The STR post code.</param>
        /// <param name="scheduleType">Type of the schedule.</param>
        /// <param name="weekNo">The week no.</param>
        /// <returns>DataSet.</returns>
        public DataSet ManpowerRequirementGet(string fromDate, string toDate, int asmtMasterAutoId, int locationAutoId, string postcode, string scheduleType, int weekNo)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ScheduleType, scheduleType);
            objParm[6] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_GetReqManP", objParm);
            return ds;
        }
        /// <summary>
        /// To Get required person on a post.
        /// </summary>
        /// <param name="asmtMasterAutoId">The int asmt master auto id.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="pdLineNo">The int pd line no.</param>
        /// <param name="element">The STR element.</param>
        /// <returns>DataSet.</returns>
        public DataSet PersonRequiredOnsiteGet(int asmtMasterAutoId, string fromDate, string toDate, int pdLineNo, string element)
        {

            SqlParameter[] objParm = new SqlParameter[5];

            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ElementId, element);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOps_SitePost_GetPersonRequired", objParm);

            return ds;
        }
        #endregion
        #region Get Scheduled manpawer
        /// <summary>
        /// To Get Schedule Hrs/Count .
        /// </summary>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="postcode">The STR post code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduledManpowerGet(string fromDate, string toDate, string asmtCode, int locationAutoId, string postcode)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_GetSchManP", objParm);
            return ds;
        }
        #endregion
        #region Get Actual manpawer
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
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_GetActManP", objParm);
            return ds;
        }
        #endregion

        #region Get Asmt Items
        /// <summary>
        /// To Get pdLine(site\post) of an assignment
        /// </summary>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="asmtMasterAutoId">The int asmt master auto id.</param>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtItemsGet(string fromDate, string toDate, int asmtMasterAutoId, int locationAutoId, string asmtCode)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_GetAsmtItems", objParm);
            return ds;
        }
        #endregion
        #region Get AsmtItemDetail
        /// <summary>
        /// To Get PdLine(site\post) wise details along with shifts
        /// </summary>
        /// <param name="asmtMasterAutoId">The int asmt master auto id.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="soLineNo">The int so line no.</param>
        /// <param name="pdLineNo">The int pd line no.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR todate.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtItemDetailGet(int asmtMasterAutoId, string asmtCode, int locationAutoId, int soLineNo, int pdLineNo, string fromDate, string toDate)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_GetAsmtItemDetail", objParm);
            return ds;
        }
        #endregion
        #region Get AsmtShift
        /// <summary>
        /// Asmts the shift get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtShiftGet(int asmtMasterAutoId, int soLineNo, int pdLineNo)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_GetAsmtShift", objParm);
            return ds;
        }
        #endregion
        #region Get Schedule By Pdline
        /// <summary>
        /// To Get Schedule (PdLine wise)
        /// </summary>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="pdLineNo">The int pd line no.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleGet(int locationAutoId, string asmtCode, int pdLineNo, string fromDate, string toDate)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_GetByPdLine", objParm);
            return ds;
        }
        #endregion
        #region Get Shift Patterns
        /// <summary>
        /// To Get Shift pattern(s)
        /// </summary>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="shifts">The STR shifts.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftPatternsGet(int locationAutoId, string clientCode, string shifts)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ShiftCode, shifts);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_GetShiftPatterns", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Shift Pattern When We Double Click Shift Pattern TextBox in schedule Roster Screen
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftPatternGet(int locationAutoId, string asmtCode, int pdLineNo)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ShiftPattern_Get", objParm);
            return ds;
        }
        #endregion
        #region Get Info based on locationAutoId,AsmtCode,PDLine Number,With Effective date of termination screen
        /// <summary>
        /// To Get schedule records
        /// </summary>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="pdLineNo">The STR PD line no.</param>
        /// <param name="withEffectiveDate">The with effective date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleRosterGet(string locationAutoId, string asmtCode, string pdLineNo, DateTime withEffectiveDate)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.WithEffectiveDate, DL.Common.DateFormat(withEffectiveDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SalesOPSTermination_GetScheduleDetail", objParm);

            return ds;
        }
        #endregion
        #endregion
        #region Function related to Insert data
        #region Insert Schedule Roster
        /// <summary>
        /// To Save schedule records of an employee
        /// </summary>
        /// <param name="asmtMasterAutoId">The int asmt master auto ID.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="pdLineNo">The int PD line no.</param>
        /// <param name="dt">The dt.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The strdesignation code.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="shiftPatternCode">The STR shift pattern code.</param>
        /// <param name="patternPosition">The intpattern position.</param>
        /// <param name="defaultSite">The STR default site.</param>
        /// <param name="opsShift">The STR ops shift.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="soRank">The STR SO rank.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dt</exception>
        public DataSet ScheduleRosterInsert(int asmtMasterAutoId, string asmtCode, int locationAutoId, int pdLineNo, DataTable dt, string employeeNumber, string roleCode, string designationCode, string dutyTypeCode, string shiftPatternCode, int patternPosition, string defaultSite, string opsShift, string modifiedBy, string soRank)
        {
            string dutyDate, shiftCode, strweekNum;

            if (dt == null || dt.Rows == null)
            {
                throw new ArgumentNullException("dt");
            }

            DataSet ds = new DataSet();
            DataSet dsReturn = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            dsReturn.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParm = new SqlParameter[17];

            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[6] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[10] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[11] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[12] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParm[13] = new SqlParameter(DL.Properties.Resources.OPSShift, opsShift);
            objParm[14] = new SqlParameter(DL.Properties.Resources.DefaultSite, defaultSite);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[16] = new SqlParameter(DL.Properties.Resources.SORank, soRank);

            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    dutyDate = dt.Rows[k][DL.Properties.Resources.fldDutyDate].ToString();
                    shiftCode = dt.Rows[k][DL.Properties.Resources.fldShiftCode].ToString();
                    strweekNum = dt.Rows[k][DL.Properties.Resources.fldWeekNum].ToString();
                    objParm[4] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
                    objParm[8] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
                    objParm[9] = new SqlParameter(DL.Properties.Resources.WeekNo, strweekNum);

                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranScheduleRoster_Insert", objParm);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (dsReturn.Tables.Count == 0)
                            {
                                dsReturn.Tables.Add(ds.Tables[0].Clone());
                            }

                            dsReturn.Tables[0].ImportRow(ds.Tables[0].Rows[0]);

                        }
                    }
                }
                tx.Complete();
            }
            ds.Dispose();

            return dsReturn;
        }
        #endregion
        #region Re Schedule
        /// <summary>
        /// To OverWrite existing schedule
        /// </summary>
        /// <param name="asmtMasterAutoId">The int asmt master auto ID.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="pdLineNo">The int PD line no.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="roleCode">The STR role code.</param>
        /// <param name="designationCode">The strdesignation code.</param>
        /// <param name="dutyTypeCode">The STR duty type code.</param>
        /// <param name="shiftPatternCode">The STR shift pattern code.</param>
        /// <param name="patternPosition">The intpattern position.</param>
        /// <param name="defaultSite">The STR default site.</param>
        /// <param name="opsShift">The STR ops shift.</param>
        /// <param name="soRank">The STR SO rank.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="concatenatedDetail">The STR concatenated detail.</param>
        /// <returns>DataSet.</returns>
        public DataSet Reschedule(int asmtMasterAutoId, string asmtCode, int locationAutoId, int pdLineNo, string employeeNumber, string roleCode, string designationCode, string dutyTypeCode, string shiftPatternCode, int patternPosition, string defaultSite, string opsShift, string soRank, string modifiedBy, string concatenatedDetail)
        {

            SqlParameter[] objParm = new SqlParameter[15];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            // objParm[4] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            //objParm[8] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            //objParm[9] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParm[7] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[9] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParm[10] = new SqlParameter(DL.Properties.Resources.OPSShift, opsShift);
            objParm[11] = new SqlParameter(DL.Properties.Resources.DefaultSite, defaultSite);
            // objParm[15] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, intSchRosterAutoID);
            objParm[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[13] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParm[14] = new SqlParameter(DL.Properties.Resources.ConcatenatedDetail, concatenatedDetail);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranScheduleRoster_ReSchedule", objParm);

            return ds;
        }
        #endregion
        #region Function Related To Schedule vs Actual Comparision
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Actual_Schedule_Comparison_Report", objParm);
            return ds;
        }
        #endregion


        #region Function to OverWrite single Shift
        /// <summary>
        /// Schedules the roster shift overwrite.
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
        /// <param name="position">The position.</param>
        /// <param name="isDefaultSite">The is default site.</param>
        /// <param name="operationShift">The operation shift.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleRosterShiftOverwrite(string asmtCode, string employeeNumber, DateTime dutyDate, string shiftCode, int pdLineNo, int asmtMasterAutoId, int rosterAutoId, string locationAutoId, string weekNo, string roleCode, string designationCode, string dutyTypeCode, string shiftPatternCode, string position, string isDefaultSite, string operationShift, string soRank, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[18];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, rosterAutoId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParm[9] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[10] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[11] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[12] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[13] = new SqlParameter(DL.Properties.Resources.PatternPosition, position);
            objParm[14] = new SqlParameter(DL.Properties.Resources.IsDefaultSite, isDefaultSite);
            objParm[15] = new SqlParameter(DL.Properties.Resources.OPSShift, operationShift);
            objParm[16] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParm[17] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranScheduleRoster_OverWriteShift", objParm);
            return ds;
        }
        #endregion
        #endregion
        #region Function related Delete
        #region Delete Schedule Roster
        /// <summary>
        /// To Delete schedule of an employee
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="pdLineNo">The int pd line no.</param>
        /// <param name="employeeNumber">The STR emp no.</param>
        /// <param name="shiftPatternCode">The STR shift pat code.</param>
        /// <param name="fromDate">The STR date from.</param>
        /// <param name="toDate">The STR date to.</param>
        /// <param name="shift">The STR shift.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleRosterDelete(string asmtCode, int locationAutoId, int pdLineNo, string employeeNumber, string shiftPatternCode, string fromDate, string toDate, string shift)
        {

            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.Shift, shift);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranScheduleRoster_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// To Delete schedule in bulk
        /// </summary>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="terminationDate">The STR termination date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleBulkDeletion(string employeeNumber, string terminationDate)
        {

            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(terminationDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Schedule_BulkDelete", objParm);
            return ds;
        }

        #endregion
        #endregion
        #region Function related To schedule convert
        #region Convert Schedule Into Rota
        /// <summary>
        /// To Convert schedule into actual rota
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dt</exception>
        public DataSet ConvertScheduleIntoRota(DataTable dt, string modifiedBy)
        {
            if (dt == null || dt.Rows == null)
            {
                throw new ArgumentNullException("dt");
            }
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            SqlParameter[] objParm = new SqlParameter[2];
            int intSchRosterautoID;
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                intSchRosterautoID = int.Parse(dt.Rows[k][DL.Properties.Resources.fldSchRosterAutoId].ToString());
                objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, intSchRosterautoID);
                objParm[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranSchedule_ConvertIntoRota", objParm);
            }

            return ds;
        }
        #endregion
        #region Update Schedule
        /// <summary>
        /// To update schedule
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dt</exception>
        public DataSet ScheduleRosterUpdate(DataTable dt, string modifiedBy)
        {

            if (dt == null || dt.Rows == null)
            {
                throw new ArgumentNullException("dt");
            }
            DataSet ds = new DataSet();
            DataSet dsReturn = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            dsReturn.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParm = new SqlParameter[7];
            int intSchRosterautoID;
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    intSchRosterautoID = int.Parse(dt.Rows[k][DL.Properties.Resources.fldSchRosterAutoId].ToString());
                    objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, intSchRosterautoID);
                    objParm[1] = new SqlParameter(DL.Properties.Resources.TimeFrom, (dt.Rows[k][DL.Properties.Resources.fldTimeFrom].ToString()));
                    objParm[2] = new SqlParameter(DL.Properties.Resources.TimeTo, (dt.Rows[k][DL.Properties.Resources.fldTimeTo].ToString()));
                    objParm[3] = new SqlParameter(DL.Properties.Resources.RoleCode, dt.Rows[k][DL.Properties.Resources.fldRoleCode].ToString());
                    objParm[4] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dt.Rows[k][DL.Properties.Resources.fldDutyTypeCode].ToString());
                    objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                    objParm[6] = new SqlParameter(DL.Properties.Resources.ControlClientID, dt.Rows[k][DL.Properties.Resources.fldControlClientId].ToString());
                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranScheduleRoster_Update", objParm);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (dsReturn.Tables.Count == 0)
                            {
                                dsReturn.Tables.Add(ds.Tables[0].Clone());
                            }
                            dsReturn.Tables[0].ImportRow(ds.Tables[0].Rows[0]);
                        }
                    }
                }
                tx.Complete();
            }
            ds.Dispose();

            return dsReturn;
        }
        #endregion
        #region Update Rota
        /// <summary>
        /// To Update Rota
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dt</exception>
        public DataSet RosterUpdate(DataTable dt, string modifiedBy)
        {

            if (dt == null || dt.Rows == null)
            {
                throw new ArgumentNullException("dt");
            }

            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InstalledUICulture;
            SqlParameter[] objParm = new SqlParameter[6];
            int intSchRosterautoID;
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                intSchRosterautoID = int.Parse(dt.Rows[k][DL.Properties.Resources.fldSchRosterAutoId].ToString());
                objParm[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, intSchRosterautoID);
                objParm[1] = new SqlParameter(DL.Properties.Resources.TimeFrom, (dt.Rows[k][DL.Properties.Resources.fldTimeFrom].ToString()));
                objParm[2] = new SqlParameter(DL.Properties.Resources.TimeTo, (dt.Rows[k][DL.Properties.Resources.fldTimeTo].ToString()));
                objParm[3] = new SqlParameter(DL.Properties.Resources.RoleCode, dt.Rows[k][DL.Properties.Resources.fldRoleCode].ToString());
                objParm[4] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dt.Rows[k][DL.Properties.Resources.fldDutyTypeCode].ToString());
                objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranRoster_Update", objParm);
            }

            return ds;
        }
        #endregion
        #endregion
        #region Schedule Authorize
        /// <summary>
        /// To authorize schedule
        /// </summary>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="monthValue">The int month val.</param>
        /// <param name="yearValue">The int year val.</param>
        /// <param name="payPeriodType">Type of the STR pay period.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleAuthorize(int locationAutoId, int monthValue, int yearValue, string payPeriodType, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Month, monthValue);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Year, yearValue);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PayPeriodType, payPeriodType);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Schedule_Authorize", objParm);
            return ds;
        }
        /// <summary>
        /// To Get authorize infomation of shcedule
        /// </summary>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="monthValue">The int month val.</param>
        /// <param name="yearValue">The int year val.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleAuthorizeInformationGet(int locationAutoId, int monthValue, int yearValue)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Month, monthValue);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Year, yearValue);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_ScheduleAuthorizeInfo_Get", objParm);
            return ds;
        }
        #endregion
        #region Convert Schedule to Actual
        /// <summary>
        /// To convert schedule into actual rota
        /// </summary>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="fromDate">The dt from date.</param>
        /// <param name="toDate">The dt to date.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConvertSchedule2Actual(int locationAutoId, string clientCode, string asmtCode, DateTime fromDate, DateTime toDate, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Convert_Schedule2Actual", objParm);
            return ds;
        }
        /// <summary>
        /// To Convert schedule into actual rota
        /// </summary>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="fromDate">The dt from date.</param>
        /// <param name="toDate">The dt to date.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConvertEmployeeWiseSchedule2Actual(int locationAutoId, string clientCode, string asmtCode, DateTime fromDate, DateTime toDate, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_ConvertEmpWise_Schedule2Actual", objParm);
            return ds;
        }

        #endregion
        #region Auto Schedule
        /// <summary>
        /// For auto scheduling
        /// </summary>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="fromDate">The dt from date.</param>
        /// <param name="toDate">The dt to date.</param>
        /// <param name="nextFromDate">The dt next from date.</param>
        /// <param name="nextToDate">The dt next to date.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AutoSchedule(int locationAutoId, string clientCode, string asmtCode, DateTime fromDate, DateTime toDate, DateTime nextFromDate, DateTime nextToDate, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.NextFromDate, DL.Common.DateFormat(nextFromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.NextToDate, DL.Common.DateFormat(nextToDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpTrans_AutoSchedule", objParm);
            return ds;
        }

        /// <summary>
        /// For auto scheduling (employee wise scheduling)
        /// </summary>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="fromDate">The dt from date.</param>
        /// <param name="toDate">The dt to date.</param>
        /// <param name="nextFromDate">The dt next from date.</param>
        /// <param name="nextToDate">The dt next to date.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <param name="dtStartDate">The dt start date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWiseAutoSchedule(int locationAutoId, string clientCode, string asmtCode, DateTime fromDate, DateTime toDate, DateTime nextFromDate, DateTime nextToDate, string modifiedBy, DateTime dtStartDate)
        {

            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.NextFromDate, DL.Common.DateFormat(nextFromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.NextToDate, DL.Common.DateFormat(nextToDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[8] = new SqlParameter(DL.Properties.Resources.MonthStartDate, DL.Common.DateFormat(dtStartDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpTrans_ScheduleEmpWise_AutoSchedule", objParm);
            return ds;
        }

        #endregion

        #region Function Related to Copy schedule
        /// <summary>
        /// To copy schedule from one date to next date or one week to next week
        /// </summary>
        /// <param name="scheduleRosterAutoId">The STR SCH roster auto ID.</param>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="copyToDate">The STR copy to date.</param>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataTable.</returns>
        public DataTable ScheduleRosterEmployeeWiseCopy(string scheduleRosterAutoId, string locationAutoId, string copyToDate, string asmtCode, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SchRosterAutoId, scheduleRosterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CopyToDate, copyToDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataTable dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpTran_ScheduleRosterEmpWise_CopySchedule", objParam);
            return dt;
        }
        #endregion

        #region Function Related to Schedule Lock / Unlock (convert 2 actual & revert ). Added on 22 aug 2010
        /// <summary>
        /// To get Lock/unLock information of schedule
        /// </summary>
        /// <param name="locationAutoId">The int location auto id.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="amtCodes">The STR amt codes.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="post">.</param>
        /// <param name="lockUnlock">The lock unlock.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleLockUnlockGet(int locationAutoId, string clientCode, string amtCodes, string fromDate, string toDate, string post, string lockUnlock)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCodeList, amtCodes);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParm[6] = new SqlParameter(DL.Properties.Resources.LockUnlock, lockUnlock);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_ScheduleLockUnLock_Get", objParm);
            return ds;
        }


        /// <summary>
        /// To Lock schedule
        /// </summary>
        /// <param name="autoID">The automatic identifier.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleLock(string autoID, string fromDate, string toDate, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AutoId, autoID);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_ScheduleLockUnLock_Lock", objParm);
            return ds;
        }

        /// <summary>
        /// To Unlock schedule
        /// </summary>
        /// <param name="autoID">The automatic identifier.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleUnlock(string autoID, string fromDate, string toDate, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AutoId, autoID);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_ScheduleLockUnLock_UnLock", objParm);
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
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCodeList, asmtCodes);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[7] = new SqlParameter(DL.Properties.Resources.LockUnlock, lockUnlock);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_ScheduleLockUnLock_LockForAll", objParm);
            return ds;
        }
        /// <summary>
        /// To UnLock All Employees
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
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCodeList, asmtCodes);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[7] = new SqlParameter(DL.Properties.Resources.LockUnlock, lockUnlock);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_ScheduleLockUnLock_UnLockForAll", objParm);
            return ds;
        }


        #endregion

        #endregion
        #region Function Related To Rota
        #region Rota Authorize

        /// <summary>
        /// To Get Rota authorization detail
        /// </summary>
        /// <param name="locationAutoId">The STR location auto ID.</param>
        /// <param name="dutyDate">The STR date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaAuthorizationDetailGet(string locationAutoId, string dutyDate)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, dutyDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_GetAuthorizationDetail", objParm);
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
        /// <returns>DataSet.</returns>
        public DataSet RotaAuthorizationStatusGet(string divisionCode, string branchCode, int month, int year, string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HrLocationCode, divisionCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, branchCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Month, month);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Year, year);
            objParm[4] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_GetAuthorizationStatus", objParm);
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

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_Authorize", objParm);
            return ds;
        }

        /// <summary>
        /// rota un authorize.
        /// </summary>
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <param name="monthValue">The int month val.</param>
        /// <param name="yearValue">The int year val.</param>
        /// <param name="payPeriodType">Type of the STR pay period.</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaUNAuthorize(int locationAutoId, int monthValue, int yearValue, string payPeriodType, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Month, monthValue);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Year, yearValue);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PayPeriodType, payPeriodType);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_UnAuthorize", objParm);
            return ds;
        }

        #endregion
        #region Get Asmt Rota
        /// <summary>
        /// Get Site post detail of a assignment with rota
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="pageReference">The page reference.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="status">The status.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtRotaGet(int locationAutoId, string asmtCode, string dutyDate, int pageReference, int pageSize, int status, string employeeNumber)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.PageRef, pageReference);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PageSize, pageSize);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtPrefilledRota_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_DailyRota_Get_Barbados", objParm);
            return ds;
        }

        #endregion

        #region Get Monthly Rota
        /// <summary>
        /// Get Monthly Rota detail of a Employee on a single asmt
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="fromDutyDate">From duty date.</param>
        /// <param name="toDutyDate">To duty date.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>Data set with rosterAutoId,Shift,Times,dutyDates,dutytypes</returns>
        public DataSet EmployeeMonthlyRotaGet(int locationAutoId, string asmtCode, int pdLineNo, string fromDutyDate, string toDutyDate, string employeeNumber, string shiftCode)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDutyDate, DL.Common.DateFormat(fromDutyDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDutyDate, DL.Common.DateFormat(toDutyDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_EmpPrefilledMonthlyRota_Get", objParm);
            return ds;
        }
        #endregion

        #region Get Rota of an Employee
        /// <summary>
        /// Employees the rota get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRotaGet(string employeeNumber, string dutyDate)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "DailyRotaofAnEmployee_Get_Barbados", objParm);
            return ds;
        }
        /// <summary>
        /// Get data set with detail of Employee Rota/Schedule for greece.
        /// </summary>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="fromDate">The STR from date.</param>
        /// <param name="toDate">The STR to date.</param>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRotaGet(string employeeNumber, string fromDate, string toDate, string companyCode, string locationCode)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LocationID, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "DailyRotaofAnEmployee_Get_Greece", objParm);
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
        /// <param name="locationId">The location identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientRotaGet(string clientCode, string asmtCode, string fromDate, string toDate, string companyCode, string locationId)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.LocationID, locationId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "DailyRotaofAnClient_Get_Greece", objParm);
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
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Option, option);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_DutyHoursOfEmployee_Get", objParm);
            return ds;
        }



        #endregion

        #region Employee Time Status Update

        /// <summary>
        /// Times the status update.
        /// </summary>
        /// <param name="rosterAutoId">The roster automatic identifier.</param>
        /// <param name="confirmedBy">The confirmed by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TimeStatusUpdate(string rosterAutoId, string confirmedBy)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, long.Parse(rosterAutoId));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConfirmedBy, int.Parse(confirmedBy));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_ConfirmDuty_Update", objParm);
            return ds;
        }
        #endregion

        #region Insert Rota
        /// <summary>
        /// To Insert Rota
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto ID.</param>
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

            SqlParameter[] objParm = new SqlParameter[15];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParm[8] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[9] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[10] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMinutes);
            objParm[11] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[12] = new SqlParameter(DL.Properties.Resources.TimeStatus, timeStatus);
            objParm[13] = new SqlParameter(DL.Properties.Resources.BreakHours, breakHours);
            objParm[14] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_Insert", objParm);
            return ds;
        }
        #endregion
        #region Overwrite Duplicate Rota
        /// <summary>
        /// rota_ over write duplicate record ajax.
        /// </summary>
        /// <param name="asmtCode">The STR asmt code.</param>
        /// <param name="locationAutoId">The int location auto ID.</param>
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
        /// <param name="rosterAutoId">The int roster auto ID.</param>
        /// <param name="timeStatus">The time status.</param>
        /// <param name="breakHours">The STR break hours.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverwriteDuplicateRota(string asmtCode, int locationAutoId, int pdLineNo, string dutyDate, string employeeNumber, string roleCode, string designationCode, string shiftCode, string timeFrom, string timeTo, int dutyMinutes, string dutyTypeCode, string modifiedBy, int duplicateRosterAutoId1, int duplicateRosterAutoId2, int duplicateRosterAutoId3, int rosterAutoId, int timeStatus, string breakHours)
        {

            SqlParameter[] objParm = new SqlParameter[19];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            //objParm[8] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            //objParm[9] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[8] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[9] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[10] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMinutes);
            objParm[11] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[13] = new SqlParameter(DL.Properties.Resources.DuplicateRosterAutoID1, duplicateRosterAutoId1);
            objParm[14] = new SqlParameter(DL.Properties.Resources.DuplicateRosterAutoID2, duplicateRosterAutoId2);
            objParm[15] = new SqlParameter(DL.Properties.Resources.DuplicateRosterAutoID3, duplicateRosterAutoId3);
            objParm[16] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[17] = new SqlParameter(DL.Properties.Resources.TimeStatus, timeStatus);
            objParm[18] = new SqlParameter(DL.Properties.Resources.BreakHours, breakHours);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_OverWriteDuplicateRecord", objParm);
            return ds;

        }
        #endregion
        #region Update Rota
        /// <summary>
        /// rota_ update.
        /// </summary>
        /// <param name="rosterAutoId">The int roster auto ID.</param>
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

            SqlParameter[] objParm = new SqlParameter[13];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[6] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[7] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMinutes);
            objParm[8] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParm[9] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParm[10] = new SqlParameter(DL.Properties.Resources.TimeStatus, timeStatus);
            objParm[11] = new SqlParameter(DL.Properties.Resources.BreakHours, breakHours);
            objParm[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_Update", objParm);
            return ds;
        }
        #endregion
        #region Delete Rota
        /// <summary>
        /// rota Delete
        /// </summary>
        /// <param name="rosterAutoId">The int roster auto ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaDelete(int rosterAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_Delete", objParm);
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
        /// <param name="suitableForRehire">if set to <c>true</c> [DDL suitable4 re hire].</param>
        /// <param name="modifiedBy">The STR modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaBulkDeletion(string employeeNumber, string reason, string terminationReason, DateTime resignationDate, string remarks, bool suitableForRehire, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[7];

            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Reason, reason);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TerminationReason, terminationReason);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ResignationDate, DL.Common.DateFormat(resignationDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[5] = new SqlParameter(DL.Properties.Resources.SuitableForReHire, suitableForRehire);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_BulkDelete", objParam);
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
        /// <param name="locationAutoId">The int location auto ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet DailyRotaCopy(string tableName, string copyDate, string fromDate, string toDate, string asmtCode, int locationAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.TableName, tableName);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CopyDutyDate, DL.Common.DateFormat(copyDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.CopyFromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.CopyToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_DailyRota_Copy", objParm);
            return ds;
        }
        #endregion

        #region Function Related To Planning Efficiency Tool
        /// <summary>
        /// To get two months hours comparision
        /// </summary>
        /// <param name="option">The option.</param>
        /// <param name="monthName">The monthname.</param>
        /// <returns>DataSet.</returns>
        public DataSet HourComparisonGet(string option, string monthName)
        {

            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.type, option);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Month, monthName);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "RptKpi_GetHours_Variation", objParam);
            return ds;
        }
        #endregion

        #region Over Write Copy Rota
        /// <summary>
        /// Overwrite in case of copy rota
        /// </summary>
        /// <param name="rosterAutoId">The int roster auto ID.</param>
        /// <param name="rosterAutoId1">The int roster auto I d1.</param>
        /// <returns>DataSet.</returns>
        public DataSet CopyRotaOverwrite(int rosterAutoId, int rosterAutoId1)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RosterAutoID1, rosterAutoId1);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_CopyRota_OverWrite", objParm);
            return ds;
        }
        #endregion
        #endregion
        #region Get Employee Weekly OFF
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranEmployeeWeeklyOff_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.WeekOffType, weekOffType);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrnWeekOff_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_SchEmpWiseWeeklyOff_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Employees the weekly off get.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeWeeklyOffGet(string asmtCode, string dutyDate, string locationAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(dutyDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrnWeekOff_GetEmployeeOfAsmt", objParm);
            return ds;
        }

        /// <summary>
        /// Employees the weekly off save.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="tableWeeklyOff">The table weekly off.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="weekOffType">Type of the week off.</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.ArgumentNullException">tableWeeklyOff</exception>
        public DataTable EmployeeWeeklyOffSave(string locationAutoId, DataTable tableWeeklyOff, string modifiedBy, string weekOffType)
        {
            if (tableWeeklyOff == null || tableWeeklyOff.Rows == null)
            {
                throw new ArgumentNullException("tableWeeklyOff");
            }
            DataSet ds = new DataSet();
            DataTable dtWeekOff = new DataTable();
            ds.Locale = CultureInfo.InvariantCulture;
            dtWeekOff.Locale = CultureInfo.InvariantCulture;


            //DataColumn col1 = new DataColumn(DL.Properties.Resources.fldMessageId, typeof(System.String));
            DataColumn col2 = new DataColumn(DL.Properties.Resources.fldEmployeeNumber, typeof(System.String));
            DataColumn col3 = new DataColumn(DL.Properties.Resources.fldDutyDate, typeof(System.DateTime));
            DataColumn col4 = new DataColumn(DL.Properties.Resources.fldMessage, typeof(System.String));
            DataColumn col5 = new DataColumn(DL.Properties.Resources.fldMessageId, typeof(System.String));
            DataColumn col6 = new DataColumn(DL.Properties.Resources.fldLeaveCode, typeof(System.String));
            DataColumn col7 = new DataColumn(DL.Properties.Resources.fldLeaveDesc, typeof(System.String));
            //dtWeekOff.Columns.Add(col1);
            dtWeekOff.Columns.Add(col2);
            dtWeekOff.Columns.Add(col3);
            dtWeekOff.Columns.Add(col4);
            dtWeekOff.Columns.Add(col5);
            dtWeekOff.Columns.Add(col6);
            dtWeekOff.Columns.Add(col7);
            // DataRow dr = new DataRow();
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                for (int i = 0; i < tableWeeklyOff.Rows.Count; i++)
                {
                    // ds = new DataSet();
                    SqlParameter[] objParm = new SqlParameter[6];
                    objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
                    objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, tableWeeklyOff.Rows[i][DL.Properties.Resources.fldEmployeeNumber].ToString());
                    objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(tableWeeklyOff.Rows[i][DL.Properties.Resources.fldDutyDate].ToString()));
                    objParm[3] = new SqlParameter(DL.Properties.Resources.IsWeekOff, bool.Parse(tableWeeklyOff.Rows[i]["IsWeekOff"].ToString()));
                    objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                    objParm[5] = new SqlParameter(DL.Properties.Resources.WeekOffType, weekOffType);

                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrnWeekOff_Save", objParm);
                    if (ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString() == "97")
                    {
                        DataRow dr = dtWeekOff.NewRow();
                        dr[DL.Properties.Resources.fldEmployeeNumber] = tableWeeklyOff.Rows[i][DL.Properties.Resources.fldEmployeeNumber].ToString();
                        dr[DL.Properties.Resources.fldDutyDate] = DateTime.Parse(tableWeeklyOff.Rows[i][DL.Properties.Resources.fldDutyDate].ToString()).ToString("dd-MMM-yyyy");
                        dr[DL.Properties.Resources.fldMessage] = "";
                        dr[DL.Properties.Resources.fldMessageId] = ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString();
                        dr[DL.Properties.Resources.fldLeaveCode] = ds.Tables[0].Rows[0][DL.Properties.Resources.fldLeaveCode].ToString();
                        dr[DL.Properties.Resources.fldLeaveDesc] = ds.Tables[0].Rows[0][DL.Properties.Resources.fldLeaveDesc].ToString();
                        dtWeekOff.Rows.Add(dr);
                    }
                    else if ((ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString() == "57") || (ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString() == "62"))
                    {
                        DataRow dr = dtWeekOff.NewRow();
                        dr[DL.Properties.Resources.fldEmployeeNumber] = tableWeeklyOff.Rows[i][DL.Properties.Resources.fldEmployeeNumber].ToString();
                        dr[DL.Properties.Resources.fldDutyDate] = DateTime.Parse(tableWeeklyOff.Rows[i][DL.Properties.Resources.fldDutyDate].ToString()).ToString("dd-MMM-yyyy");
                        dr[DL.Properties.Resources.fldMessage] = "";
                        dr[DL.Properties.Resources.fldMessageId] = ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString();
                        dr[DL.Properties.Resources.fldLeaveCode] = "";
                        dr[DL.Properties.Resources.fldLeaveDesc] = "";
                        dtWeekOff.Rows.Add(dr);
                    }
                }
                tx.Complete();
            }
            return dtWeekOff;
        }
        /// <summary>
        /// Employees the wise weekly off save.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="tableWeeklyOff">The table weekly off.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="defaultSite">if set to <c>true</c> [default site].</param>
        /// <param name="soRank">The so rank.</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.ArgumentNullException">tableWeeklyOff</exception>
        public DataTable EmployeeWiseWeeklyOffSave(string locationAutoId, DataTable tableWeeklyOff, string modifiedBy, string asmtCode, string shiftPatternCode, int patternPosition, bool defaultSite, string soRank)
        {
            if (tableWeeklyOff == null || tableWeeklyOff.Rows == null)
            {
                throw new ArgumentNullException("tableWeeklyOff");
            }

            DataSet ds = new DataSet();
            DataTable dtWeekOff = new DataTable();
            ds.Locale = CultureInfo.InvariantCulture;
            dtWeekOff.Locale = CultureInfo.InvariantCulture;

            //DataColumn col1 = new DataColumn(DL.Properties.Resources.fldMessageId, typeof(System.String));
            DataColumn col2 = new DataColumn(DL.Properties.Resources.fldEmployeeNumber, typeof(System.String));
            DataColumn col3 = new DataColumn(DL.Properties.Resources.fldDutyDate, typeof(System.DateTime));
            DataColumn col4 = new DataColumn(DL.Properties.Resources.fldMessage, typeof(System.String));
            DataColumn col5 = new DataColumn(DL.Properties.Resources.fldMessageId, typeof(System.String));
            DataColumn col6 = new DataColumn(DL.Properties.Resources.fldLeaveCode, typeof(System.String));
            DataColumn col7 = new DataColumn(DL.Properties.Resources.fldLeaveDesc, typeof(System.String));
            //dtWeekOff.Columns.Add(col1);
            dtWeekOff.Columns.Add(col2);
            dtWeekOff.Columns.Add(col3);
            dtWeekOff.Columns.Add(col4);
            dtWeekOff.Columns.Add(col5);
            dtWeekOff.Columns.Add(col6);
            dtWeekOff.Columns.Add(col7);
            // DataRow dr = new DataRow();
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                for (int i = 0; i < tableWeeklyOff.Rows.Count; i++)
                {
                    // ds = new DataSet();
                    SqlParameter[] objParm = new SqlParameter[10];
                    objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
                    objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, tableWeeklyOff.Rows[i][DL.Properties.Resources.fldEmployeeNumber].ToString());
                    objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(tableWeeklyOff.Rows[i][DL.Properties.Resources.fldDutyDate].ToString()));
                    objParm[3] = new SqlParameter(DL.Properties.Resources.IsWeekOff, bool.Parse(tableWeeklyOff.Rows[i]["IsWeekOff"].ToString()));
                    objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
                    objParm[5] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
                    objParm[6] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
                    objParm[7] = new SqlParameter(DL.Properties.Resources.DefaultSite, defaultSite);
                    objParm[8] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
                    objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_SchEmpWiseWeeklyOff_Save", objParm);
                    if (ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString() == "102" || ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString() == "66")
                    {
                        DataRow dr = dtWeekOff.NewRow();
                        dr[DL.Properties.Resources.fldEmployeeNumber] = tableWeeklyOff.Rows[i][DL.Properties.Resources.fldEmployeeNumber].ToString();
                        dr[DL.Properties.Resources.fldDutyDate] = DateTime.Parse(tableWeeklyOff.Rows[i][DL.Properties.Resources.fldDutyDate].ToString()).ToString("dd-MMM-yyyy");
                        dr[DL.Properties.Resources.fldMessage] = "";
                        dr[DL.Properties.Resources.fldMessageId] = ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString();
                        dr[DL.Properties.Resources.fldLeaveCode] = ds.Tables[0].Rows[0][DL.Properties.Resources.fldLeaveCode].ToString();
                        dr[DL.Properties.Resources.fldLeaveDesc] = ds.Tables[0].Rows[0][DL.Properties.Resources.fldLeaveDesc].ToString();
                        dtWeekOff.Rows.Add(dr);
                    }


                }
                tx.Complete();
            }
            return dtWeekOff;
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.WeekOffType, weekOffType);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranEmployeeWeeklyOff_DeleteRota", objParm);
            return ds;
        }
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrnVehicleScheduling_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Vehicles the scheduling save.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="tableVehicleOff">The table vehicle off.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">tableVehicleOff</exception>
        public DataSet VehicleSchedulingSave(string locationAutoId, DataTable tableVehicleOff, string modifiedBy)
        {

            if (tableVehicleOff == null || tableVehicleOff.Rows == null)
            {
                throw new ArgumentNullException("tableVehicleOff");
            }
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            for (int i = 0; i < tableVehicleOff.Rows.Count; i++)
            {
                SqlParameter[] objParm = new SqlParameter[5];
                objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
                objParm[1] = new SqlParameter(DL.Properties.Resources.VehicleNumber, tableVehicleOff.Rows[i]["Vehicle Number"].ToString());
                objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(tableVehicleOff.Rows[i][DL.Properties.Resources.fldDutyDate].ToString()));
                objParm[3] = new SqlParameter(DL.Properties.Resources.IsVehicleOff, bool.Parse(tableVehicleOff.Rows[i]["IsVehicleOff"].ToString()));
                objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrnVehicleScheduling_Save", objParm);
            }
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRule_RotaProcess", objParm);
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBusinessRule_Process", objParm);
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_EmployeeAttendance_Process_Morocco", objParm);
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_EmployeeAttendance_Process_Barbados", objParm);
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
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Employees, employees);
            if (processType == "Actual")
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ProcessEmployeeAttendance_Greece", objParm);
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ProcessEmployeeAttendance_Greece_Schedule", objParm);
            }
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

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranScheduleRoster_GeneratePaySum_Australia", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Year, year);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranScheduleRoster_GeneratePaySum_GetDateBasedOnClientPayPeriod", objParm);
            return ds;
        }

        #endregion
        #region Function related to Adjustment Hurs
        #region Insert AdjHrs
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

            SqlParameter[] objParm = new SqlParameter[12];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AdjDate, DL.Common.DateFormat(adjustmentDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AdjHrsFromdate, DL.Common.DateFormat(adjustmentFromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.AdjHrsToDate, DL.Common.DateFormat(adjustmentToDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.HrsAdjusted, adjustmentHours);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AdjHeadCode, adjustmentHead);
            objParm[8] = new SqlParameter(DL.Properties.Resources.Remarks, remark);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[10] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[11] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AdjustedHrs_Insert", objParm);
            return ds;
        }
        #endregion
        #region Get Adjustment Hours
        /// <summary>
        /// Adjustments the hours get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AdjustmentHoursGet(int locationAutoId, string fromDate, string toDate)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AdjustmentHours_Get", objParm);
            return ds;
        }
        #endregion
        #region Delete Adjustment Hours
        /// <summary>
        /// Adjustments the hours delete.
        /// </summary>
        /// <param name="adjustmentHoursTransactionCode">The adjustment hours transaction code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AdjustmentHoursDelete(int adjustmentHoursTransactionCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AdjHeadCode, adjustmentHoursTransactionCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AdjustmentHours_Delete", objParm);
            return ds;
        }
        #endregion
        #endregion
        #region Function Related to Contracted Hours

        #region Get Contracted Hours of assignment
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

            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_ContractedHoursOfAsmt_Get", objParm);


            return ds;
        }
        #endregion

        #endregion
        #region Function Related To Pay Sum
        /// <summary>
        /// Generates the paysum flat.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumFlat(string companyCode, string hrLocationCode, string locationCode, int month, int year, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Month, month);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Year, year);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaySum_Process_ALZ_Flat12_v2", objParm);
            return ds;
        }
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

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranRoster_GetRosterForPaySum", objParm);
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
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysum(string companyCode, string hrLocationCode, string locationCode, string fromDate, string toDate, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaySum_Process", objParm);
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaySum_Process_Egypt", objParm);
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPaySum_Process_Morocco", objParm);
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransBarobdos_GeneratePaySum", objParm);
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
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.OutputType, outputType);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransGreece_GeneratePaySum", objParm);
            return ds;

        }

        /// <summary>
        /// Generates the paysum israel.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="outputType">Type of the output.</param>
        /// <param name="countryCode">Country key</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumIsrael(string businessRuleCode, string fromDate, string toDate, string outputType,string countryCode)
        {
            var objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.OutputType, outputType);
            var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, countryCode.ToUpper() == "UAE" ? "udpTransUAE_GeneratePaySum" : "udpTransISR_GeneratePaySum", objParm);

            return ds;
        }
        /// <summary>
        /// Dl function used for Saudi Paysum -Calls the SP and stores the output of the SP in the dataset.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="outputType">Type of the output.</param>
        /// <returns>DataSet.</returns>
        public DataSet GeneratePaysumSaudi(string businessRuleCode, string fromDate, string toDate, string outputType)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.OutputType, outputType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransISR_GeneratePaySumSaudi", objParm);
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

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.OutputType, outputType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_GeneratePaySum_Australia", objParm);
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

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_GeneratePaySumPNG", objParm);
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);

            //objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            //objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));

            objParm[3] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PayPeriodNumber, int.Parse(PayPeriodNumber));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_GeneratePaySumBSPNG", objParm);
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

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.OutputType, outputType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransGreece_GeneratePaySum_Weekly", objParm);
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransBarobdos_GenerateJobWisePaySum", objParm);
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_Rota_Locking", objParm);
            return ds;
        }

        /// <summary>
        /// Rotas the locking update.
        /// </summary>
        /// <param name="dtLockAutoId">The dt lock automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="isDeleteAccess">if set to <c>true</c> [is delete access].</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dtLockAutoId</exception>
        public DataSet RotaLockingUpdate(System.Collections.Hashtable dtLockAutoId, string fromDate, string toDate, string modifiedBy, bool isDeleteAccess)
        {
            if (dtLockAutoId == null)
            {
                throw new ArgumentNullException("dtLockAutoId");
            }

            string strAutoIdList;
            strAutoIdList = "";

            foreach (DictionaryEntry Item in dtLockAutoId)
            {
                if (!string.IsNullOrEmpty(strAutoIdList))
                {
                    strAutoIdList = strAutoIdList + "," + Item.Value.ToString();
                }
                else
                { strAutoIdList = Item.Value.ToString(); }
            }



            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LockAutoId, strAutoIdList);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.IsDeleteAccess, isDeleteAccess);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_RotaLocking_Update", objParam);
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

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranRoster_GetEmpLastAssignmentt", objParm);
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

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_ShiftsOfSitePost_Get", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Requireds VS schedule Actual hours records from database.
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
        public DataSet RequiredVSScheduleVSActualGet(string locationAutoId, string clientCode, string fromDate, string toDate, string asmtStatusAuthorized, string asmtStatusTerminated, string filterParam, string areaId,string employeeno)
        {

            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtStatusAuthorized, asmtStatusAuthorized);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AsmtStatusTerminated, asmtStatusTerminated);
            objParm[6] = new SqlParameter(DL.Properties.Resources.FilterParam, filterParam);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeno);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTranScheduleRequiredPerson_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.Flag, int.Parse(flag));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updTranRoster_EmployeesDetailsWithDutyHrs_GetAll", objParm);
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
            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.DivisionCode,divisionCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Division, division);
            objParm[4] = new SqlParameter(DL.Properties.Resources.BranchCode, branchCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Branch,branch);
            objParm[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber,EmployeeNumber);
            objParm[7] = new SqlParameter(DL.Properties.Resources.EmployeeNameCondition,EmployeeName);
            objParm[8] = new SqlParameter(DL.Properties.Resources.AreaId, AreaID);
            objParm[9] = new SqlParameter(DL.Properties.Resources.AreaDesc, AreaDesc);
            objParm[10] = new SqlParameter(DL.Properties.Resources.AreaInchargeNumber, AreaINcharge);
            
            DataSet dsAllowance = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpIsraelBarredEmployees", objParm);
            return dsAllowance;
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
        /// <param name="maxDate">The maximum date.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesNotScheduleBetweenDatesGetAll(string companyCode, string locationAutoId, string fromDate, string toDate, string maxDate, string attendanceType, string areaId, string areaIncharge, string isAreaIncharge)
        {

            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DateTime.Parse(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DateTime.Parse(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.MonthEndDate, DateTime.Parse(maxDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[8] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmpNotScheduleBwDates_get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmpNotScheduleBwDates_getRequest", objParm);
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
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RequestNo, RequestNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.RequestLineNo, RequestLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(DutyDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSearchEmployeeSkillandAreaWiseGetAll", objParm);
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

            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DivisionCode, divisionCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.BranchCode, branchCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updSales_Rostering_HourAnalysis_Egypt", objParam);
            return ds;
        }
        #endregion

        #region function related to overtime details

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

            SqlParameter[] objparm = new SqlParameter[4];
            objparm[0] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objparm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objparm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DateTime.Parse(fromDate));
            objparm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DateTime.Parse(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_OverTimeDetails_get", objparm);
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

            SqlParameter[] objparm = new SqlParameter[2];
            objparm[0] = new SqlParameter(DL.Properties.Resources.AutoId, int.Parse(autoId));
            objparm[1] = new SqlParameter(DL.Properties.Resources.Reason, reason);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_OverTimeReason_Update", objparm);
            return ds;

        }

        #endregion

        //Added by Bal Mukund Starts
        #region Get Rota of All Employees
        /// <summary>
        /// Get data set with detail of Employee Rota/Schedule
        /// </summary>
        /// <param name="companyCode">The STR company code.</param>
        /// <param name="locationCode">The STR location code.</param>
        /// <param name="clientCode">The STR client code.</param>
        /// <param name="employeeNumber">The STR employee number.</param>
        /// <param name="dutyDate">The STR duty date.</param>
        /// <param name="timeFrom">The STR time from.</param>
        /// <param name="timeTo">The STR time to.</param>
        /// <param name="confirmDuty">The STR confirm duty.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaOfAllEmployeesGet(string companyCode, string locationCode, string clientCode, string employeeNumber, string dutyDate, string timeFrom, string timeTo, string confirmDuty)
        {

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[6] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ConfirmDuty, confirmDuty);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "DailyRotaForTimeFrame_Get_Barbados", objParm);
            return ds;
        }

        /// <summary>
        /// Shifts the of all employee get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftOfAllEmployeeGet(string locationAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Shift_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_ShiftTime_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            //objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeePostWiseSchRoster_rpt", objParm);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeePostWiseSchRoster_rpt", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            //objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeePostWiseSchRoster_rpt", objParm);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LegalSchRoster_rpt", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            //objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeePostWiseSchRoster_rpt", objParm);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SupervisorSchWeekly_rpt", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            //objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeePostWiseSchRoster_rpt", objParm);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UDP_SCHEDULEVSDEMAND_AVIATION_RPT", objParm);
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

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeePostWiseSchRoster_rpt", objParm);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UnitRegisterBreakupHours", objParm);
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

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeePostWiseSchRoster_rpt", objParm);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UnitRegisterEmployeeHours", objParm);
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

            SqlParameter[] objparm = new SqlParameter[2];
            objparm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objparm[1] = new SqlParameter(DL.Properties.Resources.RecordType, recordType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_EmployeeTagReference_Get", objparm);
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

            SqlParameter[] objparm = new SqlParameter[4];
            objparm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objparm[1] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            objparm[2] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objparm[3] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_EmployeeTagReference_Insert", objparm);
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

            SqlParameter[] objparm = new SqlParameter[4];
            objparm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objparm[1] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            objparm[2] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo));
            objparm[3] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_EmployeeTagReference_Close", objparm);
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

            SqlParameter[] objparm = new SqlParameter[1];
            objparm[0] = new SqlParameter(DL.Properties.Resources.TagId, locationTagId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_LocationTagReference_Get", objparm);
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

            SqlParameter[] objparm = new SqlParameter[7];
            objparm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objparm[1] = new SqlParameter(DL.Properties.Resources.TagType, tagType);
            objparm[2] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            objparm[3] = new SqlParameter(DL.Properties.Resources.TagDesc, tagDesc);
            objparm[4] = new SqlParameter(DL.Properties.Resources.Post, postId);
            objparm[5] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objparm[6] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_LocationTagReference_Insert", objparm);
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

            SqlParameter[] objparm = new SqlParameter[4];
            objparm[0] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            objparm[1] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo));
            objparm[2] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            objparm[3] = new SqlParameter(DL.Properties.Resources.Action, action);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_LocationTagReference_Close", objparm);
            return ds;
        }

        /// <summary>
        /// Posts the get all.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostGetAll(string locationAutoId)
        {

            SqlParameter[] objparm = new SqlParameter[1];
            objparm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LocationTag_PostGetAll", objparm);
            return ds;
        }
        #endregion
        #region function related to Assignment Tag reference (specific for Egypt version)

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
            SqlParameter[] objparm = new SqlParameter[8];
            objparm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objparm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objparm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objparm[3] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            objparm[4] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objparm[5] = new SqlParameter(DL.Properties.Resources.FromTime, DL.Common.DateFormat(effectiveFromTime));
            objparm[6] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            objparm[7] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_AsmtTagReference_Insert", objparm);
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
            SqlParameter[] objparm = new SqlParameter[9];
            objparm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objparm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objparm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objparm[3] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            objparm[4] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo));
            objparm[5] = new SqlParameter(DL.Properties.Resources.ToTime, DL.Common.DateFormat(effectiveToTime));
            objparm[6] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objparm[7] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            objparm[8] = new SqlParameter(DL.Properties.Resources.Action, action);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_AsmtTagReference_Close", objparm);
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


            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ServiceManager, serviceManager);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllServiceManager", objParm);
            return ds;

        }

        /// <summary>
        /// Clients the list get.
        /// </summary>
        /// <param name="serviceManager">The service manager.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientListGet(string serviceManager)
        {


            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ServiceManager, serviceManager);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllClientListByServiceManager", objParm);
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

            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ServiceManager, serviceManager);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllAsmtClientWise", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ServiceManager, serviceManager);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllSitAsmtClientWise", objParm);
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
            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtId, AsmtId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParm[6] = new SqlParameter(DL.Properties.Resources.RequestedToLocationAutoId, requestedToLocationAutoId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.RequestedToAreaId, requestedToAreaId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.StatusFresh, statusFresh);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeRequestInsertHdr", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeRequestDetailsGet", objParm);
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

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRequestNumber_FetchOwnRequest", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowedEmployeeGet", objParm);
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
            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtId, AsmtId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParm[7] = new SqlParameter(DL.Properties.Resources.RequestedToLocationAutoId, requestedToLocationAutoId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.RequestedToAreaId, requestedToAreaId);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeRequestUpdateHdr", objParm);
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
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeRequestDeleteHdr", objParm);
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
            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.NoOfPerson, noOfPerson);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.FromTime, FromTime);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ToTime, ToTime);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeDetailInsert", objParm);
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
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StatusSent, statusSent);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeRequestSend", objParm);
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
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[2] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeRequestPendingGet", objParm);
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
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.RequestLineNo, int.Parse(requestLineNo));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeDetailDelete", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeRequestDetailForApprovalGet", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowedEmployeeClosePartialApprovedRequest", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ApproveRequest", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RejectRequest", objParm);
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
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.RequestLineNo, requestLineNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.RequestSubLineNo, requestSubLineNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowedEmployeeUpdate", objParm);
            return ds;
        }

        /// <summary>
        /// Requesteds the employee no copyto all.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="requestNo">The request no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="sLineNo">The s line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet RequestedEmployeeNoCopytoAll(string locationAutoId, string requestNo, string employeeNumber, string dutyDate, string sLineNo)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.SlineNo, sLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRequestNumber_CopyToAll", objParm);
            return ds;
        }

        /// <summary>
        /// Requesteds the employee delete.
        /// </summary>
        /// <param name="requestNo">The request no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="lineNo">The line no.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet RequestedEmployeeDelete(string requestNo, string locationAutoId, int lineNo, int rowNumber)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LineNo, lineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SlineNo, rowNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRequestNumber_DeleteEmployee", objParm);
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
            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RequestNo, requestNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.RequestLineNo, RequestLineNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.NoOfPerson, noOfPerson);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.FromTime, FromTime);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ToTime, ToTime);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpBorrowEmployeeDetailUpdate", objParm);
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

            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[9] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpListofBorrowedEmployees_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udt_ToMerhavCSVFile", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_YLMDutyDates_Get", objParm);
            return ds;
        }
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
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ConfirmDuty, WithConfirmedDuty);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_YLMRosterSchDuty_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[13];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            //Added  new parameter schRosterAutoID  18-09-2012
            objParm[5] = new SqlParameter(DL.Properties.Resources.ScheduleRosterAutoID, schRosterAutoID);
            //End  
            objParm[6] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[8] = new SqlParameter(DL.Properties.Resources.InTime, DL.Common.DateFormat(inTime));
            objParm[9] = new SqlParameter(DL.Properties.Resources.OutTime, DL.Common.DateFormat(outTime));
            objParm[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[11] = new SqlParameter(DL.Properties.Resources.ConfirmStatus, confirmStatus);
            objParm[12] = new SqlParameter(DL.Properties.Resources.ActualRosterProcessedYLMAutoId, actualRosterProcessedYlmAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_YLMRosterSchDuty_Save", objParm);
            return ds;
        }
        /// <summary>
        /// For YLM Attendance Report  13-07-2012
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

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_YLMRosterSchDuty_GetRPT", objParm);
            return ds;
        }

        // YLM Attendance Raw data Report  18-10-2012

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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            //  objParm[6] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_YLMRawData_GetRPT", objParm);
            return ds;
        }


        /// <summary>
        /// 10-Dec-2012
        /// To Noshow Employee.We are showing the Employee that are schedule on particular date.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="FromDate">Date Range  from Date</param>
        /// <param name="ToDate">Date Range toDate</param>
        /// <returns>DataSet.</returns>
        /// Mention Below are the parameter we are passing

        public DataSet YlmNoShowReportGet(string locationAutoId, string clientCode, string asmtCode, string areaId, string FromDate, string ToDate)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            //  objParm[6] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_YLMRosterNoShow", objParm);
            return ds;
        }

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

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.AttendanceType, RosterOrSchedule);
            objParm[7] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, IsAreaIncharge);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmpNotScheduleBwDates_rpt", objParm);
            return ds;
        }
        /// <summary>
        /// YLM Contact Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet YlmContactDetailsReport(string locationAutoId, string clientCode, string asmtCode, string postCode, string areaId, string areaIncharge)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRptAsmtDetailsReport", objParm);
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

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParm[7] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, IsAreaIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeeWiseHours_rpt", objParm);
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
        public DataSet ScheduleControl(string locationAutoId, string areaIncharge, string areaId, string ClientCode, string AsmtCode, string Flag, string FromDate, string ToDate, string Output)
        {

            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, AsmtCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Flag, Flag);
            objParm[6] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[8] = new SqlParameter(DL.Properties.Resources.OutputFld, Output);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_schedulecontrol_rpt", objParm);
            return ds;
        }

        /// <summary>
        /// Get Week Start and end date
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetStartEndDayWeek(string locationAutoId, string FromDate, string ToDate)
        {

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetStartEndDayWeek_rpt", objParm);
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

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            //  objParm[6] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_YLMRosterVacant", objParm);
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
            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Site, site);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Year, year);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Month, month);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[7] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[8] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(key, "udpGetEmployeeScheduleFinished", objParm);
            return ds;
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
            SqlParameter[] objParam = new SqlParameter[17];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Site, site);
            objParam[5] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Sequence, sequence);
            objParam[7] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParam[8] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[10] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[11] = new SqlParameter(DL.Properties.Resources.SoLineNo, solineNo);
            objParam[12] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[13] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objParam[14] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParam[15] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[16] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);

            DataSet ds = SqlHelper.ExecuteDataset(key, CommandType.StoredProcedure, "udpAutoSchedule", objParam);
            return ds;
        }
        #endregion

        #region Function Related Popup Menu Item
        /// <summary>
        /// To Menu Item Popup
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet MenuItemPopupGet(String locationAutoId, String attendanceType)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMenuItemPopupGet", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_RotaEmpWise_GetAllBasedOnRosterAutoID", objParm);
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
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, empNumber);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, DateTime.Parse(dutyDate));
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpNewShiftCode_get", objParm);
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
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CurrentRosterAutoID, currentRosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SwapRosterAutoId, swapRosterAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[8] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.SwappedBy, swappedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSwapDuty_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// Gets the client for swap duty.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetClientForSwapDuty(string locationAutoId, string areaId, string clientCode, string areaIncharge, string isAreaIncharge, string fromDate, string toDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_ScheduleEmpWise_GetAllClients", objParm);
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
            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Month, month);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Year, year);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ClientCode, clientcode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtcode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.WeekStartDay, weekstartday);
            objParm[7] = new SqlParameter(DL.Properties.Resources.WeekEndDay, weekendday);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ClientCountOnStatus, clientcountonstatus);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_ScheduleStatusAsmtAndWeekWise", objParm);
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
            SqlParameter[] objParm = new SqlParameter[13];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate, false));
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom, true));
            objParm[5] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo, true));
            objParm[6] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMin);
            objParm[7] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[10] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[11] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[12] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRosterAllowanceInsert", objParm);
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
            SqlParameter[] objParm = new SqlParameter[14];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAllowanceAutoID, rosterAllowanceAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate, false));
            objParm[5] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom, true));
            objParm[6] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo, true));
            objParm[7] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMin);
            objParm[8] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[10] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[11] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[12] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[13] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRosterAllowanceUpdate", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAllowanceAutoID, rosterAllowanceAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRosterAllowanceDelete", objParm);
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
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRosterAllowanceGet", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetElementDetailsByAllowanceAutoID", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Allowance
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceGet(String locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet dsAllowance = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAllowanceGet", objParm);
            return dsAllowance;
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
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoID);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaId, AreaID);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AreaInchargeNumber, AreaINcharge);
            objParm[6] = new SqlParameter(DL.Properties.Resources.WeeklyRest, WeeklyRest);

        

            DataSet dsAllowance = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_WeeklyRest_rpt", objParm);
            return dsAllowance;
        }
        #endregion

        #region Function Related to Apply New Tab Allowance Details 13-Jan-2014
        /// <summary>
        /// To Get Allowance Details
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
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[6] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate, false));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TrnRosterAllowanceGet", objParm);
            return ds;
        }

        /// <summary>
        /// To Get Allowance
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceDescriptionGet(String locationAutoId)
        {
            var objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TrnAllowanceDescriptionGet", objParm);
        }

        /// <summary>
        /// To Get Allowance Details by Element
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ElementDetailsByAllowanceAutoIdGet(String allowanceAutoId)
        {
            var objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TrnGetElementDetailsByAllowanceAutoID", objParm);
        }

        /// <summary>
        /// To Get Allowance Unit Details by Element
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet UnitDetailsByAllowanceAutoIdGet(String allowanceAutoId)
        {
            var objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TrnGetUnitDetailsByAllowanceAutoID", objParm);
        }

        /// <summary>
        /// To Delete Allowance Details
        /// </summary>
        /// <param name="trnAllowanceAutoID">The TRN allowance automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterAllowanceDetailsDelete(String trnAllowanceAutoID, String locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.TrnAllowanceAutoID, trnAllowanceAutoID);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TrnRosterAllowanceDelete", objParm);
            return ds;
        }

        /// <summary>
        /// To Insert Allowance Details
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
            SqlParameter[] objParm = new SqlParameter[18];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate, false));
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom, true));
            objParm[5] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo, true));
            objParm[6] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMin);
            objParm[7] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[10] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[11] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[12] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[13] = new SqlParameter(DL.Properties.Resources.Measurement, measurement);
            objParm[14] = new SqlParameter(DL.Properties.Resources.Unit, unit);
            objParm[15] = new SqlParameter(DL.Properties.Resources.AmountPaid, amountPaid);
            objParm[16] = new SqlParameter(DL.Properties.Resources.IsBillable, isBillable);
            objParm[17] = new SqlParameter(DL.Properties.Resources.Comment, comment);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TrnRosterAllowanceInsert", objParm);
            return ds;
        }

        /// <summary>
        /// To Update Allownace Details
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
            SqlParameter[] objParm = new SqlParameter[19];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAllowanceAutoID, rosterAllowanceAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate, false));
            objParm[5] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom, true));
            objParm[6] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo, true));
            objParm[7] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMin);
            objParm[8] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[10] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[11] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[12] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParm[13] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[14] = new SqlParameter(DL.Properties.Resources.Measurement, measurement);
            objParm[15] = new SqlParameter(DL.Properties.Resources.Unit, unit);
            objParm[16] = new SqlParameter(DL.Properties.Resources.AmountPaid, amountPaid);
            objParm[17] = new SqlParameter(DL.Properties.Resources.IsBillable, isBillable);
            objParm[18] = new SqlParameter(DL.Properties.Resources.Comment, comment);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TrnRosterAllowanceUpdate", objParm);
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
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Post, post);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonForComboGet", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonTransactionGet", objParm);
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
            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ReasonAutoID, reasonAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.RosterAutoId, rosterAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[5] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[6] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMin);
            objParm[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonTranInsert", objParm);
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
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.OTReasonTranAutoId, otReasonTranAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));
            objParm[4] = new SqlParameter(DL.Properties.Resources.DutyMin, dutyMin);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonTranUpdate", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.OTReasonTranAutoId, otReasonTranAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonTranDelete", objParm);
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
            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.OTReasonTranAutoId, otReasonTranAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.TimeFrom, DL.Common.DateFormat(timeFrom));
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeTo, DL.Common.DateFormat(timeTo));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonEmpTimeOverlapCheck", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Is OT From System Parameter Table
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet IsOtFromSystemParam(String locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpIsOtFromSystemParam", objParm);
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
            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, AsmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaId, AreaId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.ScheduleActual, ScheduleActual);
            objParm[8] = new SqlParameter(DL.Properties.Resources.AreaIncharge, AreaIncharge);
            objParm[9] = new SqlParameter(DL.Properties.Resources.Option, Option);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "rpt_SchActualAsmtWise", objParm);
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
            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.SOType, soType);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "ProcInvoicePngRpt", objParm);
            return ds;
        }
        #endregion

        /// <summary>
        /// Gets the unit register.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet GetUnitRegister()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_ViewUnitRegisterWeekly_");
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

            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter(DL.Properties.Resources.HrLocationCode, HrLocationCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationCode, locationcode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.OptionParam, optionparam);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.UserId, UserID);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_rosterrpt_timesheet", objParm);
            return ds;
        }

        #region Management Report

        /// <summary>
        /// To Process Guarding Management report
        /// </summary>
        /// <param name="Base_CompanyCode">The base_ company code.</param>
        /// <param name="Base_HrLocationCode">The base_ hr location code.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <returns>DataTable.</returns>
        public DataTable GuardingManagementProcessGet(string Base_CompanyCode, string Base_HrLocationCode, string FromDate, string ToDate, string ModifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[5];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, Base_CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, Base_HrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, FromDate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, ToDate);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            using (DataTable dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udprptGRDManagementReport_Process", objParm))
            {
                return dt;
            }

        }

        /// <summary>
        /// Function Gets the Processed Dates
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <param name="HrLocationCode">The hr location code.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetGuardingManagementProcessDate(string CompanyCode, string HrLocationCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, HrLocationCode);


            using (DataTable dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpGetProcessDate", objParm))
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
            var objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AutoId, autoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Roster_RosterDetailBasedOnAutoID", objParm);
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
            var objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AutoId, autoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Reason, reason);
            objParm[3] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Status, Status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Roster_CheckEmployeeValidityAndInsertForEntryInDutyReplaced", objParm);
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

            var objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Roster_DeleteScheduleAndActual", objParm);
            return ds;
        }

        #region Added by  on 24-Apr-2014 For POP TAG Reference In Export
        /// <summary>
        /// This function fetches the data related to Location Tag Reference
        /// </summary>
        /// <param name="strLocationTagID">The string location tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlLocationTagRefGet(string strLocationTagID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objparm = new SqlParameter[1];
            objparm[0] = new SqlParameter(DL.Properties.Resources.TagId, strLocationTagID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_LocationTagReference_Get", objparm);
            return ds;
        }

        /// <summary>
        /// Funtion to get detail of employee and tag ref mapping
        /// </summary>
        /// <param name="Base_LocationAutoID">The base_ location automatic identifier.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlAsmtTagRefGet(string Base_LocationAutoID, string strAsmtCode)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objparm = new SqlParameter[2];
            objparm[0] = new SqlParameter("@LocationAutoid", Base_LocationAutoID);
            objparm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, strAsmtCode);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_AsmtTagReference_Get", objparm);
            return ds;
        }

        /// <summary>
        /// Dls the employee tag reference get.
        /// </summary>
        /// <param name="strEmployeeNumber">The string employee number.</param>
        /// <param name="strRecordType">Type of the string record.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlEmployeeTagRefGet(string strEmployeeNumber, string strRecordType)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objparm = new SqlParameter[2];
            objparm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, strEmployeeNumber);
            objparm[1] = new SqlParameter(DL.Properties.Resources.RecordType, strRecordType);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_EmployeeTagReference_Get", objparm);
            return ds;
        }
        #endregion
    }
}
