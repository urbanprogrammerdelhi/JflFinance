// ***********************************************************************
// Assembly         : DL
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
using System.Data.SqlClient;
using System.Transactions;
using System.Globalization;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class Invoice.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Invoice
    {
        #region Function Related to Invoice Generation

        #region Function Related to Invoice Header

        #region Function Related to Invoice Generation Screen Fetching Sales Order for Client
        /// <summary>
        /// Orders the information get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet OrderInformationGet(string locationAutoId, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_SO_Get4LocClient", objParm);
            return ds;
        }
        #endregion


        #region Get Function
        /// <summary>
        /// Invoices the header get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceHeaderGet(string locationAutoId, string invoiceNo)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_HeaderDetails_Get", objParm);
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
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.StatusReversal, statusReversal);
            objParm[6] = new SqlParameter(DL.Properties.Resources.StatusDeleted, statusDelete);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_CheckPeriod", objParm);
            return ds;
        }
        #endregion

        #region Insert Function
        /// <summary>
        /// Invoices the header insert.
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
        /// <param name="dataTableSoDetails">The data table so details.</param>
        /// <param name="dataTableSoItemDetails">The data table so item details.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="postingDate">The posting date.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dataTableSoItemDetails
        /// or
        /// dataTableSoDetails</exception>
        public DataSet InvoiceHeaderInsert(string locationAutoId, string invoiceNo, DateTime invoiceDate, string status, string invoiceType, string clientCode, string clientName, string soNo, string billingId, string billingAddress, DateTime periodFrom, DateTime periodTo, string remarks, decimal subtotal, decimal tax, decimal grandTotal, DataTable dataTableSoDetails, DataTable dataTableSoItemDetails, string modifiedBy, string mode, DateTime postingDate)
        {


            if (dataTableSoItemDetails == null || dataTableSoItemDetails.Rows == null)
            {
                throw new ArgumentNullException("dataTableSoItemDetails");
            }

            if (dataTableSoDetails == null || dataTableSoDetails.Rows == null)
            {
                throw new ArgumentNullException("dataTableSoDetails");
            }


            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            DataSet dsSODetailsInsert = new DataSet();
            DataSet dsSOItemDetailsInsert = new DataSet();
            dsSODetailsInsert.Locale = CultureInfo.InvariantCulture;
            dsSOItemDetailsInsert.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParm = new SqlParameter[19];
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
                objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
                objParm[2] = new SqlParameter(DL.Properties.Resources.InvoiceDate, DL.Common.DateFormat(invoiceDate));
                objParm[3] = new SqlParameter(DL.Properties.Resources.Status, status);
                objParm[4] = new SqlParameter(DL.Properties.Resources.InvoiceType, invoiceType);
                objParm[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
                objParm[6] = new SqlParameter(DL.Properties.Resources.ClientName, clientName);
                objParm[7] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
                objParm[8] = new SqlParameter(DL.Properties.Resources.BillingId, billingId);
                objParm[9] = new SqlParameter(DL.Properties.Resources.BillingAddress, billingAddress);
                objParm[10] = new SqlParameter(DL.Properties.Resources.PeriodFrom, DL.Common.DateFormat(periodFrom));
                objParm[11] = new SqlParameter(DL.Properties.Resources.PeriodTo, DL.Common.DateFormat(periodTo));
                objParm[12] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
                objParm[13] = new SqlParameter(DL.Properties.Resources.SubTotal, subtotal);
                objParm[14] = new SqlParameter(DL.Properties.Resources.Tax, tax);
                objParm[15] = new SqlParameter(DL.Properties.Resources.GrandTotal, grandTotal);
                objParm[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                objParm[17] = new SqlParameter(DL.Properties.Resources.Mode, mode);
                objParm[18] = new SqlParameter(DL.Properties.Resources.PostingDate, DL.Common.DateFormat(postingDate));
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoiceDetails_Save", objParm);
                if (ds != null && ds.Tables.Count == 2 && ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {

                    Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString(), "myIntArgument");

                    if (int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 0 || int.Parse(ds.Tables[0].Rows[0][DL.Properties.Resources.fldMessageId].ToString()) == 2)
                    {
                        invoiceNo = ds.Tables[1].Rows[0][DL.Properties.Resources.fldInvoiceNo].ToString();
                        if (dataTableSoDetails.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataTableSoDetails.Rows.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldSoNo].ToString()))
                                {
                                    Guard.ArgumentConvertibleTo<Int32>(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldNoOfPost].ToString(), "myInt32Argument");
                                    Guard.ArgumentConvertibleTo<decimal>(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldHours].ToString(), "myDecimalArgument");

                                    SqlParameter[] objInvDetails = new SqlParameter[21];

                                    objInvDetails[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldLocationAutoId].ToString());
                                    objInvDetails[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
                                    objInvDetails[2] = new SqlParameter(DL.Properties.Resources.SONO, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldSoNo].ToString());
                                    objInvDetails[3] = new SqlParameter(DL.Properties.Resources.SOAmendNo, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldSoAmendNo].ToString());
                                    objInvDetails[4] = new SqlParameter(DL.Properties.Resources.SoLineNo, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldSoLineNo].ToString());
                                    objInvDetails[5] = new SqlParameter(DL.Properties.Resources.AsmtId, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldAsmtId].ToString());
                                    objInvDetails[6] = new SqlParameter(DL.Properties.Resources.BillingDesignation, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldBillingDesignation].ToString());
                                    objInvDetails[7] = new SqlParameter(DL.Properties.Resources.NoOfPost, Int32.Parse(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldNoOfPost].ToString()));
                                    objInvDetails[8] = new SqlParameter(DL.Properties.Resources.Hours, decimal.Parse(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldHours].ToString()));
                                    objInvDetails[9] = new SqlParameter(DL.Properties.Resources.SOLineStartDate, DL.Common.DateFormat(DateTime.Parse(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldSoLineStartDate].ToString())));
                                    objInvDetails[10] = new SqlParameter(DL.Properties.Resources.SOLineEndDate, DL.Common.DateFormat(DateTime.Parse(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldSoLineEndDate].ToString())));
                                    objInvDetails[11] = new SqlParameter(DL.Properties.Resources.RatePerHour, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldRatePerHour].ToString());
                                    if (invoiceType == "FIXED" || invoiceType == "ACTUAL DAYS IN MONTH")
                                    {
                                        Guard.ArgumentConvertibleTo<decimal>(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldDaysInMonth].ToString(), "myDecimalArgument");
                                        Guard.ArgumentConvertibleTo<decimal>(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldHoursInMonth].ToString(), "myDecimalArgument");

                                        objInvDetails[12] = new SqlParameter(DL.Properties.Resources.SellingPrice, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldSellingPrice].ToString());
                                        objInvDetails[13] = new SqlParameter(DL.Properties.Resources.DaysInMonth, decimal.Parse(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldDaysInMonth].ToString()));
                                        objInvDetails[14] = new SqlParameter(DL.Properties.Resources.HoursInMonth, decimal.Parse(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldHoursInMonth].ToString()));
                                        objInvDetails[15] = new SqlParameter(DL.Properties.Resources.OtherAllowances, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldOtherAllowances].ToString());
                                        objInvDetails[16] = new SqlParameter(DL.Properties.Resources.MonthlyBilling, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldMonthlyBilling].ToString());
                                    }
                                    else
                                    {
                                        Guard.ArgumentConvertibleTo<decimal>(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldActualDaysInMonth].ToString(), "myDecimalArgument");
                                        Guard.ArgumentConvertibleTo<decimal>(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldActualHoursInMonth].ToString(), "myDecimalArgument");

                                        objInvDetails[12] = new SqlParameter(DL.Properties.Resources.SellingPrice, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldChargeRatePerHour].ToString());
                                        objInvDetails[13] = new SqlParameter(DL.Properties.Resources.DaysInMonth, decimal.Parse(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldActualDaysInMonth].ToString()));
                                        objInvDetails[14] = new SqlParameter(DL.Properties.Resources.HoursInMonth, decimal.Parse(dataTableSoDetails.Rows[i][DL.Properties.Resources.fldActualHoursInMonth].ToString()));
                                        objInvDetails[15] = new SqlParameter(DL.Properties.Resources.OtherAllowances, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldOtherAllowances].ToString());
                                        objInvDetails[16] = new SqlParameter(DL.Properties.Resources.MonthlyBilling, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldActualMonthlyBilling].ToString());
                                    }
                                    objInvDetails[17] = new SqlParameter(DL.Properties.Resources.Remarks, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldRemarks].ToString());
                                    objInvDetails[18] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy.ToString());
                                    objInvDetails[19] = new SqlParameter(DL.Properties.Resources.Mode, mode);
                                    objInvDetails[20] = new SqlParameter(DL.Properties.Resources.DutyTypeCode, dataTableSoDetails.Rows[i][DL.Properties.Resources.fldDutyTypeCode].ToString());

                                    dsSODetailsInsert = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_SODetails_Save", objInvDetails);
                                }
                            }
                        }
                        if (dataTableSoItemDetails.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataTableSoItemDetails.Rows.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldSoNo].ToString()))
                                {
                                    Guard.ArgumentConvertibleTo<decimal>(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldQty].ToString(), "myDecimalArgument");
                                    Guard.ArgumentConvertibleTo<decimal>(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldRate].ToString(), "myDecimalArgument");
                                    Guard.ArgumentConvertibleTo<decimal>(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldMonthlyBilling].ToString(), "myDecimalArgument");
                                    Guard.ArgumentConvertibleTo<Int32>(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldstrLocationAutoID].ToString(), "myInt32Argument");

                                    SqlParameter[] objInvItemDetails = new SqlParameter[13];

                                    objInvItemDetails[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
                                    objInvItemDetails[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
                                    objInvItemDetails[2] = new SqlParameter(DL.Properties.Resources.SONO, dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldSoNo].ToString());
                                    objInvItemDetails[3] = new SqlParameter(DL.Properties.Resources.SOAmendNo, dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldSoAmendNo].ToString());
                                    objInvItemDetails[4] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldItemTypeCode].ToString());
                                    objInvItemDetails[5] = new SqlParameter(DL.Properties.Resources.Qty, decimal.Parse(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldQty].ToString()));
                                    objInvItemDetails[6] = new SqlParameter(DL.Properties.Resources.Rate, decimal.Parse(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldRate].ToString()));
                                    objInvItemDetails[7] = new SqlParameter(DL.Properties.Resources.MonthlyBilling, decimal.Parse(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldMonthlyBilling].ToString()));
                                    objInvItemDetails[8] = new SqlParameter(DL.Properties.Resources.ItemStartDate, DL.Common.DateFormat(DateTime.Parse(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldItemStartDate].ToString())));
                                    objInvItemDetails[9] = new SqlParameter(DL.Properties.Resources.ItemEndDate, DL.Common.DateFormat(DateTime.Parse(dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldItemEndDate].ToString())));
                                    objInvItemDetails[10] = new SqlParameter(DL.Properties.Resources.Remarks, dataTableSoItemDetails.Rows[i][DL.Properties.Resources.fldRemarks].ToString());
                                    objInvItemDetails[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                                    objInvItemDetails[12] = new SqlParameter(DL.Properties.Resources.Mode, mode);
                                    dsSOItemDetailsInsert = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_SOItemDetails_Save", objInvItemDetails);
                                }
                            }
                        }
                    }
                }
                tx.Complete();
            }
            return ds;
        }
        #endregion

        #region Update Function
        /// <summary>
        /// Invoices the header update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="invoiceDate">The invoice date.</param>
        /// <param name="remarks">The remarks.</param>
        /// <param name="subtotal">The subtotal.</param>
        /// <param name="tax">The tax.</param>
        /// <param name="grandTotal">The grand total.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="dataTablePostingDate">The data table posting date.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceHeaderUpdate(string locationAutoId, string invoiceNo, string invoiceDate, string remarks, decimal subtotal, decimal tax, decimal grandTotal, string modifiedBy, DateTime dataTablePostingDate)
        {
            SqlParameter[] objParm = new SqlParameter[9];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.InvoiceDate, DL.Common.DateFormat(invoiceDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParm[4] = new SqlParameter(DL.Properties.Resources.SubTotal, subtotal);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Tax, tax);
            objParm[6] = new SqlParameter(DL.Properties.Resources.GrandTotal, grandTotal);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[8] = new SqlParameter(DL.Properties.Resources.PostingDate, DL.Common.DateFormat(dataTablePostingDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoiceDetails_Update", objParm);

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
            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StatusAuthorized, statusAuthorized);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_Authorized", objParm);

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
        /// <param name="reversalReason">The reversal reason.</param>
        /// <param name="reversalDate">The reversal date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="invoiceDate">The invoice date.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceReversal(string locationAutoId, string invoiceNo, string statusReversal, string modifiedBy, string reversalReason, DateTime reversalDate, string clientCode, string soNo, DateTime fromDate, DateTime toDate, DateTime invoiceDate)
        {
            SqlParameter[] objParm = new SqlParameter[11];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StatusReversal, statusReversal);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ReversalReason, reversalReason);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ReversalDate, DL.Common.DateFormat(reversalDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParm[8] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[10] = new SqlParameter(DL.Properties.Resources.InvoiceDate, DL.Common.DateFormat(invoiceDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_Reversal", objParm);
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
            SqlParameter[] objParm = new SqlParameter[4];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StatusDeletion, statusDeleted);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_Deletion", objParm);

            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Invoice Services Details
        #region Get Function
        /// <summary>
        /// Sales the order details get.
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
            SqlParameter[] objParm = new SqlParameter[6];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(startDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(endDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.InvoiceType, invoiceType);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AuthorizedStatus, authorizedStatus);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODetails4Inv_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Invoices the details get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceDetailsGet(string locationAutoId, string invoiceNo)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_Details_Get", objParm);
            return ds;
        }
        #endregion

        #region Update Function
        /// <summary>
        /// Invoices the details update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="billingDesignation">The billing designation.</param>
        /// <param name="numberOfPosts">The number of posts.</param>
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
        public DataSet InvoiceDetailsUpdate(string locationAutoId, string invoiceNo, string soNo, string soAmendNo, string soLineNo, string billingDesignation, string numberOfPosts, string hours, string daysInMonth, string hoursInMonth, string soLineStartDate, string soLineEndDate, string otherAllowances, string sellingPrice, string monthlyBilling, string remarks, string modifiedBy, int rowNumber)
        {
            SqlParameter[] objParm = new SqlParameter[18];

            Guard.ArgumentConvertibleTo<decimal>(hours, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(daysInMonth, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(hoursInMonth, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(otherAllowances, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(sellingPrice, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(monthlyBilling, "myDecimalArgument");

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.BillingDesignation, billingDesignation);
            objParm[6] = new SqlParameter(DL.Properties.Resources.NoOfPost, numberOfPosts);
            objParm[7] = new SqlParameter(DL.Properties.Resources.Hours, decimal.Parse(hours));
            objParm[8] = new SqlParameter(DL.Properties.Resources.DaysInMonth, decimal.Parse(daysInMonth));
            objParm[9] = new SqlParameter(DL.Properties.Resources.HoursInMonth, decimal.Parse(hoursInMonth));
            objParm[10] = new SqlParameter(DL.Properties.Resources.SOLineStartDate, DL.Common.DateFormat(soLineStartDate));
            objParm[11] = new SqlParameter(DL.Properties.Resources.SOLineEndDate, DL.Common.DateFormat(soLineEndDate));
            objParm[12] = new SqlParameter(DL.Properties.Resources.OtherAllowances, decimal.Parse(otherAllowances));
            objParm[13] = new SqlParameter(DL.Properties.Resources.SellingPrice, decimal.Parse(sellingPrice));
            objParm[14] = new SqlParameter(DL.Properties.Resources.MonthlyBilling, decimal.Parse(monthlyBilling));
            objParm[15] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParm[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[17] = new SqlParameter(DL.Properties.Resources.RowNumber, rowNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_Details_Update", objParm);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to Invoice Item Details
        #region Get Function
        /// <summary>
        /// Sales the order item details get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="authorizedStatus">The authorized status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDetailsGet(string locationAutoId, string soNo, string startDate, string endDate, string authorizedStatus)
        {
            SqlParameter[] objParm = new SqlParameter[5];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(startDate));
            objParm[3] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(endDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.AuthorizedStatus, authorizedStatus);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOItemDetails4Inv_Get", objParm);
            return ds;
        }


        /// <summary>
        /// Invoices the item details get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="invoiceNo">The invoice no.</param>
        /// <returns>DataSet.</returns>
        public DataSet InvoiceItemDetailsGet(string locationAutoId, string invoiceNo)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_ItemDetails_Get", objParm);
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
            SqlParameter[] objParm = new SqlParameter[12];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.InvoiceNo, invoiceNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.Qty, quantity);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Rate, rate);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ItemStartDate, DL.Common.DateFormat(itemStartDate));
            objParm[8] = new SqlParameter(DL.Properties.Resources.ItemEndDate, DL.Common.DateFormat(itemEndDate));
            objParm[9] = new SqlParameter(DL.Properties.Resources.SOItemRemarks, soItemRemarks);
            objParm[10] = new SqlParameter(DL.Properties.Resources.MonthlyBill, monthlyBill);
            objParm[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoice_ItemDetails_Update", objParm);
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
        public DataSet SoNoGet(string locationAutoId, string clientCode, string soType, string billingPattern, string startDate, string endDate, string freshStatus, String reversalStatus, string deleteStatus)
        {
            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SOType, soType);
            objParm[3] = new SqlParameter(DL.Properties.Resources.BillingPattern, billingPattern);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FreshStatus, freshStatus);
            objParm[5] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(startDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(endDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.ReversalStatus, reversalStatus);
            objParm[8] = new SqlParameter(DL.Properties.Resources.DeleteStatus, deleteStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_BulkInvCodeSONo_Get", objParm);
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
        /// <param name="dataTableSoNo">The data table so no.</param>
        /// <param name="deleteStatus">The delete status.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dataTableSoNo</exception>
        public DataSet BulkInvoiceGenerate(string locationAutoId, string invoiceDate, string startDate, string endDate, string invoiceType, string tax, string remarks, string authorizedStatus, string freshStatus, string reversalStatus, string postdate, string modifiedBy, DataTable dataTableSoNo, string deleteStatus)
        {
            if (dataTableSoNo == null || dataTableSoNo.Rows == null)
            {
                throw new ArgumentNullException("dataTableSoNo");
            }

            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.InvariantCulture;

            SqlParameter[] objParm = new SqlParameter[8];
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_BulkInvCode_Get", objParm);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
                {
                    string strBulkInvoiceCode = ds.Tables[0].Rows[0]["BulkInvoiceCode"].ToString();
                    SqlParameter[] objParmInv = new SqlParameter[13];

                    for (int i = 0; i < dataTableSoNo.Rows.Count; i++)
                    {
                        Guard.ArgumentConvertibleTo<decimal>(tax, "myDecimalArgument");

                        objParmInv = new SqlParameter[15];
                        objParmInv[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
                        objParmInv[1] = new SqlParameter(DL.Properties.Resources.SONO, dataTableSoNo.Rows[i][DL.Properties.Resources.fldSoNo].ToString());
                        objParmInv[2] = new SqlParameter(DL.Properties.Resources.InvoiceDate, DL.Common.DateFormat(invoiceDate));
                        objParmInv[3] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(startDate));
                        objParmInv[4] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(endDate));
                        objParmInv[5] = new SqlParameter(DL.Properties.Resources.InvoiceType, invoiceType);
                        objParmInv[6] = new SqlParameter(DL.Properties.Resources.Tax, decimal.Parse(tax));
                        objParmInv[7] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
                        objParmInv[8] = new SqlParameter(DL.Properties.Resources.AuthorizedStatus, authorizedStatus);
                        objParmInv[9] = new SqlParameter(DL.Properties.Resources.FreshStatus, freshStatus);
                        objParmInv[10] = new SqlParameter(DL.Properties.Resources.ReversalStatus, reversalStatus);
                        objParmInv[11] = new SqlParameter(DL.Properties.Resources.DeleteStatus, deleteStatus);
                        objParmInv[12] = new SqlParameter(DL.Properties.Resources.BulkInvoiceCode, strBulkInvoiceCode);
                        objParmInv[13] = new SqlParameter(DL.Properties.Resources.PostingDate, DL.Common.DateFormat(postdate));
                        objParmInv[14] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

                        dsResult = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODetails4BulkInv_Get", objParmInv);
                    }
                    SqlParameter[] objPrm = new SqlParameter[1];
                    objPrm[0] = new SqlParameter(DL.Properties.Resources.BulkInvoiceCode, strBulkInvoiceCode);

                    dsResult = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_BulkInvDetails_Get", objPrm);

                    tx.Complete();
                }
            }
            return dsResult;

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
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[4];
            for (int i = 0; i < dtSoNo.Rows.Count; i++)
            {
                objParm = new SqlParameter[4];
                objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
                objParm[1] = new SqlParameter(DL.Properties.Resources.SONO, dtSoNo.Rows[i][DL.Properties.Resources.fldSoNo].ToString());
                objParm[2] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(startDate));
                objParm[3] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(endDate));
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSaleDetBulkInvOutput", objParm);
            }
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
            SqlParameter[] objParm = new SqlParameter[6];

            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(periodFrom));
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(periodTo));
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SoNoParam, soNo);
            objParm[4] = new SqlParameter(DL.Properties.Resources.SoLineNoParam, soLineNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updInvoiceDetails_for_soline", objParm);
            return ds;
        }

        /// <summary>
        /// Calls updSaudiInvoiceSP
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet CallSaudiInvoiceSP(string locationAutoId, string fromDate, string toDate)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, fromDate);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ToDate, toDate);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updSaudiInvoiceSP", objParm);
            return ds;
        }

        #endregion

        #region Function Related to Bulk Authorization of Invoices
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
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.InvoiceType, invoiceType);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostDateFrom, DL.Common.DateFormat(postFromDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.PostDateTo, DL.Common.DateFormat(postToDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.FreshStatus, freshStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstInvoices2Authorized_Get", objParm);
            return ds;

        }
        #endregion

    }
}
