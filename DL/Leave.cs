// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Leave.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class Leave.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Leave
    {
        #region Function Employee Leave
        /// <summary>
        /// Employeeses the leave get.
        /// </summary>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeesLeaveGet(string hrLocationCode, int locationAutoId, string employeeNumber, string fromDate, string toDate)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_EmployeesLeave_Get", objParm);
            return ds;
        }
        #endregion

        #region Functions Related to Leave Calendar
        /// <summary>
        /// Leaves the calendar get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveCalendarGet(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstHR_LeaveCalendar_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Leaves the calendar get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveCalendarGet(string companyCode, string leaveCalendarCode)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstHRLeaveCalendar_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Leaves the calendar insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="leaveCalendarDesc">The leave calendar desc.</param>
        /// <param name="effectiveFromDate">The effective from date.</param>
        /// <param name="effectiveToDate">The effective to date.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveCalendarInsert(string companyCode, string leaveCalendarCode, string leaveCalendarDesc, string effectiveFromDate, string effectiveToDate, string status, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalDesc, leaveCalendarDesc);
            objParm[3] = new SqlParameter(DL.Properties.Resources.EffectiveFromDate, DL.Common.DateFormat(effectiveFromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.EffectiveToDate, DL.Common.DateFormat(effectiveToDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstHR_LeaveCalendar_Insert", objParm);
            return ds;
        }
        #endregion

        #region Functions Related to Leave Calendar Category Mapping
        /// <summary>
        /// Leaves the calendar category insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveCalendarCategoryInsert(string companyCode, string leaveCalendarCode, string categoryCode, string status, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CategoryCode, categoryCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstHR_LeaveCalendarCategory_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// Leaves the calendar category get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveCalendarCategoryGet(string companyCode, string leaveCalendarCode)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstHR_LeaveCalendarCategory_Get", objParm);
            return ds;

        }
        #endregion

        #region Functions Related to Leave Type
        /// <summary>
        /// Leaves the type get.
        /// </summary>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveTypeGet(string leaveCode, string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHR_LeaveType_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Leaves the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveTypeGet(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HRLeaveType_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Leaves the and sub leave type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveAndSubLeaveTypeGet(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HRLeaveAndSubLeaveType_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Leaves the type insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="leaveDesc">The leave desc.</param>
        /// <param name="leaveUnit">The leave unit.</param>
        /// <param name="leaveUnitInMimutes">The leave unit in mimutes.</param>
        /// <param name="entitlementRule">The entitlement rule.</param>
        /// <param name="entitlementUnit">The entitlement unit.</param>
        /// <param name="carryFlag">The carry flag.</param>
        /// <param name="carryRule">The carry rule.</param>
        /// <param name="carryDays">The carry days.</param>
        /// <param name="postingRule">The posting rule.</param>
        /// <param name="minimumUnit">The minimum unit.</param>
        /// <param name="maximumUnit">The maximum unit.</param>
        /// <param name="encashmentRule">The encashment rule.</param>
        /// <param name="encashmentUnit">The encashment unit.</param>
        /// <param name="affectsService">The affects service.</param>
        /// <param name="encashmentFlag">The encashment flag.</param>
        /// <param name="holidayInclusive">The holiday inclusive.</param>
        /// <param name="medicalCertification">The medical certification.</param>
        /// <param name="withoutEntitlement">The without entitlement.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="postingUnitSource">The posting unit source.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveTypeInsert(string companyCode, string leaveCode, string frequency, string leaveDesc, string leaveUnit, int leaveUnitInMimutes, string entitlementRule, string entitlementUnit, string carryFlag, string carryRule, string carryDays, string postingRule, string minimumUnit, string maximumUnit, string encashmentRule, string encashmentUnit, string affectsService, string encashmentFlag, string holidayInclusive, string medicalCertification, string withoutEntitlement, string isActive, string status, string modifiedBy, int postingUnitSource)
        {

            SqlParameter[] objParm = new SqlParameter[25];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveFreq, frequency);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveDesc, leaveDesc);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LeaveUnit, leaveUnit);
            objParm[5] = new SqlParameter(DL.Properties.Resources.LeaveUnitInMinutes, leaveUnitInMimutes);
            objParm[6] = new SqlParameter(DL.Properties.Resources.LeaveEntitlementRule, entitlementRule);
            objParm[7] = new SqlParameter(DL.Properties.Resources.LeaveEntitledUnit, entitlementUnit);
            objParm[8] = new SqlParameter(DL.Properties.Resources.CarryoverFlag, carryFlag);
            objParm[9] = new SqlParameter(DL.Properties.Resources.CarryoverRule, carryRule);
            objParm[10] = new SqlParameter(DL.Properties.Resources.CarryoverDays, carryDays);
            objParm[11] = new SqlParameter(DL.Properties.Resources.PostingRule, postingRule);
            objParm[12] = new SqlParameter(DL.Properties.Resources.MinimumUnit, minimumUnit);
            objParm[13] = new SqlParameter(DL.Properties.Resources.MaximumUnit, maximumUnit);
            objParm[14] = new SqlParameter(DL.Properties.Resources.EncashmentRule, encashmentRule);
            objParm[15] = new SqlParameter(DL.Properties.Resources.EncashmentUnit, encashmentUnit);
            objParm[16] = new SqlParameter(DL.Properties.Resources.AffectsServiceGrowth, affectsService);
            objParm[17] = new SqlParameter(DL.Properties.Resources.EncashFlag, encashmentFlag);
            objParm[18] = new SqlParameter(DL.Properties.Resources.HolidayInclusiveFlag, holidayInclusive);
            objParm[19] = new SqlParameter(DL.Properties.Resources.MedicalCertificationFlag, medicalCertification);
            objParm[20] = new SqlParameter(DL.Properties.Resources.WithoutEntitlementFlag, withoutEntitlement);
            objParm[21] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            objParm[22] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[23] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[24] = new SqlParameter(DL.Properties.Resources.PostingUnitSource, postingUnitSource);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HR_LeaveType_Insert", objParm);
            return ds;

        }

        /// <summary>
        /// Assiciateds leave update
        /// </summary>
        /// <param name="associatedLeaveCode">The associated leave code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssiciatedLeaveUpdate(string associatedLeaveCode, string leaveCode, string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AssociatedLeaveCode, associatedLeaveCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HRLeaveType_AssiciatedLeave_Update", objParm);
            return ds;
        }
               
        #endregion

        #region Function Related Sub Leave Type added by  on 28-may-2012

        /// <summary>
        /// Sub leave type get.
        /// </summary>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeGet(string leaveCode, string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HRSubLeaveType_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Sub leave type delete.
        /// </summary>
        /// <param name="subLeaveCode">The sub leave code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeDelete(string subLeaveCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SubLeaveCode, subLeaveCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HRSubLeaveType_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// Sub leave type insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="subLeaveCode">The sub leave code.</param>
        /// <param name="subLeaveDesc">The sub leave desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeInsert(string companyCode, string leaveCode, string subLeaveCode, string subLeaveDesc, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SubLeaveCode, subLeaveCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SubLeaveDesc, subLeaveDesc);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HRSubLeaveType_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// Sub leave type update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="subLeaveCode">The sub leave code.</param>
        /// <param name="subLeaveDesc">The sub leave desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeUpdate(string companyCode, string leaveCode, string subLeaveCode, string subLeaveDesc, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SubLeaveCode, subLeaveCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SubLeaveDesc, subLeaveDesc);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HRSubLeaveType_Update", objParm);
            return ds;
        }

        #endregion

        #region Functions Related to Leave Application and Posting
        /// <summary>
        /// Leaves the posting application number get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingApplicationNumberGet(string employeeNumber, string leaveCode, string locationAutoId, string leaveCalendarCode)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCalenderCode, leaveCalendarCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstLeave_ApplicationNo_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Leaves the posting application result get.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingApplicationResultGet(string session)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.SessionID, session);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_HRLeaveApplicationResult_Get", objParm);
            return ds;

        }
        /// <summary>
        /// Leaves the posting application detail get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingApplicationDetailGet(string locationAutoId, string employeeNumber, string leaveCalendarCode, string leaveCode, string applicationNo)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstLeave_ApplicationDetail_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Leaves the posting insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="calendarCode">The calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="exceptionReason">The exception reason.</param>
        /// <param name="notifiedDate">The notified date.</param>
        /// <param name="followUpdate">The follow update.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="startSession">The start session.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="endSession">The end session.</param>
        /// <param name="leaveUnits">The leave units.</param>
        /// <param name="medical">The medical.</param>
        /// <param name="authorizedLeaveUnits">The authorized leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authorizedLeaveStartDate">The authorized leave start date.</param>
        /// <param name="authorizedLeaveStartSession">The authorized leave start session.</param>
        /// <param name="authorizedLeaveEndDate">The authorized leave end date.</param>
        /// <param name="authorizedLeaveEndSession">The authorized leave end session.</param>
        /// <param name="confirmLeaveAccept">The confirm leave accept.</param>
        /// <param name="confirmLeaveUnits">The confirm leave units.</param>
        /// <param name="confirmLeaveStartDate">The confirm leave start date.</param>
        /// <param name="confirmLeaveStartSession">The confirm leave start session.</param>
        /// <param name="confirmLeaveEndDate">The confirm leave end date.</param>
        /// <param name="confirmLeaveEndSession">The confirm leave end session.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="weekOffStatus">if set to <c>true</c> [week off status].</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="defaultSite">if set to <c>true</c> [default site].</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="post">The post.</param>
        /// <param name="leaveXml">The leave XML.</param>
        /// <param name="subLeaveCode">The sub leave code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingInsert(string companyCode, string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authorizedLeaveUnits, string leaveAuthorizationAccept, string authorizedLeaveStartDate, string authorizedLeaveStartSession, string authorizedLeaveEndDate, string authorizedLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy, string sessionId, bool weekOffStatus, string shiftPatternCode, string patternPosition, bool defaultSite, string asmtCode, string rowNumber, string attendanceType, string post, string leaveXml, string subLeaveCode)
        {

            SqlParameter[] objParm = new SqlParameter[41];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, calendarCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ExceptionFlag, exception);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ExceptionReason, exceptionReason);
            objParm[8] = new SqlParameter(DL.Properties.Resources.NotifiedDate, DL.Common.DateFormat(notifiedDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.FollowupDate, DL.Common.DateFormat(followUpdate));
            objParm[10] = new SqlParameter(DL.Properties.Resources.ExpectedReturnDate, DL.Common.DateFormat(returnDate));
            objParm[11] = new SqlParameter(DL.Properties.Resources.StartDates, DL.Common.DateFormat(startDate));
            objParm[12] = new SqlParameter(DL.Properties.Resources.StartANFNSession, startSession);
            objParm[13] = new SqlParameter(DL.Properties.Resources.EndDates, DL.Common.DateFormat(endDate));
            objParm[14] = new SqlParameter(DL.Properties.Resources.EndANFNSession, endSession);
            objParm[15] = new SqlParameter(DL.Properties.Resources.LeaveTakenUnits, leaveUnits);
            objParm[16] = new SqlParameter(DL.Properties.Resources.MedicalCerification, medical);
            objParm[17] = new SqlParameter(DL.Properties.Resources.LeaveAuthUnits, authorizedLeaveUnits);
            objParm[18] = new SqlParameter(DL.Properties.Resources.LeaveAuthorizationAccept, leaveAuthorizationAccept);
            objParm[19] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartDate, DL.Common.DateFormat(authorizedLeaveStartDate, true));
            objParm[20] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartSession, authorizedLeaveStartSession);
            objParm[21] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndDate, DL.Common.DateFormat(authorizedLeaveEndDate, true));
            objParm[22] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndSession, authorizedLeaveEndSession);
            objParm[23] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmAccept, confirmLeaveAccept);
            objParm[24] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmUnits, confirmLeaveUnits);
            objParm[25] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartDate, DL.Common.DateFormat(confirmLeaveStartDate, true));
            objParm[26] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartSession, confirmLeaveStartSession);
            objParm[27] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndDate, DL.Common.DateFormat(confirmLeaveEndDate, true));
            objParm[28] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndsession, confirmLeaveEndSession);
            objParm[29] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[30] = new SqlParameter(DL.Properties.Resources.SessionID, sessionId);
            objParm[31] = new SqlParameter(DL.Properties.Resources.WeekOffStatus, weekOffStatus);
            /* Code Added By  */
            objParm[32] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[33] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParm[34] = new SqlParameter(DL.Properties.Resources.IsDefaultSite, defaultSite);
            objParm[35] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[36] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[37] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[38] = new SqlParameter(DL.Properties.Resources.Post, post);
            /* Code Added By  */
            objParm[39] = new SqlParameter(DL.Properties.Resources.LeaveXml, leaveXml);
            objParm[40] = new SqlParameter(DL.Properties.Resources.SubLeaveCode, subLeaveCode);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveApplication_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// Leaves the posting insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="calendarCode">The calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="exceptionReason">The exception reason.</param>
        /// <param name="notifiedDate">The notified date.</param>
        /// <param name="followUpdate">The follow update.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="startSession">The start session.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="endSession">The end session.</param>
        /// <param name="leaveUnits">The leave units.</param>
        /// <param name="medical">The medical.</param>
        /// <param name="authorizedLeaveUnits">The authorized leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authorizedLeaveStartDate">The authorized leave start date.</param>
        /// <param name="authorizedLeaveStartSession">The authorized leave start session.</param>
        /// <param name="authorizedLeaveEndDate">The authorized leave end date.</param>
        /// <param name="authorizedLeaveEndSession">The authorized leave end session.</param>
        /// <param name="confirmLeaveAccept">The confirm leave accept.</param>
        /// <param name="confirmLeaveUnits">The confirm leave units.</param>
        /// <param name="confirmLeaveStartDate">The confirm leave start date.</param>
        /// <param name="confirmLeaveStartSession">The confirm leave start session.</param>
        /// <param name="confirmLeaveEndDate">The confirm leave end date.</param>
        /// <param name="confirmLeaveEndSession">The confirm leave end session.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="weekOffStatus">if set to <c>true</c> [week off status].</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingInsert(string companyCode, string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authorizedLeaveUnits, string leaveAuthorizationAccept, string authorizedLeaveStartDate, string authorizedLeaveStartSession, string authorizedLeaveEndDate, string authorizedLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy, string sessionId, bool weekOffStatus)
        {

            SqlParameter[] objParm = new SqlParameter[32];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, calendarCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ExceptionFlag, exception);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ExceptionReason, exceptionReason);
            objParm[8] = new SqlParameter(DL.Properties.Resources.NotifiedDate, DL.Common.DateFormat(notifiedDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.FollowupDate, DL.Common.DateFormat(followUpdate));
            objParm[10] = new SqlParameter(DL.Properties.Resources.ExpectedReturnDate, DL.Common.DateFormat(returnDate));
            objParm[11] = new SqlParameter(DL.Properties.Resources.StartDates, DL.Common.DateFormat(startDate));
            objParm[12] = new SqlParameter(DL.Properties.Resources.StartANFNSession, startSession);
            objParm[13] = new SqlParameter(DL.Properties.Resources.EndDates, DL.Common.DateFormat(endDate));
            objParm[14] = new SqlParameter(DL.Properties.Resources.EndANFNSession, endSession);
            objParm[15] = new SqlParameter(DL.Properties.Resources.LeaveTakenUnits, leaveUnits);
            objParm[16] = new SqlParameter(DL.Properties.Resources.MedicalCerification, medical);
            objParm[17] = new SqlParameter(DL.Properties.Resources.LeaveAuthUnits, authorizedLeaveUnits);
            objParm[18] = new SqlParameter(DL.Properties.Resources.LeaveAuthorizationAccept, leaveAuthorizationAccept);
            objParm[19] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartDate, DL.Common.DateFormat(authorizedLeaveStartDate));
            objParm[20] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartSession, authorizedLeaveStartSession);
            objParm[21] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndDate, DL.Common.DateFormat(authorizedLeaveEndDate));
            objParm[22] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndSession, authorizedLeaveEndSession);
            objParm[23] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmAccept, confirmLeaveAccept);
            objParm[24] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmUnits, confirmLeaveUnits);
            objParm[25] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartDate, DL.Common.DateFormat(confirmLeaveStartDate));
            objParm[26] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartSession, confirmLeaveStartSession);
            objParm[27] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndDate, DL.Common.DateFormat(confirmLeaveEndDate));
            objParm[28] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndsession, confirmLeaveEndSession);
            objParm[29] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[30] = new SqlParameter(DL.Properties.Resources.SessionID, sessionId);
            objParm[31] = new SqlParameter(DL.Properties.Resources.WeekOffStatus, weekOffStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveApplication_SchEmpWiseInsert", objParm);
            return ds;
        }
        /// <summary>
        /// Leaves the posting delete.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="calendarCode">The calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="exceptionReason">The exception reason.</param>
        /// <param name="notifiedDate">The notified date.</param>
        /// <param name="followUpdate">The follow update.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="startSession">The start session.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="endSession">The end session.</param>
        /// <param name="leaveUnits">The leave units.</param>
        /// <param name="medical">The medical.</param>
        /// <param name="authorizedLeaveUnits">The authorized leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authorizedLeaveStartDate">The authorized leave start date.</param>
        /// <param name="authorizedLeaveStartSession">The authorized leave start session.</param>
        /// <param name="authorizedLeaveEndDate">The authorized leave end date.</param>
        /// <param name="authorizedLeaveEndSession">The authorized leave end session.</param>
        /// <param name="confirmLeaveAccept">The confirm leave accept.</param>
        /// <param name="confirmLeaveUnits">The confirm leave units.</param>
        /// <param name="confirmLeaveStartDate">The confirm leave start date.</param>
        /// <param name="confirmLeaveStartSession">The confirm leave start session.</param>
        /// <param name="confirmLeaveEndDate">The confirm leave end date.</param>
        /// <param name="confirmLeaveEndSession">The confirm leave end session.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingDelete(string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authorizedLeaveUnits, string leaveAuthorizationAccept, string authorizedLeaveStartDate, string authorizedLeaveStartSession, string authorizedLeaveEndDate, string authorizedLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[29];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, calendarCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ExceptionFlag, exception);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ExceptionReason, exceptionReason);
            objParm[7] = new SqlParameter(DL.Properties.Resources.NotifiedDate, DL.Common.DateFormat(notifiedDate));
            objParm[8] = new SqlParameter(DL.Properties.Resources.FollowupDate, DL.Common.DateFormat(followUpdate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.ExpectedReturnDate, DL.Common.DateFormat(returnDate));
            objParm[10] = new SqlParameter(DL.Properties.Resources.StartDates, DL.Common.DateFormat(startDate));
            objParm[11] = new SqlParameter(DL.Properties.Resources.StartANFNSession, startSession);
            objParm[12] = new SqlParameter(DL.Properties.Resources.EndDates, DL.Common.DateFormat(endDate));
            objParm[13] = new SqlParameter(DL.Properties.Resources.EndANFNSession, endSession);
            objParm[14] = new SqlParameter(DL.Properties.Resources.LeaveTakenUnits, leaveUnits);
            objParm[15] = new SqlParameter(DL.Properties.Resources.MedicalCerification, medical);
            objParm[16] = new SqlParameter(DL.Properties.Resources.LeaveAuthUnits, authorizedLeaveUnits);
            objParm[17] = new SqlParameter(DL.Properties.Resources.LeaveAuthorizationAccept, leaveAuthorizationAccept);
            objParm[18] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartDate, DL.Common.DateFormat(authorizedLeaveStartDate, true));
            objParm[19] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartSession, authorizedLeaveStartSession);
            objParm[20] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndDate, DL.Common.DateFormat(authorizedLeaveEndDate, true));
            objParm[21] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndSession, authorizedLeaveEndSession);
            objParm[22] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmAccept, confirmLeaveAccept);
            objParm[23] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmUnits, confirmLeaveUnits);
            objParm[24] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartDate, DL.Common.DateFormat(confirmLeaveStartDate, true));
            objParm[25] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartSession, confirmLeaveStartSession);
            objParm[26] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndDate, DL.Common.DateFormat(confirmLeaveEndDate, true));
            objParm[27] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndsession, confirmLeaveEndSession);
            objParm[28] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveApplication_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// Cancels the leave.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="leaveType">Type of the leave.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="leaveCancelFromDate">The leave cancel from date.</param>
        /// <param name="leaveCancelToDate">The leave cancel to date.</param>
        /// <param name="leaveUnits">The leave units.</param>
        /// <returns>DataTable.</returns>
        public DataTable CancelLeave(string locationAutoId, string employeeNumber, string leaveCalendarCode, string leaveType, string applicationNo, string leaveCancelFromDate, string leaveCancelToDate, string leaveUnits)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalendarCode, leaveCalendarCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveType, leaveType);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.LeaveCancelFromDate, DL.Common.DateFormat(leaveCancelFromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.LeaveCancelToDate, DL.Common.DateFormat(leaveCancelToDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.LeaveUnits, leaveUnits);
            DataTable dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udp_LeaveApplication_CancelLeave", objParm);
            return dt;
        }

        /// <summary>
        /// Leaves the posting update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="calendarCode">The calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="exceptionReason">The exception reason.</param>
        /// <param name="notifiedDate">The notified date.</param>
        /// <param name="followUpdate">The follow update.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="startSession">The start session.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="endSession">The end session.</param>
        /// <param name="leaveUnits">The leave units.</param>
        /// <param name="medical">The medical.</param>
        /// <param name="authorizedLeaveUnits">The authorized leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authorizedLeaveStartDate">The authorized leave start date.</param>
        /// <param name="authorizedLeaveStartSession">The authorized leave start session.</param>
        /// <param name="authorizedLeaveEndDate">The authorized leave end date.</param>
        /// <param name="authorizedLeaveEndSession">The authorized leave end session.</param>
        /// <param name="confirmLeaveAccept">The confirm leave accept.</param>
        /// <param name="confirmLeaveUnits">The confirm leave units.</param>
        /// <param name="confirmLeaveStartDate">The confirm leave start date.</param>
        /// <param name="confirmLeaveStartSession">The confirm leave start session.</param>
        /// <param name="confirmLeaveEndDate">The confirm leave end date.</param>
        /// <param name="confirmLeaveEndSession">The confirm leave end session.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="weekOffStatus">if set to <c>true</c> [week off status].</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="patternPosition">The pattern position.</param>
        /// <param name="defaultSite">if set to <c>true</c> [default site].</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="post">The post.</param>
        /// <param name="leaveXml">The leave XML.</param>
        /// <param name="subLeaveCode">The sub leave code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingUpdate(string companyCode, string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authorizedLeaveUnits, string leaveAuthorizationAccept, string authorizedLeaveStartDate, string authorizedLeaveStartSession, string authorizedLeaveEndDate, string authorizedLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy, string sessionId, bool weekOffStatus, string shiftPatternCode, string patternPosition, bool defaultSite, string asmtCode, string rowNumber, string attendanceType, string post, string leaveXml, string subLeaveCode)
        {

            SqlParameter[] objParm = new SqlParameter[41];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, calendarCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ExceptionFlag, exception);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ExceptionReason, exceptionReason);
            objParm[8] = new SqlParameter(DL.Properties.Resources.NotifiedDate, DL.Common.DateFormat(notifiedDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.FollowupDate, DL.Common.DateFormat(followUpdate));
            objParm[10] = new SqlParameter(DL.Properties.Resources.ExpectedReturnDate, DL.Common.DateFormat(returnDate));
            objParm[11] = new SqlParameter(DL.Properties.Resources.StartDates, DL.Common.DateFormat(startDate));
            objParm[12] = new SqlParameter(DL.Properties.Resources.StartANFNSession, startSession);
            objParm[13] = new SqlParameter(DL.Properties.Resources.EndDates, DL.Common.DateFormat(endDate));
            objParm[14] = new SqlParameter(DL.Properties.Resources.EndANFNSession, endSession);
            objParm[15] = new SqlParameter(DL.Properties.Resources.LeaveTakenUnits, leaveUnits);
            objParm[16] = new SqlParameter(DL.Properties.Resources.MedicalCerification, medical);
            objParm[17] = new SqlParameter(DL.Properties.Resources.LeaveAuthUnits, authorizedLeaveUnits);
            objParm[18] = new SqlParameter(DL.Properties.Resources.LeaveAuthorizationAccept, leaveAuthorizationAccept);
            objParm[19] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartDate, DL.Common.DateFormat(authorizedLeaveStartDate, true));
            objParm[20] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartSession, authorizedLeaveStartSession);
            objParm[21] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndDate, DL.Common.DateFormat(authorizedLeaveEndDate, true));
            objParm[22] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndSession, authorizedLeaveEndSession);
            objParm[23] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmAccept, confirmLeaveAccept);
            objParm[24] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmUnits, confirmLeaveUnits);
            objParm[25] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartDate, DL.Common.DateFormat(confirmLeaveStartDate, true));
            objParm[26] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartSession, confirmLeaveStartSession);
            objParm[27] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndDate, DL.Common.DateFormat(confirmLeaveEndDate, true));
            objParm[28] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndsession, confirmLeaveEndSession);
            objParm[29] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[30] = new SqlParameter(DL.Properties.Resources.SessionID, sessionId);
            objParm[31] = new SqlParameter(DL.Properties.Resources.WeekOffStatus, weekOffStatus);
            /* Code Added By  */
            objParm[32] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[33] = new SqlParameter(DL.Properties.Resources.PatternPosition, patternPosition);
            objParm[34] = new SqlParameter(DL.Properties.Resources.IsDefaultSite, defaultSite);
            objParm[35] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[36] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            objParm[37] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[38] = new SqlParameter(DL.Properties.Resources.Post, post);
            /* Code Added By  */
            objParm[39] = new SqlParameter(DL.Properties.Resources.LeaveXml, leaveXml);
            objParm[40] = new SqlParameter(DL.Properties.Resources.SubLeaveCode, subLeaveCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveApplication_Update", objParm);
            return ds;
        }
        /// <summary>
        /// Leaves the posting update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="calendarCode">The calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="exceptionReason">The exception reason.</param>
        /// <param name="notifiedDate">The notified date.</param>
        /// <param name="followUpdate">The follow update.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="startSession">The start session.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="endSession">The end session.</param>
        /// <param name="leaveUnits">The leave units.</param>
        /// <param name="medical">The medical.</param>
        /// <param name="authorizedLeaveUnits">The authorized leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authorizedLeaveStartDate">The authorized leave start date.</param>
        /// <param name="authorizedLeaveStartSession">The authorized leave start session.</param>
        /// <param name="authorizedLeaveEndDate">The authorized leave end date.</param>
        /// <param name="authorizedLeaveEndSession">The authorized leave end session.</param>
        /// <param name="confirmLeaveAccept">The confirm leave accept.</param>
        /// <param name="confirmLeaveUnits">The confirm leave units.</param>
        /// <param name="confirmLeaveStartDate">The confirm leave start date.</param>
        /// <param name="confirmLeaveStartSession">The confirm leave start session.</param>
        /// <param name="confirmLeaveEndDate">The confirm leave end date.</param>
        /// <param name="confirmLeaveEndSession">The confirm leave end session.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="weekOffStatus">if set to <c>true</c> [week off status].</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingUpdate(string companyCode, string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authorizedLeaveUnits, string leaveAuthorizationAccept, string authorizedLeaveStartDate, string authorizedLeaveStartSession, string authorizedLeaveEndDate, string authorizedLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy, string sessionId, bool weekOffStatus)
        {

            SqlParameter[] objParm = new SqlParameter[32];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, calendarCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ExceptionFlag, exception);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ExceptionReason, exceptionReason);
            objParm[8] = new SqlParameter(DL.Properties.Resources.NotifiedDate, DL.Common.DateFormat(notifiedDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.FollowupDate, DL.Common.DateFormat(followUpdate));
            objParm[10] = new SqlParameter(DL.Properties.Resources.ExpectedReturnDate, DL.Common.DateFormat(returnDate));
            objParm[11] = new SqlParameter(DL.Properties.Resources.StartDates, DL.Common.DateFormat(startDate));
            objParm[12] = new SqlParameter(DL.Properties.Resources.StartANFNSession, startSession);
            objParm[13] = new SqlParameter(DL.Properties.Resources.EndDates, DL.Common.DateFormat(endDate));
            objParm[14] = new SqlParameter(DL.Properties.Resources.EndANFNSession, endSession);
            objParm[15] = new SqlParameter(DL.Properties.Resources.LeaveTakenUnits, leaveUnits);
            objParm[16] = new SqlParameter(DL.Properties.Resources.MedicalCerification, medical);
            objParm[17] = new SqlParameter(DL.Properties.Resources.LeaveAuthUnits, authorizedLeaveUnits);
            objParm[18] = new SqlParameter(DL.Properties.Resources.LeaveAuthorizationAccept, leaveAuthorizationAccept);
            objParm[19] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartDate, DL.Common.DateFormat(authorizedLeaveStartDate));
            objParm[20] = new SqlParameter(DL.Properties.Resources.LeaveAuthStartSession, authorizedLeaveStartSession);
            objParm[21] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndDate, DL.Common.DateFormat(authorizedLeaveEndDate));
            objParm[22] = new SqlParameter(DL.Properties.Resources.LeaveAuthEndSession, authorizedLeaveEndSession);
            objParm[23] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmAccept, confirmLeaveAccept);
            objParm[24] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmUnits, confirmLeaveUnits);
            objParm[25] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartDate, DL.Common.DateFormat(confirmLeaveStartDate));
            objParm[26] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmStartSession, confirmLeaveStartSession);
            objParm[27] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndDate, DL.Common.DateFormat(confirmLeaveEndDate));
            objParm[28] = new SqlParameter(DL.Properties.Resources.LeaveCnfrmEndsession, confirmLeaveEndSession);
            objParm[29] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[30] = new SqlParameter(DL.Properties.Resources.SessionID, sessionId);
            objParm[31] = new SqlParameter(DL.Properties.Resources.WeekOffStatus, weekOffStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveApplication_SchEmpWiseUpdate", objParm);
            return ds;
        }

        /// <summary>
        /// To Find Whether Sub Leave Exists or Not
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeExists(string companyCode, string leaveCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SubLeaveTypeExists", objParm);
            return ds;
        }

        #endregion

        #region Functions Related to Leave Balances
        /// <summary>
        /// To Get Employee Leave Balance For a Leave Type in Leave Calander
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <returns>DataSet With Leave Balance Days</returns>
        public DataSet EmployeeLeaveBalanceGet(string locationAutoId, string employeeNumber, string leaveCalendarCode, string leaveCode)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstLeave_Application_EmployeeBalance_Get", objParm);
            return ds;
        }
        #endregion

        #region Functions Related to Leave Adjustment
        /// <summary>
        /// Leaves the adjustment insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="adjustedUnits">The adjusted units.</param>
        /// <param name="adjustmentReason">The adjustment reason.</param>
        /// <param name="adjustmentType">Type of the adjustment.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveAdjustmentInsert(string locationAutoId, string employeeNumber, string leaveCalendarCode, string leaveCode, string applicationNo, string adjustedUnits, string adjustmentReason, string adjustmentType, string status, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AdjustedUnits, adjustedUnits);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AdjustmentReason, adjustmentReason);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AdjustmentType, adjustmentType);
            objParm[8] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveAdjustment_Insert", objParm);
            return ds;

        }

        /// <summary>
        /// Leaves the adjustment application number get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveAdjustmentApplicationNumberGet(string employeeNumber, string leaveCode, string leaveCalendarCode, string locationAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstLeaveAdjustment_ApplicationNo_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Leaves the adjustment application detail get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveAdjustmentApplicationDetailGet(string locationAutoId, string employeeNumber, string leaveCalendarCode, string leaveCode, string applicationNo)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstLeaveAdjustment_ApplicationDetail_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Rosters the information get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="leaveType">Type of the leave.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterInformationGet(string companyCode, string locationAutoId, string employeeNumber, string startDate, string endDate, string applicationNo, string leaveType)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.StartDates, DL.Common.DateFormat(startDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.EndDates, DL.Common.DateFormat(endDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ApplicationNo, applicationNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.LeaveTypeCode, leaveType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveApplication_CheckRosterInfo", objParm);
            return ds;
        }
        /// <summary>
        /// Gets the leave entitlement flag.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveType">Type of the leave.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLeaveEntitlementFlag(string companyCode,string leaveType)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LeaveTypeCode, leaveType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "CheckLeaveEntitlementFlag", objParm);
            return ds;
        }
        /// <summary>
        /// Rosters the information delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RosterInformationDelete(string companyCode, string locationAutoId, string employeeNumber, string startDate, string endDate)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.StartDates, DL.Common.DateFormat(startDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.EndDates, DL.Common.DateFormat(endDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveApplication_DeleteRosterInfo", objParm);
            return ds;
        }



        #endregion

        #region Functions Related to Leave Entitlement

        /// <summary>
        /// Leaves the entitlement insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="entitledUnits">The entitled units.</param>
        /// <param name="entitledDate">The entitled date.</param>
        /// <param name="entitlementType">Type of the entitlement.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveEntitlementInsert(string locationAutoId, string employeeNumber, string leaveCalendarCode, string leaveCode, string entitledUnits, string entitledDate, string entitlementType, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCalendarCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCode, leaveCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EntitledUnits, entitledUnits);
            objParm[5] = new SqlParameter(DL.Properties.Resources.EntitledOn, DL.Common.DateFormat(entitledDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.EntitlementType, entitlementType);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LeaveEntitlement_Insert", objParm);
            return ds;
        }

        #endregion

    }
}
