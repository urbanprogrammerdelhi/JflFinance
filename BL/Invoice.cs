// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Invoice.cs" company="Magnon">
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
    /// Class Invoice.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Invoice
    {
        #region Function Related to Invoice Generation
        #region Function Related to Invoice Generation Screen Fetching Sales Order for Client
        /// <summary>
        /// Orders the information get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet OrderInformationGet(string locationAutoId, string clientCode)
        {

            DL.Invoice objInvoice = new DL.Invoice();
            DataSet ds = objInvoice.OrderInformationGet(locationAutoId, clientCode);
            return ds;
        }
        #endregion

        #region Function Related to Invoice Header

        #region Get Function
        /// <summary>
        /// Invoices the header get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceHeaderGet(string locationAutoId, string invoiceNo)
        {
            DL.Invoice objdlInvoiceDetails = new DL.Invoice();

            DataSet ds = objdlInvoiceDetails.InvoiceHeaderGet(locationAutoId, invoiceNo);
            return ds;
        }

        /// <summary>
        /// Checks the invoice period.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="statusReversal">The status reversal.</param>
        /// <param name="statusDelete">The status delete.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckInvoicePeriod(string locationAutoId, string clientCode, string soNo, string fromDate, string toDate, string statusReversal, string statusDelete)
        {
            DL.Invoice objdlInvoiceDetails = new DL.Invoice();

            DataSet ds = objdlInvoiceDetails.CheckInvoicePeriod(locationAutoId, clientCode, soNo, fromDate, toDate, statusReversal, statusDelete);
            return ds;
        }
        #endregion

        #region Insert Functions
        /// <summary>
        /// Function to insert Invoice header, Invoice Service Details and Invoice Item Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="invoiceDate">The invoice date.</param>
        /// <param name="status">The status.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="billingId">The billing identifier.</param>
        /// <param name="billingAddress">The billing address.</param>
        /// <param name="periodFrom">The period from.</param>
        /// <param name="periodTo">The period to.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="subtotal">The subtotal.</param>
        /// <param name="tax">The tax.</param>
        /// <param name="grandTotal">The grand total.</param>
        /// <param name="soDetails">The so details.</param>
        /// <param name="soItemDetails">The so item details.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="postingDate">The posting date.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceHeaderInsert(string locationAutoId, string invoiceNo, DateTime invoiceDate, string status, string invoiceType, string clientCode, string clientName, string soNo, string billingId, string billingAddress, DateTime periodFrom, DateTime periodTo, string remarks, decimal subtotal, decimal tax, decimal grandTotal, DataTable soDetails, DataTable soItemDetails, string modifiedBy, string mode, DateTime postingDate)
        {
            DL.Invoice objdlInvoiceDetails = new DL.Invoice();

            DataSet ds = objdlInvoiceDetails.InvoiceHeaderInsert(locationAutoId, invoiceNo, invoiceDate, status, invoiceType, clientCode, clientName, soNo, billingId, billingAddress, periodFrom, periodTo, remarks, subtotal, tax, grandTotal, soDetails, soItemDetails, modifiedBy, mode, postingDate);
            return ds;
        }
        #endregion

        #region Update Function
        /// <summary>
        /// function to Update Invoice Header Informations
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="invoiceDate">The invoice date.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="subtotal">The subtotal.</param>
        /// <param name="tax">The tax.</param>
        /// <param name="grandTotal">The grand total.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="postingDate">The posting date.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceHeaderUpdate(string locationAutoId, string invoiceNo, string invoiceDate, string remarks, decimal subtotal, decimal tax, decimal grandTotal, string modifiedBy, DateTime postingDate)
        {
            DL.Invoice objdlInvoice = new DL.Invoice();

            DataSet ds = objdlInvoice.InvoiceHeaderUpdate(locationAutoId, invoiceNo, invoiceDate, remarks, subtotal, tax, grandTotal, modifiedBy, postingDate);
            return ds;
        }
        #endregion

        #region Authorized Function
        /// <summary>
        /// Invoices the authorized.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="statusAuthorized">The status authorized.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceAuthorized(string locationAutoId, string invoiceNo, string statusAuthorized, string modifiedBy)
        {
            DL.Invoice objdlInvoice = new DL.Invoice();

            DataSet ds = objdlInvoice.InvoiceAuthorized(locationAutoId, invoiceNo, statusAuthorized, modifiedBy);
            return ds;
        }
        #endregion

        #region Reversal Function
        /// <summary>
        /// Invoices the reversal.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="statusReversal">The status reversal.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="reversalDate">The reversal date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="invoiceDate">The invoice date.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceReversal(string locationAutoId, string invoiceNo, string statusReversal, string modifiedBy, string reason, DateTime reversalDate, string clientCode, string soNo, DateTime fromDate, DateTime toDate, DateTime invoiceDate)
        {
            DL.Invoice objdlInvoice = new DL.Invoice();

            DataSet ds = objdlInvoice.InvoiceReversal(locationAutoId, invoiceNo, statusReversal, modifiedBy, reason, reversalDate, clientCode, soNo, fromDate, toDate, invoiceDate);
            return ds;
        }
        #endregion

        #region Deletion Function
        /// <summary>
        /// Invoices the deletion.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="statusDeleted">The status deleted.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceDeletion(string locationAutoId, string invoiceNo, string statusDeleted, string modifiedBy)
        {
            DL.Invoice objdlInvoice = new DL.Invoice();

            DataSet ds = objdlInvoice.InvoiceDeletion(locationAutoId, invoiceNo, statusDeleted, modifiedBy);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Invoice Services Details

        #region Get Function
        /// <summary>
        /// To get the Data from SaleOrder and Rostering transaction for Invoicing
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="authorizedStatus">The authorized status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailsGet(string locationAutoId, string soNo, string startDate, string endDate, string invoiceType, string authorizedStatus)
        {

            DL.Invoice objInvoice = new DL.Invoice();
            DataSet ds = objInvoice.SaleOrderDetailsGet(locationAutoId, soNo, startDate, endDate, invoiceType, authorizedStatus);
            return ds;
        }

        /// <summary>
        /// To get data from Invoice service Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceDetailsGet(string locationAutoId, string invoiceNo)
        {
            DL.Invoice objdlInvoiceDetails = new DL.Invoice();

            DataSet ds = objdlInvoiceDetails.InvoiceDetailsGet(locationAutoId, invoiceNo);
            return ds;
        }
        #endregion

        #region Update Function
        /// <summary>
        /// To Update Invoice Service Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="billingDesignation">The billing designation.</param>
        /// <param name="numberOfPost">The number of post.</param>
        /// <param name="hours">The hours.</param>
        /// <param name="daysInMonth">The days in month.</param>
        /// <param name="hoursInMonth">The hours in month.</param>
        /// <param name="soLineStartDate">The so line start date.</param>
        /// <param name="soLineEndDate">The so line end date.</param>
        /// <param name="otherAllowances">The other allowances.</param>
        /// <param name="sellingPrice">The selling price.</param>
        /// <param name="monthlyBilling">The monthly billing.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="rowNumber">The row number.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceDetailsUpdate(string locationAutoId, string invoiceNo, string soNo, string soAmendNo, string soLineNo, string billingDesignation, string numberOfPost, string hours, string daysInMonth, string hoursInMonth, string soLineStartDate, string soLineEndDate, string otherAllowances, string sellingPrice, string monthlyBilling, string remarks, string modifiedBy, int rowNumber)
        {
            DL.Invoice objdlInvoiceDetails = new DL.Invoice();

            DataSet ds = objdlInvoiceDetails.InvoiceDetailsUpdate(locationAutoId, invoiceNo, soNo, soAmendNo, soLineNo, billingDesignation, numberOfPost, hours, daysInMonth, hoursInMonth, soLineStartDate, soLineEndDate, otherAllowances, sellingPrice, monthlyBilling, remarks, modifiedBy, rowNumber);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Invoice Item Details
        #region Get Function
        /// <summary>
        /// To get the Data from SaleOrder Item Details for Invoicing
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="authorizedStatus">The authorized status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDetailsGet(string locationAutoId, string soNo, string startDate, string endDate, string authorizedStatus)
        {

            DL.Invoice objInvoice = new DL.Invoice();
            DataSet ds = objInvoice.SaleOrderItemDetailsGet(locationAutoId, soNo, startDate, endDate, authorizedStatus);
            return ds;
        }

        /// <summary>
        /// To get Data from Invoice Item Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceItemDetailsGet(string locationAutoId, string invoiceNo)
        {
            DL.Invoice objdlInvoiceDetails = new DL.Invoice();

            DataSet ds = objdlInvoiceDetails.InvoiceItemDetailsGet(locationAutoId, invoiceNo);
            return ds;
        }
        #endregion

        #region Update Function
        /// <summary>
        /// Invoices the item details update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="rate">The rate.</param>
        /// <param name="itemStartDate">The item start date.</param>
        /// <param name="itemEndDate">The item end date.</param>
        /// <param name="soItemRemarks">The so item remarks.</param>
        /// <param name="monthlyBill">The monthly bill.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceItemDetailsUpdate(string locationAutoId, string invoiceNo, string soNo, string soAmendNo, string itemTypeCode, string quantity, string rate, string itemStartDate, string itemEndDate, string soItemRemarks, string monthlyBill, string userId)
        {
            DL.Invoice objdlInvoiceDetails = new DL.Invoice();

            DataSet ds = objdlInvoiceDetails.InvoiceItemDetailsUpdate(locationAutoId, invoiceNo, soNo, soAmendNo, itemTypeCode, quantity, rate, itemStartDate, itemEndDate, soItemRemarks, monthlyBill, userId);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to Bulk Invoicing
        /// <summary>
        /// Soes the no get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soType">Type of the so.</param>
        /// <param name="billingPattern">The billing pattern.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="freshStatus">The fresh status.</param>
        /// <param name="reversalStatus">The reversal status.</param>
        /// <param name="deleteStatus">The delete status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SoNoGet(string locationAutoId, string clientCode, string soType, string billingPattern, string startDate, string endDate, string freshStatus, string reversalStatus, string deleteStatus)
        {
            DL.Invoice objdlInvoice = new DL.Invoice();

            DataSet ds = objdlInvoice.SoNoGet(locationAutoId, clientCode, soType, billingPattern, startDate, endDate, freshStatus, reversalStatus, deleteStatus);
            return ds;
        }
        /// <summary>
        /// Bulks the invoice generate.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceDate">The invoice date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="tax">The tax.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="authorizedStatus">The authorized status.</param>
        /// <param name="freshStatus">The fresh status.</param>
        /// <param name="reversalStatus">The reversal status.</param>
        /// <param name="postdate">The postdate.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="saleOrderTable">The sale order table.</param>
        /// <param name="deleteStatus">The delete status.</param>
        /// <returns>DataSet.</returns>
        public DataSet BulkInvoiceGenerate(string locationAutoId, string invoiceDate, string startDate, string endDate, string invoiceType, string tax, string remarks, string authorizedStatus, string freshStatus, string reversalStatus, string postdate, string modifiedBy, DataTable saleOrderTable, string deleteStatus)
        {
            DL.Invoice objdlInvoice = new DL.Invoice();

            DataSet ds = objdlInvoice.BulkInvoiceGenerate(locationAutoId, invoiceDate, startDate, endDate, invoiceType, tax, remarks, authorizedStatus, freshStatus, reversalStatus, postdate, modifiedBy, saleOrderTable, deleteStatus);
            return ds;
        }

        /// <summary>
        /// To generate the Invoice output in table InvoiceOutputDateWise
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="dtSoNo">The dt so no.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>DataSet.</returns>
        public DataSet BulkInvOutputGeneration(string locationAutoId, DataTable dtSoNo, string startDate, string endDate)
        {
            DL.Invoice objdlInvoice = new DL.Invoice();
            DataSet ds = objdlInvoice.BulkInvOutputGeneration(locationAutoId, dtSoNo, startDate, endDate);
            return ds;
        }
        #endregion

        /// <summary>
        /// Sales the order history details get.
        /// </summary>
        /// <param name="periodFrom">The period from.</param>
        /// <param name="periodTo">The period to.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderHistoryDetailsGet(DateTime periodFrom, DateTime periodTo, string clientCode, string soNo, int soLineNo, string locationAutoId)
        {
            DL.Invoice objdlInvoiceDetails = new DL.Invoice();

            DataSet ds = objdlInvoiceDetails.SaleOrderHistoryDetailsGet(periodFrom, periodTo, clientCode, soNo, soLineNo, locationAutoId);
            return ds;
        }

        /// <summary>
        /// Calls DL CallSaudiInvoiceSP function
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet CallSaudiInvoiceSP(string locationAutoID, string fromDate, string toDate)
        {
            DL.Invoice objSaudiInvoice = new DL.Invoice();
            DataSet ds = objSaudiInvoice.CallSaudiInvoiceSP(locationAutoID, fromDate, toDate);
            return ds;

        }


        #endregion

        #region Function Related to Bulk Invoicing Authorization
        /// <summary>
        /// Invoices2s the authorized get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="postFromDate">The post from date.</param>
        /// <param name="postToDate">The post to date.</param>
        /// <param name="freshStatus">The fresh status.</param>
        /// <returns>DataSet.</returns>
        public DataSet Invoices2AuthorizedGet(string locationAutoId, string clientCode, string invoiceType, string postFromDate, string postToDate, string freshStatus)
        {
            DL.Invoice ObjInv = new DL.Invoice();

            DataSet ds = ObjInv.Invoices2AuthorizedGet(locationAutoId, clientCode, invoiceType, postFromDate, postToDate, freshStatus);
            return ds;
        }

        #endregion
    }
}
