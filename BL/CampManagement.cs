// ***********************************************************************
// Assembly         : BL
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


/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.CampMasterGet(companyCode);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.CampMasterInsert(campCode, companyCode, campName, campAddress, effectiveFrom, effectiveTo, status, modifiedBy);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.BuildingMasterGet(campCode);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.BuildingMasterAddNew(campCode, buildingCode, buildingName, buildingAddress, effectiveFrom, effectiveTo, status, modifiedBy);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.BedMasterGet(campCode, buildingCode);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.BedMasterAddNew(campCode, buildingCode, floorNo, flatNo, roomNo, bedNo, effectiveFrom, effectiveTo, status, modifiedBy);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.CampRosterFloorGet(campCode, buildingCode);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.CampRosterFlatGet(campCode, buildingCode, floorNo);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.CampRosterRoomGet(campCode, buildingCode, floorNo, flatNo);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.CampRosterBedGet(campCode, buildingCode, floorNo, flatNo, roomNo);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.CampRosterBedDetailsGet(companyCode, campCode, buildingCode, floorNo, flatNo, roomNo);
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
            DL.CampManagement objdlCamp = new DL.CampManagement();

            DataSet ds = objdlCamp.CampRosterBedDetailsInsert(bedAutoId, employeeNumber, effectiveFrom, effectiveTo, status, modifiedBy);
            return ds;

        }

        #endregion

    }
}
