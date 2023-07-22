// ***********************************************************************
// Assembly         : BL
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


/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
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
            DL.ExceptionLogs objExlOg = new DL.ExceptionLogs();
            DataSet ds = objExlOg.ExceptionLog(exceptionDescription, userId);
            return ds;
        }

    }
}
