// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="PreTermination.cs" company="Magnon">
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
/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class PreTermination.
    /// </summary>
    /// <summary>
    /// Class PreTermination.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class PreTermination
    {
        #region Function to insert data
        /// <summary>
        /// to insert data in database
        /// </summary>
        /// <param name="xmlTerminationDetail">The XML termination detail.</param>
        /// <param name="terminationType">Type of the termination.</param>
        /// <param name="status">usStat</param>
        /// <param name="modifiedBy">modified by</param>
        /// <returns>Data Set</returns>
        public DataSet PreTerminationInsert(string xmlTerminationDetail, string terminationType, string status, string modifiedBy)
        {

            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter(DL.Properties.Resources.PreTerminationDetailTable, xmlTerminationDetail);
            obj[1] = new SqlParameter(DL.Properties.Resources.TerminationType, terminationType);
            obj[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            obj[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesTermination_Insert", obj);
            return ds;
        }

        /// <summary>
        /// To Check If WEF Date is greater than max WEF Date of SoNO and SoLIneNo
        /// </summary>
        /// <param name="soNo">So No</param>
        /// <param name="soLineNo">So Line No</param>
        /// <param name="pdLineNo">PD Line No</param>
        /// <param name="asmtMasterAutoId">Asmt Master Auto Id</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckWithEffectiveDate(string soNo, string soLineNo, string pdLineNo, string asmtMasterAutoId)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            obj[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            obj[2] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            obj[3] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_CheckWEFDate", obj);
            return ds;
        }

        /// <summary>
        /// Terminates the sale order.
        /// </summary>
        /// <param name="xmlTerminationDetail">The XML termination detail.</param>
        /// <param name="status">The status.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TerminateSaleOrder(string xmlTerminationDetail, string status, string locationAutoId, string modifiedBy)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter(DL.Properties.Resources.PreTerminationDetailTable, xmlTerminationDetail);
            obj[1] = new SqlParameter(DL.Properties.Resources.Status, status);
            obj[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            obj[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesTermination_TerminateSaleOrder", obj);
            return ds;

        }

        /// <summary>
        /// First Level Authorize
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="asmtSoNo">The asmt so no.</param>
        /// <param name="asmtSoLineNo">The asmt so line no.</param>
        /// <param name="pdLineNo">The pd line no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtMasterAutoId">The asmt master automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">The status.</param>
        /// <param name="parentStatus">if set to <c>true</c> [parent status].</param>
        /// <returns>Data Set</returns>
        public DataSet LevelAuthorize(string clientCode, string asmtId, string asmtSoNo, string asmtSoLineNo, string pdLineNo, string locationAutoId, string asmtMasterAutoId, string modifiedBy, string status, bool parentStatus)
        {
            SqlParameter[] obj = new SqlParameter[10];
            obj[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            obj[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            obj[2] = new SqlParameter(DL.Properties.Resources.SONO, asmtSoNo);
            obj[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, asmtSoLineNo);
            obj[4] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            obj[5] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            obj[6] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            obj[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            obj[8] = new SqlParameter(DL.Properties.Resources.Status, status);
            obj[9] = new SqlParameter(DL.Properties.Resources.ParentStatus, parentStatus);

            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_LevelAuthorize", obj))
                {

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["MessageID"].ToString() == "99")
                    {
                        using (DataSet dsRollBack = RollbackAssignment(clientCode, locationAutoId, status, asmtId))
                        {
                            return ds;
                        }
                    }
                    tx.Complete();
                    return ds;
                }
            }
        }

        /// <summary>
        /// To get Data to be updated in various tables on third level authorization
        /// </summary>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="clientCode">Client Code</param>
        /// <param name="asmtId">Asmt Id</param>
        /// <param name="status">Status</param>
        /// <returns>Data set</returns>
        public DataSet PreTerminationDetailGet(string locationAutoId, string clientCode, string asmtId, string status)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            obj[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            obj[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            obj[3] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_GetDetailToUpdate", obj);
            return ds;
        }

        /// <summary>
        /// get active Status Count
        /// </summary>
        /// <param name="clientCode">Client Code</param>
        /// <param name="locationAutoId">Location Auot Id</param>
        /// <param name="status">Status</param>
        /// <returns>Int Count Value</returns>
        public int ActiveStatusCountGet(string clientCode, string locationAutoId, string status)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            obj[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            obj[2] = new SqlParameter(DL.Properties.Resources.Status, status);

            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "udp_SalesOPSTermination_GetActiveStatusCount", obj))
            {
                int ColumnIndex = reader.GetOrdinal("ActiveCount");
                object Values = new object();
                while (reader.Read())
                {
                    Values = reader.GetValue(ColumnIndex);
                }
                if (string.IsNullOrEmpty(Values.ToString()))
                {
                    //reader.Close();
                    return -1;
                }
                else
                {
                    //reader.Close();
                    Guard.ArgumentConvertibleTo<int>(Values.ToString(), "myIntArgument");
                    return int.Parse(Values.ToString());
                }
            }
        }

        /// <summary>
        /// to get total number of post
        /// </summary>
        /// <param name="soNo">So No</param>
        /// <param name="soLineNo">So Line No</param>
        /// <param name="asmtId">Asmt Id</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <returns>Data Set</returns>
        public DataSet NumberOfPostsGet(string soNo, string soLineNo, string asmtId, string locationAutoId)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            obj[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            obj[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            obj[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_GetNumberOfPost", obj);
            return ds;
        }

        /// <summary>
        /// Pre Termination Update
        /// </summary>
        /// <param name="clientCode">Client Code</param>
        /// <param name="asmtId">Asmt Id</param>
        /// <param name="asmtCode">Asmt Code</param>
        /// <param name="asmtSoNo">So No</param>
        /// <param name="soLineNo">So Line No</param>
        /// <param name="pdLineNo">Pd Line No</param>
        /// <param name="isActive">Is Active</param>
        /// <param name="asmtStartDate">Asmt Start Date</param>
        /// <param name="asmtEndDate">Asmt End Date</param>
        /// <param name="isBillable">Is Billable</param>
        /// <param name="status">Status</param>
        /// <param name="numberOfPosts">No Of Post</param>
        /// <param name="modifiedBy">Modified By</param>
        /// <param name="withEffectiveDate">WEF Date</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="actualNumberOfPosts">Actual No Of Post</param>
        /// <param name="statusShortClosed">Short Close Status</param>
        /// <param name="terminationReason">Termination Reason</param>
        /// <param name="warningNo">Warning No</param>
        /// <returns>DataSet.</returns>
        public DataSet PreTerminationUpdate(string clientCode, string asmtId, string asmtCode, string asmtSoNo, int soLineNo, int pdLineNo, bool isActive, DateTime asmtStartDate, DateTime asmtEndDate, bool isBillable, string status, int numberOfPosts, string modifiedBy, string withEffectiveDate, string locationAutoId, int actualNumberOfPosts, string statusShortClosed, string terminationReason, string warningNo)
        {
            SqlParameter[] obj = new SqlParameter[19];
            obj[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            obj[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            obj[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            obj[3] = new SqlParameter(DL.Properties.Resources.SONO, asmtSoNo);
            obj[4] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            obj[5] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            obj[6] = new SqlParameter(DL.Properties.Resources.Active, isActive);
            obj[7] = new SqlParameter(DL.Properties.Resources.PDLineStartDate, DL.Common.DateFormat(asmtStartDate));
            obj[8] = new SqlParameter(DL.Properties.Resources.PDLineEndDate, DL.Common.DateFormat(asmtEndDate));
            obj[9] = new SqlParameter(DL.Properties.Resources.Billable, isBillable);
            obj[10] = new SqlParameter(DL.Properties.Resources.Status, status);
            obj[11] = new SqlParameter(DL.Properties.Resources.NumberOfPost, numberOfPosts);
            obj[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            obj[13] = new SqlParameter(DL.Properties.Resources.WithEffectiveDate, DL.Common.DateFormat(withEffectiveDate));
            obj[14] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            obj[15] = new SqlParameter(DL.Properties.Resources.ActualNoOfPost, actualNumberOfPosts);
            obj[16] = new SqlParameter(DL.Properties.Resources.StatusTerminated, statusShortClosed);
            obj[17] = new SqlParameter(DL.Properties.Resources.TerminationReason, terminationReason);
            obj[18] = new SqlParameter(DL.Properties.Resources.WDControlNo, warningNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_Update", obj);
            return ds;
        }

        #endregion

        #region Rollback changes
        /// <summary>
        /// to terminate if client code is checked/unchecked in gridview
        /// </summary>
        /// <param name="clientCode">Client Code</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="status">Status</param>
        /// <returns>Data Set</returns>
        public DataSet BulkTermination(string clientCode, string locationAutoId, string status)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            obj[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            obj[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_BulkTerminate", obj);
            return ds;
        }

        /// <summary>
        /// To rollback all data
        /// </summary>
        /// <param name="clientCode">Client Code</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="status">Status</param>
        /// <returns>Data Set</returns>
        public DataSet Rollback(string clientCode, string locationAutoId, string status)
        {
            SqlParameter[] obj = new SqlParameter[3];
            obj[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            obj[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            obj[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_RollBack", obj);
            return ds;
        }

        /// <summary>
        /// rollback individual row
        /// </summary>
        /// <param name="clientCode">Client Code</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="status">Status</param>
        /// <param name="soNo">So No</param>
        /// <param name="soLineNo">So Line no</param>
        /// <param name="pdLineNo">Pd Line No</param>
        /// <returns>Data Set</returns>
        public DataSet RollbackRows(string clientCode, string locationAutoId, string status, string soNo, string soLineNo, string pdLineNo)
        {
            SqlParameter[] obj = new SqlParameter[7];
            obj[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            obj[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            obj[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            obj[3] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            obj[4] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            obj[5] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_RollBackRow", obj);
            return ds;
        }

        /// <summary>
        /// roll back based on Assignment
        /// </summary>
        /// <param name="clientCode">Client Code</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="status">Status</param>
        /// <param name="asmtId">Asmt Id</param>
        /// <returns>Data Set</returns>
        public DataSet RollbackAssignment(string clientCode, string locationAutoId, string status, string asmtId)
        {
            SqlParameter[] obj = new SqlParameter[4];
            obj[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            obj[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            obj[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            obj[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_RollBackBasedOnAssignment", obj);
            return ds;
        }
        #endregion

        #region Function Related to SaleOrder and Assignment Amendement
        /// <summary>
        /// To Amend sale and Ops
        /// </summary>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="soNo">So No</param>
        /// <param name="soStatus">So Status</param>
        /// <param name="myStatus">My Status</param>
        /// <param name="asmtMasterAutoId">Asmt Master Auto Id</param>
        /// <param name="amendBy">Amend By</param>
        /// <param name="modifiedBy">Modified By</param>
        /// <returns>Data Set</returns>
        public DataSet AmendSales(string locationAutoId, string soNo, string soStatus, string myStatus, string asmtMasterAutoId, string amendBy, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.MyStatus, myStatus);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AmendBy, amendBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_AmendSalesandOPS", objParam);
            return ds;
        }
        #endregion

        /// <summary>
        /// Get AsmtDetails For Sale Order, LocationAutoId, AsmtId and AsmtAmendNo.
        /// </summary>
        /// <param name="clientCode">Client Code</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="asmtId">Asmt Id</param>
        /// <returns>Data Set</returns>
        public DataSet AssignmentDetailsGet(string clientCode, string locationAutoId, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_GetAsmtDetailsForSO", objParam);
            return ds;
        }

        /// <summary>
        /// To Check if the shift is created or not
        /// </summary>
        /// <param name="asmtMasterAutoId">Asmt Master Auto Id</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="status">Status</param>
        /// <returns>Data Set</returns>
        public DataSet CheckShiftCreation(string asmtMasterAutoId, string locationAutoId, string status)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtMasterAutoId, asmtMasterAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AmendStatus, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_CheckShiftCreation", objParam);
            return ds;
        }

        /// <summary>
        /// to check if data is in trn Roster
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="withEffectiveDate">The with effective date.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckActualSchedule(string locationAutoId, string asmtCode, DateTime withEffectiveDate)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(withEffectiveDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_CheckActualSchedule", objParam);
            return ds;
        }

        /// <summary>
        /// To get Rota exists in TrnRoster after given WEF Date
        /// </summary>
        /// <param name="SoNo">The so no.</param>
        /// <param name="SoLineNo">The so line no.</param>
        /// <param name="PostAutoId">The post automatic identifier.</param>
        /// <param name="WefDate">The wef date.</param>
        /// <returns>DataSet.</returns>
        public DataSet RotaGet(string SoNo, string SoLineNo, string PostAutoId, DateTime WefDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, SoNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, SoLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostAutoId, PostAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(WefDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_GetAllRota", objParam);
            return ds;
        }
        /// <summary>
        /// To get Schedule exists in TrnSchRoster after given WEF Date
        /// </summary>
        /// <param name="SoNo">The so no.</param>
        /// <param name="SoLineNo">The so line no.</param>
        /// <param name="PostAutoId">The post automatic identifier.</param>
        /// <param name="WefDate">The wef date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleGet(string SoNo, string SoLineNo, string PostAutoId, DateTime WefDate)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, SoNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, SoLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostAutoId, PostAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(WefDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_SalesOPSTermination_GetScheduleDetail", objParam);

            return ds;
        }

        /// <summary>
        /// Update Status of Rota and Schedule Deletion
        /// </summary>
        /// <param name="SoNo">The so no.</param>
        /// <param name="SoLineNo">The so line no.</param>
        /// <param name="PostAutoId">The post automatic identifier.</param>
        /// <param name="WefDate">The wef date.</param>
        /// <returns>DataSet.</returns>
        public DataSet PreTerminationRotaScheduleDeleteStatusUpdate(string SoNo, string SoLineNo, string PostAutoId, DateTime WefDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, SoNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, SoLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostAutoId, PostAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(WefDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPreTerminationRotaScheduleDeleteStatusUpdate", objParam);

            return ds;
        }
        /// <summary>
        /// insert data to delete rota at fourth level authorization
        /// </summary>
        /// <param name="asmtCode">Asmt Code</param>
        /// <param name="pdLineNo">Pd Line No</param>
        /// <param name="wefDate">WEF Date</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="modifiedBy">Modified By</param>
        /// <returns>Data Set</returns>
        public DataSet InsertRotaForDelete(string asmtCode, int pdLineNo, DateTime wefDate, string locationAutoId, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(wefDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.PDLineNo, pdLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_InsertRotaForDelete", objParam);
            return ds;
        }

        /// <summary>
        /// Details after Authorize
        /// </summary>
        /// <param name="clientCode">Client Code</param>
        /// <param name="asmtId">Asmt Id</param>
        /// <param name="thirdLevelStatus">3rd Level Status</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <returns>Data Set</returns>
        public DataSet DetailAfterAuthorizeGet(string clientCode, string asmtId, string thirdLevelStatus, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ThirdLevelStatus, thirdLevelStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_GetDetailAfterAuthorize", objParam);
            return ds;
        }

        /// <summary>
        /// Get Rota To Delete Rota from trnRoster and schRoster
        /// </summary>
        /// <param name="saleOrderDeptShiftAutoId">sale Order Dept Shift AutoId</param>
        /// <returns>Data Set</returns>
        public DataSet RotaGet(string saleOrderDeptShiftAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SaleOrderDeptShiftAutoId, saleOrderDeptShiftAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SalesOPSTermination_GetAllRotaForSODeptShiftAutoId", objParam);
            return ds;
        }
    }
}