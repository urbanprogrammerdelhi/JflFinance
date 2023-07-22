// ***********************************************************************
// Assembly         : BL
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
using System.Linq;
using System.Globalization;

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class MastersManagement.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class MastersManagement
    {

        #region Function Related to Company

        #region Function Related to Get Data

        /// <summary>
        /// To get the All Compnies
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="isAdmin">The is admin.</param>
        /// <returns>Dataset with companyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet CompanyGetAll(string userId, string isAdmin)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            if (isAdmin == BL.Properties.Resources.AdminType)
            {
                return objdlMastersManagement.CompanyGetAll();
            }
            else
            {
                return objdlMastersManagement.CompanyGetAll(userId);
            }

        }

        /// <summary>
        /// To get the Company for Company Code
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with companyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet CompanyDetailsGet(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CompanyDetailsGet(companyCode);
            return ds;
        }

        /// <summary>
        /// To get the All Compnies code and CompanyDesc
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="isAdmin">The is admin.</param>
        /// <returns>Dataset with companyCode, CompanyDesc</returns>
        public DataSet CompanyDescriptionGetAll(string companyCode, string isAdmin)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            if (isAdmin == BL.Properties.Resources.AdminType)
            {
                return objdlMastersManagement.CompanyDescriptionGetAll();
            }
            else
            {
                return objdlMastersManagement.CompanyDescriptionGet(companyCode);
            }

        }

        /// <summary>
        /// To get the All Compnies code and CompanyDesc
        /// </summary>
        /// <returns>Dataset with companyCode, CompanyDesc</returns>

        public DataSet CompanyDescriptionGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CompanyDescriptionGetAll();
            return ds;
        }

        #endregion

        #region Function Related to Insert Data

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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CompanyAddNew(companyCode, companyDesc, companyAddress, userId);
            return ds;
        }

        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update a Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="companyDesc">The company desc.</param>
        /// <param name="companyAddress">The company address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet CompanyDescriptionUpdate(string companyCode, string companyDesc, string companyAddress, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CompanyDescriptionUpdate(companyCode, companyDesc, companyAddress, userId);
            return ds;
        }

        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>message string</returns>
        public DataSet CompanyDelete(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CompanyDelete(companyCode);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to HrLocation

        #region Function Related to Get Data

        /// <summary>
        /// To get the All HrLocations
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="isAdmin">The is admin.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with HrLocationAutoId, companyCode, CompanyDesc, HrLocationCode, HrLocationDesc, HrLocationAddress</returns>
        public DataSet HRLocationGetAll(string companyCode, string isAdmin, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            if (isAdmin == BL.Properties.Resources.AdminType)
            {
                return objdlMastersManagement.HRLocationGetAll();
            }
            else
            {
                return objdlMastersManagement.HRLocationGetAll(companyCode, userId);
            }

        }

        /// <summary>
        /// To get the All HrLocations
        /// </summary>
        /// <returns>Dataset with HrLocationAutoId, companyCode, CompanyDesc, HrLocationCode, HrLocationDesc, HrLocationAddress</returns>
        public DataSet HRLocationGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.HRLocationGetAll();
            return ds;
        }

        /// <summary>
        /// To get the All HrLocation
        /// </summary>
        /// <returns>Dataset with HrLocationCode, HrLocationDesc</returns>
        public DataSet HRLocationDescriptionGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.HRLocationDescriptionGetAll();
            return ds;
        }

        /// <summary>
        /// To get the All HrLocation of a company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with HrLocationCode, HrLocationDesc</returns>
        public DataSet HRLocationDescriptionGetAll(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.HRLocationDescriptionGetAll(companyCode);
            return ds;
        }

        /// <summary>
        /// To get the HrLocation Details for companyCode and HrLocationCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>Dataset with companyCode, CompanyDesc, CompanyAddress, HrLocationCode, HrLocationDesc, HrLocationAddress</returns>
        public DataSet HRLocationDescriptionGet(string companyCode, string hrLocationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.HRLocationDescriptionGet(companyCode, hrLocationCode);
            return ds;
        }
        #endregion

        #region Function Related to Insert Data

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

            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.HRLocationAddNew(companyCode, hrLocationCode, hrLocationDesc, hrLocationAddress, userId);
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

            DL.MastersManagement ObjectMaster = new DL.MastersManagement();
            DataSet ds = ObjectMaster.HolidayAllBranchesInsert(companyCode, locationAutoId, branch, modifiedBy);
            return ds;

        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update a HrLocation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="hrLocationDesc">The hr location desc.</param>
        /// <param name="hrLocationAddress">The hr location address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet HRLocationUpdate(string companyCode, string hrLocationCode, string hrLocationDesc, string hrLocationAddress, string userId)
        {

            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.HRLocationUpdate(companyCode, hrLocationCode, hrLocationDesc, hrLocationAddress, userId);
            return ds;
        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a HrLocation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>message string</returns>
        public DataSet HRLocationDelete(string companyCode, string hrLocationCode)
        {

            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.HRLocationDelete(companyCode, hrLocationCode);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Location
        #region Function Related to Get Data

        /// <summary>
        /// To get the All Locations
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="isAdmin">The is admin.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with locationAutoId, companyCode, CompanyDesc, HrLocationCode, HrLocationDesc, LocationCode, LocationDesc, LocationAddress</returns>
        public DataSet LocationGetAll(string companyCode, string hrLocationCode, string isAdmin, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            if (isAdmin == BL.Properties.Resources.AdminType)
            {
                return objdlMastersManagement.LocationGetAll();
            }
            else
            {
                return objdlMastersManagement.LocationDescriptionGet(companyCode, hrLocationCode, userId);
            }

        }
        /// <summary>
        /// To get the All Locations
        /// </summary>
        /// <returns>Dataset with locationAutoId, companyCode, CompanyDesc, HrLocationCode, HrLocationDesc, LocationCode, LocationDesc, LocationAddress</returns>
        public DataSet LocationGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationGetAll();
            return ds;
        }
        /// <summary>
        /// Locations the description get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet LocationDescriptionGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationDescriptionGetAll();
            return ds;
        }

        /// <summary>
        /// Locations the description get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LocationDescriptionGetAll(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationDescriptionGetAll(companyCode);
            return ds;
        }
        /// <summary>
        /// to get the LocationAUTOId
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>LocationAUTOId</returns>
        public DataSet LocationAutoIdGet(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationAutoIdGet(companyCode, hrLocationCode, locationCode);
            return ds;
        }

        /// <summary>
        /// To get the Location Details for companyCode and HrLocationCode and LocationCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>Dataset with companyCode, CompanyDesc, CompanyAddress, HrLocationCode, HrLocationDesc, HrLocationAddress, LocationCode, LocationDesc, LocationAddress</returns>
        public DataSet LocationDetailGet(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationDetailGet(companyCode, hrLocationCode, locationCode);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationDescriptionGetAll(companyCode, hrLocationCode);
            return ds;
        }
        /// <summary>
        /// Locations the description get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCodeArray">The hr location code array.</param>
        /// <returns>DataSet.</returns>
        public DataSet LocationDescriptionGetAll(string companyCode, string[] hrLocationCodeArray)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationDescriptionGetAll(companyCode);
            DataTable dt = new DataTable();
            dt.Locale = CultureInfo.InvariantCulture;

            if (hrLocationCodeArray.Length > 0)
            {
                dt.Columns.Add(new DataColumn(BL.Properties.Resources.fldHrLocation, typeof(string)));
                for (int i = 0; i < hrLocationCodeArray.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[BL.Properties.Resources.fldHrLocation] = hrLocationCodeArray[i].ToString();
                    dt.Rows.Add(dr);
                }
            }


            var Location = ds.Tables[0].AsEnumerable();
            var HrLocation = dt.AsEnumerable();

            var query =
                from Loc in Location
                join HrLoc in HrLocation
                on Loc.Field<string>(BL.Properties.Resources.fldHrLocationCode)
                equals HrLoc.Field<string>(BL.Properties.Resources.fldHrLocation) ///into ords
                select new
                {
                    LocationCode =
                        Loc.Field<string>(BL.Properties.Resources.fldLocationCode),
                    LocationDesc =
                        Loc.Field<string>(BL.Properties.Resources.fldLocationDesc)
                };

            DataSet dsResult = new DataSet();
            DataTable dtResult = new DataTable();
            dsResult.Locale = CultureInfo.InvariantCulture;

            dtResult.Columns.Add(new DataColumn(BL.Properties.Resources.fldLocationCode, typeof(string)));
            dtResult.Columns.Add(new DataColumn(BL.Properties.Resources.fldLocationDesc, typeof(string)));
            dsResult.Tables.Add(dtResult);

            foreach (var result in query)
            {
                dsResult.Tables[0].Rows.Add(new object[] { result.LocationCode, result.LocationDesc });
            }

            return dsResult;

        }

        #endregion

        #region Function Related to Insert Data

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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationAddNew(companyCode, hrLocationCode, locationCode, locationDesc, locationAddress, userId);
            return ds;
        }

        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update a Location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="locationDesc">The location desc.</param>
        /// <param name="locationAddress">The location address.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message DataSet</returns>
        public DataSet LocationUpdate(string companyCode, string hrLocationCode, string locationCode, string locationDesc, string locationAddress, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationUpdate(companyCode, hrLocationCode, locationCode, locationDesc, locationAddress, userId);
            return ds;
        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Location
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>message string</returns>
        public DataSet LocationDelete(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LocationDelete(companyCode, hrLocationCode, locationCode);
            return ds;
        }
        #endregion

        #endregion

        #region Role Master

        #region Function Related To Get Data
        /// <summary>
        /// To get the RoleCode and Description for a Company from RoleMaster
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleMasterGet(string companyCode)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.RoleMasterGet(companyCode);
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

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.RoleMasterAddNew(companyCode, roleCode, roleDesc, modifiedBy);
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

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.RoleMasterUpdate(companyCode, roleCode, roleDesc, modifiedBy);
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

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.RoleMasterDelete(companyCode, roleCode);
            return ds;
        }
        #endregion

        #region Function Related To Role Details

        #region Function Related To Get Data
        /// <summary>
        /// To get RoleCode Effective dates and Rates from mstRoleRate
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="roleCode">The role code.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleDetailGet(string locationAutoId, string roleCode)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.RoleDetailGet(locationAutoId, roleCode);
            return ds;
        }

        #endregion

        #region Function Related To Update Data
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

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.RoleDetailUpdate(locationAutoId, roleCode, effectiveFrom, effectiveTo, rate, modifiedBy);
            return ds;
        }

        #endregion

        #endregion


        #endregion

        #region Task Master

        #region Function Related To Get Data
        /// <summary>
        /// To get the TaskAutoId and Description for a Location from TaskMaster
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>TaskAutoId,TaskDesc in dataset</returns>
        public DataSet TaskMasterGet(string locationAutoId)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.TaskMasterGet(locationAutoId);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.TaskMasterAddNew(locationAutoId, taskDesc, modifiedBy);
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

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.TaskMasterUpdate(taskAutoId, taskDesc, modifiedBy);
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

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.TaskMasterDelete(taskAutoId);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To Qualification Master

        /// <summary>
        /// Qualifications the grade get.
        /// </summary>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QualificationGradeGet(string qualificationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.QualificationGradeGet(qualificationCode);
            return ds;

        }

        #region Function Related To Get Data

        /// <summary>
        /// To get the All Data From Qualification Master
        /// </summary>
        /// <returns>Dataset with Qualification Code,Qualification desc</returns>
        public DataSet QualificationMasterGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.QualificationMasterGetAll();
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
        /// <returns>dataset message string</returns>
        public DataSet QualificationMasterAddNew(string qualificationCode, string qualificationDesc, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.QualificationMasterAddNew(qualificationCode, qualificationDesc, modifiedBy);
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
        /// <returns>DataSet message string</returns>
        public DataSet QualificationMasterUpdate(string qualificationCode, string qualificationDesc, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.QualificationMasterUpdate(qualificationCode, qualificationDesc, modifiedBy);
            return updateStatus;
        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Qualification
        /// </summary>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>DataSet message string</returns>
        public DataSet QualificationMasterDelete(string qualificationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet deleteStatus = objdlMastersManagement.QualificationMasterDelete(qualificationCode);
            return deleteStatus;
        }
        #endregion


        #endregion

        #region Function Related To Training Master

        #region Function Related To Get Data
        /// <summary>
        /// To get the All Data From Training Master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with Company Code,Training Code,Training desc</returns>
        public DataSet TrainingMasterGetAll(string companyCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.TrainingMasterGetAll(companyCode);
            return ds;
        }

        /// <summary>
        /// Trainings the category get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingCategoryGetAll(string companyCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.TrainingCategoryGetAll(companyCode);
            return ds;
        }

        /// <summary>
        /// Trainings the levels get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingLevelsGetAll(string companyCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.TrainingLevelsGetAll(companyCode);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.SubstituteTrainingDetailsGetAll(companyCode, trainingCode);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.SubstituteTrainingDetailsGet(companyCode, trainingCode);
            return ds;
        }

        /// <summary>
        /// Refreshes the training get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet RefreshTrainingGetAll(string companyCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.RefreshTrainingGetAll(companyCode);
            return ds;
        }

        #endregion

        #region Function Related TO Insert Data
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
        /// <param name="refreshTrainingAfterMonths">The refresh training after months.</param>
        /// <param name="refreshTrainingDays">The refresh training days.</param>
        /// <param name="isTrainingFlexi">if set to <c>true</c> [is training flexi].</param>
        /// <param name="leeWayDays">The lee way days.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet message string</returns>
        public DataSet TrainingDetailsAddNew(string companyCode, string trainingCode, string trainingDesc, string trainingCategory, string trainingLevel, string refreshTraining, string validMonths, string refreshTrainingAfterMonths, string refreshTrainingDays, bool isTrainingFlexi, string leeWayDays, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.TrainingDetailsAddNew(companyCode, trainingCode, trainingDesc, trainingCategory, trainingLevel, refreshTraining, validMonths, refreshTrainingAfterMonths, refreshTrainingDays, isTrainingFlexi, leeWayDays, modifiedBy);
            return addStatus;
        }


        /// <summary>
        /// Substitutes the training insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="mainTrainingCode">The main training code.</param>
        /// <param name="subTrainingCode">The sub training code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubstituteTrainingInsert(string companyCode, string mainTrainingCode, string subTrainingCode, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.SubstituteTrainingInsert(companyCode, mainTrainingCode, subTrainingCode, modifiedBy);
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
        /// <param name="refreshTrainingAfterMonths">The refresh training after months.</param>
        /// <param name="refreshTrainingDays">The refresh training days.</param>
        /// <param name="isTrainingFlexi">if set to <c>true</c> [is training flexi].</param>
        /// <param name="leeWayDays">The lee way days.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet message string</returns>
        public DataSet TrainingUpdate(string companyCode, string trainingCode, string trainingDesc, string trainingCategory, string trainingLevel, string refreshTraining, string validMonths, string refreshTrainingAfterMonths, string refreshTrainingDays, bool isTrainingFlexi, string leeWayDays, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.TrainingUpdate(companyCode, trainingCode, trainingDesc, trainingCategory, trainingLevel, refreshTraining, validMonths, refreshTrainingAfterMonths, refreshTrainingDays, isTrainingFlexi, leeWayDays, modifiedBy);
            return updateStatus;
        }

        /// <summary>
        /// Substitutes the training details update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="mainTrainingCode">The main training code.</param>
        /// <param name="oldSubTrainingCode">The old sub training code.</param>
        /// <param name="newSubTrainingCode">The new sub training code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubstituteTrainingDetailsUpdate(string companyCode, string mainTrainingCode, string oldSubTrainingCode, string newSubTrainingCode, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.SubstituteTrainingDetailsUpdate(companyCode, mainTrainingCode, oldSubTrainingCode, newSubTrainingCode, modifiedBy);
            return updateStatus;
        }

        /// <summary>
        /// Substitutes the training details delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="mainTrainingCode">The main training code.</param>
        /// <param name="subTrainingCode">The sub training code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubstituteTrainingDetailsDelete(string companyCode, string mainTrainingCode, string subTrainingCode, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.SubstituteTrainingDetailsDelete(companyCode, mainTrainingCode, subTrainingCode, modifiedBy);
            return updateStatus;
        }


        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>message String</returns>
        public DataSet TrainingDelete(string companyCode, string trainingCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet deleteStatus = objdlMasterManagement.TrainingDelete(companyCode, trainingCode);
            return deleteStatus;
        }

        #endregion


        #endregion

        #region Functions Related to Language Master

        #region Function Related to Get Data
        /// <summary>
        /// To get the All Data From Language Master
        /// </summary>
        /// <returns>Dataset with Language Code,Language desc</returns>
        public DataSet LanguageMasterGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.LanguageMasterGetAll();
            return ds;

        }
        #endregion

        #region Function Related to Insert Data
        /// <summary>
        /// To add a new Language
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        /// <param name="languageDesc">The language desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet message string</returns>
        public DataSet LanguageMasterAddNew(string languageCode, string languageDesc, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.LanguageMasterAddNew(languageCode, languageDesc, modifiedBy);
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
        /// <returns>DataSet message string</returns>
        public DataSet LanguageMasterUpdate(string languageCode, string languageDesc, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.LanguageMasterUpdate(languageCode, languageDesc, modifiedBy);
            return updateStatus;
        }
        #endregion

        #region Function Related To Delete Data
        /// <summary>
        /// To Delete a language
        /// </summary>
        /// <param name="languageCode">The language code.</param>
        /// <returns>DataSet message string</returns>
        public DataSet LanguageMasterDelete(string languageCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet deleteStatus = objdlMasterManagement.LanguageMasterDelete(languageCode);
            return deleteStatus;
        }
        #endregion

        #endregion

        #region Function Related to Designation

        #region Function Related to Get Data

        /// <summary>
        /// To get the All Designation
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with companyCode, designationCode, designationDesc, DesignationShortName</returns>
        public DataSet DesignationMasterGetAll(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.DesignationMasterGetAll(companyCode);
            return ds;
        }
      
        /// <summary>
        /// To get designationCode, designationDesc, DesignationCodeDesc to fill the DropDownList
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DesignationMasterGet(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.DesignationMasterGet(companyCode);
            return ds;
        }

        #endregion
        #region Function Related to Grade

        public DataSet GradeMasterGetAll(string companyCode, string DesignationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.GradeMasterGetAll(companyCode, DesignationCode);
            return ds;
        }

        public DataSet GradeMasterAddNew(string companyCode, string gradeCode, string gradeDesc, string userId, string designationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.GradeMasterAddNew(companyCode, gradeCode, gradeDesc, userId, designationCode);
            return ds;
        }
        public DataSet GradeMasterDelete(string companyCode, string designationCode,string gradeCode)
        {
            DL.MastersManagement objblMastersManagement = new DL.MastersManagement();
            DataSet ds = objblMastersManagement.GradeMasterDelete(companyCode, designationCode, gradeCode);
            return ds;
        }
        public DataSet GradeMasterUpdate(string companyCode, string designationCode,string gradeCode, string gradeDesc, string userId)
        {
            DL.MastersManagement objblMastersManagement = new DL.MastersManagement();
            DataSet ds = objblMastersManagement.GradeMasterUpdate(companyCode, designationCode, gradeCode,gradeDesc, userId);
            return ds;
        }
     
        #endregion
        #region Function to Insert Data
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.DesignationMasterAddNew(companyCode, designationCode, designationDesc, userId);
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

            DL.MastersManagement objblMastersManagement = new DL.MastersManagement();
            DataSet ds = objblMastersManagement.DesignationMasterDelete(companyCode, designationCode);
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

            DL.MastersManagement objblMastersManagement = new DL.MastersManagement();
            DataSet ds = objblMastersManagement.DesignationMasterUpdate(companyCode, designationCode, designationDesc, userId);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to Category

        #region Function Related to GetData
        /// <summary>
        /// Get All Categories of a company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>dataset with fields CategoryCode,name</returns>

        public DataSet CategoryMasterGetAll(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CategoryMasterGetAll(companyCode);
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// Update Category Name
        /// </summary>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="categoryDesc">The category desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with status of result</returns>

        public DataSet CategoryMasterUpdate(string categoryCode, string categoryDesc, string companyCode, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CategoryMasterUpdate(categoryCode, categoryDesc, companyCode, userId);

            return ds;
        }

        #endregion

        #region Function Related to Insert Data
        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="categoryDesc">The category desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>dataset with status of insert operation</returns>

        public DataSet CategoryMasterAddNew(string categoryCode, string categoryDesc, string companyCode, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CategoryMasterAddNew(categoryCode, categoryDesc, companyCode, userId);

            return ds;
        }

        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// Delete category record
        /// </summary>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>dataset with sattus of delete operation</returns>
        public DataSet CategoryMasterDelete(string categoryCode, string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CategoryMasterDelete(categoryCode, companyCode);

            return ds;

        }

        #endregion

        #endregion

        #region Function related to Country
        /// <summary>
        /// To Get Country
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CountryMasterGetAll(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CountryMasterGetAll(companyCode);
            return ds;
        }


        #region Function Related to Insert Data
        /// <summary>
        /// To insert the Country
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="countryDesc">The country desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CountryMasterAddNew(string countryCode, string countryDesc, string companyCode, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CountryMasterAddNew(countryCode, countryDesc, companyCode, userId);

            return ds;
        }

        #endregion





        #region Function Related to update Data
        /// <summary>
        /// To Update Country
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="countryDesc">The country desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>

        public DataSet CountryMasterUpdate(string countryCode, string countryDesc, string companyCode, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CountryMasterUpdate(countryCode, countryDesc, companyCode, userId);

            return ds;
        }

        #endregion



        #region Function Related to Delete Data
        /// <summary>
        /// To Delete Country
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>

        public DataSet CountryMasterDelete(string countryCode, string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CountryMasterDelete(countryCode, companyCode);

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
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.JobTypeMasterGetAll(companyCode);
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
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.JobTypeMasterAddNew(companyCode, jobTypeCode, jobTypeDesc, modifiedBy);
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
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.JobTypeMasterUpdate(companyCode, jobTypeCode, jobTypeDesc, modifiedBy);
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
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.JobTypeMasterDelete(companyCode, jobTypeCode);
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
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.JobClassMasterGetAll(companyCode);
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
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.JobClassMasterAddNew(companyCode, jobClassCode, jobClassDesc, modifiedBy);
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
        public DataSet JobClassMasterUpdate(string companyCode, string jobTypeCode, string jobTypeDesc, string modifiedBy)
        {
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.JobClassMasterUpdate(companyCode, jobTypeCode, jobTypeDesc, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Delete data From job type master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="jobTypeCode">The job type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet JobClassMasterDelete(string companyCode, string jobTypeCode)
        {
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.JobClassMasterDelete(companyCode, jobTypeCode);
            return ds;
        }
        #endregion

        #region Function Related to Shift Pattern

        #region Function Related to Get Data
        /// <summary>
        /// To get the All Shift Patterns
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <returns>Dataset with Shift PatternCode, Shift Pattern</returns>
        public DataSet ShiftPatternsGet(int locationAutoId, string asmtCode, int pdLineNo)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.ShiftPatternsGet(locationAutoId, asmtCode, pdLineNo);
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update Shift Pattern
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="shiftPattern">The shift pattern.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Dataset with MessageId, Comment</returns>
        public DataSet ShiftPatternUpdate(int locationAutoId, string shiftPatternCode, string shiftPattern, string modifiedBy)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.ShiftPatternUpdate(locationAutoId, shiftPatternCode, shiftPattern, modifiedBy);
            return ds;
        }
        #endregion

        #region Function Related to Insert Data
        /// <summary>
        /// To Update Shift Pattern
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <param name="shiftPattern">The shift pattern.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Dataset with MessageId, Comment</returns>
        public DataSet ShiftPatternInsert(int locationAutoId, string shiftPatternCode, string shiftPattern, string modifiedBy)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.ShiftPatternInsert(locationAutoId, shiftPatternCode, shiftPattern, modifiedBy);
            return ds;
        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete Shift Pattern
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftPatternCode">The shift pattern code.</param>
        /// <returns>Dataset with MessageId, Comment</returns>
        public DataSet ShiftPatternDelete(int locationAutoId, string shiftPatternCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.ShiftPatternDelete(locationAutoId, shiftPatternCode);
            return ds;
        }
        #endregion


        #endregion

        #region Function Related to Payperiod

        #region Get PayPeriod
        /// <summary>
        /// To get Payperiod of Company
        /// </summary>
        /// <param name="payPeriodCode">The pay period code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>Dataset with PayperiodDesc,companyCode,Fromday,Today</returns>
        public DataSet CompanyPayPeriodGet(string payPeriodCode, string companyCode, string hrLocationCode, string locationCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CompanyPayPeriodGet(payPeriodCode, companyCode, hrLocationCode, locationCode);
            return ds;
        }
        #endregion

        #region Get PayPeriodDates
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.CompanyPayPeriodDatesGet(payPeriodCode, companyCode, month, year);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Site Instruction for industry
        #region Function related to get data
        #region Function to get Industry Type
        /// <summary>
        /// Industries the type get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet IndustryTypeGetAll(string companyCode)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.IndustryTypeGetAll(companyCode);
            return ds;
        }
        /// <summary>
        /// Instructions the type get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet InstructionTypeGetAll(string companyCode)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.InstructionTypeGetAll(companyCode);
            return ds;
        }

        #endregion
        #region Function to get Site Instruction for industry
        /// <summary>
        /// Sites the instruction get all.
        /// </summary>
        /// <param name="industryTypeId">The industry type identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionGetAll(string industryTypeId, string companyCode)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.SiteInstructionGetAll(industryTypeId, companyCode);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.MasterSiteInstructionGetAll(InstructionTypeId, companyCode);
            return ds;
        }
        //End
        #endregion
        #endregion
        #region Function Related to add new data
        /// <summary>
        /// Sites the instruction for industry insert.
        /// </summary>
        /// <param name="instructionTypeId">The instruction type identifier.</param>
        /// <param name="industryTypeId">The industry type identifier.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionForIndustryInsert(string instructionTypeId, string industryTypeId, string siteInstruction, string companyCode, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.SiteInstructionForIndustryInsert(instructionTypeId, industryTypeId, siteInstruction, companyCode, userId);
            return ds;
        }
        #endregion
        #region Function Related to update data
        /// <summary>
        /// Sites the instruction for industry update.
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <param name="instructionTypeId">The instruction type identifier.</param>
        /// <param name="industryTypeId">The industry type identifier.</param>
        /// <param name="siteInstruction">The site instruction.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionForIndustryUpdate(int rowId, string instructionTypeId, string industryTypeId, string siteInstruction, string companyCode, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.SiteInstructionForIndustryUpdate(rowId, instructionTypeId, industryTypeId, siteInstruction, companyCode, userId);
            return ds;
        }
        #endregion
        #region Function Related to delete data
        /// <summary>
        /// Sites the instruction for industry delete.
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SiteInstructionForIndustryDelete(int rowId, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.SiteInstructionForIndustryDelete(rowId, userId);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.AsmtPostGet(locationAutoId, AreaIncharge, AreaId, clientCode, asmtCode);
            return ds;
        }
        /// <summary>
        /// Asmts the identifier post get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="AreaIncharge">The area incharge.</param>
        /// <param name="AreaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtIdPostGet(string locationAutoId, string AreaIncharge, string AreaId, string clientCode, string asmtId)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.AsmtIdPostGet(locationAutoId, AreaIncharge, AreaId, clientCode, asmtId);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.AsmtIdPostSoRankFromSODGet(locationAutoId, ClientCode, AsmtId, PostAutoId);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.SelectedAsmtPostGet(locationAutoId, clientcode, asmtCode);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.StandardSiftsGetAll(locationAutoId);
            return ds;
        }

        /// <summary>
        /// Standards the sifts get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftsGet(string locationAutoId, string shiftCode)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.StandardSiftsGet(locationAutoId, shiftCode);
            return ds;
        }

        /// <summary>
        /// Standards the sifts get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftsGet(string locationAutoId)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.StandardSiftsGet(locationAutoId);
            return ds;
        }
        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// to update a Standard Shift for a Location
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.StandardSiftUpdate(locationAutoId, shiftCode, startTime, endTime, shiftMinutes, modifiedBy, description);
            return ds;
        }
        #endregion

        #region Function Related to Insert Data
        /// <summary>
        /// To create a new Standard Shift for a location
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.StandardSiftInsert(locationAutoId, shiftCode, startTime, endTime, shiftMinutes, modifiedBy, shiftDesc);
            return ds;
        }
        #endregion

        #region Function Related to delete Data
        /// <summary>
        /// To delete a standard shift for a SOM location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <returns>DataSet.</returns>
        public DataSet StandardSiftDelete(string locationAutoId, string shiftCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.StandardSiftDelete(locationAutoId, shiftCode);
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
            DL.MastersManagement objStandardSiftCopyToBranch = new DL.MastersManagement();
            DataSet ds = objStandardSiftCopyToBranch.StandardSiftCopyToBranch(companyCode, locationAutoIdCopyFrom, locationCodeCopyTo, modifiedBy);
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

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.IndustryTypeMasterGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Quicks the code classification get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeClassificationGet(string companyCode)
        {

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.QuickCodeClassificationGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Customers the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CustomerTypeGet(string companyCode)
        {

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.CustomerTypeGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Customers the sector get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CustomerSectorGet(string companyCode)
        {

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.CustomerSectorGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Customers the subsegment get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CustomerSubsegmentGet(string companyCode)
        {

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.CustomerSubsegmentGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Premiseses the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PremisesTypeGet(string companyCode)
        {

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.PremisesTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Addresses the type get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AddressTypeGet(string companyCode)
        {

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.AddressTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Prefers the channel communication get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PreferChannelCommunicationGet(string companyCode)
        {

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.PreferChannelCommunicationGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Gets the duty replaced reason.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetDutyReplacedReason(string companyCode)
        {
            var objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.GetDutyReplacedReason(companyCode);
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

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.ComponentTypeGet(companyCode);
            return ds;
        }

        /// <summary>
        /// Percentages the value get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PercentageValueGet(string companyCode)
        {

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.PercentageValueGet(companyCode);
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

            DL.MastersManagement objMastersManagement = new DL.MastersManagement();
            DataSet ds = objMastersManagement.PercentageGet(companyCode, component);
            return ds;
        }

        #endregion

        #region Function related to Role
        /// <summary>
        /// To Get Role Based on Compnay code
        /// </summary>
        /// <param name="companyCode">The STR company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet RoleGet(string companyCode)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.RoleGet(companyCode);
            return ds;
        }
        #endregion

        #region Function Related To Duty Type

        #region Function Related To Get Data


        /// <summary>
        /// To Get All Duty Types based on company code
        /// </summary>
        /// <param name="companyCode">The STR company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DutyTypeGetAll(string companyCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.DutyTypeGetAll(companyCode);
            return ds;

        }
        #endregion

        #region function Related TO Insert Data
        /// <summary>
        /// To add a new Qualification
        /// </summary>
        /// <param name="dutyTypeDesc">The duty type desc.</param>
        /// <param name="isBillable">if set to <c>true</c> [is billable].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>dataset message string</returns>
        public DataSet DutyTypeAddNew(string dutyTypeDesc, bool isBillable, bool isActive, bool isDefault, string modifiedBy, string companyCode, string hrLocationCode, string locationCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.DutyTypeAddNew(dutyTypeDesc, isBillable, isActive, isDefault, modifiedBy, companyCode, hrLocationCode, locationCode);
            return addStatus;
        }
        #endregion

        #region Function related to Update Data
        /// <summary>
        /// To Update Qualification
        /// </summary>
        /// <param name="dutyTypeCode">The duty type code.</param>
        /// <param name="dutyTypeDesc">The duty type desc.</param>
        /// <param name="isBillable">The is billable.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="isDefault">The is default.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet message string</returns>
        public DataSet DutyTypeUpdate(string dutyTypeCode, string dutyTypeDesc, string isBillable, string isActive, string isDefault, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.DutyTypeUpdate(dutyTypeCode, dutyTypeDesc, isBillable, isActive, isDefault, modifiedBy);
            return updateStatus;
        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Qualification
        /// </summary>
        /// <param name="dutyTypeCode">The duty type code.</param>
        /// <returns>DataSet message string</returns>
        public DataSet DutyTypeDelete(string dutyTypeCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet deleteStatus = objdlMastersManagement.DutyTypeDelete(dutyTypeCode);
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
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.HolidayTypeGetAll();
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
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.HolidayTypeInsert(holidayTypeCode, holidayTypeDesc, modifiedBy);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.HolidayTypeUpdate(holidayTypeCode, holidayTypeDesc, modifiedBy);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.HolidayTypeDelete(holidayTypeCode);
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
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.HolidayMasterGetAll(locationAutoId, holidayTypeCode);
            return ds;
        }
        /// <summary>
        /// To get the Holidaycode and Description from master holiday
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayDescriptionGet(string locationAutoId)
        {
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.HolidayDescriptionGet(locationAutoId);
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
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.HolidayMasterAddNew(locationAutoId, holidayCode, holidayDesc, holidayTypeCode, modifiedBy);
            return ds;
        }
        #endregion

        #region Function to Update
        /// <summary>
        /// To update Holidays
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDesc">The holiday desc.</param>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayMasterUpdate(string locationAutoId, string holidayCode, string holidayDesc, string holidayTypeCode, string modifiedBy)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.HolidayMasterUpdate(locationAutoId, holidayCode, holidayDesc, holidayTypeCode, modifiedBy);
            return ds;
        }
        #endregion

        #region Function TO Delete
        /// <summary>
        /// To delete the Holidays
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayTypeCode">The holiday type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayMasterDelete(string locationAutoId, string holidayCode, string holidayTypeCode)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.HolidayMasterDelete(locationAutoId, holidayCode, holidayTypeCode);
            return ds;
        }
        #endregion


        #endregion

        #region Function related to Transaction Holiday

        #region Function to Get Data
        /// <summary>
        /// Function to get all holiday Transactions
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayGetAll(string locationAutoId)
        {
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.HolidayGetAll(locationAutoId);
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
            var objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.HolidayInsert(locationAutoId, holidayCode, holidayDate, modifiedBy, toDate, clientCode, asmtCode, guid);
            return ds;
        }
        #endregion

        #region Function TO Delete
        /// <summary>
        /// To delete the Holiday Transactions
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="holidayCode">The holiday code.</param>
        /// <param name="holidayDate">The holiday date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet HolidayDelete(string locationAutoId, string holidayCode, string holidayDate, string clientCode, string asmtCode)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.HolidayDelete(locationAutoId, holidayCode, holidayDate, clientCode, asmtCode);
            return ds;
        }
        #endregion


        #endregion

        #region Function related to AdjHrs Head
        /// <summary>
        /// Get All Adj hrs Heads
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>dataset with column code,desc,isbillable</returns>
        public DataSet AdjustmentHeadGetAll(string companyCode)
        {
            DL.MastersManagement objMaster = new DL.MastersManagement();

            DataSet ds = objMaster.AdjustmentHeadGetAll(companyCode);
            return ds;
        }
        #endregion

        #region Function Related to Nationality

        #region Function Related to Get Data

        /// <summary>
        /// To get the All Compnies
        /// </summary>
        /// <returns>Dataset with companyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet NationalityMasterGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.NationalityMasterGetAll();
            return ds;
        }

        #endregion
        #region Function Related to Insert Data

        /// <summary>
        /// To add a new Company
        /// </summary>
        /// <param name="nationalityCode">The nationality code.</param>
        /// <param name="nationalityDesc">The nationality desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet NationalityMasterInsert(string nationalityCode, string nationalityDesc, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.NationalityMasterInsert(nationalityCode, nationalityDesc, userId);
            return ds;
        }

        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update a Company
        /// </summary>
        /// <param name="nationalityCode">The nationality code.</param>
        /// <param name="nationalityDesc">The nationality desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet NationalityMasterUpdate(string nationalityCode, string nationalityDesc, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.NationalityMasterUpdate(nationalityCode, nationalityDesc, userId);
            return ds;
        }

        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Nationality
        /// </summary>
        /// <param name="nationalityCode">The nationality code.</param>
        /// <returns>message string</returns>
        public DataSet NationalityMasterDelete(string nationalityCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.NationalityMasterDelete(nationalityCode);
            return ds;
        }
        #endregion


        #endregion

        #region Function Related to IdType

        #region Function Related to Get Data

        /// <summary>
        /// To get the All Compnies
        /// </summary>
        /// <returns>Dataset with companyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet IdTypeGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.IdTypeGetAll();
            return ds;
        }

        #endregion
        #region Function Related to Insert Data

        /// <summary>
        /// To add a new Company
        /// </summary>
        /// <param name="idTypeCode">The identifier type code.</param>
        /// <param name="idTypeDesc">The identifier type desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet IdTypeInsert(string idTypeCode, string idTypeDesc, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.IdTypeInsert(idTypeCode, idTypeDesc, userId);
            return ds;
        }

        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update a Company
        /// </summary>
        /// <param name="idTypeCode">The identifier type code.</param>
        /// <param name="idTypeDesc">The identifier type desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet IdTypeUpdate(string idTypeCode, string idTypeDesc, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.IdTypeUpdate(idTypeCode, idTypeDesc, userId);
            return ds;
        }

        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a IdType
        /// </summary>
        /// <param name="idTypeCode">The identifier type code.</param>
        /// <returns>message string</returns>
        public DataSet IdTypeDelete(string idTypeCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.IdTypeDelete(idTypeCode);
            return ds;
        }
        #endregion


        #endregion

        #region Function Related to Department

        #region Function Related to Get Data

        /// <summary>
        /// To get the All Compnies
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with companyCode, CompanyDesc, CompanyAddress</returns>
        public DataSet DepartmentGetAll(string companyCode)
        {
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.DepartmentGetAll(companyCode);
            return ds;
        }
        #endregion
        #region Function Related to Insert Data

        /// <summary>
        /// To add a new Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="departmentDesc">The department desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet DepartmentAddNew(string companyCode, string departmentCode, string departmentDesc, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.DepartmentAddNew(companyCode, departmentCode, departmentDesc, userId);
            return ds;
        }

        #endregion

        #region Function Related to Update Data
        /// <summary>
        /// To Update a Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="departmentDesc">The department desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>message string</returns>
        public DataSet DepartmentUpdate(string companyCode, string departmentCode, string departmentDesc, string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.DepartmentUpdate(companyCode, departmentCode, departmentDesc, userId);
            return ds;
        }

        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Department
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <returns>message string</returns>
        public DataSet DepartmentDelete(string companyCode, string departmentCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.DepartmentDelete(companyCode, departmentCode);
            return ds;
        }
        #endregion


        #endregion

        #region function related to Increment and Promotions

        /// <summary>
        /// To get currency data
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with currencyCode,currencyname</returns>
        public DataSet CurrencyMasterGetAll(string companyCode)
        {
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.CurrencyMasterGetAll(companyCode);
            return ds;
        }

        /// <summary>
        /// To get Rate Frequency
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with RateFrequencyCode,RateFrequency</returns>
        public DataSet RateFrequencyGetAll(string companyCode)
        {
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.RateFrequencyGetAll(companyCode);
            return ds;
        }

        /// <summary>
        /// Increments the reason types get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet IncrementReasonTypesGetAll()
        {
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.IncrementReasonTypesGetAll();
            return ds;
        }

        #endregion


        #region Function Related To Currency master

        #region Function Related To Get Data

        /// <summary>
        /// Currencies the master get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet CurrencyMasterGetAll()
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.CurrencyMasterGetAll();
            return ds;
        }
        #endregion

        #region Function Related TO Insert Data
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.CurrencyMasterAddNew(currencyCode, currencyDesc, currencySymbol, modifiedBy);
            return addStatus;
        }

        #endregion

        #region Function related to Update Data
        /// <summary>
        /// Currencies the master update.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="currencyDesc">The currency desc.</param>
        /// <param name="currencySymbol">The currency symbol.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CurrencyMasterUpdate(string currencyCode, string currencyDesc, string currencySymbol, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.CurrencyMasterUpdate(currencyCode, currencyDesc, currencySymbol, modifiedBy);
            return updateStatus;
        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// Currencies the master delete.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CurrencyMasterDelete(string currencyCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet deleteStatus = objdlMasterManagement.CurrencyMasterDelete(currencyCode);
            return deleteStatus;
        }

        #endregion
        #endregion

        /**********Code Added By   on 9-June-2010 **********/
        #region Event
        #region Event Master

        #region Function Related To Get Data

        /// <summary>
        /// Events the master get.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMasterGet(string module)
        {


            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventMasterGet(module);
            return ds;
        }

        /// <summary>
        /// Modules the name get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet ModuleNameGet()
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.ModuleNameGet();
            return ds;
        }
        #endregion

        #region Function Related To Update Data

        /// <summary>
        /// Events the master update.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="eventCode">The event code.</param>
        /// <param name="eventDesc">The event desc.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="baseUserId">The base user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMasterUpdate(string module, string eventCode, string eventDesc, bool isActive, string baseUserId)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventMasterUpdate(module, eventCode, eventDesc, isActive, baseUserId);
            return ds;
        }
        #endregion

        #region Function Related To Inserr Data

        /// <summary>
        /// Events the master add.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="eventCode">The event code.</param>
        /// <param name="eventDesc">The event desc.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="baseUserId">The base user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMasterAdd(string module, string eventCode, string eventDesc, bool isActive, string baseUserId)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventMasterAdd(module, eventCode, eventDesc, isActive, baseUserId);
            return ds;
        }
        #endregion

        #region Function Related To Inserr Data
        /// <summary>
        /// Events the delete.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="eventCode">The event code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventDelete(string module, string eventCode)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventDelete(module, eventCode);
            return ds;
        }
        #endregion
        #endregion
        /**********Code Added By   on 9-June-2010 **********/

        /**********Code Added By   on 10-June-2010 **********/



        #region EventUserMapping

        #region Functions to get data

        /// <summary>
        /// Users the get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet UserGet()
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.UserGet();
            return ds;
        }

        /// <summary>
        /// Events the mapping get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingGet(string userId)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventMappingGet(userId);
            return ds;
        }
        /// <summary>
        /// Events the mapping get all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingGetAll(string userId)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventMappingGetAll(userId);
            return ds;
        }
        /// <summary>
        /// Events the subscribers get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet EventSubscribersGet()
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventSubscribersGet();
            return ds;
        }
        /// <summary>
        /// Events the module mapping get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventModuleMappingGet(string userId)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventModuleMappingGet(userId);
            return ds;
        }


        /// <summary>
        /// Events the mapping description get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingDescriptionGet()
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventMappingDescriptionGet();
            return ds;
        }
        /// <summary>
        /// Events the mapping desc get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingDescGet()
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventMappingDescriptionGet();
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

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.EventMappingSubscriberGet(userId, moduleCode, eventCode);
            return ds;

        }
        #endregion

        #region Functions to Insert data

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="moduleCode">The module code.</param>
        /// <param name="eventCode">The event code.</param>
        /// <param name="blIsActive">if set to <c>true</c> [bl is active].</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="subEmailId">The sub email identifier.</param>
        /// <param name="baseUserId">The base user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaveData(string userId, string moduleCode, string eventCode, bool blIsActive, string emailId, string subEmailId, string baseUserId)
        {

            DL.MastersManagement objMaster = new DL.MastersManagement();
            DataSet ds = objMaster.SaveData(userId, moduleCode, eventCode, blIsActive, emailId, subEmailId, baseUserId);
            return ds;
        }

        #endregion

        #region Functions to Update data
        #endregion

        #region Functions to Delete data
        /// <summary>
        /// Events the mapping delete.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="eventDesc">The event desc.</param>
        /// <param name="moduleDesc">The module desc.</param>
        /// <returns>DataSet.</returns>
        public DataSet EventMappingDelete(string userId, string eventDesc, string moduleDesc)
        {

            DL.MastersManagement objDelEventMapping = new DL.MastersManagement();
            DataSet ds = objDelEventMapping.EventMappingDelete(userId, eventDesc, moduleDesc);
            return ds;

        }
        #endregion

        #endregion

        #endregion
        /**********Code Added By   on 10-June-2010 **********/

        #region Function Related to Password Policy
        /// <summary>
        /// To get the All data
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with all parameters</returns>
        public DataSet PasswordPolicyGet(string companyCode)
        {
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.PasswordPolicyGet(companyCode);
            return ds;
        }


        /// <summary>
        /// Passwords the policy update.
        /// </summary>
        /// <param name="passwordMinimumLength">Minimum length of the password.</param>
        /// <param name="minUpperCase">The minimum upper case.</param>
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
        public DataSet PasswordPolicyUpdate(int passwordMinimumLength,  int minUpperCase, int numericCharacterLength, int specialCharacterLength, int passwordExpireAfterDays, int passwordExpireWarningBefore, int passwordReuseAftertimes, int disableUserAccountAfterDays, int unsuccessfulAttemptAllowed, bool isDisableUserAccountAfterUnsuccessfulAttempt, string companyCode, string modifiedBy, bool isActive)
        {
            DL.MastersManagement objmasterManagement = new DL.MastersManagement();

            DataSet ds = objmasterManagement.PasswordPolicyUpdate(passwordMinimumLength, minUpperCase, numericCharacterLength, specialCharacterLength, passwordExpireAfterDays, passwordExpireWarningBefore, passwordReuseAftertimes, disableUserAccountAfterDays, unsuccessfulAttemptAllowed, isDisableUserAccountAfterUnsuccessfulAttempt, companyCode, modifiedBy, isActive);
            return ds;
        }


        #endregion

        #region function related to group user
        /// <summary>
        /// Users the group get all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserGroupGetAll(string userId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.UserGroupGetAll(userId);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.UserGroupUpdate(userGroupCode, userGroupName, userId);
            return ds;
        }
        /// <summary>
        /// Users the group delete.
        /// </summary>
        /// <param name="userGroupCode">The user group code.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserGroupDelete(string userGroupCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.UserGroupDelete(userGroupCode);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.UserGroupAddNew(userGroupCode, userGroupName, userId);
            return ds;
        }


        #endregion

        #region function related to Business Rules
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleMainInsert(ruleCode, ruleDesc, companyCode, hrLocationCode, locationAutoId, areaId, clientCode, modifiedBy);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRulePayPeriodInsert(businessRuleCode, payPeriodType, startDate, endDate, startDay, endDay, modifiedBy);
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
        /// <param name="isScheduledAbsenteeismHrs">if set to <c>true</c> [is scheduled absenteeism HRS].</param>
        /// <param name="minimumHoursRequiredDaily">The minimum hours required daily.</param>
        /// <param name="minimumHoursRequiredWeekly">The minimum hours required weekly.</param>
        /// <param name="minimumHoursRequiredFortnightly">The minimum hours required fortnightly.</param>
        /// <param name="minimumHoursRequiredMonthly">The minimum hours required monthly.</param>
        /// <param name="minimumLeaveHoursRequired">The minimum leave hours required.</param>
        /// <param name="minimumHoursRequiredAbsenteeism">The minimum hours required absenteeism.</param>
        /// <param name="maximumHoursDaily">The maximum hours daily.</param>
        /// <param name="maximumHoursWeekly">The maximum hours weekly.</param>
        /// <param name="maximumHoursFortnightly">The maximum hours fortnightly.</param>
        /// <param name="maximumHoursMonthly">The maximum hours monthly.</param>
        /// <param name="normalDays">The normal days.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleHoursDistributionInsert(string businessRuleCode, bool isScheduledDaily, bool isScheduledWeekly, bool isScheduledFortnightly, bool isScheduledMonthly, bool isScheduledLeaveHours, bool isScheduledAbsenteeismHrs, string minimumHoursRequiredDaily, string minimumHoursRequiredWeekly, string minimumHoursRequiredFortnightly, string minimumHoursRequiredMonthly, string minimumLeaveHoursRequired, string minimumHoursRequiredAbsenteeism, string maximumHoursDaily, string maximumHoursWeekly, string maximumHoursFortnightly, string maximumHoursMonthly, string normalDays, string modifiedBy)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleHoursDistributionInsert(businessRuleCode, isScheduledDaily, isScheduledWeekly, isScheduledFortnightly, isScheduledMonthly, isScheduledLeaveHours, isScheduledAbsenteeismHrs, minimumHoursRequiredDaily, minimumHoursRequiredWeekly, minimumHoursRequiredFortnightly, minimumHoursRequiredMonthly, minimumLeaveHoursRequired, minimumHoursRequiredAbsenteeism, maximumHoursDaily, maximumHoursWeekly, maximumHoursFortnightly, maximumHoursMonthly, normalDays, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Businesses the rule ot details get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleOTDetailsGet(string businessRuleCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleOTDetailsGet(businessRuleCode);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleOTDetailsInsert(businessRuleCode, otCode, otRate, applicableOn, modifiedBy);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleOTDetailsUpdate(otDetailAutoId, businessRuleCode, otCode, otRate, applicableOn, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Businesses the rule ot details delete.
        /// </summary>
        /// <param name="otDetailAutoId">The ot detail automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleOTDetailsDelete(string otDetailAutoId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleOTDetailsDelete(otDetailAutoId);
            return ds;
        }

        /// <summary>
        /// Businesses the rule get.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleGet(string businessRuleCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleGet(businessRuleCode);
            return ds;
        }

        /// <summary>
        /// Businesses the rule get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationId">The location identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleGet(string companyCode, string locationId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleGet(companyCode, locationId);
            return ds;
        }

        /// <summary>
        /// Businesses the rule delete.
        /// </summary>
        /// <param name="businessRuleCode">The business rule code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BusinessRuleDelete(string businessRuleCode)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleDelete(businessRuleCode);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.BusinessRuleGeneratePayPeriodClientWise(locationAutoId, clientCode, businessRuleCode, startDate, modifiedBy, payPeriodType);
            return ds;
        }
        #endregion

        #region Function Related to Constraint Type
        /// <summary>
        /// To Get All ConstraintType Based On Company Code
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintTypeGetAll(string companyCode)
        {
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintTypeGetAll(companyCode);
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
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintTypeInsert(companyCode, constraintTypeCode, constraintTypeDesc, modifiedBy);
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
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintTypeUpdate(constraintTypeAutoId, constraintTypeDesc, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Constraints the type delete.
        /// </summary>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintTypeDelete(string constraintTypeAutoId)
        {
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintTypeDelete(constraintTypeAutoId);
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
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintGetAll(companyCode, constraintType, page);
            return ds;
        }
        /// <summary>
        /// Constraints the insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="constraintCode">The constraint code.</param>
        /// <param name="constraintDesc">The constraint desc.</param>
        /// <param name="value">The value.</param>
        /// <param name="constraintOperator">The constraint operator.</param>
        /// <param name="constraintType">Type of the constraint.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintInsert(string companyCode, string constraintCode, string constraintDesc, string value, string constraintOperator, string constraintType, string modifiedBy)
        {
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintInsert(companyCode, constraintCode, constraintDesc, value, constraintOperator, constraintType, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Constraints the update.
        /// </summary>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <param name="constraintDesc">The constraint desc.</param>
        /// <param name="value">The value.</param>
        /// <param name="constraintOperator">The constraint operator.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintUpdate(string constraintAutoId, string constraintDesc, string value, string constraintOperator, string modifiedBy)
        {
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintUpdate(constraintAutoId, constraintDesc, value, constraintOperator, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Constraints the delete.
        /// </summary>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ConstraintDelete(string constraintAutoId)
        {
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintDelete(constraintAutoId);
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
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintValueGet(constraintAutoId, constraintTypeAutoId);
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
            DL.MastersManagement objMastersManagement = new DL.MastersManagement();

            DataSet ds = objMastersManagement.ConstraintDescriptionGet(constraintCode, companyCode, constraintTypeAutoId);
            return ds;

        }
        #endregion

        #region Function Related To Component Master

        #region Function Related To Get Data
        /// <summary>
        /// To get the All Data From Training Master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with Company Code,Training Code,Training desc</returns>
        public DataSet ComponentMasterGetAll(string companyCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.ComponentMasterGetAll(companyCode);
            return ds;
        }
        #endregion

        #region Function Related TO Insert Data
        /// <summary>
        /// To add a new Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="componentCode">The component code.</param>
        /// <param name="componentDesc">The component desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet message string</returns>
        public DataSet ComponentMasterAdd(string companyCode, string componentCode, string componentDesc, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.ComponentMasterAdd(companyCode, componentCode, componentDesc, modifiedBy);
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
        /// <returns>DataSet message string</returns>
        public DataSet ComponentMasterUpdate(string companyCode, string componentCode, string componentDesc, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.ComponentMasterUpdate(companyCode, componentCode, componentDesc, modifiedBy);
            return updateStatus;
        }
        #endregion

        #region Function Related to Delete Data
        /// <summary>
        /// To Delete a Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="componentCode">The component code.</param>
        /// <returns>message String</returns>
        public DataSet ComponentMasterDelete(string companyCode, string componentCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet deleteStatus = objdlMasterManagement.ComponentMasterDelete(companyCode, componentCode);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();

            DataSet ds = objdlMasterManagement.TrainingDetailsGet(companyCode, trainingCode);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet deleteStatus = objdlMasterManagement.EmployeeTrainingDelete(companyCode, trainingCode, employeeNumber, trainingDate);
            return deleteStatus;
        }


        /// <summary>
        /// Refreshers the training schedule pattern details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>DataSet.</returns>
        public DataSet RefresherTrainingSchedulePatternDetailsGet(string companyCode, string trainingCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = new DataSet();
            ds = objdlMasterManagement.RefresherTrainingSchedulePatternDetailsGet(companyCode, trainingCode);
            return ds;
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = new DataSet();
            ds = objdlMasterManagement.RefresherTrainingGenerateScheduleMonths(companyCode, trainingCode, validForMonths, refTrainAfterNMonths, refTrainingDays, modifiedBy);
            return ds;
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = new DataSet();
            updateStatus = objdlMasterManagement.TrainingMasterSchedulePatternUpdate(companyCode, trainingCode, month, trainingDays, modifiedBy);
            return updateStatus;
        }

        #endregion

        #region Zip Master
        /// <summary>
        /// To get the Group Zip Code for a Branch
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeGroupGet(string locationAutoId)
        {
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.ZipCodeGroupGet(locationAutoId);
            return ds;
        }
        /// <summary>
        /// To get the Zip Code for a Location and Group Zip Code
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="groupZipCode">The group zip code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ZipCodeGet(string locationAutoId, string groupZipCode)
        {
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.ZipCodeGet(locationAutoId, groupZipCode);
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
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.ZipCodeGroupDelete(locationAutoId, groupZipCode);
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
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.ZipCodeDelete(locationAutoId, groupZipCode, zipCode);
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
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.ZipCodeGroupUpdate(locationAutoId, groupZipCode, groupZipDesc, modifiedBy);
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
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.ZipCodeUpdate(locationAutoId, groupZipCode, zipCode, zipDesc, modifiedBy);
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
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.ZipCodeGroupAdd(locationAutoId, groupZipCode, groupZipDesc, modifiedBy);
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
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.ZipCodeAdd(locationAutoId, groupZipCode, zipCode, zipDesc, modifiedBy);
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
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.GroupGet();
            return ds;
        }
        /// <summary>
        /// To get Table Name Based on Group Name
        /// </summary>
        /// <param name="groupCode">The group code.</param>
        /// <returns>Data Set</returns>
        public DataSet SubgroupGet(string groupCode)
        {
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.SubgroupGet(groupCode);
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
            var objMm = new DL.MastersManagement();
            DataSet ds = objMm.InterfaceMappingGet(tableName, dbName);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.MstInterfaceMappingInsert(scolumnName, columnName, sdataType, dataType, slength, length, sperc, perc, snullable, nullable, seditable, stableName, databaseName, tableName, scollation, collation, screenName, sscreenfieldName, screenfieldName, sdescription, description, smandatory, color, sourceType, defaultValue, isprovided, modifiedBy);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.MstInterfaceMappingUpdate(rowautoId, scolumnName, columnName, sdataType, dataType, slength, length, sperc, perc, snullable, nullable, seditable, stableName, databaseName, tableName, scollation, collation, screenName, sscreenfieldName, screenfieldName, sdescription, description, smandatory, color, sourceType, defaultValue, isprovided, modifiedBy);
            return updateStatus;
        }
        #endregion

        #region Cost Center Mapping
        /// <summary>
        /// To Get Cost Center Mapping data
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostCenterMapping(string locationAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.CostCenterMapping(locationAutoId);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.CostCenterMappingUpdate(compnayCode, locationAutoId, clientCode, costCenter, assignment, site, modifiedBy);
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
        public DataSet CostCenterMappingDelete(string locationAutoId, string assignment, string site, string costCenter)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.CostCenterMappingDelete(locationAutoId, assignment, site, costCenter);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.InsertCostCenter(companyCode, locationAutoId, clientCode, assignment, site, costCenter, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Get Assignment
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAssignment(String locationAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.GetAssignment(locationAutoId);
            return ds;
        }
        /// <summary>
        /// Get Post Assignemnt Wise
        /// </summary>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetSiteAssignmentWise(String asmtMasterAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.GetSiteAssignmentWise(asmtMasterAutoId);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.FutureDateRotaEntryGetAll(companyCode, locationAutoId);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.FutureDateRotaEntryAddNew(companyCode, locationAutoId, clientCode, asmtCode, allowed, userId);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.FutureDateRotaEntryDelete(companyCode, locationAutoId, clientCode, asmtCode);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.AllowanceMasterAdd(locationAutoId, allowanceDescription, element, elementType, rateId, modifiedBy);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.AllowanceMasterUpdate(locationAutoId, allowanceAutoId, allowanceDescription, element, rateId, elementType);
            return ds;
        }
        /// <summary>
        /// To Delete Allowance
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterDelete(String allowanceAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.AllowanceMasterDelete(allowanceAutoId);
            return ds;
        }
        /// <summary>
        /// To Get Allowances
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterGet(String locationAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.AllowanceMasterGet(locationAutoId);
            return ds;
        }
        #endregion

        #region  Function Related to PrePostFix
        /// <summary>
        /// To Get SeqField from Quick Code
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PrePostFixGet(String CompanyCode)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.PrePostFixGet(CompanyCode);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.PrePostFixInsertUpdate(CompanyCode, SeqField, IsAutoUpdatePostFix, PrefixStr, PostfixStr, RunningSeq);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.ScheduleContextMenuGet(LocationCode);
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
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.ScheduleContextMenuInsertUpdate(LocationCode, MenuAutoID, IsActive, AttendanceType);
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
            var objdlMasterManagement = new DL.MastersManagement();
            return objdlMasterManagement.AllowanceMasterGetAll(locationAutoId);
        }
        /// <summary>
        /// To add a New Allowance
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
            var objdlMasterManagement = new DL.MastersManagement();
            return objdlMasterManagement.AllowanceMasterInsertRecord(locationAutoId, allowanceCode, allowanceDescription, element, elementType, unitType, rateId, designationCode, measurement, modifiedBy);
        }
        /// <summary>
        /// To Update the Allowance
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
            var objdlMasterManagement = new DL.MastersManagement();
            return objdlMasterManagement.AllowanceMasterUpdateRecord(locationAutoId, allowanceCode, allowanceAutoId, allowanceDescription, element, rateId, elementType, unitType, designationCode, measurement, modifiedBy);
        }
        /// <summary>
        /// To Delete Allowance
        /// </summary>
        /// <param name="allowanceAutoId">The allowance automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AllowanceMasterDeleteRecord(String allowanceAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.AllowanceMasterDeleteRecord(allowanceAutoId);
            return ds;
        }
        #endregion

        #region OT Reason Objects
        /// <summary>
        /// To Get OT Reasons
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet OvertimeReasonGet(String companyCode, String locationAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.OverTimeReasonGet(companyCode, locationAutoId);
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
        /// <returns>DataSet</returns>
        public DataSet OvertimeReasonSave(String companyCode, String reasonCode, String reasonDesc, bool isActive, String locationAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.OverTimeReasonSave(companyCode, reasonCode, reasonDesc, isActive, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Update OT Reasons
        /// </summary>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="reasonDesc">The reason desc.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet OvertimeReasonUpdate(String reasonCode, String reasonDesc, bool isActive, String locationAutoId)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet ds = objdlMasterManagement.OverTimeReasonUpdate(reasonCode, reasonDesc, isActive, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Delete OT Reasons
        /// </summary>
        /// <param name="reasonCode">The reason code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet OvertimeReasonDelete(String reasonCode, String locationAutoId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OverTimeReasonDelete(reasonCode, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Get OT Reasons
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OverTimeReasonGetAll(String companyCode, string locationAutoId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OverTimeReasonGetAll(companyCode, locationAutoId);
            return ds;
        }
        #endregion

        #region OT Reason Mapping
        /// <summary>
        /// To Get OT Reasons
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet OvertimeReasonGetAll(String companyCode, String locationAutoId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OverTimeReasonGetAll(companyCode, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Get Location Description
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet LocationDescGet(String locationAutoId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.LocationDescGet(locationAutoId);
            return ds;

        }
        /// <summary>
        /// To Get Clients Based On Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtReasonClientGet(String locationAutoId)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OtReasonClientGet(locationAutoId);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OtReasonAssignmentGet(locationAutoId, clientCode);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OtReasonPostGet(locationAutoId, clientCode, asmtCode);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OtReasonMappingInsert(otReason, locationAutoId, clientCode, asmtCode, post, modifiedBy);
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
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OtReasonMappingLocationWiseGet(companyCode, locationAutoId, clientCode, asmtCode, post);
            return ds;
        }
        /// <summary>
        /// To Delete Selected Reason Code Mapping
        /// </summary>
        /// <param name="reasonAutoID">The reason automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtReasonMappingDelete(String reasonAutoID)
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.OtReasonMappingDelete(reasonAutoID);
            return ds;
        }
        #endregion

        #region Employee Inbox Portal

        /// <summary>
        /// Requests the type get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet RequestTypeGetAll()
        {
            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();
            DataSet ds = objdlMastersManagement.RequestTypeGetAll();
            return ds;
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
            DL.MastersManagement objdlRequest = new DL.MastersManagement();
            DataSet ds = objdlRequest.EmployeeRequestGetBySeriesUserId(seriesName, companyCode, userId);
            return ds;
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
            DL.MastersManagement objdlExpToExcel = new DL.MastersManagement();
            DataSet ds = objdlExpToExcel.ExportMasterToExcel(eType, companyCode, locationAutoId);
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
            DL.MastersManagement objdlExpToExcel = new DL.MastersManagement();
            DataSet ds = objdlExpToExcel.UpdateFlatFilePath(uploadDesc);
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
            DL.MastersManagement objdlExpToExcel = new DL.MastersManagement();
            DataSet ds = objdlExpToExcel.MstProcessInterfaceData();
            return ds;
        }

        #endregion

        #region Barred Reason master
        /// <summary>
        /// To get All data from Barred Reason master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BarredReasonMasterGetAll(string companyCode)
        {
            var objMaster = new DL.MastersManagement();
            var ds = objMaster.BarredReasonMasterGetAll(companyCode);
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
            var objMaster = new DL.MastersManagement();
            var ds = objMaster.udpMst_BarredReason_Insert(companyCode, Reason, ReasonDesc, modifiedBy);
            return ds;

        }


        /// <summary>
        /// TO delete data from Barred Reason master
        /// </summary>
        /// <param name="Reason">The Reason code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet udpMst_BarredReason_Delete(string Reason, string companyCode)
        {
            var objMaster = new DL.MastersManagement();
            var ds = objMaster.udpMst_BarredReason_Delete(Reason, companyCode);
            return ds;

        }

        #endregion

        #region Function Related to Get Data of Group and SubGroup
        //public DataSet GroupMasterMasterGetAll()
        //{
        //    DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

        //    DataSet ds = objdlMastersManagement.GroupMasterMasterGetAll();
        //    return ds;
        //}
        //public DataSet SubGroupMasterMasterGetAll(int GroupID)
        //{
        //    DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

        //    DataSet ds = objdlMastersManagement.SubGroupMasterMasterGetAll(GroupID);
        //    return ds;
        //}
        public DataSet EmployeeItemsGroupGetAll()
        {
            DL.MastersManagement objmastermgmt = new DL.MastersManagement();
            DataSet ds = objmastermgmt.EmployeeItemsGroupGetAll();
            return ds;
        }
        public DataSet EmployeeItemInsertNUpdate(string ItemCode, string ItemName, string ItemGroupName, string ItemSubGroupName, string ModifiedBy, string flag)
        {
            DL.MastersManagement objmstmgmt = new DL.MastersManagement();
            DataSet ds = objmstmgmt.EmployeeItemInsertNUpdate(ItemCode, ItemName, ItemGroupName, ItemSubGroupName, ModifiedBy, flag);
            return ds;
        }
        public DataSet EmployeeItemDelete(string ItemCode)
        {
            DL.MastersManagement objmstmgmt = new DL.MastersManagement();
            DataSet ds = objmstmgmt.EmployeeItemDelete(ItemCode);
            return ds;
        }
        public DataSet EmployeeItemsGetAll()
        {
            DL.MastersManagement objmstmgmt = new DL.MastersManagement();
            DataSet ds = objmstmgmt.EmployeeItemsGetAll();
            return ds;
        }
        #endregion

        #region Functions Related to DeviceCardAsmtMapping

        /// <summary>
        /// To Get All the Data from DeviceCardAsmtMapping
        /// </summary>
        /// <param name="BaseLocationAutoID">BaseLocationAutoID</param>
        /// <param name="ddlselect">ddlselect</param>
        /// <param name="txtsearch">txtsearch</param>
        /// <returns></returns>
        public DataSet DeviceCardAsmtMappingGetAll(string BaseLocationAutoID, string ddlselect, string txtsearch)
        {

            DL.MastersManagement objdlMastersManagement = new DL.MastersManagement();

            DataSet ds = objdlMastersManagement.DeviceCardAsmtMappingGetAll(BaseLocationAutoID, ddlselect, txtsearch);
            return ds;

        }

        /// <summary>
        /// To Insert DeviceCardAsmtMapping
        /// </summary>
        /// <param name="LocationAutoId">LocationAutoId</param>
        /// <param name="ClientCode">ClientCode</param>
        /// <param name="AsmtId">AsmtId</param>
        /// <param name="AsmtCardNo">AsmtCardNo</param>
        /// <param name="EffectiveFromDate">EffectiveFromDate</param>
        /// <param name="EffectiveToDate">EffectiveToDate</param>
        /// <param name="modifiedBy">modifiedBy</param>
        /// <returns></returns>
        public DataSet DeviceCardAsmtMappingAddNew(string LocationAutoId, string ClientCode, string AsmtId, string AsmtCardNo, string EffectiveFromDate, string EffectiveToDate, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet addStatus = objdlMasterManagement.DeviceCardAsmtMappingAddNew(LocationAutoId, ClientCode, AsmtId, AsmtCardNo, EffectiveFromDate, EffectiveToDate, modifiedBy);
            return addStatus;
        }

        /// <summary>
        /// To Update DeviceCardAsmtMapping
        /// </summary>
        /// <param name="LocationAutoId">LocationAutoId</param>
        /// <param name="ClientCode">ClientCode</param>
        /// <param name="AsmtId">AsmtId</param>
        /// <param name="AsmtCardNo">AsmtCardNo</param>
        /// <param name="FromDate">FromDate</param>
        /// <param name="ToDate">ToDate</param>
        /// <param name="modifiedBy">modifiedBy</param>
        /// <returns></returns>
        public DataSet DeviceCardAsmtMappingUpdate(string LocationAutoId, string ClientCode, string AsmtId, string AsmtCardNo, string FromDate, string ToDate, string modifiedBy)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet updateStatus = objdlMasterManagement.DeviceCardAsmtMappingUpdate(LocationAutoId, ClientCode, AsmtId, AsmtCardNo, FromDate, ToDate, modifiedBy);
            return updateStatus;
        }

        /// <summary>
        /// To Delete DeviceCardAsmtMapping
        /// </summary>
        /// <param name="CardAsmtMappingAutoId">CardAsmtMappingAutoId</param>
        /// <param name="AsmtCardNo">AsmtCardNo</param>
        /// <returns></returns>
        public DataSet DeviceCardAsmtMappingDelete(string CardAsmtMappingAutoId, string AsmtCardNo)
        {
            DL.MastersManagement objdlMasterManagement = new DL.MastersManagement();
            DataSet deleteStatus = objdlMasterManagement.DeviceCardAsmtMappingDelete(CardAsmtMappingAutoId, AsmtCardNo);
            return deleteStatus;
        }
        #endregion
    }
}
