// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Misc.cs" company="Magnon">
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
    /// Class Misc.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Misc
    {
        #region Function Related to Quick Code Type Master
        /// <summary>
        /// To get All data from QuickCode type master
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_GetAll");
            return ds;
        }
        /// <summary>
        /// To Insert Data into QuickCode Type Master
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="quickCodeDesc">The quick code desc.</param>
        /// <param name="status">if set to <c>true</c> [status].</param>
        /// <param name="parentQuickCode">The parent quick code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeInsert(string quickCode, string quickCodeDesc, bool status, string parentQuickCode, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.QuickCodeDesc, quickCodeDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ParentQuickCode, parentQuickCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);            
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_Insert", objParam);
            return ds;

        }
        /// <summary>
        /// TO delete data from QuickCode master
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeDelete(string quickCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_Delete", objParam);
            return ds;

        }
        /// <summary>
        /// To update QuickCodeType Master
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="quickCodeDesc">The quick code desc.</param>
        /// <param name="status">if set to <c>true</c> [status].</param>
        /// <param name="parentQuickCode">The parent quick code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeUpdate(string quickCode, string quickCodeDesc, bool status, string parentQuickCode, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.QuickCodeDesc, quickCodeDesc);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ParentQuickCode, parentQuickCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To get All Data from Quick Code Master Based on QuickCode swelected from QuickCodeType
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeMasterGetAll(string quickCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeMaster_GetAll", objParam);
            return ds;
        }
        public DataSet UnMappedQuickCodeMasterGet(string quickCode, string companycode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companycode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_unMappedQuickCodeMaster_Get", objParam);
            return ds;
        }
        public DataSet MappedQuickCodeMasterGet(string quickCode, string companycode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companycode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_MappedQuickCodeMaster_Get", objParam);
            return ds;
        }
        /// <summary>
        /// to fill ddlparentId in footer of gvQuickCodeMaster
        /// </summary>
        /// <param name="ItemCode">The item code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="QuickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeMasterGetParentId(string ItemCode, string companyCode, string QuickCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ItemCode, ItemCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.QuickCode, QuickCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeMaster_GetParentID", objParam);
            return ds;
        }
        /// <summary>
        /// To insert into QuickCodeMaster
        /// </summary>
        /// <param name="QuickCode">The quick code.</param>
        /// <param name="ItemCode">The item code.</param>
        /// <param name="ItemDesc">The item desc.</param>
        /// <param name="status">if set to <c>true</c> [status].</param>
        /// <param name="ParentItemCode">The parent item code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeMasterInsert(string QuickCode, string ItemCode, string ItemDesc, bool status, string ParentItemCode, string modifiedBy, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, QuickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemCode, ItemCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ItemDesc, ItemDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ParentItemCode, ParentItemCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeMaster_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// To get ParentID for QuickCodeType
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeParentIdGet()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_GetParentID");
            return ds;

        }
        /// <summary>
        /// To get Quick Codes those can be set as the parent quick code of the given QuickCode
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeParentIdGet(string quickCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_GetParentID4Edit", objParam);
            return ds;
        }
        /// <summary>
        /// TO get QuickCodeTypeAutoID Based on QuickCode
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeAutoIdGet(string quickCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_GetQuickCodeTypeAutoIDBasedQuickCode", objParam);
            return ds;
        }
        /// <summary>
        /// To Disable QuickCode in QuickCodeType
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DisableQuickCodeType(string quickCode, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_DisableQuickCodeType", objParam);
            return ds;
        }
        /// <summary>
        /// To Enable QuickCode in QuickCodeType
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EnableQuickCodeType(string quickCode, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_EnableQuickCodeType", objParam);
            return ds;
        }
        /// <summary>
        /// To SHow Enable Disable image in gridview
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeGet()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_GetEnableDisable");
            return ds; ;
        }
        /// <summary>
        /// To Check If Child is made parent of QuickCode or not
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckParentChildRelation(string quickCode, int parentId)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ParentID, parentId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeType_CheckParentChildRelation", objParam);
            return ds;
        }
        /// <summary>
        /// To Disable QuickCode in Quick Code Master
        /// </summary>
        /// <param name="ItemDesc">The item desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DisableQuickCodeMaster(int ItemDesc, string companyCode, string quickCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ItemDesc, ItemDesc);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeMaster_DisableQuickCodeMaster", objParam);
            return ds;
        }
        /// <summary>
        /// To SHow Enable Disable image in Quick Code Master gridview
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeMasterGetEnableDisable(string quickCode, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeMaster_GetEnableDisable", objParam);
            return ds; ;
        }
        /// <summary>
        /// To Enable QuickCode in Quick Code Master
        /// </summary>
        /// <param name="ItemDesc">The item desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EnableQuickCodeMaster(int ItemDesc, string companyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ItemDesc, ItemDesc);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeMaster_EnableQuickCodeMaster", objParam);
            return ds;
        }
        /// <summary>
        /// To Update QuickCode In QuickCodeMaster
        /// </summary>
        /// <param name="quickCode">quickCode</param>
        /// <param name="itemCode">itemCode</param>
        /// <param name="itemDesc">itemDesc</param>
        /// <param name="status">status</param>
        /// <param name="parentItemCode">parentItemCode</param>
        /// <param name="modifiedBy">modifiedBy</param>
        /// <returns>update result in dataset</returns>
        public DataSet QuickCodeMasterUpdate(string quickCode, string itemCode, string itemDesc, bool status, string parentItemCode, string modifiedBy, string companyCode)
        {
            var objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemCode, itemCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ItemDesc, itemDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ParentItemCode, parentItemCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeMaster_Update", objParam);
        }
        /// <summary>
        /// To delete a Quick code item
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="ItemCode">The item code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeMasterDelete(string quickCode, string ItemCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemCode, ItemCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstMisc_QuickCodeMaster_Delete", objParam);
            return ds;
        }
        #endregion

        #region Get Thee UOM Code
        /// <summary>
        /// Quicks the code uom get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeUomGet(string companyCode)
        {

            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_UOM_Get", objParm);
            return ds;
        }
        #endregion


        # region  Controller Screen

        /// <summary>
        /// This method is used for displaying all the client with number of
        /// scheduled and present employee in particular time duration
        /// </summary>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">time from</param>
        /// <param name="timeTo">time to</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientController(DateTime dutyDate, DateTime timeFrom, DateTime timeTo)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParam[1] = new SqlParameter(DL.Properties.Resources.tf, timeFrom);
            objParam[2] = new SqlParameter(DL.Properties.Resources.tt, timeTo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "NFC_ClientController", objParam);
            return ds;
        }

        /// <summary>
        /// NFCs the incident.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet NfcIncident(string companyCode, string locationAutoId, string clientCode, DateTime dutyDate, DateTime timeFrom, DateTime timeTo)
        {

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCIncident", objParam);
            return ds;
        }

        /// <summary>
        /// Panics the alert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet PanicAlert(string companyCode, string locationAutoId, string clientCode, DateTime dutyDate, DateTime timeFrom, DateTime timeTo)
        {

            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCPanicAlert", objParam);
            return ds;
        }

        /// <summary>
        /// NFCs the no shows get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet NfcNoShowsGet(string companyCode, string locationAutoId, string clientCode, DateTime dutyDate, DateTime timeFrom, DateTime timeTo)
        {

            SqlParameter[] objParm = new SqlParameter[6];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCNoShow", objParm);
            return ds;
        }

        /// <summary>
        /// NFCs the vacant posts get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet NfcVacantPostsGet(string companyCode, string locationAutoId, string clientCode, DateTime dutyDate, DateTime timeFrom, DateTime timeTo)
        {

            SqlParameter[] objParm = new SqlParameter[6];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParm[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCVacantPost", objParm);
            return ds;
        }

        /// <summary>
        /// This method is used to displaying all the assignment of client client with scheduled and
        /// present employee in particular duration.
        /// All parameter will taken from clientcontroller screen
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="swipeDate">The swipe date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>

        public DataSet AssignmentController(string clientCode, DateTime swipeDate, DateTime timeFrom, DateTime timeTo)
        {


            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SwipeDate, swipeDate);
            objParam[2] = new SqlParameter(DL.Properties.Resources.tf, timeFrom);
            objParam[3] = new SqlParameter(DL.Properties.Resources.tt, timeTo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "NFC_AssignmentController", objParam);
            return ds;

        }
        /// <summary>
        /// Method is used for displaying the employee scheduled and there presence or not on
        /// particular assignment durring time interval.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentWiseEmployeesGet(string asmtCode, DateTime dutyDate, DateTime timeFrom, DateTime timeTo)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParam[2] = new SqlParameter(DL.Properties.Resources.tf, timeFrom);
            objParam[3] = new SqlParameter(DL.Properties.Resources.tt, timeTo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "NFC_EmployeeDetails", objParam);
            return ds;
        }

        /// <summary>
        /// Assignments the controller confirm.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentControllerConfirm(string locationAutoId, string employeeNumber, string asmtCode, string dutyDate, string modifiedBy)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Date, dutyDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AssignmentController_Confirm", objParam);
            return ds;
        }
        #endregion



        #region Direct NFC Attendance from Itek

        /// <summary>
        /// Insert record in Direct_NFC_Attendance
        /// </summary>
        /// <param name="imei">The imei.</param>
        /// <param name="employeeTag">The employee tag.</param>
        /// <param name="swipeType">Type of the swipe.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <returns>DataSet.</returns>

        public DataSet NfcAttendance(string imei, string employeeTag, string swipeType, DateTime dutyDate)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.IMEI, imei);
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmpTag, employeeTag);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AttendanceTime, dutyDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AttendanceType, swipeType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "NFC_Direct_Attendance", objParam);
            return ds;
        }
        #endregion


        // Sync Secure trax 16-10-2012
        /// <summary>
        /// To show data in clent Controller
        /// </summary>
        /// <param name="dutydate">From Date</param>
        /// <param name="tf">Time From</param>
        /// <param name="tt">Time To</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="strWETDate">The string wet date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="postString">The post string.</param>
        /// <param name="scan">The scan.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlClientController(DateTime dutydate, DateTime tf, DateTime tt, string clientCode, string strWETDate, string locationAutoID, string flag, string postString, string scan)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter("@DutyDate", dutydate);
            objParam[1] = new SqlParameter("@TF", tf);
            objParam[2] = new SqlParameter("@TT", tt);
            objParam[3] = new SqlParameter("@ClientCode", clientCode);
            objParam[4] = new SqlParameter("@WETDate", DL.Common.DateFormat(strWETDate));
            objParam[5] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParam[6] = new SqlParameter("@Flag", flag);
            objParam[7] = new SqlParameter("@PostString", postString);
            objParam[8] = new SqlParameter("@Scan", scan);

            //ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "NFC_ClientController", objParam);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UDP_NfcAttendance", objParam);
            return ds;
        }

        /// <summary>
        /// Dls the misc get all guard tour identifier.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postCode">The post code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlMiscGetAllGuardTourID(string companyCode, string locationAutoID, string clientCode, string asmtCode, string postCode)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter("@CompanyCode", companyCode);
            objParam[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParam[2] = new SqlParameter("@ClientCode", clientCode);
            objParam[3] = new SqlParameter("@AsmtCode", asmtCode);
            objParam[4] = new SqlParameter("@PostCode", postCode);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "GetAllGuardTourID", objParam);
            return ds;
        }

        /// <summary>
        /// Dls the misc get all guard tour client.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="tourID">The tour identifier.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postCode">The post code.</param>
        /// <param name="scanType">Type of the scan.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlMiscGetAllGuardTourClient(string companyCode, string locationAutoID, string clientCode, string timeFrom, string timeTo, string dutyDate, string toDate, string modifiedBy, string tourID, string asmtCode, string postCode, string scanType)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[12];
            objParm[0] = new SqlParameter("@CompanyCode", companyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", clientCode);
            objParm[3] = new SqlParameter("@TimeFrom", timeFrom);
            objParm[4] = new SqlParameter("@TimeTo", timeTo);
            objParm[5] = new SqlParameter("@DutyDate", dutyDate);
            objParm[6] = new SqlParameter("@ModifiedBy", modifiedBy);
            objParm[7] = new SqlParameter("@GTourID", tourID);
            objParm[8] = new SqlParameter("@AsmtCode", asmtCode);
            objParm[9] = new SqlParameter("@PostCode", postCode);
            objParm[10] = new SqlParameter("@WETDate", toDate);
            objParm[11] = new SqlParameter("@ScanType", scanType);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCguardTourClientController", objParm);
            return ds;
        }

        /// <summary>
        /// This method is used to displaying all the assignment of client client with scheduled and
        /// present employee in particular duration.
        /// All parameter will taken from clientcontroller screen
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="swipeDate">The swipe date.</param>
        /// <param name="tf">The tf.</param>
        /// <param name="tt">The tt.</param>
        /// <param name="wetDate">The wet date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>

        public DataSet DlAssignmentController(string clientCode, DateTime swipeDate, DateTime tf, DateTime tt, string wetDate, string locationAutoID)
        {

            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter("@ClientCode", clientCode);
            objParam[1] = new SqlParameter("@SwipeDate", swipeDate);
            objParam[2] = new SqlParameter("@tf", tf);
            objParam[3] = new SqlParameter("@tt", tt);
            objParam[4] = new SqlParameter("@WETDate", DL.Common.DateFormat(wetDate));
            objParam[5] = new SqlParameter("@LocationAutoID", locationAutoID);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "NFC_AssignmentController", objParam);
            return ds;

        }
        /// <summary>
        /// Method is used for displaying the employee scheduled and there presence or not on
        /// particular assignment durring time interval.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dutydate">The dutydate.</param>
        /// <param name="tf">The tf.</param>
        /// <param name="tt">The tt.</param>
        /// <param name="wetDate">The wet date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlEmpAssignmentWise(string asmtCode, DateTime dutydate, DateTime tf, DateTime tt, string wetDate, string locationAutoID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter("@AsmtCode", asmtCode);
            objParam[1] = new SqlParameter("@dutydate", dutydate);
            objParam[2] = new SqlParameter("@tf", tf);
            objParam[3] = new SqlParameter("@tt", tt);
            objParam[4] = new SqlParameter("@WETDate", wetDate);
            objParam[5] = new SqlParameter("@LocationAutoID", locationAutoID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "NFC_EmployeeDetails", objParam);
            return ds;
        }

        /// <summary>
        /// Dls the assignment controller confirm.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="date">The date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlAssignmentControllerConfirm(string locationAutoID, string employeeNumber, string clientCode, string asmtCode, string date, string modifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParam[1] = new SqlParameter("@EmployeeNumber", employeeNumber);
            objParam[2] = new SqlParameter("@ClientCode", clientCode);
            objParam[3] = new SqlParameter("@AsmtCode", asmtCode);
            objParam[4] = new SqlParameter("@Date", date);
            objParam[5] = new SqlParameter("@ModifiedBy", modifiedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AssignmentController_Confirm", objParam);
            return ds;
        }

        #region Add by  on 24-Apr-2014 for Export Functionality on POP Solution
        /// <summary>
        /// Function used to export NFC Incident Records.
        /// </summary>
        /// <param name="strCompanyCode">The string company code.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strTimeFrom">The string time from.</param>
        /// <param name="strTimeTo">The string time to.</param>
        /// <param name="strDutyDate">The string duty date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcIncidentExport(string strCompanyCode, string strLocationAutoID, string strClientCode, string strTimeFrom, string strTimeTo, string strDutyDate, string strToDate, string strModifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@CompanyCode", strCompanyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", strLocationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", strClientCode);
            objParm[3] = new SqlParameter("@TimeFrom", strTimeFrom);
            objParm[4] = new SqlParameter("@TimeTo", strTimeTo);
            objParm[5] = new SqlParameter("@DutyDate", strDutyDate);
            objParm[6] = new SqlParameter("@WETDate", strToDate);
            objParm[7] = new SqlParameter("@ModifiedBy", strModifiedBy);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCIncident_Export", objParm);
            return ds;
        }

        /// <summary>
        /// Function used to export NFC Panic Records.
        /// </summary>
        /// <param name="strCompanyCode">The string company code.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strTimeFrom">The string time from.</param>
        /// <param name="strTimeTo">The string time to.</param>
        /// <param name="strDutyDate">The string duty date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcPanicExport(string strCompanyCode, string strLocationAutoID, string strClientCode, string strTimeFrom, string strTimeTo, string strDutyDate, string strToDate, string strModifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@CompanyCode", strCompanyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", strLocationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", strClientCode);
            objParm[3] = new SqlParameter("@TimeFrom", strTimeFrom);
            objParm[4] = new SqlParameter("@TimeTo", strTimeTo);
            objParm[5] = new SqlParameter("@DutyDate", DL.Common.DateFormat(strDutyDate));
            objParm[6] = new SqlParameter("@ModifiedBy", strModifiedBy);
            objParm[7] = new SqlParameter("@WETDate", DL.Common.DateFormat(strToDate));

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCPanicAlert_Export", objParm);
            return ds;
        }

        /// <summary>
        /// Function used to export Guard Tour Records.
        /// </summary>
        /// <param name="strCompanyCode">The string company code.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strTimeFrom">The string time from.</param>
        /// <param name="strTimeTo">The string time to.</param>
        /// <param name="strDutyDate">The string duty date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <param name="strTourID">The string tour identifier.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="strPostCode">The string post code.</param>
        /// <param name="strScanType">Type of the string scan.</param>
        /// <param name="strSelectedGT">The string selected gt.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNFCGuardTourExport(string strCompanyCode, string strLocationAutoID, string strClientCode, string strTimeFrom, string strTimeTo, string strDutyDate, string strToDate, string strModifiedBy, string strTourID, string strAsmtCode, string strPostCode, string strScanType, string strSelectedGT)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[13];

            objParm[0] = new SqlParameter("@CompanyCode", strCompanyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", strLocationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", strClientCode);
            objParm[3] = new SqlParameter("@TimeFrom", strTimeFrom);
            objParm[4] = new SqlParameter("@TimeTo", strTimeTo);
            objParm[5] = new SqlParameter("@DutyDate", strDutyDate);
            objParm[6] = new SqlParameter("@ModifiedBy", strModifiedBy);
            objParm[7] = new SqlParameter("@GTourID", strTourID);
            objParm[8] = new SqlParameter("@AsmtCode", strAsmtCode);
            objParm[9] = new SqlParameter("@PostCode", strPostCode);
            objParm[10] = new SqlParameter("@WETDate", strToDate);
            objParm[11] = new SqlParameter("@ScanType", strScanType);
            objParm[12] = new SqlParameter("@SelectedGT", strSelectedGT);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCguardTour_Export", objParm);
            return ds;
        }

        /// <summary>
        /// Function used to export NFC POP Records.
        /// </summary>
        /// <param name="strPOPWefDate">The string pop wef date.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="strPOPWET">The string popwet.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNFCPOPExport(string strPOPWefDate, string strLocationAutoID, string strAsmtCode, string strPOPWET)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter("@POPWefDate", DL.Common.DateFormat(strPOPWefDate));
            objParm[1] = new SqlParameter("@LocationAutoID", strLocationAutoID);
            objParm[2] = new SqlParameter("@AsmtCode", strAsmtCode);
            objParm[3] = new SqlParameter("@POPWETDate", strPOPWET);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_POP_Export", objParm);
            return ds;
        }

        /// <summary>
        /// Function used to export NFC Vacant Records.
        /// </summary>
        /// <param name="strCompanyCode">The string company code.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strTimeFrom">The string time from.</param>
        /// <param name="strTimeTo">The string time to.</param>
        /// <param name="strDutyDate">The string duty date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcVacantExport(string strCompanyCode, string strLocationAutoID, string strClientCode, string strTimeFrom, string strTimeTo, string strDutyDate, string strToDate, string strModifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@CompanyCode", strCompanyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", strLocationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", strClientCode);
            objParm[3] = new SqlParameter("@TimeFrom", strTimeFrom);
            objParm[4] = new SqlParameter("@TimeTo", strTimeTo);
            objParm[5] = new SqlParameter("@DutyDate", DL.Common.DateFormat(strDutyDate));
            objParm[6] = new SqlParameter("@ModifiedBy", strModifiedBy);
            objParm[7] = new SqlParameter("@WETDate", DL.Common.DateFormat(strToDate));
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_NFCVacantPost_Export", objParm);
            return ds;
        }

        /// <summary>
        /// Dls the NFC no show export.
        /// </summary>
        /// <param name="strCompanyCode">The string company code.</param>
        /// <param name="strLocationAutoID">The string location automatic identifier.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strTimeFrom">The string time from.</param>
        /// <param name="strTimeTo">The string time to.</param>
        /// <param name="strDutyDate">The string duty date.</param>
        /// <param name="strToDate">The string to date.</param>
        /// <param name="strModifiedBy">The string modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlNfcNoShowExport(string strCompanyCode, string strLocationAutoID, string strClientCode, string strTimeFrom, string strTimeTo, string strDutyDate, string strToDate, string strModifiedBy)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter("@CompanyCode", strCompanyCode);
            objParm[1] = new SqlParameter("@LocationAutoID", strLocationAutoID);
            objParm[2] = new SqlParameter("@ClientCode", strClientCode);
            objParm[3] = new SqlParameter("@TimeFrom", strTimeFrom);
            objParm[4] = new SqlParameter("@TimeTo", strTimeTo);
            objParm[5] = new SqlParameter("@DutyDate", strDutyDate);

            objParm[6] = new SqlParameter("@ModifiedBy", strModifiedBy);
            objParm[7] = new SqlParameter("@WETDate", strToDate);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NFCNoShow_Export", objParm);
            return ds;
        }
        #endregion


        #region  POP Interval Screen

        /// <summary>
        /// Dls the pop interval_ insert.
        /// </summary>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="strEffectiveFrom">The string effective from.</param>
        /// <param name="strPostCode">The string post code.</param>
        /// <param name="POPInterval">The pop interval.</param>
        /// <param name="strUserId">The string user identifier.</param>
        /// <param name="AutolocationID">The autolocation identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet dlPopInterval_Insert(string strAsmtCode, string ClientCode, string strEffectiveFrom, string strPostCode, string POPInterval, string strUserId, string AutolocationID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objparm = new SqlParameter[7];
            objparm[0] = new SqlParameter("@AsmtCode", strAsmtCode);
            objparm[1] = new SqlParameter("@ClientCode", ClientCode);
            objparm[2] = new SqlParameter("@PopStartTime", strEffectiveFrom);
            objparm[3] = new SqlParameter("@Userid", strUserId);
            objparm[4] = new SqlParameter("@PostCode", strPostCode);
            objparm[5] = new SqlParameter("@PopInterval", POPInterval);
            objparm[6] = new SqlParameter("@LocationAutoID", AutolocationID);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMisc_PopInterval_Insert", objparm);
            return ds;

        }

        /// <summary>
        /// Dls the pop interval_ close.
        /// </summary>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strPostCode">The string post code.</param>
        /// <param name="strUserId">The string user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet dlPopInterval_Close(string strAsmtCode, string strClientCode, string strPostCode, string strUserId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objparm = new SqlParameter[4];
            objparm[0] = new SqlParameter("@AsmtCode", strAsmtCode);
            objparm[1] = new SqlParameter("@ClientCode", strClientCode);
            objparm[2] = new SqlParameter("@Userid", strUserId);
            objparm[3] = new SqlParameter("@PostCode", strPostCode);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMisc_Popinterval_Close", objparm);
            return ds;

        }

        /// <summary>
        /// Dls the pop interval_ get.
        /// </summary>
        /// <param name="LocationAutoID">The location automatic identifier.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet dlPopInterval_Get(string LocationAutoID, string strAsmtCode)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objparm = new SqlParameter[2];
            objparm[0] = new SqlParameter("@LocationAutoID", LocationAutoID);
            objparm[1] = new SqlParameter("@AsmtCode", strAsmtCode);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpRoster_mstPOPInterval_Get", objparm);
            return ds;

        }

        /// <summary>
        /// Function used to updated Pop Interval
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="AsmtCode">The asmt code.</param>
        /// <param name="POPInterval">The pop interval.</param>
        /// <param name="PopStartTime">The pop start time.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlPopInterval_Update(string clientCode, string AsmtCode, string POPInterval, string PopStartTime)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter("@ClientCode", clientCode);
            objParm[1] = new SqlParameter("@AsmtCode", AsmtCode);
            objParm[2] = new SqlParameter("@POPInterval", POPInterval);
            objParm[3] = new SqlParameter("@PopStartTime", PopStartTime);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMisc_Popinterval_Update", objParm);
            return ds;
        }

        #endregion
    }
}
