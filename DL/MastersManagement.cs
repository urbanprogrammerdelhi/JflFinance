// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="MastersManagement.cs" company="Magnon">
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
    /// Class MastersManagement.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class MastersManagement
    {
        #region Function Related To Company

        #region Function related to get data

        /// <summary>
        /// To get the All Companies
        /// </summary>
        /// <returns>Dataset with CompanyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet CompanyGetAll()
        {



            DataSet ds = SqlHelper.ExecuteDataset("udpMst_Companies4SA_GetAll");
            return ds;
        }
        /// <summary>
        /// To get the All Companies
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with CompanyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet CompanyGetAll(String userId)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Companies_GetAll", objParm);
            return ds;
        }

        /// <summary>
        /// To get the All Companies
        /// </summary>
        /// <returns>Dataset with CompanyCode, CompanyDesc</returns>
        public DataSet CompanyDescriptionGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset("udpMst_Companies_GetAllCodeDesc");
            return ds;
        }
        /// <summary>
        /// To get the Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with CompanyCode, CompanyDesc</returns>
        public DataSet CompanyDescriptionGet(String companyCode)
        {


            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Companies_GetCodeDescOfComp", objParm);
            return ds;
        }

        /// <summary>
        /// To get the Company Details for CompanyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with CompanyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet CompanyDetailsGet(String companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Company_Detail_Get", objParm);
            return ds;
        }
        #endregion

        #region Function related to add new data
        /// <summary>
        /// To add a new Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="companyDesc">The company desc.</param>
        /// <param name="companyAddress">The company address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet CompanyAddNew(string companyCode, string companyDesc, string companyAddress, string userId)
        {


            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyDesc, companyDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyAddress, companyAddress);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Companies_Insert", objParm);
            return ds;
        }
        #endregion

        #region Function related to Update data
        /// <summary>
        /// To Update Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="companyDesc">The company desc.</param>
        /// <param name="companyAddress">The company address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet CompanyDescriptionUpdate(string companyCode, string companyDesc, string companyAddress, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyDesc, companyDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyAddress, companyAddress);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Companies_Update", objParm);
            return ds;
        }
        #endregion

        #region Function To Insert Data Branch based
        /// <summary>
        /// To insert Holiday Data in all branches choosed by combo
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="branch">The branch.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>

        public DataSet HolidayAllBranchesInsert(string companyCode, string locationAutoId, string branch, string modifiedBy)
        {

            SqlParameter[] Objparam = new SqlParameter[4];
            Objparam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            Objparam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            Objparam[2] = new SqlParameter(DL.Properties.Resources.BranchCode, branch);
            Objparam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_Holiday_InsertAllBranches", Objparam);
            return ds;

        }
        #endregion

        #region Function related to Delete data
        /// <summary>
        /// To Delete a Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>message string</returns>
        public DataSet CompanyDelete(string companyCode)
        {



            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Companies_Delete", objParm);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To Role Master

        #region  Function Related To GetData
        /// <summary>
        /// To get the RoleCode and Description for a Company from RoleMaster
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>RoleCode,RoleDesc in dataset</returns>
        public DataSet RoleMasterGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_RoleMaster_Get", objParam);
            return ds;
        }
        #endregion

        #region Function Related To Insert Data
        /// <summary>
        /// To Add a Role in RoleMaster
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="roleDesc">The role desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleMasterAddNew(string companyCode, string roleCode, string roleDesc, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.RoleDesc, roleDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_RoleMaster_Add", objParam);
            return ds;
        }

        #endregion

        #region Function related to Update Data
        /// <summary>
        /// To Update a RoleCode in RoleMaster
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="roleDesc">The role desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleMasterUpdate(string companyCode, string roleCode, string roleDesc, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.RoleDesc, roleDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_RoleMaster_Update", objParam);
            return ds;
        }

        #endregion

        #region Function related To Delete Data
        /// <summary>
        /// To Delete a role From RoleMaster
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="roleCode">The role code.</param>
        /// <returns>DataSet.</returns>

        public DataSet RoleMasterDelete(string companyCode, string roleCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_RoleMaster_Delete", objParam);
            return ds;
        }
        #endregion

        #region Function Related To Role Details

        #region  Function Related To GetData
        /// <summary>
        /// To get RoleCode Effective dates and Rates from mstRoleRate
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="roleCode">The role code.</param>
        /// <returns>DataSet.</returns>

        public DataSet RoleDetailGet(string locationAutoId, string roleCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_RoleDetails_Get", objParam);
            return ds;
        }
        #endregion

        #region Function Related To Update
        /// <summary>
        /// To Update the mstRoleRate
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="roleCode">The role code.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="rate">The rate.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>

        public DataSet RoleDetailUpdate(string locationAutoId, string roleCode, string effectiveFrom, string effectiveTo, string rate, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[6];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.RoleCode, roleCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            if (string.IsNullOrEmpty(effectiveTo))
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DBNull.Value);
            }
            else
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            }
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rate, rate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_RoleDetails_Update", objParam);
            return ds;
        }

        #endregion


        #endregion

        #endregion
        #region Function Related To Task Master

        #region  Function Related To GetData
        /// <summary>
        /// To get the TaskAutoId and Description for a Location from TaskMaster
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>TaskAutoId,TaskDesc in dataset</returns>
        public DataSet TaskMasterGet(string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_TaskMaster_Get", objParam);
            return ds;
        }
        #endregion

        #region Function Related To Insert Data
        /// <summary>
        /// To Add a Task in TaskMaster
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="taskDesc">The task desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TaskMasterAddNew(string locationAutoId, string taskDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TaskDesc, taskDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_TaskMaster_Add", objParam);
            return ds;
        }

        #endregion

        #region Function related to Update Data
        /// <summary>
        /// To Update a Task in TaskMaster
        /// </summary>
        /// <param name="taskAutoId">The task automatic identifier.</param>
        /// <param name="taskDesc">The task desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TaskMasterUpdate(string taskAutoId, string taskDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TaskAutoId, taskAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TaskDesc, taskDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_TaskMaster_Update", objParam);
            return ds;
        }

        #endregion

        #region Function related To Delete Data
        /// <summary>
        /// To Delete a Task From TaskMaster
        /// </summary>
        /// <param name="taskAutoId">The task automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TaskMasterDelete(string taskAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TaskAutoId, taskAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_TaskMaster_Delete", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To HrLocation

        #region Function related to get data

        /// <summary>
        /// To get the All HrLocation
        /// </summary>
        /// <returns>Dataset with HrLocationAutoID, CompanyCode, CompanyDesc, HrLocationCode, HrLocationDesc, HrLocationAddress</returns>
        public DataSet HRLocationGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset("udpMst_HrLocation_GetAll");
            return ds;
        }
        /// <summary>
        /// To get the All HrLocation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with HrLocationAutoID, CompanyCode, CompanyDesc, HrLocationCode, HrLocationDesc, HrLocationAddress</returns>
        public DataSet HRLocationGetAll(string companyCode, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HrLocation_ForCompany_GetAll", objParm);
            return ds;
        }

        /// <summary>
        /// To get the All HrLocation
        /// </summary>
        /// <returns>Dataset with HrLocationCode, HrLocationDesc</returns>
        public DataSet HRLocationDescriptionGetAll()
        {



            DataSet ds = SqlHelper.ExecuteDataset("udpMst_HrLocation_GetAllCodeDesc");
            return ds;
        }

        /// <summary>
        /// To get the All HrLocation for a Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with HrLocationCode, HrLocationDesc</returns>
        public DataSet HRLocationDescriptionGetAll(string companyCode)
        {



            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HrLocation_GetAllCodeDesc4Company", objParm);
            return ds;
        }
        /// <summary>
        /// To get the HrLocation Details for CompanyCode and HrLocationCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>Dataset with CompanyCode, CompanyDesc, CompanyAddress, HrLocationCode, HrLocationDesc, HrLocationAddress</returns>
        public DataSet HRLocationDescriptionGet(string companyCode, string hrLocationCode)
        {



            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HrLocation_Detail_Get", objParm);
            return ds;
        }
        #endregion

        #region Function related to add new data
        /// <summary>
        /// To add a new HrLocation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="hrLocationDesc">The hr location desc.</param>
        /// <param name="hrLocationAddress">The hr location address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet HRLocationAddNew(string companyCode, string hrLocationCode, string hrLocationDesc, string hrLocationAddress, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[5];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationDesc, hrLocationDesc);
            objParm[3] = new SqlParameter(DL.Properties.Resources.HrLocationAddress, hrLocationAddress);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HrLocation_Insert", objParm);
            return ds;
        }

        #endregion

        #region Function related to Update data
        /// <summary>
        /// To Update HrLocation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="hrLocationDesc">The hr location desc.</param>
        /// <param name="hrLocationAddress">The hr location address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet HRLocationUpdate(string companyCode, string hrLocationCode, string hrLocationDesc, string hrLocationAddress, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[5];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationDesc, hrLocationDesc);
            objParm[3] = new SqlParameter(DL.Properties.Resources.HrLocationAddress, hrLocationAddress);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HrLocation_Update", objParm);
            return ds;
        }
        #endregion

        #region Function related to Delete data
        /// <summary>
        /// To Delete a HrLocation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>message string</returns>
        public DataSet HRLocationDelete(string companyCode, string hrLocationCode)
        {



            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HrLocation_Delete", objParm);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To Location

        #region Function related to get data

        /// <summary>
        /// To get the All Location
        /// </summary>
        /// <returns>Dataset with LocationAutoID, CompanyCode, CompanyDesc, HrLocationCode, HrLocationDesc, LocationCode, LocationDesc, LocationAddress</returns>
        public DataSet LocationGetAll()
        {



            DataSet ds = SqlHelper.ExecuteDataset("udpMst_Location_GetAll");
            return ds;
        }
        /// <summary>
        /// Locations the description get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LocationDescriptionGetAll(string companyCode, string hrLocationCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_LocationByHRLocation_GetAllCodeDesc", objParm);
            return ds;
        }
        /// <summary>
        /// To get the All Location of a Comapny and HrLocation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with LocationAutoID, CompanyCode, CompanyDesc, HrLocationCode, HrLocationDesc, LocationCode, LocationDesc, LocationAddress</returns>
        public DataSet LocationDescriptionGet(string companyCode, string hrLocationCode, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Location_GetForCompanyAndHr", objParm);
            return ds;
        }

        /// <summary>
        /// To get the All Location
        /// </summary>
        /// <returns>Dataset with LocationCode, LocationDesc</returns>
        public DataSet LocationDescriptionGetAll()
        {



            DataSet ds = SqlHelper.ExecuteDataset("udpMst_Location_GetAllCodeDesc");
            return ds;
        }

        /// <summary>
        /// To get the All Location for a HrLocation and a Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>Dataset with LocationCode, LocationDesc</returns>
        public DataSet LocationDescriptionGet(string companyCode, string hrLocationCode)
        {



            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Location_GetAllCodeDesc4Comp_HrLoc", objParm);
            return ds;
        }
        /// <summary>
        /// To get the All Location of a company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with LocationAutoID, CompanyCode, CompanyDesc, HrLocationCode, HrLocationDesc, LocationCode, LocationDesc, LocationAddress</returns>
        public DataSet LocationDescriptionGetAll(string companyCode)
        {



            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Location4Company_GetAll", objParm);
            return ds;
        }
        /// <summary>
        /// To the LocationAutoID a Company, HrLocation and Location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>Dataset with LocationAutoID</returns>
        public DataSet LocationAutoIdGet(string companyCode, string hrLocationCode, string locationCode)
        {



            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Location_GetLocationAutoID", objParm);
            return ds;
        }
        /// <summary>
        /// To get the Location Details for CompanyCode and HrLocationCode and LocationCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>Dataset with CompanyCode, CompanyDesc, CompanyAddress, HrLocationCode, HrLocationDesc, HrLocationAddress, LocationCode, LocationDesc, LocationAddress</returns>
        public DataSet LocationDetailGet(string companyCode, string hrLocationCode, string locationCode)
        {



            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
             DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Location_Detail_Get", objParm);
            return ds;
        }
        #endregion

        #region Function related to add new data
        /// <summary>
        /// To add a new Location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="locationDesc">The location desc.</param>
        /// <param name="locationAddress">The location address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet LocationAddNew(string companyCode, string hrLocationCode, string locationCode, string locationDesc, string locationAddress, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[6];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationDesc, locationDesc);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LocationAddress, locationAddress);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Location_Insert", objParm);
            return ds;
        }

        #endregion

        #region Function related to Update data
        /// <summary>
        /// To Update Location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="locationDesc">The location desc.</param>
        /// <param name="locationAddress">The location address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet LocationUpdate(string companyCode, string hrLocationCode, string locationCode, string locationDesc, string locationAddress, string userId)
        {


            SqlParameter[] objParm = new SqlParameter[6];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationDesc, locationDesc);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LocationAddress, locationAddress);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Location_Update", objParm);
            return ds;
        }
        #endregion

        #region Function related to Delete data
        /// <summary>
        /// To Delete a Location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>message string</returns>
        public DataSet LocationDelete(string companyCode, string hrLocationCode, string locationCode)
        {



            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Location_Delete", objParm);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To Qualification Master

        #region Function Related To Get Data

        /// <summary>
        /// To get the All Data From Qualification Master
        /// </summary>
        /// <returns>Dataset with Qualification Code,Qualification desc</returns>
        public DataSet QualificationMasterGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset("udpMst_Qualification_GetAll");
            return ds;
        }

        /// <summary>
        /// Qualifications the grade get.
        /// </summary>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QualificationGradeGet(string qualificationCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_Qualification_Grade_Get", objParam);
            return ds;
        }
        #endregion

        #region function Related TO Insert Data
        /// <summary>
        /// To add a new Qualification
        /// </summary>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <param name="qualificationDesc">The qualification desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>ADD status[integer 0 or 1]</returns>
        public DataSet QualificationMasterAddNew(string qualificationCode, string qualificationDesc, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.QualificationDesc, qualificationDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMst_Qualification_Insert", objParam);
            return addStatus;


        }

        #endregion

        #region Function related to Update Data
        /// <summary>
        /// To Update Qualification
        /// </summary>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <param name="qualificationDesc">The qualification desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Update status[integer 0 or 1]</returns>
        public DataSet QualificationMasterUpdate(string qualificationCode, string qualificationDesc, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.QualificationDesc, qualificationDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMst_Qualification_Update", objParam);
            return updateStatus;

        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Qualification
        /// </summary>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>Delete status[integer 0 or 1]</returns>
        public DataSet QualificationMasterDelete(string qualificationCode)
        {


            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMst_Qualification_Delete", objParam);
            return deleteStatus;
        }
        #endregion

        #endregion

        #region Function Related To Training Master

        #region  Function Related To GetData
        /// <summary>
        /// To get the All Data From Training Master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with Company Code,Training Code,Training desc</returns>
        public DataSet TrainingMasterGetAll(string companyCode)
        {



            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Training_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// Trainings the category get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingCategoryGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_TrainingCategory_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Trainings the levels get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingLevelsGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_TrainingLevel_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Substitutes the training details get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubstituteTrainingDetailsGetAll(string companyCode, string trainingCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_SubstituteTrainingDetails_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Substitutes the training details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubstituteTrainingDetailsGet(string companyCode, string trainingCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_FillSubstituteTrainingDetails_Get", objParam);
            return ds;
        }


        /// <summary>
        /// Refreshes the training get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet RefreshTrainingGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_RefreshTraining_Get", objParam);
            return ds;
        }

        #endregion

        #region Function Related To Insert Data
        /// <summary>
        /// To add a new Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="trainingDesc">The training desc.</param>
        /// <param name="trainingCategory">The training category.</param>
        /// <param name="trainingLevel">The training level.</param>
        /// <param name="refreshTraining">The refresh training.</param>
        /// <param name="validMonths">The valid months.</param>
        /// <param name="refreshTrainAfterMonths">The refresh train after months.</param>
        /// <param name="refreshTrainingDays">The refresh training days.</param>
        /// <param name="isTrainingFlexi">if set to <c>true</c> [is training flexi].</param>
        /// <param name="leeWayDays">The lee way days.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>ADD status[integer 0 or 1]</returns>
        public DataSet TrainingDetailsAddNew(string companyCode, string trainingCode, string trainingDesc,
            string trainingCategory, string trainingLevel, string refreshTraining, string validMonths,
            string refreshTrainAfterMonths, string refreshTrainingDays, bool isTrainingFlexi, string leeWayDays, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingDesc, trainingDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingCategory, trainingCategory);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TrainingLevel, trainingLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.RefreshTraining, refreshTraining);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ValidMonths, validMonths);
            objParam[7] = new SqlParameter(DL.Properties.Resources.RefTrainAfterNMonths, refreshTrainAfterMonths);
            objParam[8] = new SqlParameter(DL.Properties.Resources.RefTrainingDays, refreshTrainingDays);
            objParam[9] = new SqlParameter(DL.Properties.Resources.IsTrainingFlexi, isTrainingFlexi);
            objParam[10] = new SqlParameter(DL.Properties.Resources.LeeWayDays, leeWayDays);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Training_Insert", objParam);
            return addStatus;
        }

        /// <summary>
        /// Substitutes the training insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCodeMain">The training code main.</param>
        /// <param name="trainingCodeSub">The training code sub.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubstituteTrainingInsert(string companyCode, string trainingCodeMain, string trainingCodeSub, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCodeMain, trainingCodeMain);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingCodeSub, trainingCodeSub);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_TrainingMasterForSubstitute_Insert", objParam);
            return addStatus;
        }

        #endregion

        #region Function related to Update Data
        /// <summary>
        /// To Update Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="trainingDesc">The training desc.</param>
        /// <param name="trainingCategory">The training category.</param>
        /// <param name="trainingLevel">The training level.</param>
        /// <param name="refreshTraining">The refresh training.</param>
        /// <param name="validMonths">The valid months.</param>
        /// <param name="refreshTrainAfterMonths">The refresh train after months.</param>
        /// <param name="refreshTrainingDays">The refresh training days.</param>
        /// <param name="isTrainingFlexi">if set to <c>true</c> [is training flexi].</param>
        /// <param name="leeWayDays">The lee way days.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Update Status[integer 1 or 0]</returns>
        public DataSet TrainingUpdate(string companyCode, string trainingCode, string trainingDesc,
            string trainingCategory, string trainingLevel, string refreshTraining, string validMonths,
            string refreshTrainAfterMonths, string refreshTrainingDays, bool isTrainingFlexi, string leeWayDays, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingDesc, trainingDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingCategory, trainingCategory);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TrainingLevel, trainingLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.RefreshTraining, refreshTraining);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ValidMonths, validMonths);
            objParam[7] = new SqlParameter(DL.Properties.Resources.RefTrainAfterNMonths, refreshTrainAfterMonths);
            objParam[8] = new SqlParameter(DL.Properties.Resources.RefTrainingDays, refreshTrainingDays);
            objParam[9] = new SqlParameter(DL.Properties.Resources.IsTrainingFlexi, isTrainingFlexi);
            objParam[10] = new SqlParameter(DL.Properties.Resources.LeeWayDays, leeWayDays);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMst_Training_Update", objParam);
            return updateStatus;
        }

        /// <summary>
        /// Substitutes the training details update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCodeMain">The training code main.</param>
        /// <param name="oldSubTrainingCode">The old sub training code.</param>
        /// <param name="newSubTrainingCode">The new sub training code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubstituteTrainingDetailsUpdate(string companyCode, string trainingCodeMain, string oldSubTrainingCode, string newSubTrainingCode, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCodeMain, trainingCodeMain);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingCodeSubOld, oldSubTrainingCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingCodeSubNew, newSubTrainingCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMst_SubstituteTrainingDetails_Update", objParam);
            return updateStatus;
        }

        /// <summary>
        /// Substitutes the training details delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCodeMain">The training code main.</param>
        /// <param name="trainingCodeSub">The training code sub.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubstituteTrainingDetailsDelete(string companyCode, string trainingCodeMain, string trainingCodeSub, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCodeMain, trainingCodeMain);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingCodeSub, trainingCodeSub);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMst_SubstituteTrainingDetails_Delete", objParam);
            return updateStatus;
        }

        #endregion

        #region Function related To Delete Data
        /// <summary>
        /// To Delete a Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>Delete status[integer 0 or 1]</returns>
        public DataSet TrainingDelete(string companyCode, string trainingCode)
        {


            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMst_Training_Delete", objParam);
            return deleteStatus;
        }
        #endregion
        #endregion

        #region Function Related to Language Master

        #region Function Related to Get Data
        /// <summary>
        /// Languages the master get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet LanguageMasterGetAll()
        {



            DataSet ds = SqlHelper.ExecuteDataset("udpMst_language_GetAll");
            return ds;
        }
        #endregion]

        #region Function Related to Insert Data
        /// <summary>
        /// To add a new Language
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        /// <param name="languageDesc">The language desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>message string</returns>
        public DataSet LanguageMasterAddNew(string languageCode, string languageDesc, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LanguageDesc, languageDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMst_Language_Insert", objParam);
            return addStatus;

        }

        #endregion

        #region Function Related To Update Data
        /// <summary>
        /// To Update language
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        /// <param name="languageDesc">The language desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>message string</returns>
        public DataSet LanguageMasterUpdate(string languageCode, string languageDesc, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LanguageDesc, languageDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMst_Language_Update", objParam);
            return updateStatus;

        }
        #endregion

        #region Function Related To Delete Data
        /// <summary>
        /// To Delete a Qualification
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        /// <returns>message string</returns>
        public DataSet LanguageMasterDelete(string languageCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMst_language_Delete", objParam);
            return deleteStatus;

        }
        #endregion
        #endregion

        #region Function Related To Designation

        #region Function Related to Get Data
        /// <summary>
        /// To get Designation for Designation master page gridview
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DesignationMasterGetAll(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Designation_GetAll", objParam);
            return ds;

        }
       
        /// <summary>
        /// To get DesignationCode, DesignationDesc, DesignationCodeDesc to fill the DropDownList
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DesignationMasterGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Designation_Get", objParam);
            return ds;
        }
        #endregion
        #region Function Related to Grade
        public DataSet GradeMasterGetAll(string companyCode, string DesignationCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Designationcode, DesignationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Grade_GetAll", objParam);
            return ds;

        }
        public DataSet GradeMasterAddNew(string companyCode, string gradeCode, string gradeDesc, string userId, string designationCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.GradeCode, gradeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.GradeDesc, gradeDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_Grade_Insert", objParam);
            return ds;
        }
        public DataSet GradeMasterDelete(string companyCode, string designationCode, string gradeCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.GradeCode, gradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_Grade_Delete", objParam);
            return ds;
        }
        public DataSet GradeMasterUpdate(string companyCode, string designationCode, string gradeCode, string gradeDesc, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.GradeCode, gradeCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.GradeDesc, gradeDesc);
             objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
             DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_Grade_Update", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Insert Data
        /// <summary>
        /// Designations the master add new.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="designationDesc">The designation desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DesignationMasterAddNew(string companyCode, string designationCode, string designationDesc, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DesignationDesc, designationDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_Designation_Insert", objParam);
            return ds;

        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// Designations the master delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DesignationMasterDelete(string companyCode, string designationCode)
        {



            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_Designation_Delete", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// Designations the master update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="designationDesc">The designation desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DesignationMasterUpdate(string companyCode, string designationCode, string designationDesc, string userId)
        {



            SqlParameter[] objParam = new SqlParameter[4];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DesignationDesc, designationDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updMstHR_Designation_Update", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related To Category

        #region Function related to get data

        /// <summary>
        /// Categories the master get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CategoryMasterGetAll(string companyCode)
        {



            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Categories_GetAll", objParm);
            return ds;

        }

        #endregion

        #region Function related to Edit data

        /// <summary>
        /// Categories the master update.
        /// </summary>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="categoryDesc">The category desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CategoryMasterUpdate(string categoryCode, string categoryDesc, string companyCode, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CategoryCode, categoryCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CategoryDesc, categoryDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Category_Update", objParm);
            return ds;

        }


        #endregion

        #region Function Related To Add Data
        /// <summary>
        /// Categories the master add new.
        /// </summary>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="categoryDesc">The category desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CategoryMasterAddNew(string categoryCode, string categoryDesc, string companyCode, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CategoryCode, categoryCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CategoryDesc, categoryDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Category_Insert", objParm);
            return ds;

        }

        #endregion

        #region Function Related To Delete Data
        /// <summary>
        /// Categories the master delete.
        /// </summary>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CategoryMasterDelete(string categoryCode, string companyCode)
        {



            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CategoryCode, categoryCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Category_Delete", objParm);
            return ds;

        }

        #endregion

        #endregion

        #region Function related to Country

        #region related to Get Data
        /// <summary>
        /// To get Country
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CountryMasterGetAll(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Country_Get", objParm);
            return ds;
        }
        #endregion

        #region Function related to Edit data
        /// <summary>
        /// To Edit Country
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="countryDesc">The country desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>

        public DataSet CountryMasterUpdate(string countryCode, string countryDesc, string companyCode, string userId)
        {



            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CountryDesc, countryDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Country_Update", objParm);
            return ds;

        }

        #endregion

        #region Function related to add data
        /// <summary>
        /// To Add Country
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="countryDesc">The country desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>

        public DataSet CountryMasterAddNew(string countryCode, string countryDesc, string companyCode, string userId)
        {


            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CountryDesc, countryDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Country_Add", objParm);
            return ds;

        }

        #endregion

        #region Function Related To Delete Data
        /// <summary>
        /// To Delete Country
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CountryMasterDelete(string countryCode, string companyCode)
        {



            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Country_Delete", objParm);
            return ds;

        }

        #endregion

        #endregion

        #region Function Related to get Job Type
        /// <summary>
        /// to get JobType
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobTypeMasterGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_JobType_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// to insert data into job type master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <param name="jobTypeDesc">The job type desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobTypeMasterAddNew(string companyCode, string jobTypeCode, string jobTypeDesc, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.JobTypeCode, jobTypeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.JobTypeDesc, jobTypeDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_JobType_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// to Update data into job type master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <param name="jobTypeDesc">The job type desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobTypeMasterUpdate(string companyCode, string jobTypeCode, string jobTypeDesc, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.JobTypeCode, jobTypeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.JobTypeDesc, jobTypeDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_JobType_Update", objParam);
            return ds;
        }

        /// <summary>
        /// To Delete data From job type master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobTypeMasterDelete(string companyCode, string jobTypeCode)
        {



            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.JobTypeCode, jobTypeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_JobType_Delete", objParam);
            return ds;
        }
        #endregion

        #region Function Related to get Job Class
        /// <summary>
        /// to get JobClass
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobClassMasterGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_JobClass_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// to insert data into job Class master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="jobClassCode">The job class code.</param>
        /// <param name="jobClassDesc">The job class desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobClassMasterAddNew(string companyCode, string jobClassCode, string jobClassDesc, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.JobClassCode, jobClassCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.JobClassDesc, jobClassDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_JobClass_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// to Update data into job Class master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="jobClassCode">The job class code.</param>
        /// <param name="jobClassDesc">The job class desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobClassMasterUpdate(string companyCode, string jobClassCode, string jobClassDesc, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.JobClassCode, jobClassCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.JobClassDesc, jobClassDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_JobClass_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To Delete data From job Class master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="jobClassCode">The job class code.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobClassMasterDelete(string companyCode, string jobClassCode)
        {



            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.JobClassCode, jobClassCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_JobClass_Delete", objParam);
            return ds;
        }
        #endregion

        #region Function Related To Shift Pattern

        #region Function related to get data
        /// <summary>
        /// To get the All Shift Patterns of a Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>Dataset with ShiftPatternCode , ShiftPattern</returns>
        public DataSet ShiftPatternsGet(int locationAutoId, string asmtCode, int pdLineNo)
        {



            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ShiftPattern_Get", objParm);
            return ds;
        }
        #endregion

        #region Function related to Update data
        /// <summary>
        /// Shifts the pattern update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="shiftPattern">The shift pattern.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftPatternUpdate(int locationAutoId, string shiftPatternCode, string shiftPattern, string modifiedBy)
        {



            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ShiftPattern, shiftPattern);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ShiftPattern_Update", objParm);
            return ds;
        }
        #endregion

        #region Function related to Insert data
        /// <summary>
        /// Shifts the pattern insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="shiftPattern">The shift pattern.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftPatternInsert(int locationAutoId, string shiftPatternCode, string shiftPattern, string modifiedBy)
        {


            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ShiftPattern, shiftPattern);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ShiftPattern_Insert", objParm);
            return ds;
        }
        #endregion

        #region Function related to Delete data
        /// <summary>
        /// Shifts the pattern delete.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShiftPatternDelete(int locationAutoId, string shiftPatternCode)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ShiftPatternCode, shiftPatternCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ShiftPattern_Delete", objParm);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To PayPeriod

        #region Function related to get data
        /// <summary>
        /// Companies the pay period get.
        /// </summary>
        /// <param name="payPeriodCode">The pay period code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CompanyPayPeriodGet(string payPeriodCode, string companyCode, string hrLocationCode, string locationCode)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PayPeriodCode, payPeriodCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PayPeriodOfCompany_Get", objParm);
            return ds;
        }
        #endregion


        #region Function related to get dates of payperiod
        /// <summary>
        /// Companies the pay period dates get.
        /// </summary>
        /// <param name="payPeriodCode">The pay period code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>DataSet.</returns>
        public DataSet CompanyPayPeriodDatesGet(string payPeriodCode, string companyCode, int month, int year)
        {


            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PayPeriodCode, payPeriodCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Month, month);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Year, year);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PayPeriodDates_Get", objParm);
            return ds;
        }
        #endregion


        #endregion

        #region Function Related To Site Instruction For Industry

        #region Function related to get data
        #region Function to get Industry Type
        /// <summary>
        /// Industries the type get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IndustryTypeGetAll(string companyCode)
        {



            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_IndustryType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Instructions the type get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet InstructionTypeGetAll(string companyCode)
        {



            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_InstructionType_Get", objParam);
            return ds;
        }

        #endregion
        #region Function to get Site Instruction
        /// <summary>
        /// Sites the instruction get all.
        /// </summary>
        /// <param name="noIndustryTypeId">The no industry type identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionGetAll(string noIndustryTypeId, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IndustryTypeID, noIndustryTypeId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstruction_Get", objParam);
            return ds;
        }


        /// <summary>
        /// Masters the site instruction get all.
        /// </summary>
        /// <param name="InstructionTypeId">The instruction type identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MasterSiteInstructionGetAll(string InstructionTypeId, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.InstructionTypeID, InstructionTypeId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_MasterSiteInstruction_Get", objParam);
            return ds;
        }
        //End
        #endregion
        #endregion
        #region Function Related To add new data
        #region Function Related To Insert Site Instruction For Industry
        /// <summary>
        /// Sites the instruction for industry insert.
        /// </summary>
        /// <param name="InstructionTypeId">The instruction type identifier.</param>
        /// <param name="IndustryTypeId">The industry type identifier.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionForIndustryInsert(string InstructionTypeId, string IndustryTypeId, string siteInstruction, string companyCode, string userId)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.InstructionTypeID, InstructionTypeId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.IndustryTypeID, IndustryTypeId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SiteInstruction, siteInstruction);
            objParm[3] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstructionForIndustry_Insert", objParm);
            return ds;
        }
        #endregion
        #endregion
        #region Function Related to update data
        /// <summary>
        /// Sites the instruction for industry update.
        /// </summary>
        /// <param name="noRowId">The no row identifier.</param>
        /// <param name="InstructionTypeId">The instruction type identifier.</param>
        /// <param name="IndustryTypeId">The industry type identifier.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionForIndustryUpdate(int noRowId, string InstructionTypeId, string IndustryTypeId, string siteInstruction, string companyCode, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, noRowId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.InstructionTypeID, InstructionTypeId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IndustryTypeID, IndustryTypeId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SiteInstruction, siteInstruction);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstructionForIndustry_Update", objParam);
            return ds;
        }
        #endregion
        #region Function Related to delete data
        /// <summary>
        /// Sites the instruction for industry delete.
        /// </summary>
        /// <param name="noRowId">The no row identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionForIndustryDelete(int noRowId, string userId)
        {



            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowId, noRowId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SiteInstructionForIndustry_Delete", objParam);
            return ds;
        }
        #endregion

        /// <summary>
        /// Asmts the post get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="AreaIncharge">The area incharge.</param>
        /// <param name="AreaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtPostGet(string locationAutoId, string AreaIncharge, string AreaId, string clientCode, string asmtCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, AreaIncharge);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaId, AreaId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AsmtPost_GetByInchargeAreaClientAsmt", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Post for Incharge Area Client AsmtId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="AreaIncharge">The area incharge.</param>
        /// <param name="AreaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtIdPostGet(string locationAutoId, string AreaIncharge, string AreaId, string clientCode, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, AreaIncharge);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaId, AreaId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAsmtIdPostGet", objParam);
            return ds;
        }

        /// <summary>
        /// To get So Ranks from Sale Order Details where Location, Client Code and Post is same as parameters.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="AsmtId">The asmt identifier.</param>
        /// <param name="PostAutoId">The post automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtIdPostSoRankFromSODGet(string locationAutoId, string ClientCode, string AsmtId, string PostAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, AsmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PostAutoId, PostAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udtSoRankFromSODGet", objParam);
            return ds;
        }

        /// <summary>
        /// To Get Post for Selected Assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientcode">The clientcode.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet</returns>
        public DataSet SelectedAsmtPostGet(string locationAutoId, string clientcode, string asmtCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientcode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSelectedAsmtPostGet", objParam);
            return ds;
        }
        #endregion

        #region Function related to Standard Shift
        #region Function Related to Get Data
        /// <summary>
        /// Standards the sifts get all.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftsGetAll(string locationAutoId)
        {



            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_StandardShift_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get the StandardShift with Fromtime, Endtime and minutes for a location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>DataSet.</returns>

        public DataSet StandardSiftsGet(string locationAutoId, string shiftCode)
        {



            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_StandardShiftTimeFromTo_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Standards the sifts get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftsGet(string locationAutoId)
        {


            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_StandardShift_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To update a Standard Shift For a Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="shiftMinutes">The shift minutes.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="description">The description.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftUpdate(string locationAutoId, string shiftCode, string startTime, string endTime, string shiftMinutes, string modifiedBy, string description)
        {



            SqlParameter[] objParam = new SqlParameter[7];
            if (string.IsNullOrEmpty(shiftMinutes))
            { shiftMinutes = "0"; }

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.StartTime, startTime);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EndTime, endTime);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ShiftMinutes, shiftMinutes);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Description, description);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_StandardShift_Update", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Insert Data
        /// <summary>
        /// To insert a new standardShift for a Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="shiftMinutes">The shift minutes.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="shiftDesc">The shift desc.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftInsert(string locationAutoId, string shiftCode, string startTime, string endTime, string shiftMinutes, string modifiedBy, string shiftDesc)
        {



            SqlParameter[] objParam = new SqlParameter[7];
            if (string.IsNullOrEmpty(shiftMinutes))
            { shiftMinutes = "0"; }

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.StartTime, startTime);
            objParam[3] = new SqlParameter(DL.Properties.Resources.EndTime, endTime);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ShiftMinutes, shiftMinutes);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Description, shiftDesc);

            DataSet ds = SqlHelper.ExecuteDataset("udpMst_StandardShift_Insert", objParam);
            return ds;
        }
        #endregion

        #region Function Related to delete Data
        /// <summary>
        /// To dalete a Standard Shift For a Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftDelete(string locationAutoId, string shiftCode)
        {



            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_StandardShift_Delete", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Copy Standard Shift To Another Branch
        /// <summary>
        /// To Copy The Standard Shift from Login Location To Other Location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoIdCopyFrom">The location automatic identifier copy from.</param>
        /// <param name="locationCodeCopyTo">The location code copy to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftCopyToBranch(string companyCode, string locationAutoIdCopyFrom, string locationCodeCopyTo, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoIdCopyFrom);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCodeCopyTo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpStandardSiftCopyToBranch", objParm);
            return ds;
        }
        #endregion

        #endregion

        #region Function related to Quick Code
        /// <summary>
        /// Industries the type master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IndustryTypeMasterGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodeIndustryType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Quicks the code classification get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeClassificationGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodeClassification_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Customers the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CustomerTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodeCustomerType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Customers the sector get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CustomerSectorGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodeSectort_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Customers the subsegment get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CustomerSubsegmentGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodeSubSegment_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Premiseses the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PremisesTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodePremisesType_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Addresses the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AddressTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodeAddressType_Get", objParam);
            return ds;
        }


        /// <summary>
        /// Prefers the channel communication get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PreferChannelCommunicationGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodePrefChannelComm_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Gets the duty replaced reason.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetDutyReplacedReason(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_QuickCodeGetDutyReplacedReason_Get", objParam);
            return ds;
        }

        #endregion

        #region Function related to Employee Compensation History

        /// <summary>
        /// Components the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ComponentTypeGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ComponentType_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Percentages the value get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PercentageValueGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PercentageValue_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Percentages the get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="component">The component.</param>
        /// <returns>DataSet.</returns>
        public DataSet PercentageGet(string companyCode, string component)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ComponentCode, component);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Percentageof_Get", objParam);
            return ds;
        }

        #endregion

        #region Function Related To Role

        #region Function related to get data
        /// <summary>
        /// To get All RoleCodes
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with RoleCode, RoleDesc</returns>
        public DataSet RoleGet(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Role_Get", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To Duty Type Master

        #region Function Related To Get Data

        /// <summary>
        /// To get the All Data From Qualification Master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with Qualification Code,Qualification desc</returns>
        public DataSet DutyTypeGetAll(string companyCode)
        {




            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_DutyType_GetAll", objParam);
            return ds;
        }
        #endregion

        #region function Related TO Insert Data
        /// <summary>
        /// To add a new DutyType
        /// </summary>
        /// <param name="dutyTypeDesc">The duty type desc.</param>
        /// <param name="isBillable">if set to <c>true</c> [is billable].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>ADD status[integer 0 or 1]</returns>
        public DataSet DutyTypeAddNew(string dutyTypeDesc, bool isBillable, bool isActive, bool isDefault, string modifiedBy, string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DutyTypeDesc, dutyTypeDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IsBillable, isBillable);
            objParam[3] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            objParam[4] = new SqlParameter(DL.Properties.Resources.IsDefault, isDefault);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMst_DutyType_Insert", objParam);
            return addStatus;

        }

        #endregion

        #region Function related to Update Data
        /// <summary>
        /// To Update DutyType
        /// </summary>
        /// <param name="dutyTypeCode">The duty type code.</param>
        /// <param name="dutyTypeDesc">The duty type desc.</param>
        /// <param name="isBillable">The is billable.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="isDefault">The is default.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Update status[integer 0 or 1]</returns>
        public DataSet DutyTypeUpdate(string dutyTypeCode, string dutyTypeDesc, string isBillable, string isActive, string isDefault, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[6];

            objParam[0] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DutyTypeDesc, dutyTypeDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.IsBillable, isBillable);
            objParam[3] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            objParam[4] = new SqlParameter(DL.Properties.Resources.IsDefault, isDefault);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMst_DutyType_Update", objParam);
            return updateStatus;

        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a DutyType
        /// </summary>
        /// <param name="dutyTypeCode">The duty type code.</param>
        /// <returns>Delete status[integer 0 or 1]</returns>
        public DataSet DutyTypeDelete(string dutyTypeCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dutyTypeCode);
            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMst_DutyType_Delete", objParam);
            return deleteStatus;
        }
        #endregion

        #endregion

        #region Function related to Holiday Type

        #region Function to Get Data
        /// <summary>
        /// Function to get all holiday type
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet HolidayTypeGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HolidayType_GetAll");
            return ds;
        }
        #endregion

        #region Function To Insert Data
        /// <summary>
        /// To Insert Data
        /// </summary>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <param name="holidayTypeDesc">The holiday type desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayTypeInsert(string holidayTypeCode, string holidayTypeDesc, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HolidayTypeDesc, holidayTypeDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HolidayType_Insert", objParam);
            return ds;
        }
        #endregion

        #region Function to Update
        /// <summary>
        /// To Update
        /// </summary>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <param name="holidayTypeDesc">The holiday type desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayTypeUpdate(string holidayTypeCode, string holidayTypeDesc, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HolidayTypeDesc, holidayTypeDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HolidayType_Update", objParam);
            return ds;
        }
        #endregion

        #region Function TO Delete
        /// <summary>
        /// Holidays the type delete.
        /// </summary>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayTypeDelete(string holidayTypeCode)
        {


            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HolidayType_Delete", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function related to Holiday

        #region Function to Get Data
        /// <summary>
        /// Function to get all holiday
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayMasterGetAll(string locationAutoId, string holidayTypeCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Holiday_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Holidaycode and Description from master holiday
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayDescriptionGet(string locationAutoId)
        {



            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_HolidayCodeDesc_Get", objParam);
            return ds;
        }
        #endregion

        #region Function To Insert Data
        /// <summary>
        /// To insert Holidays
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDesc">The holiday desc.</param>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayMasterAddNew(string locationAutoId, string holidayCode, string holidayDesc, string holidayTypeCode, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HolidayCode, holidayCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.HolidayDesc, holidayDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Holiday_Insert", objParam);
            return ds;
        }
        #endregion

        #region Function to Update
        /// <summary>
        /// To update holidays
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDesc">The holiday desc.</param>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayMasterUpdate(string locationAutoId, string holidayCode, string holidayDesc, string holidayTypeCode, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HolidayCode, holidayCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.HolidayDesc, holidayDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Holiday_Update", objParam);
            return ds;
        }
        #endregion

        #region Function TO Delete
        /// <summary>
        /// To delete Holidays
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayMasterDelete(string locationAutoId, string holidayCode, string holidayTypeCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HolidayCode, holidayCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Holiday_Delete", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function related to Holiday Transactions

        #region Function to Get Data
        /// <summary>
        /// Function to get all holiday Transactions
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayGetAll(string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_Holiday_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function To Insert Data

        /// <summary>
        /// To insert Holiday Transaction
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDate">The holiday date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayInsert(string locationAutoId, string holidayCode, string holidayDate, string modifiedBy, string toDate, string clientCode, string asmtCode, string guid)
        {

            var objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HolidayCode, holidayCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.HolidayDate, DL.Common.DateFormat(holidayDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Guid, guid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_Holiday_Insert", objParam);
            return ds;
        }
        #endregion

        #region Function TO Delete
        /// <summary>
        /// To delete Holiday Transaction
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDate">The holiday date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayDelete(string locationAutoId, string holidayCode, string holidayDate, string clientCode, string asmtCode)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.HolidayCode, holidayCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.HolidayDate, DL.Common.DateFormat(holidayDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_Holiday_Delete", objParam);

            return ds;
        }
        #endregion
        #endregion

        #region Function Related Adjustment Hrs Type

        #region Function get Adj Master data
        /// <summary>
        /// To get All Adj Head Types
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with AdjCode, AdjDesc</returns>
        public DataSet AdjustmentHeadGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_AdjHead_Get", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To Nationality

        #region Function related to get data

        /// <summary>
        /// To get the All Nationality
        /// </summary>
        /// <returns>Dataset with CompanyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet NationalityMasterGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset("udpMst_Nationality_GetAll");
            return ds;
        }

        #endregion
        #region Function related to add new data
        /// <summary>
        /// To add a new Nationality
        /// </summary>
        /// <param name="nationalityCode">The nationality code.</param>
        /// <param name="nationalityDesc">The nationality desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet NationalityMasterInsert(string nationalityCode, string nationalityDesc, string userId)
        {

            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.NationalityCode, nationalityCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.NationalityDesc, nationalityDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Nationality_Insert", objParm);
            return ds;

        }
        #endregion
        #region Function related to Update data
        /// <summary>
        /// To Update Nationality
        /// </summary>
        /// <param name="nationalityCode">The nationality code.</param>
        /// <param name="nationalityDesc">The nationality desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet NationalityMasterUpdate(string nationalityCode, string nationalityDesc, string userId)
        {

            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.NationalityCode, nationalityCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.NationalityDesc, nationalityDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Nationality_Update", objParm);
            return ds;
        }
        #endregion
        #region Function related to Delete data
        /// <summary>
        /// To Delete a Nationality
        /// </summary>
        /// <param name="nationalityCode">The nationality code.</param>
        /// <returns>message string</returns>
        public DataSet NationalityMasterDelete(string nationalityCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.NationalityCode, nationalityCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Nationality_Delete", objParm);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To IdType

        #region Function related to get data

        /// <summary>
        /// To get the All IdType
        /// </summary>
        /// <returns>Dataset with CompanyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet IdTypeGetAll()
        {


            DataSet ds = SqlHelper.ExecuteDataset("udpMst_IdType_GetAll");
            return ds;
        }

        #endregion
        #region Function related to add new data
        /// <summary>
        /// To add a new IdType
        /// </summary>
        /// <param name="idTypeCode">The identifier type code.</param>
        /// <param name="idTypeDesc">The identifier type desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet IdTypeInsert(string idTypeCode, string idTypeDesc, string userId)
        {

            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.IdTypeCode, idTypeCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.IdTypeDesc, idTypeDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_IdType_Insert", objParm);
            return ds;

        }
        #endregion
        #region Function related to Update data
        /// <summary>
        /// To Update IdType
        /// </summary>
        /// <param name="idTypeCode">The identifier type code.</param>
        /// <param name="idTypeDesc">The identifier type desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet IdTypeUpdate(string idTypeCode, string idTypeDesc, string userId)
        {

            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.IdTypeCode, idTypeCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.IdTypeDesc, idTypeDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_IdType_Update", objParm);
            return ds;
        }
        #endregion
        #region Function related to Delete data
        /// <summary>
        /// To Delete a IdType
        /// </summary>
        /// <param name="idTypeCode">The identifier type code.</param>
        /// <returns>message string</returns>
        public DataSet IdTypeDelete(string idTypeCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.IdTypeCode, idTypeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_IdType_Delete", objParm);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To Department

        #region Function related to get data

        /// <summary>
        /// To get the All Department
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with CompanyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet DepartmentGetAll(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Department_GetAll", objParm);
            return ds;
        }

        #endregion
        #region Function related to add new data
        /// <summary>
        /// To add a new Department
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="departmentDesc">The department desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet DepartmentAddNew(string companyCode, string departmentCode, string departmentDesc, string userId)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.DepartmentCode, departmentCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DepartmentDesc, departmentDesc);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Department_Insert", objParm);
            return ds;

        }
        #endregion
        #region Function related to Update data
        /// <summary>
        /// To Update Department
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="departmentDesc">The department desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet DepartmentUpdate(string companyCode, string departmentCode, string departmentDesc, string userId)
        {

            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.DepartmentCode, departmentCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.DepartmentDesc, departmentDesc);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Department_Update", objParm);
            return ds;
        }
        #endregion
        #region Function related to Delete data
        /// <summary>
        /// To Delete a Department
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <returns>message string</returns>
        public DataSet DepartmentDelete(string companyCode, string departmentCode)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.DepartmentCode, departmentCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Department_Delete", objParm);
            return ds;
        }
        #endregion

        #endregion

        #region function related to  Employee Increment Promotions

        /// <summary>
        /// To get currency Names
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with currencyCode,currencyname</returns>
        public DataSet CurrencyMasterGetAll(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Currency_GetAll", objParm);
            return ds;
        }

        /// <summary>
        /// To get Rate Frequency
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with RateFrequencyCode,RateFrequency</returns>
        public DataSet RateFrequencyGetAll(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_RateFrequency_GetAll", objParm);
            return ds;
        }

        /// <summary>
        /// Increments the reason types get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet IncrementReasonTypesGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpMst_IncrementReasonTypes_Get");
            return ds;
        }

        #endregion

        #region Function Related to Currency Master

        #region  Function Related To GetData

        /// <summary>
        /// Currencies the master get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet CurrencyMasterGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Currency_GetAll");
            return ds;
        }
        #endregion

        #region Function Related To Insert Data
        /// <summary>
        /// Currencies the master add new.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="currencyDesc">The currency desc.</param>
        /// <param name="currencySymbol">The currency symbol.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CurrencyMasterAddNew(string currencyCode, string currencyDesc, string currencySymbol, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CurrencyCode, currencyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CurrencyDesc, currencyDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CurrencySymbol, currencySymbol);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Currency_Insert", objParam);
            return addStatus;
        }
        #endregion

        #region Function related to Update Data
        /// <summary>
        /// To Update Training
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="currencyDesc">The currency desc.</param>
        /// <param name="currencySymbol">The currency symbol.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Update Status[integer 1 or 0]</returns>
        public DataSet CurrencyMasterUpdate(string currencyCode, string currencyDesc, string currencySymbol, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CurrencyCode, currencyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CurrencyDesc, currencyDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CurrencySymbol, currencySymbol);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet updateStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Currency_Update", objParam);
            return updateStatus;
        }
        #endregion

        #region Function related To Delete Data
        /// <summary>
        /// Currencies the master delete.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CurrencyMasterDelete(string currencyCode)
        {


            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CurrencyCode, currencyCode);
            DataSet deleteStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Currency_Delete", objParam);
            return deleteStatus;
        }
        #endregion


        #endregion

        #region Event
        /**********Code Added By   on 9-June-2010 **********/
        #region Event Master

        #region Function Related To Get Data

        /// <summary>
        /// Events the master get.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMasterGet(string module)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Module, module);

            //DataSet  ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EventMaster_Get", objParam);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_EventMaster_Get", objParam);
            return ds;

        }

        /// <summary>
        /// Modules the name get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet ModuleNameGet()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ModuleName_Get");
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// Events the master update.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="eventCode">The event code.</param>
        /// <param name="eventDesc">The event desc.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMasterUpdate(string module, string eventCode, string eventDesc, bool isActive, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Module, module);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EventCode, eventCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EventDesc, eventDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            objParam[4] = new SqlParameter(DL.Properties.Resources.UserId, userId);


            DataSet ds = SqlHelper.ExecuteDataset("udpMst_EventMaster_Update", objParam);
            return ds;
        }
        #endregion

        #region Functions to Insert data
        /// <summary>
        /// Events the master add.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="eventCode">The event code.</param>
        /// <param name="eventDesc">The event desc.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMasterAdd(string module, string eventCode, string eventDesc, bool isActive, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Module, module);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EventCode, eventCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EventDesc, eventDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            objParam[4] = new SqlParameter(DL.Properties.Resources.UserId, userId);


            DataSet ds = SqlHelper.ExecuteDataset("udpMst_EventMaster_Insert", objParam);
            return ds;
        }
        #endregion

        #region Functions to Delete data
        /// <summary>
        /// Events the delete.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="eventCode">The event code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventDelete(string module, string eventCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Module, module);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EventCode, eventCode);

            DataSet ds = SqlHelper.ExecuteDataset("udpMst_EventMaster_Delete", objParam);
            return ds;
        }
        #endregion

        #endregion
        /**********Code Added By   on 9-June-2010 **********/

        /**********Code Added By   on 10-June-2010 **********/
        #region EventUserMapping

        /// <summary>
        /// Users the get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet UserGet()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "getUserName_EventMapping");
            return ds;
        }

        /// <summary>
        /// Events the mapping get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingGet(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);


            DataSet ds = SqlHelper.ExecuteDataset("UserNameEventMapping_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Events the mapping get all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingGetAll(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);


            DataSet ds = SqlHelper.ExecuteDataset("UserNameEventMapping_GetGrid", objParam);
            return ds;
        }
        /// <summary>
        /// Events the subscribers get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet EventSubscribersGet()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SubscribedMailID_Get");
            return ds;
        }

        /// <summary>
        /// Events the module mapping get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventModuleMappingGet(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);


            DataSet ds = SqlHelper.ExecuteDataset("sp_useraccessmodule", objParam);
            return ds;
        }


        /// <summary>
        /// Events the mapping description get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingDescriptionGet()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_EventDesc_Get");
            return ds;
        }

        /// <summary>
        /// Events the mapping subscriber get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="moduleCode">The module code.</param>
        /// <param name="eventCode">The event code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingSubscriberGet(string userId, string moduleCode, string eventCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ModuleCode, moduleCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EventCode, eventCode);


            DataSet ds = SqlHelper.ExecuteDataset("sp_GetUsersEventWise", objParam);
            return ds;
        }
        /**********Code Added by   on 14-june-2010 *********/

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="moduleCode">The module code.</param>
        /// <param name="eventCode">The event code.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="subEmailId">The sub email identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaveData(string userId, string moduleCode, string eventCode, bool isActive, string emailId, string subEmailId, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];

            objParam[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ModuleCode, moduleCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EventCode, eventCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EmailID, emailId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.SubEmailID, subEmailId);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);



            DataSet ds = SqlHelper.ExecuteDataset("sp_insertDataModuleEventmapping", objParam);
            return ds;
        }
        #endregion
        /**********Code Added By   on 10-June-2010 **********/
        /**********Code Added by   on 14-june-2010 *********/

        /// <summary>
        /// Events the mapping delete.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="eventDesc">The event desc.</param>
        /// <param name="moduleDesc">The module desc.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingDelete(string userId, string eventDesc, string moduleDesc)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);

            objParam[1] = new SqlParameter(DL.Properties.Resources.EventDesc, eventDesc);

            objParam[2] = new SqlParameter(DL.Properties.Resources.ModuleCode, moduleDesc);

            DataSet ds = SqlHelper.ExecuteDataset("sp_DeleteDataModuleEventmapping", objParam);
            return ds;

        }
        #endregion

        #region Function Related To Password Policy
        /// <summary>
        /// Get data all the password policy data
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PasswordPolicyGet(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PasswordPolicy_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Passwords the policy update.
        /// </summary>
        /// <param name="passwordMinimumLength">Minimum length of the password.</param>
        /// <param name="MinUpperCase">The minimum upper case.</param>
        /// <param name="numericCharacterLength">Length of the numeric character.</param>
        /// <param name="specialCharacterLength">Length of the special character.</param>
        /// <param name="passwordExpireAfterDays">The password expire after days.</param>
        /// <param name="passwordExpireWarningBefore">The password expire warning before.</param>
        /// <param name="passwordReuseAftertimes">The password reuse aftertimes.</param>
        /// <param name="disableUserAccountAfterDays">The disable user account after days.</param>
        /// <param name="unsuccessfulAttemptAllowed">The unsuccessful attempt allowed.</param>
        /// <param name="isDisableUserAccountAfterUnsuccessfulAttempt">if set to <c>true</c> [is disable user account after unsuccessful attempt].</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>DataSet.</returns>
        public DataSet PasswordPolicyUpdate(int passwordMinimumLength, int MinUpperCase, int numericCharacterLength, int specialCharacterLength, int passwordExpireAfterDays, int passwordExpireWarningBefore, int passwordReuseAftertimes, int disableUserAccountAfterDays, int unsuccessfulAttemptAllowed, bool isDisableUserAccountAfterUnsuccessfulAttempt, string companyCode, string modifiedBy, bool isActive)
        {

            SqlParameter[] objParm = new SqlParameter[13];
            objParm[0] = new SqlParameter(DL.Properties.Resources.PasswordMinLen, passwordMinimumLength);
            objParm[1] = new SqlParameter(DL.Properties.Resources.MinUpperCase, MinUpperCase);
            objParm[2] = new SqlParameter(DL.Properties.Resources.NumericCharlen, numericCharacterLength);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SpecialCharlen, specialCharacterLength);
            objParm[4] = new SqlParameter(DL.Properties.Resources.PasswordExpAfterDays, passwordExpireAfterDays);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PasswordExpWarnBefore, passwordExpireWarningBefore);
            objParm[6] = new SqlParameter(DL.Properties.Resources.PasswordReuseAfterTimes, passwordReuseAftertimes);
            objParm[7] = new SqlParameter(DL.Properties.Resources.DisableAcAfterDays, disableUserAccountAfterDays);
            objParm[8] = new SqlParameter(DL.Properties.Resources.UnSuccessfulAtemptAllowed, unsuccessfulAttemptAllowed);
            objParm[9] = new SqlParameter(DL.Properties.Resources.IsDisableAcAfterUnSuccessAttempt, isDisableUserAccountAfterUnsuccessfulAttempt);
            objParm[10] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[12] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PasswordPolicy_Update", objParm);
            return ds;

        }

        #endregion

        #region function related to Group user
        /// <summary>
        /// Users the group get all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserGroupGetAll(string userId)
        {


            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_UserGroup_GetAll", objParm);
            return ds;

        }

        /// <summary>
        /// Users the group update.
        /// </summary>
        /// <param name="userGroupCode">The user group code.</param>
        /// <param name="userGroupName">Name of the user group.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserGroupUpdate(string userGroupCode, string userGroupName, string userId)
        {


            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.UGCode, userGroupCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.UGName, userGroupName);
            objParm[2] = new SqlParameter(DL.Properties.Resources.UserId, userId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_UserGroup_Update", objParm);
            return ds;

        }

        /// <summary>
        /// Users the group delete.
        /// </summary>
        /// <param name="userGroupCode">The user group code.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserGroupDelete(string userGroupCode)
        {


            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.UGCode, userGroupCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_UserGroup_Delete", objParm);
            return ds;

        }

        /// <summary>
        /// Users the group add new.
        /// </summary>
        /// <param name="userGroupCode">The user group code.</param>
        /// <param name="userGroupName">Name of the user group.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserGroupAddNew(string userGroupCode, string userGroupName, string userId)
        {


            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.UGCode, userGroupCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.UGName, userGroupName);
            objParm[2] = new SqlParameter(DL.Properties.Resources.UserId, userId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_UserGroup_Insert", objParm);
            return ds;

        }


        #endregion

        #region function related Business Rules
        /// <summary>
        /// Businesses the rule main insert.
        /// </summary>
        /// <param name="ruleCode">The rule code.</param>
        /// <param name="ruleDesc">The rule desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleMainInsert(string ruleCode, string ruleDesc, string companyCode, string hrLocationCode, string locationAutoId, string areaId, string clientCode, string modifiedBy)
        {


            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter(DL.Properties.Resources.RuleCode, ruleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.RuleDesc, ruleDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRuleMain_Insert", objParm);
            return ds;

        }
        /// <summary>
        /// Businesses the rule pay period insert.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="payPeriodType">Type of the pay period.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="startDay">The start day.</param>
        /// <param name="endDay">The end day.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRulePayPeriodInsert(string businessRuleCode, string payPeriodType, string startDate, string endDate, string startDay, string endDay, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.PayPeriodType, payPeriodType);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StartDate, DateTime.Parse(startDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.EndDate, DateTime.Parse(endDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.StartDay, startDay);
            objParm[5] = new SqlParameter(DL.Properties.Resources.EndDay, endDay);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRulePayPeriod_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// Businesses the rule hours distribution insert.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="isScheduledDaily">if set to <c>true</c> [is scheduled daily].</param>
        /// <param name="isScheduledWeekly">if set to <c>true</c> [is scheduled weekly].</param>
        /// <param name="isScheduledFortnightly">if set to <c>true</c> [is scheduled fortnightly].</param>
        /// <param name="isScheduledMonthly">if set to <c>true</c> [is scheduled monthly].</param>
        /// <param name="isScheduledLeaveHours">if set to <c>true</c> [is scheduled leave hours].</param>
        /// <param name="isScheduledAbsenteeismHours">if set to <c>true</c> [is scheduled absenteeism hours].</param>
        /// <param name="minimumHoursRequiredDaily">The minimum hours required daily.</param>
        /// <param name="minimumHoursRequiredWeekly">The minimum hours required weekly.</param>
        /// <param name="minimumHoursRequiredFortnightly">The minimum hours required fortnightly.</param>
        /// <param name="minimumHoursRequiredMonthly">The minimum hours required monthly.</param>
        /// <param name="minimumHoursRequiredLeaveHrs">The minimum hours required leave HRS.</param>
        /// <param name="minimumHoursRequiredAbsenteeism">The minimum hours required absenteeism.</param>
        /// <param name="maxHoursDaily">The maximum hours daily.</param>
        /// <param name="maxHoursWeekly">The maximum hours weekly.</param>
        /// <param name="maxHoursFortnightly">The maximum hours fortnightly.</param>
        /// <param name="maxHoursMonthly">The maximum hours monthly.</param>
        /// <param name="normalDays">The normal days.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleHoursDistributionInsert(string businessRuleCode, bool isScheduledDaily, bool isScheduledWeekly, bool isScheduledFortnightly, bool isScheduledMonthly, bool isScheduledLeaveHours, bool isScheduledAbsenteeismHours, string minimumHoursRequiredDaily, string minimumHoursRequiredWeekly, string minimumHoursRequiredFortnightly, string minimumHoursRequiredMonthly, string minimumHoursRequiredLeaveHrs, string minimumHoursRequiredAbsenteeism, string maxHoursDaily, string maxHoursWeekly, string maxHoursFortnightly, string maxHoursMonthly, string normalDays, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[19];

            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.IsScheduledDaily, isScheduledDaily);
            objParm[2] = new SqlParameter(DL.Properties.Resources.IsScheduledWeekly, isScheduledWeekly);
            objParm[3] = new SqlParameter(DL.Properties.Resources.IsScheduledFortNightly, isScheduledFortnightly);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsScheduledMonthly, isScheduledMonthly);
            objParm[5] = new SqlParameter(DL.Properties.Resources.IsScheduledLeaveHrs, isScheduledLeaveHours);
            objParm[6] = new SqlParameter(DL.Properties.Resources.IsScheduledAbsenteeismHrs, isScheduledAbsenteeismHours);
            objParm[7] = new SqlParameter(DL.Properties.Resources.MinHrsRqDaily, minimumHoursRequiredDaily);
            objParm[8] = new SqlParameter(DL.Properties.Resources.MinHrsRqWeekly, minimumHoursRequiredWeekly);
            objParm[9] = new SqlParameter(DL.Properties.Resources.MinHrsRqFortNightly, minimumHoursRequiredFortnightly);
            objParm[10] = new SqlParameter(DL.Properties.Resources.MinHrsRqMonthly, minimumHoursRequiredMonthly);
            objParm[11] = new SqlParameter(DL.Properties.Resources.MinHrsRqLeaveHrs, minimumHoursRequiredLeaveHrs);
            objParm[12] = new SqlParameter(DL.Properties.Resources.MinHrsRqAbsenteesim, minimumHoursRequiredAbsenteeism);
            objParm[13] = new SqlParameter(DL.Properties.Resources.MaxHrsPrDaily, maxHoursDaily);
            objParm[14] = new SqlParameter(DL.Properties.Resources.MaxHrsPrWeekly, maxHoursWeekly);
            objParm[15] = new SqlParameter(DL.Properties.Resources.MaxHrsPrFortNightly, maxHoursFortnightly);
            objParm[16] = new SqlParameter(DL.Properties.Resources.MaxHrsPrMonthly, maxHoursMonthly);
            objParm[17] = new SqlParameter(DL.Properties.Resources.NormalDays, normalDays);
            objParm[18] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRuleHrsDistribution_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// Businesses the rule ot details get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleOTDetailsGet(string businessRuleCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRuleOTDetsils_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Businesses the rule ot details insert.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="otCode">The ot code.</param>
        /// <param name="otRate">The ot rate.</param>
        /// <param name="applicableOn">The applicable on.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleOTDetailsInsert(string businessRuleCode, string otCode, string otRate, string applicableOn, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.OTCode, otCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.OTRate, otRate);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ApplicableOn, applicableOn);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRuleOTDetsils_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// Businesses the rule ot details update.
        /// </summary>
        /// <param name="otDetailAutoId">The ot detail automatic identifier.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="otCode">The ot code.</param>
        /// <param name="otRate">The ot rate.</param>
        /// <param name="applicableOn">The applicable on.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleOTDetailsUpdate(string otDetailAutoId, string businessRuleCode, string otCode, string otRate, string applicableOn, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.OTDetailAutoID, otDetailAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.OTCode, otCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.OTRate, otRate);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ApplicableOn, applicableOn);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRuleOTDetsils_Update", objParm);
            return ds;
        }
        /// <summary>
        /// Businesses the rule ot details delete.
        /// </summary>
        /// <param name="otDetailAutoId">The ot detail automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleOTDetailsDelete(string otDetailAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.OTDetailAutoID, otDetailAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRuleOTDetsils_Delete", objParm);
            return ds;
        }
        /// <summary>
        /// Businesses the rule get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleGet(string businessRuleCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRule_fetch", objParm);
            return ds;
        }

        /// <summary>
        /// Businesses the rule get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleGet(string companyCode, string locationAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRule_get", objParm);
            return ds;
        }

        /// <summary>
        /// Businesses the rule delete.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleDelete(string businessRuleCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_BusinessRule_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// Businesses the rule generate pay period client wise.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="payPeriodType">Type of the pay period.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleGeneratePayPeriodClientWise(string locationAutoId, string clientCode, string businessRuleCode, string startDate, string modifiedBy, string payPeriodType)
        {

            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.BusinessRuleCode, businessRuleCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.StartDate, DateTime.Parse(startDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PayPeriodType, payPeriodType);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GenratePayPeriodClientWise", objParm);
            return ds;
        }
        #endregion

        #region Function Related to Constraint Type

        /// <summary>
        /// Constraints the type get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintTypeGetAll(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ConstraintType_GetAll", objParm);
            return ds;
        }
        /// <summary>
        /// Constraints the type insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="constraintTypeCode">The constraint type code.</param>
        /// <param name="constraintTypeDesc">The constraint type desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintTypeInsert(string companyCode, string constraintTypeCode, string constraintTypeDesc, string modifiedBy)
        {


            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConstraintTypeCode, constraintTypeCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ConstraintTypeDesc, constraintTypeDesc);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ConstraintType_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// Constraints the type update.
        /// </summary>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <param name="constraintTypeDesc">The constraint type desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintTypeUpdate(string constraintTypeAutoId, string constraintTypeDesc, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConstraintTypeDesc, constraintTypeDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ConstraintType_Update", objParm);
            return ds;
        }

        /// <summary>
        /// Constraints the type delete.
        /// </summary>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintTypeDelete(string constraintTypeAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ConstraintType_Delete", objParm);
            return ds;
        }
        #endregion

        #region Function Related to Constraint Master

        /// <summary>
        /// Constraints the get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="constraintType">Type of the constraint.</param>
        /// <param name="page">The page.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintGetAll(string companyCode, string constraintType, string page)
        {
            if (string.IsNullOrEmpty(constraintType) || string.IsNullOrEmpty(constraintType))
            { constraintType = "0"; }


            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintType);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Page, page);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Constraint_GetAll", objParm);
            return ds;
        }

        /// <summary>
        /// Constraints the insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="constraintCode">The constraint code.</param>
        /// <param name="constraintDesc">The constraint desc.</param>
        /// <param name="constraintValue">The constraint value.</param>
        /// <param name="constraintOperator">The constraint operator.</param>
        /// <param name="constraintType">Type of the constraint.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintInsert(string companyCode, string constraintCode, string constraintDesc, string constraintValue, string constraintOperator, string constraintType, string modifiedBy)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConstraintCode, constraintCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ConstraintDesc, constraintDesc);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Value, constraintValue);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Operator, constraintOperator);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintType);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Constraint_Insert", objParm);
            return ds;

        }

        /// <summary>
        /// Constraints the update.
        /// </summary>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <param name="constraintDesc">The constraint desc.</param>
        /// <param name="constraintValue">The constraint value.</param>
        /// <param name="constraintOperator">The constraint operator.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintUpdate(string constraintAutoId, string constraintDesc, string constraintValue, string constraintOperator, string modifiedBy)
        {


            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConstraintDesc, constraintDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Value, constraintValue);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Operator, constraintOperator);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Constraint_Update", objParm);
            return ds;
        }
        /// <summary>
        /// Constraints the delete.
        /// </summary>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintDelete(string constraintAutoId)
        {


            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Constraint_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// Constraints the value get.
        /// </summary>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintValueGet(string constraintAutoId, string constraintTypeAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Constraint_GetValueBasedOnConstraintAutoID", objParm);
            return ds;
        }
        /// <summary>
        /// Constraints the description get.
        /// </summary>
        /// <param name="constraintCode">The constraint code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintDescriptionGet(string constraintCode, string companyCode, string constraintTypeAutoId)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ConstraintCode, constraintCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Constraint_GetDescBasedOnConstraintCode", objParm);
            return ds;
        }
        #endregion

        #region Function Related To Component Master

        #region  Function Related To GetData
        /// <summary>
        /// To get the All Data From Training Master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with Company Code,Training Code,Training desc</returns>
        public DataSet ComponentMasterGetAll(string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_ComponentMaster_GetAll", objParam);
            return ds;
        }
        #endregion

        #region Function Related To Insert Data
        /// <summary>
        /// To add a new Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="componentCode">The component code.</param>
        /// <param name="componentDesc">The component desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>ADD status[integer 0 or 1]</returns>
        public DataSet ComponentMasterAdd(string companyCode, string componentCode, string componentDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ComponentCode, componentCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ComponentDesc, componentDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ComponentMaster_Insert", objParam);
            return addStatus;
        }
        #endregion

        #region Function related to Update Data
        /// <summary>
        /// To Update Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="componentCode">The component code.</param>
        /// <param name="componentDesc">The component desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Update Status[integer 1 or 0]</returns>
        public DataSet ComponentMasterUpdate(string companyCode, string componentCode, string componentDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ComponentCode, componentCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ComponentDesc, componentDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMst_ComponentMaster_Update", objParam);
            return updateStatus;
        }
        #endregion

        #region Function related To Delete Data
        /// <summary>
        /// To Delete a Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="componentCode">The component code.</param>
        /// <returns>Delete status[integer 0 or 1]</returns>
        public DataSet ComponentMasterDelete(string companyCode, string componentCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ComponentCode, componentCode);
            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMst_ComponentMaster_Delete", objParam);
            return deleteStatus;
        }
        #endregion
        #endregion

        #region EmployeeTraining
        /// <summary>
        /// Trainings the details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingDetailsGet(string companyCode, string trainingCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            DataSet ds = SqlHelper.ExecuteDataset("mstHR_TrainingDetailsGet_ForSelectedTraining", objParam);
            return ds;
        }

        /// <summary>
        /// Employees the training delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="trainingDate">The training date.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeTrainingDelete(string companyCode, string trainingCode, string employeeNumber, string trainingDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingDate, trainingDate);
            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMst_EmployeeTraining_Delete", objParam);
            return deleteStatus;
        }

        /// <summary>
        /// Refreshers the training generate schedule months.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="validForMonths">The valid for months.</param>
        /// <param name="refTrainAfterNMonths">The reference train after n months.</param>
        /// <param name="refTrainingDays">The reference training days.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet RefresherTrainingGenerateScheduleMonths(string companyCode, string trainingCode, int validForMonths, int refTrainAfterNMonths, int refTrainingDays, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ValidMonths, validForMonths);
            objParam[3] = new SqlParameter(DL.Properties.Resources.RefTrainAfterNMonths, refTrainAfterNMonths);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Duration, refTrainingDays);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            return SqlHelper.ExecuteDataset("udpMstHr_TrainingGenerateScheduleMonths_Insert", objParam);

        }


        /// <summary>
        /// Refreshers the training schedule pattern details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>DataSet.</returns>
        public DataSet RefresherTrainingSchedulePatternDetailsGet(string companyCode, string trainingCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            return SqlHelper.ExecuteDataset("udpMst_RefreshTrainingSchedulePatternDetails_Get", objParam);

        }

        /// <summary>
        /// Trainings the master schedule pattern update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="month">The month.</param>
        /// <param name="trainingDays">The training days.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingMasterSchedulePatternUpdate(string companyCode, string trainingCode, int month, int trainingDays, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, month);
            objParam[3] = new SqlParameter(DL.Properties.Resources.RefTrainingDays, trainingDays);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            return SqlHelper.ExecuteDataset("udpMst_TrainingMasterSchedulePattern_Update", objParam);

        }


        #endregion EmployeeTraining

        #region Zip Master
        /// <summary>
        /// To get the Group Zip Code for a Branch
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeGroupGet(string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_GroupZip_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Zip Code for a Location and Group Zip Code
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeGet(string locationAutoId, string zipCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.GroupZipCode, zipCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Zip_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To delete a Group Zip Code
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="groupZipCode">The group zip code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeGroupDelete(string locationAutoId, string groupZipCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.GroupZipCode, groupZipCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_GroupZip_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To delete a Zip Code
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="groupZipCode">The group zip code.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeDelete(string locationAutoId, string groupZipCode, string zipCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.GroupZipCode, groupZipCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ZipCode, zipCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Zip_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To Update a Group Zip Master
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="groupZipCode">The group zip code.</param>
        /// <param name="groupZipDesc">The group zip desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeGroupUpdate(string locationAutoId, string groupZipCode, string groupZipDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.GroupZipCode, groupZipCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.GroupZipDesc, groupZipDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_GroupZip_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To Update a Zip Master
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="groupZipCode">The group zip code.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="zipDesc">The zip desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeUpdate(string locationAutoId, string groupZipCode, string zipCode, string zipDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.GroupZipCode, groupZipCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ZipCode, zipCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ZipDesc, zipDesc);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Zip_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To Insert in a new Group Zip Code
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="groupZipCode">The group zip code.</param>
        /// <param name="groupZipDesc">The group zip desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeGroupAdd(string locationAutoId, string groupZipCode, string groupZipDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.GroupZipCode, groupZipCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.GroupZipDesc, groupZipDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_GroupZip_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To Insert in a new Zip Code
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="groupZipCode">The group zip code.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="zipDesc">The zip desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeAdd(string locationAutoId, string groupZipCode, string zipCode, string zipDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.GroupZipCode, groupZipCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ZipCode, zipCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ZipDesc, zipDesc);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Zip_Add", objParam);
            return ds;
        }
        #endregion

        #region Interface Mapping Table
        /// <summary>
        /// To get Group Names for Interface Screen
        /// </summary>
        /// <returns>Data Set</returns>
        public DataSet GroupGet()
        {
            SqlParameter[] objParam = new SqlParameter[0];
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGroupGet", objParam);
            return ds;
        }
        /// <summary>
        /// To get Table Name Based on Group Name
        /// </summary>
        /// <param name="groupCode">The group code.</param>
        /// <returns>Data Set</returns>
        public DataSet SubgroupGet(string groupCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.GroupCode, groupCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSubGroupGet", objParam);
            return ds;
        }
        /// <summary>
        /// To get Data for Interface Screen Main Grid
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="dbName">Name of the database.</param>
        /// <returns>Data Set</returns>
        public DataSet InterfaceMappingGet(string tableName, string dbName)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TableName, tableName);
            objParam[1] = new SqlParameter(DL.Properties.Resources.dbName, dbName);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpInterfaceMappingGet", objParam);
            return ds;
        }
        /// <summary>
        /// For Insert Data in InterfaceMapping Table
        /// </summary>
        /// <param name="scolumnName">Name of the scolumn.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="sdataType">Type of the sdata.</param>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="slength">The slength.</param>
        /// <param name="length">The length.</param>
        /// <param name="sperc">The sperc.</param>
        /// <param name="perc">The perc.</param>
        /// <param name="snullable">if set to <c>true</c> [snullable].</param>
        /// <param name="nullable">if set to <c>true</c> [nullable].</param>
        /// <param name="seditable">if set to <c>true</c> [seditable].</param>
        /// <param name="stableName">Name of the stable.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="scollation">The scollation.</param>
        /// <param name="collation">The collation.</param>
        /// <param name="screenName">Name of the screen.</param>
        /// <param name="sscreenfieldName">Name of the sscreenfield.</param>
        /// <param name="screenfieldName">Name of the screenfield.</param>
        /// <param name="sdescription">The sdescription.</param>
        /// <param name="description">The description.</param>
        /// <param name="smandatory">if set to <c>true</c> [smandatory].</param>
        /// <param name="color">The color.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="isprovided">if set to <c>true</c> [isprovided].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MstInterfaceMappingInsert(string scolumnName, string columnName, string sdataType, string dataType, int slength, int length, int sperc, int perc, bool snullable, bool nullable, bool seditable, string stableName, string databaseName, string tableName, string scollation, string collation, string screenName, string sscreenfieldName, string screenfieldName, string sdescription, string description, bool smandatory, string color, int sourceType, string defaultValue, bool isprovided, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[27];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SColumnName, scolumnName);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ColumnName, columnName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SDataType, sdataType);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DataType, dataType);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SLength, slength);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Length, length);
            objParam[6] = new SqlParameter(DL.Properties.Resources.SPerc, sperc);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Perc, perc);
            objParam[8] = new SqlParameter(DL.Properties.Resources.SNullable, snullable);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Nullable, nullable);
            objParam[10] = new SqlParameter(DL.Properties.Resources.SEditable, seditable);
            objParam[11] = new SqlParameter(DL.Properties.Resources.STableName, stableName);
            objParam[12] = new SqlParameter(DL.Properties.Resources.DataBaseName, databaseName);
            objParam[13] = new SqlParameter(DL.Properties.Resources.TableName, tableName);
            objParam[14] = new SqlParameter(DL.Properties.Resources.SCollation, scollation);
            objParam[15] = new SqlParameter(DL.Properties.Resources.Collation, collation);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ScreenName, screenName);
            objParam[17] = new SqlParameter(DL.Properties.Resources.SScreenFieldName, sscreenfieldName);
            objParam[18] = new SqlParameter(DL.Properties.Resources.ScreenFieldName, screenfieldName);
            objParam[19] = new SqlParameter(DL.Properties.Resources.SDescription, sdescription);
            objParam[20] = new SqlParameter(DL.Properties.Resources.Description, description);
            objParam[21] = new SqlParameter(DL.Properties.Resources.SMandatory, smandatory);
            objParam[22] = new SqlParameter(DL.Properties.Resources.Color, color);
            objParam[23] = new SqlParameter(DL.Properties.Resources.SourceType, sourceType);
            objParam[24] = new SqlParameter(DL.Properties.Resources.DefaultValue, defaultValue);
            objParam[25] = new SqlParameter(DL.Properties.Resources.IsProvided, isprovided);
            objParam[26] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstInterfaceMappingInsert", objParam);
            return addStatus;
        }
        /// <summary>
        /// For Update Data in InterfaceMapping Table
        /// </summary>
        /// <param name="rowautoId">The rowauto identifier.</param>
        /// <param name="scolumnName">Name of the scolumn.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="sdataType">Type of the sdata.</param>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="slength">The slength.</param>
        /// <param name="length">The length.</param>
        /// <param name="sperc">The sperc.</param>
        /// <param name="perc">The perc.</param>
        /// <param name="snullable">if set to <c>true</c> [snullable].</param>
        /// <param name="nullable">if set to <c>true</c> [nullable].</param>
        /// <param name="seditable">if set to <c>true</c> [seditable].</param>
        /// <param name="stableName">Name of the stable.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="scollation">The scollation.</param>
        /// <param name="collation">The collation.</param>
        /// <param name="screenName">Name of the screen.</param>
        /// <param name="sscreenfieldName">Name of the sscreenfield.</param>
        /// <param name="screenfieldName">Name of the screenfield.</param>
        /// <param name="sdescription">The sdescription.</param>
        /// <param name="description">The description.</param>
        /// <param name="smandatory">if set to <c>true</c> [smandatory].</param>
        /// <param name="color">The color.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="isprovided">if set to <c>true</c> [isprovided].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MstInterfaceMappingUpdate(decimal rowautoId, string scolumnName, string columnName, string sdataType, string dataType, int slength, int length, int sperc, int perc, bool snullable, bool nullable, bool seditable, string stableName, string databaseName, string tableName, string scollation, string collation, string screenName, string sscreenfieldName, string screenfieldName, string sdescription, string description, bool smandatory, string color, int sourceType, string defaultValue, bool isprovided, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[28];
            objParam[0] = new SqlParameter(DL.Properties.Resources.RowAutoId, rowautoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SColumnName, scolumnName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ColumnName, columnName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SDataType, sdataType);
            objParam[4] = new SqlParameter(DL.Properties.Resources.DataType, dataType);
            objParam[5] = new SqlParameter(DL.Properties.Resources.SLength, slength);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Length, length);
            objParam[7] = new SqlParameter(DL.Properties.Resources.SPerc, sperc);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Perc, perc);
            objParam[9] = new SqlParameter(DL.Properties.Resources.SNullable, snullable);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Nullable, nullable);
            objParam[11] = new SqlParameter(DL.Properties.Resources.SEditable, seditable);
            objParam[12] = new SqlParameter(DL.Properties.Resources.STableName, stableName);
            objParam[13] = new SqlParameter(DL.Properties.Resources.DataBaseName, databaseName);
            objParam[14] = new SqlParameter(DL.Properties.Resources.TableName, tableName);
            objParam[15] = new SqlParameter(DL.Properties.Resources.SCollation, scollation);
            objParam[16] = new SqlParameter(DL.Properties.Resources.Collation, collation);
            objParam[17] = new SqlParameter(DL.Properties.Resources.ScreenName, screenName);
            objParam[18] = new SqlParameter(DL.Properties.Resources.SScreenFieldName, sscreenfieldName);
            objParam[19] = new SqlParameter(DL.Properties.Resources.ScreenFieldName, screenfieldName);
            objParam[20] = new SqlParameter(DL.Properties.Resources.SDescription, sdescription);
            objParam[21] = new SqlParameter(DL.Properties.Resources.Description, description);
            objParam[22] = new SqlParameter(DL.Properties.Resources.SMandatory, smandatory);
            objParam[23] = new SqlParameter(DL.Properties.Resources.Color, color);
            objParam[24] = new SqlParameter(DL.Properties.Resources.SourceType, sourceType);
            objParam[25] = new SqlParameter(DL.Properties.Resources.DefaultValue, defaultValue);
            objParam[26] = new SqlParameter(DL.Properties.Resources.IsProvided, isprovided);
            objParam[27] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstInterfaceMappingUpdate", objParam);
            return addStatus;
        }
        #endregion

        #region Cost Center Mapping
        /// <summary>
        /// To Get Cost Center Mapping data
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostCenterMapping(String locationAutoId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpCostCenterMapping_get", objParm);
            return ds;
        }
        /// <summary>
        /// To Update Cost Center Mapping
        /// </summary>
        /// <param name="compnayCode">The compnay code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="costCenter">The cost center.</param>
        /// <param name="assignment">The assignment.</param>
        /// <param name="site">The site.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostCenterMappingUpdate(String compnayCode, String locationAutoId, String clientCode, String costCenter, String assignment, String site, String modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, compnayCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.CostCenter, costCenter);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Assignment, assignment);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Site, site);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpCostCenterMapping_update", objParm);
            return ds;
        }
        /// <summary>
        /// To Delete Cost Center Mapping
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="assignment">The assignment.</param>
        /// <param name="site">The site.</param>
        /// <param name="costCenter">The cost center.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostCenterMappingDelete(String locationAutoId, String assignment, String site, String costCenter)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Assignment, assignment);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Site, site);
            objParm[3] = new SqlParameter(DL.Properties.Resources.CostCenter, costCenter);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpDeleteCostCenter", objParm);
            return ds;
        }
        /// <summary>
        /// To Insert New Cost Center
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="assignment">The assignment.</param>
        /// <param name="site">The site.</param>
        /// <param name="costCenter">The cost center.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InsertCostCenter(String companyCode, String locationAutoId, String clientCode, String assignment, String site, String costCenter, String modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Assignment, assignment);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Site, site);
            objParm[5] = new SqlParameter(DL.Properties.Resources.CostCenter, costCenter);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpInsertCostCenterMapping", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAssignment(String locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAssignment", objParm);
            return ds;
        }
        /// <summary>
        /// Get Post Assignemnt Wise
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetSiteAssignmentWise(String asmtMasterAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetPostAssignmentWise", objParm);
            return ds;
        }
        #endregion

        #region Future Date Rota Entery
        /// <summary>
        /// To Get All Future Date Rota Entry
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet FutureDateRotaEntryGetAll(string companyCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_FutureDateRotaEntry_GetAll", objParm);
            return ds;
        }
        /// <summary>
        /// To Add Future Date Rota
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="allowed">The allowed.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet FutureDateRotaEntryAddNew(string companyCode, string locationAutoId, string clientCode, string asmtCode, string allowed, string userId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Allowed, allowed);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMasters_FutureDateRotaEntry_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// To Delete Future Date Rota
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet FutureDateRotaEntryDelete(string companyCode, string locationAutoId, string clientCode, string asmtCode)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_FutureDateRotaEntry_Delete", objParm);
            return ds;
        }
        #endregion

        #region Function Related to Allowance
        /// <summary>
        /// To Add Allowances
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="allowanceDescription">The allowance description.</param>
        /// <param name="element">The element.</param>
        /// <param name="elementType">Type of the element.</param>
        /// <param name="rateId">The rate identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterAdd(String locationAutoId, String allowanceDescription, String element, String elementType, String rateId, String modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AllowanceDescription, allowanceDescription);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Element, element);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ElementType, elementType);
            objParam[4] = new SqlParameter(DL.Properties.Resources.RateID, float.Parse(rateId));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpInsertAllowance", objParam);
            return ds;
        }
        /// <summary>
        /// To Update Allowance
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <param name="allowanceDescription">The allowance description.</param>
        /// <param name="element">The element.</param>
        /// <param name="rateId">The rate identifier.</param>
        /// <param name="elementType">Type of the element.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterUpdate(String locationAutoId, String allowanceAutoId, String allowanceDescription, String element, String rateId, String elementType)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AllowanceDescription, allowanceDescription);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Element, element);
            objParam[4] = new SqlParameter(DL.Properties.Resources.RateID, float.Parse(rateId));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ElementType, elementType);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUpdateAllowance", objParam);
            return ds;
        }
        /// <summary>
        /// To Delete Allowance
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterDelete(String allowanceAutoId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpDeleteAllowance", objParam);
            return ds;
        }
        /// <summary>
        /// To Get Allowances
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterGet(String locationAutoId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAllowance", objParam);
            return ds;
        }
        #endregion

        #region  Function Related to PrePostFix
        /// <summary>
        /// To Get SeqField from Quick Code
        /// </summary>
        /// <param name="CompanyCode">The Company automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PrePostFixGet(String CompanyCode)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_AutogenratedSeq_MstPrePostFix_Get", objParam);
            return ds;
        }

        /// <summary>
        /// To Insert/Update Prefix Postfix Master data
        /// </summary>
        /// <param name="CompanyCode">The Company automatic identifier.</param>
        /// <param name="SeqField">The SeqField automatic identifier.</param>
        /// <param name="IsAutoUpdatePostFix">The IsAutoUpdatePostFix automatic identifier.</param>
        /// <param name="PrefixStr">The PrefixStr automatic identifier.</param>
        /// <param name="PostfixStr">The PostfixStr automatic identifier.</param>
        /// <param name="RunningSeq">The RunningSeq automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PrePostFixInsertUpdate(String CompanyCode, string SeqField, bool IsAutoUpdatePostFix, string PrefixStr, string PostfixStr, string RunningSeq)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.seqField, SeqField);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AutoUpdatePostFix, IsAutoUpdatePostFix);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PrefixText, PrefixStr);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PostFixText, PostfixStr);
            objParam[5] = new SqlParameter(DL.Properties.Resources.RunningSequence, RunningSeq);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstPrePostFix_Insert_Update", objParam);
            return ds;
        }
        #endregion

        #region  Function Related to ScheduleContextMenu
        /// <summary>
        /// To Get MenuItemCode
        /// </summary>
        /// <param name="LocationCode">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleContextMenuGet(string LocationCode)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationCode, LocationCode);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstContextMenuMapping_Get", objParam);
            return ds;
        }

        /// <summary>
        /// To Insert/Update Schedule Context Menu Mapping
        /// </summary>
        /// <param name="LocationCode">The LocationCode automatic identifier.</param>
        /// <param name="MenuAutoID">The MenuAutoID automatic identifier.</param>
        /// <param name="IsActive">The IsActive automatic identifier.</param>
        /// <param name="AttendanceType">The AttendanceType automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleContextMenuInsertUpdate(String LocationCode, string MenuAutoID, bool IsActive, string AttendanceType)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationCode, LocationCode);
            objParam[1] = new SqlParameter("@MenuAutoID", MenuAutoID);//DL.Properties.Resources.
            objParam[2] = new SqlParameter(DL.Properties.Resources.IsActive, IsActive);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AttendanceType, AttendanceType);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstContextMenuMapping_Insert_Update", objParam);
            return ds;
        }
        #endregion

        #region New Functions Related to Allowance on 7-Jan-2014
        /// <summary>
        /// To Get Allowances
        /// </summary>
        /// <param name="locationAutoId">location Auto Id</param>
        /// <returns>allowances dataset for the location Auto Id</returns>
        public DataSet AllowanceMasterGetAll(string locationAutoId)
        {
            var objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstAllowanceGet", objParam);
        }
        /// <summary>
        /// To Insert the Allowance
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="allowanceCode">The allowance code.</param>
        /// <param name="allowanceDescription">The allowance description.</param>
        /// <param name="element">The element.</param>
        /// <param name="elementType">Type of the element.</param>
        /// <param name="unitType">Type of the unit.</param>
        /// <param name="rateId">The rate identifier.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="measurement">The measurement.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterInsertRecord(String locationAutoId, String allowanceCode, String allowanceDescription, String element, String elementType, String unitType, String rateId, String designationCode, String measurement, String modifiedBy)
        {
            var objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AllowanceCode, allowanceCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AllowanceDescription, allowanceDescription);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Element, element);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ElementType, elementType);
            objParam[5] = new SqlParameter(DL.Properties.Resources.UnitType, unitType);
            objParam[6] = new SqlParameter(DL.Properties.Resources.RateID, Convert.ToDecimal(rateId));
            objParam[7] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Measurement, measurement);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstAllowanceInsert", objParam);
        }
        /// <summary>
        /// To Update the allowance
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="allowanceCode">The allowance code.</param>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <param name="allowanceDescription">The allowance description.</param>
        /// <param name="element">The element.</param>
        /// <param name="rateId">The rate identifier.</param>
        /// <param name="elementType">Type of the element.</param>
        /// <param name="unitType">Type of the unit.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="measurement">The measurement.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterUpdateRecord(String locationAutoId, String allowanceCode, String allowanceAutoId, String allowanceDescription, String element, String rateId, String elementType, String unitType, String designationCode, String measurement, String modifiedBy)
        {
            var objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AllowanceCode, allowanceCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AllowanceDescription, allowanceDescription);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Element, element);
            objParam[5] = new SqlParameter(DL.Properties.Resources.RateID, Convert.ToDecimal(rateId));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ElementType, elementType);
            objParam[7] = new SqlParameter(DL.Properties.Resources.UnitType, unitType);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Measurement, measurement);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstAllowanceUpdate", objParam);
        }
        /// <summary>
        /// To Delete Allowance
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterDeleteRecord(String allowanceAutoId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.allowanceAutoId, allowanceAutoId);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstAllowanceDelete", objParam);
            return ds;
        }
        #endregion

        #region OT Reason Objects
        /// <summary>
        /// To Get OT Reasons
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverTimeReasonGet(String companyCode, String locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTREasonGet", objParm);
            return ds;
        }
        /// <summary>
        /// To Sace OT Reasons
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="reasonDesc">The reason desc.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverTimeReasonSave(String companyCode, String reasonCode, String reasonDesc, bool isActive, String locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ReasonCode, reasonCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ReasonDesc, reasonDesc);
            objParm[3] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonSave", objParm);
            return ds;
        }
        /// <summary>
        /// To Update OT Reasons
        /// </summary>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="reasonDesc">The reason desc.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverTimeReasonUpdate(String reasonCode, String reasonDesc, bool isActive, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ReasonCode, reasonCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ReasonDesc, reasonDesc);
            objParm[2] = new SqlParameter(DL.Properties.Resources.IsActive, isActive);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonUpdate", objParm);
            return ds;
        }
        /// <summary>
        /// To Delete Reason
        /// </summary>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverTimeReasonDelete(String reasonCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ReasonCode, reasonCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonDelete", objParm);


            return ds;
        }

        #endregion

        #region OT Reason Mapping
        /// <summary>
        /// To Get OT Reasons
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverTimeReasonGetAll(String companyCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTREasonGetAll", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Location Description
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet LocationDescGet(String locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpLocationDescGet", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Clients Based On Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonClientGet(String locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonClientGet", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Assignemnts
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonAssignmentGet(String locationAutoId, String clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonAssignmentGet", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Post
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonPostGet(String locationAutoId, String clientCode, String asmtCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonPostGet", objParm);
            return ds;
        }
        /// <summary>
        /// To Insert OT Reason Mapping
        /// </summary>
        /// <param name="otReason">The ot reason.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="post">The post.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonMappingInsert(String otReason, String locationAutoId, String clientCode, String asmtCode, String post, String modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.OTReason, otReason);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Post, post);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonMappingInsert", objParm);
            return ds;
        }
        /// <summary>
        /// To Get OT Reason For Mapping
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="post">The post.</param>
        /// <returns>DataSet</returns>
        public DataSet OtReasonMappingLocationWiseGet(String companyCode, String locationAutoId, String clientCode, String asmtCode, String post)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Post, post);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonMappingLocationWiseGet", objParm);
            return ds;
        }
        /// <summary>
        /// To Delete Selected Reason Code Mapping
        /// </summary>
        /// <param name="reasonAutoID">The reason automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtReasonMappingDelete(String reasonAutoID)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ReasonAutoID, reasonAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOTReasonMappingDelete", objParm);
            return ds;
        }
        #endregion

        #region Employee Inbox Portal
        /// <summary>
        /// Fills DataSet for Request Type
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet RequestTypeGetAll()
        {
            using (DataSet dsRequest = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpEPortalRequestType_GeTAll"))
            {
                return dsRequest;
            }
        }

        /// <summary>
        /// Employees the request get by series user identifier.
        /// </summary>
        /// <param name="seriesName">Name of the series.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRequestGetBySeriesUserId(string seriesName, string companyCode, string userId)
        {
            var objParm = new SqlParameter[3];


            objParm[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParm[1] = new SqlParameter(Properties.Resources.SeriesName, seriesName);
            objParm[2] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);

            using (DataSet dsRequest = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpEPortalRequestBySeriesUserID_GeTAll", objParm))
            {
                return dsRequest;
            }
        }
        #endregion

        #region Export Master To Excel

        /// <summary>
        /// Exports the master to excel.
        /// </summary>
        /// <param name="eType">Type of the e.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ExportMasterToExcel(string eType, string companyCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.type, eType);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpExportMasterToExcel", objParm);
            return ds;
        }

        #endregion
        #region Update Flat File Interface Path
        /// <summary>
        /// Update Flat File Interface Path
        /// </summary>
        /// <param name="uploadDesc">The upload desc.</param>
        /// <returns>DataSet.</returns>
        public DataSet UpdateFlatFilePath(string uploadDesc)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.UploadDesc, uploadDesc);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUpdateFlatFilePath", objParm);
            return ds;
        }

        #endregion
        #region Flat File Interface
        /// <summary>
        /// No Input Parameters
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet MstProcessInterfaceData()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstProcessInterfaceData", null);
            return ds;
        }

        #endregion

        #region Barred Reason master

        /// <summary>
        /// To get All data from Barred Reason Master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BarredReasonMasterGetAll(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_BarredReason_GetAll", objParam);
            return ds;
        }



        /// <summary>
        /// Insert into barred employee master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="Reason">reason is passed</param>
        /// <param name="ReasonDesc">Description is passesd</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet udpMst_BarredReason_Insert(string companyCode, string Reason, string ReasonDesc, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Reason, Reason);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ReasonDesc, ReasonDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_BarredReason_Insert", objParam);
            return ds;

        }


        /// <summary>
        /// TO delete data from QuickCode master
        /// </summary>
        /// <param name="Reason">The reason.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet udpMst_BarredReason_Delete(string Reason, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Reason, Reason);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_BarredReason_Delete", objParam);
            return ds;

        }


        #endregion

        #region Function Related to Get Data of Group and SubGroup
        //public DataSet GroupMasterMasterGetAll()
        //{
        //    DataSet ds = SqlHelper.ExecuteDataset("udpMst_GroupAll_GetAll");
        //    return ds;
        //}
        //public DataSet SubGroupMasterMasterGetAll(int GroupID)
        //{
        //    SqlParameter[] objParm = new SqlParameter[1];
        //    objParm[0] = new SqlParameter(DL.Properties.Resources.GroupID, GroupID);
        //    DataSet ds = SqlHelper.ExecuteDataset("udpMst_SubGroupAll_GetAll", objParm);
        //    return ds;
        //}
        public DataSet EmployeeItemsGroupGetAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UpdHrEmployeeItemsGroupGetAll");
            return ds;
        }
        public DataSet EmployeeItemInsertNUpdate(string ItemCode, string ItemName, string ItemGroupName, string ItemSubGroupName, string ModifiedBy, string flag)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ItemCode, ItemCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemName, ItemName);

            objParam[2] = new SqlParameter(DL.Properties.Resources.ItemGroupName, ItemGroupName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ItemSubGroupName, ItemSubGroupName);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Flag, flag);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UpdHrEmployeeItemInsertNUpdate", objParam);
            return ds;
        }
        public DataSet EmployeeItemDelete(string ItemCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ItemCode, ItemCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UpdHrEmployeeItemDelete", objParam);
            return ds;
        }
        public DataSet EmployeeItemsGetAll()
        {
            SqlParameter[] objParam = new SqlParameter[0];

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpHrEmployeeItemsGetAll", objParam);
            return ds;
        }
        #endregion

        #region Function Related to DeviceCardAsmtMapping

        /// <summary>
        /// DeviceCardAsmtMapping get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet DeviceCardAsmtMappingGetAll(String BaseLocationAutoID, string ddlselect, string txtsearch)
        {

            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FilterParam, ddlselect);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Value, txtsearch);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstDeviceCardAsmtMappingGetAll", objParm);
            return ds;
        }

        /// <summary>
        /// To add a new DeviceCardAsmtMapping
        /// </summary>
        /// <param name="languageCode">The Client code.</param>
        /// <param name="languageDesc">The AsmtId desc.</param>
        /// <param name="languageDesc">The Asmt CardNumber.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet message string</returns>
        public DataSet DeviceCardAsmtMappingAddNew(string LocationAutoId, string ClientCode, string AsmtId, string AsmtCardNo, string EffectiveFromDate, string EffectiveToDate, string modifiedBy)
        {


            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, AsmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtCardNo, AsmtCardNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FromDate, Common.DateFormat(EffectiveFromDate, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, Common.DateFormat(EffectiveToDate, true));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstDeviceCardAsmtMappingInsert", objParam);
            return addStatus;

        }

        /// <summary>
        /// To Update DeviceCardAsmtMapping
        /// </summary>
        /// <param name="LocationAutoId"></param>
        /// <param name="languageCode">The Client code.</param>
        /// <param name="languageDesc">The AsmtId desc.</param>
        /// <param name="languageDesc">The Asmt CardNumber.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet message string</returns>
        public DataSet DeviceCardAsmtMappingUpdate(string LocationAutoId, string ClientCode, string AsmtId, string AsmtCardNo, string FromDate, string ToDate, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, AsmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtCardNo, AsmtCardNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FromDate, Common.DateFormat(FromDate, true));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, Common.DateFormat(ToDate, true));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstDeviceCardAsmtMappingUpdate", objParam);
            return updateStatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CardAsmtMappingAutoId"></param>
        /// <param name="AsmtCardNo">lkjhlkhkjhgkjhg</param>
        /// <returns></returns>
        public DataSet DeviceCardAsmtMappingDelete(string CardAsmtMappingAutoId, string AsmtCardNo)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CardAsmtMappingAutoId, Convert.ToInt32(CardAsmtMappingAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCardNo, AsmtCardNo);

            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMstDeviceCardAsmtMappingDelete", objParam);
            return deleteStatus;

        }
        #endregion
    }
}
