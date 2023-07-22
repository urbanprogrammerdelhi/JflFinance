// ***********************************************************************
// Assembly         : BL
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

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class Leave.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Leave
    {
        #region Get Employees Leave
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.EmployeesLeaveGet(hrLocationCode, locationAutoId, employeeNumber, fromDate, toDate);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveCalendarGet(companyCode);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveCalendarGet(companyCode, leaveCalendarCode);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveCalendarInsert(companyCode, leaveCalendarCode, leaveCalendarDesc, effectiveFromDate, effectiveToDate, status, modifiedBy);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveCalendarCategoryInsert(companyCode, leaveCalendarCode, categoryCode, status, modifiedBy);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveCalendarCategoryGet(companyCode, leaveCalendarCode);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveTypeGet(leaveCode, companyCode);
            return ds;
        }

        /// <summary>
        /// Leaves the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveTypeGet(string companyCode)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Leaves the and sub leave type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveAndSubLeaveTypeGet(string companyCode)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveAndSubLeaveTypeGet(companyCode);
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
        /// <param name="minUnit">The minimum unit.</param>
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
        public DataSet LeaveTypeInsert(string companyCode, string leaveCode, string frequency, string leaveDesc, string leaveUnit, int leaveUnitInMimutes, string entitlementRule, string entitlementUnit, string carryFlag, string carryRule, string carryDays, string postingRule, string minUnit, string maximumUnit, string encashmentRule, string encashmentUnit, string affectsService, string encashmentFlag, string holidayInclusive, string medicalCertification, string withoutEntitlement, string isActive, string status, string modifiedBy, int postingUnitSource)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveTypeInsert(companyCode, leaveCode, frequency, leaveDesc, leaveUnit, leaveUnitInMimutes, entitlementRule, entitlementUnit, carryFlag, carryRule, carryDays, postingRule, minUnit, maximumUnit, encashmentRule, encashmentUnit, affectsService, encashmentFlag, holidayInclusive, medicalCertification, withoutEntitlement, isActive, status, modifiedBy, postingUnitSource);
            return ds;
        }


        /// <summary>
        /// Assiciateds leave update.
        /// </summary>
        /// <param name="associatedLeaveType">Type of the associated leave.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssiciatedLeaveUpdate(string associatedLeaveType, string leaveCode, string companyCode)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.AssiciatedLeaveUpdate(associatedLeaveType, leaveCode, companyCode);
            return ds;
        }


        #endregion

        #region Functions Related to Sub Leave Type added by  on 28-may-2012

        /// <summary>
        /// Subs leave type get.
        /// </summary>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeGet(string leaveCode, string companyCode)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.SubLeaveTypeGet(leaveCode, companyCode);
            return ds;
        }


        /// <summary>
        /// Subs leave type delete.
        /// </summary>
        /// <param name="SubLeaveCode">The sub leave code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeDelete(string SubLeaveCode)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.SubLeaveTypeDelete(SubLeaveCode);
            return ds;
        }

        /// <summary>
        /// Add New Sub Leave Type.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="SubLeaveCode">The sub leave code.</param>
        /// <param name="SubLeaveDesc">The sub leave desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeInsert(string companyCode, string leaveCode, string SubLeaveCode, string SubLeaveDesc, string modifiedBy)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.SubLeaveTypeInsert(companyCode, leaveCode, SubLeaveCode, SubLeaveDesc, modifiedBy);
            return ds;
        }


        /// <summary>
        /// Sub leave type update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <param name="SubLeaveCode">The sub leave code.</param>
        /// <param name="SubLeaveDesc">The sub leave desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubLeaveTypeUpdate(string companyCode, string leaveCode, string SubLeaveCode, string SubLeaveDesc, string modifiedBy)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.SubLeaveTypeUpdate(companyCode, leaveCode, SubLeaveCode, SubLeaveDesc, modifiedBy);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeavePostingApplicationNumberGet(employeeNumber, leaveCode, locationAutoId, leaveCalendarCode);
            return ds;
        }

        /// <summary>
        /// Leaves the posting application result get.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingApplicationResultGet(string session)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeavePostingApplicationResultGet(session);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeavePostingApplicationDetailGet(locationAutoId, employeeNumber, leaveCalendarCode, leaveCode, applicationNo);
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
        /// <param name="authLeaveUnits">The authentication leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authLeaveStartDate">The authentication leave start date.</param>
        /// <param name="authLeaveStartSession">The authentication leave start session.</param>
        /// <param name="authLeaveEndDate">The authentication leave end date.</param>
        /// <param name="authLeaveEndSession">The authentication leave end session.</param>
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
        public DataSet LeavePostingInsert(string companyCode, string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authLeaveUnits, string leaveAuthorizationAccept, string authLeaveStartDate, string authLeaveStartSession, string authLeaveEndDate, string authLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy, string sessionId, bool weekOffStatus, string shiftPatternCode, string patternPosition, bool defaultSite, string asmtCode, string rowNumber, string attendanceType, string post, string leaveXml, string subLeaveCode)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeavePostingInsert(companyCode, locationAutoId, employeeNumber, calendarCode, leaveCode, applicationNo, exception, exceptionReason, notifiedDate, followUpdate, returnDate, startDate, startSession, endDate, endSession, leaveUnits, medical, authLeaveUnits, leaveAuthorizationAccept, authLeaveStartDate, authLeaveStartSession, authLeaveEndDate, authLeaveEndSession, confirmLeaveAccept, confirmLeaveUnits, confirmLeaveStartDate, confirmLeaveStartSession, confirmLeaveEndDate, confirmLeaveEndSession, modifiedBy, sessionId, weekOffStatus, shiftPatternCode, patternPosition, defaultSite, asmtCode, rowNumber, attendanceType, post, leaveXml, subLeaveCode);
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
        /// <param name="authLeaveUnits">The authentication leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authLeaveStartDate">The authentication leave start date.</param>
        /// <param name="authLeaveStartSession">The authentication leave start session.</param>
        /// <param name="authLeaveEndDate">The authentication leave end date.</param>
        /// <param name="authLeaveEndSession">The authentication leave end session.</param>
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
        public DataSet LeavePostingInsert(string companyCode, string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authLeaveUnits, string leaveAuthorizationAccept, string authLeaveStartDate, string authLeaveStartSession, string authLeaveEndDate, string authLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy, string sessionId, bool weekOffStatus)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeavePostingInsert(companyCode, locationAutoId, employeeNumber, calendarCode, leaveCode, applicationNo, exception, exceptionReason, notifiedDate, followUpdate, returnDate, startDate, startSession, endDate, endSession, leaveUnits, medical, authLeaveUnits, leaveAuthorizationAccept, authLeaveStartDate, authLeaveStartSession, authLeaveEndDate, authLeaveEndSession, confirmLeaveAccept, confirmLeaveUnits, confirmLeaveStartDate, confirmLeaveStartSession, confirmLeaveEndDate, confirmLeaveEndSession, modifiedBy, sessionId, weekOffStatus);
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
        /// <param name="authLeaveUnits">The authentication leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authLeaveStartDate">The authentication leave start date.</param>
        /// <param name="authLeaveStartSession">The authentication leave start session.</param>
        /// <param name="authLeaveEndDate">The authentication leave end date.</param>
        /// <param name="authLeaveEndSession">The authentication leave end session.</param>
        /// <param name="confirmLeaveAccept">The confirm leave accept.</param>
        /// <param name="confirmLeaveUnits">The confirm leave units.</param>
        /// <param name="confirmLeaveStartDate">The confirm leave start date.</param>
        /// <param name="confirmLeaveStartSession">The confirm leave start session.</param>
        /// <param name="confirmLeaveEndDate">The confirm leave end date.</param>
        /// <param name="confirmLeaveEndSession">The confirm leave end session.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeavePostingDelete(string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authLeaveUnits, string leaveAuthorizationAccept, string authLeaveStartDate, string authLeaveStartSession, string authLeaveEndDate, string authLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeavePostingDelete(locationAutoId, employeeNumber, calendarCode, leaveCode, applicationNo, exception, exceptionReason, notifiedDate, followUpdate, returnDate, startDate, startSession, endDate, endSession, leaveUnits, medical, authLeaveUnits, leaveAuthorizationAccept, authLeaveStartDate, authLeaveStartSession, authLeaveEndDate, authLeaveEndSession, confirmLeaveAccept, confirmLeaveUnits, confirmLeaveStartDate, confirmLeaveStartSession, confirmLeaveEndDate, confirmLeaveEndSession, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Cancels the leave.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="txtLeaveCalendarCode">The text leave calendar code.</param>
        /// <param name="leaveType">Type of the leave.</param>
        /// <param name="applicationNo">The application no.</param>
        /// <param name="leaveCancelFromDate">The leave cancel from date.</param>
        /// <param name="leaveCancelToDate">The leave cancel to date.</param>
        /// <param name="leaveUnits">The leave units.</param>
        /// <returns>DataTable.</returns>
        public DataTable CancelLeave(string locationAutoId, string employeeNumber, string txtLeaveCalendarCode, string leaveType, string applicationNo, string leaveCancelFromDate, string leaveCancelToDate, string leaveUnits)
        {
            DL.Leave objLeave = new DL.Leave();
            DataTable dt = objLeave.CancelLeave(locationAutoId, employeeNumber, txtLeaveCalendarCode, leaveType, applicationNo, leaveCancelFromDate, leaveCancelToDate, leaveUnits);
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
        /// <param name="authLeaveUnits">The authentication leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authLeaveStartDate">The authentication leave start date.</param>
        /// <param name="authLeaveStartSession">The authentication leave start session.</param>
        /// <param name="authLeaveEndDate">The authentication leave end date.</param>
        /// <param name="authLeaveEndSession">The authentication leave end session.</param>
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
        public DataSet LeavePostingUpdate(string companyCode, string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authLeaveUnits, string leaveAuthorizationAccept, string authLeaveStartDate, string authLeaveStartSession, string authLeaveEndDate, string authLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy, string sessionId, bool weekOffStatus, string shiftPatternCode, string patternPosition, bool defaultSite, string asmtCode, string rowNumber, string attendanceType, string post, string leaveXml, string subLeaveCode)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeavePostingUpdate(companyCode, locationAutoId, employeeNumber, calendarCode, leaveCode, applicationNo, exception, exceptionReason, notifiedDate, followUpdate, returnDate, startDate, startSession, endDate, endSession, leaveUnits, medical, authLeaveUnits, leaveAuthorizationAccept, authLeaveStartDate, authLeaveStartSession, authLeaveEndDate, authLeaveEndSession, confirmLeaveAccept, confirmLeaveUnits, confirmLeaveStartDate, confirmLeaveStartSession, confirmLeaveEndDate, confirmLeaveEndSession, modifiedBy, sessionId, weekOffStatus, shiftPatternCode, patternPosition, defaultSite, asmtCode, rowNumber, attendanceType, post, leaveXml, subLeaveCode);
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
        /// <param name="authLeaveUnits">The authentication leave units.</param>
        /// <param name="leaveAuthorizationAccept">The leave authorization accept.</param>
        /// <param name="authLeaveStartDate">The authentication leave start date.</param>
        /// <param name="authLeaveStartSession">The authentication leave start session.</param>
        /// <param name="authLeaveEndDate">The authentication leave end date.</param>
        /// <param name="authLeaveEndSession">The authentication leave end session.</param>
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
        public DataSet LeavePostingUpdate(string companyCode, string locationAutoId, string employeeNumber, string calendarCode, string leaveCode, string applicationNo, string exception, string exceptionReason, string notifiedDate, string followUpdate, string returnDate, string startDate, string startSession, string endDate, string endSession, string leaveUnits, string medical, string authLeaveUnits, string leaveAuthorizationAccept, string authLeaveStartDate, string authLeaveStartSession, string authLeaveEndDate, string authLeaveEndSession, string confirmLeaveAccept, string confirmLeaveUnits, string confirmLeaveStartDate, string confirmLeaveStartSession, string confirmLeaveEndDate, string confirmLeaveEndSession, string modifiedBy, string sessionId, bool weekOffStatus)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeavePostingUpdate(companyCode, locationAutoId, employeeNumber, calendarCode, leaveCode, applicationNo, exception, exceptionReason, notifiedDate, followUpdate, returnDate, startDate, startSession, endDate, endSession, leaveUnits, medical, authLeaveUnits, leaveAuthorizationAccept, authLeaveStartDate, authLeaveStartSession, authLeaveEndDate, authLeaveEndSession, confirmLeaveAccept, confirmLeaveUnits, confirmLeaveStartDate, confirmLeaveStartSession, confirmLeaveEndDate, confirmLeaveEndSession, modifiedBy, sessionId, weekOffStatus);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.SubLeaveTypeExists(companyCode, leaveCode);
            return ds;
        }


        #endregion

        #region Functions Related to Leave Balances

        /// <summary>
        /// Employees the leave balance get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCalendarCode">The leave calendar code.</param>
        /// <param name="leaveCode">The leave code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeLeaveBalanceGet(string locationAutoId, string employeeNumber, string leaveCalendarCode, string leaveCode)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.EmployeeLeaveBalanceGet(locationAutoId, employeeNumber, leaveCalendarCode, leaveCode);
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
        /// <param name="leaveApplicationNo">The leave application no.</param>
        /// <param name="adjustedUnits">The adjusted units.</param>
        /// <param name="adjustmentReason">The adjustment reason.</param>
        /// <param name="adjustmentType">Type of the adjustment.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LeaveAdjustmentInsert(string locationAutoId, string employeeNumber, string leaveCalendarCode, string leaveCode, string leaveApplicationNo, string adjustedUnits, string adjustmentReason, string adjustmentType, string status, string modifiedBy)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveAdjustmentInsert(locationAutoId, employeeNumber, leaveCalendarCode, leaveCode, leaveApplicationNo, adjustedUnits, adjustmentReason, adjustmentType, status, modifiedBy);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveAdjustmentApplicationNumberGet(employeeNumber, leaveCode, leaveCalendarCode, locationAutoId);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveAdjustmentApplicationDetailGet(locationAutoId, employeeNumber, leaveCalendarCode, leaveCode, applicationNo);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.RosterInformationGet(companyCode, locationAutoId, employeeNumber, startDate, endDate, applicationNo, leaveType);
            return ds;
        }
        /// <summary>
        /// Gets the leave entitlement flag.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="leaveType">Type of the leave.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLeaveEntitlementFlag(string companyCode, string leaveType)
        {
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.GetLeaveEntitlementFlag(companyCode, leaveType);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.RosterInformationDelete(companyCode, locationAutoId, employeeNumber, startDate, endDate);
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
            DL.Leave objdlLeave = new DL.Leave();

            DataSet ds = objdlLeave.LeaveEntitlementInsert(locationAutoId, employeeNumber, leaveCalendarCode, leaveCode, entitledUnits, entitledDate, entitlementType, modifiedBy);
            return ds;
        }
        #endregion

    }
}
