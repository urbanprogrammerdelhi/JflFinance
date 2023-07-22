// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 04-27-2015
//
// Last Modified By : Administrator
// Last Modified On : 02-12-2015
// ***********************************************************************
// <copyright file="Report.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class Report.
    /// </summary>
    [CLSCompliant(false)]
    public class Report
    {
        #region function related to reports
        /// <summary>
        /// Dls the sector breakdown client get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet DLSectorBreakdownClientGet(string companyCode, string fromDate, string toDate)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.FromDate, Common.DateFormat(fromDate));
            objParm[2] = new SqlParameter(Properties.Resources.ToDate, Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_salesRpt_ClientSectorBreakDown", objParm);
            return ds;
        }

        /// <summary>
        /// Dls the employees of branch.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public static DataSet DLEmployeesOfBranch(string companyCode, int locationAutoId, DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[3] = new SqlParameter(Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RosterRpt_EmployeesOfBranch", objParm);
            return ds;
        }



        #endregion

        #region India
        #region Manual Leave upload India
        /// <summary>
        /// Dls the leave upload india.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>DataSet.</returns>
        public static DataSet DLLeaveUploadIndia(string companyCode, string hrLocationCode, string employeeNumber, int month, int year)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(Properties.Resources.Month, month);
            objParm[4] = new SqlParameter(Properties.Resources.Year, year);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "proc_UploadLeavesIndia", objParm);
            return ds;
        }
        #endregion

        /// <summary>
        /// Dls the unit register excel india.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="dutyType">Type of the duty.</param>
        /// <returns>DataSet.</returns>
        public static DataSet DLUnitRegisterExcelIndia(int locationAutoId, string clientCode, string asmtCode, string fromDate, string toDate, string dutyType)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(Properties.Resources.FromDate, Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(Properties.Resources.ToDate, Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(Properties.Resources.DutyTypeCode, dutyType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RostRpt_UnitRegister", objParm);
            return ds;
        }

        #region posting sheet
        /// <summary>
        /// Dls the posting sheet india.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public static DataSet DLPostingSheetIndia(int locationAutoId, string clientCode, string asmtCode, string fromDate, string toDate, string shiftCode, string areaId, string userId)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(Properties.Resources.AsmtCode, asmtCode);
            objParm[3] = new SqlParameter(Properties.Resources.FromDate, Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(Properties.Resources.ToDate, Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(Properties.Resources.ShiftCode, shiftCode);
            objParm[6] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[7] = new SqlParameter(Properties.Resources.UserId, userId);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_rosterrpt_weeklypostingsheetDuplicate", objParm);
            return ds;
        }
        #endregion

        #endregion

        /// <summary>
        /// Australia Leave Output
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet OutputHoursDistribution(string companyCode, string locationAutoId, string clientCode, string fromDate, string toDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[4] = new SqlParameter(Properties.Resources.ToDate, toDate);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAusOutputHoursDistribution", objParm);
            return ds;
        }

        /// <summary>
        /// Function Used to process data for the BranchWiseEffectiveness Report
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="year">The year.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataTable.</returns>
        public DataTable GuardingManagementBranchWiseSuccess(string companyCode, string hrLocationCode, string locationCode, string year, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(Properties.Resources.Year, int.Parse(year));
            objParm[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataTable ds = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpBranchWiseEffectiveness_Rpt", objParm);
            return ds;
        }

        /// <summary>
        /// muster roll report
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="categoryCode">The category code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataTable.</returns>
        public DataTable MusterRoll(string companyCode, string hrLocationCode, string locationCode, string categoryCode, string fromDate, string toDate, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationCode, locationCode);
            objParm[3] = new SqlParameter(Properties.Resources.CategoryCode, categoryCode);
            objParm[4] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[5] = new SqlParameter(Properties.Resources.ToDate, toDate);
            objParm[6] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataTable ds = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpTransMusterRoll_4Excel", objParm);
            return ds;
        }
        /// <summary>
        /// A Register report
        /// </summary>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="customerCode">The customer code.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="includeCentralizedBilling">if set to <c>true</c> [include centralized billing].</param>
        /// <returns>DataSet.</returns>
        public DataSet ARegister(string hrLocationCode, string locationCode, string customerCode, string year, string month,bool includeCentralizedBilling)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[1] = new SqlParameter(Properties.Resources.LocationCode, locationCode);
            objParm[2] = new SqlParameter(Properties.Resources.CustomerCode, customerCode);
            objParm[3] = new SqlParameter(Properties.Resources.Year, year);
            objParm[4] = new SqlParameter(Properties.Resources.Month, month);
            objParm[5] = new SqlParameter(Properties.Resources.Billable, includeCentralizedBilling);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpARegister", objParm);
            return ds;
        }

        /// <summary>
        /// This Process the Invoice for ARegister Report
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>DataSet.</returns>
        public DataSet ARegisterProcess(string locationId, string month, string year)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationId);
            objParm[1] = new SqlParameter(Properties.Resources.Month, month);
            objParm[2] = new SqlParameter(Properties.Resources.Year, year);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_InvProcessing", objParm);
            return ds;
        }

        #region functions related to Cyprus Invoice text Output
        /// <summary>
        /// Function used to Get the Records for Invoice Text Header Output
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataTable.</returns>
        public DataTable InvoiceTextHeaderOutput(string companyCode, string hrLocationCode, string locationAutoId, string areaId, string clientCode, string soNo, string invoiceType, DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToDecimal(locationAutoId));
            objParm[3] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(Properties.Resources.SONO, soNo);
            objParm[6] = new SqlParameter(Properties.Resources.InvoiceType, invoiceType);
            objParm[8] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[9] = new SqlParameter(Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptInvoiceHeaderOutputGet", objParm);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// Function used to Get the Records for Invoice Text Footer Output
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="period">The period.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="vat">The vat.</param>
        /// <returns>DataTable.</returns>
        public DataTable InvoiceTextFooterOutput(string companyCode, string hrLocationCode, string locationAutoId, string areaId, string clientCode, string soNo, string invoiceType, string period, DateTime fromDate, DateTime toDate, string vat)
        {
            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToDecimal(locationAutoId));
            objParm[3] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(Properties.Resources.SONO, soNo);
            objParm[6] = new SqlParameter(Properties.Resources.InvoiceType, invoiceType);
            objParm[7] = new SqlParameter(Properties.Resources.Period, period);
            objParm[8] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[9] = new SqlParameter(Properties.Resources.ToDate, toDate);
            objParm[10] = new SqlParameter(Properties.Resources.Value, vat);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptInvoiceFooterOutputGet", objParm);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// Function used to Get the Records for Invoice Text Footer Item Output
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="period">The period.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="vat">The vat.</param>
        /// <returns>DataTable.</returns>
        public DataTable InvoiceTextFooterItemOutput(string companyCode, string hrLocationCode, string locationAutoId, string areaId, string clientCode, string soNo, string invoiceType, string period, DateTime fromDate, DateTime toDate, string vat)
        {
            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToDecimal(locationAutoId));
            objParm[3] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(Properties.Resources.SONO, soNo);
            objParm[6] = new SqlParameter(Properties.Resources.InvoiceType, invoiceType);
            objParm[7] = new SqlParameter(Properties.Resources.Period, period);
            objParm[8] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[9] = new SqlParameter(Properties.Resources.ToDate, toDate);
            objParm[10] = new SqlParameter(Properties.Resources.Value, vat);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptInvoiceFooterItemOutputGet", objParm);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        #endregion

        #region functions related to Cyprus Invoice text Output
        /// <summary>
        /// Function used to Get the Records for Invoice Text Header Output
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataTable.</returns>
        public DataTable InvoicePDFHeaderOutput(string companyCode, string hrLocationCode, string locationAutoId, string areaId, string clientCode, string soNo, string invoiceType, DateTime fromDate, DateTime toDate)
        {
            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToDecimal(locationAutoId));
            objParm[3] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(Properties.Resources.SONO, soNo);
            objParm[6] = new SqlParameter(Properties.Resources.InvoiceType, invoiceType);
            objParm[8] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[9] = new SqlParameter(Properties.Resources.ToDate, toDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptInvoicePDFHeaderOutputGet", objParm);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// Function used to Get the Records for Invoice Text Footer Output
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="period">The period.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="vat">The vat.</param>
        /// <returns>DataTable.</returns>
        public DataTable InvoicePDFFooterOutput(string companyCode, string hrLocationCode, string locationAutoId, string areaId, string clientCode, string soNo, string invoiceType, string period, DateTime fromDate, DateTime toDate, string vat)
        {
            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToDecimal(locationAutoId));
            objParm[3] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(Properties.Resources.SONO, soNo);
            objParm[6] = new SqlParameter(Properties.Resources.InvoiceType, invoiceType);
            objParm[7] = new SqlParameter(Properties.Resources.Period, period);
            objParm[8] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[9] = new SqlParameter(Properties.Resources.ToDate, toDate);
            objParm[10] = new SqlParameter(Properties.Resources.Value, vat);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptInvoicePDFFooterOutputGet", objParm);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// Function used to Get the Records for Invoice Text Footer Item Output
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="period">The period.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="vat">The vat.</param>
        /// <returns>DataTable.</returns>
        public DataTable InvoicePDFFooterItemOutput(string companyCode, string hrLocationCode, string locationAutoId, string areaId, string clientCode, string soNo, string invoiceType, string period, DateTime fromDate, DateTime toDate, string vat)
        {
            SqlParameter[] objParm = new SqlParameter[11];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToDecimal(locationAutoId));
            objParm[3] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[5] = new SqlParameter(Properties.Resources.SONO, soNo);
            objParm[6] = new SqlParameter(Properties.Resources.InvoiceType, invoiceType);
            objParm[7] = new SqlParameter(Properties.Resources.Period, period);
            objParm[8] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[9] = new SqlParameter(Properties.Resources.ToDate, toDate);
            objParm[10] = new SqlParameter(Properties.Resources.Value, vat);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptInvoicePDFFooterItemOutputGet", objParm);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        #endregion

        #region ThailandReports

        /// <summary>
        /// Gets the List of HeadCodes for the Attendance Type = "Processing"
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Datatable with list of Processing HeadCodes</returns>
        public DataTable ProcessingHoursType(string companyCode)
        {
            var param = new SqlParameter[1];
            param[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            var dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpHoursHeadCompanyGetAll", param);
            return dt;
        }
        #endregion


        /// <summary>
        /// Gets Israel Report details for SO
        /// </summary>
        /// <param name="companyCode">Company Code</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="clientCode">Client Code</param>
        /// <param name="asmtCode">Asmt Id</param>
        /// <param name="areaId">Arae Id</param>
        /// <param name="areaIncharge">Area incharge</param>
        /// <param name="centerlize">Is Centerlize included</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailsISR(string companyCode, string locationAutoId, string clientCode, string asmtCode, string areaId, string areaIncharge, string centerlize)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[5] = new SqlParameter(Properties.Resources.AreaIncharge, areaIncharge);
            objParm[6] = new SqlParameter(Properties.Resources.CenterlizeBilling, bool.Parse(centerlize));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptSaleorderDetail_ISR", objParm);
           
            return ds;
        }

        /// <summary>
        /// Gets Report details for SO
        /// </summary>
        /// <param name="companyCode">Company Code</param>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <param name="clientCode">Client Code</param>
        /// <param name="asmtCode">Asmt Id</param>
        /// <param name="areaId">Arae Id</param>
        /// <param name="areaIncharge">Area incharge</param>
        /// <param name="centerlize">Is Centerlize included</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetails(string companyCode, string locationAutoId, string clientCode, string asmtCode, string areaId, string areaIncharge, string centerlize)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(Properties.Resources.AsmtCode, asmtCode);
            objParm[4] = new SqlParameter(Properties.Resources.AreaId, areaId);
            objParm[5] = new SqlParameter(Properties.Resources.AreaIncharge, areaIncharge);
            objParm[6] = new SqlParameter(Properties.Resources.CenterlizeBilling, bool.Parse(centerlize));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_RptSaleOrderValue", objParm);

            return ds;
        }

        /// <summary>
        /// Gets EmployeeWise Constraint Details
        /// </summary>
        /// <param name="CompanyCode">Company Code</param>
        /// <param name="LocationAutoId">Auto Id</param>
        /// <param name="EmployeeNumber">Employee Number</param>
        /// <param name="AreaId">Area Id</param>
        /// <param name="AreaIncharge">Area Incharge</param>
        /// <param name="TrainingCode">Training Code</param>
        /// <param name="QualificationCode">Qualification Code</param>
        /// <param name="SkillCode">Skill Code</param>
        /// <param name="ConstraintCode">Constraint Code</param>
        /// <param name="IdType">Id Type</param>
        /// <param name="LanguageCode">Language Code</param>
        /// <returns>Employee Wise Constraint Details</returns>
        public DataSet EmployeeConstraintIsrGet(string CompanyCode, string LocationAutoId, string EmployeeNumber,
            string AreaId, string AreaIncharge, string TrainingCode, string QualificationCode, string SkillCode,
            string ConstraintCode, string IdType, string LanguageCode)
        {
            var ObjParam = new SqlParameter[11];
            ObjParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            ObjParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            ObjParam[2] = new SqlParameter(Properties.Resources.EmployeeNumber, EmployeeNumber);
            ObjParam[3] = new SqlParameter(Properties.Resources.AreaId, AreaId);
            ObjParam[4] = new SqlParameter(Properties.Resources.AreaIncharge, AreaIncharge);
            ObjParam[5] = new SqlParameter(Properties.Resources.TrainingCode, TrainingCode);
            ObjParam[6] = new SqlParameter(Properties.Resources.QualificationCode, QualificationCode);
            ObjParam[7] = new SqlParameter(Properties.Resources.SkillCode, SkillCode);
            ObjParam[8] = new SqlParameter(Properties.Resources.ConstraintCode, ConstraintCode);
            ObjParam[9] = new SqlParameter(Properties.Resources.IDType, IdType);
            ObjParam[10] = new SqlParameter(Properties.Resources.LanguageCode, LanguageCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_EmployeeConstraint_Rpt", ObjParam);

            return ds;
        }
        /// <summary>
        /// Gets List of All Client Constraint
        /// </summary>
        /// <param name="CompanyCode">CompanyCode</param>
        /// <param name="LocationAutoId">LocationAutoId</param>
        /// <param name="ClientCode">Client Code</param>
        /// <param name="AsmtId">Assignment ID</param>
        /// <param name="PostCode">PostCode ID</param>
        /// <param name="AreaId">AraeId</param>
        /// <param name="AreaIncharge">InchargeCode</param>
        /// <param name="ConstraintCode">All/Man/In/Recom</param>
        /// <param name="TrainingCode">Training Code</param>
        /// <returns>DataSet Object of Client details</returns>
        public DataSet CustomerConstraintIsrGet(string CompanyCode, string LocationAutoId, string ClientCode,string AsmtId,string PostCode,
            string AreaId, string AreaIncharge, string ConstraintCode,string TrainingCode)
        {
            var ObjParam = new SqlParameter[9];
            ObjParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            ObjParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            ObjParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            ObjParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            ObjParam[4] = new SqlParameter(Properties.Resources.PostCode, PostCode);
            ObjParam[5] = new SqlParameter(Properties.Resources.AreaId, AreaId);
            ObjParam[6] = new SqlParameter(Properties.Resources.AreaIncharge, AreaIncharge);
            ObjParam[7] = new SqlParameter(Properties.Resources.ConstraintCode, ConstraintCode);
            ObjParam[8] = new SqlParameter(Properties.Resources.TrainingCode, TrainingCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpHr_CustomerConstraint_Rpt", ObjParam);

            return ds;
        }
    }
}
