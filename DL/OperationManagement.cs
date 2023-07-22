// ***********************************************************************
// Assembly         : DL
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
using System.Transactions;
using System.Globalization;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
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
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaMaster_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To get all Cleint Area Master
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientAreaMasterGetAll(string locationAutoId, string clientCode, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_ClientAreaMaster_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To get all Clients
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientGetAll(string locationAutoId, string areaId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Client_getAll", objParam);
            return ds;
        }
        /// <summary>
        /// To get Area Master
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaMasterGetAll(string locationCode, string hrLocationCode, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaMaster_LocaitonWise_GetAll", objParam);
            return ds;
        }
        #endregion
        #region Function To insert data
        /// <summary>
        /// To Insert Area Master
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaDesc">The area desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaMasterInsert(string locationAutoId, string areaId, string areaDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaDesc, areaDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaMaster_Insert", objParam);
            return ds;

        }
        #endregion
        #region FUnction To Update Data
        /// <summary>
        /// Areas the master update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaDesc">The area desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaMasterUpdate(string locationAutoId, string areaId, string areaDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaDesc, areaDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaMaster_Update", objParam);
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
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaMaster_Delete", objParam);
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
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To get Area Incharge
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGet(string locationCode, string hrLocationCode, string companyCode, string areaId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_LocationWise_GetallAreaIncharge", objParam);
            return ds;
        }
        /// <summary>
        /// Get Area Incharge For AsmtAutoId and AreaID
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGet(string locationAutoId, string areaId)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_GetallAreaIncharge", objParam);
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
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_GetAreaID", objParam);
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
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.UserId, userid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_GetAreaID_UserID", objParam);
            return ds;

        }

        /// <summary>
        /// TO get CurrentLocationAutoID based on current location
        /// </summary>
        /// <param name="BaseCompanyCode">The base company code.</param>
        /// <param name="LocationCode">The location code.</param>
        /// <param name="HrlocationCode">The hrlocation code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetCurrentLocationAutoID(string BaseCompanyCode, string LocationCode, string HrlocationCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationCode, LocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, HrlocationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_GetCurrentLocationCode", objParam);
            return ds;

        }
        /// <summary>
        /// To Get Area ID Based On Area Incharge and Valid From And To date
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaIdGet(string locationAutoId, string areaIncharge, string isIncharge, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaMaster_GetAreaID", objParam);
            return ds;

        }
        /// <summary>
        /// To get Area ID for HR
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaIdGetAll(string locationAutoId, string areaIncharge, string isIncharge, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstHRManagement_AreaMaster_GetAreaID", objParam);
            return ds;
        }

        /// <summary>
        /// Areas the identifier get all for location.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaIdGetAllForLocation(string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAreaIdGetAllForLocation", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_GetAreaDescBasedOnAreaID", objParam);
            return ds;

        }
        /// <summary>
        /// To get Employeename based on employee ID
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeNameByIdGet(string employeeNumber)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_GetEmployeeNameByID", objParam);
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
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(effectiveFrom));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_Insert", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_Delete", objParam);
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

            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset("udp_FutureAreaIncharge_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// this will update the end date of the AreaIncharge and create a new line for Future Incharge
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

            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AreaInchargeAutoId, areaInchargeAutoId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EffectiveFromDate, DL.Common.DateFormat(effectiveFrom));
            objParam[5] = new SqlParameter(DL.Properties.Resources.EffectiveToDate, DL.Common.DateFormat(effectiveTo));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_Update", objParam);
            return ds;

        }
        /// <summary>
        /// This will find the status of the line if it is Open or Closed
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeStatus(string locationAutoId, string areaId, string employeeNumber, string effectiveFrom)
        {

            SqlParameter[] objParam = new SqlParameter[4];

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            DataSet ds = SqlHelper.ExecuteDataset("udp_FutureAreaIncharge_GetByArea", objParam);
            return ds;
        }
        //Code added by   on 6-Sep-2011

        /// <summary>
        /// returns Dataset with AreaInchnarge List Location Wise
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeLocationWise(string locationAutoId, string month, string year)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Month, month);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Year, year);
            
            DataSet ds = SqlHelper.ExecuteDataset("udpMstOperation_AreaIncharge_ByLocation", objParam);
            return ds;
        }

        #endregion

        #region Functions Related to Assignment
        /// <summary>
        /// Get AsmtDetails For Client, LocationAutoId, AsmtId and AsmtAmendNo.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtDetailGet(string clientCode, string locationAutoId, string asmtId, string asmtAmendNo)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtAmendNo, asmtAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_GetAsmtDetailsForSO", objParam);
            return ds;
        }
        /// <summary>
        /// Function to get Asmt Address for Asmt Site Instruction Report
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet OpsAsmtCodeAddressGet(string locationAutoId, string clientCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_OPSAsmtCodeAddess_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Get AsmtAmendNo For SaleOrder No, ocationAutoID, AsmtID
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtAmendNoGet(string clientCode, string locationAutoId, string asmtId)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_GetAsmtAmendNoBasedOnSO", objParam);
            return ds;
        }

        /// <summary>
        /// Assignmentses the of client get.
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
            SqlParameter[] objParm = new SqlParameter[6];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtsOfClient_GetInchargeAreaId", objParm);
            return ds;
        }

        /// <summary>
        /// Assignmentses the of client get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientGet(int locationAutoId, string clientCode, string fromDate, string toDate, string areaIncharge, string isAreaIncharge, string areaId)
        {

            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaId, areaId); // Added By   on 22-Mar-2012

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtsOfClient_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaId, areaId); // Added By   on 22-Mar-2012

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_PreferanceAsmtsOfClient_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Assignmentses the of multiple client get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfMultipleClientGet(int locationAutoId, string clientCode, string fromDate, string toDate, string areaIncharge, string isAreaIncharge, string areaId)
        {

            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaId, areaId); // Added By   on 22-Mar-2012

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AsmtMultipleClientWise_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Assignmentses the of client schedule lock unlock get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientScheduleLockUnlockGet(int locationAutoId, string clientCode, string fromDate, string toDate)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtsOfClient_ScheduleLockUnlockGet", objParm);
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
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAsmtPost", objParm);
            return ds;
        }
        /// <summary>
        /// To get Client Assignments Basd on Branch and Division
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="divisionCode">The division code.</param>
        /// <param name="branchCode">The branch code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientGetBasedOnBranchAndDivisionCode(string companyCode, string divisionCode, string branchCode, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DivisionCode, divisionCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.BranchCode, branchCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtsOfClient_GetBasedOnBranchAndDivisionCode", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Asmt_GetByClientCodeNAreaId", objParm);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Asmt_Delete", objParm);
            return ds;
        }
        /// <summary>
        /// To get Shifts
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftGet(string asmtCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtWiseShift_Get", objParm);
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

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtCode);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_ShiftOnAsmtOfClient_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Get Assignemnt on Max Amend No
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMaxAmendNoGet(string clientCode, string locationAutoId, string asmtId)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_MaxAmendNo_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Get Total No Of Post From SOdetails For SONO,LocationAutoId,AmendNo
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet TotalNumberOfPostGet(string soNo, string locationAutoId, string soAmendNo)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_AsmtCreation_TotaNoOfPost_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Save the Information of Assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
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
        public DataSet AsmtMasterInfoSave(string locationAutoId, string clientCode, string asmtId, string asmtMasterAutoId, string asmtCode, string manualAsmtCode, string asmtAmendNo, string asmtAmendDate, string amendBy, string asmtStartDate, string terminationDate, string terminationReason, string terminatedBy, string asmtStatus, string areaId, string areaInch, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[17];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            //objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            //objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ManualAsmtCode, manualAsmtCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AsmtAmendNo, asmtAmendNo);
            objParam[7] = new SqlParameter(DL.Properties.Resources.AsmtAmendDate, DL.Common.DateFormat(asmtAmendDate));
            objParam[8] = new SqlParameter(DL.Properties.Resources.AmendBy, amendBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.AsmtStartDate, DL.Common.DateFormat(asmtStartDate));
            objParam[10] = new SqlParameter(DL.Properties.Resources.TerminationDate, DL.Common.DateFormat(terminationDate));
            objParam[11] = new SqlParameter(DL.Properties.Resources.TerminationReason, terminationReason);
            objParam[12] = new SqlParameter(DL.Properties.Resources.TerminatedBy, terminatedBy);
            objParam[13] = new SqlParameter(DL.Properties.Resources.AsmtStatus, asmtStatus);
            objParam[14] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[15] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaInch);
            //objParam[17] = new SqlParameter(DL.Properties.Resources.SOType, strSOType);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_OPSAsmtMasterInfo_Save", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Min SO line start date
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterMinSOLineStartDateGet(String locationAutoId, string clientCode, string asmtId)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MinSOLineStartDate4Asmt_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Save the Information Of AsmtPostDeployment
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
            SqlParameter[] objParam = new SqlParameter[15];

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            //objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            //objParam[3] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtAmendNo, asmtAmendNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Site, site);
            objParam[7] = new SqlParameter(DL.Properties.Resources.JobDesc, jobDesc);
            objParam[8] = new SqlParameter(DL.Properties.Resources.PersAllocated, personAllocated);
            objParam[9] = new SqlParameter(DL.Properties.Resources.PDLineStartDate, DL.Common.DateFormat(pdLineStartDate));
            objParam[10] = new SqlParameter(DL.Properties.Resources.PDLineEndDate, DL.Common.DateFormat(pdLineEndDate));
            objParam[11] = new SqlParameter(DL.Properties.Resources.PDLineWEFDate, DL.Common.DateFormat(pdLineWefDate));
            objParam[12] = new SqlParameter(DL.Properties.Resources.Active, active);
            objParam[13] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AsmtPostDeployment_save", objParam);
            return ds;
        }
        /// <summary>
        /// Get AsmtPostDeploymnet Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentGet(string locationAutoId, string clientCode, string asmtId, string asmtCode, string asmtAmendNo)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtAmendNo, asmtAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AsmtPostDeployment_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtAmendNo, asmtAmendNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.StatusThirdLevelAuthorize, statusThirdLevelAuthorize);
            objParam[6] = new SqlParameter(DL.Properties.Resources.StatusShortClosed, statusShortClosed);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_GetDetailForTermination", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(dutyDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtAllShifts_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Get Assignment Shift deitails for AsmtMasterAutoId,SOLine,PDLineNo
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentShiftDetailGet(string asmtMasterAutoId, int soLineNo, int pdLineNo)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AsmtPDShiftDetails_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Assignment Details by PD Line No
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentShiftDetailsGet(string asmtMasterAutoId, int soLineNo, int pdLineNo)
        {
            DL.OperationManagement objOperationManagement = new DL.OperationManagement();

            DataSet ds = objOperationManagement.AsmtPostDeploymentShiftDetailGet(asmtMasterAutoId, soLineNo, pdLineNo);
            return ds;
        }
        /// <summary>
        /// Save Assignment Shift Details
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

            SqlParameter[] objParam = new SqlParameter[29];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParam[6] = new SqlParameter(DL.Properties.Resources.PDSLineNo, pdSLineNo);
            objParam[7] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Shift, shift);
            if (string.IsNullOrEmpty(monTimeFrom))
            {
                objParam[9] = new SqlParameter(DL.Properties.Resources.MonTimeFrom, null);
            }
            else
            {
                objParam[9] = new SqlParameter(DL.Properties.Resources.MonTimeFrom, monTimeFrom);
            }

            if (string.IsNullOrEmpty(monTimeTo))
            {
                objParam[10] = new SqlParameter(DL.Properties.Resources.MonTimeTo, null);
            }
            else
            {
                objParam[10] = new SqlParameter(DL.Properties.Resources.MonTimeTo, monTimeTo);
            }

            if (string.IsNullOrEmpty(tueTimeFrom))
            {
                objParam[11] = new SqlParameter(DL.Properties.Resources.TueTimeFrom, null);
            }
            else
            {
                objParam[11] = new SqlParameter(DL.Properties.Resources.TueTimeFrom, tueTimeFrom);
            }
            if (string.IsNullOrEmpty(tueTimeTo))
            {
                objParam[12] = new SqlParameter(DL.Properties.Resources.TueTimeTo, null);
            }
            else
            {
                objParam[12] = new SqlParameter(DL.Properties.Resources.TueTimeTo, tueTimeTo);
            }
            if (string.IsNullOrEmpty(wedTimeFrom))
            {
                objParam[13] = new SqlParameter(DL.Properties.Resources.WedTimeFrom, null);
            }
            else
            {
                objParam[13] = new SqlParameter(DL.Properties.Resources.WedTimeFrom, wedTimeFrom);
            }
            if (string.IsNullOrEmpty(wedTimeTo))
            {
                objParam[14] = new SqlParameter(DL.Properties.Resources.WedTimeTo, null);
            }
            else
            {
                objParam[14] = new SqlParameter(DL.Properties.Resources.WedTimeTo, wedTimeTo);
            }
            if (string.IsNullOrEmpty(thuTimeFrom))
            {
                objParam[15] = new SqlParameter(DL.Properties.Resources.ThuTimeFrom, null);
            }
            else
            {
                objParam[15] = new SqlParameter(DL.Properties.Resources.ThuTimeFrom, thuTimeFrom);
            }
            if (string.IsNullOrEmpty(thuTimeTo))
            {
                objParam[16] = new SqlParameter(DL.Properties.Resources.ThuTimeTo, null);
            }
            else
            {
                objParam[16] = new SqlParameter(DL.Properties.Resources.ThuTimeTo, thuTimeTo);
            }
            if (string.IsNullOrEmpty(friTimeFrom))
            {
                objParam[17] = new SqlParameter(DL.Properties.Resources.FriTimeFrom, null);
            }
            else
            {
                objParam[17] = new SqlParameter(DL.Properties.Resources.FriTimeFrom, friTimeFrom);
            }
            if (string.IsNullOrEmpty(friTimeTo))
            {
                objParam[18] = new SqlParameter(DL.Properties.Resources.FriTimeTo, null);
            }
            else
            {
                objParam[18] = new SqlParameter(DL.Properties.Resources.FriTimeTo, friTimeTo);
            }
            if (string.IsNullOrEmpty(satTimeFrom))
            {
                objParam[19] = new SqlParameter(DL.Properties.Resources.SatTimeFrom, null);
            }
            else
            {
                objParam[19] = new SqlParameter(DL.Properties.Resources.SatTimeFrom, satTimeFrom);
            }
            if (string.IsNullOrEmpty(satTimeTo))
            {
                objParam[20] = new SqlParameter(DL.Properties.Resources.SatTimeTo, null);
            }
            else
            {
                objParam[20] = new SqlParameter(DL.Properties.Resources.SatTimeTo, satTimeTo);
            }
            if (string.IsNullOrEmpty(sunTimeFrom))
            {
                objParam[21] = new SqlParameter(DL.Properties.Resources.SunTimeFrom, null);
            }
            else
            {
                objParam[21] = new SqlParameter(DL.Properties.Resources.SunTimeFrom, sunTimeFrom);
            }

            if (string.IsNullOrEmpty(sunTimeTo))
            {
                objParam[22] = new SqlParameter(DL.Properties.Resources.SunTimeTo, null);
            }
            else
            {
                objParam[22] = new SqlParameter(DL.Properties.Resources.SunTimeTo, sunTimeTo);
            }
            objParam[23] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[24] = new SqlParameter(DL.Properties.Resources.ModifiedDate, DL.Common.DateFormat(DateTime.Now));
            objParam[25] = new SqlParameter(DL.Properties.Resources.RecordStatus, recordStatus);
            objParam[26] = new SqlParameter(DL.Properties.Resources.MaxPDSLineNoAdd1, maximumLineNo);
            objParam[27] = new SqlParameter(DL.Properties.Resources.UpdateStatus, updateStatus);
            objParam[28] = new SqlParameter(DL.Properties.Resources.RoleCode, role);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtPDShiftDetails_Save", objParam);
            return ds;
        }
        /// <summary>
        /// AuthoRize Asignment for AsmtMasterAutoId,LocationAutoId
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterAuthorize(string asmtMasterAutoId, string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtMaster_Authorize", objParam);
            return ds;
        }
        /// <summary>
        /// Asmt Master Amend
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="amendBy">The amend by.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterAmend(string asmtMasterAutoId, string locationAutoId, string amendBy, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AmendBy, amendBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Asmt_Amend", objParam);
            return ds;
        }
        /// <summary>
        /// Assignment Master Amend on Sale Order Authiorize
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="amendBy">The amend by.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterAmendOnSoAuthorized(string clientCode, string soNo, string locationAutoId, string amendBy, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AmendBy, amendBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtAmendonSOAuthorize", objParam);
            return ds;
        }
        /// <summary>
        /// Assignemnt Master Terminate
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

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TerminatedBy, terminatedBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TerminationDate, DL.Common.DateFormat(terminationDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.TerminationReason, terminationReason);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Asmt_Terminate", objParam);
            return ds;
        }
        /// <summary>
        /// Get Assignemnt Master Deployment Pattern
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterDeploymentPatternSoGet(string locationAutoId, string soNo, string soAmendNo, int soLineNo)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SaleOrderDeploymentPattern_Get", objParam);
            return ds;
        }
        /// <summary>
        /// to get asmtCode ,max amend number based on clientCode,AsmtID,Status=Authorized
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMasterGetAsmtCodeAndMaxAmendNo(string clientCode, string asmtId, string status)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SaleOPSTermination_GetAsmtCodeANDMaxAmendNo", objParam);
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
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemCode, code);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TerminationType, terminationType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SaleTermination_Get", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Stndard Shifts
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardShiftGet(string locationAutoId, string shiftCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_StandardShift_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Maximum PD Position for Assignment
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtMaximumPostDeploymentPositionGet(string asmtMasterAutoId, int soLineNo, int pdLineNo)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NoOfPost_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Get Inventory Details for Assignment
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtInventoryDetailsGet(string asmtMasterAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtInventoryDetails_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Insert Inventory
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

            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Quantity, quantity);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Owner, owner);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[5] = new SqlParameter(DL.Properties.Resources.RecordStatus, recordStatus);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_OPSAsmtInventory_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Training Details for Assignment
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtTrainingDetailsGet(string asmtMasterAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtTrainingDetails_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get On Job Training
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtOnJobTrainingMasterGet(string asmtMasterAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_OnJobTrainingMaster_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Site And Post for Assignment
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtSiteAndPostGet(string asmtMasterAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtSiteandPost_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Employee Post
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtSiteEmployeePostGet(int asmtMasterAutoId, int locationAutoId, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtSiteEmployeePost_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Save On Job Tranining
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

            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Site, site);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Subject, subject);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[7] = new SqlParameter(DL.Properties.Resources.RecordStatus, recordStatus);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_OPSOnJobTraining_Insert", objParam);
            return ds;

        }
        /// <summary>
        /// To Save On Site Training
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

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CourseId, courseId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.InternalExternal, internalExternal);
            objParam[3] = new SqlParameter(DL.Properties.Resources.OnSiteTrg, onsiteTraining);
            objParam[4] = new SqlParameter(DL.Properties.Resources.RecordStatus, recordStatus);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_OPSAsmtTraining_Insert", objParam);
            return ds;

        }
        /// <summary>
        /// To Get Inventory Item Type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtInventoryItemTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtInventory_ItemType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Invetory Sub item Type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="itemType">Type of the item.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtInventoryItemSubtypeGet(string companyCode, string itemType)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemType, itemType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtInventory_ItemSubType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// TO get Training Course Type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtTrainingCourseTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtTraining_CourseType_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(date));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtSitePost_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Shift PD Line of SO Line
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostDeploymentShiftGet(string asmtMasterAutoId, string soNo, string soLineNo, string pdLineNo)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtShift_PdLineofSoLine_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Copy Shift on PD Line of SO Line no
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="copyTo">The copy to.</param>
        /// <returns>DataSet.</returns>
        public DataSet CopyAsmtShift(string asmtMasterAutoId, string soNo, string soLineNo, string pdLineNo, string copyTo)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CopyTo, copyTo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtShift_Copy_onPdLinesofSOLineNo", objParam);
            return ds;
        }
        /// <summary>
        /// To get Fresh and Amend Assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="statusFresh">The status fresh.</param>
        /// <param name="statusAmend">The status amend.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OpsPendingAsmtGet(string locationAutoId, string statusFresh, string statusAmend, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.StatusFresh, statusFresh);
            objParam[2] = new SqlParameter(DL.Properties.Resources.StatusAmend, statusAmend);
            objParam[3] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_mstOPS_pendingAsmt_get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get All Post Based on Asmt Code
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet OpsGetAllPostBasedOnAsmtCode(string asmtCode, string locationAutoId, string fromDate, string toDate,string clientCode )
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetAllPost", objParam);
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
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPSAsmtsOfSelectedClientGet", objParm);
            return ds;
        }

        /// <summary>
        /// To Get Incident No for Selected Clients By  on 1-Aug-2013
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>dataset</returns>
        public DataSet IncidentNoSelectedClientGet( string clientCode, int locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_IncidentNoSelectedClient_Get", objParm);
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
        public DataSet DLPOPGetAllPost(string asmtCode, string locationAutoId, string fromDate, string toDate, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_POP_GetAllPost", objParam);
            return ds;
        }
        #endregion

        #region Functions Related to Assignment Ciatation And Recommendation
        /// <summary>
        /// To Get Citation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtCitationGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Citation_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Citation Type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtCitationTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtCitation_CitationType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Citation Detail
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="citationNo">The citation no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtCitationDetailGet(string locationAutoId, string citationNo)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CitationNo, citationNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtCitationdtl_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CitationNo, citationNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, awardedTo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Citation_DeleteAwardDetails", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CitationNo, citationNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AwardDescripation, awardDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, awardedTo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Citation_InsertAwardDetails", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CitationNo, citationNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AwardDescripation, awardDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, awardedTo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Citation_UpdateAwardDetails", objParam);
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
        /// <param name="awardedDate">The awarded date.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="awardDetail">The award detail.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">awardDetail</exception>
        public DataSet CitationHeaderDetailInsert(string locationAutoId, string citationType, DateTime citationDate, string citation, string awardedBy, string designation, DateTime awardedDate, string asmtCode, DataTable awardDetail, string status, string modifiedBy)
        {

            if (awardDetail == null || awardDetail.Rows==null)
            {
                throw new ArgumentNullException("awardDetail");
            }

            DataSet ds = new DataSet();
            DataSet dsAwardDetails = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            dsAwardDetails.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Citationtype, citationType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CitationDate, DL.Common.DateFormat(citationDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.Citation, citation);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Awardedby, awardedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Designation, designation);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Awardedon, awardedDate);
            objParam[7] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Citation_InsertHdr", objParam);
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Citation_no"].ToString()))
                {
                    if (awardDetail.Rows.Count > 0)
                    {
                        Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");
                        if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                        {
                            for (int i = 0; i < awardDetail.Rows.Count; i++)
                            {
                                SqlParameter[] obj = new SqlParameter[4];
                                obj[0] = new SqlParameter(DL.Properties.Resources.CitationNo, ds.Tables[0].Rows[0]["Citation_no"].ToString());
                                obj[1] = new SqlParameter(DL.Properties.Resources.AwardDescripation, awardDetail.Rows[i]["Award_Descripation"].ToString());
                                obj[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, awardDetail.Rows[i][DL.Properties.Resources.fldEmployeeNumber].ToString());
                                obj[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                dsAwardDetails = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Citation_InsertAwardDetails", obj);
                            }
                        }
                    }
                }
                tx.Complete();
            }
            if (dsAwardDetails.Tables.Count > 0 && dsAwardDetails.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return dsAwardDetails;
            }
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CitationNo, citationNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Citaion_Authorize", objParam);
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
        /// <param name="awardedDate">The awarded date.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CitationUpdate(string locationAutoId, string citationNo, string citationType, DateTime citationDate, string citation, string awardedBy, string designation, DateTime awardedDate, string asmtCode, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CitationNo, citationNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Citationtype, citationType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.CitationDate, DL.Common.DateFormat(citationDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.Citation, citation);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Awardedby, awardedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Designation, designation);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Awardedon, awardedDate);
            objParam[8] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Citation_Update", objParam);
            return ds;
        }
        #endregion

        #region Function Related to IncidentMaster
        /// <summary>
        /// Incidents the insert.
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
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="supportRequired">The support required.</param>
        /// <param name="messagePassed">The message passed.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">The status.</param>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">messagePassed</exception>
        public DataSet IncidentInsert(DateTime reportingDate, DateTime timeReportingTime, string incidentType, string clientCode, string asmtId, string reportedBy, string designation, string nature, string description, string materialStolen, bool policeInvolved, double lossClaimValue, string PoliceRefNo, DateTime occurrenceDate, DateTime occurrenceTime, string employeeId, string supportRequired, DataTable messagePassed, string locationAutoId, string modifiedBy, string status, DataTable dtFileUpload)
        {

            if (messagePassed == null || messagePassed.Rows == null)
            {
                throw new ArgumentNullException("messagePassed");
            }

            DataSet ds = new DataSet();
            DataSet objds = new DataSet();
            DataSet dsUpload = new DataSet();               //Added Code for Upload Document by  on 21-Jun-2013
            ds.Locale = CultureInfo.InvariantCulture;
            objds.Locale = CultureInfo.InvariantCulture;
            dsUpload.Locale = CultureInfo.InvariantCulture;     //Added Code for Upload Document by  on 21-Jun-2013

            SqlParameter[] objParam = new SqlParameter[20];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ReportingDate, DL.Common.DateFormat(reportingDate));
            objParam[1] = new SqlParameter(DL.Properties.Resources.ReportingTime, timeReportingTime);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IncidentType, incidentType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ReportedBy, reportedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Designation, designation);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Nature, nature);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Description, description);
            objParam[9] = new SqlParameter(DL.Properties.Resources.MaterialStolen, materialStolen);
            objParam[10] = new SqlParameter(DL.Properties.Resources.PoliceInvolved, policeInvolved);
            objParam[11] = new SqlParameter(DL.Properties.Resources.LossClaimValue, lossClaimValue);
            objParam[12] = new SqlParameter(DL.Properties.Resources.PoliceRefNo, PoliceRefNo);
            objParam[13] = new SqlParameter(DL.Properties.Resources.OccuranceDate, DL.Common.DateFormat(occurrenceDate));
            objParam[14] = new SqlParameter(DL.Properties.Resources.OccuranceTime, occurrenceTime);
            objParam[15] = new SqlParameter(DL.Properties.Resources.EnteredBy, employeeId);
            objParam[16] = new SqlParameter(DL.Properties.Resources.SupportReq, supportRequired);
            objParam[17] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[18] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[19] = new SqlParameter(DL.Properties.Resources.Status, status);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_IncidentMaster_Insert", objParam);
                if (messagePassed.Rows.Count > 0)
                {
                    Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");
                    if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                    {

                        for (int i = 0; i < messagePassed.Rows.Count; i++)
                        {
                            SqlParameter[] obj = new SqlParameter[5];
                            Guard.ArgumentValidDate(messagePassed.Rows[i][DL.Properties.Resources.fldDate].ToString(), "myDateArgument");
                            Guard.ArgumentValidDate(messagePassed.Rows[i][DL.Properties.Resources.fldTime].ToString(), "myDateArgument");
                            obj[0] = new SqlParameter(DL.Properties.Resources.MessageTo, messagePassed.Rows[i][DL.Properties.Resources.fldMessageTo].ToString());
                            obj[1] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(DateTime.Parse(messagePassed.Rows[i][DL.Properties.Resources.fldDate].ToString())));
                            obj[2] = new SqlParameter(DL.Properties.Resources.Time, DL.Common.DateFormat(DateTime.Parse(messagePassed.Rows[i][DL.Properties.Resources.fldTime].ToString())));
                            obj[3] = new SqlParameter(DL.Properties.Resources.IncidentNo, ds.Tables[0].Rows[0][DL.Properties.Resources.fldIncidentNumber].ToString());
                            obj[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                            objds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_IncidentMaster_InsertPassedInfo", obj);
                        }
                    }
                    //Added for Document Upload by  on 21-Jun-2013
                    if (dtFileUpload.Rows.Count > 0)
                    {
                        if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                        {
                            for (int cnt = 0; cnt < dtFileUpload.Rows.Count; cnt++)
                            {
                                SqlParameter[] objUpload = new SqlParameter[6];
                                objUpload[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, dtFileUpload.Rows[cnt]["EmployeeNumber"].ToString());
                                objUpload[1] = new SqlParameter(DL.Properties.Resources.RefNo, ds.Tables[0].Rows[0][DL.Properties.Resources.fldIncidentNumber].ToString());
                                objUpload[2] = new SqlParameter(DL.Properties.Resources.UploadDesc, dtFileUpload.Rows[cnt]["UploadDesc"].ToString());
                                objUpload[3] = new SqlParameter(DL.Properties.Resources.FileName, dtFileUpload.Rows[cnt]["FileName"].ToString());
                                objUpload[4] = new SqlParameter(DL.Properties.Resources.UploadDate, Convert.ToDateTime(dtFileUpload.Rows[cnt]["UploadDate"]));
                                objUpload[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                dsUpload = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Document_Upload_Download_Insert", objUpload);
                            }
                        }
                    }
                    //End
                }
                tx.Complete();
            }

            if (messagePassed.Rows.Count > 0)
            {
                return objds;
            }
            else
            {
                return ds;
            }
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

            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IncidentTrackingDate, DL.Common.DateFormat(incidentTrackDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ReportedBy, reportedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ReportedDate, DL.Common.DateFormat(reportedDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ReportedTime, reportedTime);
            objParam[6] = new SqlParameter(DL.Properties.Resources.IncTrackStatus, incidentTrackStatus);
            objParam[7] = new SqlParameter(DL.Properties.Resources.IncTrackAction, incidentTrackAction);
            objParam[8] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[9] = new SqlParameter(DL.Properties.Resources.UserId, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_IncidentTracking_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// To Fill Drop down ddlIncidentType with item desc from quick Code master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentItemDescGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_GetItemDesc", objParam);
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

        //    SqlParameter[] objParam = new SqlParameter[2];
        //    objParam[0] = new SqlParameter(DL.Properties.Resources.ItemDesc, ItemDesc);
        //    objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
        //    DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_GetItemDescBasedOnItemDesc", objParam);
        //    return ds;
        //}
        public DataSet IncidentItemDescGet(string incidentType, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentType, incidentType);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_Get_Nature", objParam);
            return ds;
        }

        /// <summary>
        /// To get Details based on Asmt Code and location AutoID
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        /// Modify by  on 20-May-2013
        public DataSet AsmtIncidentDetailGet(string clientCode, string asmtCode, string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_GetAsmtDetail", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtDetail_GetDetailBasedOnCompanyCode", objParam);
            return ds;
        }
        /// <summary>
        /// Incidents the number get.
        /// </summary>
        /// <param name="prefixText">The prefix text.</param>
        /// <param name="type">The type.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader IncidentNumberGet(String prefixText, string type, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.PrefixText, prefixText);
            objParam[1] = new SqlParameter(DL.Properties.Resources.type, type);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "udpMstoperation_IncidentMaster_SearchAutoComplete", objParam);
            return reader;
        }
        /// <summary>
        /// To Get details based on Incident number
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentDetailGet(string incidentNo, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_GetDetailBasedOnIncidentNo", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_IncidentTracking_GetDetailBasedOnIncidentNo", objParam);
            return ds;
        }
        /// <summary>
        /// To delete Details from Incident Master
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentDelete(string incidentNo, string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_Delete", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_GetDataForUpdate", objParam);
            return ds;
        }
        /// <summary>
        /// To Update gvIncident Info in Edit mode
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="messageTo">The message to.</param>
        /// <param name="date">The date.</param>
        /// <param name="dtTime">The dt time.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="oldMessageTo">The old message to.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentInformationUpdate(string incidentNumber, string messageTo, DateTime date, DateTime dtTime, string modifiedBy, string oldMessageTo)
        {

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(date));
            objParam[2] = new SqlParameter(DL.Properties.Resources.Time, DL.Common.DateFormat(dtTime));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.MessageTo, messageTo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.OldMessageTo, oldMessageTo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_UpdatePassedInfo", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MessageTo, messageTo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_DeletePassedInfo", objParam);
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
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="supportRequired">The support required.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentUpdate(DateTime reportingDate, DateTime timeReportingTime, string incidentType, string clientCode, string asmtId, string reportedBy, string designation, string nature, string description, string materialStolen, bool policeInvolved, double lossClaimValue, string policeRefNo, DateTime occurrenceDate, DateTime occurrenceTime, string employeeId, string supportRequired, string locationAutoId, string modifiedBy, string incidentNo)
        {

            SqlParameter[] objParam = new SqlParameter[20];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ReportingDate, DL.Common.DateFormat(reportingDate));
            objParam[1] = new SqlParameter(DL.Properties.Resources.ReportingTime, DL.Common.DateFormat(timeReportingTime));
            objParam[2] = new SqlParameter(DL.Properties.Resources.IncidentType, incidentType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ReportedBy, reportedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Designation, designation);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Nature, nature);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Description, description);
            objParam[9] = new SqlParameter(DL.Properties.Resources.MaterialStolen, materialStolen);
            objParam[10] = new SqlParameter(DL.Properties.Resources.PoliceInvolved, policeInvolved);
            objParam[11] = new SqlParameter(DL.Properties.Resources.LossClaimValue, lossClaimValue);
            objParam[12] = new SqlParameter(DL.Properties.Resources.PoliceRefNo, policeRefNo);
            objParam[13] = new SqlParameter(DL.Properties.Resources.OccuranceDate, DL.Common.DateFormat(occurrenceDate));
            objParam[14] = new SqlParameter(DL.Properties.Resources.OccuranceTime, occurrenceTime);
            objParam[15] = new SqlParameter(DL.Properties.Resources.EnteredBy, employeeId);
            objParam[16] = new SqlParameter(DL.Properties.Resources.SupportReq, supportRequired);
            objParam[17] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[18] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[19] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_Update", objParam);
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

            SqlParameter[] objParam = new SqlParameter[9];

            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IncidentTrackingDate, DL.Common.DateFormat(incidentTrackDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ReportedBy, reportedBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ReportedDate, DL.Common.DateFormat(reportedDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ReportedTime, DL.Common.DateFormat(reportedTime));
            objParam[5] = new SqlParameter(DL.Properties.Resources.IncTrackStatus, incidentTrackStatus);
            objParam[6] = new SqlParameter(DL.Properties.Resources.IncTrackAction, incidentTrackAction);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[8] = new SqlParameter(DL.Properties.Resources.UserId, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_IncidentTracking_Update", objParam);
            return ds;
        }

        /// <summary>
        /// To Insert date into gv incident info
        /// </summary>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="messageTo">The message to.</param>
        /// <param name="date">The date.</param>
        /// <param name="dtTime">The dt time.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentPassedInformationInsert(string incidentNo, string messageTo, DateTime date, DateTime dtTime, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MessageTo, messageTo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(date));
            objParam[3] = new SqlParameter(DL.Properties.Resources.Time, DL.Common.DateFormat(dtTime));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_InsertPassedInfo", objParam);
            return ds;
        }

        /// <summary>
        /// To Check If the Assignment belongs to the incidentNo SP NOT DELETED
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet IncidentAuthorize(string incidentNumber, string status, string locationAutoId, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_Authorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_IncidentTracking_Authorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_Amend", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_IncidentTracking_Amend", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_GetAll", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Incident_GetIncidentType", objParam);
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
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="financialImplication">The financial implication.</param>
        /// <param name="briefOfProblem">The brief of problem.</param>
        /// <param name="briefOfResolution">The brief of resolution.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="damageAndWarningStatus">The damage and warning status.</param>
        /// <param name="investigationStatus">The investigation status.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningInsert(DateTime statusChangeDate, string status, string asmtCode, string meetingNo, string reasonForChange, string comfortStatus, string incidentNo, string employeeId, string financialImplication, string briefOfProblem, string briefOfResolution, string locationAutoId, string modifiedBy, int amendNo, string damageAndWarningStatus, string investigationStatus)
        {

            SqlParameter[] objParam = new SqlParameter[16];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.WDAmendNo, amendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.WDStatus, damageAndWarningStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.StatusChangeDate, DL.Common.DateFormat(statusChangeDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.MeetingNo, meetingNo);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ReasonForChange, reasonForChange);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ComfortStatus, comfortStatus);
            objParam[9] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.EnteredBy, employeeId);
            objParam[11] = new SqlParameter(DL.Properties.Resources.FinancialImplication, financialImplication);
            objParam[12] = new SqlParameter(DL.Properties.Resources.BriefOfProblem, briefOfProblem);
            objParam[13] = new SqlParameter(DL.Properties.Resources.BriefOfResolution, briefOfResolution);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[15] = new SqlParameter(DL.Properties.Resources.InvestigationStatus, investigationStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_WarningAndDamage_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// To Check If the Assignment belongs to the MeetingNo
        /// </summary>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningAmendNumberGet(string damageAndWarningControlNo)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WDControlNo, damageAndWarningControlNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_DamageAndWarning_GetAmendNoBasedOnWDControlNo", objParam);
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
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WDAmendNo, amendNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.WDStatus, damageAndWarningStatus);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.WDControlNo, damageAndWarningControlNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_WarningAndDamage_Authorize", objParam);
            return ds;
        }
        /// <summary>
        /// To Amend
        /// </summary>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <param name="statusChangeDate">The status change date.</param>
        /// <param name="status">The status.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="meetingNo">The meeting no.</param>
        /// <param name="reasonForChange">The reason for change.</param>
        /// <param name="comfortStatus">The comfort status.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="employeeId">The employee identifier.</param>
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
        public DataSet DamageAndWarningAmend(string damageAndWarningControlNo, DateTime statusChangeDate, string status, string asmtCode, string meetingNo, string reasonForChange, string comfortStatus, string incidentNo, string employeeId, string financialImplication, string briefOfProblem, string briefOfResolution, string locationAutoId, string modifiedBy, int amendNo, string damageAndWarningStatus, DateTime amendDate, string investigationStatus)
        {

            SqlParameter[] objParam = new SqlParameter[18];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.WDAmendNo, amendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.WDStatus, damageAndWarningStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.StatusChangeDate, DL.Common.DateFormat(statusChangeDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.MeetingNo, meetingNo);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ReasonForChange, reasonForChange);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ComfortStatus, comfortStatus);
            objParam[9] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.EnteredBy, employeeId);
            objParam[11] = new SqlParameter(DL.Properties.Resources.FinancialImplication, financialImplication);
            objParam[12] = new SqlParameter(DL.Properties.Resources.BriefOfProblem, briefOfProblem);
            objParam[13] = new SqlParameter(DL.Properties.Resources.BriefOfResolution, briefOfResolution);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[15] = new SqlParameter(DL.Properties.Resources.WDControlNo, damageAndWarningControlNo);
            objParam[16] = new SqlParameter(DL.Properties.Resources.AmendmentDate, DL.Common.DateFormat(amendDate));
            objParam[17] = new SqlParameter(DL.Properties.Resources.InvestigationStatus, investigationStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_WarningAndDamage_Amend", objParam);
            return ds;
        }
        /// <summary>
        /// To Get the MAx Amend Number of WDControlNo
        /// </summary>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningMaximumAmendNumberGet(string damageAndWarningControlNo)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WDControlNo, damageAndWarningControlNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_DamageAndWarning_GetMaxAmendNo", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.WDControlNo, damageAndWarningControlNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.WDAmendNo, amendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_DamageAndWarning_GetDetail", objParam);
            return ds;
        }
        /// <summary>
        /// to update
        /// </summary>
        /// <param name="damageAndWarningControlNo">The damage and warning control no.</param>
        /// <param name="statusChangeDate">The status change date.</param>
        /// <param name="status">The status.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="meetingNo">The meeting no.</param>
        /// <param name="reasonForChange">The reason for change.</param>
        /// <param name="comfortStatus">The comfort status.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="employeeId">The employee identifier.</param>
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
        public DataSet DamageAndWarningUpdate(string damageAndWarningControlNo, DateTime statusChangeDate, string status, string asmtCode, string meetingNo, string reasonForChange, string comfortStatus, string incidentNo, string employeeId, string financialImplication, string briefOfProblem, string briefOfResolution, string locationAutoId, string modifiedBy, int amendNo, string damageAndWarningStatus, DateTime amendDate, string investigationStatus)
        {

            SqlParameter[] objParam = new SqlParameter[18];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.WDAmendNo, amendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.WDStatus, damageAndWarningStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.StatusChangeDate, DL.Common.DateFormat(statusChangeDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.MeetingNo, meetingNo);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ReasonForChange, reasonForChange);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ComfortStatus, comfortStatus);
            objParam[9] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.EnteredBy, employeeId);
            objParam[11] = new SqlParameter(DL.Properties.Resources.FinancialImplication, financialImplication);
            objParam[12] = new SqlParameter(DL.Properties.Resources.BriefOfProblem, briefOfProblem);
            objParam[13] = new SqlParameter(DL.Properties.Resources.BriefOfResolution, briefOfResolution);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[15] = new SqlParameter(DL.Properties.Resources.WDControlNo, damageAndWarningControlNo);
            objParam[16] = new SqlParameter(DL.Properties.Resources.AmendmentDate, DL.Common.DateFormat(amendDate));
            objParam[17] = new SqlParameter(DL.Properties.Resources.InvestigationStatus, investigationStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_WarningAndDamage_Update", objParam);
            return ds;
        }

        /// <summary>
        /// To fill ddlComfortStatus
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningComfortStatusGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_DamageAndWarning_GetComfortStatus", objParam);
            return ds;
        }
        /// <summary>
        /// To fill ddlGetReason4Change
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ReasonForChangingDamageAndWarningGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_DamageAndWarning_GetReason4Change", objParam);
            return ds;
        }
        /// <summary>
        /// To fill ddlStatus
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DamageAndWarningStatusGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_DamageAndWarning_GetStatus", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Customer Meeting and Feedback
        /// <summary>
        /// To fill ddlContext
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingContextGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_GetAllContext", objParam);
            return ds;

        }
        /// <summary>
        /// to fill ddlMeeting type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MeetingTypeGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_GetAllMeetingType", objParam);
            return ds;
        }

        /// <summary>
        /// To fill ddl observation type in gridview client meeting in edit mode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ObservationTypeGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_GetAllObservationType", objParam);
            return ds;
        }
        ///// <summary>
        ///// To fill ddl observation type in gridview client meeting in footer
        ///// </summary>
        ///// <param name="companyCode"></param>
        ///// <returns></returns>
        //public DataSet dlMeeting_GetAllNewddlObservationType(string companyCode)
        //{
        //     
        //    
        //    
        //    SqlParameter[] objParam = new SqlParameter[1];
        //    objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
        //    DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_GetAllNewddlObservationType", objParam);
        //    return ds;
        //}
        /// <summary>
        /// Meetings the detail insert.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="dateMeetingDate">The date meeting date.</param>
        /// <param name="informationDetails">The information details.</param>
        /// <param name="informationDate">The information date.</param>
        /// <param name="customerRepresentative">The customer representative.</param>
        /// <param name="context">The context.</param>
        /// <param name="meetingType">Type of the meeting.</param>
        /// <param name="minutesOfMeeting">The minutes of meeting.</param>
        /// <param name="nextActionPlan">The next action plan.</param>
        /// <param name="nextMeetingDate">The next meeting date.</param>
        /// <param name="dataTableClientMeeting">The data table client meeting.</param>
        /// <param name="dataTableCompanyRepresentative">The data table company representative.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dataTableCompanyRepresentative</exception>
        public DataSet MeetingDetailInsert(string clientCode, string asmtId, string incidentNo, DateTime dateMeetingDate, string informationDetails, DateTime informationDate, string customerRepresentative, string context, string meetingType, string minutesOfMeeting, string nextActionPlan, string nextMeetingDate, DataTable dataTableClientMeeting, DataTable dataTableCompanyRepresentative, string modifiedBy, string locationAutoId, string status)
        {


            if (dataTableCompanyRepresentative == null || dataTableCompanyRepresentative.Rows == null)
            {
                throw new ArgumentNullException("dataTableCompanyRepresentative");
            }

            DataSet dsClientMeeting = new DataSet();
            DataSet dsRepresentative = new DataSet();
            dsClientMeeting.Locale = CultureInfo.InvariantCulture;
            dsRepresentative.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParam = new SqlParameter[15];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.MeetingDate, DL.Common.DateFormat(dateMeetingDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.InformationDetails, informationDetails);
            objParam[5] = new SqlParameter(DL.Properties.Resources.InformationDate, DL.Common.DateFormat(informationDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.CustomerRepresentative, customerRepresentative);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ContextOfMeeting, context);
            objParam[8] = new SqlParameter(DL.Properties.Resources.MeetingType, meetingType);
            objParam[9] = new SqlParameter(DL.Properties.Resources.MinutesOfMeeting, minutesOfMeeting);
            objParam[10] = new SqlParameter(DL.Properties.Resources.NextActionPlan, nextActionPlan);
            if (!string.IsNullOrEmpty(nextMeetingDate))
            {
                objParam[11] = new SqlParameter(DL.Properties.Resources.NextMeetingDate, nextMeetingDate);
            }
            else
            {
                objParam[11] = new SqlParameter(DL.Properties.Resources.NextMeetingDate, null);
            }
            objParam[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[13] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[14] = new SqlParameter(DL.Properties.Resources.Status, status);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_InsertAsmtClientMeetingHdr", objParam);
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMeetingNumber].ToString()))
                {
                    if (dataTableClientMeeting.Rows.Count > 0)
                    {
                        Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");
                        if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                        {
                            for (int i = 0; i < dataTableClientMeeting.Rows.Count; i++)
                            {
                                SqlParameter[] obj = new SqlParameter[10];
                                obj[0] = new SqlParameter(DL.Properties.Resources.ObservationType, dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldTempObservationType].ToString());
                                obj[1] = new SqlParameter(DL.Properties.Resources.Observation, dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldObservation].ToString());
                                obj[2] = new SqlParameter(DL.Properties.Resources.CorrectiveMeasures, dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldCorrectiveMeasures].ToString());
                                obj[3] = new SqlParameter(DL.Properties.Resources.MeetingNumber, ds.Tables[0].Rows[0][DL.Properties.Resources.fldMeetingNumber].ToString());
                                obj[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                obj[5] = new SqlParameter(DL.Properties.Resources.PromisedDate, DL.Common.DateFormat(dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldPromisedDate].ToString()));
                                obj[6] = new SqlParameter(DL.Properties.Resources.ActionPlanned, dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldActionPlanned].ToString());
                                obj[7] = new SqlParameter(DL.Properties.Resources.Responsibility, dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldResponsibility].ToString());
                                //Modify by  on 19-Mar-2013 Start***
                                //obj[8] = new SqlParameter(DL.Properties.Resources.ActionDate, DL.Common.DateFormat(dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldActionPlanned].ToString()));
                                if (!string.IsNullOrEmpty(dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldActionDate].ToString()))
                                {
                                    obj[8] = new SqlParameter(DL.Properties.Resources.ActionDate, DL.Common.DateFormat(dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldActionDate].ToString()));
                                }
                                else
                                {
                                    obj[8] = new SqlParameter(DL.Properties.Resources.ActionDate, null);
                                }
                                //End***
                                obj[9] = new SqlParameter(DL.Properties.Resources.Remarks, dataTableClientMeeting.Rows[i][DL.Properties.Resources.fldRemarks].ToString());
                                dsClientMeeting = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_InsertAsmtClientMeetingDtl", obj);
                            }
                        }

                    }
                    if (dataTableCompanyRepresentative.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTableCompanyRepresentative.Rows.Count; i++)
                        {
                            SqlParameter[] obj = new SqlParameter[3];
                            obj[0] = new SqlParameter(DL.Properties.Resources.MeetingNumber, ds.Tables[0].Rows[0][DL.Properties.Resources.fldMeetingNumber].ToString());
                            obj[1] = new SqlParameter(DL.Properties.Resources.OurRepresentative, dataTableCompanyRepresentative.Rows[i]["OurRepresentative"].ToString());
                            obj[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                            dsRepresentative = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_InsertAsmtClientMeetingOurRepresentativeDtl", obj);
                        }
                    }

                    if (dataTableCompanyRepresentative.Rows.Count == 0 && dataTableClientMeeting.Rows.Count == 0)
                    {
                        tx.Complete();
                        return ds;
                    }
                    else if (dataTableCompanyRepresentative.Rows.Count > 0 || dataTableClientMeeting.Rows.Count > 0)
                    {
                        if (dataTableCompanyRepresentative.Rows.Count == 0)
                        {
                            tx.Complete();
                            return dsClientMeeting; ;
                        }
                        else
                        {
                            tx.Complete();
                            return dsRepresentative;
                        }
                    }
                }
                else
                {
                    tx.Complete();
                    return ds;
                }
                tx.Complete();
            }
            return dsRepresentative;
        }
        /// <summary>
        /// To Fill gvClientMeeting Detail
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMeetingDetailGetAll(string meetingNumber, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_GetAllClientMeetingDetail", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_GetAllOurRepresentative", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_ObservationAuthorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_PlanAuthorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_ActionAuthorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_CheckPlanAuthorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.OurRepresentative, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_InsertOurRepresentative", objParam);
            return ds;
        }
        /// <summary>
        /// To update Data in gv Representative
        /// </summary>
        /// <param name="meetingNumber">The meeting number.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="employeeOldNumber">The employee old number.</param>
        /// <returns>DataSet.</returns>
        public DataSet CompanyRepresentativeUpdate(string meetingNumber, string employeeNumber, string modifiedBy, string employeeOldNumber)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.OurRepresentative, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.OldOurRepresentative, employeeOldNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_UpdateOurRepresentative", objParam);
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
            DL.Common objCommon = new DL.Common();

            actionDate = objCommon.ConvertDateToNull(actionDate);
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ObservationType, observationType);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Observation, observation);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CorrectiveMeasures, correctiveMeasures);
            objParam[3] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PromisedDate, DL.Common.DateFormat(promisedDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ActionPlanned, actionPlanned);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Responsibility, responsibility);
            //Modified by  on 19-Mar-2013 Start***
            //objParam[8] = new SqlParameter(DL.Properties.Resources.ActionDate, DL.Common.DateFormat(actionDate));
            if (!string.IsNullOrEmpty(actionDate))
            {
                objParam[8] = new SqlParameter(DL.Properties.Resources.ActionDate, actionDate);
            }
            else
            {
                objParam[8] = new SqlParameter(DL.Properties.Resources.ActionDate, null);
            }
            //End***
            objParam[9] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_InsertClientDetail", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.OurRepresentative, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_DeleteOurRepresentative", objParam);
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

            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CustomerRepersentative, customerRepresentative);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ContextOfMeeting, context);
            objParam[3] = new SqlParameter(DL.Properties.Resources.MinutesOfMeeting, minutesOfMeeting);
            objParam[4] = new SqlParameter(DL.Properties.Resources.NextActionPlan, nextActionPlan);
            if (!string.IsNullOrEmpty(nextMeetingDate))
            {
                objParam[5] = new SqlParameter(DL.Properties.Resources.NextMeetingDate, nextMeetingDate);
            }
            else
            {
                objParam[5] = new SqlParameter(DL.Properties.Resources.NextMeetingDate, null);
            }
            objParam[6] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_Update", objParam);
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
        public DataSet ClientMeetingDetailUpdate(string observationType, string observation, string correctiveMeasures, DateTime promisedDate, string actionPlanned, string responsibility, string actionDate, string remarks,  string modifiedBy, string meetingNumber, int rowId)
        {
            DL.Common objCommon = new DL.Common();

            actionDate = objCommon.ConvertDateToNull(actionDate);
            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ObservationType, observationType);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Observation, observation);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CorrectiveMeasures, correctiveMeasures);
            objParam[3] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PromisedDate, DL.Common.DateFormat(promisedDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ActionPlanned, actionPlanned);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Responsibility, responsibility);
            //Modified by  on 19-Mar-2013 Start***
            //objParam[8] = new SqlParameter(DL.Properties.Resources.ActionDate, DL.Common.DateFormat(actionDate));
            if (!string.IsNullOrEmpty(actionDate))
            {
                objParam[8] = new SqlParameter(DL.Properties.Resources.ActionDate, actionDate);
            }
            else
            {
                objParam[8] = new SqlParameter(DL.Properties.Resources.ActionDate, null);
            }
            //End***
            objParam[9] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[10] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_UpdateClientDetail", objParam);
            return ds;
        }

        /// <summary>
        /// To Delete from
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMeetingDetailDelete(string rowId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_DeleteClientMeetingDetail", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MeetingNumber, meetingNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_GetAll", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Meeting_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_GetCheckVisitType", objParam);
            return ds;
        }
        /// <summary>
        /// Function to fill ddl Observation Type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitObservationTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_GetObservationType", objParam);
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
        /// <param name="dtNightCheckDetail">The dt night check detail.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dtNightCheckDetail</exception>
        //Modify by  on 23-May-2013
        public DataSet NightCheckVisitInsert(string checkVisitType, string status, DateTime date, string timeFrom, string timeTo, string conductedBy, DataTable dtNightCheckDetail, string locationAutoId, string modifiedBy)
        {


            if (dtNightCheckDetail == null || dtNightCheckDetail.Rows == null)
            {
                throw new ArgumentNullException("dtNightCheckDetail");
            }

            DataSet ds = new DataSet();
            DataSet dsNightCheckDtl = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            dsNightCheckDtl.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitType, checkVisitType);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CheckVisitDate, DL.Common.DateFormat(date));
            objParam[3] = new SqlParameter(DL.Properties.Resources.VisitTimeFrom, DateTime.Parse(timeFrom.ToString()));
            objParam[4] = new SqlParameter(DL.Properties.Resources.VisitTimeTo, DateTime.Parse(timeTo.ToString()));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ConductedBy, conductedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_Insert", objParam);

                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][DL.Properties.Resources.fldCheckVisitNumber].ToString()))
                {
                    if (dtNightCheckDetail.Rows.Count > 0)
                    {
                        Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");
                        if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                        {
                            for (int i = 0; i < dtNightCheckDetail.Rows.Count; i++)
                            {
                                SqlParameter[] obj = new SqlParameter[11];
                                obj[0] = new SqlParameter(DL.Properties.Resources.ObservationType, dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldTempObservationType].ToString());
                                obj[1] = new SqlParameter(DL.Properties.Resources.Observation, dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldObservation].ToString());
                                obj[2] = new SqlParameter(DL.Properties.Resources.ClientCode, dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldClientCode].ToString());
                                obj[3] = new SqlParameter(DL.Properties.Resources.AsmtId, dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldAsmtId].ToString());
                                obj[4] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, ds.Tables[0].Rows[0][DL.Properties.Resources.fldCheckVisitNumber].ToString());
                                obj[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                Guard.ArgumentValidDate(dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldTimeFrom].ToString(), "myDateArgument");
                                Guard.ArgumentValidDate(dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldTimeTo].ToString(), "myDateArgument");
                                obj[6] = new SqlParameter(DL.Properties.Resources.VisitTimeFrom, DateTime.Parse(dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldTimeFrom].ToString()));
                                obj[7] = new SqlParameter(DL.Properties.Resources.VisitTimeTo, DateTime.Parse(dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldTimeTo].ToString()));
                                obj[8] = new SqlParameter(DL.Properties.Resources.ActionStatus, dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldActionStatus].ToString());
                                obj[9] = new SqlParameter(DL.Properties.Resources.ActionNumber, dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldActionNumber].ToString());
                                obj[10] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, dtNightCheckDetail.Rows[i][DL.Properties.Resources.fldEmployeeId].ToString());
                                dsNightCheckDtl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_InsertNightCheckVisitDtl", obj);
                            }
                        }
                    }
                }
                tx.Complete();
            }
            if (dtNightCheckDetail.Rows.Count > 0)
            {
                return dsNightCheckDtl;
            }
            else
            {
                return ds;
            }

        }
        /// <summary>
        /// To get all data into gv night check detail after save
        /// </summary>
        /// <param name="nightCheckVisitNumber">The night check visit number.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitDetailGetAll(string nightCheckVisitNumber)//, string companyCode, string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, nightCheckVisitNumber);
            //objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            // objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_GetAllNightCheckDtl", objParam);
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

            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ObservationType, observationType);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Observation, observation);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, checkVisitNumber);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.VisitTimeFrom, DL.Common.DateFormat(timeFrom));
            objParam[7] = new SqlParameter(DL.Properties.Resources.VisitTimeTo, DL.Common.DateFormat(newTimeTo));
            objParam[8] = new SqlParameter(DL.Properties.Resources.ActionStatus, actionStatus);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ActionNumber, checkVisitActionNo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_InsertNightCheckVisitDtl", objParam);
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

            SqlParameter[] objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ObservationType, observationType);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Observation, observation);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, checkVisitNumber);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.VisitTimeFrom, DateTime.Parse(timeFrom));
            objParam[7] = new SqlParameter(DL.Properties.Resources.VisitTimeTo, DateTime.Parse(newTimeTo));
            objParam[8] = new SqlParameter(DL.Properties.Resources.ActionStatus, actionStatus);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ActionNumber, checkVisitActionNo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[11] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_UpdateNightCheckVisitDtl", objParam);
            return ds;
        }
        /// <summary>
        /// to delete from gridview
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitDetailDelete(string rowId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_DeleteNightCheckVisitDtl", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, nightCheckNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_Authorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, nightCheckVisitNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisit_GetAll", objParam);
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
        // Modify by  on 24-May-2013 TimeFrom and TimeTo
        public DataSet NightCheckVisitUpdate(DateTime date, string timeFrom, string timeTo, string conductedBy, string locationAutoId, string modifiedBy, string nightCheckNo, string checkVisitType)
        {

            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitDate, DL.Common.DateFormat(date));
            objParam[1] = new SqlParameter(DL.Properties.Resources.VisitTimeFrom, DateTime.Parse(timeFrom));
            objParam[2] = new SqlParameter(DL.Properties.Resources.VisitTimeTo, DateTime.Parse(timeTo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ConductedBy, conductedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, nightCheckNo);
            objParam[7] = new SqlParameter(DL.Properties.Resources.CheckVisitType, checkVisitType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To Update Action Status On Authorize button Click
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionStatusUpdate(string rowId, string status)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_UpdateActionStatus", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, nightCheckNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitDetail_Amend", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, nightCheckVisitNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisit_CheckAsmtCode", objParam);
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

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, checkVisitNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_GetAll", objParam);
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

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitActionNo, checkVisitActionNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, checkVisitNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitActionDetail_GetAll", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitActionNo, checkVisitActionNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_GetDetailsAfterSave", objParam);
            return ds;
        }
        /// <summary>
        /// To Save data on button save click
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="checkVisitNumber">The check visit number.</param>
        /// <param name="dataTableNightCheckVisitAction">The data table night check visit action.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">The status.</param>
        /// <param name="date">The date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dataTableNightCheckVisitAction</exception>
        // Modify by  on 31-May-2013
        public DataSet NightCheckVisitActionInsert(string companyCode, string hrLocationCode, string locationCode, string checkVisitNumber, DataTable dataTableNightCheckVisitAction, string modifiedBy, string status, DateTime date, string clientCode, string asmtId)
        {
            if (dataTableNightCheckVisitAction == null || dataTableNightCheckVisitAction.Rows == null)
            {
                throw new ArgumentNullException("dataTableNightCheckVisitAction");
            }

            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            DL.Common objCommon = new DL.Common();
            //string actionDate;
            SqlParameter[] objParamVisitActionNo = new SqlParameter[3];
            objParamVisitActionNo[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParamVisitActionNo[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParamVisitActionNo[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_GenerateNightCheckVisitActionNumber", objParamVisitActionNo);
                string checkVisitActionNo = ds.Tables[0].Rows[0][DL.Properties.Resources.fldCheckVisitActionNo].ToString();
                if (dataTableNightCheckVisitAction.Rows.Count > 0)
                {
                    for (int i = 0; i < dataTableNightCheckVisitAction.Rows.Count; i++)
                    {
                        SqlParameter[] objParam = new SqlParameter[13];
                        objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, checkVisitNumber);
                        objParam[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                        objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
                        objParam[3] = new SqlParameter(DL.Properties.Resources.ActionPlan, dataTableNightCheckVisitAction.Rows[i][DL.Properties.Resources.fldActionPlan].ToString());
                        objParam[4] = new SqlParameter(DL.Properties.Resources.Responsible, dataTableNightCheckVisitAction.Rows[i][DL.Properties.Resources.fldResponsible].ToString());
                        if (string.IsNullOrEmpty(dataTableNightCheckVisitAction.Rows[i][DL.Properties.Resources.fldActionDates].ToString()))
                        {
                            objParam[5] = new SqlParameter(DL.Properties.Resources.ActionDt, DateTime.Now);
                        }
                        else
                        {
                            objParam[5] = new SqlParameter(DL.Properties.Resources.ActionDt, DL.Common.DateFormat(dataTableNightCheckVisitAction.Rows[i][DL.Properties.Resources.fldActionDates].ToString()));
                        }
                        objParam[6] = new SqlParameter(DL.Properties.Resources.Remarks, dataTableNightCheckVisitAction.Rows[i][DL.Properties.Resources.fldRemarks].ToString());
                        objParam[7] = new SqlParameter(DL.Properties.Resources.CheckVisitActionNo, checkVisitActionNo);
                        objParam[8] = new SqlParameter(DL.Properties.Resources.ObservationType, dataTableNightCheckVisitAction.Rows[i][DL.Properties.Resources.fldItemDesc].ToString());
                        objParam[9] = new SqlParameter(DL.Properties.Resources.CheckVisitActionDate, DL.Common.DateFormat(date));
                        objParam[10] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
                        objParam[11] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
                        objParam[12] = new SqlParameter(DL.Properties.Resources.ComplainAgainst, dataTableNightCheckVisitAction.Rows[i][DL.Properties.Resources.fldComplainAgainst].ToString());
                        ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_Insert", objParam);
                    }
                }
                tx.Complete();
            }
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, nightCheckVisitNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_CheckForNightCheckVisitNumber", objParam);
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

            DL.Common objCommon = new DL.Common();
            if (string.IsNullOrEmpty(actionDate))
            {
                actionDate = objCommon.ConvertDateToNull(objCommon.CheckDateNull(actionDate));
            }
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, Convert.ToInt32(autoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.ActionPlan, actionPlanned);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Responsible, responsibility);
            if (!string.IsNullOrEmpty(actionDate))
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.ActionDt, DL.Common.DateFormat(actionDate));
            }
            else
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.ActionDt, DateTime.Now);
            }
            objParam[4] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(date));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_UpdateNightCheckActionDtl", objParam);
            return ds;
        }
        /// <summary>
        /// Nights the check visit action update.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="checkVisitActionNo">The check visit action no.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionUpdate(DateTime date, string modifiedBy, string checkVisitActionNo)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(date));
            objParam[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CheckVisitActionNo, checkVisitActionNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_Update", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CheckVisitActionNo, checkVisitActionNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_PlanAuthorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CheckVisitActionNo, checkVisitActionNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ActionStatus, actionStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_ActionAuthorize", objParam);
            return ds;
        }
        /// <summary>
        /// Nights the check visit action detail get.
        /// </summary>
        /// <param name="checkVisitActionNumber">The check visit action number.</param>
        /// <returns>DataSet.</returns>
        public DataSet NightCheckVisitActionDetailGet(string checkVisitActionNumber)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitActionNo, checkVisitActionNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_GetDetail", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CheckVisitNo, checkVisitNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_NightCheckVisitAction_GetAllAsmtCode", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingNo, trainingNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtTrainingdtl_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TrainingNumber, trainingNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ConductedBy, conductedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Training_DeleteTrnDetails", objParam);
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

            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TrainingNumber, trainingNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ConductedBy, conductedBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AreasToBeCovered, areasCovered);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ActualTrainingDt, trainingDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.VisitTimeFrom, DL.Common.DateFormat(timeFrom));
            objParam[6] = new SqlParameter(DL.Properties.Resources.VisitTimeTo, DL.Common.DateFormat(timeTo));
            objParam[7] = new SqlParameter(DL.Properties.Resources.Hours, hours);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Training_InsertTrnDetails", objParam);
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

            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TrainingNumber, trainingNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ConductedBy, conductedBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AreasToBeCovered, areasCovered);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ActualTrainingDt, trainingDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.VisitTimeFrom, DL.Common.DateFormat(timeFrom));
            objParam[6] = new SqlParameter(DL.Properties.Resources.VisitTimeTo, DL.Common.DateFormat(timeTo));
            objParam[7] = new SqlParameter(DL.Properties.Resources.Hours, hours);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Training_UpdateTrnDetails", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingNumber, trainingNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Training_Authorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingNumber, trainingNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingType, trainingType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingDt, DL.Common.DateFormat(trainingDate));
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Training_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Assignments the training type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentTrainingTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtTraining_TrainingType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Trainings the detail insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="trainingType">Type of the training.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dataTableTrainingDetails">The data table training details.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dataTableTrainingDetails</exception>
        public DataSet TrainingDetailInsert(string locationAutoId, string trainingType, DateTime trainingDate, string asmtCode, DataTable dataTableTrainingDetails, string status, string modifiedBy)
        {
            if (dataTableTrainingDetails == null || dataTableTrainingDetails.Rows == null)
            {
                throw new ArgumentNullException("dataTableTrainingDetails");
            }

            DataSet ds = new DataSet();
            DataSet dsTrainingDetails = new DataSet();

            ds.Locale = CultureInfo.InvariantCulture;
            dsTrainingDetails.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingType, trainingType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingDt, DL.Common.DateFormat(trainingDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Training_InsertHdr", objParam);
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][DL.Properties.Resources.TrainingNumber].ToString()))
                {
                    if (dataTableTrainingDetails.Rows.Count > 0)
                    {
                        Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");
                        if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                        {
                            for (int i = 0; i < dataTableTrainingDetails.Rows.Count; i++)
                            {

                                SqlParameter[] obj = new SqlParameter[10];
                                obj[0] = new SqlParameter(DL.Properties.Resources.TrainingNumber, ds.Tables[0].Rows[0][DL.Properties.Resources.TrainingNumber].ToString());
                                obj[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldEmployeeNumber].ToString());
                                obj[2] = new SqlParameter(DL.Properties.Resources.ConductedBy, dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldConductedBy].ToString());
                                obj[3] = new SqlParameter(DL.Properties.Resources.AreasToBeCovered, dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldAreasToBeCovered].ToString());
                                Guard.ArgumentValidDate(dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldActualTrainingDate].ToString(), "myDateArgument");
                                Guard.ArgumentValidDate(dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldTimeuFrom].ToString(), "myDateArgument");
                                Guard.ArgumentValidDate(dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldTimeuTo].ToString(), "myDateArgument");
                                obj[4] = new SqlParameter(DL.Properties.Resources.ActualTrainingDt, DateTime.Parse(dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldActualTrainingDate].ToString()));
                                obj[5] = new SqlParameter(DL.Properties.Resources.VisitTimeFrom, DL.Common.DateFormat(DateTime.Parse(dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldTimeuFrom].ToString())));
                                obj[6] = new SqlParameter(DL.Properties.Resources.VisitTimeTo, DL.Common.DateFormat(DateTime.Parse(dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldTimeuTo].ToString())));
                                obj[7] = new SqlParameter(DL.Properties.Resources.Hours, dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldHours].ToString());
                                obj[8] = new SqlParameter(DL.Properties.Resources.Remarks, dataTableTrainingDetails.Rows[i][DL.Properties.Resources.fldRemarks].ToString());
                                obj[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                dsTrainingDetails = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Training_InsertTrnDetails", obj);
                            }
                        }
                    }
                }
                tx.Complete();
            }
            if (dsTrainingDetails.Tables.Count > 0 && dsTrainingDetails.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return dsTrainingDetails;
            }
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

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationReason_GetItemDesc", objParam);
            return ds;
        }

        //Modify for Upload Document by  on 25-Jun-2013
        /// <summary>
        /// Investigations the request insert.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="investigationRequest">The investigation request.</param>
        /// <param name="incidentNo">The incident no.</param>
        /// <param name="invoiceStatusId">The invoice status identifier.</param>
        /// <param name="invoiceReason">The invoice reason.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="details">The details.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationRequestInsert(string status, DateTime investigationRequest, string incidentNo, int invoiceStatusId, int invoiceReason, string employeeId, string details, string locationAutoId, string modifiedBy, DataTable dtFileUpload)
        {

            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvReqDate, DL.Common.DateFormat(investigationRequest));
            objParam[1] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.InvStatusId, invoiceStatusId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.InvReason, invoiceReason);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.InvDetails, details);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Status, status);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationRequest_Insert", objParam);

            //Added Code for Upload Document by  on 21-Jun-2013
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["InvestigationNo"].ToString()))
            {
                DataSet dsUpload = new DataSet();               
                dsUpload.Locale = CultureInfo.InvariantCulture;
                if (dtFileUpload.Rows.Count > 0)
                {
                    if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                    {
                        for (int cnt = 0; cnt < dtFileUpload.Rows.Count; cnt++)
                        {
                            SqlParameter[] objUpload = new SqlParameter[6];
                            objUpload[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, dtFileUpload.Rows[cnt]["EmployeeNumber"].ToString());
                            objUpload[1] = new SqlParameter(DL.Properties.Resources.RefNo, ds.Tables[0].Rows[0]["InvestigationNo"].ToString());
                            objUpload[2] = new SqlParameter(DL.Properties.Resources.UploadDesc, dtFileUpload.Rows[cnt]["UploadDesc"].ToString());
                            objUpload[3] = new SqlParameter(DL.Properties.Resources.FileName, dtFileUpload.Rows[cnt]["FileName"].ToString());
                            objUpload[4] = new SqlParameter(DL.Properties.Resources.UploadDate, Convert.ToDateTime(dtFileUpload.Rows[cnt]["UploadDate"]));
                            objUpload[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                            dsUpload = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Document_Upload_Download_Insert", objUpload);
                        }
                    }
                }

            }
            //End
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvestigationNo, investigationNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Investigation_GetDetailBasedOnInvestigationNo", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvestigationNo, investigationNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Investigation_GetInvestigationDetailDate", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvestigationNo, investigationNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationDetails_GetDetailBasedOnInvestigationNo", objParam);
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
        /// <param name="invoiceStatusId">The invoice status identifier.</param>
        /// <param name="invoiceReason">The invoice reason.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="details">The details.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationRequestUpdate(string investigationDate, string investigationRequestNo, string status, DateTime investigationRequest, string incidentNo, int invoiceStatusId, int invoiceReason, string employeeId, string details, string locationAutoId, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvReqNo, investigationRequestNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.InvReqDate, DL.Common.DateFormat(investigationRequest));
            objParam[3] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.InvStatusId, invoiceStatusId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.InvReason, invoiceReason);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.InvDetails, details);
            objParam[8] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[10] = new SqlParameter(DL.Properties.Resources.InvestigationDate, DL.Common.DateFormat(investigationDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationRequest_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Investigations the detail update.
        /// </summary>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="status">The status.</param>
        /// <param name="investigationDetailDate">The investigation detail date.</param>
        /// <param name="legalAssistance">The legal assistance.</param>
        /// <param name="companyInvolved">The company involved.</param>
        /// <param name="customerInvolved">The customer involved.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="findings">The findings.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailUpdate(string investigationRequestNo, string status, DateTime investigationDetailDate, int legalAssistance, int companyInvolved, int customerInvolved, string employeeId, string findings, string locationAutoId, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvReqNo, investigationRequestNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DetStatus, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.InvDetDate, DL.Common.DateFormat(investigationDetailDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.LegalAssistance, legalAssistance);
            objParam[4] = new SqlParameter(DL.Properties.Resources.WeInvolved, companyInvolved);
            objParam[5] = new SqlParameter(DL.Properties.Resources.CustInvolved, customerInvolved);
            objParam[6] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.InvFindings, findings);
            objParam[8] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationRequestDetails_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Investigations the detail authorize.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailAuthorize(string status, string investigationRequestNo, string locationAutoId, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvReqNo, investigationRequestNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationRequest_Authorize", objParam);
            return ds;
        }
        /// <summary>
        /// Investigations the details authorize.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailsAuthorize(string status, string investigationRequestNo, string locationAutoId, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvReqNo, investigationRequestNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DetStatus, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationRequestDetails_Authorize", objParam);
            return ds;
        }
        /// <summary>
        /// Investigations the detail amend.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailAmend(string status, string investigationRequestNo, string locationAutoId, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvReqNo, investigationRequestNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationRequest_AmendRecord", objParam);
            return ds;
        }
        /// <summary>
        /// Investigations the details amend.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="investigationRequestNo">The investigation request no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationDetailsAmend(string status, string investigationRequestNo, string locationAutoId, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InvReqNo, investigationRequestNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DetStatus, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationRequestDetails_AmendRecord", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Investigation Status based on incident number
        /// </summary>
        /// <param name="incidentNumber">The incident number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvestigationStatusGet(string incidentNumber, string locationAutoId, string status)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IncidentNo, incidentNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_InvestigationRequestDetails_GetStatusBasedOnIncidentnumber", objParam);
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

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstruction_ForSiteInstNo_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstruction_ForSiteInstNoHdr_Get", objParam);
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
        /// <param name="signDate">The sign date.</param>
        /// <param name="clientRepresentative">The client representative.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="reasonNotSign">The reason not sign.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">siteInstruction</exception>
        public DataSet SiteInstructionInsert(DateTime instructionDate, DateTime nextRevisionDate, string clientCode, string asmtId, string employeeNumber, DateTime prepared, int reason, int clientSignature, DateTime signDate, string clientRepresentative, string designation, string reasonNotSign, DataTable siteInstruction, string userId, int locationAutoId, string status, DataTable dtFileUpload)
        {
            if (siteInstruction == null || siteInstruction.Rows == null)
            {
                throw new ArgumentNullException("siteInstruction");
            }

            DataSet dsSiteInstruction = new DataSet();
            dsSiteInstruction.Locale = CultureInfo.InvariantCulture;

            //Added Code for Upload Document by  on 24-Jun-2013
            DataSet dsUpload = new DataSet();               
            dsUpload.Locale = CultureInfo.InvariantCulture;     
            //End

            SqlParameter[] objParam = new SqlParameter[15];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InstDate, DL.Common.DateFormat(instructionDate));
            objParam[1] = new SqlParameter(DL.Properties.Resources.NextRivDate, DL.Common.DateFormat(nextRevisionDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EmployeeId, employeeNumber);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PreparedDate, DL.Common.DateFormat(prepared));
            objParam[6] = new SqlParameter(DL.Properties.Resources.Reason, reason);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ClientSigned, clientSignature);
            objParam[8] = new SqlParameter(DL.Properties.Resources.SignDate, DL.Common.DateFormat(signDate));
            objParam[9] = new SqlParameter(DL.Properties.Resources.ClientRep, clientRepresentative);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ClientDesig, designation);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ReasonNotSign, reasonNotSign);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParam[13] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[14] = new SqlParameter(DL.Properties.Resources.Status, status);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SiteInstruction_AsmtSiteInstHdr_Insert", objParam);
                if (siteInstruction.Rows.Count > 0)
                {
                    Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");
                    if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                    {
                        for (int i = 0; i < siteInstruction.Rows.Count; i++)
                        {
                            SqlParameter[] obj = new SqlParameter[4];
                            obj[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, ds.Tables[0].Rows[0]["SiteInstNo"].ToString());
                            obj[1] = new SqlParameter(DL.Properties.Resources.InstructionTypeID, siteInstruction.Rows[i]["InstructionTypeID"].ToString());
                            obj[2] = new SqlParameter(DL.Properties.Resources.SiteInstruction, siteInstruction.Rows[i]["SiteInstruction"].ToString());
                            obj[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
                            dsSiteInstruction = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SiteInstruction_AsmtSiteInstDtl_Insert", obj);
                        }
                    }
                    //Added for Document Upload by  on 24-Jun-2013
                    if (dtFileUpload.Rows.Count > 0)
                    {
                        if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                        {
                            for (int cnt = 0; cnt < dtFileUpload.Rows.Count; cnt++)
                            {
                                SqlParameter[] objUpload = new SqlParameter[6];
                                objUpload[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, dtFileUpload.Rows[cnt]["EmployeeNumber"].ToString());
                                objUpload[1] = new SqlParameter(DL.Properties.Resources.RefNo, ds.Tables[0].Rows[0]["SiteInstNo"].ToString());
                                objUpload[2] = new SqlParameter(DL.Properties.Resources.UploadDesc, dtFileUpload.Rows[cnt]["UploadDesc"].ToString());
                                objUpload[3] = new SqlParameter(DL.Properties.Resources.FileName, dtFileUpload.Rows[cnt]["FileName"].ToString());
                                objUpload[4] = new SqlParameter(DL.Properties.Resources.UploadDate, Convert.ToDateTime(dtFileUpload.Rows[cnt]["UploadDate"]));
                                objUpload[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
                                dsUpload = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Document_Upload_Download_Insert", objUpload);
                            }
                        }
                    }
                    //End
                }
                tx.Complete();
            }
            return dsSiteInstruction;
        }

        /// <summary>
        /// Sites the instruction bulk insert.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">siteInstruction</exception>
        public DataSet SiteInstructionBulkInsert(string siteInstructionNo, DataTable siteInstruction, string userId)
        {
            if (siteInstruction == null || siteInstruction.Rows == null)
            {
                throw new ArgumentNullException("siteInstruction");
            }

            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            if (siteInstruction.Rows.Count > 0)
            {
                for (int i = 0; i < siteInstruction.Rows.Count; i++)
                {
                    SqlParameter[] obj = new SqlParameter[4];
                    obj[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
                    obj[1] = new SqlParameter(DL.Properties.Resources.InstructionTypeID, siteInstruction.Rows[i]["InstructionTypeID"].ToString());
                    obj[2] = new SqlParameter(DL.Properties.Resources.SiteInstruction, siteInstruction.Rows[i]["SiteInstruction"].ToString());
                    obj[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SiteInstruction_AsmtSiteInstDtl_Insert", obj);
                }
            }
            return ds;
        }

        //Modify by  on 18-Mar-2013
        //public DataSet SiteInstructionDetailInsert(String siteInstructionNo, int siteInstructionTypeId, string siteInstruction, string userId)
        //{

        //    DataSet dsSiteInstruction = new DataSet();
        //    dsSiteInstruction.Locale = CultureInfo.InvariantCulture;

        //    SqlParameter[] objParam = new SqlParameter[4];
        //    objParam[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
        //    objParam[1] = new SqlParameter(DL.Properties.Resources.InstructionTypeID, siteInstructionTypeId);
        //    objParam[2] = new SqlParameter(DL.Properties.Resources.SiteInstruction, siteInstruction);
        //    objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
        //    DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SiteInstruction_AsmtSiteInstDtl_Insert", objParam);
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

            DataSet dsSiteInstruction = new DataSet();
            dsSiteInstruction.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.InstructionTypeID, siteInstructionTypeId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SiteInstruction, siteInstruction);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SiteInstruction_AsmtSiteInstDtl_Insert", objParam);
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
        /// <param name="signDate">The sign date.</param>
        /// <param name="clientRepresentative">The client representative.</param>
        /// <param name="designation">The designation.</param>
        /// <param name="reasonNotSign">The reason not sign.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionUpdate(string siteInstructionNo, DateTime instructionDate, DateTime nextRevisionDate, string clientCode, string asmtId, string employeeNumber, DateTime prepared, int reason, int clientSignature, DateTime signDate, string clientRepresentative, string designation, string reasonNotSign, string userId, int locationAutoId, string status)
        {

            SqlParameter[] objParam = new SqlParameter[16];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.InstDate, DL.Common.DateFormat(instructionDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.NextRivDate, DL.Common.DateFormat(nextRevisionDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.EmployeeId, employeeNumber);
            objParam[6] = new SqlParameter(DL.Properties.Resources.PreparedDate, DL.Common.DateFormat(prepared));
            objParam[7] = new SqlParameter(DL.Properties.Resources.Reason, reason);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ClientSigned, clientSignature);
            objParam[9] = new SqlParameter(DL.Properties.Resources.SignDate, DL.Common.DateFormat(signDate));
            objParam[10] = new SqlParameter(DL.Properties.Resources.ClientRep, clientRepresentative);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ClientDesig, designation);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ReasonNotSign, reasonNotSign);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParam[14] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[15] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SiteInstruction_AsmtSiteInstHdr_Update", objParam);
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

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.InstructionTypeID, instructionTypeId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SiteInstruction, instruction);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstructionDtl_Update", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SiteInstruction_Authorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationID, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SiteInstruction_Amend", objParam);
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

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstructionDtl_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// Sites the instruction detail bulk delete.
        /// </summary>
        /// <param name="siteInstructionNo">The site instruction no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionDetailBulkDelete(string siteInstructionNo)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SiteInstNo, siteInstructionNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstructionDtlBulk_Delete", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_PDAddress_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_SoLineDet_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SOLineSkills_Get", objParam);
            return ds;
        }
        /// <summary>
        /// MPSs the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSProcess_MPSType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// MPSs the deployment type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsDeploymentTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSDeploymentType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// MPSs the status get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsStatusGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSProcess_MPSStatus_Get", objParam);
            return ds;
        }
        /// <summary>
        /// MPSs the reason for removal get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsReasonForRemovalGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSReasonForRemoval_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSFooterLines_BasedOnAsmtCode_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSFooterDetailsBasedonAmendNo_Get", objParam);
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
        /// <param name="dataTableMpsDetails">The data table MPS details.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsHeaderInsert(string locationAutoId, string mpsType, DateTime dateOfCreation, string asmtCode, string mpsAmendNo, string amendmentDate, string amendBy, string status, DataTable dataTableMpsDetails, string modifiedBy)
        {

            Guard.ArgumentNotNull(dataTableMpsDetails, "MpsDetails");
            Guard.ArgumentNotNull(dataTableMpsDetails.Rows, "MpsDetails");

            DataSet ds = new DataSet();
            DataSet dsMPSDetails = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            dsMPSDetails.Locale = CultureInfo.InvariantCulture;

            //Boolean flag = new Boolean();
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSType, mpsType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DateOfCreation, DL.Common.DateFormat(dateOfCreation));
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            if (string.IsNullOrEmpty(amendmentDate))
            {
                objParam[5] = new SqlParameter(DL.Properties.Resources.AmendmentDate, null);
            }
            else
            {
                objParam[5] = new SqlParameter(DL.Properties.Resources.AmendmentDate, DL.Common.DateFormat(amendmentDate));
            }
            objParam[6] = new SqlParameter(DL.Properties.Resources.AmendBy, amendBy);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_Inserthdr", objParam);
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMPSAutoId].ToString()))
                {
                    if (dataTableMpsDetails.Rows.Count > 0)
                    {
                        Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");
                        if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                        {
                            for (int i = 0; i < dataTableMpsDetails.Rows.Count; i++)
                            {
                                SqlParameter[] obj = new SqlParameter[22];
                                obj[0] = new SqlParameter(DL.Properties.Resources.MPSAutoId, ds.Tables[0].Rows[0][DL.Properties.Resources.fldMPSAutoId].ToString());
                                obj[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldEmployeeNumber].ToString());
                                obj[2] = new SqlParameter(DL.Properties.Resources.DeploymentType, int.Parse("0"));
                                if (string.IsNullOrEmpty(dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldIDate].ToString()))
                                {
                                    obj[3] = new SqlParameter(DL.Properties.Resources.IntroductionDate, null);
                                }
                                else
                                {
                                    Guard.ArgumentValidDate(dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldIDate].ToString(), "myDateArgument");
                                    obj[3] = new SqlParameter(DL.Properties.Resources.IntroductionDate, DL.Common.DateFormat(DateTime.Parse(dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldIDate].ToString())));
                                }
                                obj[4] = new SqlParameter(DL.Properties.Resources.IntroducedBy, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldIntroBy].ToString());
                                obj[5] = new SqlParameter(DL.Properties.Resources.InterviewedBy, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldInterviewedBy].ToString());
                                obj[6] = new SqlParameter(DL.Properties.Resources.Designation, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldInterviewedbyDesignation].ToString());
                                obj[7] = new SqlParameter(DL.Properties.Resources.Result, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldResult].ToString());
                                obj[8] = new SqlParameter(DL.Properties.Resources.InterviewRemarks, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldInterviewRemarks].ToString());
                                obj[9] = new SqlParameter(DL.Properties.Resources.SONO, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldSoNo].ToString());
                                obj[10] = new SqlParameter(DL.Properties.Resources.SoLineNo, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldSoLineNo].ToString());
                                obj[11] = new SqlParameter(DL.Properties.Resources.PDLineNo, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldPDLineNo].ToString());
                                obj[12] = new SqlParameter(DL.Properties.Resources.DeploymentDate, null);
                                obj[13] = new SqlParameter(DL.Properties.Resources.DeploymentTime, null);
                                obj[14] = new SqlParameter(DL.Properties.Resources.ToDate, null);
                                obj[15] = new SqlParameter(DL.Properties.Resources.ToTime, null);
                                obj[16] = new SqlParameter(DL.Properties.Resources.RemovalDate, null);
                                //obj[17] = new SqlParameter(DL.Properties.Resources.ReasonForRemoval, dataTableMpsDetails.Rows[i]["RemovalReason"].ToString());
                                obj[17] = new SqlParameter(DL.Properties.Resources.ReasonForRemoval, int.Parse("0"));
                                obj[18] = new SqlParameter(DL.Properties.Resources.Remarks, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldRemarks].ToString());
                                //obj[19] = new SqlParameter(DL.Properties.Resources.Status, dataTableMpsDetails.Rows[i]["Status"].ToString());
                                obj[19] = new SqlParameter(DL.Properties.Resources.MPSLineNo, dataTableMpsDetails.Rows[i][DL.Properties.Resources.fldMPSLineNO].ToString());
                                obj[20] = new SqlParameter(DL.Properties.Resources.Status, int.Parse("0"));
                                obj[21] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                dsMPSDetails = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_Insertdtl", obj);
                            }
                        }
                    }
                }
                tx.Complete();
            }
            if (dsMPSDetails.Tables.Count > 0 && dsMPSDetails.Tables[0].Rows.Count > 0)
            {
                return dsMPSDetails;
            }
            else
            {
                return ds;
            }

        }
        /// <summary>
        /// MPSs the detail get.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsDetailGet(string mpsNo)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSDetails_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSDetailsBasedonAmendNo_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[23];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.MPSLineNo, mpsLineNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.DeploymentType, deploymentType);
            if (!string.IsNullOrEmpty(introductionDate))
            {
                objParam[5] = new SqlParameter(DL.Properties.Resources.IntroductionDate, DL.Common.DateFormat(introductionDate));
            }
            else
            {
                objParam[5] = new SqlParameter(DL.Properties.Resources.IntroductionDate, DBNull.Value);
            }
            objParam[6] = new SqlParameter(DL.Properties.Resources.IntroducedBy, introducedBy);
            objParam[7] = new SqlParameter(DL.Properties.Resources.InterviewedBy, interviewedBy);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Designation, designation);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Result, result);
            objParam[10] = new SqlParameter(DL.Properties.Resources.InterviewRemarks, interviewRemarks);
            objParam[11] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[12] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[13] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            if (!string.IsNullOrEmpty(deploymentDate))
            {
                objParam[14] = new SqlParameter(DL.Properties.Resources.DeploymentDate, DL.Common.DateFormat(deploymentDate));
            }
            else
            {
                objParam[14] = new SqlParameter(DL.Properties.Resources.DeploymentDate, DBNull.Value);
            }
            if (!string.IsNullOrEmpty(deploymentTime))
            {
                objParam[15] = new SqlParameter(DL.Properties.Resources.DeploymentTime, DL.Common.DateFormat(deploymentTime));
            }
            else
            {
                objParam[15] = new SqlParameter(DL.Properties.Resources.DeploymentTime, DBNull.Value);

            }
            if (!string.IsNullOrEmpty(toDate))
            {
                objParam[16] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            }
            else
            {
                objParam[16] = new SqlParameter(DL.Properties.Resources.ToDate, DBNull.Value);
            }

            if (!string.IsNullOrEmpty(toTime))
            {
                objParam[17] = new SqlParameter(DL.Properties.Resources.ToTime, DL.Common.DateFormat(toTime));
            }
            else
            {
                objParam[17] = new SqlParameter(DL.Properties.Resources.ToTime, DBNull.Value);
            }
            if (removalDate != null)
            {

                objParam[18] = new SqlParameter(DL.Properties.Resources.RemovalDate, DL.Common.DateFormat(removalDate));
            }
            else
            {
                objParam[18] = new SqlParameter(DL.Properties.Resources.RemovalDate, DBNull.Value);
            }
            objParam[19] = new SqlParameter(DL.Properties.Resources.ReasonForRemoval, reasonForRemoval);
            objParam[20] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[21] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSDtl_Save", objParam);
            return ds;
        }
        /// <summary>
        /// MPSs the authorize.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsAuthorize(string mpsNo, string mpsAmendNo, string locationAutoId, string asmtCode, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_Authorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AmendBy, amendBy);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_Amend", objParam);
            return ds;
        }
        /// <summary>
        /// MPSs the terminate.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <param name="mpsAmendNo">The MPS amend no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="terminatedBy">The terminated by.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsTerminate(string mpsNo, string mpsAmendNo, string locationAutoId, string terminatedBy, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AmendBy, terminatedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_Terminate", objParam);
            return ds;
        }
        /// <summary>
        /// MPSs the maximum amend number get.
        /// </summary>
        /// <param name="mpsNo">The MPS no.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsMaximumAmendNumberGet(string mpsNo)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_MaxAmendNo_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPS_FooterLine_SONO_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DeploymentType, deploymentType);
            objParam[4] = new SqlParameter(DL.Properties.Resources.IntroductionDate, DL.Common.DateFormat(introductionDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.IntroducedBy, introducedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[7] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[8] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSFtrDtl_Save", objParam);
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
        /// <param name="authorizedStatus">The authorized status.</param>
        /// <param name="resultAuthorizedId">The result authorized identifier.</param>
        /// <param name="resultAuthorizedStatus">The result authorized status.</param>
        /// <param name="removalAuthorizedId">The removal authorized identifier.</param>
        /// <param name="removalAuthorizedStatus">The removal authorized status.</param>
        /// <param name="reasonForRemoval">The reason for removal.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MpsMoveDetailInsert(string mpsNo, string mpsAmendNo, string mpsLineNo, string employeeNumber, string deploymentType, string introductionDate, string introducedBy, string status, string authorizedStatus, string resultAuthorizedId, string resultAuthorizedStatus, string removalAuthorizedId, string removalAuthorizedStatus, string reasonForRemoval, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[15];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.MPSLineNo, mpsLineNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.DeploymentType, deploymentType);
            objParam[5] = new SqlParameter(DL.Properties.Resources.IntroductionDate, DL.Common.DateFormat(introductionDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.IntroducedBy, introducedBy);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[8] = new SqlParameter(DL.Properties.Resources.IntroAuthorizedStatus, authorizedStatus);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ResultAuthorizedId, resultAuthorizedId);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ResultAuthorizedStatus, resultAuthorizedStatus);
            objParam[11] = new SqlParameter(DL.Properties.Resources.RemovalAuthorizedId, removalAuthorizedId);
            objParam[12] = new SqlParameter(DL.Properties.Resources.RemovalAuthorizedStatus, removalAuthorizedStatus);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ReasonForRemoval, reasonForRemoval);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSMoveDtl_Save", objParam);
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

            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.MPsNo, mpsNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.MPSAmendNo, mpsAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DeploymentType, deploymentType);
            objParam[4] = new SqlParameter(DL.Properties.Resources.IntroductionDate, DL.Common.DateFormat(introductionDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.IntroducedBy, introducedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[7] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[8] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_MPSFtrMoveDtl_Save", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DesignChangeNo, designChangeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_GetAllObservationDetail", objParam);
            return ds;
        }
        /// <summary>
        /// to fill ddl Sensitivity
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewSensitivityGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_GetSensitivity", objParam);
            return ds;
        }
        /// <summary>
        /// to fill ddl Design Type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_GetDesignType", objParam);
            return ds;
        }
        /// <summary>
        /// to fill ddl reason for review
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewReasonGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_GetReasonForReview", objParam);
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

            DL.Common objCommon = new DL.Common();
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DesignChangeNo, designChangeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Observation, observation);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Recommendation, recommendation);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Sensitivity, sensitivity);
            if (string.IsNullOrEmpty(implementationDate))
            {
                objParam[4] = new SqlParameter(DL.Properties.Resources.ImplementationDate, objCommon.ConvertDateToNull(objCommon.CheckDateNull(implementationDate)));
            }
            else
            {
                objParam[4] = new SqlParameter(DL.Properties.Resources.ImplementationDate, DL.Common.DateFormat(implementationDate));
            }
            objParam[5] = new SqlParameter(DL.Properties.Resources.ReasonForPending, reasonForPending);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_InsertObservationDetail", objParam);
            return ds;
        }
        /// <summary>
        /// To delete data from gridview after save
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SecurityDesignReviewObservationDetailDelete(string rowId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_DeleteObservationDetail", objParam);
            return ds;
        }
        /// <summary>
        /// Securities the design review insert.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="status">The status.</param>
        /// <param name="dateOfReport">The date of report.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="designType">Type of the design.</param>
        /// <param name="conductedBy">The conducted by.</param>
        /// <param name="reasonForReview">The reason for review.</param>
        /// <param name="dataTableObservationDetail">The data table observation detail.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="dtFileUpload">The dt file upload.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dataTableObservationDetail</exception>
        public DataSet SecurityDesignReviewInsert(DateTime date, string status, DateTime dateOfReport, string clientCode, string asmtId, string designType, string conductedBy, string reasonForReview, DataTable dataTableObservationDetail, string locationAutoId, string modifiedBy, DataTable dtFileUpload)
        {
            if (dataTableObservationDetail == null || dataTableObservationDetail.Rows == null)
            {
                throw new ArgumentNullException("dataTableObservationDetail");
            }

            DataSet ds = new DataSet();
            DataSet dsObservationDtl = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            dsObservationDtl.Locale = CultureInfo.InvariantCulture;

            //Added Code for Upload Document by  on 25-Jun-2013
            DataSet dsUpload = new DataSet();
            dsUpload.Locale = CultureInfo.InvariantCulture;
            //End
            DL.Common objCommon = new DL.Common();
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DesignChangeDate, DL.Common.DateFormat(date));
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ReportingDate, DL.Common.DateFormat(dateOfReport));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.DesignType, designType);
            objParam[6] = new SqlParameter(DL.Properties.Resources.RequestIdentifiedBy, conductedBy);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ReasonForReview, reasonForReview);
            objParam[8] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_Insert", objParam);
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0][DL.Properties.Resources.fldDesignChangeNo].ToString()))
                {
                    if (dataTableObservationDetail.Rows.Count > 0)
                    {
                        Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");
                        if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                        {
                            for (int i = 0; i < dataTableObservationDetail.Rows.Count; i++)
                            {
                                SqlParameter[] obj = new SqlParameter[7];
                                obj[0] = new SqlParameter(DL.Properties.Resources.DesignChangeNo, ds.Tables[0].Rows[0][DL.Properties.Resources.fldDesignChangeNo].ToString());
                                obj[1] = new SqlParameter(DL.Properties.Resources.Observation, dataTableObservationDetail.Rows[i][DL.Properties.Resources.fldObservation].ToString());
                                obj[2] = new SqlParameter(DL.Properties.Resources.Recommendation, dataTableObservationDetail.Rows[i][DL.Properties.Resources.fldRecommendation].ToString());
                                obj[3] = new SqlParameter(DL.Properties.Resources.Sensitivity, dataTableObservationDetail.Rows[i][DL.Properties.Resources.fldTempSensitivity].ToString());
                                obj[4] = new SqlParameter(DL.Properties.Resources.ImplementationDate, dataTableObservationDetail.Rows[i][DL.Properties.Resources.fldImplementationDate].ToString());
                                obj[5] = new SqlParameter(DL.Properties.Resources.ReasonForPending, dataTableObservationDetail.Rows[i][DL.Properties.Resources.fldReasonForPending].ToString());
                                obj[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                dsObservationDtl = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_InsertObservationDetail", obj);
                            }
                        }
                        //Added for Document Upload by  on 25-Jun-2013
                        if (dtFileUpload.Rows.Count > 0)
                        {
                            if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0)
                            {
                                for (int cnt = 0; cnt < dtFileUpload.Rows.Count; cnt++)
                                {
                                    SqlParameter[] objUpload = new SqlParameter[6];
                                    objUpload[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, dtFileUpload.Rows[cnt]["EmployeeNumber"].ToString());
                                    objUpload[1] = new SqlParameter(DL.Properties.Resources.RefNo, ds.Tables[0].Rows[0][DL.Properties.Resources.fldDesignChangeNo].ToString());
                                    objUpload[2] = new SqlParameter(DL.Properties.Resources.UploadDesc, dtFileUpload.Rows[cnt]["UploadDesc"].ToString());
                                    objUpload[3] = new SqlParameter(DL.Properties.Resources.FileName, dtFileUpload.Rows[cnt]["FileName"].ToString());
                                    objUpload[4] = new SqlParameter(DL.Properties.Resources.UploadDate, Convert.ToDateTime(dtFileUpload.Rows[cnt]["UploadDate"]));
                                    objUpload[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                    dsUpload = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Document_Upload_Download_Insert", objUpload);
                                }
                            }
                        }
                        //End
                    }
                }
                tx.Complete();
            }
            if (dataTableObservationDetail.Rows.Count > 0)
            {
                return dsObservationDtl;
            }
            else
            {
                return ds;
            }
        }

        /// <summary>
        /// Securities the design review update.
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

            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DesignChangeNo, designChangeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DesignChangeDate, DL.Common.DateFormat(date));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ReportingDate, DL.Common.DateFormat(dateOfReport));
            objParam[4] = new SqlParameter(DL.Properties.Resources.RequestIdentifiedBy, conductedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ReasonForReview, reasonForReview);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[8] = new SqlParameter(DL.Properties.Resources.DesignType, designType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_Update", objParam);
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

            DL.Common objCommon = new DL.Common();
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Observation, observation);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Recommendation, recommendation);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Sensitivity, sensitivity);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ImplementationDate, implementationDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ReasonForPending, reasonForPending);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.RowId, rowId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_UpdateObservationDetail", objParam);
            return ds;
        }

        /// <summary>
        /// Securities the design review observation authorize.
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

            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DesignChangeNo, designChangeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DesignChangeDate, DL.Common.DateFormat(date));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ReportingDate, DL.Common.DateFormat(dateOfReport));
            objParam[4] = new SqlParameter(DL.Properties.Resources.RequestIdentifiedBy, conductedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ReasonForReview, reasonForReview);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_ObservationAuthorize", objParam);
            return ds;
        }
        /// <summary>
        /// Securities the design review action authorize.
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

            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DesignChangeNo, designChangeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DesignChangeDate, DL.Common.DateFormat(date));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ReportingDate, DL.Common.DateFormat(dateOfReport));
            objParam[4] = new SqlParameter(DL.Properties.Resources.RequestIdentifiedBy, conductedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ReasonForReview, reasonForReview);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_ActionAuthorize", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DesignChangeNo, designChangeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_Amend", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DesignChangeNo, designChangeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SecurityDesignReview_GetAll", objParam);
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

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtAmendNo, asmtAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_OPSAsmtOTDetails_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Asmts the overtime detail update.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="asmtAmendNo">The asmt amend no.</param>
        /// <param name="normalHrs">The normal HRS.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtOvertimeDetailUpdate(string asmtCode, int asmtAmendNo, int normalHrs)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtAmendNo, asmtAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.NormalHrs, normalHrs);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_OPSAsmtOTDetails_Update", objParam);
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
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaInch">The area inch.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDeploymentGetAll(string locationCode, string hrLocationCode, string companyCode, string areaId, string areaInch)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaInch);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpRpt_Deployment_Client_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Asmts the deployment get all.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaInch">The area inch.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtDeploymentGetAll(string locationCode, string hrLocationCode, string companyCode, string areaId, string areaInch, string clientCode)
        {

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaInch);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpRpt_Deployment_AsmtCode_Get", objParam);
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

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOps_SaleOrderNumber_GetByPdLineNo", objParam);
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

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtPreferredEmployees_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// Asmts the employee preferences insert.
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

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EmployeeSiteType, employeeSiteType);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtEmployeePreferances_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// Asmts the employee preferences delete.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtEmployeePreferencesDelete(string clientCode, string asmtId, string postCode, string employeeNumber)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtEmployeePreferances_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// Asmts the employee preferences update.
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

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EmployeeSiteType, employeeSiteType);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtEmployeePreferances_Update", objParam);
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
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, fromdate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPSAsmtsOfClientForFutureDateRotaGet", objParm);
            return ds;
        }
        #endregion
        
        #region Functions Related to Swap Duty
        /// <summary>
        /// To Get Assignment of Clients
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromdate">The fromdate.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientGet(int locationAutoId, String clientCode, String fromdate, String toDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FromDate, fromdate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtsOfClient_ForSwapDutyGet", objParm);
            return ds;
        }
        #endregion


        // Sync Secure trax


        /// <summary>
        /// Dls the asmt post code get all.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlAsmtPostCodeGetAll(string clientCode, string asmtId, string locationAutoID, string fromDate, string toDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoID);
            objParam[3] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_GetAllPost", objParam);
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
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_GetClient", objParam);
            return ds;
        }
        //End

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
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RefNo, refNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Document_Upload_DownloadGetAll", objParam);
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
            //Added for Document Upload by  on 21-Jun-2013
            DataSet dsUpload = new DataSet();
            if (dtFileUpload.Rows.Count > 0)
            {
                for (int cnt = 0; cnt < dtFileUpload.Rows.Count; cnt++)
                {
                    SqlParameter[] objUpload = new SqlParameter[6];
                    objUpload[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, dtFileUpload.Rows[cnt]["EmployeeNumber"].ToString());
                    objUpload[1] = new SqlParameter(DL.Properties.Resources.RefNo, dtFileUpload.Rows[cnt]["RefNo"].ToString());
                    objUpload[2] = new SqlParameter(DL.Properties.Resources.UploadDesc, dtFileUpload.Rows[cnt]["UploadDesc"].ToString());
                    objUpload[3] = new SqlParameter(DL.Properties.Resources.FileName, dtFileUpload.Rows[cnt]["FileName"].ToString());
                    objUpload[4] = new SqlParameter(DL.Properties.Resources.UploadDate, Convert.ToDateTime(dtFileUpload.Rows[cnt]["UploadDate"]));
                    objUpload[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                    dsUpload = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Document_Upload_Download_Insert", objUpload);
                }
            }
            return dsUpload;
            //End
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
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RefNo, refNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_Document_Upload_Download_Delete", objParam);
            return ds;
        }

        #endregion
        //End
        #endregion

        #region Function related to Employee Card Mapping
        public DataSet GetEmployeeCardMapping(string CompanyCode, string ddlSelect, string txtSearch)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FilterParam, ddlSelect);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Value, txtSearch);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Ops_EmpCardMapping", objParam);
            return ds;
        }
        public DataSet EmployeeCardMappingInsert(string CompanyCode, string employeeeNumber, string employeeCardNumber, string ModifiedBy, int ID, string effectiveFromDate, string effectiveToDate)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeCardNo, employeeCardNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CardEmpMappingAutoId, ID);
            objParam[5] = new SqlParameter(DL.Properties.Resources.FromDate, Common.DateFormat(effectiveFromDate, true));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ToDate, Common.DateFormat(effectiveToDate, true));


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Ops_EmpCardMappingInsert", objParam);
            return ds;
        }
        public DataSet EmployeeCardMappingDelete(int ID, string cardNumber)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CardEmpMappingAutoId, ID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeCardNo, cardNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Ops_EmpCardMappingDelete", objParam);
            return ds;
        }
        #endregion
    }
}
