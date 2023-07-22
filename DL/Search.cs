// ***********************************************************************
// Assembly         : DL
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
using System.Data.SqlClient;
using System.Transactions;
/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class Search.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Search
    {

        #region Function Related To Search

        #region Get Field Names of an Object
        /// <summary>
        /// To get the All Field Name of a table/view
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        /// <returns>Dataset with field names</returns>
        public DataSet ColumnNamesOfTableGet(string objectName)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.objectName, objectName);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SearchFieldsName_Get", objParam);
            return ds;
        }
        #endregion

        #region Insert Master CCH
        /// <summary>
        /// To Insert new CCH Code
        /// </summary>
        /// <param name="cchCode">The CCH code.</param>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="returnFieldName">Name of the return field.</param>
        /// <param name="returnFieldName2">The return field name2.</param>
        /// <param name="dt">The dt.</param>
        /// <returns>Nothing</returns>
        /// <exception cref="System.ArgumentNullException">dt</exception>
        public DataSet CommonSearchFormatInsert(string cchCode, string objectName, string returnFieldName, string returnFieldName2, DataTable dt)
        {
            if (dt == null || dt.Rows == null)
            {
                throw new ArgumentNullException("dt");
            }
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CCHCode, cchCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.objectName, objectName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ReturnFld, returnFieldName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ReturnFld2, returnFieldName2);
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                DataSet dsCCH = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_CCHdetail_Insert", objParam);

                SqlParameter[] objParam1 = new SqlParameter[5];

                string strFldName;
                string strInputFld;
                string strOutputFld;
                string strFldDataType;

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    strFldName = dt.Rows[k][DL.Properties.Resources.fldFldName].ToString();
                    strInputFld = dt.Rows[k][DL.Properties.Resources.fldInputFld].ToString();
                    strOutputFld = dt.Rows[k][DL.Properties.Resources.fldOutputFld].ToString();
                    strFldDataType = dt.Rows[k][DL.Properties.Resources.fldFldDataType].ToString();

                    objParam1[0] = new SqlParameter(DL.Properties.Resources.CCHCode, cchCode);
                    objParam1[1] = new SqlParameter(DL.Properties.Resources.FldName, strFldName);
                    objParam1[2] = new SqlParameter(DL.Properties.Resources.InputFld, strInputFld);
                    objParam1[3] = new SqlParameter(DL.Properties.Resources.OutputFld, strOutputFld);
                    objParam1[4] = new SqlParameter(DL.Properties.Resources.FldDataType, strFldDataType);

                    //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_CCHdetail_Insert", objParam1);
                    SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrn_CCHdetail_Insert", objParam1);
                }
                tx.Complete();
                return dsCCH;
            }

        }
        #endregion

        #region Get CCH detail
        /// <summary>
        /// TGet CCH detail in order to generate dynamic interface of search page
        /// </summary>
        /// <param name="cchCode">The CCH code.</param>
        /// <returns>Dataset with fields ObjectName,ReturnFld,FldName,InputFld,OutputFld</returns>
        public DataSet CommonSearchFormatGet(string cchCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CCHCode, cchCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_CCHdetail_Get", objParam);
            return ds;
        }
        #endregion

        #region Get Search Result
        /// <summary>
        /// Commons the search result get.
        /// </summary>
        /// <param name="sqlQueryString">The SQL query string.</param>
        /// <returns>DataSet.</returns>
        public DataSet CommonSearchResultGet(string sqlQueryString)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.strSqlQuery, sqlQueryString);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSearch_Result_Get", objParam);
            return ds;
        }
        #endregion

        #region function related to employee search for schedule
        /// <summary>
        /// Skills the based employee list get.
        /// </summary>
        /// <param name="asmtAutoId">The asmt auto id.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>Dataset ds</returns>
        public DataSet SkillBasedEmployeeListGet(int asmtAutoId, int pdLineNo, string soRank, int locationAutoId, string hrLocationCode, string fromDate, string toDate)
        {
            var objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpCCH_EmpList4Schedule_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Alls the employee list get.
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
            var objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostCode, postCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[7] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ZipCode, zipCode);
            objParam[9] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[10] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParam[11] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[12] = new SqlParameter(DL.Properties.Resources.Month, NoOfMonths);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSearch_EmployeeList_GetAll", objParam);
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
        /// <returns>Datset ds</returns>
        public DataSet TotalMatchedSkillSummary(string clientCode, string asmtId, string postCode, int locationAutoId, string fromDate, string toDate, string areaId, string areaIncharge, string isAreaIncharge, string employeeNumber, string skillType)
        {
            var objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostCode, postCode);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParam[4] = new SqlParameter(Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParam[6] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParam[7] = new SqlParameter(Properties.Resources.AreaIncharge, areaIncharge);
            objParam[8] = new SqlParameter(Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParam[9] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[10] = new SqlParameter(Properties.Resources.SkillType, skillType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTransaction_ScheduleEmpWise_TotalMatchedSkills", objParam);
            return ds;
        }


        /// <summary>
        /// Queries the based employee list get.
        /// </summary>
        /// <returns>Dataset ds</returns>
        public DataSet QueryBasedEmployeeListGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpCCH_QueryBasedEmployeeList_Get");
            return ds;
        }

        #endregion
        #endregion

    }

}
