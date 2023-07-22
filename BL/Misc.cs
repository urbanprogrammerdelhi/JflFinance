// ***********************************************************************
// Assembly         : BL
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

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeTypeGetAll();
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeTypeInsert(quickCode, quickCodeDesc, status, parentQuickCode, modifiedBy);
            return ds;

        }
        /// <summary>
        /// TO delete data from QuickCode master
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeDelete(string quickCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeTypeDelete(quickCode);
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeTypeUpdate(quickCode, quickCodeDesc, status, parentQuickCode, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To get All Data from Quick Code Master Based on QuickCode swelected from QuickCodeType
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeMasterGetAll(string quickCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeMasterGetAll(quickCode);
            return ds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quickCode"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public DataSet MappedQuickCodeMasterGet(string quickCode, string companyCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.MappedQuickCodeMasterGet(quickCode, companyCode);
            return ds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quickCode"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public DataSet UnMappedQuickCodeMasterGet(string quickCode, string companyCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.UnMappedQuickCodeMasterGet(quickCode, companyCode);
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeMasterGetParentId(ItemCode, companyCode, QuickCode);
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeMasterInsert(QuickCode, ItemCode, ItemDesc, status, ParentItemCode, modifiedBy, companyCode);
            return ds;
        }
        /// <summary>
        /// To get parentId for QuickCodeType
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeParentIdGet()
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeTypeParentIdGet();
            return ds;

        }
        /// <summary>
        /// To get Quick Codes those can be set as the parent quick code of the given QuickCode
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeParentIdGet(string quickCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeTypeParentIdGet(quickCode);
            return ds;
        }
        /// <summary>
        /// TO get QuickCodeTypeAutoId Based on QuickCode
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeAutoIdGet(string quickCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeTypeAutoIdGet(quickCode);
            return ds;
        }
        /// <summary>
        /// To Disable QuickCode in Quick Code Type
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DisableQuickCodeType(string quickCode, string companyCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.DisableQuickCodeType(quickCode, companyCode);
            return ds;
        }
        /// <summary>
        /// To Enable QuickCode in Quick Code Type
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EnableQuickCodeType(string quickCode, string companyCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.EnableQuickCodeType(quickCode, companyCode);
            return ds;
        }
        /// <summary>
        /// To SHow Enable Disable image in Quick Code Type gridview
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeTypeGet()
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeTypeGet();
            return ds;
        }
        /// <summary>
        /// To Check If Child is made parent of QuickCode or not in QuickCode Type Gridview
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckParentChildRelation(string quickCode, int parentId)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.CheckParentChildRelation(quickCode, parentId);
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.DisableQuickCodeMaster(ItemDesc, companyCode, quickCode);
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeMasterGetEnableDisable(quickCode, companyCode);
            return ds;
        }
        /// <summary>
        /// To Enable QuickCode in Quick Code Master
        /// </summary>
        /// <param name="ItemDesc">The item desc.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EnableQuickCodeMaster(int ItemDesc, string companyCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.EnableQuickCodeMaster(ItemDesc, companyCode);
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
            var objMisc = new DL.Misc();
            return objMisc.QuickCodeMasterUpdate(quickCode, itemCode, itemDesc, status, parentItemCode, modifiedBy, companyCode);
        }
        /// <summary>
        /// To delete a Quick code item
        /// </summary>
        /// <param name="quickCode">The quick code.</param>
        /// <param name="ItemCode">The item code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeMasterDelete(string quickCode, string ItemCode)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeMasterDelete(quickCode, ItemCode);
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.QuickCodeUomGet(companyCode);
            return ds;
        }
        #endregion

        # region Controller Screen Function


        /// <summary>
        /// Clients the controller.
        /// </summary>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientController(DateTime dutyDate, DateTime timeFrom, DateTime timeTo)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.ClientController(dutyDate, timeFrom, timeTo);
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.NfcIncident(companyCode, locationAutoId, clientCode, dutyDate, timeFrom, timeTo);
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
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.PanicAlert(companyCode, locationAutoId, clientCode, dutyDate, timeFrom, timeTo);
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
            DL.Misc objNFC = new DL.Misc();
            DataSet ds = objNFC.NfcNoShowsGet(companyCode, locationAutoId, clientCode, dutyDate, timeTo, timeFrom);
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
            DL.Misc objNFC = new DL.Misc();
            DataSet ds = objNFC.NfcVacantPostsGet(companyCode, locationAutoId, clientCode, dutyDate, timeTo, timeFrom);
            return ds;
        }


        /// <summary>
        /// Assignments the controller.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="swipeDate">The swipe date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentController(string clientCode, DateTime swipeDate, DateTime timeFrom, DateTime timeTo)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.AssignmentController(clientCode, swipeDate, timeFrom, timeTo);
            return ds;
        }



        /// <summary>
        /// Assignments the wise employees get.
        /// </summary>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="dutyDate">The duty date.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentWiseEmployeesGet(string asmtCode, DateTime dutyDate, DateTime timeFrom, DateTime timeTo)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.AssignmentWiseEmployeesGet(asmtCode, dutyDate, timeFrom, timeTo);
            return ds;
        }

        /// <summary>
        /// Assignments the controller confirm.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="date">The date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentControllerConfirm(string locationAutoId, string employeeNumber, string asmtCode, string date, string modifiedBy)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.AssignmentControllerConfirm(locationAutoId, employeeNumber, asmtCode, date, modifiedBy);
            return ds;
        }

        # endregion

        # region NFC Attendance Directly from ITek

        /// <summary>
        /// NFCs the attendance.
        /// </summary>
        /// <param name="imei">Unique mobile Identification Number</param>
        /// <param name="employeeTag">Unique EmployeeId</param>
        /// <param name="swipeType">Type of the swipe.</param>
        /// <param name="date">The date.</param>
        /// <returns>DataSet.</returns>
        public DataSet NfcAttendance(string imei, string employeeTag, string swipeType, DateTime date)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = objMisc.NfcAttendance(imei, employeeTag, swipeType, date);
            return ds;
        }

        #endregion

        // sync secure trax 16-10-2012

        /// <summary>
        /// Bls the client controller.
        /// </summary>
        /// <param name="dutydate">The dutydate.</param>
        /// <param name="tf">The tf.</param>
        /// <param name="tt">The tt.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="wetDate">The wet date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="postString">The post string.</param>
        /// <param name="scan">The scan.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlClientController(DateTime dutydate, DateTime tf, DateTime tt, string clientCode, string wetDate, string locationAutoID, string flag, string postString, string scan)
        {
            DataSet ds = new DataSet();
            DL.Misc objMisc = new DL.Misc();
            ds = objMisc.DlClientController(dutydate, tf, tt, clientCode, wetDate, locationAutoID, flag, postString, scan);
            return ds;
        }

        /// <summary>
        /// Bls the misc get all guard tour identifier.
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <param name="LocationAutoID">The location automatic identifier.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="AsmtCode">The asmt code.</param>
        /// <param name="PostCode">The post code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlMiscGetAllGuardTourID(string CompanyCode, string LocationAutoID, string ClientCode, string AsmtCode, string PostCode)
        {
            DataSet ds = new DataSet();
            DL.Misc objMisc = new DL.Misc();
            ds = objMisc.DlMiscGetAllGuardTourID(CompanyCode, LocationAutoID, ClientCode, AsmtCode, PostCode);
            return ds;
        }

        /// <summary>
        /// Bls the misc get all guard tour.
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <param name="LocationAutoID">The location automatic identifier.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="TimeFrom">The time from.</param>
        /// <param name="TimeTo">The time to.</param>
        /// <param name="DutyDate">The duty date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="ModifiedBy">The modified by.</param>
        /// <param name="TourID">The tour identifier.</param>
        /// <param name="AsmtCode">The asmt code.</param>
        /// <param name="PostCode">The post code.</param>
        /// <param name="ScanType">Type of the scan.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlMiscGetAllGuardTour(string CompanyCode, string LocationAutoID, string ClientCode, string TimeFrom, string TimeTo, string DutyDate, string ToDate, string ModifiedBy, string TourID, string AsmtCode, string PostCode, string ScanType)
        {
            DataSet ds = new DataSet();
            DL.Misc objMics = new DL.Misc();
            ds = objMics.DlMiscGetAllGuardTourClient(CompanyCode, LocationAutoID, ClientCode, TimeFrom, TimeTo, DutyDate, ToDate, ModifiedBy, TourID, AsmtCode, PostCode, ScanType);
            return ds;
        }

        /// <summary>
        /// Bls the assignment controller.
        /// </summary>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="SwipeDate">The swipe date.</param>
        /// <param name="tf">The tf.</param>
        /// <param name="tt">The tt.</param>
        /// <param name="WETDate">The wet date.</param>
        /// <param name="LocationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlAssignmentController(string ClientCode, DateTime SwipeDate, DateTime tf, DateTime tt, string WETDate, string LocationAutoID)
        {
            DataSet ds = new DataSet();
            DL.Misc objMisc = new DL.Misc();
            ds = objMisc.DlAssignmentController(ClientCode, SwipeDate, tf, tt, WETDate, LocationAutoID);
            return ds;
        }



        /// <summary>
        /// Bls the emp assignment wise.
        /// </summary>
        /// <param name="AsmtCode">The asmt code.</param>
        /// <param name="dutydate">The dutydate.</param>
        /// <param name="tf">The tf.</param>
        /// <param name="tt">The tt.</param>
        /// <param name="WETDate">The wet date.</param>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlEmpAssignmentWise(string AsmtCode, DateTime dutydate, DateTime tf, DateTime tt, string WETDate, string locationAutoID)
        {
            DataSet ds = new DataSet();
            DL.Misc objMisc = new DL.Misc();
            ds = objMisc.DlEmpAssignmentWise(AsmtCode, dutydate, tf, tt, WETDate, locationAutoID);
            return ds;
        }

        /// <summary>
        /// Bls the assignment controller confirm.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="date">The date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlAssignmentControllerConfirm(string locationAutoID, string employeeNumber, string clientCode, string asmtCode, string date, string modifiedBy)
        {
            DataSet ds = new DataSet();
            DL.Misc objMisc = new DL.Misc();
            ds = objMisc.DlAssignmentControllerConfirm(locationAutoID, employeeNumber, clientCode, asmtCode, date, modifiedBy);
            return ds;
        }

        # region POP Interval Screen Function

        /// <summary>
        /// Bls the pop interval_ insert.
        /// </summary>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strEffectiveFrom">The string effective from.</param>
        /// <param name="strPostCode">The string post code.</param>
        /// <param name="POPInterval">The pop interval.</param>
        /// <param name="strUserId">The string user identifier.</param>
        /// <param name="AutolocationID">The autolocation identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet blPopInterval_Insert(string strAsmtCode, string strClientCode, string strEffectiveFrom, string strPostCode, string POPInterval, string strUserId, string AutolocationID)
        {
            DL.Misc objMics = new DL.Misc();
            DataSet ds = new DataSet();
            ds = objMics.dlPopInterval_Insert(strAsmtCode, strClientCode, strEffectiveFrom, strPostCode, POPInterval, strUserId, AutolocationID);
            return ds;
        }



        /// <summary>
        /// Bls the pop interval_ close.
        /// </summary>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <param name="strClientCode">The string client code.</param>
        /// <param name="strPostCode">The string post code.</param>
        /// <param name="strUserId">The string user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet blPopInterval_Close(string strAsmtCode, string strClientCode, string strPostCode, string strUserId)
        {
            DL.Misc objMisc = new DL.Misc();
            DataSet ds = new DataSet();
            ds = objMisc.dlPopInterval_Close(strAsmtCode, strClientCode, strPostCode, strUserId);
            return ds;
        }



        /// <summary>
        /// Bls the pop interval_ get.
        /// </summary>
        /// <param name="LocationAutoID">The location automatic identifier.</param>
        /// <param name="strAsmtCode">The string asmt code.</param>
        /// <returns>DataSet.</returns>
        public DataSet blPopInterval_Get(string LocationAutoID, string strAsmtCode)
        {
            DL.Misc objmisc = new DL.Misc();
            DataSet ds = new DataSet();
            ds = objmisc.dlPopInterval_Get(LocationAutoID, strAsmtCode);
            return ds;
        }

        /// <summary>
        /// Function used to updated Pop Interval
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="AsmtCode">The asmt code.</param>
        /// <param name="POPInterval">The pop interval.</param>
        /// <param name="strPOPStartTime">The string pop start time.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlPopInterval_Update(string clientCode, string AsmtCode, string POPInterval, string strPOPStartTime)
        {
            DL.Misc objmisc = new DL.Misc();
            DataSet ds = new DataSet();
            ds = objmisc.DlPopInterval_Update(clientCode, AsmtCode, POPInterval, strPOPStartTime);
            return ds;
        }
        # endregion

    }
}
