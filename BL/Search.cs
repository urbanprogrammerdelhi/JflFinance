// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Search.cs" company="Magnon">
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
    /// Class Search.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Search
    {

        #region Function Get Field Names of table/view
        /// <summary>
        /// Columns the names of table get.
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        /// <returns>DataSet.</returns>
        public DataSet ColumnNamesOfTableGet(string objectName)
        {
            DL.Search objdlSearch = new DL.Search();

            DataSet ds = objdlSearch.ColumnNamesOfTableGet(objectName);
            return ds;
        }
        #endregion

        #region Function InsertCCH Detail
        /// <summary>
        /// Commons the search format insert.
        /// </summary>
        /// <param name="cchCode">The CCH code.</param>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="returnFieldName">Name of the return field.</param>
        /// <param name="returnFieldName2">The return field name2.</param>
        /// <param name="dataTable">The data table.</param>
        /// <returns>DataSet.</returns>
        public DataSet CommonSearchFormatInsert(string cchCode, string objectName, string returnFieldName, string returnFieldName2, DataTable dataTable)
        {
            DL.Search objdlSearch = new DL.Search();

            DataSet ds = objdlSearch.CommonSearchFormatInsert(cchCode, objectName, returnFieldName, returnFieldName2, dataTable);
            return ds;
        }
        #endregion

        #region Function Get CCH Detail
        /// <summary>
        /// Commons the search format get.
        /// </summary>
        /// <param name="cchCode">The CCH code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CommonSearchFormatGet(string cchCode)
        {
            DL.Search objdlSearch = new DL.Search();

            DataSet ds = objdlSearch.CommonSearchFormatGet(cchCode);
            return ds;
        }
        #endregion

        #region Function Get Search(CCH) Result
        /// <summary>
        /// Commons the search result get.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Dataset with columns defined in sqlquery</returns>
        public DataSet CommonSearchResultGet(string query)
        {
            DL.Search objdlSearch = new DL.Search();

            DataSet ds = objdlSearch.CommonSearchResultGet(query);
            return ds;
        }
        #endregion

        #region function related to employee search for scheduling
        /// <summary>
        /// Skills the based employee list get.
        /// </summary>
        /// <param name="asmtAutoId">The asmt automatic identifier.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet SkillBasedEmployeeListGet(int asmtAutoId, int pdLineNo, string soRank, int locationAutoId, string hrLocationCode, string fromDate, string toDate)
        {
            DL.Search objdlSearch = new DL.Search();

            DataSet ds = objdlSearch.SkillBasedEmployeeListGet(asmtAutoId, pdLineNo, soRank, locationAutoId, hrLocationCode, fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// Serach Employee Based on AreaID,Zip,Skill etc in Scheduling Screen
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="status">The status.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="areaId">The area id.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="NoOfMonths">The no of months.</param>
        /// <returns>Dataset ds</returns>
        public DataSet AllEmployeeListGet(string clientCode, string asmtId, string postCode, int locationAutoId, string hrLocationCode, string fromDate, string toDate, int status, string zipCode, string areaId, string areaIncharge, string isAreaIncharge, int NoOfMonths)
        {
            var objdlSearch = new DL.Search();

            DataSet ds = objdlSearch.AllEmployeeListGet(clientCode, asmtId, postCode, locationAutoId, hrLocationCode, fromDate, toDate, status, zipCode, areaId, areaIncharge, isAreaIncharge, NoOfMonths);
            return ds;
        }

        /// <summary>
        /// Totals the matched skill summary.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="areaId">The area id.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="skillType">Type of the skill.</param>
        /// <returns>Dataset ds</returns>
        public DataSet TotalMatchedSkillSummary(string clientCode,string asmtId, string postCode, int locationAutoId, string fromDate, string toDate, string areaId, string areaIncharge, string isAreaIncharge, string employeeNumber, string skillType)
        {
            var objdlSearch = new DL.Search();

            DataSet ds = objdlSearch.TotalMatchedSkillSummary(clientCode,asmtId, postCode, locationAutoId, fromDate, toDate, areaId, areaIncharge, isAreaIncharge, employeeNumber, skillType);
            return ds;
        }

        /// <summary>
        /// Queries the based employee list get.
        /// </summary>
        /// <returns>Dataset ds</returns>
        public DataSet QueryBasedEmployeeListGet()
        {
            DL.Search objdlSearch = new DL.Search();

            DataSet ds = objdlSearch.QueryBasedEmployeeListGet();
            return ds;
        }

        #endregion
    }
}
