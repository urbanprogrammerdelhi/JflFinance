// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Interface.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    
    //All the interface related Function will be written here

    /// <summary>
    /// Class Interface.
    /// </summary>
   public  class Interface
    {


        /// <summary>
        /// Retrieve all the value from mapping table on the basis of Screen Name
        /// </summary>
        /// <param name="screenName">Name of the screen.</param>
        /// <returns>DataSet.</returns>
        /// ais
        public DataSet GetAllRecordsOnScreenName(string screenName)
        {
            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.screen, screenName);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllRecordsOnScreenName", objParm);
            return ds;
        }



        /// <summary>
        /// Gets the name of all records on screen name and table.
        /// </summary>
        /// <param name="screenName">Name of the screen.</param>
        /// <param name="TableName">Name of the table.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllRecordsOnScreenNameAndTableName(string screenName, string TableName)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.screen, screenName);
            objParm[1] = new SqlParameter(DL.Properties.Resources.TableName, TableName);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllRecordsOnScreenNameAndTablename", objParm);

            return ds;
        }

        #region functions related to Upload Employees
        /// <summary>
        /// To Get Lcoation From Aus Server
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLocationfromAusServer(string employeeNumber)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetLocationfromAusServer", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Employees from Aus Server
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetEmployeeMasterDatafromAusServer(string locationAutoId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetEmployeeMasterDatafromAusServer", objParm);
            return ds;
        }
        /// <summary>
        /// To Get All Lccation From Aus Server
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllLoction(string locationAutoId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAllLoction", objParm);
            return ds;
        }
        /// <summary>
        /// Get Leave Calender
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLeaveCal(string company)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Company, company);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetLeaveCal", objParm);
            return ds;
        }
        /// <summary>
        /// To Upload Employees
        /// </summary>
        /// <param name="fromLocation">From location.</param>
        /// <param name="toLocationAutoId">To location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet UploadEmployees(string fromLocation, string toLocationAutoId, string employeeNumber)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromLocation, fromLocation);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToLocation, toLocationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpCollectDataFromAusServertoUploadEmployees", objParm);
            return ds;
        }
        /// <summary>
        /// To Upload Leaves
        /// </summary>
        /// <param name="fromLocation">From location.</param>
        /// <param name="toLocationAutoId">To location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCal">The leave cal.</param>
        /// <param name="leaveType">Type of the leave.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet UploadLeaves(string fromLocation, string toLocationAutoId, string employeeNumber, string leaveCal, string leaveType, string modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromLocation, fromLocation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToLocation, toLocationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCal);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LeaveType, leaveType);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUploadLeaveBalances", objParm);
            return ds;
        }
        /// <summary>
        /// To Update Leaves
        /// </summary>
        /// <param name="fromLocation">From location.</param>
        /// <param name="toLocationAutoId">To location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="leaveCal">The leave cal.</param>
        /// <param name="leaveType">Type of the leave.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet UpdateUploadLeaves(string fromLocation, string toLocationAutoId, string employeeNumber, string leaveCal, string leaveType, string modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FromLocation, fromLocation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToLocation, toLocationAutoId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LeaveCalCode, leaveCal);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LeaveType, leaveType);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUpdateUploadLeaveBalances", objParm);
            return ds;
        }
        /// <summary>
        /// To Update Employees
        /// </summary>
        /// <param name="fromLocation">From location.</param>
        /// <param name="toLocationAutoId">To location automatic identifier.</param>
        /// <param name="toCompanyCode">To company code.</param>
        /// <param name="toHrLocationCode">To hr location code.</param>
        /// <param name="areaID">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet UpdateUploadEmployees(string fromLocation, string toLocationAutoId, string toCompanyCode,string toHrLocationCode,string areaID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromLocation, fromLocation);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToLocation, toLocationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ToCompanyCode, toCompanyCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ToHrLocationCode, toHrLocationCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaId, areaID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpCollectDataFromAusServertoUpdateUploadedEmployees", objParm);
            return ds;
        }        
        #endregion
    }
}
