// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="ExceptionLogs.cs" company="Magnon">
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
    /// Class ExceptionLogs.
    /// </summary>
    [CLSCompliantAttribute(false)]
   public class ExceptionLogs
    {
        /// <summary>
        /// Exceptions the log.
        /// </summary>
        /// <param name="exceptionDescription">The exception description.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ExceptionLog(string exceptionDescription, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ExceptionDesc, exceptionDescription);
            objParam[1] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TrnExceptionLog", objParam);
            return ds;
        }




    }
}
