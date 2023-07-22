// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="CampManagement.cs" company="Magnon">
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
    /// Class CampManagement.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class CampManagement
    {

        #region Functions Related to Camp Master

        /// <summary>
        /// Camps the master get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CampMasterGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpmstCampMgmt_Camp_get", objParm);
            return ds;
        }

        /// <summary>
        /// Camps the master insert.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="campName">Name of the camp.</param>
        /// <param name="campAddress">The camp address.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CampMasterInsert(string campCode, string companyCode, string campName, string campAddress, string effectiveFrom, string effectiveTo, string status, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[8];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CampName, campName);
            objParm[3] = new SqlParameter(DL.Properties.Resources.CampAddress, campAddress);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objParm[5] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParm[6] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpmstCampMgmt_Camp_Insert", objParm);
            return ds;
        }


        #endregion

        #region Functions Related to Building Master

        /// <summary>
        /// Buildings the master get.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BuildingMasterGet(string campCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpmstCampMgmt_Building_get", objParm);
            return ds;
        }

        /// <summary>
        /// Buildings the master add new.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <param name="buildingName">Name of the building.</param>
        /// <param name="buildingAddress">The building address.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BuildingMasterAddNew(string campCode, string buildingCode, string buildingName, string buildingAddress, string effectiveFrom, string effectiveTo, string status, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[8];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BuildingCode, buildingCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.BuildingName, buildingName);
            objParm[3] = new SqlParameter(DL.Properties.Resources.BuildingAddress, buildingAddress);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objParm[5] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParm[6] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpmstCampMgmt_Building_Insert", objParm);
            return ds;
        }



        #endregion

        #region Functions Related to Bed Master

        /// <summary>
        /// Beds the master get.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BedMasterGet(string campCode, string buildingCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BuildingCode, buildingCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpmstCampMgmt_Bed_get", objParm);
            return ds;
        }

        /// <summary>
        /// Beds the master add new.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <param name="floorNo">The floor no.</param>
        /// <param name="flatNo">The flat no.</param>
        /// <param name="roomNo">The room no.</param>
        /// <param name="bedNo">The bed no.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BedMasterAddNew(string campCode, string buildingCode, string floorNo, string flatNo, string roomNo, string bedNo, string effectiveFrom, string effectiveTo, string status, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[10];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BuildingCode, buildingCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FloorNo, floorNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FlatNo, flatNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.RoomNo, roomNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.BedNo, bedNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objParm[7] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParm[8] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpmstCampMgmt_Bed_Insert", objParm);
            return ds;
        }


        #endregion

        #region Functions Related to Camp Transaction

        /// <summary>
        /// Camps the roster floor get.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CampRosterFloorGet(string campCode, string buildingCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BuildingCode, buildingCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "trnCampRoster_Floor_get", objParm);
            return ds;

        }

        /// <summary>
        /// Camps the roster flat get.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <param name="floorNo">The floor no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CampRosterFlatGet(string campCode, string buildingCode, string floorNo)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BuildingCode, buildingCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FloorNo, floorNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "trnCampRoster_Flat_get", objParm);
            return ds;

        }

        /// <summary>
        /// Camps the roster room get.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <param name="floorNo">The floor no.</param>
        /// <param name="flatNo">The flat no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CampRosterRoomGet(string campCode, string buildingCode, string floorNo, string flatNo)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BuildingCode, buildingCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FloorNo, floorNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FlatNo, flatNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "trnCampRoster_Room_get", objParm);
            return ds;

        }

        /// <summary>
        /// Camps the roster bed get.
        /// </summary>
        /// <param name="campCode">The camp code.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <param name="floorNo">The floor no.</param>
        /// <param name="flatNo">The flat no.</param>
        /// <param name="roomNo">The room no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CampRosterBedGet(string campCode, string buildingCode, string floorNo, string flatNo, string roomNo)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.BuildingCode, buildingCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.FloorNo, floorNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FlatNo, flatNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.RoomNo, roomNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "trnCampRoster_Bed_Get", objParm);
            return ds;


        }

        /// <summary>
        /// Camps the roster bed details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="campCode">The camp code.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <param name="floorNo">The floor no.</param>
        /// <param name="flatNo">The flat no.</param>
        /// <param name="roomNo">The room no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CampRosterBedDetailsGet(string companyCode, string campCode, string buildingCode, string floorNo, string flatNo, string roomNo)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Campcode, campCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.BuildingCode, buildingCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FloorNo, floorNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FlatNo, flatNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.RoomNo, roomNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "trnCampRoster_BedDetails_Get", objParm);
            return ds;

        }

        /// <summary>
        /// Camps the roster bed details insert.
        /// </summary>
        /// <param name="bedAutoId">The bed automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CampRosterBedDetailsInsert(string bedAutoId, string employeeNumber, string effectiveFrom, string effectiveTo, string status, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[6];

            if (!String.IsNullOrEmpty(effectiveTo))
                Guard.ArgumentValidDate(effectiveTo, "myDateArgument");

            objParm[0] = new SqlParameter(DL.Properties.Resources.BedAutoId, bedAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            objParm[3] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo, true));
            objParm[4] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "trncampRoster_BedDetails_Insert", objParm);
            return ds;

        }
        #endregion

    }
}
