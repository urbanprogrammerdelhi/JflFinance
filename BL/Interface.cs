// ***********************************************************************
// Assembly         : BL
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


/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class Interface.
    /// </summary>
  public  class Interface
    {


        /// <summary>
        /// Gets the name of all records on screen.
        /// </summary>
        /// <param name="screenName">Name of the screen.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllRecordsOnScreenName(string screenName)
        {

           DL.Interface objInterface = new DL.Interface();
           DataSet ds = objInterface.GetAllRecordsOnScreenName(screenName);
            return ds;
            
            
        }


        /// <summary>
        /// Gets the name of all records on screen name and table.
        /// </summary>
        /// <param name="screenName">Name of the screen.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllRecordsOnScreenNameAndTableName(string screenName,string tableName)
        {

            DL.Interface objInterface = new DL.Interface();
            DataSet ds = objInterface.GetAllRecordsOnScreenNameAndTableName(screenName, tableName);
            return ds;


        }

        #region Function Related to Aus Upload Employees
        /// <summary>
        /// To Get Location From Aus Server
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLocationfromAusServer(string employeeNumber)
        { 
            DL.Interface objdlInterface = new DL.Interface();
            DataSet ds = objdlInterface.GetLocationfromAusServer(employeeNumber);
            return ds;
        }
        /// <summary>
        /// To Get Master data from Aus Server
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetEmployeeMasterDatafromAusServer(string locationAutoID)
        {
            DL.Interface objdlInterface = new DL.Interface();
            DataSet ds = objdlInterface.GetEmployeeMasterDatafromAusServer(locationAutoID);
            return ds;
        }
        /// <summary>
        /// To Get Location
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAllLoction(string locationAutoID)
        {
            DL.Interface objdlInterface = new DL.Interface();
            DataSet ds = objdlInterface.GetAllLoction(locationAutoID);
            return ds;
        }
        /// <summary>
        /// Get Leave Calender
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLeaveCal(string company)
        {
            DL.Interface objdlInterface = new DL.Interface();
            DataSet ds = objdlInterface.GetLeaveCal(company);
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
            DL.Interface objdlInterface = new DL.Interface();
            DataSet ds = objdlInterface.UploadLeaves(fromLocation, toLocationAutoId, employeeNumber, leaveCal, leaveType, modifiedBy);
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
            DL.Interface objdlInterface = new DL.Interface();
            DataSet ds = objdlInterface.UpdateUploadLeaves(fromLocation, toLocationAutoId, employeeNumber, leaveCal, leaveType, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Upload n Update Employees
        /// </summary>
        /// <param name="fromLocation">From location.</param>
        /// <param name="toLocationAutoID">To location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet UploadEmployees(string fromLocation, string toLocationAutoID, string employeeNumber)
        {
            DL.Interface objdlInterface = new DL.Interface();
            DataSet ds = objdlInterface.UploadEmployees(fromLocation, toLocationAutoID, employeeNumber);
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
        public DataSet UpdateUploadEmployees(string fromLocation, string toLocationAutoId, string toCompanyCode, string toHrLocationCode, string areaID)
        {
            DL.Interface objdlInterface = new DL.Interface();
            DataSet ds = objdlInterface.UpdateUploadEmployees(fromLocation, toLocationAutoId, toCompanyCode,toHrLocationCode,areaID);
            return ds;

        }       
        #endregion     
    }
}
