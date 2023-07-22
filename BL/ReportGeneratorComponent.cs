// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 05-26-2014
//
// Last Modified By : Administrator
// Last Modified On : 05-01-2015
// ***********************************************************************
// <copyright file="ReportGeneratorComponent.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Data.SqlClient;
using DL;

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class ReportGeneratorComponent
    /// </summary>
    public class ReportGeneratorComponent
    {
        #region Member Declaration
        /// <summary>
        /// The _ report generator repository
        /// </summary>
        readonly DL.ReportGeneratorRepository _ReportGeneratorRepository = null;
        #endregion

        #region Constractor
        /// <summary>
        /// ReportGeneratorComponent Constractor
        /// </summary>
        public ReportGeneratorComponent()
        {
            _ReportGeneratorRepository = new ReportGeneratorRepository();
        }
        #endregion

        /// <summary>
        /// Function used to call DL function GetOJTDetails
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="scheduleType">Type of the schedule.</param>
        /// <param name="billable">The billable.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet</returns>
        public DataSet GetOJTDetails(int locationAutoId, string areaIncharge, string areaId, string employeeNumber, string scheduleType, string billable, DateTime fromDate, DateTime toDate)
        {
            return _ReportGeneratorRepository.GetOJTDetails(locationAutoId, areaIncharge, areaId, employeeNumber, scheduleType, billable, fromDate, toDate);
        }

        #region SAT#124 Employee Work History
        /// <summary>
        /// Function used to call DL function GetEmployeeWorkHistoryDetails
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="confirmDuty">The confirm duty.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetEmployeeWorkHistoryDetails(int locationAutoId, string areaIncharge, string areaId, string employeeNumber, string clientCode, string asmtId, DateTime fromDate, DateTime toDate, string confirmDuty)
        {
            return _ReportGeneratorRepository.GetEmployeeWorkHistoryDetails(locationAutoId, areaIncharge, areaId, employeeNumber, clientCode, asmtId, fromDate, toDate, confirmDuty);
        }
        #endregion
    }
}
