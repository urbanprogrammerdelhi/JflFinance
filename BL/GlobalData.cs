// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="GlobalData.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;


/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class GlobalData.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public static class GlobalData
    {
        /// <summary>
        /// The _ employee list
        /// </summary>
        private static string _EmployeeList = "";
        /// <summary>
        /// Gets or sets the employee list.
        /// </summary>
        /// <value>The employee list.</value>
        public static string EmployeeList
        {
            get { return _EmployeeList; }
            set
            {
                if (value.Contains(",")) //// remove from strting 
                    _EmployeeList = _EmployeeList.Replace(value, "");
                else //// add to string
                    _EmployeeList = _EmployeeList + "," + value;

            }
        }

    }
}
