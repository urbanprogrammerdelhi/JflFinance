// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="OperationManagement.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class OperationManagement.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class OperationManagement
    {

        #region Function Related to Area Master
        #region Function To get All Details Of Area Master based on location Auto id
        /// <summary>
        /// To get All Details Of Area Master based on location Auto id
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaMasterGetAll(string locationAutoId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaMasterGetAll(locationAutoId);
            return ds;
        }
        /// <summary>
        /// Clients the area master get all.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientAreaMasterGetAll(string locationAutoId, string clientCode, string asmtId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.ClientAreaMasterGetAll(locationAutoId, clientCode, asmtId);
            return ds;
        }
        /// <summary>
        /// Clients the get all.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientGetAll(string locationAutoId, string asmtId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.ClientGetAll(locationAutoId, asmtId);
            return ds;
        }
        /// <summary>
        /// Areas the master get all.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaMasterGetAll(string locationCode, string hrLocationCode, string companyCode)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaMasterGetAll(locationCode, hrLocationCode, companyCode);
            return ds;
        }

        #endregion
        #region Function To insert data
        /// <summary>
        /// To insert data
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaDesc">The area desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaMasterInsert(string locationAutoId, string areaId, string areaDesc, string modifiedBy)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaMasterInsert(locationAutoId, areaId, areaDesc, modifiedBy);
            return ds;

        }
        #endregion
        #region FUnction To Update Data
        /// <summary>
        /// To Update Data
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaDesc">The area desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaMasterUpdate(string locationAutoId, string areaId, string areaDesc, string modifiedBy)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaMasterUpdate(locationAutoId, areaId, areaDesc, modifiedBy);
            return ds;
        }
        #endregion
        #region Function To Delete Data
        /// <summary>
        /// To Delete Data
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaMasterDelete(string locationAutoId, string areaId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaMasterDelete(locationAutoId, areaId);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related To Area Incharge
        /// <summary>
        /// TO get all Area Incharge based on locationAutoid
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGetAll(string locationAutoId, string areaId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaInchargeGetAll(locationAutoId, areaId);
            return ds;
        }

        /// <summary>
        /// Areas the incharge get.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGet(string locationCode, string hrLocationCode, string companyCode, string areaId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaInchargeGet(locationCode, hrLocationCode, companyCode, areaId);
            return ds;
        }


        /// <summary>
        /// Get Area Incharge For AsmtAutoId and AreaId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGet(string locationAutoId, string areaId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaInchargeGet(locationAutoId, areaId);
            return ds;
        }
        /// <summary>
        /// TO get Area Id based on Location Auto id
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaIdGet(String locationAutoId, String areaIncharge)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaIdGet(locationAutoId, areaIncharge);
            return ds;

        }

        /// <summary>
        /// TO get LocationAutoID Id based on Current Branch Selection
        /// </summary>
        /// <param name="BaseCompanyCode">The base company code.</param>
        /// <param name="LocationCode">.</param>
        /// <param name="HrlocationCode">The hrlocation code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetCurrentLocationAutoID(String BaseCompanyCode, String LocationCode, string HrlocationCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.GetCurrentLocationAutoID(BaseCompanyCode, LocationCode,HrlocationCode);
            return ds;
        }


        /// <summary>
        /// TO get Area Id based on Location Auto id and UserID
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userid">The userid.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaIdGetUserWise(String locationAutoId, String userid)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaIdGetUserWise(locationAutoId, userid);
            return ds;

        }
        /// <summary>
        /// To Get Area Id Based On Area Incharge and Valid From And To date
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaIdGet(string locationAutoId, string areaIncharge, string isIncharge, string fromDate, string toDate)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaIdGet(locationAutoId, areaIncharge, isIncharge, fromDate, toDate);
            return ds;

        }

        /// <summary>
        /// Areas the identifier get all.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaIdGetAll(string locationAutoId, string areaIncharge, string isIncharge, string fromDate, string toDate)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaIdGetAll(locationAutoId, areaIncharge, isIncharge, fromDate, toDate);
            return ds;

        }

        /// <summary>
        /// Areas the identifier get all for location.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaIdGetAllForLocation(string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaIdGetAllForLocation(locationAutoId);
            return ds;
        }

        /// <summary>
        /// To get area desc based on area id
        /// </summary>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaDescBasedOnAreaIdGet(string areaId, string locationAutoId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaDescBasedOnAreaIdGet(areaId, locationAutoId);
            return ds;

        }
        /// <summary>
        /// To get Employeename based on employee Id
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameByIdGet(string employeeNumber)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.EmployeeNameByIdGet(employeeNumber);
            return ds;
        }

        //Code added by   on 2-Sep-2011
        /// <summary>
        /// To Insert data into Area Incharge
        /// </summary>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeInsert(string areaId, string employeeNumber, string locationAutoId, string modifiedBy, string effectiveFrom)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaInchargeInsert(areaId, employeeNumber, locationAutoId, modifiedBy, effectiveFrom);
            return ds;
        }
        //End of Code added by   on 2-Sep-2011

        /// <summary>
        /// To delete date from area incharge
        /// </summary>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeDelete(string areaId, string employeeNumber, string locationAutoId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaInchargeDelete(areaId, employeeNumber, locationAutoId);
            return ds;

        }

        //Code added by   on 6-Sep-2011
        /// <summary>
        /// this Method will return the List of Area Incharge for the Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet FutureIncharge(string locationAutoId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.FutureIncharge(locationAutoId);
            return ds;
        }
        /// <summary>
        /// this will update and create a new AreaIncharge for the ending line
        /// </summary>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaInchargeAutoId">The area incharge automatic identifier.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeUpdate(string areaId, string employeeNumber, string locationAutoId, string areaInchargeAutoId, string effectiveFrom, string effectiveTo, string modifiedBy)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaInchargeUpdate(areaId, employeeNumber, locationAutoId, areaInchargeAutoId, effectiveFrom, effectiveTo, modifiedBy);
            return ds;
        }
        /// <summary>
        /// this will return status of the Line Incharge Wise for Current Employee
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeStatus(string locationAutoId, string areaId, string employeeNumber, string effectiveFrom)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaInchargeStatus(locationAutoId, areaId, employeeNumber, effectiveFrom);
            return ds;
        }
        //End of Code added by   on 6-Sep-2011

        /// <summary>
        /// returns Dataset with AreaInchnarge List Location Wise
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeLocationWise(string locationAutoId, string month, string year)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AreaInchargeLocationWise(locationAutoId, month, year);
            return ds;
        }
        #endregion

        #region Functions related to Assignment
        /// <summary>
        /// Get AsmtDetails For Sale Order, locationAutoId, AsmtId and AsmtAmendNo.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtDetailGet(string clientCode, string locationAutoId, string asmtId, string asmtAmendNo)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AsmtDetailGet(clientCode, locationAutoId, asmtId, asmtAmendNo);
            return ds;
        }
        /// <summary>
        /// Function to get Asmt Code Address for Asmt site instruction report
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet OpsAsmtCodeAddressGet(string locationAutoId, string clientCode)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.OpsAsmtCodeAddressGet(locationAutoId, clientCode);
            return ds;
        }

        /// <summary>
        /// Get AsmtAmendNo For SaleOrder No, ocationAutoId, AsmtId
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtAmendNoGet(string clientCode, string locationAutoId, string asmtId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AsmtAmendNoGet(clientCode, locationAutoId, asmtId);
            return ds;
        }

        /// <summary>
        /// Get Assignments for locationAutoId, AreaIncharge, AreaId and ClientCode
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientGet(int locationAutoId, string clientCode, string fromDate, string toDate, string areaIncharge, string areaId)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();
            DataSet ds = objdlOperationManagement.AssignmentsOfClientGet(locationAutoId, clientCode, fromDate, toDate, areaIncharge, areaId);
            return ds;
        }

        /// <summary>
        /// Get Assignments for locationAutoId and ClientCode
        /// Area Id Added By   on 22-Mar-2012
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>data set of assignments</returns>
        public DataSet AssignmentsOfClientGet(int locationAutoId, string clientCode, string fromDate, string toDate, string areaIncharge, string isAreaIncharge, string areaId)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();
            DataSet ds = objdlOperationManagement.AssignmentsOfClientGet(locationAutoId, clientCode, fromDate, toDate, areaIncharge, isAreaIncharge, areaId);
            return ds;
        }

        /// <summary>
        /// Preferances the assignments of client get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PreferanceAssignmentsOfClientGet(int locationAutoId, string clientCode, string fromDate, string toDate, string areaIncharge, string isAreaIncharge, string areaId)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();
            DataSet ds = objdlOperationManagement.PreferanceAssignmentsOfClientGet(locationAutoId, clientCode, fromDate, toDate, areaIncharge, isAreaIncharge, areaId);
            return ds;
        }
        /// <summary>
        /// Get Assignments for locationAutoId and ClientCode Wise On Multiple Client Selection
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>data set of assignments</returns>
        public DataSet AssignmentsOfMultipleClientGet(int locationAutoId, string clientCode, string fromDate, string toDate, string areaIncharge, string isAreaIncharge, string areaId)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();
            DataSet ds = objdlOperationManagement.AssignmentsOfMultipleClientGet(locationAutoId, clientCode, fromDate, toDate, areaIncharge, isAreaIncharge, areaId);
            return ds;
        }

        /// <summary>
        /// Get Assignments for locationAutoId and ClientCode
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>data set of assignments</returns>
        public DataSet AssignmentsOfClientScheduleLockUnlockGet(int locationAutoId, string clientCode, string fromDate, string toDate)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();

            DataSet ds = objdlOperationManagement.AssignmentsOfClientScheduleLockUnlockGet(locationAutoId, clientCode, fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// Posts for selected asmt get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostForSelectedAsmtGet(int locationAutoId, string clientCode, string asmtCode)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();
            DataSet ds = objdlOperationManagement.PostForSelectedAsmtGet(locationAutoId, clientCode, asmtCode);
            return ds;
        }

        /// <summary>
        /// Assignmentses the of client get based on branch and division code.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="divisionCode">The division code.</param>
        /// <param name="branchCode">The branch code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientGetBasedOnBranchAndDivisionCode(string companyCode, string divisionCode, string branchCode, string clientCode)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();

            DataSet ds = objdlOperationManagement.AssignmentsOfClientGetBasedOnBranchAndDivisionCode(companyCode, divisionCode, branchCode, clientCode);
            return ds;
        }
        /// <summary>
        /// To get assignment Code and Description for a Location, Client and areaId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>To get assignment Code and Description for a Location, Client and areaId</returns>
        public DataSet AssignmentGet(string locationAutoId, string clientCode, string areaId)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();

            DataSet ds = objdlOperationManagement.AssignmentGet(locationAutoId, clientCode, areaId);
            return ds;
        }
        /// <summary>
        /// Function to delete Assignment in fresh mode
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterDelete(string asmtCode, string locationAutoId)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();

            DataSet ds = objdlOperationManagement.AsmtMasterDelete(asmtCode, locationAutoId);
            return ds;
        }


        /// <summary>
        /// To get shift for a Location, assignment id
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>To get assignment Code and Description for a Location, Client and areaId</returns>
        public DataSet ShiftGet(string asmtCode, string locationAutoId)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();

            DataSet ds = objdlOperationManagement.ShiftGet(asmtCode, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To get Shift in Assignment Code of Selected Client and (Client Code and AsmtCode both or any one of them can also be selected as "ALL" or "")
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>To get [Shift] in Assignment Code of Selected Client</returns>
        public DataSet ShiftOnAsmtOfClientGet(string locationAutoId, string clientCode, string asmtCode)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();

            DataSet ds = objdlOperationManagement.ShiftOnAsmtOfClientGet(locationAutoId, clientCode, asmtCode);
            return ds;
        }
        /// <summary>
        /// Get Max Amend No for SONo,locationAutoId,AsmtId
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMaxAmendNoGet(string clientCode, string locationAutoId, string asmtId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMaxAmendNoGet(clientCode, locationAutoId, asmtId);
            return ds;
        }

        /// <summary>
        /// Get Total No Of Post From SOdetails For SONO,locationAutoId,AmendNo
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet TotalNumberOfPostGet(string soNo, string locationAutoId, string soAmendNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.TotalNumberOfPostGet(soNo, locationAutoId, soAmendNo);
            return ds;
        }
        /// <summary>
        /// save the Information of Assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtAutoId">The asmt automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="manualAsmtCode">The manual asmt code.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <param name="asmtAmendDate">The asmt amend date.</param>
        /// <param name="amendBy">The amend by.</param>
        /// <param name="asmtStartDate">The asmt start date.</param>
        /// <param name="terminationDate">The termination date.</param>
        /// <param name="terminationReason">The termination reason.</param>
        /// <param name="terminatedBy">The terminated by.</param>
        /// <param name="asmtStatus">The asmt status.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaInch">The area inch.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterInfoSave(String locationAutoId, string clientCode, string asmtId, string asmtAutoId, string asmtCode, string manualAsmtCode, string asmtAmendNo, string asmtAmendDate, string amendBy, string asmtStartDate, string terminationDate, string terminationReason, string terminatedBy, string asmtStatus, string areaId, string areaInch, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMasterInfoSave(locationAutoId, clientCode, asmtId, asmtAutoId, asmtCode, manualAsmtCode, asmtAmendNo, asmtAmendDate, amendBy, asmtStartDate, terminationDate, terminationReason, terminatedBy, asmtStatus, areaId, areaInch, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Asmts the master minimum so line start date get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterMinSOLineStartDateGet(String locationAutoId, string clientCode, string asmtId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMasterMinSOLineStartDateGet(locationAutoId, clientCode, asmtId);
            return ds;
        }
        /// <summary>
        /// Get AsmtPostDeployment Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentGet(string locationAutoId, string clientCode, string asmtId, string asmtCode, string asmtAmendNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPostDeploymentGet(locationAutoId, clientCode, asmtId, asmtCode, asmtAmendNo);
            return ds;
        }
        /// <summary>
        /// to terminate assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <param name="statusThirdLevelAuthorize">The status third level authorize.</param>
        /// <param name="statusShortClosed">The status short closed.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentGetDetailForTermination(string locationAutoId, string clientCode, string asmtId, string asmtCode, string asmtAmendNo, string statusThirdLevelAuthorize, string statusShortClosed)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPostDeploymentGetDetailForTermination(locationAutoId, clientCode, asmtId, asmtCode, asmtAmendNo, statusThirdLevelAuthorize, statusShortClosed);
            return ds;
        }
        /// <summary>
        /// Asmts the post deployment save.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="site">The site.</param>
        /// <param name="jobDesc">The job desc.</param>
        /// <param name="personAllocated">The person allocated.</param>
        /// <param name="pdLineStartDate">The pd line start date.</param>
        /// <param name="pdLineEndDate">The pd line end date.</param>
        /// <param name="pdLineWefDate">The pd line wef date.</param>
        /// <param name="active">The active.</param>
        /// <param name="billable">The billable.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentSave(string locationAutoId, string asmtId, string asmtCode, string asmtAmendNo, string soLineNo, string pdLineNo, string site, string jobDesc, string personAllocated, string pdLineStartDate, string pdLineEndDate, string pdLineWefDate, string active, string billable, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPostDeploymentSave(locationAutoId, asmtId, asmtCode, asmtAmendNo, soLineNo, pdLineNo, site, jobDesc, personAllocated, pdLineStartDate, pdLineEndDate, pdLineWefDate, active, billable, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Asmts all shifts get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtAllShiftsGet(string locationAutoId, string asmtCode, string dutyDate)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtAllShiftsGet(locationAutoId, asmtCode, dutyDate);
            return ds;
        }


        /// <summary>
        /// Get Assignment Shift deitails for AsmtMasterAutoId,SOLine,pdLineNo
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentShiftDetailGet(string asmtMasterAutoId, int soLineNo, int pdLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPostDeploymentShiftDetailGet(asmtMasterAutoId, soLineNo, pdLineNo);
            return ds;
        }

        /// <summary>
        /// Asmts the post deployment shift details get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentShiftDetailsGet(string asmtMasterAutoId, int soLineNo, int pdLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPostDeploymentShiftDetailsGet(asmtMasterAutoId, soLineNo, pdLineNo);
            return ds;
        }

        /// <summary>
        /// Asmts the post deployment shift details insert.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="pdSLineNo">The pd s line no.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="shift">The shift.</param>
        /// <param name="monTimeFrom">The mon time from.</param>
        /// <param name="monTimeTo">The mon time to.</param>
        /// <param name="tueTimeFrom">The tue time from.</param>
        /// <param name="tueTimeTo">The tue time to.</param>
        /// <param name="wedTimeFrom">The wed time from.</param>
        /// <param name="wedTimeTo">The wed time to.</param>
        /// <param name="thuTimeFrom">The thu time from.</param>
        /// <param name="thuTimeTo">The thu time to.</param>
        /// <param name="friTimeFrom">The fri time from.</param>
        /// <param name="friTimeTo">The fri time to.</param>
        /// <param name="satTimeFrom">The sat time from.</param>
        /// <param name="satTimeTo">The sat time to.</param>
        /// <param name="sunTimeFrom">The sun time from.</param>
        /// <param name="sunTimeTo">The sun time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="recordStatus">The record status.</param>
        /// <param name="maximumLineNo">The maximum line no.</param>
        /// <param name="updateStatus">The update status.</param>
        /// <param name="role">The role.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentShiftDetailsInsert(string soNo, string soAmendNo, string locationAutoId, string asmtMasterAutoId, int soLineNo, int pdLineNo, int pdSLineNo, string weekNo, char shift, string monTimeFrom, string monTimeTo, string tueTimeFrom, string tueTimeTo, string wedTimeFrom, string wedTimeTo, string thuTimeFrom, string thuTimeTo, string friTimeFrom, string friTimeTo, string satTimeFrom, string satTimeTo, string sunTimeFrom, string sunTimeTo, string modifiedBy, string recordStatus, int maximumLineNo, int updateStatus, string role)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPostDeploymentShiftDetailsInsert(soNo, soAmendNo, locationAutoId, asmtMasterAutoId, soLineNo, pdLineNo, pdSLineNo, weekNo, shift, monTimeFrom, monTimeTo, tueTimeFrom, tueTimeTo, wedTimeFrom, wedTimeTo, thuTimeFrom, thuTimeTo, friTimeFrom, friTimeTo, satTimeFrom, satTimeTo, sunTimeFrom, sunTimeTo, modifiedBy, recordStatus, maximumLineNo, updateStatus, role);
            return ds;
        }

        /// <summary>
        /// Asmts the master authorize.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterAuthorize(string asmtMasterAutoId, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMasterAuthorize(asmtMasterAutoId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// Asmts the master amend.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="amendBy">The amend by.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterAmend(string asmtMasterAutoId, string locationAutoId, string amendBy, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMasterAmend(asmtMasterAutoId, locationAutoId, amendBy, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Asmts the master amend on so authorized.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="amendBy">The amend by.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterAmendOnSoAuthorized(string clientCode, string soNo, string locationAutoId, string amendBy, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMasterAmendOnSoAuthorized(clientCode, soNo, locationAutoId, amendBy, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Asmts the master terminate.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="terminatedBy">The terminated by.</param>
        /// <param name="terminationDate">The termination date.</param>
        /// <param name="terminationReason">The termination reason.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterTerminate(string asmtMasterAutoId, string locationAutoId, string terminatedBy, string terminationDate, string terminationReason, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMasterTerminate(asmtMasterAutoId, locationAutoId, terminatedBy, terminationDate, terminationReason, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Asmts the master deployment pattern so get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterDeploymentPatternSoGet(string locationAutoId, string soNo, string soAmendNo, int soLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMasterDeploymentPatternSoGet(locationAutoId, soNo, soAmendNo, soLineNo);
            return ds;
        }
        /// <summary>
        /// to get asmtCode ,maximum amend number based on clientCode,AsmtId,status=Authorized
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterGetAsmtCodeAndMaxAmendNo(string clientCode, string asmtId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtMasterGetAsmtCodeAndMaxAmendNo(clientCode, asmtId, status);
            return ds;
        }

        /// <summary>
        /// To get data for Sale Termination Grid
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="code">The code.</param>
        /// <param name="terminationType">Type of the termination.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleTerminationDetailsGet(string locationAutoId, string code, string terminationType)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SaleTerminationDetailsGet(locationAutoId, code, terminationType);
            return ds;
        }

        /// <summary>
        /// Standards the shift get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardShiftGet(string locationAutoId, string shiftCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.StandardShiftGet(locationAutoId, shiftCode);
            return ds;
        }

        /// <summary>
        /// Asmts the inventory details get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtInventoryDetailsGet(string asmtMasterAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtInventoryDetailsGet(asmtMasterAutoId);
            return ds;
        }

        /// <summary>
        /// Asmts the inventory details insert.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="owner">The owner.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="recordStatus">The record status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtInventoryDetailsInsert(string asmtMasterAutoId, string itemTypeCode, string quantity, string owner, string remarks, string recordStatus, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtInventoryDetailsInsert(asmtMasterAutoId, itemTypeCode, quantity, owner, remarks, recordStatus, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Asmts the training details get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtTrainingDetailsGet(string asmtMasterAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtTrainingDetailsGet(asmtMasterAutoId);
            return ds;
        }

        /// <summary>
        /// Asmts the on job training master get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtOnJobTrainingMasterGet(string asmtMasterAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtOnJobTrainingMasterGet(asmtMasterAutoId);
            return ds;
        }

        /// <summary>
        /// Asmts the site and post get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtSiteAndPostGet(string asmtMasterAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtSiteAndPostGet(asmtMasterAutoId);
            return ds;
        }


        /// <summary>
        /// Asmts the site employee post get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtSiteEmployeePostGet(int asmtMasterAutoId, int locationAutoId, string fromDate, string toDate)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtSiteEmployeePostGet(asmtMasterAutoId, locationAutoId, fromDate, toDate);
            return ds;
        }



        /// <summary>
        /// Asmts the on job training master save.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="rowId">The row identifier.</param>
        /// <param name="site">The site.</param>
        /// <param name="post">The post.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="recordStatus">The record status.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtOnJobTrainingMasterSave(string asmtMasterAutoId, string rowId, string site, string post, string subject, string remarks, string modifiedBy, string recordStatus)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtOnJobTrainingMasterSave(asmtMasterAutoId, rowId, site, post, subject, remarks, modifiedBy, recordStatus);
            return ds;
        }

        /// <summary>
        /// Asmts the onsite training master insert.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="courseId">The course identifier.</param>
        /// <param name="internalExternal">The internal external.</param>
        /// <param name="onsiteTraining">The onsite training.</param>
        /// <param name="recordStatus">The record status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtOnsiteTrainingMasterInsert(string asmtMasterAutoId, string courseId, string internalExternal, string onsiteTraining, string recordStatus, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtOnsiteTrainingMasterInsert(asmtMasterAutoId, courseId, internalExternal, onsiteTraining, recordStatus, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Asmts the inventory item type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtInventoryItemTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtInventoryItemTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Asmts the inventory item subtype get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="itemType">Type of the item.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtInventoryItemSubtypeGet(string companyCode, string itemType)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtInventoryItemSubtypeGet(companyCode, itemType);
            return ds;
        }

        /// <summary>
        /// Asmts the training course type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtTrainingCourseTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtTrainingCourseTypeGet(companyCode);
            return ds;
        }


        /// <summary>
        /// Asmts the site post get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="date">The date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtSitePostGet(int asmtMasterAutoId, int locationAutoId, string date)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtSitePostGet(asmtMasterAutoId, locationAutoId, date);
            return ds;
        }

        /// <summary>
        /// Asmts the post deployment shift get.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentShiftGet(string asmtMasterAutoId, string soNo, string soLineNo, string pdLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPostDeploymentShiftGet(asmtMasterAutoId, soNo, soLineNo, pdLineNo);
            return ds;
        }
        /// <summary>
        /// Copies the asmt shift.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="copyTo">The copy to.</param>
        /// <returns>DataSet.</returns>
        public DataSet CopyAsmtShift(string asmtMasterAutoId, string soNo, string soLineNo, string pdLineNo, string copyTo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CopyAsmtShift(asmtMasterAutoId, soNo, soLineNo, pdLineNo, copyTo);
            return ds;
        }

        /// <summary>
        /// Opses the pending asmt get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="statusFresh">The status fresh.</param>
        /// <param name="statusAmend">The status amend.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OpsPendingAsmtGet(string locationAutoId, string statusFresh, string statusAmend, string userId)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.OpsPendingAsmtGet(locationAutoId, statusFresh, statusAmend, userId);
            return ds;
        }

        /// <summary>
        /// Opses the get all post based on asmt code.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet OpsGetAllPostBasedOnAsmtCode(string asmtCode, string locationAutoId, string fromDate, string toDate,string clientCode)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.OpsGetAllPostBasedOnAsmtCode(asmtCode, locationAutoId, fromDate, toDate, clientCode);
            return ds;
        }
        /// <summary>
        /// To Get Assignemnt for Selected Clients
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>dataset</returns>
        public DataSet AssignmentsOfSelectedClientGet(int locationAutoId, string clientCode)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();
            DataSet ds = objdlOperationManagement.AssignmentsOfSelectedClientGet(locationAutoId, clientCode);
            return ds;
        }

        /// <summary>
        /// To Get Incident No for Selected Clients By  on 1-Aug-2013
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>dataset</returns>
        public DataSet IncidentNoSelectedClientGet(string clientCode, int locationAutoId)
        {
            DL.OperationManagement objdlOperationManagement = new DL.OperationManagement();
            DataSet ds = objdlOperationManagement.IncidentNoSelectedClientGet(clientCode, locationAutoId);
            return ds;
        }

        //Added by  on 5-May-2014
        /// <summary>
        /// Get all post based on Client, asmt code, location, from and To Date.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BLPOPGetAllPost(string asmtCode, string locationAutoId, string fromDate, string toDate, string clientCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.DLPOPGetAllPost(asmtCode, locationAutoId, fromDate, toDate, clientCode);
            return ds;
        }
        #endregion

        #region Functions Related to Assignment Citation And Recommendations
        /// <summary>
        /// Asmts the citation get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtCitationGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtCitationGet(companyCode);
            return ds;
        }


        /// <summary>
        /// Asmts the citation type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtCitationTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtCitationTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Asmts the citation detail get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="citationNo">The citation no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtCitationDetailGet(string locationAutoId, string citationNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtCitationDetailGet(locationAutoId, citationNo);
            return ds;
        }

        /// <summary>
        /// Citations the delete award details.
        /// </summary>
        /// <param name="citationNo">The citation no.</param>
        /// <param name="awardedTo">The awarded to.</param>
        /// <returns>DataSet.</returns>
        public DataSet CitationDeleteAwardDetails(string citationNo, string awardedTo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CitationDeleteAwardDetails(citationNo, awardedTo);
            return ds;
        }

        /// <summary>
        /// Citations the award details insert.
        /// </summary>
        /// <param name="citationNo">The citation no.</param>
        /// <param name="awardDesc">The award desc.</param>
        /// <param name="awardedTo">The awarded to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CitationAwardDetailsInsert(string citationNo, string awardDesc, string awardedTo, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CitationAwardDetailsInsert(citationNo, awardDesc, awardedTo, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Citations the award details update.
        /// </summary>
        /// <param name="citationNo">The citation no.</param>
        /// <param name="awardDesc">The award desc.</param>
        /// <param name="awardedTo">The awarded to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CitationAwardDetailsUpdate(string citationNo, string awardDesc, string awardedTo, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CitationAwardDetailsUpdate(citationNo, awardDesc, awardedTo, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Citations the header detail insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="citationType">Type of the citation.</param>
        /// <param name="citationDate">The citation date.</param>
        /// <param name="citation">The citation.</param>
        /// <param name="awardedBy">The awarded by.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="awardedOn">The awarded on.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="awardDetails">The award details.</param>
        /// <param name="status">The status.</param>
        /// <param name="user">The user.</param>
        /// <returns>DataSet.</returns>
        public DataSet CitationHeaderDetailInsert(string locationAutoId, string citationType, DateTime citationDate, string citation, string awardedBy, string designation, DateTime awardedOn, string asmtCode, DataTable awardDetails, string status, string user)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CitationHeaderDetailInsert(locationAutoId, citationType, citationDate, citation, awardedBy, designation, awardedOn, asmtCode, awardDetails, status, user);
            return ds;
        }

        /// <summary>
        /// Citations the authorize.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="citationNo">The citation no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CitationAuthorize(string status, string citationNo, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CitationAuthorize(status, citationNo, locationAutoId);
            return ds;
        }

        /// <summary>
        /// Citations the update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="citationNo">The citation no.</param>
        /// <param name="citationType">Type of the citation.</param>
        /// <param name="citationDate">The citation date.</param>
        /// <param name="citation">The citation.</param>
        /// <param name="awardedBy">The awarded by.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="awardedOn">The awarded on.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CitationUpdate(string locationAutoId, string citationNo, string citationType, DateTime citationDate, string citation, string awardedBy, string designation, DateTime awardedOn, string asmtCode, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CitationUpdate(locationAutoId, citationNo, citationType, citationDate, citation, awardedBy, designation, awardedOn, asmtCode, modifiedBy);
            return ds;
        }

        #endregion

        #region Function Related to IncidentMaster
        /// <summary>
        /// To insert Into incidentMaster Gridview
        /// // Modified by  on 21-Mar-2013
        /// </summary>
        /// <param name="reportingDate">The reporting date.</param>
        /// <param name="timeReportingTime">The time reporting time.</param>
        /// <param name="incidentType">Type of the incident.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="reportedBy">The reported by.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="nature">The nature.</param>
        /// <param name="description">The description.</param>
        /// <param name="materialStolen">The material stolen.</param>
        /// <param name="policeInvolved">if set to <c>true</c> [police involved].</param>
        /// <param name="lossClaimValue">The loss claim value.</param>
        /// <param name="PoliceRefNo">The police reference no.</param>
        /// <param name="occurrenceDate">The occurrence date.</param>
        /// <param name="occurrenceTime">The occurrence time.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="supportRequired">The support required.</param>
        /// <param name="messagePassed">The message passed.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">The status.</param>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <returns>DataSet.</returns>
        // Modified by  on 21-Mar-2013 & on 22-May-2013  Updated on 21-Jun-2013
        public DataSet IncidentInsert(DateTime reportingDate, DateTime timeReportingTime, string incidentType, string clientCode, string asmtId, string reportedBy, string designation, string nature, string description, string materialStolen, bool policeInvolved, double lossClaimValue, string PoliceRefNo, DateTime occurrenceDate, DateTime occurrenceTime, string employeeNumber, string supportRequired, DataTable messagePassed, string locationAutoId, string modifiedBy, string status, DataTable dtFileUpload)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentInsert(reportingDate, timeReportingTime, incidentType, clientCode, asmtId, reportedBy, designation, nature, description, materialStolen, policeInvolved, lossClaimValue, PoliceRefNo, occurrenceDate, occurrenceTime, employeeNumber, supportRequired, messagePassed, locationAutoId, modifiedBy, status, dtFileUpload);
            return ds;
        }

        /// <summary>
        /// Incidents the tracking insert.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="incidentTrackDate">The incident track date.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="reportedBy">The reported by.</param>
        /// <param name="reportedDate">The reported date.</param>
        /// <param name="reportedTime">The reported time.</param>
        /// <param name="incidentTrackStatus">The incident track status.</param>
        /// <param name="incidentTrackAction">The incident track action.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentTrackingInsert(string status, DateTime incidentTrackDate, string incidentNo, string reportedBy, DateTime reportedDate, DateTime reportedTime, string incidentTrackStatus, string incidentTrackAction, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentTrackingInsert(status, incidentTrackDate, incidentNo, reportedBy, reportedDate, reportedTime, incidentTrackStatus, incidentTrackAction, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Fill Drop down ddlIncidentType with item desc from quick Code master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentItemDescGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentItemDescGet(companyCode);
            return ds;
        }
        /// <summary>
        /// To fill dropdown ddlNature based on ddlincident type Modified by  on 21-Mar-2013
        /// </summary>
        /// <param name="incidentType">Type of the incident.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        //public DataSet IncidentItemDescGet(int ItemDesc, string companyCode)
        //{
        //    DL.OperationManagement objOperationManagement = new DL.OperationManagement();

        //    DataSet ds = objOperationManagement.IncidentItemDescGet(ItemDesc, companyCode);
        //    return ds;
        //}
        public DataSet IncidentItemDescGet(string incidentType, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentItemDescGet(incidentType, companyCode);
            return ds;
        }

        /// <summary>
        /// To get Details based on Asmt Code and location AutoId
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        /// Modify by  on 20-May-2013
        public DataSet AsmtIncidentDetailGet(string clientCode, string asmtCode, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtIncidentDetailGet(clientCode, asmtCode, locationAutoId);
            return ds;
        }
        /// <summary>
        /// to get assignment details based on asmt code only
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtDetailGetAll(string asmtCode, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtDetailGetAll(asmtCode, companyCode);
            return ds;
        }
        /// <summary>
        /// For Auto Complete textbox [ not working Yet]
        /// </summary>
        /// <param name="prefixText">The prefix text.</param>
        /// <param name="type">The type.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader IncidentNumberGet(String prefixText, string type, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            SqlDataReader drIncidentNo = objOperationManagement.IncidentNumberGet(prefixText, type, locationAutoId);
            return drIncidentNo;
        }
        /// <summary>
        /// To Get details based on Incident number
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentDetailGet(string incidentNo, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentDetailGet(incidentNo, companyCode);
            return ds;
        }
        /// <summary>
        /// Incidents the details get.
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentDetailsGet(string incidentNo, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentDetailsGet(incidentNo, companyCode);
            return ds;
        }        /// <summary>
        /// <summary>
        /// Incidents the delete.
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentDelete(string incidentNo, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentDelete(incidentNo, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To get data in gridvie gvincidentInfo
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentDataGet(string incidentNo, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentDataGet(incidentNo, companyCode);
            return ds;
        }
        /// <summary>
        /// To Update gvIncident Info in Edit mode
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="messageTo">The message to.</param>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="oldMessageTo">The old message to.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentInformationUpdate(string incidentNumber, string messageTo, DateTime date, DateTime time, string modifiedBy, string oldMessageTo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentInformationUpdate(incidentNumber, messageTo, date, time, modifiedBy, oldMessageTo);
            return ds;
        }
        /// <summary>
        /// To Delete Data from gvIncidentInfo
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="messageTo">The message to.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentInformationDelete(string incidentNo, string messageTo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentInformationDelete(incidentNo, messageTo);
            return ds;
        }
        /// <summary>
        /// Incidents the update.
        /// </summary>
        /// <param name="reportingDate">The reporting date.</param>
        /// <param name="timeReportingTime">The time reporting time.</param>
        /// <param name="incidentType">Type of the incident.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="reportedBy">The reported by.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="nature">The nature.</param>
        /// <param name="description">The description.</param>
        /// <param name="materialStolen">The material stolen.</param>
        /// <param name="policeInvolved">if set to <c>true</c> [police involved].</param>
        /// <param name="lossClaimValue">The loss claim value.</param>
        /// <param name="policeRefNo">The police reference no.</param>
        /// <param name="occurrenceDate">The occurrence date.</param>
        /// <param name="occurrenceTime">The occurrence time.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="supportRequired">The support required.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentUpdate(DateTime reportingDate, DateTime timeReportingTime, string incidentType, string clientCode, string asmtId, string reportedBy, string designation, string nature, string description, string materialStolen, bool policeInvolved, double lossClaimValue, string policeRefNo, DateTime occurrenceDate, DateTime occurrenceTime, string employeeNumber, string supportRequired, string locationAutoId, string modifiedBy, string incidentNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentUpdate(reportingDate, timeReportingTime, incidentType, clientCode, asmtId, reportedBy, designation, nature, description, materialStolen, policeInvolved, lossClaimValue, policeRefNo, occurrenceDate, occurrenceTime, employeeNumber, supportRequired, locationAutoId, modifiedBy, incidentNo);
            return ds;
        }

        /// <summary>
        /// Incidents the tracking update.
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="incidentTrackDate">The incident track date.</param>
        /// <param name="reportedBy">The reported by.</param>
        /// <param name="reportedDate">The reported date.</param>
        /// <param name="reportedTime">The reported time.</param>
        /// <param name="incidentTrackStatus">The incident track status.</param>
        /// <param name="incidentTrackAction">The incident track action.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentTrackingUpdate(string incidentNo, DateTime incidentTrackDate, string reportedBy, DateTime reportedDate, DateTime reportedTime, string incidentTrackStatus, string incidentTrackAction, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentTrackingUpdate(incidentNo, incidentTrackDate, reportedBy, reportedDate, reportedTime, incidentTrackStatus, incidentTrackAction, locationAutoId, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To Insert date into gv incident info
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="messageTo">The message to.</param>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentPassedInformationInsert(string incidentNo, string messageTo, DateTime date, DateTime time, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentPassedInformationInsert(incidentNo, messageTo, date, time, modifiedBy);
            return ds;
        }
        ///// <summary>
        ///// To Check If the Assignment belongs to the incidentNo
        ///// </summary>
        ///// <param name="incidentNo"></param>
        ///// <param name="locationAutoId"></param>
        ///// <returns></returns>
        //public DataSet blIncident_CheckAssignment(string incidentNo, string locationAutoId, string asmtCode)
        //{
        //    DL.OperationManagement objOperationManagement = new DL.OperationManagement();
        //    
        //    DataSet ds = objOperationManagement.dlIncident_CheckAssignment(incidentNo, locationAutoId, asmtCode);
        //    return ds;
        //}
        /// <summary>
        /// Function to Authorize
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentAuthorize(string incidentNumber, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentAuthorize(incidentNumber, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Incidents the tracking authorize.
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentTrackingAuthorize(string incidentNumber, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentTrackingAuthorize(incidentNumber, status, locationAutoId, modifiedBy);
            return ds;
        }

        /// <summary>
        /// to Amend
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentAmend(string incidentNumber, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentAmend(incidentNumber, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Incidents the tracking amend.
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentTrackingAmend(string incidentNumber, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentTrackingAmend(incidentNumber, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// to get all meeting number for a particular assignment number
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentGetAll(string asmtCode, string locationAutoId, string companyCode, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentGetAll(asmtCode, locationAutoId, companyCode, status);
            return ds;
        }
        /// <summary>
        /// to get Incident Type based on IncidentNumber
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentTypeGet(string incidentNumber, string locationAutoId, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.IncidentTypeGet(incidentNumber, locationAutoId, companyCode);
            return ds;
        }
        #endregion

        #region Finction Related to Warning And Damage Control
        /// <summary>
        /// Function To Insert
        /// </summary>
        /// <param name="statusChangeDate">The status change date.</param>
        /// <param name="status">The status.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="meetingNo">The meeting no.</param>
        /// <param name="reasonForChange">The reason for change.</param>
        /// <param name="comfortStatus">The comfort status.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="financialImplication">The financial implication.</param>
        /// <param name="briefOfProblem">The brief of problem.</param>
        /// <param name="briefOfResolution">The brief of resolution.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="damageAndWarningStatus">The damage and warning status.</param>
        /// <param name="investigationStatus">The investigation status.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningInsert(DateTime statusChangeDate, string status, string asmtCode, string meetingNo, string reasonForChange, string comfortStatus, string incidentNo, string employeeNumber, string financialImplication, string briefOfProblem, string briefOfResolution, string locationAutoId, string modifiedBy, int amendNo, string damageAndWarningStatus, string investigationStatus)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningInsert(statusChangeDate, status, asmtCode, meetingNo, reasonForChange, comfortStatus, incidentNo, employeeNumber, financialImplication, briefOfProblem, briefOfResolution, locationAutoId, modifiedBy, amendNo, damageAndWarningStatus, investigationStatus);
            return ds;
        }

        /// <summary>
        /// To Check If the Assignment belongs to the MeetingNo
        /// </summary>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningAmendNumberGet(string damageAndWarningControlNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningAmendNumberGet(damageAndWarningControlNo);
            return ds;
        }
        /// <summary>
        /// To Authorize
        /// </summary>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="damageAndWarningStatus">The damage and warning status.</param>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningAuthorize(string modifiedBy, int amendNo, string damageAndWarningStatus, string damageAndWarningControlNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningAuthorize(modifiedBy, amendNo, damageAndWarningStatus, damageAndWarningControlNo);
            return ds;
        }
        /// <summary>
        /// TO AMEND
        /// </summary>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <param name="statusChangeDate">The status change date.</param>
        /// <param name="status">The status.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="meetingNo">The meeting no.</param>
        /// <param name="reasonForChange">The reason for change.</param>
        /// <param name="comfortStatus">The comfort status.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="financialImplication">The financial implication.</param>
        /// <param name="briefOfProblem">The brief of problem.</param>
        /// <param name="briefOfResolution">The brief of resolution.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="damageAndWarningStatus">The damage and warning status.</param>
        /// <param name="amendDate">The amend date.</param>
        /// <param name="investigationStatus">The investigation status.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningAmend(string damageAndWarningControlNo, DateTime statusChangeDate, string status, string asmtCode, string meetingNo, string reasonForChange, string comfortStatus, string incidentNo, string employeeNumber, string financialImplication, string briefOfProblem, string briefOfResolution, string locationAutoId, string modifiedBy, int amendNo, string damageAndWarningStatus, DateTime amendDate, string investigationStatus)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningAmend(damageAndWarningControlNo, statusChangeDate, status, asmtCode, meetingNo, reasonForChange, comfortStatus, incidentNo, employeeNumber, financialImplication, briefOfProblem, briefOfResolution, locationAutoId, modifiedBy, amendNo, damageAndWarningStatus, amendDate, investigationStatus);
            return ds;
        }
        /// <summary>
        /// To Get the MAx Amend Number of WDControlNo
        /// </summary>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningMaximumAmendNumberGet(string damageAndWarningControlNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningMaximumAmendNumberGet(damageAndWarningControlNo);
            return ds;
        }
        /// <summary>
        /// To Fill details Based on AmendNo,WDControlNo
        /// </summary>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningDetailGet(int amendNo, string damageAndWarningControlNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningDetailGet(amendNo, damageAndWarningControlNo);
            return ds;
        }
        /// <summary>
        /// to update data
        /// </summary>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <param name="statusChangeDate">The status change date.</param>
        /// <param name="status">The status.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="meetingNo">The meeting no.</param>
        /// <param name="reasonForChange">The reason for change.</param>
        /// <param name="comfortStatus">The comfort status.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="financialImplication">The financial implication.</param>
        /// <param name="briefOfProblem">The brief of problem.</param>
        /// <param name="briefOfResolution">The brief of resolution.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="damageAndWarningStatus">The damage and warning status.</param>
        /// <param name="amendDate">The amend date.</param>
        /// <param name="investigationStatus">The investigation status.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningUpdate(string damageAndWarningControlNo, DateTime statusChangeDate, string status, string asmtCode, string meetingNo, string reasonForChange, string comfortStatus, string incidentNo, string employeeNumber, string financialImplication, string briefOfProblem, string briefOfResolution, string locationAutoId, string modifiedBy, int amendNo, string damageAndWarningStatus, DateTime amendDate, string investigationStatus)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningUpdate(damageAndWarningControlNo, statusChangeDate, status, asmtCode, meetingNo, reasonForChange, comfortStatus, incidentNo, employeeNumber, financialImplication, briefOfProblem, briefOfResolution, locationAutoId, modifiedBy, amendNo, damageAndWarningStatus, amendDate, investigationStatus);
            return ds;
        }
        /// <summary>
        /// To fill ddlComfortStatus
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningComfortStatusGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningComfortStatusGet(companyCode);
            return ds;
        }
        /// <summary>
        /// To fill ddlGetReason4Change
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ReasonForChangingDamageAndWarningGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.ReasonForChangingDamageAndWarningGet(companyCode);
            return ds;
        }
        /// <summary>
        /// To fill ddlStatus
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningStatusGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.DamageAndWarningStatusGet(companyCode);
            return ds;
        }
        /// <summary>
        /// To check if a meeting is done for the assignment
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingContextGetAll(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingContextGetAll(companyCode);
            return ds;
        }
        /// <summary>
        /// to fill ddlMeeting type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingTypeGetAll(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingTypeGetAll(companyCode);
            return ds;
        }
        /// <summary>
        /// To fill ddl observation type in gridview client meeting in edit mode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ObservationTypeGetAll(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.ObservationTypeGetAll(companyCode);
            return ds;
        }
        ///// <summary>
        ///// To fill ddl observation type in gridview client meeting in footer
        ///// </summary>
        ///// <param name="companyCode"></param>
        ///// <returns></returns>
        //public DataSet blMeeting_GetAllNewddlObservationType(string companyCode)
        //{
        //    DL.OperationManagement objOperationManagement = new DL.OperationManagement();
        //    
        //    DataSet ds = objOperationManagement.dlMeeting_GetAllNewddlObservationType(companyCode);
        //    return ds;
        //}
        /// <summary>
        /// Meetings the detail insert.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="meetingDate">The meeting date.</param>
        /// <param name="informationDetails">The information details.</param>
        /// <param name="informationDate">The information date.</param>
        /// <param name="customerRepresentative">The customer representative.</param>
        /// <param name="context">The context.</param>
        /// <param name="meetingType">Type of the meeting.</param>
        /// <param name="minutesOfMeeting">The minutes of meeting.</param>
        /// <param name="nextActionPlan">The next action plan.</param>
        /// <param name="nextMeetingDate">The next meeting date.</param>
        /// <param name="tableClientMeeting">The table client meeting.</param>
        /// <param name="companyRepresentative">The company representative.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingDetailInsert(string clientCode, string asmtId, string incidentNo, DateTime meetingDate, string informationDetails, DateTime informationDate, string customerRepresentative, string context, string meetingType, string minutesOfMeeting, string nextActionPlan, string nextMeetingDate, DataTable tableClientMeeting, DataTable companyRepresentative, string modifiedBy, string locationAutoId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingDetailInsert(clientCode, asmtId, incidentNo, meetingDate, informationDetails, informationDate, customerRepresentative, context, meetingType, minutesOfMeeting, nextActionPlan, nextMeetingDate, tableClientMeeting, companyRepresentative, modifiedBy, locationAutoId, status);
            return ds;
        }
        /// <summary>
        /// To Fill gvClientMeeting Detail
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMeetingDetailGetAll(string meetingNumber, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.ClientMeetingDetailGetAll(meetingNumber, companyCode);
            return ds;
        }
        /// <summary>
        /// To Fill gv Representative Detail
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CompanyRepresentativeGetAll(string meetingNumber, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CompanyRepresentativeGetAll(meetingNumber, companyCode);
            return ds;
        }
        /// <summary>
        /// For ObservationAuthorize
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingObservationAuthorize(string status, string meetingNumber, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingObservationAuthorize(status, meetingNumber, locationAutoId);
            return ds;
        }
        /// <summary>
        /// For Plan Authorize
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingPlanAuthorize(string status, string meetingNumber, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingPlanAuthorize(status, meetingNumber, locationAutoId);
            return ds;
        }
        /// <summary>
        /// For Action Authorize
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingActionAuthorize(string status, string meetingNumber, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingActionAuthorize(status, meetingNumber, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Check Wheather Plan Authorization details are entered or not before plan authorizing it
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingCheckPlanAuthorize(string meetingNumber, string locationAutoId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingCheckPlanAuthorize(meetingNumber, locationAutoId, status);
            return ds;
        }
        /// <summary>
        /// To insert Data in gv Representative
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CompanyRepresentativeInsert(string meetingNumber, string employeeNumber, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CompanyRepresentativeInsert(meetingNumber, employeeNumber, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To update Data in gv Representative
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="oldEmployeeNumber">The old employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet CompanyRepresentativeUpdate(string meetingNumber, string employeeNumber, string modifiedBy, string oldEmployeeNumber)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CompanyRepresentativeUpdate(meetingNumber, employeeNumber, modifiedBy, oldEmployeeNumber);
            return ds;
        }
        /// <summary>
        /// To Add Data in gv Client Detail
        /// </summary>
        /// <param name="observationType">Type of the observation.</param>
        /// <param name="observation">The observation.</param>
        /// <param name="correctiveMeasures">The corrective measures.</param>
        /// <param name="promisedDate">The promised date.</param>
        /// <param name="actionPlanned">The action planned.</param>
        /// <param name="responsibility">The responsibility.</param>
        /// <param name="actionDate">The action date.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailInsert(string observationType, string observation, string correctiveMeasures, DateTime promisedDate, string actionPlanned, string responsibility, string actionDate, string remarks, string modifiedBy, string meetingNumber)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.ClientDetailInsert(observationType, observation, correctiveMeasures, promisedDate, actionPlanned, responsibility, actionDate, remarks, modifiedBy, meetingNumber);
            return ds;
        }
        /// <summary>
        /// to delete from gv Representative
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet CompanyRepresentativeDelete(string meetingNumber, string employeeNumber)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CompanyRepresentativeDelete(meetingNumber, employeeNumber);
            return ds;
        }
        /// <summary>
        /// Meetings the detail update.
        /// </summary>
        /// <param name="meetingNo">The meeting no.</param>
        /// <param name="customerRepresentative">The customer representative.</param>
        /// <param name="context">The context.</param>
        /// <param name="minutesOfMeeting">The minutes of meeting.</param>
        /// <param name="nextActionPlan">The next action plan.</param>
        /// <param name="nextMeetingDate">The next meeting date.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingDetailUpdate(string meetingNo, string customerRepresentative, string context, string minutesOfMeeting, string nextActionPlan, string nextMeetingDate, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingDetailUpdate(meetingNo, customerRepresentative, context, minutesOfMeeting, nextActionPlan, nextMeetingDate, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To update gv ClientDetail
        /// </summary>
        /// <param name="observationType">Type of the observation.</param>
        /// <param name="observation">The observation.</param>
        /// <param name="correctiveMeasures">The corrective measures.</param>
        /// <param name="promisedDate">The promised date.</param>
        /// <param name="actionPlanned">The action planned.</param>
        /// <param name="responsibility">The responsibility.</param>
        /// <param name="actionDate">The action date.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMeetingDetailUpdate(string observationType, string observation, string correctiveMeasures, DateTime promisedDate, string actionPlanned, string responsibility, string actionDate, string remarks, string modifiedBy, string meetingNumber, int rowId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.ClientMeetingDetailUpdate(observationType, observation, correctiveMeasures, promisedDate, actionPlanned, responsibility, actionDate, remarks, modifiedBy, meetingNumber, rowId);
            return ds;
        }
        /// <summary>
        /// To Delete from
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMeetingDetailDelete(string rowId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.ClientMeetingDetailDelete(rowId);
            return ds;
        }
        /// <summary>
        /// to GEt all details
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingDetailGet(string meetingNumber, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingDetailGet(meetingNumber, locationAutoId);
            return ds;
        }
        /// <summary>
        /// to get all meeting number for a particular assignment number
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingNumberGet(string asmtCode, string locationAutoId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MeetingNumberGet(asmtCode, locationAutoId, status);
            return ds;
        }
        #endregion

        #region Function Related To Night Check Visit Detail
        /// <summary>
        /// Function to fill ddl check visit type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Function to fill ddl Observation Type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitObservationTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitObservationTypeGet(companyCode);
            return ds;
        }
        /// <summary>
        /// to insert data
        /// </summary>
        /// <param name="checkVisitType">Type of the check visit.</param>
        /// <param name="status">The status.</param>
        /// <param name="date">The date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="nightCheckDetail">The night check detail.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitInsert(string checkVisitType, string status, DateTime date, string timeFrom, string timeTo, string conductedBy, DataTable nightCheckDetail, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitInsert(checkVisitType, status, date, timeFrom, timeTo, conductedBy, nightCheckDetail, locationAutoId, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To get all data into gv night check detail after save
        /// </summary>
        /// <param name="nightCheckVisit">The night check visit.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitDetailGetAll(string nightCheckVisit)//, string companyCode, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitDetailGetAll(nightCheckVisit);//, companyCode, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Insert into gv Night check after saving all data
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="checkVisitNumber">The check visit number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="newTimeTo">The new time to.</param>
        /// <param name="observationType">Type of the observation.</param>
        /// <param name="observation">The observation.</param>
        /// <param name="actionStatus">The action status.</param>
        /// <param name="checkVisitActionNo">The check visit action no.</param>
        /// <returns>DataSet.</returns>
        //Modify by  on 2-Jun-2013
        public DataSet NightCheckVisitDetailInsert(string employeeNumber, string clientCode, string asmtId, string checkVisitNumber, string modifiedBy, string timeFrom, string newTimeTo, string observationType, string observation, string actionStatus, string checkVisitActionNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitDetailInsert(employeeNumber, clientCode, asmtId, checkVisitNumber, modifiedBy, timeFrom, newTimeTo, observationType, observation, actionStatus, checkVisitActionNo);
            return ds;
        }
        /// <summary>
        /// To update record in gridview
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="checkVisitNumber">The check visit number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="newTimeTo">The new time to.</param>
        /// <param name="observationType">Type of the observation.</param>
        /// <param name="observation">The observation.</param>
        /// <param name="actionStatus">The action status.</param>
        /// <param name="checkVisitActionNo">The check visit action no.</param>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        //Modify by  on 23-May-2013
        public DataSet NightCheckVisitDetailUpdate(string employeeNumber, string clientCode, string asmtId, string checkVisitNumber, string modifiedBy, string timeFrom, string newTimeTo, string observationType, string observation, string actionStatus, string checkVisitActionNo, string rowId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitDetailUpdate(employeeNumber, clientCode, asmtId, checkVisitNumber, modifiedBy, timeFrom, newTimeTo, observationType, observation, actionStatus, checkVisitActionNo, rowId);
            return ds;
        }
        /// <summary>
        /// to delete from gridview
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitDetailDelete(string rowId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitDetailDelete(rowId);
            return ds;
        }
        /// <summary>
        /// to authorize
        /// </summary>
        /// <param name="nightCheckNumber">The night check number.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitAuthorize(string nightCheckNumber, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitAuthorize(nightCheckNumber, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Get All Details
        /// </summary>
        /// <param name="nightCheckVisitNumber">The night check visit number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitGetAll(string nightCheckVisitNumber, string locationAutoId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitGetAll(nightCheckVisitNumber, locationAutoId, status);
            return ds;
        }
        /// <summary>
        /// To Update date of header
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="nightCheckNo">The night check no.</param>
        /// <param name="checkVisitType">Type of the check visit.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitUpdate(DateTime date, string timeFrom, string timeTo, string conductedBy, string locationAutoId, string modifiedBy, string nightCheckNo, string checkVisitType)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitUpdate(date, timeFrom, timeTo, conductedBy, locationAutoId, modifiedBy, nightCheckNo, checkVisitType);
            return ds;
        }
        /// <summary>
        /// To Update Action status On Authorize button Click
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionStatusUpdate(string rowId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionStatusUpdate(rowId, status);
            return ds;
        }
        /// <summary>
        /// to amend records
        /// </summary>
        /// <param name="nightCheckNumber">The night check number.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitAmend(string nightCheckNumber, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitAmend(nightCheckNumber, status, locationAutoId, modifiedBy);
            return ds;
        }
        #endregion

        #region Function related to Night Check Visit Action
        /// <summary>
        /// To Check if the asmt code belong to night check visit number
        /// </summary>
        /// <param name="nightCheckVisitNumber">The night check visit number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckAsmtForNightCheckAndVisit(string nightCheckVisitNumber, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.CheckAsmtForNightCheckAndVisit(nightCheckVisitNumber, locationAutoId);
            return ds;
        }
        /// <summary>
        /// to get all details of gridview
        /// </summary>
        /// <param name="checkVisitNumber">The check visit number.</param>
        /// <param name="status">The status.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        //Modify by  on 31-May-2013
        public DataSet NightCheckVisitActionGetAll(string checkVisitNumber, string status, string clientCode, string asmtId, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionGetAll(checkVisitNumber, status, clientCode, asmtId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// to get all details of gridview based on Check_Visit_Action_No
        /// </summary>
        /// <param name="checkVisitActionNumber">The check visit action number.</param>
        /// <param name="checkVisitNumber">The check visit number.</param>
        /// <param name="status">The status.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        //Added by  on 1-Jun-2013
        public DataSet NightCheckVisitActionDetailGetAll(string checkVisitActionNumber, string checkVisitNumber, string status, string clientCode, string asmtId, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionDetailGetAll(checkVisitActionNumber, checkVisitNumber, status, clientCode, asmtId, locationAutoId);
            return ds;
        }
        /// <summary>
        /// to get the details after save
        /// </summary>
        /// <param name="checkVisitActionNumber">The check visit action number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionDetailGet(string checkVisitActionNumber, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionDetailGet(checkVisitActionNumber, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Save data on button save click
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="checkVisitNumber">The check visit number.</param>
        /// <param name="nightCheckVisitAction">The night check visit action.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">The status.</param>
        /// <param name="date">The date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        //Modify by  on 31-May-2013
        public DataSet NightCheckVisitActionInsert(string companyCode, string hrLocationCode, string locationCode, string checkVisitNumber, DataTable nightCheckVisitAction, string modifiedBy, string status, DateTime date, string clientCode, string asmtId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionInsert(companyCode, hrLocationCode, locationCode, checkVisitNumber, nightCheckVisitAction, modifiedBy, status, date, clientCode, asmtId);
            return ds;
        }
        /// <summary>
        /// To check
        /// </summary>
        /// <param name="nightCheckVisitNumber">The night check visit number.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionCheckForNightCheckVisitNumber(string nightCheckVisitNumber, string asmtCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionCheckForNightCheckVisitNumber(nightCheckVisitNumber, asmtCode);
            return ds;
        }
        /// <summary>
        /// To update
        /// </summary>
        /// <param name="autoId">The automatic identifier.</param>
        /// <param name="actionPlanned">The action planned.</param>
        /// <param name="responsibility">The responsibility.</param>
        /// <param name="actionDate">The action date.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="date">The date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckActionDetailUpdate(string autoId, string actionPlanned, string responsibility, string actionDate, string remarks, DateTime date, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckActionDetailUpdate(autoId, actionPlanned, responsibility, actionDate, remarks, date, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update All data on update button click
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="checkVisitActionNo">The check visit action no.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionUpdate(DateTime date, string modifiedBy, string checkVisitActionNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionUpdate(date, modifiedBy, checkVisitActionNo);
            return ds;
        }
        /// <summary>
        /// For PlanAuthorize
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="checkVisitActionNumber">The check visit action number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionPlanAuthorize(string status, string checkVisitActionNumber, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionPlanAuthorize(status, checkVisitActionNumber, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Action Authorize
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="checkVisitActionNumber">The check visit action number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="rowId">The row identifier.</param>
        /// <param name="actionStatus">The action status.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionAuthorize(string status, string checkVisitActionNumber, string modifiedBy, int rowId, string actionStatus)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionAuthorize(status, checkVisitActionNumber, modifiedBy, rowId, actionStatus);
            return ds;
        }

        /// <summary>
        /// Nights the check visit action detail get.
        /// </summary>
        /// <param name="checkVisitActionNumber">The check visit action number.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionDetailGet(string checkVisitActionNumber)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.NightCheckVisitActionDetailGet(checkVisitActionNumber);
            return ds;
        }
        /// <summary>
        /// To Get All Asmt Code of Night check visit number
        /// </summary>
        /// <param name="checkVisitNumber">The check visit number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtCodeForNightCheckVisitGetAll(string checkVisitNumber, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtCodeForNightCheckVisitGetAll(checkVisitNumber, locationAutoId);
            return ds;
        }
        #endregion

        #region Functions Related to Assignment Training Screen

        /// <summary>
        /// Asmts the training detail get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="trainingNo">The training no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtTrainingDetailGet(string locationAutoId, string trainingNo)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AsmtTrainingDetailGet(locationAutoId, trainingNo);
            return ds;
        }

        /// <summary>
        /// Trainings the details delete.
        /// </summary>
        /// <param name="trainingNo">The training no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingDetailsDelete(string trainingNo, string employeeNumber, string conductedBy)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.TrainingDetailsDelete(trainingNo, employeeNumber, conductedBy);
            return ds;
        }

        /// <summary>
        /// Trainings the details insert.
        /// </summary>
        /// <param name="trainingNo">The training no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="areasCovered">The areas covered.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="hours">The hours.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingDetailsInsert(string trainingNo, string employeeNumber, string conductedBy, string areasCovered, DateTime trainingDate, DateTime timeFrom, DateTime timeTo, string hours, string remarks, string modifiedBy)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.TrainingDetailsInsert(trainingNo, employeeNumber, conductedBy, areasCovered, trainingDate, timeFrom, timeTo, hours, remarks, modifiedBy);
            return ds;

        }

        /// <summary>
        /// Trainings the details update.
        /// </summary>
        /// <param name="trainingNo">The training no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="areasCovered">The areas covered.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="hours">The hours.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingDetailsUpdate(string trainingNo, string employeeNumber, string conductedBy, string areasCovered, DateTime trainingDate, DateTime timeFrom, DateTime timeTo, string hours, string remarks, string modifiedBy)
        {

            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.TrainingDetailsUpdate(trainingNo, employeeNumber, conductedBy, areasCovered, trainingDate, timeFrom, timeTo, hours, remarks, modifiedBy);
            return ds;

        }

        /// <summary>
        /// Assignments the training type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentTrainingTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AssignmentTrainingTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Trainings the update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="trainingNo">The training no.</param>
        /// <param name="trainingType">Type of the training.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingUpdate(string locationAutoId, string trainingNo, string trainingType, DateTime trainingDate, string asmtCode, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.TrainingUpdate(locationAutoId, trainingNo, trainingType, trainingDate, asmtCode, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Trainings the authorize.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="trainingNo">The training no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingAuthorize(string status, string trainingNo, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.TrainingAuthorize(status, trainingNo, locationAutoId);
            return ds;
        }

        /// <summary>
        /// Trainings the detail insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="trainingType">Type of the training.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="trainingDetails">The training details.</param>
        /// <param name="status">The status.</param>
        /// <param name="user">The user.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingDetailInsert(string locationAutoId, string trainingType, DateTime trainingDate, string asmtCode, DataTable trainingDetails, string status, string user)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.TrainingDetailInsert(locationAutoId, trainingType, trainingDate, asmtCode, trainingDetails, status, user);
            return ds;
        }

        #endregion

        #region Function Related to InvestigationRequest
        /// <summary>
        /// Investigations the reason get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationReasonGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationReasonGet(companyCode);
            return ds;
        }

        //Modify by  on 25-Jun-2013
        /// <summary>
        /// Investigations the request insert.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="investigationRequest">The investigation request.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="investigationStatusId">The investigation status identifier.</param>
        /// <param name="investigationReason">The investigation reason.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="details">The details.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationRequestInsert(string status, DateTime investigationRequest, string incidentNo, int investigationStatusId, int investigationReason, string employeeNumber, string details, string locationAutoId, string modifiedBy, DataTable dtFileUpload)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationRequestInsert(status, investigationRequest, incidentNo, investigationStatusId, investigationReason, employeeNumber, details, locationAutoId, modifiedBy, dtFileUpload);
            return ds;
        }
        /// <summary>
        /// Investigations the detail get.
        /// </summary>
        /// <param name="investigationNo">The investigation no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailGet(string investigationNo, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationDetailGet(investigationNo, companyCode);
            return ds;
        }

        /// <summary>
        /// Investigations the details get.
        /// </summary>
        /// <param name="investigationNo">The investigation no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailsGet(string investigationNo, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationDetailsGet(investigationNo, locationAutoId);
            return ds;
        }

        /// <summary>
        /// Investigations the details get all.
        /// </summary>
        /// <param name="investigationNo">The investigation no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailsGetAll(string investigationNo, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationDetailsGetAll(investigationNo, companyCode);
            return ds;
        }
        /// <summary>
        /// Investigations the request update.
        /// </summary>
        /// <param name="investigationDate">The investigation date.</param>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="status">The status.</param>
        /// <param name="investigationRequest">The investigation request.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="investigationStatusId">The investigation status identifier.</param>
        /// <param name="investigationReason">The investigation reason.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="details">The details.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationRequestUpdate(string investigationDate, string investigationRequestNo, string status, DateTime investigationRequest, string incidentNo, int investigationStatusId, int investigationReason, string employeeNumber, string details, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationRequestUpdate(investigationDate, investigationRequestNo, status, investigationRequest, incidentNo, investigationStatusId, investigationReason, employeeNumber, details, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Investigations the detail update.
        /// </summary>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="status">The status.</param>
        /// <param name="investigationDate">The investigation date.</param>
        /// <param name="legalAssistance">The legal assistance.</param>
        /// <param name="companyInvolved">The company involved.</param>
        /// <param name="customerInvolved">The customer involved.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="findings">The findings.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailUpdate(string investigationRequestNo, string status, DateTime investigationDate, int legalAssistance, int companyInvolved, int customerInvolved, string employeeNumber, string findings, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationDetailUpdate(investigationRequestNo, status, investigationDate, legalAssistance, companyInvolved, customerInvolved, employeeNumber, findings, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Investigations the detail authorize.
        /// </summary>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailAuthorize(string investigationRequestNo, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationDetailAuthorize(investigationRequestNo, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Investigations the details authorize.
        /// </summary>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailsAuthorize(string investigationRequestNo, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationDetailsAuthorize(investigationRequestNo, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Investigations the detail amend.
        /// </summary>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailAmend(string investigationRequestNo, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationDetailAmend(investigationRequestNo, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Investigations the details amend.
        /// </summary>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailsAmend(string investigationRequestNo, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationDetailsAmend(investigationRequestNo, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Get Investigation status based on incident number
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationStatusGet(string incidentNumber, string locationAutoId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.InvestigationStatusGet(incidentNumber, locationAutoId, status);
            return ds;
        }
        #endregion

        #region Function Related to Site Instruction
        #region Function Related to get data
        /// <summary>
        /// Sites the instruction get all.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionGetAll(string siteInstructionNo)
        {
            DL.OperationManagement objOPS = new DL.OperationManagement();

            DataSet ds = objOPS.SiteInstructionGetAll(siteInstructionNo);
            return ds;
        }
        /// <summary>
        /// Sites the instruction number get.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionNumberGet(string siteInstructionNo, int locationAutoId)
        {
            DL.OperationManagement objOPS = new DL.OperationManagement();

            DataSet ds = objOPS.SiteInstructionNumberGet(siteInstructionNo, locationAutoId);
            return ds;
        }
        #endregion
        #region Function Related to Insert Data
        //Modify by  on 22-May-2013 and 24-Jun-2013
        /// <summary>
        /// Sites the instruction insert.
        /// </summary>
        /// <param name="instructionDate">The instruction date.</param>
        /// <param name="nextRevisionDate">The next revision date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="prepared">The prepared.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="clientSignature">The client signature.</param>
        /// <param name="signatureDate">The signature date.</param>
        /// <param name="clientRepresentative">The client representative.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="reasonNotSign">The reason not sign.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionInsert(DateTime instructionDate, DateTime nextRevisionDate, string clientCode, string asmtId, string employeeNumber, DateTime prepared, int reason, int clientSignature, DateTime signatureDate, string clientRepresentative, string designation, string reasonNotSign, DataTable siteInstruction, string userId, int locationAutoId, string status, DataTable dtFileUpload)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionInsert(instructionDate, nextRevisionDate, clientCode, asmtId, employeeNumber, prepared, reason, clientSignature, signatureDate, clientRepresentative, designation, reasonNotSign, siteInstruction, userId, locationAutoId, status, dtFileUpload);
            return ds;
        }

        /// <summary>
        /// Sites the instruction bulk insert.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionBulkInsert(string siteInstructionNo, DataTable siteInstruction, string userId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionBulkInsert(siteInstructionNo, siteInstruction, userId);
            return ds;
        }

        //Modify By  on 18-Mar-2013
        //public DataSet SiteInstructionDetailInsert(String siteInstructionNo, int siteInstructionTypeId, string siteInstruction, string userId)
        //{
        //    DL.OperationManagement objOperationManagement = new DL.OperationManagement();

        //    DataSet ds = objOperationManagement.SiteInstructionDetailInsert(siteInstructionNo, siteInstructionTypeId, siteInstruction, userId);
        //    return ds;
        //}

        /// <summary>
        /// Sites the instruction detail insert.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <param name="siteInstructionTypeId">The site instruction type identifier.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionDetailInsert(String siteInstructionNo, string siteInstructionTypeId, string siteInstruction, string userId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionDetailInsert(siteInstructionNo, siteInstructionTypeId, siteInstruction, userId);
            return ds;
        }
        #endregion
        #region Function Related to Update Data
        //Modify by  on 22-May-2013
        /// <summary>
        /// Sites the instruction update.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <param name="instructionDate">The instruction date.</param>
        /// <param name="nextRevisionDate">The next revision date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="prepared">The prepared.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="clientSignature">The client signature.</param>
        /// <param name="signatureDate">The signature date.</param>
        /// <param name="clientRepresentative">The client representative.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="reasonNotSign">The reason not sign.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionUpdate(string siteInstructionNo, DateTime instructionDate, DateTime nextRevisionDate, string clientCode, string asmtId, string employeeNumber, DateTime prepared, int reason, int clientSignature, DateTime signatureDate, string clientRepresentative, string designation, string reasonNotSign, string userId, int locationAutoId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionUpdate(siteInstructionNo, instructionDate, nextRevisionDate, clientCode, asmtId, employeeNumber, prepared, reason, clientSignature, signatureDate, clientRepresentative, designation, reasonNotSign, userId, locationAutoId, status);
            return ds;
        }
        /// <summary>
        /// Sites the instruction detail update.
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <param name="instructionTypeId">The instruction type identifier.</param>
        /// <param name="instruction">The instruction.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionDetailUpdate(int rowId, string siteInstructionNo, int instructionTypeId, string instruction, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionDetailUpdate(rowId, siteInstructionNo, instructionTypeId, instruction, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Sites the instruction authorize.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionAuthorize(string siteInstructionNo, string modifiedBy, int locationAutoId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionAuthorize(siteInstructionNo, modifiedBy, locationAutoId, status);
            return ds;
        }
        /// <summary>
        /// Sites the instruction amend.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionAmend(string siteInstructionNo, string modifiedBy, int locationAutoId, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionAmend(siteInstructionNo, modifiedBy, locationAutoId, status);
            return ds;
        }


        #endregion
        #region Function Related to Delete Data
        /// <summary>
        /// Sites the instruction detail delete.
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionDetailDelete(int rowId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionDetailDelete(rowId);
            return ds;
        }
        /// <summary>
        /// Sites the instruction detail bulk delete.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionDetailBulkDelete(string siteInstructionNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SiteInstructionDetailBulkDelete(siteInstructionNo);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related To ManPower Selection Process

        /// <summary>
        /// Addresses the get.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AddressGet(string employeeNumber, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AddressGet(employeeNumber, companyCode);
            return ds;
        }

        /// <summary>
        /// Sales the order line detail get.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderLineDetailGet(string soNo, string soLineNo, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SaleOrderLineDetailGet(soNo, soLineNo, companyCode);
            return ds;
        }

        /// <summary>
        /// Soes the line skills get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SoLineSkillsGet(string locationAutoId, string soNo, int soLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SoLineSkillsGet(locationAutoId, soNo, soLineNo);
            return ds;
        }

        /// <summary>
        /// MPSs the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// MPSs the deployment type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsDeploymentTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsDeploymentTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// MPSs the status get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsStatusGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsStatusGet(companyCode);
            return ds;
        }

        /// <summary>
        /// MPSs the reason for removal get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsReasonForRemovalGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsReasonForRemovalGet(companyCode);
            return ds;
        }

        /// <summary>
        /// MPSs the footer lines get.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsFooterLinesGet(string asmtCode, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsFooterLinesGet(asmtCode, companyCode);
            return ds;
        }

        /// <summary>
        /// MPSs the details get.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsDetailsGet(string mpsNo, string mpsAmendNo, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsDetailsGet(mpsNo, mpsAmendNo, companyCode);
            return ds;
        }

        /// <summary>
        /// MPSs the header insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="mpsType">Type of the MPS.</param>
        /// <param name="dateOfCreation">The date of creation.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="amendmentDate">The amendment date.</param>
        /// <param name="amendBy">The amend by.</param>
        /// <param name="status">The status.</param>
        /// <param name="mpsDetails">The MPS details.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsHeaderInsert(string locationAutoId, string mpsType, DateTime dateOfCreation, string asmtCode, string mpsAmendNo, string amendmentDate, string amendBy, string status, DataTable mpsDetails, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsHeaderInsert(locationAutoId, mpsType, dateOfCreation, asmtCode, mpsAmendNo, amendmentDate, amendBy, status, mpsDetails, modifiedBy);
            return ds;
        }

        /// <summary>
        /// MPSs the detail get.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsDetailGet(string mpsNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsDetailGet(mpsNo);
            return ds;
        }

        /// <summary>
        /// MPSs the details get.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsDetailsGet(string mpsNo, string mpsAmendNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsDetailsGet(mpsNo, mpsAmendNo);
            return ds;
        }

        /// <summary>
        /// MPSs the footer detail insert.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="mpsLineNo">The MPS line no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="deploymentType">Type of the deployment.</param>
        /// <param name="introductionDate">The introduction date.</param>
        /// <param name="introducedBy">The introduced by.</param>
        /// <param name="interviewedBy">The interviewed by.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="result">The result.</param>
        /// <param name="interviewRemarks">The interview remarks.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="deploymentDate">The deployment date.</param>
        /// <param name="deploymentTime">The deployment time.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="toTime">To time.</param>
        /// <param name="removalDate">The removal date.</param>
        /// <param name="reasonForRemoval">The reason for removal.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsFooterDetailInsert(string mpsNo, int mpsAmendNo, int mpsLineNo, string employeeNumber, int deploymentType, string introductionDate, string introducedBy, string interviewedBy, string designation, Boolean result, string interviewRemarks, string soNo, int soLineNo, int pdLineNo, string deploymentDate, string deploymentTime, string toDate, string toTime, string removalDate, int reasonForRemoval, string remarks, int status, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsFooterDetailInsert(mpsNo, mpsAmendNo, mpsLineNo, employeeNumber, deploymentType, introductionDate, introducedBy, interviewedBy, designation, result, interviewRemarks, soNo, soLineNo, pdLineNo, deploymentDate, deploymentTime, toDate, toTime, removalDate, reasonForRemoval, remarks, status, modifiedBy);
            return ds;
        }

        /// <summary>
        /// MPSs the authorize.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNO">The MPS amend no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsAuthorize(string mpsNo, string mpsAmendNO, string locationAutoId, string asmtCode, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsAuthorize(mpsNo, mpsAmendNO, locationAutoId, asmtCode, companyCode);
            return ds;
        }

        /// <summary>
        /// MPSs the amend.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="amendBy">The amend by.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsAmend(string mpsNo, string locationAutoId, string amendBy, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsAmend(mpsNo, locationAutoId, amendBy, modifiedBy);
            return ds;
        }

        /// <summary>
        /// MPSs the terminate.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNO">The MPS amend no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="terminatedBy">The terminated by.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsTerminate(string mpsNo, string mpsAmendNO, string locationAutoId, string terminatedBy, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsTerminate(mpsNo, mpsAmendNO, locationAutoId, terminatedBy, modifiedBy);
            return ds;
        }

        /// <summary>
        /// MPSs the maximum amend number get.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsMaximumAmendNumberGet(string mpsNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsMaximumAmendNumberGet(mpsNo);
            return ds;
        }

        /// <summary>
        /// MPSs the footer line get.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsFooterLineGet(string mpsNo, string mpsAmendNo, string companyCode, string soNo, string soLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsFooterLineGet(mpsNo, mpsAmendNo, companyCode, soNo, soLineNo);
            return ds;
        }

        /// <summary>
        /// MPSs the footer detail insert.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="deploymentType">Type of the deployment.</param>
        /// <param name="introductionDate">The introduction date.</param>
        /// <param name="introducedBy">The introduced by.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsFooterDetailInsert(string mpsNo, string mpsAmendNo, string employeeNumber, string deploymentType, string introductionDate, string introducedBy, string soNo, string soLineNo, string pdLineNo, string status, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsFooterDetailInsert(mpsNo, mpsAmendNo, employeeNumber, deploymentType, introductionDate, introducedBy, soNo, soLineNo, pdLineNo, status, modifiedBy);
            return ds;
        }

        /// <summary>
        /// MPSs the move detail insert.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="mpsLineNo">The MPS line no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="deploymentType">Type of the deployment.</param>
        /// <param name="introductionDate">The introduction date.</param>
        /// <param name="introducedBy">The introduced by.</param>
        /// <param name="status">The status.</param>
        /// <param name="introAuthorizedStatus">The intro authorized status.</param>
        /// <param name="resultAuthorizedId">The result authorized identifier.</param>
        /// <param name="resultAuthorizedStatus">The result authorized status.</param>
        /// <param name="removalAuthorizedId">The removal authorized identifier.</param>
        /// <param name="removalAuthorizedStatus">The removal authorized status.</param>
        /// <param name="reasonForRemoval">The reason for removal.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsMoveDetailInsert(string mpsNo, string mpsAmendNo, string mpsLineNo, string employeeNumber, string deploymentType, string introductionDate, string introducedBy, string status, string introAuthorizedStatus, string resultAuthorizedId, string resultAuthorizedStatus, string removalAuthorizedId, string removalAuthorizedStatus, string reasonForRemoval, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsMoveDetailInsert(mpsNo, mpsAmendNo, mpsLineNo, employeeNumber, deploymentType, introductionDate, introducedBy, status, introAuthorizedStatus, resultAuthorizedId, resultAuthorizedStatus, removalAuthorizedId, removalAuthorizedStatus, reasonForRemoval, modifiedBy);
            return ds;

        }

        /// <summary>
        /// MPSs the footer move detail insert.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="deploymentType">Type of the deployment.</param>
        /// <param name="introductionDate">The introduction date.</param>
        /// <param name="introducedBy">The introduced by.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsFooterMoveDetailInsert(string mpsNo, string mpsAmendNo, string employeeNumber, string deploymentType, string introductionDate, string introducedBy, string soNo, string soLineNo, string pdLineNo, string status, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.MpsFooterMoveDetailInsert(mpsNo, mpsAmendNo, employeeNumber, deploymentType, introductionDate, introducedBy, soNo, soLineNo, pdLineNo, status, modifiedBy);
            return ds;
        }
        #endregion

        #region Function Related to Security Design And Review

        /// <summary>
        /// To get All Observation Details in the gridview based on the Design number
        /// </summary>
        /// <param name="designChangeNumber">The design change number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewObservationDetailGetAll(string designChangeNumber, string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewObservationDetailGetAll(designChangeNumber, companyCode);
            return ds;
        }
        /// <summary>
        /// to fill ddl Sensitivity
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewSensitivityGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewSensitivityGet(companyCode);
            return ds;
        }

        /// <summary>
        /// to fill ddl Design Type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewTypeGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewTypeGet(companyCode);
            return ds;
        }
        /// <summary>
        /// to fill ddl reason for review
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewReasonGet(string companyCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewReasonGet(companyCode);
            return ds;
        }
        /// <summary>
        /// To Insert Details in geridview after saving data to database
        /// </summary>
        /// <param name="designChangeNumber">The design change number.</param>
        /// <param name="observation">The observation.</param>
        /// <param name="recommendation">The recommendation.</param>
        /// <param name="sensitivity">The sensitivity.</param>
        /// <param name="implementationDate">The implementation date.</param>
        /// <param name="reasonForPending">The reason for pending.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewObservationDetailInsert(string designChangeNumber, string observation, string recommendation, string sensitivity, string implementationDate, string reasonForPending, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewObservationDetailInsert(designChangeNumber, observation, recommendation, sensitivity, implementationDate, reasonForPending, modifiedBy);
            return ds;
        }

        /// <summary>
        /// To delete data from gridview after save
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewObservationDetailDelete(string rowId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewObservationDetailDelete(rowId);
            return ds;
        }
        /// <summary>
        /// to insert data
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="status">The status.</param>
        /// <param name="dateOfReport">The date of report.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="designType">Type of the design.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="reasonForReview">The reason for review.</param>
        /// <param name="observationDetail">The observation detail.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <returns>DataSet.</returns>
        //Modify By  on 30-May-2013 and 25-Jun-2013
        public DataSet SecurityDesignReviewInsert(DateTime date, string status, DateTime dateOfReport, string clientCode, string asmtId, string designType, string conductedBy, string reasonForReview, DataTable observationDetail, string locationAutoId, string modifiedBy, DataTable dtFileUpload)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewInsert(date, status, dateOfReport, clientCode, asmtId, designType, conductedBy, reasonForReview, observationDetail, locationAutoId, modifiedBy, dtFileUpload);
            return ds;
        }
        /// <summary>
        /// To Update data
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="dateOfReport">The date of report.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="reasonForReview">The reason for review.</param>
        /// <param name="designChangeNumber">The design change number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="designType">Type of the design.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewUpdate(DateTime date, DateTime dateOfReport, string conductedBy, string reasonForReview, string designChangeNumber, string locationAutoId, string modifiedBy, string designType)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewUpdate(date, dateOfReport, conductedBy, reasonForReview, designChangeNumber, locationAutoId, modifiedBy, designType);
            return ds;
        }
        /// <summary>
        /// to update data in GridView observation
        /// </summary>
        /// <param name="observation">The observation.</param>
        /// <param name="recommendation">The recommendation.</param>
        /// <param name="sensitivity">The sensitivity.</param>
        /// <param name="implementationDate">The implementation date.</param>
        /// <param name="reasonForPending">The reason for pending.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewObservationDetailUpdate(string observation, string recommendation, string sensitivity, string implementationDate, string reasonForPending, string modifiedBy, string rowId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewObservationDetailUpdate(observation, recommendation, sensitivity, implementationDate, reasonForPending, modifiedBy, rowId);
            return ds;
        }
        /// <summary>
        /// To Observation Authorize
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="dateOfReport">The date of report.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="reasonForReview">The reason for review.</param>
        /// <param name="designChangeNumber">The design change number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewObservationAuthorize(DateTime date, DateTime dateOfReport, string conductedBy, string reasonForReview, string designChangeNumber, string locationAutoId, string modifiedBy, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewObservationAuthorize(date, dateOfReport, conductedBy, reasonForReview, designChangeNumber, locationAutoId, modifiedBy, status);
            return ds;
        }
        /// <summary>
        /// to Action Authorize
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="dateOfReport">The date of report.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="reasonForReview">The reason for review.</param>
        /// <param name="designChangeNumber">The design change number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewActionAuthorize(DateTime date, DateTime dateOfReport, string conductedBy, string reasonForReview, string designChangeNumber, string locationAutoId, string modifiedBy, string status)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewActionAuthorize(date, dateOfReport, conductedBy, reasonForReview, designChangeNumber, locationAutoId, modifiedBy, status);
            return ds;
        }
        /// <summary>
        /// To Amend
        /// </summary>
        /// <param name="designChangeNumber">The design change number.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewAmend(string designChangeNumber, string status, string locationAutoId, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewAmend(designChangeNumber, status, locationAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To get all details on design change number text change
        /// </summary>
        /// <param name="designChangeNumber">The design change number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewGetAll(string designChangeNumber, string locationAutoId)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SecurityDesignReviewGetAll(designChangeNumber, locationAutoId);
            return ds;
        }
        #endregion

        #region Function Related to Operations Report
        /// <summary>
        /// Clients the deployment get all.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="area">The area.</param>
        /// <param name="areaInch">The area inch.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDeploymentGetAll(string locationCode, string hrLocationCode, string companyCode, string area, string areaInch)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.ClientDeploymentGetAll(locationCode, hrLocationCode, companyCode, area, areaInch);
            return ds;
        }

        /// <summary>
        /// Asmts the deployment get all.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="area">The area.</param>
        /// <param name="areaInch">The area inch.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtDeploymentGetAll(string locationCode, string hrLocationCode, string companyCode, string area, string areaInch, string clientCode)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtDeploymentGetAll(locationCode, hrLocationCode, companyCode, area, areaInch, clientCode);
            return ds;
        }



        #endregion

        #region Function related to Assignment OT Details
        /// <summary>
        /// Asmts the overtime details get.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtOvertimeDetailsGet(string asmtCode, int asmtAmendNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtOvertimeDetailsGet(asmtCode, asmtAmendNo);
            return ds;

        }
        /// <summary>
        /// Asmts the overtime detail update.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <param name="normalHours">The normal hours.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtOvertimeDetailUpdate(string asmtCode, int asmtAmendNo, int normalHours)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtOvertimeDetailUpdate(asmtCode, asmtAmendNo, normalHours);
            return ds;
        }
        #endregion

        #region Get Sale Order Number by Pdline No

        /// <summary>
        /// Sales the order number get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderNumberGet(int locationAutoId, int asmtMasterAutoId, int pdLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.SaleOrderNumberGet(locationAutoId, asmtMasterAutoId, pdLineNo);
            return ds;
        }
        #endregion



        /// <summary>
        /// Asmts the preferred employees get all.
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPreferredEmployeesGetAll(string asmtMasterAutoId, string locationAutoId, int soLineNo, int pdLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPreferredEmployeesGetAll(asmtMasterAutoId, locationAutoId, soLineNo, pdLineNo);
            return ds;
        }

        /// <summary>
        /// Insert preferred/back up employees on assignment
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="employeeSiteType">Type of the employee site.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtEmployeePreferencesInsert(string clientCode, string asmtId, string postCode, string employeeNumber, string employeeSiteType, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtEmployeePreferencesInsert(clientCode, asmtId, postCode, employeeNumber, employeeSiteType, modifiedBy);
            return ds;
        }

        /// <summary>
        /// delete preferred/back up employees on assignment
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtEmployeePreferencesDelete(string clientCode, string asmtId, string postCode, string employeeNumber)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtEmployeePreferencesDelete(clientCode, asmtId, postCode, employeeNumber);
            return ds;
        }

        /// <summary>
        /// update preferred/back up employees on assignment.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="employeeSiteType">Type of the employee site.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtEmployeePreferencesUpdate(string clientCode, string asmtId, string postCode, string employeeNumber, string employeeSiteType, string modifiedBy)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtEmployeePreferencesUpdate(clientCode, asmtId, postCode, employeeNumber, employeeSiteType, modifiedBy);
            return ds;
        }
        #region Future Date Rota entry
        /// <summary>
        /// To Get Assignments for future date rota entry
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientForFutureDateRotaGet(int locationAutoId, string clientCode, string fromdate, string toDate)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AssignmentsOfClientForFutureDateRotaGet(locationAutoId, clientCode, fromdate, toDate);
            return ds;
        }
        #endregion

        #region Functions Related to Swap Duty
        /// <summary>
        /// Assignmentses the of client get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientGet(int locationAutoId, String clientCode, String fromdate, String toDate)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            DataSet ds = objOperationManagement.AssignmentsOfClientGet(locationAutoId, clientCode, fromdate, toDate);
            return ds;
        }
        #endregion



        // sync secure trax 

        /// <summary>
        /// Bls the asmt post code get all.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlAsmtPostCodeGetAll(string clientCode, string asmtId, string locationAutoID, string fromDate, string toDate)
        {
            DataSet ds = new DataSet();
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            ds = objOperationManagement.DlAsmtPostCodeGetAll(clientCode, asmtId, locationAutoID, fromDate, toDate);
            return ds;
        }
        #region Code Added by  
        //Added by  on 29-May-2013
        // Get Client based on CompanyCode, hrLocationCode and LocationCode
        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetClient(string companyCode, string hrLocationCode, string locationCode)
        {
            DataSet ds = new DataSet();
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();
            ds = objOperationManagement.GetClient(companyCode, hrLocationCode, locationCode);
            return ds;
        }

       //*End

        //Added by  on 19-Jun-2013
        #region Function Related to Employee Document Upload In Employee Master
        /// <summary>
        /// Opses the document download.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet OPSDocumentDownload(string refNo, string employeeNumber)
        {

            DL.OperationManagement objOPS = new DL.OperationManagement();
            DataSet ds = objOPS.OPSDocumentDownload(refNo, employeeNumber);
            return ds;
        }

        /// <summary>
        /// Opses the document insert.
        /// </summary>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet OPSDocumentInsert(DataTable dtFileUpload, string modifiedBy)
        {

            DL.OperationManagement objOPS = new DL.OperationManagement();
            DataSet ds = objOPS.OPSDocumentInsert(dtFileUpload, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Opses the document delete.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet OPSDocumentDelete(string refNo, string fileName, string employeeNumber)
        {

            DL.OperationManagement objOPS = new DL.OperationManagement();
            DataSet ds = objOPS.OPSDocumentDelete(refNo, fileName, employeeNumber);
            return ds;
        }
        //End
        #endregion

        #endregion

        #region Function related to Employee Card Mapping
        public DataSet GetEmployeeCardMapping(string CompanyCode, string ddlSelect, string txtSearch)
        {
            DL.OperationManagement objoptMgmt = new DL.OperationManagement();
            DataSet ds = objoptMgmt.GetEmployeeCardMapping(CompanyCode, ddlSelect, txtSearch);
            return ds;
        }
        public DataSet EmployeeCardMappingInsert(string CompanyCode, string employeeeNumber, string employeeCardNumber, string ModifiedBy, int ID, string effectiveFromDate, string effectiveToDate)
        {
            DL.OperationManagement objoptMgmt = new DL.OperationManagement();
            DataSet ds = objoptMgmt.EmployeeCardMappingInsert(CompanyCode, employeeeNumber, employeeCardNumber, ModifiedBy, ID, effectiveFromDate, effectiveToDate);
            return ds;
        }
        public DataSet EmployeeCardMappingDelete(int ID, string cardNumber)
        {
            DL.OperationManagement objoptMgmt = new DL.OperationManagement();
            DataSet ds = objoptMgmt.EmployeeCardMappingDelete(ID, cardNumber);
            return ds;
        }
        #endregion
    }
}
