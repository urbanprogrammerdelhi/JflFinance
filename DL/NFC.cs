// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="NFC.cs" company="Magnon">
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
    /// Class NFC.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class NFC
    {

        /// <summary>
        /// Incidents the get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentGetAll(string companyCode, string locationAutoId, string clientCode, string timeFrom, string timeTo, string dutyDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCIncident", objParm);
            return ds;
        }
        /// <summary>
        /// Panics the alerts get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet PanicAlertsGetAll(string companyCode, string locationAutoId, string clientCode, string timeFrom, string timeTo, string dutyDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCPanicAlert", objParm);
            return ds;
        }

        /// <summary>
        /// Noes the show get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet NoShowGetAll(string companyCode, string locationAutoId, string clientCode, string timeFrom, string timeTo, string dutyDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCNoShow", objParm);
            return ds;
        }

        /// <summary>
        /// Vacants the post get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet VacantPostGetAll(string companyCode, string locationAutoId, string clientCode, string timeFrom, string timeTo, string dutyDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCVacantPost", objParm);
            return ds;
        }

        /// <summary>
        /// Guards the tour get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GuardTourGetAll(string companyCode, string locationAutoId, string clientCode, string timeFrom, string timeTo, string dutyDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCguardTour", objParm);
            return ds;
        }


        /// <summary>
        /// Pops the no response get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet PopNoResponseGetAll(string companyCode, string locationAutoId, string clientCode, string timeFrom, string timeTo, string dutyDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCPOPNoResponse", objParm);
            return ds;
        }

        /// <summary>
        /// Guards the tour read status update.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="swipeTime">The swipe time.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GuardTourReadStatusUpdate(string employeeNumber, string postcode, string swipeTime, string dutyDate, string modifiedBy, string companyCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.SwipeTime, swipeTime);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_GuardTour_UpdateReadStatus", objParm);
            return ds;
        }

        /// <summary>
        /// Vacants the post read status update.
        /// </summary>
        /// <param name="dutyCompletedEmployeeNumber">The duty completed employee number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="lateDutyEmployeeNumber">The late duty employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet VacantPostReadStatusUpdate(string dutyCompletedEmployeeNumber, string postcode, string lateDutyEmployeeNumber, string dutyDate, string modifiedBy, string companyCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DutyCompletedEmployeeNumber, dutyCompletedEmployeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LateEmployeeNumber, lateDutyEmployeeNumber);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_VacantPost_UpdateReadStatus", objParm);
            return ds;
        }
        /// <summary>
        /// Noes the show read status update.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="scheduledTimeFrom">The scheduled time from.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet NoShowReadStatusUpdate(string employeeNumber, string postcode, string scheduledTimeFrom, string dutyDate, string modifiedBy, string companyCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ScheduledTimeFrom, scheduledTimeFrom);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NoShow_UpdateReadStatus", objParm);
            return ds;
        }
        /// <summary>
        /// Incidents the read status update.
        /// </summary>
        /// <param name="incidentId">The incident identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentReadStatusUpdate(string incidentId, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.IncidentID, incidentId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_Incident_UpdateReadStatus", objParm);
            return ds;
        }
        /// <summary>
        /// Panics the read status update.
        /// </summary>
        /// <param name="panicId">The panic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet PanicReadStatusUpdate(string panicId, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.PanicID, panicId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_Panic_UpdateReadStatus", objParm);
            return ds;
        }

        //  


        /// <summary>
        /// Dls the NFC get all incident client controller.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGetAllIncidentClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@CompanyCode", companyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", clientCode);
            objParm[3] = new SqlParameter("@TimeFrom", timeFrom);
            objParm[4] = new SqlParameter("@TimeTo", timeTo);
            objParm[5] = new SqlParameter("@DutyDate", DL.Common.DateFormat(dutyDate));
            objParm[6] = new SqlParameter("@WETDate", DL.Common.DateFormat(toDate));
            objParm[7] = new SqlParameter("@ModifiedBy", modifiedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCIncident_ClientController", objParm);
            return ds;
        }

        /// <summary>
        /// Dls the NFC get all panic alerts client controller.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGetAllPanicAlertsClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@CompanyCode", companyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", clientCode);
            objParm[3] = new SqlParameter("@TimeFrom", timeFrom);
            objParm[4] = new SqlParameter("@TimeTo", timeTo);
            objParm[5] = new SqlParameter("@DutyDate", DL.Common.DateFormat(dutyDate));
            objParm[6] = new SqlParameter("@ModifiedBy", modifiedBy);
            objParm[7] = new SqlParameter("@WETDate", DL.Common.DateFormat(toDate));

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCPanicAlert_ClientController", objParm);
            return ds;
        }

        //public DataSet dlNfc_GetAllvacantPost_ClientController(string strCompanyCode, string strLocationAutoID, string strClientCode, string strTimeFrom, string strTimeTo, string strDutyDate, string strToDate, string strModifiedBy)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter[] objParm = new SqlParameter[8];

        //    objParm[0] = new SqlParameter("@CompanyCode", strCompanyCode);
        //    objParm[1] = new SqlParameter("@LocationAutoID", strLocationAutoID);
        //    objParm[2] = new SqlParameter("@ClientCode", strClientCode);
        //    objParm[3] = new SqlParameter("@TimeFrom", strTimeFrom);
        //    objParm[4] = new SqlParameter("@TimeTo", strTimeTo);
        //    objParm[5] = new SqlParameter("@DutyDate", DL.Common.DateFormat(strDutyDate));
        //    objParm[6] = new SqlParameter("@ModifiedBy", strModifiedBy);
        //    objParm[7] = new SqlParameter("@WETDate", DL.Common.DateFormat(strToDate));
        //    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCVacantPost_ClientController", objParm);
        //    return ds;
        //}

        /// <summary>
        /// Dls the NFC get allvacant post client controller.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGetAllvacantPostClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy, string flag)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[9];

            objParm[0] = new SqlParameter("@CompanyCode", companyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", clientCode);
            objParm[3] = new SqlParameter("@TimeFrom", timeFrom);
            objParm[4] = new SqlParameter("@TimeTo", timeTo);
            objParm[5] = new SqlParameter("@DutyDate", DL.Common.DateFormat(dutyDate));
            objParm[6] = new SqlParameter("@ModifiedBy", modifiedBy);
            objParm[7] = new SqlParameter("@WETDate", DL.Common.DateFormat(toDate));
            objParm[8] = new SqlParameter("@flag", flag);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCVacantPost", objParm);
            return ds;
        }

        /// <summary>
        /// Dls the NFC get all no show clent controller.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGetAllNoShowClentController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@CompanyCode", companyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", clientCode);
            objParm[3] = new SqlParameter("@TimeFrom", timeFrom);
            objParm[4] = new SqlParameter("@TimeTo", timeTo);
            objParm[5] = new SqlParameter("@DutyDate", dutyDate);
            objParm[6] = new SqlParameter("@ModifiedBy", modifiedBy);
            objParm[7] = new SqlParameter("@WETDate", toDate);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCNoShow_ClientController", objParm);
            return ds;
        }



        /// <summary>
        /// Dls the NFC get all pop no response client controller.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGetAllPopNoResponseClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter("@CompanyCode", companyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", clientCode);
            objParm[3] = new SqlParameter("@TimeFrom", timeFrom);
            objParm[4] = new SqlParameter("@TimeTo", timeTo);
            objParm[5] = new SqlParameter("@DutyDate", dutyDate);
            objParm[6] = new SqlParameter("@ModifiedBy", modifiedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCPOPNoResponse_ClientController", objParm);
            return ds;
        }



        ////For Unscheduled Emploee 


        /// <summary>
        /// Dls the NFC unscheduled employee.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="todate">The todate.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcUnscheduledEmployee(string clientCode, string asmtCode, string postCode, string fromdate, string todate, string timeFrom, string timeTo, string locationAutoID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@ClientCode", clientCode);
            objParm[1] = new SqlParameter("@AsmtCode", asmtCode);
            objParm[2] = new SqlParameter("@PostCode", postCode);
            objParm[3] = new SqlParameter("@dutydate", DL.Common.DateFormat(fromdate));
            objParm[4] = new SqlParameter("@tf", timeFrom);
            objParm[5] = new SqlParameter("@tt", timeTo);


            objParm[6] = new SqlParameter("@WETDate", DL.Common.DateFormat(todate));
            objParm[7] = new SqlParameter("@LocationAutoID", locationAutoID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "NFC_Unscheduled_EmployeeDetails", objParm);
            return ds;
        }

        //////////////////---------------------POP Update-------------------------

        #region Added by  on 22-Apr-2014 For Guard Tour Creation
        /// <summary>
        /// Function used to get all details of Guard Tour
        /// </summary>
        /// <param name="strGuardTourID">The string guard tour identifier.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGuardTourGetAll(string strGuardTourID, string strLocationAutoID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter("@GuardTourID", strGuardTourID);
            objParm[1] = new SqlParameter("@LocationAutoID", strLocationAutoID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_GuardTour_GetAll", objParm);
            return ds;
        }

        /// <summary>
        /// Function used to insert the detail of Guard Tour
        /// </summary>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="strPostCode">The string post code.</param>
        /// <param name="strGuardTourDesc">The string guard tour desc.</param>
        /// <param name="strStartTime">The string start time.</param>
        /// <param name="strEndTime">The string end time.</param>
        /// <param name="strFromDay">The string from day.</param>
        /// <param name="strToDay">The string to day.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <param name="strSupervision">The string supervision.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGuardTourInsertAll(string strLocationAutoID, string strClientCode, string strAsmtCode, string strPostCode, string strGuardTourDesc, string strStartTime, string strEndTime, string strFromDay, string strToDay, string strModifiedBy, string strSupervision)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[11];

            objParm[0] = new SqlParameter("@LocationAutoID", strLocationAutoID);
            objParm[1] = new SqlParameter("@ClientCode", strClientCode);
            objParm[2] = new SqlParameter("@AsmtCode", strAsmtCode);
            objParm[3] = new SqlParameter("@PostCode", strPostCode);
            objParm[4] = new SqlParameter("@GuardTourDesc", strGuardTourDesc);
            objParm[5] = new SqlParameter("@StartTime", DL.Common.DateFormat(strStartTime));
            objParm[6] = new SqlParameter("@EndTime", DL.Common.DateFormat(strEndTime));
            objParm[7] = new SqlParameter("@FromDay", strFromDay);
            objParm[8] = new SqlParameter("@ToDay", strToDay);
            objParm[9] = new SqlParameter("@ModifiedBy", strModifiedBy);
            objParm[10] = new SqlParameter("@Supervision", Boolean.Parse(strSupervision));
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_GuardTour_InsertAll", objParm);
            return ds;
        }

        /// <summary>
        /// Function used to delete all details of Guard Tour
        /// </summary>
        /// <param name="strGuardTourID">The string guard tour identifier.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGuardTourDeleteAll(string strGuardTourID, string strModifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter("@GuardTourID", strGuardTourID);
            objParm[1] = new SqlParameter("@ModifiedBy", strModifiedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_GuardTour_DeleteAll", objParm);
            return ds;
        }

        /// <summary>
        /// Function used to update the detail of Guard Tour
        /// </summary>
        /// <param name="strGuardTourID">The string guard tour identifier.</param>
        /// <param name="strGuardTourDesc">The string guard tour desc.</param>
        /// <param name="strStartTime">The string start time.</param>
        /// <param name="strEndTime">The string end time.</param>
        /// <param name="strFromDay">The string from day.</param>
        /// <param name="strToDay">The string to day.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <param name="strSupervision">The string supervision.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcGuardTourUpdate(string strGuardTourID, string strGuardTourDesc, string strStartTime, string strEndTime, string strFromDay, string strToDay, string strModifiedBy, string strSupervision)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@GuardTourID", strGuardTourID);
            objParm[1] = new SqlParameter("@GuardTourDesc", strGuardTourDesc);
            objParm[2] = new SqlParameter("@StartTime", DL.Common.DateFormat(strStartTime));
            objParm[3] = new SqlParameter("@EndTime", DL.Common.DateFormat(strEndTime));
            objParm[4] = new SqlParameter("@FromDay", strFromDay);
            objParm[5] = new SqlParameter("@ToDay", strToDay);
            objParm[6] = new SqlParameter("@ModifiedBy", strModifiedBy);
            objParm[7] = new SqlParameter("@Supervision", Boolean.Parse(strSupervision));
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_GuardTour_Update", objParm);
            return ds;
        }
        #endregion

        #region Device
        public DataSet DlDeviceAttendanceGet(string locationAutoId, string clientCode, string asmtId, string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter("@LocationAutoID", locationAutoId);
            objParm[1] = new SqlParameter("@ClientCode", clientCode);
            objParm[2] = new SqlParameter("@AsmtId", asmtId);
            objParm[3] = new SqlParameter("@FromDate", DL.Common.DateFormat(fromdate));
            objParm[4] = new SqlParameter("@ToDate", todate);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpDeviceAttendanceGet", objParm);
            return ds;
        }

        public DataSet DlDeviceEmpAttendanceGet(string locationAutoId, string clientCode, string asmtId, string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter("@LocationAutoID", locationAutoId);
            objParm[1] = new SqlParameter("@ClientCode", clientCode);
            objParm[2] = new SqlParameter("@AsmtId", asmtId);
            objParm[3] = new SqlParameter("@FromDate", DL.Common.DateFormat(fromdate));
            objParm[4] = new SqlParameter("@ToDate", todate);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpDeviceEmpAttendanceGet", objParm);
            return ds;
        }
        public DataSet DlDeviceEmpIncidentGet(string locationAutoId, string clientCode, string asmtId, string postAutoId, string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter("@LocationAutoID", locationAutoId);
            objParm[1] = new SqlParameter("@ClientCode", clientCode);
            objParm[2] = new SqlParameter("@AsmtId", asmtId);
            objParm[3] = new SqlParameter("@PostAutoId", postAutoId);
            objParm[4] = new SqlParameter("@FromDate", DL.Common.DateFormat(fromdate));
            objParm[5] = new SqlParameter("@ToDate", todate);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpDeviceEmpIncidentGet", objParm);
            return ds;
        }

        public DataSet DlDeviceEmployeeORIncidentImageGet(string deviceAttORInciAutoId, string employeeORIncident)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter("@DeviceAttORInciAutoId", deviceAttORInciAutoId);
            objParm[1] = new SqlParameter("@EmployeeORIncident", employeeORIncident);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpDeviceEmployeeIncidentImageGet", objParm);
            return ds;
        }
        #endregion Device
    }
}
