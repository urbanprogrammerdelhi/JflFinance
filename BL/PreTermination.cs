// ***********************************************************************
// Assembly         : BL
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

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
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
            var ds = new DataSet();
            var objPreTermination = new DL.PreTermination();
            ds = objPreTermination.PreTerminationInsert(xmlTerminationDetail, terminationType, status, modifiedBy);
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.CheckWithEffectiveDate(soNo, soLineNo, pdLineNo, asmtMasterAutoId);
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
        public DataSet TerminateSaleOrder(string xmlTerminationDetail, string status,string locationAutoId, string modifiedBy)
        {
            var ds = new DataSet();
            var objPreTermination = new DL.PreTermination();
            ds = objPreTermination.TerminateSaleOrder(xmlTerminationDetail, status, locationAutoId,modifiedBy);
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
        /// <returns>DataSet.</returns>
        public DataSet LevelAuthorize(string clientCode, string asmtId, string asmtSoNo, string asmtSoLineNo, string pdLineNo, string locationAutoId, string asmtMasterAutoId, string modifiedBy, string status, bool parentStatus)
        {
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.LevelAuthorize(clientCode, asmtId, asmtSoNo, asmtSoLineNo, pdLineNo, locationAutoId, asmtMasterAutoId, modifiedBy, status, parentStatus);
            return ds;
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.PreTerminationDetailGet(locationAutoId, clientCode, asmtId, status);
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
            DL.PreTermination objPreTermination = new DL.PreTermination();
            int ActiveStatus = objPreTermination.ActiveStatusCountGet(clientCode, locationAutoId, status);
            return ActiveStatus;
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.NumberOfPostsGet(soNo, soLineNo, asmtId, locationAutoId);
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.PreTerminationUpdate(clientCode, asmtId, asmtCode, asmtSoNo, soLineNo, pdLineNo, isActive, asmtStartDate, asmtEndDate, isBillable, status, numberOfPosts, modifiedBy, withEffectiveDate, locationAutoId, actualNumberOfPosts, statusShortClosed, terminationReason, warningNo);
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.BulkTermination(clientCode, locationAutoId, status);
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.Rollback(clientCode, locationAutoId, status);
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.RollbackRows(clientCode, locationAutoId, status, soNo, soLineNo, pdLineNo);
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.RollbackAssignment(clientCode, locationAutoId, status, asmtId);
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.AmendSales(locationAutoId, soNo, soStatus, myStatus, asmtMasterAutoId, amendBy, modifiedBy);
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
            DataSet ds = new DataSet();
            DL.PreTermination objPreTermination = new DL.PreTermination();
            ds = objPreTermination.AssignmentDetailsGet(clientCode, locationAutoId, asmtId);
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
            DL.PreTermination objPreTermination = new DL.PreTermination();
            DataSet ds = new DataSet();
            ds = objPreTermination.CheckShiftCreation(asmtMasterAutoId, locationAutoId, status);
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
            DL.PreTermination objPreTermination = new DL.PreTermination();
            DataSet ds = new DataSet();
            ds = objPreTermination.CheckActualSchedule(locationAutoId, asmtCode, withEffectiveDate);
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
            DL.PreTermination objPreTermination = new DL.PreTermination();
            DataSet ds = new DataSet();
            ds = objPreTermination.RotaGet(SoNo, SoLineNo, PostAutoId, WefDate);
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
            DL.PreTermination objPreTermination = new DL.PreTermination();
            DataSet ds = new DataSet();
            ds = objPreTermination.ScheduleGet(SoNo, SoLineNo, PostAutoId, WefDate);
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
            DL.PreTermination objPreTermination = new DL.PreTermination();
            DataSet ds = new DataSet();
            ds = objPreTermination.PreTerminationRotaScheduleDeleteStatusUpdate(SoNo, SoLineNo, PostAutoId, WefDate);
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
            DL.PreTermination objPreTermination = new DL.PreTermination();
            DataSet ds = new DataSet();
            ds = objPreTermination.InsertRotaForDelete(asmtCode, pdLineNo, wefDate, locationAutoId, modifiedBy);
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
            DL.PreTermination objPreTermination = new DL.PreTermination();
            DataSet ds = new DataSet();
            ds = objPreTermination.DetailAfterAuthorizeGet(clientCode, asmtId, thirdLevelStatus, locationAutoId);
            return ds;
        }
        /// <summary>
        /// Get Rota To Delete Rota from trnRoster and schRoster
        /// </summary>
        /// <param name="saleOrderDeptShiftAutoId">sale Order Dept Shift AutoId</param>
        /// <returns>Data Set</returns>
        public DataSet RotaGet(string saleOrderDeptShiftAutoId)
        {
            DL.PreTermination objPreTermination = new DL.PreTermination();
            DataSet ds = objPreTermination.RotaGet(saleOrderDeptShiftAutoId);
            return ds;
        }
    }
}