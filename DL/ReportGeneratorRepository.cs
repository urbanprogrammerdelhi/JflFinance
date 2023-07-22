// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 04-27-2015
//
// Last Modified By : Administrator
// Last Modified On : 04-18-2015
// ***********************************************************************
// <copyright file="ReportGeneratorRepository.cs" company="Magnon">
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
    /// Class ReportGeneratorRepository For Reports
    /// </summary>
    public class ReportGeneratorRepository
    {
        #region Added function for OJT Report
        /// <summary>
        /// Function used to get output for OJT Report
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
            var objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(Properties.Resources.AreaIncharge, areaIncharge);
            objParm[2] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[3] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[4] = new SqlParameter(Properties.Resources.ScheduleType, scheduleType);
            objParm[5] = new SqlParameter(Properties.Resources.Billable, billable);
            objParm[6] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[7] = new SqlParameter(Properties.Resources.ToDate, toDate);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptGetOJTDetail", objParm);
        }
        #endregion

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
            var objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(Properties.Resources.AreaIncharge, areaIncharge);
            objParm[2] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[3] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[4] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(Properties.Resources.AsmtId, asmtId);
            objParm[6] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[7] = new SqlParameter(Properties.Resources.ToDate, toDate);
            objParm[8] = new SqlParameter(Properties.Resources.ConfirmDuty, confirmDuty);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptGetEmployeeWorkHistory", objParm);
            return ds.Tables[0];
        }
        #endregion
    }
}
