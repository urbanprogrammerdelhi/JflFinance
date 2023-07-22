// ***********************************************************************
// Assembly         : BL
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

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.IncidentGetAll(companyCode, locationAutoId, clientCode, timeFrom, timeTo, dutyDate, modifiedBy);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.PanicAlertsGetAll(companyCode, locationAutoId, clientCode, timeFrom, timeTo, dutyDate, modifiedBy);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.NoShowGetAll(companyCode, locationAutoId, clientCode, timeFrom, timeTo, dutyDate, modifiedBy);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.VacantPostGetAll(companyCode, locationAutoId, clientCode, timeFrom, timeTo, dutyDate, modifiedBy);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.GuardTourGetAll(companyCode, locationAutoId, clientCode, timeFrom, timeTo, dutyDate, modifiedBy);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.PopNoResponseGetAll(companyCode, locationAutoId, clientCode, timeFrom, timeTo, dutyDate, modifiedBy);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.GuardTourReadStatusUpdate(employeeNumber, postcode, swipeTime, dutyDate, modifiedBy, companyCode, locationAutoId);
            return ds;
        }

        /// <summary>
        /// Vacants the post read status update.
        /// </summary>
        /// <param name="dutyCompletedEmployeeNumber">The duty completed employee number.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="lateEmployeeNumber">The late employee number.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet VacantPostReadStatusUpdate(string dutyCompletedEmployeeNumber, string postcode, string lateEmployeeNumber, string dutyDate, string modifiedBy, string companyCode, string locationAutoId)
        {
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.VacantPostReadStatusUpdate(dutyCompletedEmployeeNumber, postcode, lateEmployeeNumber, dutyDate, modifiedBy, companyCode, locationAutoId);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.NoShowReadStatusUpdate(employeeNumber, postcode, scheduledTimeFrom, dutyDate, modifiedBy, companyCode, locationAutoId);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.IncidentReadStatusUpdate(incidentId, modifiedBy);
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
            
            DL.NFC objNfc = new DL.NFC();
            DataSet ds = objNfc.PanicReadStatusUpdate(panicId, modifiedBy);
            return ds;
        }


        // sync Secure trax 16-10-2012


        /// <summary>
        /// Bls the NFC get all incident client controller.
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
        public DataSet BlNfcGetAllIncidentClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGetAllIncidentClientController( companyCode,  locationAutoID,  clientCode,  timeFrom, timeTo,  dutyDate,  toDate,  modifiedBy);
            return ds;
        }


        /// <summary>
        /// Bls the NFC get all panic alerts client controller.
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
        public DataSet BlNfcGetAllPanicAlertsClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGetAllPanicAlertsClientController(companyCode, locationAutoID, clientCode, timeFrom, timeTo, dutyDate, toDate, modifiedBy);
            return ds;
        }


        //public DataSet blNfc_GetAllvacantPost_ClientController(string strCompanyCode, string strLocationAutoID, string strClientCode, string strTimeFrom, string strTimeTo, string strDutyDate, string strToDate, string strModifiedBy)
        //{
        //    DataSet ds = new DataSet();
        //    DL.NFC objNFC = new DL.NFC();
        //    ds = objNFC.dlNfc_GetAllvacantPost_ClientController(strCompanyCode, strLocationAutoID, strClientCode, strTimeFrom, strTimeTo, strDutyDate, strToDate, strModifiedBy);
        //    return ds;
        //}

        /// <summary>
        /// Bls the NFC get allvacant post client controller.
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
        public DataSet BlNfcGetAllvacantPostClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy, string flag)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGetAllvacantPostClientController(companyCode, locationAutoID, clientCode, timeFrom, timeTo, dutyDate, toDate, modifiedBy, flag);
            return ds;
        }

        /// <summary>
        /// Bls the NFC get all no show client controller.
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
        public DataSet BlNfcGetAllNoShowClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGetAllNoShowClentController(companyCode, locationAutoID, clientCode, timeFrom, timeTo, dutyDate, toDate, modifiedBy);
            return ds;
        }


        /// <summary>
        /// Bls the NFC get all pop no response client controller.
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
        public DataSet BlNfcGetAllPopNoResponseClientController(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGetAllPopNoResponseClientController(companyCode, locationAutoID, clientCode, timeFrom, timeTo, dutyDate, toDate, modifiedBy);
            return ds;
        }



        /// <summary>
        /// Bls the NFC unscheduled employee.
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
        public DataSet BlNfcUnscheduledEmployee(string clientCode, string asmtCode, string postCode, string fromdate, string todate, string timeFrom, string timeTo, string locationAutoID)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcUnscheduledEmployee(clientCode, asmtCode, postCode, fromdate, todate, timeFrom, timeTo, locationAutoID);
            return ds;

        }

        #region Added by  on 22-Apr-2014 For Guard Tour Creation
        /// <summary>
        /// Function used to get all details of Guard Tour
        /// </summary>
        /// <param name="strGuardTourID">The string guard tour identifier.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlNfcGuardTourGetAll(string strGuardTourID, string strLocationAutoID)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGuardTourGetAll(strGuardTourID, strLocationAutoID);
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
        public DataSet BlNfcGuardTourInsertAll(string strLocationAutoID, string strClientCode, string strAsmtCode, string strPostCode, string strGuardTourDesc, string strStartTime, string strEndTime, string strFromDay, string strToDay, string strModifiedBy, string strSupervision)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGuardTourInsertAll(strLocationAutoID, strClientCode, strAsmtCode, strPostCode, strGuardTourDesc, strStartTime, strEndTime, strFromDay, strToDay, strModifiedBy, strSupervision);
            return ds;
        }

        /// <summary>
        /// Function used to delete all details of Guard Tour
        /// </summary>
        /// <param name="strGuardTourID">The string guard tour identifier.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlNfcGuardTourDeleteAll(string strGuardTourID, string ModifiedBy)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGuardTourDeleteAll(strGuardTourID, ModifiedBy);
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
        public DataSet BlNfcGuardTourUpdate(string strGuardTourID, string strGuardTourDesc, string strStartTime, string strEndTime, string strFromDay, string strToDay, string strModifiedBy, string strSupervision)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlNfcGuardTourUpdate(strGuardTourID, strGuardTourDesc, strStartTime, strEndTime, strFromDay, strToDay, strModifiedBy, strSupervision);
            return ds;
        }
        #endregion

        #region Device 
        public DataSet BlDeviceAttendanceGet(string locationAutoId, string clientCode, string asmtId, string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlDeviceAttendanceGet(locationAutoId, clientCode, asmtId, fromdate, todate);
            return ds;
        }

        public DataSet BlDeviceEmpAttendanceGet(string locationAutoId, string clientCode, string asmtId, string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlDeviceEmpAttendanceGet(locationAutoId, clientCode, asmtId, fromdate, todate);
            return ds;
        }

        public DataSet BlDeviceEmpIncidentGet(string locationAutoId, string clientCode, string asmtId, string postAutoId, string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlDeviceEmpIncidentGet(locationAutoId, clientCode, asmtId, postAutoId, fromdate, todate);
            return ds;
        }

        public DataSet BlDeviceEmployeeORIncidentImageGet(string deviceAttORInciAutoId, string employeeORIncident)
        {
            DataSet ds = new DataSet();
            DL.NFC objNFC = new DL.NFC();
            ds = objNFC.DlDeviceEmployeeORIncidentImageGet(deviceAttORInciAutoId, employeeORIncident);
            return ds;
        }
        #endregion Device
    }
}
