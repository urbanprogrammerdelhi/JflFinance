// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Sales.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using DL;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;



/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class Sales.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Sales
    {

        #region Function Related To Clients

        #region Get All Client Master
        /*Code modified by   on 31-Aug-2011*/
        /// <summary>
        /// Get Client List by Area
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMasterGetAll(int locationAutoId, string areaId, string areaIncharge, string isIncharge, string fromDate, string toDate)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParam[3] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isIncharge);
            objParam[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetAll", objParam);
            return ds;
        }
        /*End of Code modified by   on 31-Aug-2011*/
        /// <summary>
        /// To Check if the manual client code already exists in database
        /// </summary>
        /// <param name="manualClientCode">The manual client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckClientCodeAvailability(string manualClientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ManualClientCode, manualClientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_CheckManualNumberAvailability", objParm);
            return ds;
        }
        /// <summary>
        /// Checks the client name availability.
        /// </summary>
        /// <param name="clientName">Name of the client.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckClientNameAvailability(string clientName)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientName, clientName);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_CheckClientNameAvailability", objParm);
            return ds;
        }
        /// <summary>
        /// To get all the details based on Client Code
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailGet(string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetDetailBasedOnClientCode", objParm);
            return ds;
        }

        /// <summary>
        /// Sales the order item rate get.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemRateGet(string soNo, string locationAutoId, string asmtId, string soAmendNo, string itemTypeCode)
        {
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_SaleOrderItemDetail_GetItemRate", objParam);
            return ds;
        }

        /// <summary>
        /// Sales the order item deployment pattern get all.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDeploymentPatternGetAll(string locationAutoId, string soNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOItemDepPattren_GetALL", objParam);
            return ds;
        }

        /// <summary>
        /// To get ClientCode  manual ClientCode and Name of the client
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientNameGet(string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetByCode", objParm);
            return ds;
        }

        /// <summary>
        /// Sales the order item days in month update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="daysInMonth">The days in month.</param>
        /// <param name="totalRate">The total rate.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDaysInMonthUpdate(string locationAutoId, string soNo, string soAmendNo, string asmtId, string itemTypeCode, string daysInMonth, string totalRate, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.DaysInMonth, daysInMonth);
            objParam[6] = new SqlParameter(DL.Properties.Resources.TotalRate, totalRate);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SaleOrderItemDetail_UpdatedaysInMonth", objParam);
            return ds;
        }

        /// <summary>
        /// Sales the order item deployment pattern get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDeploymentPatternGet(string locationAutoId, string soNo, string soAmendNo, string asmtId, string itemTypeCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOItemDepPattren_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Sales the order item deployment pattern update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="dtSOItemDeptPattern">The dt so item dept pattern.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dtSOItemDeptPattern</exception>
        public DataSet SaleOrderItemDeploymentPatternUpdate(string locationAutoId, string soNo, string soAmendNo, string asmtId, DataTable dtSOItemDeptPattern, string itemTypeCode, string modifiedBy)
        {
            if (dtSOItemDeptPattern == null || dtSOItemDeptPattern.Rows == null)
            {
                throw new ArgumentNullException("dtSOItemDeptPattern");
            }
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                foreach (DataRow dr in dtSOItemDeptPattern.Rows)
                {
                    SqlParameter[] objParam = new SqlParameter[14];
                    Guard.ArgumentConvertibleTo<Int64>(locationAutoId, "myInt64Argument");
                    Guard.ArgumentConvertibleTo<int>(soAmendNo, "myIntArgument");
                    Guard.ArgumentConvertibleTo<int>(dr[0].ToString(), "myIntArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[1].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[2].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[3].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[4].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[5].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[6].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[7].ToString(), "myBoolArgument");

                    objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int64.Parse(locationAutoId));
                    objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
                    objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, int.Parse(soAmendNo));
                    objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
                    objParam[4] = new SqlParameter(DL.Properties.Resources.WeekNo, int.Parse(dr[0].ToString()));
                    objParam[5] = new SqlParameter(DL.Properties.Resources.SUN, bool.Parse(dr[1].ToString()));
                    objParam[6] = new SqlParameter(DL.Properties.Resources.MON, bool.Parse(dr[2].ToString()));
                    objParam[7] = new SqlParameter(DL.Properties.Resources.TUE, bool.Parse(dr[3].ToString()));
                    objParam[8] = new SqlParameter(DL.Properties.Resources.WED, bool.Parse(dr[4].ToString()));
                    objParam[9] = new SqlParameter(DL.Properties.Resources.THU, bool.Parse(dr[5].ToString()));
                    objParam[10] = new SqlParameter(DL.Properties.Resources.FRI, bool.Parse(dr[6].ToString()));
                    objParam[11] = new SqlParameter(DL.Properties.Resources.SAT, bool.Parse(dr[7].ToString()));

                    objParam[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
                    objParam[13] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);

                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOItemDeploymentPattern_Update", objParam);
                }
                tx.Complete();
            }
            return ds;
        }


        /// <summary>
        /// Clientses the company wise get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsCompanyWiseGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_CompClient_GetAll", objParm);
            return ds;
        }
        /// <summary>
        /// Clients the get.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientGet(string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Client_GetById", objParm);
            return ds;
        }
        /// <summary>
        /// Contracts the details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractDetailsGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_rptContract_ContractDetailsQubic", objParm);
            return ds;
        }
        /// <summary>
        /// to get ClientCode client name and ClientCode(ClientName) for a Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsLocationWiseGet(string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_Get", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Location And Client Wise Sale Orders
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SOClientWiseGet(string locationAutoId, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SOClientWiseGet", objParm);
            return ds;
        }
        /// <summary>
        /// Clients the get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientGet(string locationAutoId, string userId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetBasedOnClientCode", objParm);
            return ds;
        }
        /// <summary>
        /// Clients the details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_rptClient_ClientDetails", objParm);
            return ds;
        }
        /// <summary>
        /// Clients the location wise get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="divisionCode">The division code.</param>
        /// <param name="branchCode">The branch code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientLocationWiseGet(string companyCode, string divisionCode, string branchCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.DivisionCode, divisionCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.BranchCode, branchCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetBasedOnLocationCode", objParm);
            return ds;
        }

        /// <summary>
        /// To Get AsmtId and ClientCode based on LocationAutoID[SalesOPSTermination Screen]
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientCodeAndAsmtIdGet(string clientCode, string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSales_SaleOPSTermination_GetAsmtIDAndClientCode", objParm);
            return ds;
        }

        /// <summary>
        /// To Get PostCode AsmtId and ClientCode based on LocationAutoID[SalesOPSTermination Screen]
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientCodeAsmtIdPostcodeGet(string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSales_SaleOPSTermination_GetPostCodeAsmtIDClientCode", objParm);
            return ds;
        }

        /// <summary>
        /// Clients the area wise get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="AreaIncharge">The area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientAreaWiseGet(string locationAutoId, string AreaIncharge, string areaId)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaIncharge, AreaIncharge);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetByInchargeAreaId", objParm);
            return ds;
        }

        /// <summary>
        /// To get ClientCode, ClientName, Client ManualCode
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>To get ClientCode, ClientName, Client ManualCode</returns>
        public DataSet ClientAreaWiseGet(string locationAutoId, string areaId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetByAreaId", objParm);
            return ds;
        }
        /// <summary>
        /// Get Clients Based on Logged in Area Incharge
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="locationCode">The location code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientAreaInchargeWiseGet(string locationAutoId, string areaId, string areaIncharge, string isAreaIncharge, string locationCode, string fromDate, string toDate)
        {

            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[3] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[4] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetByAreaId_AreaIncharge", objParm);
            return ds;
        }
        /// <summary>
        /// to get ClientCode, ClientName and ClientCode(ClientName) for The Given parameters
        /// the HrLocationCode and the LocationCode can be pass as blank "" or ALL.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientHRLocationWiseGet(string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientOfCompHRLoc_Get", objParm);
            return ds;
        }
        /// <summary>
        /// To Get SoNo based on Client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soStatus">The so status.</param>
        /// <param name="isBillable">The is billable.</param>
        /// <param name="billingPattern">The billing pattern.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientSaleOrderGet(string locationAutoId, string clientCode, string soStatus, string isBillable, string billingPattern)
        {
            SqlParameter[] objParm = new SqlParameter[5];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            objParm[3] = new SqlParameter(DL.Properties.Resources.IsBillable, isBillable);
            objParm[4] = new SqlParameter(DL.Properties.Resources.BillingPattern, billingPattern);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSaleOrderNoGet", objParm);
            return ds;

        }

        /// <summary>
        /// to get clientCode client name and clientCode(clientName) for a Location on Status Basis
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="status">The status.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsLocationStatusWiseGet(string locationAutoId, string month, string year, string status, string areaIncharge, string isAreaIncharge, string areaId, string fromDate, string toDate)
        {
            SqlParameter[] objParm = new SqlParameter[9];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Month, int.Parse(month));
            objParm[2] = new SqlParameter(DL.Properties.Resources.Year, int.Parse(year));
            objParm[3] = new SqlParameter(DL.Properties.Resources.Status, status);

            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[8] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_GetByStatus", objParm);
            return ds;
        }
        #endregion

        #region Function related to clientMaster Page

        #region get data
        /// <summary>
        /// To the Client Name by ClientCode
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientNameDetailGet(string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientName_Get", objParm);
            return ds;
        }


        /// <summary>
        /// Enables to get if the Client Code would be allowed to be Manually Created or Not
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="autoGenerateCode">The automatic generate code.</param>
        /// <returns>DataTable.</returns>
        public DataTable SetAutoGenerateCodeForClient(string companyCode, string autoGenerateCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AutoGenerateCode, autoGenerateCode);

            DataTable dt = SqlHelper.ExecuteDatatable("udpAutoGenerateCodeForClients", objParam);
            return dt;
        }

        #endregion

        #region Insert Client

        /// <summary>
        /// To insert Auto Generate new client code
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="manualClientCode">The manual client code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="addressLine1">The address line1.</param>
        /// <param name="addressLine2">The address line2.</param>
        /// <param name="addressLine3">The address line3.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="countryOrigin">The country origin.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="website">The website.</param>
        /// <param name="email">The email.</param>
        /// <param name="clientContactPerson">The client contact person.</param>
        /// <param name="clientContactPersonDesignation">The client contact person designation.</param>
        /// <param name="clientContactPersonMobile">The client contact person mobile.</param>
        /// <param name="ourContactPerson">Our contact person.</param>
        /// <param name="ourContactPersonEmployeeNo">Our contact person employee no.</param>
        /// <param name="ourContactPersonMobile">Our contact person mobile.</param>
        /// <param name="turnover">The turnover.</param>
        /// <param name="industryType">Type of the industry.</param>
        /// <param name="classification">The classification.</param>
        /// <param name="customerType">Type of the customer.</param>
        /// <param name="isInternational">The is international.</param>
        /// <param name="sector">The sector.</param>
        /// <param name="subsegment">The subsegment.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="otherLanguageClientName">Name of the other language client.</param>
        /// <param name="otherLanguageAdd1">The other language add1.</param>
        /// <param name="otherLanguageAdd2">The other language add2.</param>
        /// <param name="otherLanguageAdd3">The other language add3.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMasterInsert(string companyCode, string locationAutoId, string manualClientCode,
                                             string clientName, string addressLine1, string addressLine2,
                                             string addressLine3, string city, string state, string pin,
                                             string countryCode, string countryOrigin, string phone,
                                             string fax, string website, string email, string contactPersonEmail,
                                             string clientContactPerson, string clientContactPersonDesignation,
                                             string clientContactPersonMobile, string ourContactPerson,
                                             string ourContactPersonEmployeeNo, string ourContactPersonMobile,
                                             float turnover, string industryType, string classification,
                                             string customerType, string isInternational, string sector,
                                             string subsegment, string comments, string modifiedBy,
                                             string otherLanguageClientName, string otherLanguageAdd1,
                                             string otherLanguageAdd2, string otherLanguageAdd3)
        {
            SqlParameter[] objParm = new SqlParameter[36];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ManualClientCode, manualClientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientName, clientName);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AddressLine1, addressLine1);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AddressLine2, addressLine2);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AddressLine3, addressLine3);
            objParm[5] = new SqlParameter(DL.Properties.Resources.City, city);
            objParm[6] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[7] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParm[8] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[9] = new SqlParameter(DL.Properties.Resources.CountryOrigin, countryOrigin);
            objParm[10] = new SqlParameter(DL.Properties.Resources.Phone, phone);
            objParm[11] = new SqlParameter(DL.Properties.Resources.Fax, fax);
            objParm[12] = new SqlParameter(DL.Properties.Resources.WebSite, website);
            objParm[13] = new SqlParameter(DL.Properties.Resources.Email, email);
            objParm[14] = new SqlParameter(DL.Properties.Resources.ContactPersonEmail, contactPersonEmail);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ClientContactPerson, clientContactPerson);
            objParm[16] = new SqlParameter(DL.Properties.Resources.ClientContactPersonDesignation, clientContactPersonDesignation);
            objParm[17] = new SqlParameter(DL.Properties.Resources.ClientContactPersonMobile, clientContactPersonMobile);
            objParm[18] = new SqlParameter(DL.Properties.Resources.OurContactPerson, ourContactPerson);
            objParm[19] = new SqlParameter(DL.Properties.Resources.OurContactPersonEmpNo, ourContactPersonEmployeeNo);
            objParm[20] = new SqlParameter(DL.Properties.Resources.OurContactPersonMobile, ourContactPersonMobile);
            objParm[21] = new SqlParameter(DL.Properties.Resources.Turnover, turnover);
            objParm[22] = new SqlParameter(DL.Properties.Resources.IndustryType, industryType);
            objParm[23] = new SqlParameter(DL.Properties.Resources.Classification, classification);
            objParm[24] = new SqlParameter(DL.Properties.Resources.CustomerType, customerType);
            objParm[25] = new SqlParameter(DL.Properties.Resources.IsInternational, isInternational);
            objParm[26] = new SqlParameter(DL.Properties.Resources.Sector, sector);
            objParm[27] = new SqlParameter(DL.Properties.Resources.SubSegment, subsegment);
            objParm[28] = new SqlParameter(DL.Properties.Resources.Comments, comments);
            objParm[29] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[30] = new SqlParameter(DL.Properties.Resources.OtherLanguageClientName, otherLanguageClientName);
            objParm[31] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd1, otherLanguageAdd1);
            objParm[32] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd2, otherLanguageAdd2);
            objParm[33] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd3, otherLanguageAdd3);
            objParm[34] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[35] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// To insert new client code Manually
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="manualClientCode">The manual client code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="addressLine1">The address line1.</param>
        /// <param name="addressLine2">The address line2.</param>
        /// <param name="addressLine3">The address line3.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="countryOrigin">The country origin.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="website">The website.</param>
        /// <param name="email">The email.</param>
        /// <param name="clientContactPerson">The client contact person.</param>
        /// <param name="clientContactPersonDesignation">The client contact person designation.</param>
        /// <param name="clientContactPersonMobile">The client contact person mobile.</param>
        /// <param name="ourContactPerson">Our contact person.</param>
        /// <param name="ourContactPersonEmployeeNo">Our contact person employee no.</param>
        /// <param name="ourContactPersonMobile">Our contact person mobile.</param>
        /// <param name="turnover">The turnover.</param>
        /// <param name="industryType">Type of the industry.</param>
        /// <param name="classification">The classification.</param>
        /// <param name="customerType">Type of the customer.</param>
        /// <param name="isInternational">The is international.</param>
        /// <param name="sector">The sector.</param>
        /// <param name="subsegment">The subsegment.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="otherLanguageClientName">Name of the other language client.</param>
        /// <param name="otherLanguageAdd1">The other language add1.</param>
        /// <param name="otherLanguageAdd2">The other language add2.</param>
        /// <param name="otherLanguageAdd3">The other language add3.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMasterManualInsert(string companyCode, string locationAutoId, string clientCode,
                                                   string manualClientCode, string clientName,
                                                   string addressLine1, string addressLine2,
                                                   string addressLine3, string city, string state,
                                                   string pin, string countryCode, string countryOrigin,
                                                   string phone, string fax, string website, string email,
                                                   string contactPersonEmail, string clientContactPerson,
                                                   string clientContactPersonDesignation,
                                                   string clientContactPersonMobile, string ourContactPerson,
                                                   string ourContactPersonEmployeeNo, string ourContactPersonMobile,
                                                   float turnover, string industryType, string classification,
                                                   string customerType, string isInternational, string sector,
                                                   string subsegment, string comments, string modifiedBy,
                                                   string otherLanguageClientName, string otherLanguageAdd1,
                                                   string otherLanguageAdd2, string otherLanguageAdd3)
        {
            SqlParameter[] objParm = new SqlParameter[37];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ManualClientCode, manualClientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientName, clientName);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AddressLine1, addressLine1);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AddressLine2, addressLine2);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AddressLine3, addressLine3);
            objParm[6] = new SqlParameter(DL.Properties.Resources.City, city);
            objParm[7] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[8] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParm[9] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[10] = new SqlParameter(DL.Properties.Resources.CountryOrigin, countryOrigin);
            objParm[11] = new SqlParameter(DL.Properties.Resources.Phone, phone);
            objParm[12] = new SqlParameter(DL.Properties.Resources.Fax, fax);
            objParm[13] = new SqlParameter(DL.Properties.Resources.WebSite, website);
            objParm[14] = new SqlParameter(DL.Properties.Resources.Email, email);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ContactPersonEmail, contactPersonEmail);
            objParm[16] = new SqlParameter(DL.Properties.Resources.ClientContactPerson, clientContactPerson);
            objParm[17] = new SqlParameter(DL.Properties.Resources.ClientContactPersonDesignation, clientContactPersonDesignation);
            objParm[18] = new SqlParameter(DL.Properties.Resources.ClientContactPersonMobile, clientContactPersonMobile);
            objParm[19] = new SqlParameter(DL.Properties.Resources.OurContactPerson, ourContactPerson);
            objParm[20] = new SqlParameter(DL.Properties.Resources.OurContactPersonEmpNo, ourContactPersonEmployeeNo);
            objParm[21] = new SqlParameter(DL.Properties.Resources.OurContactPersonMobile, ourContactPersonMobile);
            objParm[22] = new SqlParameter(DL.Properties.Resources.Turnover, turnover);
            objParm[23] = new SqlParameter(DL.Properties.Resources.IndustryType, industryType);
            objParm[24] = new SqlParameter(DL.Properties.Resources.Classification, classification);
            objParm[25] = new SqlParameter(DL.Properties.Resources.CustomerType, customerType);
            objParm[26] = new SqlParameter(DL.Properties.Resources.IsInternational, isInternational);
            objParm[27] = new SqlParameter(DL.Properties.Resources.Sector, sector);
            objParm[28] = new SqlParameter(DL.Properties.Resources.SubSegment, subsegment);
            objParm[29] = new SqlParameter(DL.Properties.Resources.Comments, comments);
            objParm[30] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[31] = new SqlParameter(DL.Properties.Resources.OtherLanguageClientName, otherLanguageClientName);
            objParm[32] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd1, otherLanguageAdd1);
            objParm[33] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd2, otherLanguageAdd2);
            objParm[34] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd3, otherLanguageAdd3);
            objParm[35] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[36] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstSaleClient_InsertManually", objParm);
            return ds;
        }

        #endregion


        #region Update Data
        /// <summary>
        /// To Update
        /// </summary>
        /// <param name="manualClientCode">The manual client code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="addressLine1">The address line1.</param>
        /// <param name="addressLine2">The address line2.</param>
        /// <param name="addressLine3">The address line3.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="countryOrigin">The country origin.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="website">The website.</param>
        /// <param name="email">The email.</param>
        /// <param name="clientContactPerson">The client contact person.</param>
        /// <param name="clientContactPersonDesignation">The client contact person designation.</param>
        /// <param name="clientContactPersonMobile">The client contact person mobile.</param>
        /// <param name="ourContactPerson">Our contact person.</param>
        /// <param name="ourContactPersonEmployeeNo">Our contact person employee no.</param>
        /// <param name="ourContactPersonMobile">Our contact person mobile.</param>
        /// <param name="turnover">The turnover.</param>
        /// <param name="industryType">Type of the industry.</param>
        /// <param name="classification">The classification.</param>
        /// <param name="customerType">Type of the customer.</param>
        /// <param name="isInternational">The is international.</param>
        /// <param name="sector">The sector.</param>
        /// <param name="subsegment">The subsegment.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMasterUpdate(string manualClientCode, string clientName, string addressLine1, string addressLine2, string addressLine3, string city, string state, string pin, string countryCode, string countryOrigin, string phone, string fax, string website, string email, string contactPersonEmail, string clientContactPerson, string clientContactPersonDesignation, string clientContactPersonMobile, string ourContactPerson, string ourContactPersonEmployeeNo, string ourContactPersonMobile, float turnover, string industryType, string classification, string customerType, string isInternational, string sector, string subsegment, string comments, string clientCode, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[31];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ManualClientCode, manualClientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientName, clientName);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AddressLine1, addressLine1);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AddressLine2, addressLine2);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AddressLine3, addressLine3);
            objParm[5] = new SqlParameter(DL.Properties.Resources.City, city);
            objParm[6] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[7] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParm[8] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[9] = new SqlParameter(DL.Properties.Resources.CountryOrigin, countryOrigin);
            objParm[10] = new SqlParameter(DL.Properties.Resources.Phone, phone);
            objParm[11] = new SqlParameter(DL.Properties.Resources.Fax, fax);
            objParm[12] = new SqlParameter(DL.Properties.Resources.WebSite, website);
            objParm[13] = new SqlParameter(DL.Properties.Resources.Email, email);
            objParm[14] = new SqlParameter(DL.Properties.Resources.ContactPersonEmail, contactPersonEmail);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ClientContactPerson, clientContactPerson);
            objParm[16] = new SqlParameter(DL.Properties.Resources.ClientContactPersonDesignation, clientContactPersonDesignation);
            objParm[17] = new SqlParameter(DL.Properties.Resources.ClientContactPersonMobile, clientContactPersonMobile);
            objParm[18] = new SqlParameter(DL.Properties.Resources.OurContactPerson, ourContactPerson);
            objParm[19] = new SqlParameter(DL.Properties.Resources.OurContactPersonEmpNo, ourContactPersonEmployeeNo);
            objParm[20] = new SqlParameter(DL.Properties.Resources.OurContactPersonMobile, ourContactPersonMobile);
            objParm[21] = new SqlParameter(DL.Properties.Resources.Turnover, turnover);
            objParm[22] = new SqlParameter(DL.Properties.Resources.IndustryType, industryType);
            objParm[23] = new SqlParameter(DL.Properties.Resources.Classification, classification);
            objParm[24] = new SqlParameter(DL.Properties.Resources.CustomerType, customerType);
            objParm[25] = new SqlParameter(DL.Properties.Resources.IsInternational, isInternational);
            objParm[26] = new SqlParameter(DL.Properties.Resources.Sector, sector);
            objParm[27] = new SqlParameter(DL.Properties.Resources.SubSegment, subsegment);
            objParm[28] = new SqlParameter(DL.Properties.Resources.Comments, comments);
            objParm[29] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[30] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_Client_Update", objParm);
            return ds;
        }
        #endregion
        #region Delete Data
        /// <summary>
        /// Clients the master delete.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMasterDelete(string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientMast_Delete", objParm);
            return ds;
        }
        #endregion
        #endregion

        #region Function related To client Company Mapping
        #region Get Data
        /// <summary>
        /// To get All the clientCode, manual client code client name and combine code and name not mapped with company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsNotMappedWithCompanyGet(string companyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientCompanyNoMapped_Get", objParm);
            return ds;
        }
        /// <summary>
        /// To get all the details of Client Company Mapping
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailGet(string companyCode, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientCompany_GetDetails", objParm);
            return ds;
        }

        #endregion
        #region Insert Data
        /// <summary>
        /// Clients the company mapping insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="addressLine1">The address line1.</param>
        /// <param name="addressLine2">The address line2.</param>
        /// <param name="addressLine3">The address line3.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="website">The website.</param>
        /// <param name="email">The email.</param>
        /// <param name="clientContactPerson">The client contact person.</param>
        /// <param name="clientContactPersonDesignation">The client contact person designation.</param>
        /// <param name="clientContactPersonMobile">The client contact person mobile.</param>
        /// <param name="ourContactPerson">Our contact person.</param>
        /// <param name="ourContactPersonEmployeeNo">Our contact person employee no.</param>
        /// <param name="ourContactPersonMobile">Our contact person mobile.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientCompanyMappingInsert(string companyCode, string clientCode, string addressLine1, string addressLine2, string addressLine3, string city, string state, string pin, string countryCode, string phone, string fax, string website, string email, string clientContactPerson, string clientContactPersonDesignation, string clientContactPersonMobile, string ourContactPerson, string ourContactPersonEmployeeNo, string ourContactPersonMobile, string comments, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[21];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AddressLine1, addressLine1);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AddressLine2, addressLine2);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AddressLine3, addressLine3);
            objParm[5] = new SqlParameter(DL.Properties.Resources.City, city);
            objParm[6] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[7] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParm[8] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[9] = new SqlParameter(DL.Properties.Resources.Phone, phone);
            objParm[10] = new SqlParameter(DL.Properties.Resources.Fax, fax);
            objParm[11] = new SqlParameter(DL.Properties.Resources.WebSite, website);
            objParm[12] = new SqlParameter(DL.Properties.Resources.Email, email);
            objParm[13] = new SqlParameter(DL.Properties.Resources.ClientContactPerson, clientContactPerson);
            objParm[14] = new SqlParameter(DL.Properties.Resources.ClientContactPersonDesignation, clientContactPersonDesignation);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ClientContactPersonMobile, clientContactPersonMobile);
            objParm[16] = new SqlParameter(DL.Properties.Resources.OurContactPerson, ourContactPerson);
            objParm[17] = new SqlParameter(DL.Properties.Resources.OurContactPersonEmpNo, ourContactPersonEmployeeNo);
            objParm[18] = new SqlParameter(DL.Properties.Resources.OurContactPersonMobile, ourContactPersonMobile);
            objParm[19] = new SqlParameter(DL.Properties.Resources.Comments, comments);
            objParm[20] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientCompany_Insert", objParm);
            return ds;
        }
        #endregion
        #region Modify Data
        /// <summary>
        /// Clients the company mapping update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="addressLine1">The address line1.</param>
        /// <param name="addressLine2">The address line2.</param>
        /// <param name="addressLine3">The address line3.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="website">The website.</param>
        /// <param name="email">The email.</param>
        /// <param name="clientContactPerson">The client contact person.</param>
        /// <param name="clientContactPersonDesignation">The client contact person designation.</param>
        /// <param name="clientContactPersonMobile">The client contact person mobile.</param>
        /// <param name="ourContactPerson">Our contact person.</param>
        /// <param name="ourContactPersonEmployeeNo">Our contact person employee no.</param>
        /// <param name="ourContactPersonMobile">Our contact person mobile.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientCompanyMappingUpdate(string companyCode, string clientCode, string addressLine1, string addressLine2, string addressLine3, string city, string state, string pin, string countryCode, string phone, string fax, string website, string email, string clientContactPerson, string clientContactPersonDesignation, string clientContactPersonMobile, string ourContactPerson, string ourContactPersonEmployeeNo, string ourContactPersonMobile, string comments, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[21];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AddressLine1, addressLine1);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AddressLine2, addressLine2);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AddressLine3, addressLine3);
            objParm[5] = new SqlParameter(DL.Properties.Resources.City, city);
            objParm[6] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[7] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParm[8] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[9] = new SqlParameter(DL.Properties.Resources.Phone, phone);
            objParm[10] = new SqlParameter(DL.Properties.Resources.Fax, fax);
            objParm[11] = new SqlParameter(DL.Properties.Resources.WebSite, website);
            objParm[12] = new SqlParameter(DL.Properties.Resources.Email, email);
            objParm[13] = new SqlParameter(DL.Properties.Resources.ClientContactPerson, clientContactPerson);
            objParm[14] = new SqlParameter(DL.Properties.Resources.ClientContactPersonDesignation, clientContactPersonDesignation);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ClientContactPersonMobile, clientContactPersonMobile);
            objParm[16] = new SqlParameter(DL.Properties.Resources.OurContactPerson, ourContactPerson);
            objParm[17] = new SqlParameter(DL.Properties.Resources.OurContactPersonEmpNo, ourContactPersonEmployeeNo);
            objParm[18] = new SqlParameter(DL.Properties.Resources.OurContactPersonMobile, ourContactPersonMobile);
            objParm[19] = new SqlParameter(DL.Properties.Resources.Comments, comments);
            objParm[20] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientCompany_Update", objParm);
            return ds;
        }
        #endregion
        #region delete Data
        /// <summary>
        /// Clients the company mapping delete.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientCompanyMappingDelete(string clientCode, string companyCode, int locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_CompClient_Delete", objParm);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related To Client Location Mapping
        #region Add Client to Location
        /// <summary>
        /// Clients the mapping to location add.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMappingToLocationAdd(int locationAutoId, string clientCode, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Client_AddToLocation", objParm);
            return ds;
        }
        #endregion
        #region Remove Client from Location
        /// <summary>
        /// Clients the mapping to location remove.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMappingToLocationRemove(int locationAutoId, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Client_RemoveFromLocation", objParm);
            return ds;
        }

        #endregion
        #region Get UnMapped ClientLocation
        /// <summary>
        /// Clients the not mapped to location get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientNotMappedToLocationGet(string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ClientLocationUnMapped_Get", objParm);
            return ds;
        }

        #endregion
        /*Code Modified By   on 1-Sep-2011*/
        #region Get Mapped ClientLocation

        /// <summary>
        /// Function Related to Get Mapped Clients
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsMappedToLocationGet(string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ClientLocationMapped_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Code fetches data for the Client List Screen on basis of AreaID
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsMappedToLocationGet(string locationAutoId, string areaId, string clientCode, string employeeNumber, string isAreaIncharge, string fromDate, string toDate)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaIncharge, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ClientLocationMappedAreaWise_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Function Related to Get Mapped AreaID ClientWise for ClientPortal
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsMappedToLocationGet(string locationAutoId, string userId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_ClientLocationMapped_GetBasedOnClientCode", objParm);
            return ds;
        }

        /// <summary>
        /// Gets the customer meeting detail.
        /// </summary>
        /// <param name="locationAutoId">The location automatic unique identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetCustomerMeetingDetail(string locationAutoId, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataTable  dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpMst_ClientMeetingDetails_GetBasedOnClientCode", objParm);
            return dt;
        }
        /// <summary>
        /// Updates the customer meeting detail.
        /// </summary>
        /// <param name="locationAutoId">The location automatic unique identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="custMeetingUnit">The customer meeting unit.</param>
        /// <returns>DataTable.</returns>
        public DataTable UpdateCustomerMeetingDetail(string locationAutoId, string clientCode, string custMeetingUnit)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CustMeetingUnit, custMeetingUnit);
            DataTable dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpMst_ClientMeetingDetails_UpdateBasedOnClientCode", objParm);
            return dt;
        }
        #endregion
        #endregion

        #region Function Related To Client Details
        #region Get Data
        /// <summary>
        /// Clients the details get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsGet(string locationAutoId, string clientCode, string areaId, string employeeNumber, string isIncharge, string fromDate, string toDate)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaIncharge, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientDetails_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Get Assignment details when cliecnytcode is passed with comma
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAssignmentDetails(string locationAutoId, string clientCode, string areaId, string employeeNumber,
       string isIncharge, string fromDate, string toDate)
        {
            var objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaIncharge, employeeNumber);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_AssignmentDetails_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Clients the asmt ids get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientAsmtIdsGet(string locationAutoId, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientAsmtId_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Clients the details get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsGet(string locationAutoId, string clientCode, string asmtId)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientDetails_GetByCode", objParm);
            return ds;
        }
        /// <summary>
        /// To get all the LocationAutoId, LocationCode, LocationDesc, LocationCodeDesc for a Client where any AsmtID is exists
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>ds with To get the LocationAutoId, LocationCode, LocationDesc, LocationCodeDesc for a Client where any AsmtID is exists</returns>
        public DataSet ClientAssignmentsGet(string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstClientLocation_Get", objParm);
            return ds;
        }
        /// <summary>
        /// To Get All the AsmtID's for a Client and LocationAutoId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>ds with All the AsmtID for a Client and LocationAutoId</returns>
        public DataSet ClientAsmtIdsGetAll(string locationAutoId, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstClientLocationAsmtID_Get", objParm);
            return ds;
        }
        /// <summary>
        /// To Get All the AsmtID's for a Client and LocationAutoId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="wefDate">The wef date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientAsmtIdsGetAll(string locationAutoId, string clientCode, string areaIncharge,string wefDate)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            if (wefDate != "")
            {
                objParm[3] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(wefDate));
            }
            else
            {
                objParm[3] = new SqlParameter(DL.Properties.Resources.WEFDate, wefDate);
            }
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstClientLocationAsmtIDIncharge_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Actives the asmt ids get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ActiveAsmtIdsGet(string locationAutoId, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Sales_GetNonTerminatedAsmtID", objParm);
            return ds;
        }
        /// <summary>
        /// to get the AsmtId , Address, and AsmtID(Address) where AsmtID starts with "B" For a Location and Client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtBillingIdGet(string locationAutoId, string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_BillingID_Get", objParm);
            return ds;
        }
        /// <summary>
        /// To Get Client for Branch
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>dataset</returns>
        public DataSet ClientGetBasedOnClientCode(string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSaleClientGetBasedOnClientCode", objParm);
            return ds;
        }
        #endregion
        #region Insert Data
        /// <summary>
        /// This Allows to create System generated New Address ID
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtIdType">Type of the asmt identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="asmtName">Name of the asmt.</param>
        /// <param name="jobNo">The job no.</param>
        /// <param name="asmtAddress">The asmt address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="email">The email.</param>
        /// <param name="clientContactPerson">The client contact person.</param>
        /// <param name="clientContactPersonDesignation">The client contact person designation.</param>
        /// <param name="clientContactPersonMobile">The client contact person mobile.</param>
        /// <param name="premisesType">Type of the premises.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="otherLanguageAsmtAddress">The other language asmt address.</param>
        /// <param name="fromdate">The fromdate.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsInsert(string locationAutoId, string clientCode, string asmtIdType, string areaId, string asmtName, string jobNo, string asmtAddress, string city, string state, string pin, string countryCode, string phone, string fax, string email, string clientContactPerson, string clientContactPersonDesignation, string clientContactPersonMobile, string premisesType, string comments, string modifiedBy, string otherLanguageAsmtAddress, string fromdate)
        {
            SqlParameter[] objParm = new SqlParameter[22];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtIdType, asmtIdType);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtName, asmtName);
            objParm[5] = new SqlParameter(DL.Properties.Resources.JobNo, jobNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AsmtAddress, asmtAddress);
            objParm[7] = new SqlParameter(DL.Properties.Resources.City, city);
            objParm[8] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[9] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParm[10] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[11] = new SqlParameter(DL.Properties.Resources.Phone, phone);
            objParm[12] = new SqlParameter(DL.Properties.Resources.Fax, fax);
            objParm[13] = new SqlParameter(DL.Properties.Resources.Email, email);
            objParm[14] = new SqlParameter(DL.Properties.Resources.ClientContactPerson, clientContactPerson);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ClientContactPersonDesignation, clientContactPersonDesignation);
            objParm[16] = new SqlParameter(DL.Properties.Resources.ClientContactPersonMobile, clientContactPersonMobile);
            objParm[17] = new SqlParameter(DL.Properties.Resources.PremisesType, premisesType);
            objParm[18] = new SqlParameter(DL.Properties.Resources.Comments, comments);
            objParm[19] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[20] = new SqlParameter(DL.Properties.Resources.OtherLanguageAsmtAddress, otherLanguageAsmtAddress);
            objParm[21] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromdate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientDetails_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// This Allows to create New Address ID Manually
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtIdType">Type of the asmt identifier.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="asmtName">Name of the asmt.</param>
        /// <param name="jobNo">The job no.</param>
        /// <param name="asmtAddress">The asmt address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="email">The email.</param>
        /// <param name="clientContactPerson">The client contact person.</param>
        /// <param name="clientContactPersonDesignation">The client contact person designation.</param>
        /// <param name="clientContactPersonMobile">The client contact person mobile.</param>
        /// <param name="premisesType">Type of the premises.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="otherLanguageAsmtAddress">The other language asmt address.</param>
        /// <param name="fromDate">From date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsManuallyInsert(string locationAutoId, string clientCode,
                                                      string asmtIdType, string asmtId, string areaId, string asmtName,
                                                      string jobNo, string asmtAddress, string city, string state,
                                                      string pin, string countryCode, string phone,
                                                      string fax, string email, string clientContactPerson,
                                                      string clientContactPersonDesignation,
                                                      string clientContactPersonMobile, string premisesType,
                                                      string comments, string modifiedBy,
                                                      string otherLanguageAsmtAddress, string fromDate)
        {
            SqlParameter[] objParm = new SqlParameter[23];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtIdType, asmtIdType);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AsmtName, asmtName);
            objParm[6] = new SqlParameter(DL.Properties.Resources.JobNo, jobNo);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AsmtAddress, asmtAddress);
            objParm[8] = new SqlParameter(DL.Properties.Resources.City, city);
            objParm[9] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[10] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParm[11] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[12] = new SqlParameter(DL.Properties.Resources.Phone, phone);
            objParm[13] = new SqlParameter(DL.Properties.Resources.Fax, fax);
            objParm[14] = new SqlParameter(DL.Properties.Resources.Email, email);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ClientContactPerson, clientContactPerson);
            objParm[16] = new SqlParameter(DL.Properties.Resources.ClientContactPersonDesignation, clientContactPersonDesignation);
            objParm[17] = new SqlParameter(DL.Properties.Resources.ClientContactPersonMobile, clientContactPersonMobile);
            objParm[18] = new SqlParameter(DL.Properties.Resources.PremisesType, premisesType);
            objParm[19] = new SqlParameter(DL.Properties.Resources.Comments, comments);
            objParm[20] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParm[21] = new SqlParameter(DL.Properties.Resources.OtherLanguageAsmtAddress, otherLanguageAsmtAddress);
            objParm[22] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientDetails_ManualInsert", objParm);
            return ds;
        }
        #endregion
        #region Update Data
        /// <summary>
        /// Clients the details update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="asmtName">Name of the asmt.</param>
        /// <param name="jobNo">The job no.</param>
        /// <param name="asmtAddress">The asmt address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="countryCode">The country code.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="fax">The fax.</param>
        /// <param name="email">The email.</param>
        /// <param name="clientContactPerson">The client contact person.</param>
        /// <param name="clientContactPersonDesignation">The client contact person designation.</param>
        /// <param name="clientContactPersonMobile">The client contact person mobile.</param>
        /// <param name="premisesType">Type of the premises.</param>
        /// <param name="comments">The comments.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsUpdate(string locationAutoId, string clientCode, string asmtId, string areaId, string asmtName, string jobNo, string asmtAddress, string city, string state, string pin, string countryCode, string phone, string fax, string email, string clientContactPerson, string clientContactPersonDesignation, string clientContactPersonMobile, string premisesType, string comments, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[20];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AsmtName, asmtName);
            objParm[5] = new SqlParameter(DL.Properties.Resources.JobNo, jobNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AsmtAddress, asmtAddress);
            objParm[7] = new SqlParameter(DL.Properties.Resources.City, city);
            objParm[8] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[9] = new SqlParameter(DL.Properties.Resources.Pin, pin);
            objParm[10] = new SqlParameter(DL.Properties.Resources.CountryCode, countryCode);
            objParm[11] = new SqlParameter(DL.Properties.Resources.Phone, phone);
            objParm[12] = new SqlParameter(DL.Properties.Resources.Fax, fax);
            objParm[13] = new SqlParameter(DL.Properties.Resources.Email, email);
            objParm[14] = new SqlParameter(DL.Properties.Resources.ClientContactPerson, clientContactPerson);
            objParm[15] = new SqlParameter(DL.Properties.Resources.ClientContactPersonDesignation, clientContactPersonDesignation);
            objParm[16] = new SqlParameter(DL.Properties.Resources.ClientContactPersonMobile, clientContactPersonMobile);
            objParm[17] = new SqlParameter(DL.Properties.Resources.PremisesType, premisesType);
            objParm[18] = new SqlParameter(DL.Properties.Resources.Comments, comments);
            objParm[19] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientDetails_Update", objParm);
            return ds;
        }
        #endregion
        #region Delete data
        /// <summary>
        /// Clients the details delete.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsDelete(string locationAutoId, string clientCode, string asmtId)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientDetails_Delete", objParm);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related To Multilingual
        /// <summary>
        /// Multilinguals the client detail insert.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="otherLanguageClientName">Name of the other language client.</param>
        /// <param name="otherLanguageAdd1">The other language add1.</param>
        /// <param name="otherLanguageAdd2">The other language add2.</param>
        /// <param name="otherLanguageAdd3">The other language add3.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MultilingualClientDetailInsert(string clientCode, string otherLanguageClientName, string otherLanguageAdd1, string otherLanguageAdd2, string otherLanguageAdd3, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.OtherLanguageClientName, otherLanguageClientName);
            objParm[2] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd1, otherLanguageAdd1);
            objParm[3] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd2, otherLanguageAdd2);
            objParm[4] = new SqlParameter(DL.Properties.Resources.OtherLanguageAdd3, otherLanguageAdd3);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_MultiLingualClientDetails_Insert", objParm);
            return ds;
        }
        /// <summary>
        /// Multilinguals the client detail get all.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MultilingualClientDetailGetAll(string clientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_MultiLingualClientDetails_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Multilinguals the asmt detail insert.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="otherLanguageAsmtAddress">The other language asmt address.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MultilingualAsmtDetailInsert(string clientCode, string asmtId, string otherLanguageAsmtAddress, string locationAutoId, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.OtherLanguageAsmtAddress, otherLanguageAsmtAddress);
            objParm[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_MultiLingualAsmtDetails_Insert", objParm);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related To Contract Master

        #region Function Related to get Data
        /// <summary>
        /// To Get Contract number
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="statusAuthorized">The status authorized.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractNumberGetAll(string clientCode, string statusAuthorized)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.StatusAuthorized, statusAuthorized);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractNumber_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// to get all Authorized contract details of the selected Location and client code
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="statusAuthorized">The status authorized.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractNumberGetAll(string locationAutoId, string clientCode, string statusAuthorized)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.StatusAuthorized, statusAuthorized);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSalesContractNoGetForLocation", objParam);
            return ds;
        }

        /// <summary>
        /// to get all contract details of the selected client code
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterGetAll(string clientCode, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_GetAll", objParam);
            return ds;

        }
        /// <summary>
        /// Contracts the detail get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractDetailGet(string locationAutoId, string clientCode, string contractNumber)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstContractDetails_get4ContNo", objParam);
            return ds;
        }
        /// <summary>
        /// Contracts the value get.
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="soStatus">The so status.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractValueGet(string contractNumber, string soStatus)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstSaleContractvalue_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Pendings the contract get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="statusFresh">The status fresh.</param>
        /// <param name="statusAmend">The status amend.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PendingContractGet(string locationAutoId, string statusFresh, string statusAmend, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.StatusFresh, statusFresh);
            objParam[2] = new SqlParameter(DL.Properties.Resources.StatusAmend, statusAmend);
            objParam[3] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstSalePendingContract_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Get All The Contract where review date is in next 60 days by default or the set value in system parameters
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractReviewGet(string locationAutoId, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstSaleContractReview_Get", objParam);
            return ds;
        }
        public DataSet ContractDashboardGet(string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetContractDetails", objParam);
            return ds;
        }

        /// <summary>
        /// Expirings the contract get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ExpiringContractGet(string locationAutoId, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_mstSaleExpiringContract_Get", objParam);
            return ds;
        }


        #endregion

        #region Function Related To insert Data
        /// <summary>
        /// Creates Contract Master
        /// </summary>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <param name="issuingAuthority">The issuing authority.</param>
        /// <param name="deliveryDate">The delivery date.</param>
        /// <param name="deliveryTo">The delivery to.</param>
        /// <param name="expectedSignDate">The expected sign date.</param>
        /// <param name="loiDate">The loi date.</param>
        /// <param name="loiStartDate">The loi start date.</param>
        /// <param name="loiEndDate">The loi end date.</param>
        /// <param name="manualContractNo">The manual contract no.</param>
        /// <param name="clientSigningAuthority">The client signing authority.</param>
        /// <param name="designationAuthority">The designation authority.</param>
        /// <param name="contractSignDate">The contract sign date.</param>
        /// <param name="contractStartDate">The contract start date.</param>
        /// <param name="contractEndDate">The contract end date.</param>
        /// <param name="contractReviewDate">The contract Review Date</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="withEffectFrom">The with effect from.</param>
        /// <param name="status">The status.</param>
        /// <param name="contractValue">The contract value.</param>
        /// <param name="contractPaperDelivered">if set to <c>true</c> [contract paper delivered].</param>
        /// <param name="paramValue1">The parameter value1.</param>
        /// <param name="noticePeriodDaysToTerminate">The notice period days to terminate.</param>
        /// <param name="totalWarrantyAmount">The total warranty amount.</param>
        /// <param name="renewalInMonths">The renewal in months.</param>
        /// <param name="clientNoticeToRenewalInDays">The client notice to renewal in days.</param>
        /// <param name="insurance">The insurance.</param>
        /// <param name="isAutoRenewal">if set to <c>true</c> [is automatic renewal].</param>
        /// <param name="isLimitedWarranty">if set to <c>true</c> [is limited warranty].</param>
        /// <param name="isScanCopyExists">if set to <c>true</c> [is scan copy exists].</param>
        /// <param name="ifTerminatePossible">if set to <c>true</c> [if terminate possible].</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterInsert(int amendmentNo, string issuingAuthority, string deliveryDate,
            string deliveryTo, string expectedSignDate, string loiDate, string loiStartDate, string loiEndDate,
            string manualContractNo, string clientSigningAuthority, string designationAuthority, string contractSignDate,
            string contractStartDate, string contractEndDate, string contractReviewDate, string modifiedBy, string clientCode, string locationAutoId,
            string withEffectFrom, string status, float contractValue, bool contractPaperDelivered, string paramValue1,
            string noticePeriodDaysToTerminate, string totalWarrantyAmount, string renewalInMonths,
            string clientNoticeToRenewalInDays, string insurance, bool isAutoRenewal, bool isLimitedWarranty,
            bool isScanCopyExists, bool ifTerminatePossible)
        {
            DL.Common objCommon = new DL.Common();
            deliveryDate = objCommon.ConvertDateToNull(deliveryDate);
            expectedSignDate = objCommon.ConvertDateToNull(expectedSignDate);
            loiDate = objCommon.ConvertDateToNull(loiDate);
            loiStartDate = objCommon.ConvertDateToNull(loiStartDate);
            loiEndDate = objCommon.ConvertDateToNull(loiEndDate);
            contractSignDate = objCommon.ConvertDateToNull(contractSignDate);
            contractStartDate = objCommon.ConvertDateToNull(contractStartDate);
            contractEndDate = objCommon.ConvertDateToNull(contractEndDate);
            contractReviewDate = objCommon.ConvertDateToNull(contractReviewDate);
            withEffectFrom = objCommon.ConvertDateToNull(withEffectFrom);
            SqlParameter[] objParam = new SqlParameter[32];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AmendNo, amendmentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IssuingAuth, issuingAuthority);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DeliveryDate, deliveryDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DeliveryTo, deliveryTo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ExpSignDate, expectedSignDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.LOIDate, loiDate);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LOIStartDate, loiStartDate);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LOIEndDate, loiEndDate);
            objParam[8] = new SqlParameter(DL.Properties.Resources.MContractNo, manualContractNo);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ClientSigAuth, clientSigningAuthority);
            objParam[10] = new SqlParameter(DL.Properties.Resources.DesignationAuth, designationAuthority);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ContractSignDate, contractSignDate);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ContStartDate, contractStartDate);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ContEndDate, contractEndDate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ContReviewDate, contractReviewDate);
            objParam[15] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[17] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[18] = new SqlParameter(DL.Properties.Resources.WithEffectiveFrom, withEffectFrom);
            objParam[19] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[20] = new SqlParameter(DL.Properties.Resources.ContractValue, contractValue);
            objParam[21] = new SqlParameter(DL.Properties.Resources.ContractPaperDelivered, contractPaperDelivered);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ParamValue1, paramValue1);
            objParam[23] = new SqlParameter(DL.Properties.Resources.NoticePeriodDaysToTerminate,
                                           noticePeriodDaysToTerminate);
            objParam[24] = new SqlParameter(DL.Properties.Resources.TotalWarrantyAmount, totalWarrantyAmount);
            objParam[25] = new SqlParameter(DL.Properties.Resources.RenewalInMonths, renewalInMonths);
            objParam[26] = new SqlParameter(DL.Properties.Resources.ClientNoticeToRenewalInDays,
                                            clientNoticeToRenewalInDays);
            objParam[27] = new SqlParameter(DL.Properties.Resources.Insurance, insurance);
            objParam[28] = new SqlParameter(DL.Properties.Resources.IsAutoRenewal, isAutoRenewal);
            objParam[29] = new SqlParameter(DL.Properties.Resources.IsLimitedWarranty, isLimitedWarranty);
            objParam[30] = new SqlParameter(DL.Properties.Resources.IsScanCopyExists, isScanCopyExists);
            objParam[31] = new SqlParameter(DL.Properties.Resources.IfWeCanTerminate, ifTerminatePossible);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Inserts Contract Number Manually
        /// </summary>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <param name="issuingAuthority">The issuing authority.</param>
        /// <param name="deliveryDate">The delivery date.</param>
        /// <param name="deliveryTo">The delivery to.</param>
        /// <param name="expectedSignDate">The expected sign date.</param>
        /// <param name="loiDate">The loi date.</param>
        /// <param name="loiStartDate">The loi start date.</param>
        /// <param name="loiEndDate">The loi end date.</param>
        /// <param name="manualContractNo">The manual contract no.</param>
        /// <param name="clientSigningAuthority">The client signing authority.</param>
        /// <param name="designationAuthority">The designation authority.</param>
        /// <param name="contractSignDate">The contract sign date.</param>
        /// <param name="contractStartDate">The contract start date.</param>
        /// <param name="contractEndDate">The contract end date.</param>
        /// <param name="ContractReviewDate">The contract review date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="withEffectFrom">The with effect from.</param>
        /// <param name="status">The status.</param>
        /// <param name="contractValue">The contract value.</param>
        /// <param name="contractPaperDelivered">if set to <c>true</c> [contract paper delivered].</param>
        /// <param name="paramValue1">The parameter value1.</param>
        /// <param name="contractNo">The contract no.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterManuallyInsert(int amendmentNo, string issuingAuthority,
                                                       string deliveryDate, string deliveryTo,
                                                       string expectedSignDate, string loiDate, string loiStartDate,
                                                       string loiEndDate, string manualContractNo,
                                                       string clientSigningAuthority, string designationAuthority,
                                                       string contractSignDate, string contractStartDate,
                                                       string contractEndDate, string ContractReviewDate, string modifiedBy,
                                                       string clientCode, string locationAutoId,
                                                       string withEffectFrom, string status, float contractValue,
                                                       bool contractPaperDelivered, string paramValue1,
                                                       string contractNo)
        {
            DL.Common objCommon = new DL.Common();
            deliveryDate = objCommon.ConvertDateToNull(deliveryDate);
            expectedSignDate = objCommon.ConvertDateToNull(expectedSignDate);
            loiDate = objCommon.ConvertDateToNull(loiDate);
            loiStartDate = objCommon.ConvertDateToNull(loiStartDate);
            loiEndDate = objCommon.ConvertDateToNull(loiEndDate);
            contractSignDate = objCommon.ConvertDateToNull(contractSignDate);
            contractStartDate = objCommon.ConvertDateToNull(contractStartDate);
            contractEndDate = objCommon.ConvertDateToNull(contractEndDate);
            ContractReviewDate = objCommon.ConvertDateToNull(ContractReviewDate);
            withEffectFrom = objCommon.ConvertDateToNull(withEffectFrom);
            SqlParameter[] objParam = new SqlParameter[24];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AmendNo, amendmentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IssuingAuth, issuingAuthority);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DeliveryDate, deliveryDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DeliveryTo, deliveryTo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ExpSignDate, expectedSignDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.LOIDate, loiDate);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LOIStartDate, loiStartDate);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LOIEndDate, loiEndDate);
            objParam[8] = new SqlParameter(DL.Properties.Resources.MContractNo, manualContractNo);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ClientSigAuth, clientSigningAuthority);
            objParam[10] = new SqlParameter(DL.Properties.Resources.DesignationAuth, designationAuthority);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ContractSignDate, contractSignDate);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ContStartDate, contractStartDate);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ContEndDate, contractEndDate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ContReviewDate, ContractReviewDate);
            objParam[15] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[17] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[18] = new SqlParameter(DL.Properties.Resources.WithEffectiveFrom, withEffectFrom);
            objParam[19] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[20] = new SqlParameter(DL.Properties.Resources.ContractValue, contractValue);
            objParam[21] = new SqlParameter(DL.Properties.Resources.ContractPaperDelivered, contractPaperDelivered);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ParamValue1, paramValue1);
            objParam[23] = new SqlParameter(DL.Properties.Resources.ContractNo, contractNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_ManualInsert",
                                          objParam);
            return ds;
        }
        /// <summary>
        /// Attendances the type insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic unique identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt unique identifier.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="breakHRApplication">The break character application.</param>
        /// <param name="breakHrs">The break HRS.</param>
        /// <param name="siteSuperVisionNo">The site super vision no.</param>
        /// <param name="siteSuperVisionUnit">The site super vision unit.</param>
        /// <returns>DataTable.</returns>
        public DataTable AttendanceTypeInsert(string locationAutoId, string clientCode, string asmtId, string attendanceType, string modifiedBy, string breakHRApplication, string breakHrs,int siteSuperVisionNo ,string siteSuperVisionUnit )
        {
            // int rowsaffected = 0;
            SqlParameter[] objParm = new SqlParameter[9];

            Guard.ArgumentConvertibleTo<bool>(breakHRApplication, "myBoolArgument");
            Guard.ArgumentConvertibleTo<int>(breakHrs, "myIntArgument");

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AttendanceType, attendanceType);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            // objParm[5] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(wefDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.BreakHrsApp, bool.Parse(breakHRApplication));
            objParm[6] = new SqlParameter(DL.Properties.Resources.BreakHrs, int.Parse(breakHrs));
            objParm[7] = new SqlParameter(DL.Properties.Resources.SiteSuperVisionNo, siteSuperVisionNo);
            objParm[8] = new SqlParameter(DL.Properties.Resources.SiteSuperVisionUnit,siteSuperVisionUnit);
            //objParm[9] = new SqlParameter(DL.Properties.Resources.CustMeetingNo, custMeetingNo);
            //objParm[10] = new SqlParameter(DL.Properties.Resources.CustMeetingUnit,custMeetingUnit);

            DataTable dt = SqlHelper.ExecuteDatatable("udp_SaleClientDetails_AttendanceType_Insert", objParm);
            return dt;

        }

        /// <summary>
        /// Asmts the attendance details get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader AsmtAttendanceDetailsGet(string locationAutoId, string clientCode, string asmtId)
        {
            SqlDataReader reader = null;
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);

            reader = SqlHelper.ExecuteReader("udp_SaleClientDetails_AttendanceType_Get", objParm);
            return reader;

        }

        /// <summary>
        /// Asmts the attend details by amend no get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader AsmtAttendDetailsByAmendNoGet(string locationAutoId, string clientCode, string asmtId, int amendNo)
        {
            SqlDataReader reader = null;
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AmendNo, amendNo);

            reader = SqlHelper.ExecuteReader("udp_SaleClientDetails_AttendanceType_GetByAmendNo", objParm);
            return reader;

        }
        #endregion

        #region Function To insert Record when user clicks Short Close And Status iS Authorized
        /// <summary>
        /// To insert Record when user clicks Short Close And Status iS Authorized
        /// </summary>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <param name="issuingAuthority">The issuing authority.</param>
        /// <param name="deliveryDate">The delivery date.</param>
        /// <param name="deliveryTo">The delivery to.</param>
        /// <param name="expectedSignDate">The expected sign date.</param>
        /// <param name="loiDate">The loi date.</param>
        /// <param name="loiStartDate">The loi start date.</param>
        /// <param name="loiEndDate">The loi end date.</param>
        /// <param name="manualContractNo">The manual contract no.</param>
        /// <param name="clientSigningAuthority">The client signing authority.</param>
        /// <param name="designationAuthority">The designation authority.</param>
        /// <param name="contractSignDate">The contract sign date.</param>
        /// <param name="contractStartDate">The contract start date.</param>
        /// <param name="contractEndDate">The contract end date.</param>
        /// <param name="contractReviewDate">The contract Review Date</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="withEffectFrom">The with effect from.</param>
        /// <param name="status">The status.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="shortCloseDate">The short close date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShortCloseContractMaster(int amendmentNo, string issuingAuthority, string deliveryDate, string deliveryTo, string expectedSignDate, string loiDate, string loiStartDate, string loiEndDate, string manualContractNo, string clientSigningAuthority, string designationAuthority, string contractSignDate, string contractStartDate, string contractEndDate, string contractReviewDate, string modifiedBy, string clientCode, string locationAutoId, string withEffectFrom, string status, string contractNumber, string shortCloseDate)
        {
            DL.Common objCommon = new DL.Common();
            deliveryDate = objCommon.ConvertDateToNull(deliveryDate);
            expectedSignDate = objCommon.ConvertDateToNull(expectedSignDate);
            loiDate = objCommon.ConvertDateToNull(loiDate);
            loiStartDate = objCommon.ConvertDateToNull(loiStartDate);
            loiEndDate = objCommon.ConvertDateToNull(loiEndDate);
            contractSignDate = objCommon.ConvertDateToNull(contractSignDate);
            contractStartDate = objCommon.ConvertDateToNull(contractStartDate);
            contractEndDate = objCommon.ConvertDateToNull(contractEndDate);
            contractReviewDate = objCommon.ConvertDateToNull(contractReviewDate);
            withEffectFrom = objCommon.ConvertDateToNull(withEffectFrom);
            SqlParameter[] objParam = new SqlParameter[22];                             // Added For Bug #2496
            objParam[0] = new SqlParameter(DL.Properties.Resources.AmendNo, amendmentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IssuingAuth, issuingAuthority);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DeliveryDate, deliveryDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DeliveryTo, deliveryTo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ExpSignDate, expectedSignDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.LOIDate, loiDate);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LOIStartDate, loiStartDate);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LOIEndDate, loiEndDate);
            objParam[8] = new SqlParameter(DL.Properties.Resources.MContractNo, manualContractNo);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ClientSigAuth, clientSigningAuthority);
            objParam[10] = new SqlParameter(DL.Properties.Resources.DesignationAuth, designationAuthority);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ContractSignDate, contractSignDate);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ContStartDate, contractStartDate);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ContEndDate, contractEndDate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ContReviewDate, contractReviewDate);
            objParam[15] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[17] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[18] = new SqlParameter(DL.Properties.Resources.WithEffectiveFrom, withEffectFrom);
            objParam[19] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[20] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[21] = new SqlParameter(DL.Properties.Resources.ShortCloseDate, shortCloseDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_ShortCloseInsert", objParam);
            return ds;
        }
        #endregion

        #region Function To Insert Amend Records
        /// <summary>
        /// To Insert New Record when Amend Button Is Clicked
        /// </summary>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <param name="issuingAuthority">The issuing authority.</param>
        /// <param name="deliveryDate">The delivery date.</param>
        /// <param name="deliveryTo">The delivery to.</param>
        /// <param name="expectedSignDate">The expected sign date.</param>
        /// <param name="loiDate">The loi date.</param>
        /// <param name="loiStartDate">The loi start date.</param>
        /// <param name="loiEndDate">The loi end date.</param>
        /// <param name="manualContractNo">The manual contract no.</param>
        /// <param name="clientSigningAuthority">The client signing authority.</param>
        /// <param name="designationAuthority">The designation authority.</param>
        /// <param name="contractSignDate">The contract sign date.</param>
        /// <param name="contractStartDate">The contract start date.</param>
        /// <param name="contractEndDate">The contract end date.</param>
        /// <param name="contractReviewDate">The contract Review Date</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="withEffectFrom">The with effect from.</param>
        /// <param name="status">The status.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="contractValue">The contract value.</param>
        /// <param name="contractPaperDelivered">if set to <c>true</c> [contract paper delivered].</param>
        /// <param name="noticePeriodDaysToTerminate">The notice period days to terminate.</param>
        /// <param name="totalWarrantyAmount">The total warranty amount.</param>
        /// <param name="renewalInMonths">The renewal in months.</param>
        /// <param name="clientNoticeToRenewalInDays">The client notice to renewal in days.</param>
        /// <param name="insurance">The insurance.</param>
        /// <param name="isAutoRenewal">if set to <c>true</c> [is automatic renewal].</param>
        /// <param name="isLimitedWarranty">if set to <c>true</c> [is limited warranty].</param>
        /// <param name="isScanCopyExists">if set to <c>true</c> [is scan copy exists].</param>
        /// <param name="ifTerminatePossible">if set to <c>true</c> [if terminate possible].</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterInsertAmendRecord(int amendmentNo, string issuingAuthority, string deliveryDate, string deliveryTo, string expectedSignDate, string loiDate, string loiStartDate, string loiEndDate, string manualContractNo, string clientSigningAuthority, string designationAuthority, string contractSignDate, string contractStartDate, string contractEndDate, string contractReviewDate, string modifiedBy, string clientCode, string locationAutoId, string withEffectFrom, string status, string contractNumber, float contractValue, bool contractPaperDelivered, string noticePeriodDaysToTerminate, string totalWarrantyAmount, string renewalInMonths,
            string clientNoticeToRenewalInDays, string insurance, bool isAutoRenewal, bool isLimitedWarranty,
            bool isScanCopyExists, bool ifTerminatePossible)
        {

            DL.Common objCommon = new DL.Common();
            deliveryDate = objCommon.ConvertDateToNull(deliveryDate);
            expectedSignDate = objCommon.ConvertDateToNull(expectedSignDate);
            loiDate = objCommon.ConvertDateToNull(loiDate);
            loiStartDate = objCommon.ConvertDateToNull(loiStartDate);
            loiEndDate = objCommon.ConvertDateToNull(loiEndDate);
            contractSignDate = objCommon.ConvertDateToNull(contractSignDate);
            contractStartDate = objCommon.ConvertDateToNull(contractStartDate);
            contractEndDate = objCommon.ConvertDateToNull(contractEndDate);
            contractReviewDate = objCommon.ConvertDateToNull(contractReviewDate);
            withEffectFrom = objCommon.ConvertDateToNull(withEffectFrom);
            SqlParameter[] objParam = new SqlParameter[32];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AmendNo, amendmentNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IssuingAuth, issuingAuthority);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DeliveryDate, deliveryDate);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DeliveryTo, deliveryTo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ExpSignDate, expectedSignDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.LOIDate, loiDate);
            objParam[6] = new SqlParameter(DL.Properties.Resources.LOIStartDate, loiStartDate);
            objParam[7] = new SqlParameter(DL.Properties.Resources.LOIEndDate, loiEndDate);
            objParam[8] = new SqlParameter(DL.Properties.Resources.MContractNo, manualContractNo);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ClientSigAuth, clientSigningAuthority);
            objParam[10] = new SqlParameter(DL.Properties.Resources.DesignationAuth, designationAuthority);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ContractSignDate, contractSignDate);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ContStartDate, contractStartDate);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ContEndDate, contractEndDate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ContReviewDate, contractReviewDate);
            objParam[15] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[16] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[17] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[18] = new SqlParameter(DL.Properties.Resources.WithEffectiveFrom, withEffectFrom);
            objParam[19] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[20] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[21] = new SqlParameter(DL.Properties.Resources.ContractValue, contractValue);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ContractPaperDelivered, contractPaperDelivered);
            objParam[23] = new SqlParameter(DL.Properties.Resources.NoticePeriodDaysToTerminate,
                                            noticePeriodDaysToTerminate);
            objParam[24] = new SqlParameter(DL.Properties.Resources.TotalWarrantyAmount, totalWarrantyAmount);
            objParam[25] = new SqlParameter(DL.Properties.Resources.RenewalInMonths, renewalInMonths);
            objParam[26] = new SqlParameter(DL.Properties.Resources.ClientNoticeToRenewalInDays,
                                            clientNoticeToRenewalInDays);
            objParam[27] = new SqlParameter(DL.Properties.Resources.Insurance, insurance);
            objParam[28] = new SqlParameter(DL.Properties.Resources.IsAutoRenewal, isAutoRenewal);
            objParam[29] = new SqlParameter(DL.Properties.Resources.IsLimitedWarranty, isLimitedWarranty);
            objParam[30] = new SqlParameter(DL.Properties.Resources.IsScanCopyExists, isScanCopyExists);
            objParam[31] = new SqlParameter(DL.Properties.Resources.IfWeCanTerminate, ifTerminatePossible);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_InsertAmendRecord", objParam);
            return ds;
        }
        /// <summary>
        /// Determines whether [is sale order exists for contract] [the specified contract number].
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet IsSaleOrderExistsForContract(string contractNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SaleContractDetails_GetIsSOExist", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Authorizatio
        /// <summary>
        /// Contracts the master authorized.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterAuthorized(string clientCode, string contractNumber, int amendmentNo, string modifiedBy, string locationAutoId, string status)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AmendmentNo, amendmentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractNumber_Authorize", objParam);
            return ds;
        }
        #endregion

        #region Function Related to update when Save button is clicked in contract master
        /// <summary>
        /// to update when Save button is clicked
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <param name="clientSigningAuthority">The client signing authority.</param>
        /// <param name="contractEndDate">The contract end date.</param>
        /// <param name="contractReviewDate">The Contract Review Date</param>
        /// <param name="contractSignDate">The contract sign date.</param>
        /// <param name="contractStartDate">The contract start date.</param>
        /// <param name="deliveryDate">The delivery date.</param>
        /// <param name="deliveryTo">The delivery to.</param>
        /// <param name="designationAuthority">The designation authority.</param>
        /// <param name="expectedSignDate">The expected sign date.</param>
        /// <param name="issuingAuthority">The issuing authority.</param>
        /// <param name="loiDate">The loi date.</param>
        /// <param name="loiEndDate">The loi end date.</param>
        /// <param name="loiStartDate">The loi start date.</param>
        /// <param name="manualContractNo">The manual contract no.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="status">The status.</param>
        /// <param name="withEffectFrom">The with effect from.</param>
        /// <param name="contractValue">The contract value.</param>
        /// <param name="contractPaperDelivered">if set to <c>true</c> [contract paper delivered].</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="noticePeriodDaysToTerminate">The notice period days to terminate.</param>
        /// <param name="totalWarrantyAmount">The total warranty amount.</param>
        /// <param name="renewalInMonths">The renewal in months.</param>
        /// <param name="clientNoticeToRenewalInDays">The client notice to renewal in days.</param>
        /// <param name="insurance">The insurance.</param>
        /// <param name="isAutoRenewal">if set to <c>true</c> [is automatic renewal].</param>
        /// <param name="isLimitedWarranty">if set to <c>true</c> [is limited warranty].</param>
        /// <param name="isScanCopyExists">if set to <c>true</c> [is scan copy exists].</param>
        /// <param name="ifTerminatePossible">if set to <c>true</c> [if terminate possible].</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterUpdate(string clientCode, string contractNumber, int amendmentNo, string clientSigningAuthority, string contractEndDate, string contractReviewDate, string contractSignDate, string contractStartDate, string deliveryDate, string deliveryTo, string designationAuthority, string expectedSignDate, string issuingAuthority, string loiDate, string loiEndDate, string loiStartDate, string manualContractNo, string modifiedBy, string locationAutoId, string status, string withEffectFrom, float contractValue, bool contractPaperDelivered, string paramValue, string noticePeriodDaysToTerminate, string totalWarrantyAmount, string renewalInMonths,
            string clientNoticeToRenewalInDays, string insurance, bool isAutoRenewal, bool isLimitedWarranty,
            bool isScanCopyExists, bool ifTerminatePossible)
        {

            DL.Common objCommon = new DL.Common();
            deliveryDate = objCommon.ConvertDateToNull(deliveryDate);
            expectedSignDate = objCommon.ConvertDateToNull(expectedSignDate);
            loiDate = objCommon.ConvertDateToNull(loiDate);
            loiStartDate = objCommon.ConvertDateToNull(loiStartDate);
            loiEndDate = objCommon.ConvertDateToNull(loiEndDate);
            contractSignDate = objCommon.ConvertDateToNull(contractSignDate);
            contractStartDate = objCommon.ConvertDateToNull(contractStartDate);
            contractEndDate = objCommon.ConvertDateToNull(contractEndDate);
            contractReviewDate = objCommon.ConvertDateToNull(contractReviewDate);
            withEffectFrom = objCommon.ConvertDateToNull(withEffectFrom);
            SqlParameter[] objParam = new SqlParameter[33];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AmendmentNo, amendmentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientSignAuth, clientSigningAuthority);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ContEndDate, contractEndDate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ContReviewDate, contractReviewDate);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ContractSignDate, contractSignDate);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ContStartDate, contractStartDate);
            objParam[8] = new SqlParameter(DL.Properties.Resources.DeliveryDate, deliveryDate);
            objParam[9] = new SqlParameter(DL.Properties.Resources.DeliveryTo, deliveryTo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.DesignationAuth, designationAuthority);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ExptSignDate, expectedSignDate);
            objParam[12] = new SqlParameter(DL.Properties.Resources.IssuingAuth, issuingAuthority);
            objParam[13] = new SqlParameter(DL.Properties.Resources.LOIDate, loiDate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.LOIEndDate, loiEndDate);
            objParam[15] = new SqlParameter(DL.Properties.Resources.LOIStartDate, loiStartDate);
            objParam[16] = new SqlParameter(DL.Properties.Resources.MContractNumber, manualContractNo);
            objParam[17] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[18] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[19] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[20] = new SqlParameter(DL.Properties.Resources.WithEffectFrom, withEffectFrom);
            objParam[21] = new SqlParameter(DL.Properties.Resources.ContractValue, contractValue);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ContractPaperDelivered, contractPaperDelivered);
            objParam[23] = new SqlParameter(DL.Properties.Resources.ParamValue1, paramValue);
            objParam[24] = new SqlParameter(DL.Properties.Resources.NoticePeriodDaysToTerminate,
                                            noticePeriodDaysToTerminate);
            objParam[25] = new SqlParameter(DL.Properties.Resources.TotalWarrantyAmount, totalWarrantyAmount);
            objParam[26] = new SqlParameter(DL.Properties.Resources.RenewalInMonths, renewalInMonths);
            objParam[27] = new SqlParameter(DL.Properties.Resources.ClientNoticeToRenewalInDays,
                                            clientNoticeToRenewalInDays);
            objParam[28] = new SqlParameter(DL.Properties.Resources.Insurance, insurance);
            objParam[29] = new SqlParameter(DL.Properties.Resources.IsAutoRenewal, isAutoRenewal);
            objParam[30] = new SqlParameter(DL.Properties.Resources.IsLimitedWarranty, isLimitedWarranty);
            objParam[31] = new SqlParameter(DL.Properties.Resources.IsScanCopyExists, isScanCopyExists);
            objParam[32] = new SqlParameter(DL.Properties.Resources.IfWeCanTerminate, ifTerminatePossible);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_Update", objParam);
            return ds;
        }
        #endregion

        #region Function Related to delete Data
        /// <summary>
        /// to delete Contract
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterDelete(string contractNumber)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_Delete", objParam);
            return ds;
        }
        #endregion

        #region Function TO get clientName BAsed On ClientCode
        /// <summary>
        /// TO get clientName BAsed On ClientCode
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientNameGet(string clientCode, string locationAutoId)
        {
            Guard.ArgumentConvertibleTo<int>(locationAutoId, "myIntArgument");

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, int.Parse(locationAutoId));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_GetClientNameBasedOnClientCode", objParam);
            return ds;

        }
        #endregion

        #region Function To get Details based on max amend number
        /// <summary>
        /// To get Details based on max amend number
        /// </summary>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterDetailsGet(int amendNo, string clientCode, string contractNumber, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AmendmentNo, amendNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_GetDetailsBasedOnAmendNo", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Get Amend Number
        /// <summary>
        /// To get The amend number of the selected client code
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterAmendNoGet(string clientCode, string contractNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_GetAmendNo", objParam);
            return ds;
        }
        #endregion

        /// <summary>
        /// Clients the list get.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="type">The type.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader ClientListGet(string client, string type)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Name, client);
            objParam[1] = new SqlParameter(DL.Properties.Resources.type, type);
            SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "udpMstSales_ContractMaster_SearchAutoComplete", objParam);
            return reader;
        }
        /// <summary>
        /// To get the search result  [Add location Auto ID Change to be made 12 sep 2008]
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="operatorClientCode">The operator client code.</param>
        /// <param name="andOrClientCode">The and or client code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="operatorClientName">Name of the operator client.</param>
        /// <param name="andOrClientName">Name of the and or client.</param>
        /// <param name="clientAddress">The client address.</param>
        /// <param name="operatorClientAddress">The operator client address.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientSearch(string clientCode, string operatorClientCode, string andOrClientCode, string clientName, string operatorClientName, string andOrClientName, string clientAddress, string operatorClientAddress)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCodeCondition, GenerateWhereCondition("SL.ClientCode", operatorClientCode, clientCode, andOrClientCode));
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientNameCondition, GenerateWhereCondition("SL.ClientName", operatorClientName, clientName, andOrClientName));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientAddressCondition, GenerateWhereCondition("SL.ClientAddress", operatorClientAddress, clientAddress, ""));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSalesClientCode_Search", objParam);
            return ds;
        }
        /// <summary>
        /// Generates the where condition.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="operatorValue">The operator value.</param>
        /// <param name="value">The value.</param>
        /// <param name="andOr">The and or.</param>
        /// <returns>String.</returns>
        public String GenerateWhereCondition(string fieldName, string operatorValue, string value, string andOr)
        {
            string strGenerateWhereCondition;
            if (!string.IsNullOrEmpty(operatorValue) || !string.IsNullOrEmpty(andOr))
            {
                if (operatorValue == "Like" || operatorValue == "Not Like")
                {
                    value = "'%" + value + "%'";
                    strGenerateWhereCondition = fieldName + " " + operatorValue + " " + value + " " + andOr + " ";
                    return strGenerateWhereCondition;
                }
                else
                {
                    strGenerateWhereCondition = fieldName + " " + operatorValue + " '" + value + "' " + andOr + " ";
                    return strGenerateWhereCondition;
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// To get the client details [Normal Search]
        /// </summary>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientSearch(string paramValue, string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Value, paramValue);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_SearchClient", objParam);
            return ds;
        }
        /// <summary>
        /// To Get All Amendment Number Based on the Contract Number
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AmendmentNoBasedOnContractNoGetAll(string contractNumber)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_GetAmendmentNoBasedOnContractNo", objParam);
            return ds;
        }
        /// <summary>
        /// To Upload and save File
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <param name="uploadDesc">The upload desc.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractUpload(string contractNumber, int amendmentNo, string uploadDesc, string fileName, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AmendmentNo, amendmentNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.UploadDesc, uploadDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_ContractUpload", objParam);
            return ds;
        }
        /// <summary>
        /// To Get All files to grid W.R.T ContractNumber,Amendement Number
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterDownload(string contractNumber, int amendmentNo)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AmendmentNo, amendmentNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_DownloadGetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To delete file from grid view
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractUploadDelete(string fileName, string contractNumber, int amendmentNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.FileName, fileName);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AmendmentNo, amendmentNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_ContractMaster_ContractUploadDelete", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Contract Derails Cubic
        #region GetDate
        /// <summary>
        /// To get the Contract Details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractDetailsGet(string locationAutoId, string contractNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SaleContractDetails_GetAll", objParam);
            return ds;
        }
        #endregion
        #region Insert Data
        /// <summary>
        /// To insert data for contract details cubic
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="clientRegNo">The client reg no.</param>
        /// <param name="primInternalArea">The prim internal area.</param>
        /// <param name="accessExitControl">The access exit control.</param>
        /// <param name="passSystemAdmin">The pass system admin.</param>
        /// <param name="screeningServices">The screening services.</param>
        /// <param name="responseServices">The response services.</param>
        /// <param name="otherGuardingServices">The other guarding services.</param>
        /// <param name="technicalServices">The technical services.</param>
        /// <param name="technicalServicesIncomePerMonth">The technical services income per month.</param>
        /// <param name="safetyServices">The safety services.</param>
        /// <param name="safetyServicesIncomePerMonth">The safety services income per month.</param>
        /// <param name="otherServices">The other services.</param>
        /// <param name="otherServicesIncomePerMonth">The other services income per month.</param>
        /// <param name="nuclearRiskCovered">The nuclear risk covered.</param>
        /// <param name="nuclearIncident">The nuclear incident.</param>
        /// <param name="nuclearAggregate">The nuclear aggregate.</param>
        /// <param name="consequentialLosses">The consequential losses.</param>
        /// <param name="consequentialLossesIncident">The consequential losses incident.</param>
        /// <param name="consequentialLossesAggregate">The consequential losses aggregate.</param>
        /// <param name="generalClaimsAnyone">The general claims anyone.</param>
        /// <param name="generalClaimsAggregate">The general claims aggregate.</param>
        /// <param name="thirdPartyIndemnity">The third party indemnity.</param>
        /// <param name="forceMajorClause">The force major clause.</param>
        /// <param name="highRiskContract">The high risk contract.</param>
        /// <param name="personsMoreThenFiveThousand">The persons more then five thousand.</param>
        /// <param name="jurisdiction">The jurisdiction.</param>
        /// <param name="applicableLaw">The applicable law.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractDetailsInsert(string locationAutoId, string contractNumber, string clientRegNo, string primInternalArea, string accessExitControl, string passSystemAdmin, string screeningServices, string responseServices, string otherGuardingServices, string technicalServices, string technicalServicesIncomePerMonth, string safetyServices, string safetyServicesIncomePerMonth, string otherServices, string otherServicesIncomePerMonth, string nuclearRiskCovered, string nuclearIncident, string nuclearAggregate, string consequentialLosses, string consequentialLossesIncident, string consequentialLossesAggregate, string generalClaimsAnyone, string generalClaimsAggregate, string thirdPartyIndemnity, string forceMajorClause, string highRiskContract, string personsMoreThenFiveThousand, string jurisdiction, string applicableLaw, string modifiedBy)
        {

            Guard.ArgumentConvertibleTo<bool>(primInternalArea, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(accessExitControl, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(passSystemAdmin, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(screeningServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(responseServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(otherGuardingServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(technicalServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(safetyServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(otherServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(nuclearRiskCovered, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(consequentialLosses, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(thirdPartyIndemnity, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(forceMajorClause, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(highRiskContract, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(personsMoreThenFiveThousand, "myBoolArgument");


            SqlParameter[] objParam = new SqlParameter[30];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientRegNo, clientRegNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PrimInternalArea, bool.Parse(primInternalArea));
            objParam[4] = new SqlParameter(DL.Properties.Resources.AccessExitControle, bool.Parse(accessExitControl));
            objParam[5] = new SqlParameter(DL.Properties.Resources.PassSystemAdmin, bool.Parse(passSystemAdmin));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ScreeningServices, bool.Parse(screeningServices));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ResponseServices, bool.Parse(responseServices));
            objParam[8] = new SqlParameter(DL.Properties.Resources.OtherGuardingServices, bool.Parse(otherGuardingServices));
            objParam[9] = new SqlParameter(DL.Properties.Resources.TechnicalServices, bool.Parse(technicalServices));
            //Change done in objParam[10]  13-Feb-2013 previously passed  TechnicalServices insteadof TechnicalServicesIncomePerMonth
            objParam[10] = new SqlParameter(DL.Properties.Resources.TechnicalServicesIncomePerMonth, technicalServicesIncomePerMonth);
            objParam[11] = new SqlParameter(DL.Properties.Resources.SafetyServices, bool.Parse(safetyServices));
            objParam[12] = new SqlParameter(DL.Properties.Resources.SafetyServicesIncomePerMonth, safetyServicesIncomePerMonth);
            objParam[13] = new SqlParameter(DL.Properties.Resources.OtherServices, bool.Parse(otherServices));
            objParam[14] = new SqlParameter(DL.Properties.Resources.OtherServicesIncomePerMonth, otherServicesIncomePerMonth);
            objParam[15] = new SqlParameter(DL.Properties.Resources.NuclearRiskCovered, bool.Parse(nuclearRiskCovered));
            objParam[16] = new SqlParameter(DL.Properties.Resources.NuclearIncident, nuclearIncident);
            objParam[17] = new SqlParameter(DL.Properties.Resources.NuclearAggregate, nuclearAggregate);
            objParam[18] = new SqlParameter(DL.Properties.Resources.ConsquentialLosses, bool.Parse(consequentialLosses));
            objParam[19] = new SqlParameter(DL.Properties.Resources.ConsquentialLossesIncident, consequentialLossesIncident);
            objParam[20] = new SqlParameter(DL.Properties.Resources.ConsquentialLossesAggregate, consequentialLossesAggregate);
            objParam[21] = new SqlParameter(DL.Properties.Resources.GeneralClaimsAnyOne, generalClaimsAnyone);
            objParam[22] = new SqlParameter(DL.Properties.Resources.GeneralClaimsAggregate, generalClaimsAggregate);
            objParam[23] = new SqlParameter(DL.Properties.Resources.ThirdPartyIndemnity, bool.Parse(thirdPartyIndemnity));
            objParam[24] = new SqlParameter(DL.Properties.Resources.ForceMajeureClause, bool.Parse(forceMajorClause));
            objParam[25] = new SqlParameter(DL.Properties.Resources.HighRiskContract, bool.Parse(highRiskContract));
            objParam[26] = new SqlParameter(DL.Properties.Resources.PersonsMoreThenFiveThousand, bool.Parse(personsMoreThenFiveThousand));
            objParam[27] = new SqlParameter(DL.Properties.Resources.Jurisdiction, jurisdiction);
            objParam[28] = new SqlParameter(DL.Properties.Resources.ApplicaleLaw, applicableLaw);
            objParam[29] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SaleContractDetails_Insert", objParam);
            return ds;
        }
        #endregion
        #region Update Data
        /// <summary>
        /// To update Contract details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="clientRegNo">The client reg no.</param>
        /// <param name="primInternalArea">The prim internal area.</param>
        /// <param name="accessExitControl">The access exit control.</param>
        /// <param name="passSystemAdmin">The pass system admin.</param>
        /// <param name="screeningServices">The screening services.</param>
        /// <param name="responseServices">The response services.</param>
        /// <param name="otherGuardingServices">The other guarding services.</param>
        /// <param name="technicalServices">The technical services.</param>
        /// <param name="technicalServicesIncomePerMonth">The technical services income per month.</param>
        /// <param name="safetyServices">The safety services.</param>
        /// <param name="safetyServicesIncomePerMonth">The safety services income per month.</param>
        /// <param name="otherServices">The other services.</param>
        /// <param name="otherServicesIncomePerMonth">The other services income per month.</param>
        /// <param name="nuclearRiskCovered">The nuclear risk covered.</param>
        /// <param name="nuclearIncident">The nuclear incident.</param>
        /// <param name="nuclearAggregate">The nuclear aggregate.</param>
        /// <param name="consequentialLosses">The consequential losses.</param>
        /// <param name="consequentialLossesIncident">The consequential losses incident.</param>
        /// <param name="consequentialLossesAggregate">The consequential losses aggregate.</param>
        /// <param name="generalClaimsAnyone">The general claims anyone.</param>
        /// <param name="generalClaimsAggregate">The general claims aggregate.</param>
        /// <param name="thirdPartyIndemnity">The third party indemnity.</param>
        /// <param name="forceMajorClause">The force major clause.</param>
        /// <param name="highRiskContract">The high risk contract.</param>
        /// <param name="personsMoreThenFiveThousand">The persons more then five thousand.</param>
        /// <param name="jurisdiction">The jurisdiction.</param>
        /// <param name="applicableLaw">The applicable law.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractDetailsUpdate(string locationAutoId, string contractNumber, string clientRegNo, string primInternalArea, string accessExitControl, string passSystemAdmin, string screeningServices, string responseServices, string otherGuardingServices, string technicalServices, string technicalServicesIncomePerMonth, string safetyServices, string safetyServicesIncomePerMonth, string otherServices, string otherServicesIncomePerMonth, string nuclearRiskCovered, string nuclearIncident, string nuclearAggregate, string consequentialLosses, string consequentialLossesIncident, string consequentialLossesAggregate, string generalClaimsAnyone, string generalClaimsAggregate, string thirdPartyIndemnity, string forceMajorClause, string highRiskContract, string personsMoreThenFiveThousand, string jurisdiction, string applicableLaw, string modifiedBy)
        {

            Guard.ArgumentConvertibleTo<bool>(primInternalArea, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(accessExitControl, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(passSystemAdmin, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(screeningServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(responseServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(otherGuardingServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(technicalServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(safetyServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(otherServices, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(nuclearRiskCovered, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(consequentialLosses, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(thirdPartyIndemnity, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(forceMajorClause, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(highRiskContract, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(personsMoreThenFiveThousand, "myBoolArgument");

            SqlParameter[] objParam = new SqlParameter[30];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientRegNo, clientRegNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PrimInternalArea, bool.Parse(primInternalArea));
            objParam[4] = new SqlParameter(DL.Properties.Resources.AccessExitControle, bool.Parse(accessExitControl));
            objParam[5] = new SqlParameter(DL.Properties.Resources.PassSystemAdmin, bool.Parse(passSystemAdmin));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ScreeningServices, bool.Parse(screeningServices));
            objParam[7] = new SqlParameter(DL.Properties.Resources.ResponseServices, bool.Parse(responseServices));
            objParam[8] = new SqlParameter(DL.Properties.Resources.OtherGuardingServices, bool.Parse(otherGuardingServices));
            objParam[9] = new SqlParameter(DL.Properties.Resources.TechnicalServices, bool.Parse(technicalServices));
            //Change done in objParam[10]  13-Feb-2013
            objParam[10] = new SqlParameter(DL.Properties.Resources.TechnicalServicesIncomePerMonth, technicalServicesIncomePerMonth);
            objParam[11] = new SqlParameter(DL.Properties.Resources.SafetyServices, bool.Parse(safetyServices));
            objParam[12] = new SqlParameter(DL.Properties.Resources.SafetyServicesIncomePerMonth, safetyServicesIncomePerMonth);
            objParam[13] = new SqlParameter(DL.Properties.Resources.OtherServices, bool.Parse(otherServices));
            objParam[14] = new SqlParameter(DL.Properties.Resources.OtherServicesIncomePerMonth, otherServicesIncomePerMonth);
            objParam[15] = new SqlParameter(DL.Properties.Resources.NuclearRiskCovered, bool.Parse(nuclearRiskCovered));
            objParam[16] = new SqlParameter(DL.Properties.Resources.NuclearIncident, nuclearIncident);
            objParam[17] = new SqlParameter(DL.Properties.Resources.NuclearAggregate, nuclearAggregate);
            objParam[18] = new SqlParameter(DL.Properties.Resources.ConsquentialLosses, bool.Parse(consequentialLosses));
            objParam[19] = new SqlParameter(DL.Properties.Resources.ConsquentialLossesIncident, consequentialLossesIncident);
            objParam[20] = new SqlParameter(DL.Properties.Resources.ConsquentialLossesAggregate, consequentialLossesAggregate);
            objParam[21] = new SqlParameter(DL.Properties.Resources.GeneralClaimsAnyOne, generalClaimsAnyone);
            objParam[22] = new SqlParameter(DL.Properties.Resources.GeneralClaimsAggregate, generalClaimsAggregate);
            objParam[23] = new SqlParameter(DL.Properties.Resources.ThirdPartyIndemnity, bool.Parse(thirdPartyIndemnity));
            objParam[24] = new SqlParameter(DL.Properties.Resources.ForceMajeureClause, bool.Parse(forceMajorClause));
            objParam[25] = new SqlParameter(DL.Properties.Resources.HighRiskContract, bool.Parse(highRiskContract));
            objParam[26] = new SqlParameter(DL.Properties.Resources.PersonsMoreThenFiveThousand, bool.Parse(personsMoreThenFiveThousand));
            objParam[27] = new SqlParameter(DL.Properties.Resources.Jurisdiction, jurisdiction);
            objParam[28] = new SqlParameter(DL.Properties.Resources.ApplicaleLaw, applicableLaw);
            objParam[29] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SaleContractDetails_Update", objParam);
            return ds;
        }
        #endregion
        #region Delete Data
        /// <summary>
        /// Contracts the details delete.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractDetailsDelete(string locationAutoId, string contractNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_SaleContractDetails_Delete", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to SO

        #region SaleOrder Get Functions
        /// <summary>
        /// to get SaleOrder Information for a Location and a Client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="deleteStatus">The delete status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderInfoGet(string locationAutoId, string clientCode, string asmtId, string deleteStatus)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SoDelStatus, deleteStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SO_Get4LocClient", objParm);
            return ds;
        }
        /// <summary>
        /// To get Sale Orders of Given LocationAutoID
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderGet(string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_GetAllSoofLoc", objParm);
            return ds;
        }
        /// <summary>
        /// To get Sale Orders of Given LocationAutoID, SaleOrder and SoAmendNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderGet(string locationAutoId, string soNo, string soAmendNo)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SO_Get", objParm);
            return ds;
        }
        /// <summary>
        /// Get Sale Order Service Details For LocationAutoId, SONO, SOAmendNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailGet(string locationAutoId, string soNo, string soAmendNo, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODetails_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Get Sale Order Service Details For LocationAutoId, SONO, SOAmendNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailGet(string locationAutoId, string soNo, string soAmendNo, string asmtId, string areaIncharge)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODetails_Get4Incharge", objParam);
            return ds;
        }

        /// <summary>
        /// Sales the order detail get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailGet(string locationAutoId, string soNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, "");
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODetails_Get", objParam);
            return ds;
        }

        /// <summary>
        /// returns the new created Soline No
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailGetSolineNo(string locationAutoId, string soNo, string soAmendNo, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSaleSODetailsGetNewSolineNo", objParam);
            return ds;
        }

        /// <summary>
        /// Get Sale Order Item Details For LocationAutoId, SONO, SOAmendNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDetailsGet(string locationAutoId, string soNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOItemDetails_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Get Assignment Address of Sale Order Details For LocationAutoID Sono and SOAmendementNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailsGet(string locationAutoId, string clientCode, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_GetSODetOfSOLines", objParam);
            return ds;
        }
        /// <summary>
        /// Get Sale Order Details For locationAutoId, Sono, SOAmendementNo and asmtId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailsGet(string locationAutoId, string soNo, string soAmendNo, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_GetSODet", objParam);
            return ds;
        }
        /// <summary>
        /// Get SaleOrderAmendement Numbers For LocationAutoID and SaleOrder
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderAmendNoGet(string locationAutoId, string soNo)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Sale_AmendNoofSO_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// Get AsmtID For LocationAutoID SONO and SOAmendementNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtIdGet(string locationAutoId, string soNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_GetallAsmtIdofSO", objParam);
            return ds;
        }
        /// <summary>
        /// To get SoType
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderTypeGet(string locationAutoId, string soNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTrans_AsmtCreation_SOTypeGet", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Deployment Pattren for a company with ItemDesc and DeploymentPattern
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeDeploymentPatternGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_DeploymentPattern_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Quicks the code2 items get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="quickCode">The quick code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCode2ItemsGet(string companyCode, string quickCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.QuickCode, quickCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstQuickCode_QuickCode2Items_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To View All So OF the Selected Contract number and ClientCode [ContractMaster View So Click]
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderViewGet(string contractNumber, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ViewSO_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order maximum amend no get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderMaxAmendNoGet(string locationAutoId, string soNo)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtShift_MaxSoAmendNo_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get Fresh and Amend Sale Orders
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="statusFresh">The status fresh.</param>
        /// <param name="statusAmend">The status amend.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PendingSaleOrdersGet(string locationAutoId, string statusFresh, string statusAmend, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.StatusFresh, statusFresh);
            objParam[2] = new SqlParameter(DL.Properties.Resources.StatusAmend, statusAmend);
            objParam[3] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MstSalePendingSO_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order detail maximum authorized no of post get.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailMaximumAuthorizedNoOfPostGet(string soNo, int soLineNo, int locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SaleOrderDetails_GetMaximumAuthorizedNoOfPost", objParam);
            return ds;
        }



        #endregion

        #region SaleOrder Save Functions
        /// <summary>
        /// To save a new record of Sale Order Master
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="wefDate">The wef date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soStatus">The so status.</param>
        /// <param name="soTerminationDate">The so termination date.</param>
        /// <param name="soTerminationReason">The so termination reason.</param>
        /// <param name="soTerminatedBy">The so terminated by.</param>
        /// <param name="soType">Type of the so.</param>
        /// <param name="isCentralizedBilling">if set to <c>true</c> [is centralized billing].</param>
        /// <param name="centralizedBillingLocationAutoId">The centralized billing location automatic identifier.</param>
        /// <param name="asmtBillingId">The asmt billing identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="remarks">The remarks.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderMasterSave(string locationAutoId, string wefDate, string clientCode, string soStatus, string soTerminationDate, string soTerminationReason, string soTerminatedBy, string soType, bool isCentralizedBilling, string centralizedBillingLocationAutoId, string asmtBillingId, string modifiedBy, string invoiceType, string remarks, string QuotationNo)
        {
            SqlParameter[] objParam = new SqlParameter[15];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            if (string.IsNullOrEmpty(wefDate))
            {
                objParam[1] = new SqlParameter(DL.Properties.Resources.WEFDate, DBNull.Value);
            }
            else
            {
                objParam[1] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(wefDate));
            }
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            if (string.IsNullOrEmpty(soTerminationDate))
            {
                objParam[4] = new SqlParameter(DL.Properties.Resources.SoTerminationDate, DBNull.Value);
            }
            else
            {
                objParam[4] = new SqlParameter(DL.Properties.Resources.SoTerminationDate, DL.Common.DateFormat(soTerminationDate));
            }

            objParam[5] = new SqlParameter(DL.Properties.Resources.SoTerminationReason, soTerminationReason);
            objParam[6] = new SqlParameter(DL.Properties.Resources.SOTerminatedBy, soTerminatedBy);
            objParam[7] = new SqlParameter(DL.Properties.Resources.SOType, soType);
            objParam[8] = new SqlParameter(DL.Properties.Resources.CenterlizeBilling, isCentralizedBilling);
            if (string.IsNullOrEmpty(centralizedBillingLocationAutoId))
            {
                objParam[9] = new SqlParameter(DL.Properties.Resources.CenterlizeBillingLocationAutoId, DBNull.Value);
            }
            else
            {
                Guard.ArgumentConvertibleTo<Int32>(centralizedBillingLocationAutoId, "myInt32Argument");
                objParam[9] = new SqlParameter(DL.Properties.Resources.CenterlizeBillingLocationAutoId, Int32.Parse(centralizedBillingLocationAutoId));
            }
            objParam[10] = new SqlParameter(DL.Properties.Resources.AsmtBillingId, asmtBillingId);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[12] = new SqlParameter(DL.Properties.Resources.InvoiceType, invoiceType);
            objParam[13] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            objParam[14] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOMaster_saveNew", objParam);
            return ds;
        }
        /// <summary>
        /// To save a new record in sale rder service details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="billingDesignation">The billing designation.</param>
        /// <param name="noOfPost">The no of post.</param>
        /// <param name="hours">The hours.</param>
        /// <param name="deploymentPattern">The deployment pattern.</param>
        /// <param name="minManpower">The minimum manpower.</param>
        /// <param name="maxManpower">The maximum manpower.</param>
        /// <param name="daysInMonth">The days in month.</param>
        /// <param name="hoursInMonth">The hours in month.</param>
        /// <param name="soLineStartDate">The so line start date.</param>
        /// <param name="soLineEndDate">The so line end date.</param>
        /// <param name="soLineWefDate">The so line wef date.</param>
        /// <param name="typeOfService">The type of service.</param>
        /// <param name="typeOfItem">The type of item.</param>
        /// <param name="billable">if set to <c>true</c> [billable].</param>
        /// <param name="active">if set to <c>true</c> [active].</param>
        /// <param name="minWages">The minimum wages.</param>
        /// <param name="otherAllowances">The other allowances.</param>
        /// <param name="allowancesMode">The allowances mode.</param>
        /// <param name="isAllowanceBillable">if set to <c>true</c> [is allowance billable].</param>
        /// <param name="chargeRatePerHrs">The charge rate per HRS.</param>
        /// <param name="sellingPrice">The selling price.</param>
        /// <param name="minProfitability">The minimum profitability.</param>
        /// <param name="optimumProfitability">The optimum profitability.</param>
        /// <param name="serviceCategoryCode">The service category code.</param>
        /// <param name="postposition">The postposition.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="payRateType">Type of the pay rate.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailAddNew(string locationAutoId, string soNo, string soAmendNo, string contractNumber, string asmtId, 
                                            string postAutoId, string soRank, string billingDesignation, string noOfPost, string hours, 
                                            string deploymentPattern, string minManpower, string maxManpower, string daysInMonth, string hoursInMonth, 
                                            string soLineStartDate, string soLineEndDate, string soLineWefDate, string typeOfService, string typeOfItem, 
                                            bool billable, bool active, string minWages, string otherAllowances, string allowancesMode, bool isAllowanceBillable, 
                                            string chargeRatePerHrs, double sellingPrice, string minProfitability, string optimumProfitability, string serviceCategoryCode,
                                            string postposition, string modifiedBy, string payRateType)
        {
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(postAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(noOfPost, "myInt32Argument");
            Guard.ArgumentConvertibleTo<decimal>(hours, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(minManpower, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(maxManpower, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(hoursInMonth, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(minWages, "myDecimalArgument");

            SqlParameter[] objParam = new SqlParameter[34];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objParam[6] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[7] = new SqlParameter(DL.Properties.Resources.BillingDesignation, billingDesignation);
            objParam[8] = new SqlParameter(DL.Properties.Resources.NoOfPost, Int32.Parse(noOfPost));
            objParam[9] = new SqlParameter(DL.Properties.Resources.Hours, decimal.Parse(hours));
            objParam[10] = new SqlParameter(DL.Properties.Resources.DeploymentPattern, deploymentPattern);
            objParam[11] = new SqlParameter(DL.Properties.Resources.MinManPower, Int32.Parse(Math.Ceiling(decimal.Parse(minManpower)).ToString()));
            objParam[12] = new SqlParameter(DL.Properties.Resources.MaxManPower, Int32.Parse(Math.Ceiling(decimal.Parse(maxManpower)).ToString()));
            objParam[13] = new SqlParameter(DL.Properties.Resources.DaysInMonth, "0");
            objParam[14] = new SqlParameter(DL.Properties.Resources.HoursInMonth, decimal.Parse(hoursInMonth));
            objParam[15] = new SqlParameter(DL.Properties.Resources.SOLineStartDate, DL.Common.DateFormat(soLineStartDate));
            objParam[16] = new SqlParameter(DL.Properties.Resources.SOLineEndDate, DL.Common.DateFormat(soLineEndDate));
            objParam[17] = new SqlParameter(DL.Properties.Resources.SOLineWEFDate, DL.Common.DateFormat(soLineWefDate));
            objParam[18] = new SqlParameter(DL.Properties.Resources.TypeOfService, typeOfService);
            objParam[19] = new SqlParameter(DL.Properties.Resources.TypeOfItem, typeOfItem);
            objParam[20] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[21] = new SqlParameter(DL.Properties.Resources.Active, active);
            objParam[22] = new SqlParameter(DL.Properties.Resources.MinWages, decimal.Parse(minWages));
            objParam[23] = new SqlParameter(DL.Properties.Resources.OtherAllowances, otherAllowances);
            objParam[24] = new SqlParameter(DL.Properties.Resources.AllowancesMode, allowancesMode);
            objParam[25] = new SqlParameter(DL.Properties.Resources.ISAllowanceBillable, isAllowanceBillable);
            objParam[26] = new SqlParameter(DL.Properties.Resources.SellingPrice, sellingPrice);
            objParam[27] = new SqlParameter(DL.Properties.Resources.ChargeRatePerHrs, chargeRatePerHrs);
            objParam[28] = new SqlParameter(DL.Properties.Resources.MinProfitability, minProfitability);
            objParam[29] = new SqlParameter(DL.Properties.Resources.OptimumProfitability, optimumProfitability);
            objParam[30] = new SqlParameter(DL.Properties.Resources.ServiceCategoryCode, serviceCategoryCode);
            objParam[31] = new SqlParameter(DL.Properties.Resources.PostPosition, postposition);
            objParam[32] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[33] = new SqlParameter(DL.Properties.Resources.PayRateType, payRateType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOServiceDetails_saveNew", objParam);
            return ds;
        }
        /// <summary>
        /// To save a new record in Sale Order Item Details
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="rate">The rate.</param>
        /// <param name="billable">if set to <c>true</c> [billable].</param>
        /// <param name="active">if set to <c>true</c> [active].</param>
        /// <param name="itemStartDate">The item start date.</param>
        /// <param name="itemEndDate">The item end date.</param>
        /// <param name="itemWefDate">The item wef date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDetailAddNew(string soNo, string soAmendNo, string itemTypeCode, string contractNumber, string quantity, string rate, bool billable, bool active, string itemStartDate, string itemEndDate, string itemWefDate, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[12];

            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<decimal>(quantity, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(rate, "myDecimalArgument");
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Qty, decimal.Parse(quantity));
            objParam[5] = new SqlParameter(DL.Properties.Resources.Rate, decimal.Parse(rate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Active, active);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ItemStartDate, DL.Common.DateFormat(itemStartDate));
            objParam[9] = new SqlParameter(DL.Properties.Resources.ItemEndDate, DL.Common.DateFormat(itemEndDate));
            objParam[10] = new SqlParameter(DL.Properties.Resources.ItemWEFDate, DL.Common.DateFormat(itemWefDate));
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOItemDetails_saveNew", objParam);
            return ds;
        }

        #endregion

        #region SaleOrder Update Functions
        /// <summary>
        /// To Update the Sale Order Master in case of Fresh and Amend
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="wefDate">The wef date.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="soStatus">The so status.</param>
        /// <param name="soTerminationDate">The so termination date.</param>
        /// <param name="soTerminationReason">The so termination reason.</param>
        /// <param name="soTerminatedBy">The so terminated by.</param>
        /// <param name="soType">Type of the so.</param>
        /// <param name="isCentralizedBilling">if set to <c>true</c> [is centralized billing].</param>
        /// <param name="centralizedBillingLocationAutoId">The centralized billing location automatic identifier.</param>
        /// <param name="asmtBillingId">The asmt billing identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="myStatus">My status.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="remarks">The remarks.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderMasterUpdate(string locationAutoId, string soNo, string soAmendNo, string wefDate, string clientCode, string soStatus, string soTerminationDate, string soTerminationReason, string soTerminatedBy, string soType, bool isCentralizedBilling, string centralizedBillingLocationAutoId, string asmtBillingId, string modifiedBy, string myStatus, string invoiceType, string remarks)
        {
            SqlParameter[] objParam = new SqlParameter[17];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            if (string.IsNullOrEmpty(wefDate))
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.WEFDate, DBNull.Value);
            }
            else
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(wefDate));
            }
            objParam[4] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            if (string.IsNullOrEmpty(soTerminationDate))
            {
                objParam[6] = new SqlParameter(DL.Properties.Resources.SoTerminationDate, DBNull.Value);
            }
            else
            {
                objParam[6] = new SqlParameter(DL.Properties.Resources.SoTerminationDate, DL.Common.DateFormat(soTerminationDate));
            }

            objParam[7] = new SqlParameter(DL.Properties.Resources.SoTerminationReason, soTerminationReason);
            objParam[8] = new SqlParameter(DL.Properties.Resources.SOTerminatedBy, soTerminatedBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.SOType, soType);
            objParam[10] = new SqlParameter(DL.Properties.Resources.CenterlizeBilling, isCentralizedBilling);
            if (string.IsNullOrEmpty(centralizedBillingLocationAutoId))
            {
                objParam[11] = new SqlParameter(DL.Properties.Resources.CenterlizeBillingLocationAutoId, DBNull.Value);
            }
            else
            {
                Guard.ArgumentConvertibleTo<Int32>(centralizedBillingLocationAutoId, "myInt32Argument");
                objParam[11] = new SqlParameter(DL.Properties.Resources.CenterlizeBillingLocationAutoId, Int32.Parse(centralizedBillingLocationAutoId));
            }
            objParam[12] = new SqlParameter(DL.Properties.Resources.AsmtBillingId, asmtBillingId);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[14] = new SqlParameter(DL.Properties.Resources.MyStatus, myStatus);
            objParam[15] = new SqlParameter(DL.Properties.Resources.InvoiceType, invoiceType);
            objParam[16] = new SqlParameter(DL.Properties.Resources.Remarks, remarks);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOMaster_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To update the sale Order service Details for a SOLine Number
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="billingDesignation">The billing designation.</param>
        /// <param name="noOfPost">The no of post.</param>
        /// <param name="hours">The hours.</param>
        /// <param name="deploymentPattern">The deployment pattern.</param>
        /// <param name="minManpower">The minimum manpower.</param>
        /// <param name="maxManpower">The maximum manpower.</param>
        /// <param name="daysInMonth">The days in month.</param>
        /// <param name="hoursInMonth">The hours in month.</param>
        /// <param name="soLineStartDate">The so line start date.</param>
        /// <param name="soLineEndDate">The so line end date.</param>
        /// <param name="soLineWefDate">The so line wef date.</param>
        /// <param name="typeOfService">The type of service.</param>
        /// <param name="typeOfItem">The type of item.</param>
        /// <param name="billable">if set to <c>true</c> [billable].</param>
        /// <param name="active">if set to <c>true</c> [active].</param>
        /// <param name="minWages">The minimum wages.</param>
        /// <param name="otherAllowances">The other allowances.</param>
        /// <param name="allowancesMode">The allowances mode.</param>
        /// <param name="isAllowanceBillable">if set to <c>true</c> [is allowance billable].</param>
        /// <param name="chargeRatePerHrs">The charge rate per HRS.</param>
        /// <param name="sellingPrice">The selling price.</param>
        /// <param name="minProfitability">The minimum profitability.</param>
        /// <param name="optimumProfitability">The optimum profitability.</param>
        /// <param name="serviceCategoryCode">The service category code.</param>
        /// <param name="postposition">The postposition.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="strStatusFresh">The string status fresh.</param>
        /// <param name="payRateType">Type of the pay rate.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailUpdate(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string contractNumber, string asmtId, string postAutoId, string soRank, string billingDesignation, string noOfPost, string hours, string deploymentPattern, string minManpower, string maxManpower, string daysInMonth, string hoursInMonth, string soLineStartDate, string soLineEndDate, string soLineWefDate, string typeOfService, string typeOfItem, bool billable, bool active, string minWages, string otherAllowances, string allowancesMode, bool isAllowanceBillable, double chargeRatePerHrs, string sellingPrice, string minProfitability, string optimumProfitability, string serviceCategoryCode, string postposition, string modifiedBy, string strStatusFresh,string payRateType)
        {
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(postAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(noOfPost, "myInt32Argument");
            Guard.ArgumentConvertibleTo<decimal>(hours, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(minManpower, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(maxManpower, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(daysInMonth, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(hoursInMonth, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(minWages, "myDecimalArgument");


            SqlParameter[] objParam = new SqlParameter[36];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[5] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[6] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objParam[7] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[8] = new SqlParameter(DL.Properties.Resources.BillingDesignation, billingDesignation);
            objParam[9] = new SqlParameter(DL.Properties.Resources.NoOfPost, Int32.Parse(noOfPost));
            objParam[10] = new SqlParameter(DL.Properties.Resources.Hours, decimal.Parse(hours));
            objParam[11] = new SqlParameter(DL.Properties.Resources.DeploymentPattern, deploymentPattern);
            objParam[12] = new SqlParameter(DL.Properties.Resources.MinManPower, Int32.Parse(Math.Ceiling(decimal.Parse(minManpower)).ToString()));
            objParam[13] = new SqlParameter(DL.Properties.Resources.MaxManPower, Int32.Parse(Math.Ceiling(decimal.Parse(maxManpower)).ToString()));
            objParam[14] = new SqlParameter(DL.Properties.Resources.DaysInMonth, decimal.Parse(daysInMonth));
            objParam[15] = new SqlParameter(DL.Properties.Resources.HoursInMonth, decimal.Parse(hoursInMonth));
            objParam[16] = new SqlParameter(DL.Properties.Resources.SOLineStartDate, DL.Common.DateFormat(soLineStartDate));
            objParam[17] = new SqlParameter(DL.Properties.Resources.SOLineEndDate, DL.Common.DateFormat(soLineEndDate));
            objParam[18] = new SqlParameter(DL.Properties.Resources.SOLineWEFDate, DL.Common.DateFormat(soLineWefDate));
            objParam[19] = new SqlParameter(DL.Properties.Resources.TypeOfService, typeOfService);
            objParam[20] = new SqlParameter(DL.Properties.Resources.TypeOfItem, typeOfItem);
            objParam[21] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[22] = new SqlParameter(DL.Properties.Resources.Active, active);
            objParam[23] = new SqlParameter(DL.Properties.Resources.MinWages, decimal.Parse(minWages));
            objParam[24] = new SqlParameter(DL.Properties.Resources.OtherAllowances, otherAllowances);
            objParam[25] = new SqlParameter(DL.Properties.Resources.AllowancesMode, allowancesMode);
            objParam[26] = new SqlParameter(DL.Properties.Resources.ISAllowanceBillable, isAllowanceBillable);
            objParam[27] = new SqlParameter(DL.Properties.Resources.ChargeRatePerHrs, chargeRatePerHrs);
            objParam[28] = new SqlParameter(DL.Properties.Resources.SellingPrice, sellingPrice);
            objParam[29] = new SqlParameter(DL.Properties.Resources.MinProfitability, minProfitability);
            objParam[30] = new SqlParameter(DL.Properties.Resources.OptimumProfitability, optimumProfitability);
            objParam[31] = new SqlParameter(DL.Properties.Resources.ServiceCategoryCode, serviceCategoryCode);
            objParam[32] = new SqlParameter(DL.Properties.Resources.PostPosition, postposition);
            objParam[33] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[34] = new SqlParameter(DL.Properties.Resources.StatusFresh, strStatusFresh);
            objParam[35] = new SqlParameter(DL.Properties.Resources.PayRateType, payRateType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOServiceDetails_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To update sale Order Item Details when Sale order is in Fresh or amend Mode
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="rate">The rate.</param>
        /// <param name="billable">if set to <c>true</c> [billable].</param>
        /// <param name="active">if set to <c>true</c> [active].</param>
        /// <param name="itemStartDate">The item start date.</param>
        /// <param name="itemEndDate">The item end date.</param>
        /// <param name="itemWefDate">The item wef date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDetailUpdate( string soNo, string soAmendNo, string itemTypeCode, string contractNumber, string quantity, string rate, bool billable, bool active, string itemStartDate, string itemEndDate, string itemWefDate, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[12];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<decimal>(quantity, "myDecimalArgument");
            Guard.ArgumentConvertibleTo<decimal>(rate, "myDecimalArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Qty, decimal.Parse(quantity));
            objParam[5] = new SqlParameter(DL.Properties.Resources.Rate, decimal.Parse(rate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Active, active);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ItemStartDate, DL.Common.DateFormat(itemStartDate));
            objParam[9] = new SqlParameter(DL.Properties.Resources.ItemEndDate, DL.Common.DateFormat(itemEndDate));
            objParam[10] = new SqlParameter(DL.Properties.Resources.ItemWEFDate, DL.Common.DateFormat(itemWefDate));
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOItemDetails_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Sellings the days in month get.
        /// </summary>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SellingDaysInMonthGet(string soLineNo, string locationAutoId, string soNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_SOServiceDetails_GetSellingdaysInMonth", objParam);
            return ds;
        }
        /// <summary>
        /// Sellings the price update.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="sellingPrice">The selling price.</param>
        /// <param name="daysInMonth">The days in month.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SellingPriceUpdate(string soNo, string soAmendNo, string soLineNo, string locationAutoId, string sellingPrice, string daysInMonth, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[4] = new SqlParameter(DL.Properties.Resources.SellingPrice, sellingPrice);
            objParam[5] = new SqlParameter(DL.Properties.Resources.DaysInMonth, daysInMonth);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_SOServiceDetails_UpdateSellingPrice", objParam);
            return ds;
        }
        /// <summary>
        /// Services the details shift update.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="sellingPrice">The selling price.</param>
        /// <param name="daysInMonth">The days in month.</param>
        /// <param name="hoursInMonth">The hours in month.</param>
        /// <param name="payPrice">The pay price.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ServiceDetailsShiftUpdate(string soNo, string soAmendNo, string soLineNo, string locationAutoId, string sellingPrice, string daysInMonth, string hoursInMonth, string payPrice, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[4] = new SqlParameter(DL.Properties.Resources.SellingPrice, sellingPrice);
            objParam[5] = new SqlParameter(DL.Properties.Resources.DaysInMonth, daysInMonth);
            objParam[6] = new SqlParameter(DL.Properties.Resources.HoursInMonth, hoursInMonth);
            objParam[7] = new SqlParameter(DL.Properties.Resources.PayPrice, payPrice);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_SOServiceDetailsFromDeptShift_Update", objParam);
            return ds;
        }
        #endregion

        #region SaleOrder Delete Functions
        /// <summary>
        /// To delete a Sale Order only when it is in Fresh Mode
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDelete(string locationAutoId, string soNo)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SO_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order details delete.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailsDelete(string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Sno, soLineNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODetailsDetails_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To delete a Sale rder Item only if it is in Fresh mode
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="itemStartDate">The item start date.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDetailsDelete(string soNo, string soAmendNo, string itemTypeCode, string contractNumber,string itemStartDate)
        {
            SqlParameter[] objParam = new SqlParameter[5];

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ContractNumber, contractNumber);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ItemStartDate, DL.Common.DateFormat(itemStartDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOItemDetails_Delete", objParam);
            return ds;
        }
        #endregion

        /// <summary>
        /// Sales the order short close.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soStatus">The so status.</param>
        /// <param name="soStatusAuthorized">The so status authorized.</param>
        /// <param name="soStatusShortClosed">The so status short closed.</param>
        /// <param name="statusTerminated">The status terminated.</param>
        /// <param name="terminationDate">The termination date.</param>
        /// <param name="terminationReason">The termination reason.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderShortClose(string locationAutoId, string soNo, string soStatus, string soStatusAuthorized, string soStatusShortClosed, string statusTerminated, string terminationDate, string terminationReason, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoStatusAuthorized, soStatusAuthorized);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SoStatusShortClosed, soStatusShortClosed);
            objParam[5] = new SqlParameter(DL.Properties.Resources.StatusTerminated, statusTerminated);
            objParam[6] = new SqlParameter(DL.Properties.Resources.TerminationDate, DL.Common.DateFormat(terminationDate));
            objParam[7] = new SqlParameter(DL.Properties.Resources.TerminationReason, terminationReason);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_SoNo_ShortClose", objParam);
            return ds;
        }

        #region Function Related to SaleOrder Amendement
        /// <summary>
        /// Sales the order master amend.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soStatus">The so status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="myStatus">My status.</param>
        /// <param name="wefDate">The wef date.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderMasterAmend(string locationAutoId, string soNo, string soStatus, string modifiedBy, string myStatus, string wefDate)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(DL.Properties.Resources.MyStatus, myStatus);
            objParam[5] = new SqlParameter(DL.Properties.Resources.WEFDate, DL.Common.DateFormat(wefDate));
            objParam[6] = new SqlParameter(DL.Properties.Resources.Status, "");
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOMaster_Amend", objParam);
            return ds;
        }
        #endregion
        #region function related to saleOrder Authorization
        /// <summary>
        /// Sales the order master authorized.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soStatus">The so status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="myStatus">My status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderMasterAuthorized(string locationAutoId, string soNo, string soAmendNo, string soStatus, string modifiedBy, string myStatus)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(DL.Properties.Resources.MyStatus, myStatus);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOMaster_Authorized", objParam);
            return ds;
        }
        #endregion
        #region function related SaleOrder Deletion
        /// <summary>
        /// Sales the order delete.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soStatus">The so status.</param>
        /// <param name="soStatusFresh">The so status fresh.</param>
        /// <param name="soStatusDeleted">The so status deleted.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDelete(string locationAutoId, string soNo, string soStatus, string soStatusFresh, string soStatusDeleted, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOStatus, soStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoStatusFresh, soStatusFresh);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SoStatusDeleted, soStatusDeleted);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_SoNo_Delete", objParam);
            return ds;
        }
        #endregion

        /// <summary>
        /// Days in month from system parameters
        /// </summary>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <returns>Data Set</returns>
        public DataSet DaysInMonthSysParamGet(string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_DaysInMonthSysParamGet", objParam);
            return ds;
        }
        #endregion

        #region Sale order Shift Break Mechanism

        /// <summary>
        /// Sales the order deployment shifts break get.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="weekNo">The week no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsBreakGet(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string shiftCode, string weekNo)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShiftBreak_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Sales the order deployment shifts break insert.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="monTimeFrom">The mon time from.</param>
        /// <param name="monTimeTo">The mon time to.</param>
        /// <param name="tueTimeFrom">The tue time from.</param>
        /// <param name="tueTimeTo">The tue time to.</param>
        /// <param name="wedTimeFrom">The wed time from.</param>
        /// <param name="wedTimeTo">The wed time to.</param>
        /// <param name="thuTimeFrom">The thu time from.</param>
        /// <param name="thuTimeTo">The thu time to.</param>
        /// <param name="friTimeFrom">The fri time from.</param>
        /// <param name="friTimeTo">The fri time to.</param>
        /// <param name="satTimeFrom">The sat time from.</param>
        /// <param name="satTimeTo">The sat time to.</param>
        /// <param name="sunTimeFrom">The sun time from.</param>
        /// <param name="sunTimeTo">The sun time to.</param>
        /// <param name="holidayTimeFrom">The holiday Time From</param>
        /// <param name="holidayTimeTo">The holiday Time To</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="billable">The billable.</param>
        /// <param name="payable">The payable.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsBreakInsert(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string weekNo, string shiftCode,
          string monTimeFrom, string monTimeTo,
          string tueTimeFrom, string tueTimeTo,
          string wedTimeFrom, string wedTimeTo,
          string thuTimeFrom, string thuTimeTo,
          string friTimeFrom, string friTimeTo,
          string satTimeFrom, string satTimeTo,
          string sunTimeFrom, string sunTimeTo,
          string holidayTimeFrom, string holidayTimeTo,
          string modifiedBy, string billable, string payable
          )
        {
            SqlParameter[] objParam = new SqlParameter[25];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.MonTimeFrom, monTimeFrom);
            objParam[7] = new SqlParameter(DL.Properties.Resources.MonTimeTo, monTimeTo);
            objParam[8] = new SqlParameter(DL.Properties.Resources.TueTimeFrom, tueTimeFrom);
            objParam[9] = new SqlParameter(DL.Properties.Resources.TueTimeTo, tueTimeTo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.WedTimeFrom, wedTimeFrom);
            objParam[11] = new SqlParameter(DL.Properties.Resources.WedTimeTo, wedTimeTo);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ThuTimeFrom, thuTimeFrom);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ThuTimeTo, thuTimeTo);
            objParam[14] = new SqlParameter(DL.Properties.Resources.FriTimeFrom, friTimeFrom);
            objParam[15] = new SqlParameter(DL.Properties.Resources.FriTimeTo, friTimeTo);
            objParam[16] = new SqlParameter(DL.Properties.Resources.SatTimeFrom, satTimeFrom);
            objParam[17] = new SqlParameter(DL.Properties.Resources.SatTimeTo, satTimeTo);
            objParam[18] = new SqlParameter(DL.Properties.Resources.SunTimeFrom, sunTimeFrom);
            objParam[19] = new SqlParameter(DL.Properties.Resources.SunTimeTo, sunTimeTo);
            objParam[20] = new SqlParameter(DL.Properties.Resources.HolidayTimeFrom, holidayTimeFrom);
            objParam[21] = new SqlParameter(DL.Properties.Resources.HolidayTimeTo, holidayTimeTo);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[23] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[24] = new SqlParameter(DL.Properties.Resources.IsPayable, payable);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShiftBreak_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Sales the order deployment shifts break insert.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="breakMin">The break minimum.</param>
        /// <param name="status">The status.</param>
        /// <param name="breakLineNo">The break line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentCheckBreakRule(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string weekNo, string shiftCode,
          string timeFrom, string timeTo,
           string breakMin, string status, string breakLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[7] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[8] = new SqlParameter(DL.Properties.Resources.BreakHrs, breakMin);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParam[10] = new SqlParameter(DL.Properties.Resources.BreakHourAutoId, breakLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShiftBreak_CheckBreakRule", objParam);
            return ds;
        }

        /// <summary>
        /// Sales the order deployment shifts break update.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="monTimeFrom">The mon time from.</param>
        /// <param name="monTimeTo">The mon time to.</param>
        /// <param name="tueTimeFrom">The tue time from.</param>
        /// <param name="tueTimeTo">The tue time to.</param>
        /// <param name="wedTimeFrom">The wed time from.</param>
        /// <param name="wedTimeTo">The wed time to.</param>
        /// <param name="thuTimeFrom">The thu time from.</param>
        /// <param name="thuTimeTo">The thu time to.</param>
        /// <param name="friTimeFrom">The fri time from.</param>
        /// <param name="friTimeTo">The fri time to.</param>
        /// <param name="satTimeFrom">The sat time from.</param>
        /// <param name="satTimeTo">The sat time to.</param>
        /// <param name="sunTimeFrom">The sun time from.</param>
        /// <param name="sunTimeTo">The sun time to.</param>
        /// <param name="holidayTimeFrom">The holiday time from.</param>
        /// <param name="holidayTimeTo">The holiday time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="breakLineNo">The break line no.</param>
        /// <param name="billable">The billable.</param>
        /// <param name="payable">The payable.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsBreakUpdate(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string weekNo, string shiftCode,
         string monTimeFrom, string monTimeTo,
         string tueTimeFrom, string tueTimeTo,
         string wedTimeFrom, string wedTimeTo,
         string thuTimeFrom, string thuTimeTo,
         string friTimeFrom, string friTimeTo,
         string satTimeFrom, string satTimeTo,
         string sunTimeFrom, string sunTimeTo,
         string holidayTimeFrom, string holidayTimeTo,
         string modifiedBy, string breakLineNo, string billable, string payable
         )
        {
            SqlParameter[] objParam = new SqlParameter[26];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.MonTimeFrom, monTimeFrom);
            objParam[7] = new SqlParameter(DL.Properties.Resources.MonTimeTo, monTimeTo);
            objParam[8] = new SqlParameter(DL.Properties.Resources.TueTimeFrom, tueTimeFrom);
            objParam[9] = new SqlParameter(DL.Properties.Resources.TueTimeTo, tueTimeTo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.WedTimeFrom, wedTimeFrom);
            objParam[11] = new SqlParameter(DL.Properties.Resources.WedTimeTo, wedTimeTo);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ThuTimeFrom, thuTimeFrom);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ThuTimeTo, thuTimeTo);
            objParam[14] = new SqlParameter(DL.Properties.Resources.FriTimeFrom, friTimeFrom);
            objParam[15] = new SqlParameter(DL.Properties.Resources.FriTimeTo, friTimeTo);
            objParam[16] = new SqlParameter(DL.Properties.Resources.SatTimeFrom, satTimeFrom);
            objParam[17] = new SqlParameter(DL.Properties.Resources.SatTimeTo, satTimeTo);
            objParam[18] = new SqlParameter(DL.Properties.Resources.SunTimeFrom, sunTimeFrom);
            objParam[19] = new SqlParameter(DL.Properties.Resources.SunTimeTo, sunTimeTo);
            objParam[20] = new SqlParameter(DL.Properties.Resources.HolidayTimeFrom, holidayTimeFrom);
            objParam[21] = new SqlParameter(DL.Properties.Resources.HolidayTimeTo, holidayTimeTo);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[23] = new SqlParameter(DL.Properties.Resources.BreakHourAutoId, breakLineNo);
            objParam[24] = new SqlParameter(DL.Properties.Resources.Billable, billable);
            objParam[25] = new SqlParameter(DL.Properties.Resources.IsPayable, payable);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShiftBreak_Update", objParam);
            return ds;
        }

        /// <summary>
        /// Break shift Delete functionality
        /// </summary>
        /// <param name="locationAutoId">The Location Auto Identifier</param>
        /// <param name="clientCode">The client Code</param>
        /// <param name="asmtId">The assignment identifier</param>
        /// <param name="postAutoId">The post auto identifier</param>
        /// <param name="Shift">The shift Hours</param>
        /// <param name="Break">The Break Hours</param>
        /// <param name="AmendNo">The Amend Number</param>
        /// <returns>DataSet .</returns>
        public DataSet BreakShiftDelete(string locationAutoId, string clientCode, string asmtId, string postAutoId, double Shift, double Break, int AmendNo)
        {
            var objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Shift, Shift);
            objParm[5] = new SqlParameter(DL.Properties.Resources.BreakHrs, Break);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            var ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_BreakShift_Delete", objParm);
            return ds;
        }


        /// <summary>
        /// Sales the order deployment shifts break delete.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="breakLineNo">The break line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsBreakDelete(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string weekNo, string shiftCode, string breakLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.BreakHourAutoId, breakLineNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShiftBreak_Delete", objParam);
            return ds;
        }

        #endregion Sale order Shift Break Mechanism

        #region Sale Order Deployment Shift
        /// <summary>
        /// Sales the order deployment shifts get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsGet(string locationAutoId, string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShift_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order deployment shifts insert.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="monNoOfPersons">The mon no of persons.</param>
        /// <param name="monSellingRate">The mon selling rate.</param>
        /// <param name="monPayRate">The mon pay rate.</param>
        /// <param name="monTimeFrom">The mon time from.</param>
        /// <param name="monTimeTo">The mon time to.</param>
        /// <param name="tueNoOfPersons">The tue no of persons.</param>
        /// <param name="tueSellingRate">The tue selling rate.</param>
        /// <param name="tuePayRate">The tue pay rate.</param>
        /// <param name="tueTimeFrom">The tue time from.</param>
        /// <param name="tueTimeTo">The tue time to.</param>
        /// <param name="wedNoOfPersons">The wed no of persons.</param>
        /// <param name="wedSellingRate">The wed selling rate.</param>
        /// <param name="wedPayRate">The wed pay rate.</param>
        /// <param name="wedTimeFrom">The wed time from.</param>
        /// <param name="wedTimeTo">The wed time to.</param>
        /// <param name="thuNoOfPersons">The thu no of persons.</param>
        /// <param name="thuSellingRate">The thu selling rate.</param>
        /// <param name="thuPayRate">The thu pay rate.</param>
        /// <param name="thuTimeFrom">The thu time from.</param>
        /// <param name="thuTimeTo">The thu time to.</param>
        /// <param name="friNoOfPersons">The fri no of persons.</param>
        /// <param name="friSellingRate">The fri selling rate.</param>
        /// <param name="friPayRate">The fri pay rate.</param>
        /// <param name="friTimeFrom">The fri time from.</param>
        /// <param name="friTimeTo">The fri time to.</param>
        /// <param name="satNoOfPersons">The sat no of persons.</param>
        /// <param name="satSellingRate">The sat selling rate.</param>
        /// <param name="satPayRate">The sat pay rate.</param>
        /// <param name="satTimeFrom">The sat time from.</param>
        /// <param name="satTimeTo">The sat time to.</param>
        /// <param name="sunNoOfPersons">The sun no of persons.</param>
        /// <param name="sunSellingRate">The sun selling rate.</param>
        /// <param name="sunPayRate">The sun pay rate.</param>
        /// <param name="sunTimeFrom">The sun time from.</param>
        /// <param name="sunTimeTo">The sun time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="MonOTSellingRate">The mon OT selling rate.</param>
        /// <param name="MonHSellingRate">The mon H selling rate.</param>
        /// <param name="MonOSellingRate">The mon O selling rate.</param>
        /// <param name="TueOTSellingRate">The tue OT selling rate.</param>
        /// <param name="TueHSellingRate">The tue H selling rate.</param>
        /// <param name="TueOSellingRate">The tue O selling rate.</param>
        /// <param name="WedOTSellingRate">The wed OT selling rate.</param>
        /// <param name="WedHSellingRate">The wed H selling rate.</param>
        /// <param name="WedOSellingRate">The wed O selling rate.</param>
        /// <param name="ThuOTSellingRate">The thu OT selling rate.</param>
        /// <param name="ThuHSellingRate">The thu H selling rate.</param>
        /// <param name="ThuOSellingRate">The thu O selling rate.</param>
        /// <param name="FriOTSellingRate">The fri OT selling rate.</param>
        /// <param name="FriHSellingRate">The fri H selling rate.</param>
        /// <param name="FriOSellingRate">The fri O selling rate.</param>
        /// <param name="SatOTSellingRate">The sat OT selling rate.</param>
        /// <param name="SatHSellingRate">The sat H selling rate.</param>
        /// <param name="SatOSellingRate">The sat O selling rate.</param>
        /// <param name="SunOTSellingRate">The sun OT selling rate.</param>
        /// <param name="SunHSellingRate">The sun H selling rate.</param>
        /// <param name="SunOSellingRate">The sun O selling rate.</param>
        /// <param name="holidayTypeCode">holiday type code</param>
        /// <param name="holidayTimeFrom">holiday time from</param>
        /// <param name="holidayTimeTo">holiday time to</param>
        /// <param name="holidayNoOfPersons">holiday no of persons</param>
        /// <param name="holidaySellingRate">holiday selling rate</param>
        /// <param name="holidayPayRate">holiday pay rate</param>
        /// <param name="holidayOTSellingRate">holiday Ot selling rate</param>
        /// <param name="holidayOSellingRate">holiday other selling rate</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsInsert(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string weekNo, string shiftCode,
            string monNoOfPersons, string monSellingRate, string monPayRate, string monTimeFrom, string monTimeTo,
            string tueNoOfPersons, string tueSellingRate, string tuePayRate, string tueTimeFrom, string tueTimeTo,
            string wedNoOfPersons, string wedSellingRate, string wedPayRate, string wedTimeFrom, string wedTimeTo,
            string thuNoOfPersons, string thuSellingRate, string thuPayRate, string thuTimeFrom, string thuTimeTo,
            string friNoOfPersons, string friSellingRate, string friPayRate, string friTimeFrom, string friTimeTo,
            string satNoOfPersons, string satSellingRate, string satPayRate, string satTimeFrom, string satTimeTo,
            string sunNoOfPersons, string sunSellingRate, string sunPayRate, string sunTimeFrom, string sunTimeTo, string modifiedBy,
            string MonOTSellingRate, string MonHSellingRate, string MonOSellingRate,
            string TueOTSellingRate, string TueHSellingRate, string TueOSellingRate,
            string WedOTSellingRate, string WedHSellingRate, string WedOSellingRate,
            string ThuOTSellingRate, string ThuHSellingRate, string ThuOSellingRate,
            string FriOTSellingRate, string FriHSellingRate, string FriOSellingRate,
            string SatOTSellingRate, string SatHSellingRate, string SatOSellingRate,
            string SunOTSellingRate, string SunHSellingRate, string SunOSellingRate,
            string holidayTypeCode, string holidayTimeFrom, string holidayTimeTo, string holidayNoOfPersons,
            string holidaySellingRate, string holidayPayRate, string holidayOTSellingRate, string holidayOSellingRate)
        {
            SqlParameter[] objParam = new SqlParameter[71];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);

            objParam[6] = new SqlParameter(DL.Properties.Resources.MonNoOfPersons, monNoOfPersons);
            objParam[7] = new SqlParameter(DL.Properties.Resources.MonSellingRate, monSellingRate);
            objParam[8] = new SqlParameter(DL.Properties.Resources.MonPayRate, monPayRate);
            objParam[9] = new SqlParameter(DL.Properties.Resources.MonTimeFrom, monTimeFrom);
            objParam[10] = new SqlParameter(DL.Properties.Resources.MonTimeTo, monTimeTo);

            objParam[11] = new SqlParameter(DL.Properties.Resources.TueNoOfPersons, tueNoOfPersons);
            objParam[12] = new SqlParameter(DL.Properties.Resources.TueSellingRate, tueSellingRate);
            objParam[13] = new SqlParameter(DL.Properties.Resources.TuePayRate, tuePayRate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.TueTimeFrom, tueTimeFrom);
            objParam[15] = new SqlParameter(DL.Properties.Resources.TueTimeTo, tueTimeTo);

            objParam[16] = new SqlParameter(DL.Properties.Resources.WedNoOfPersons, wedNoOfPersons);
            objParam[17] = new SqlParameter(DL.Properties.Resources.WedSellingRate, wedSellingRate);
            objParam[18] = new SqlParameter(DL.Properties.Resources.WedPayRate, wedPayRate);
            objParam[19] = new SqlParameter(DL.Properties.Resources.WedTimeFrom, wedTimeFrom);
            objParam[20] = new SqlParameter(DL.Properties.Resources.WedTimeTo, wedTimeTo);

            objParam[21] = new SqlParameter(DL.Properties.Resources.ThuNoOfPersons, thuNoOfPersons);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ThuSellingRate, thuSellingRate);
            objParam[23] = new SqlParameter(DL.Properties.Resources.ThuPayRate, thuPayRate);
            objParam[24] = new SqlParameter(DL.Properties.Resources.ThuTimeFrom, thuTimeFrom);
            objParam[25] = new SqlParameter(DL.Properties.Resources.ThuTimeTo, thuTimeTo);

            objParam[26] = new SqlParameter(DL.Properties.Resources.FriNoOfPersons, friNoOfPersons);
            objParam[27] = new SqlParameter(DL.Properties.Resources.FriSellingRate, friSellingRate);
            objParam[28] = new SqlParameter(DL.Properties.Resources.FriPayRate, friPayRate);
            objParam[29] = new SqlParameter(DL.Properties.Resources.FriTimeFrom, friTimeFrom);
            objParam[30] = new SqlParameter(DL.Properties.Resources.FriTimeTo, friTimeTo);

            objParam[31] = new SqlParameter(DL.Properties.Resources.SatNoOfPersons, satNoOfPersons);
            objParam[32] = new SqlParameter(DL.Properties.Resources.SatSellingRate, satSellingRate);
            objParam[33] = new SqlParameter(DL.Properties.Resources.SatPayRate, satPayRate);
            objParam[34] = new SqlParameter(DL.Properties.Resources.SatTimeFrom, satTimeFrom);
            objParam[35] = new SqlParameter(DL.Properties.Resources.SatTimeTo, satTimeTo);

            objParam[36] = new SqlParameter(DL.Properties.Resources.SunNoOfPersons, sunNoOfPersons);
            objParam[37] = new SqlParameter(DL.Properties.Resources.SunSellingRate, sunSellingRate);
            objParam[38] = new SqlParameter(DL.Properties.Resources.SunPayRate, sunPayRate);
            objParam[39] = new SqlParameter(DL.Properties.Resources.SunTimeFrom, sunTimeFrom);
            objParam[40] = new SqlParameter(DL.Properties.Resources.SunTimeTo, sunTimeTo);

            objParam[41] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            objParam[42] = new SqlParameter(DL.Properties.Resources.MonOTSellingRate, MonOTSellingRate);
            objParam[43] = new SqlParameter(DL.Properties.Resources.MonHSellingRate, MonHSellingRate);
            objParam[44] = new SqlParameter(DL.Properties.Resources.MonOSellingRate, MonOSellingRate);
            objParam[45] = new SqlParameter(DL.Properties.Resources.TueOTSellingRate, TueOTSellingRate);
            objParam[46] = new SqlParameter(DL.Properties.Resources.TueHSellingRate, TueHSellingRate);
            objParam[47] = new SqlParameter(DL.Properties.Resources.TueOSellingRate, TueOSellingRate);
            objParam[48] = new SqlParameter(DL.Properties.Resources.WedOTSellingRate, WedOTSellingRate);
            objParam[49] = new SqlParameter(DL.Properties.Resources.WedHSellingRate, WedHSellingRate);
            objParam[50] = new SqlParameter(DL.Properties.Resources.WedOSellingRate, WedOSellingRate);
            objParam[51] = new SqlParameter(DL.Properties.Resources.ThuOTSellingRate, ThuOTSellingRate);
            objParam[52] = new SqlParameter(DL.Properties.Resources.ThuHSellingRate, ThuHSellingRate);
            objParam[53] = new SqlParameter(DL.Properties.Resources.ThuOSellingRate, ThuOSellingRate);
            objParam[54] = new SqlParameter(DL.Properties.Resources.FriOTSellingRate, FriOTSellingRate);
            objParam[55] = new SqlParameter(DL.Properties.Resources.FriHSellingRate, FriHSellingRate);
            objParam[56] = new SqlParameter(DL.Properties.Resources.FriOSellingRate, FriOSellingRate);
            objParam[57] = new SqlParameter(DL.Properties.Resources.SatOTSellingRate, SatOTSellingRate);
            objParam[58] = new SqlParameter(DL.Properties.Resources.SatHSellingRate, SatHSellingRate);
            objParam[59] = new SqlParameter(DL.Properties.Resources.SatOSellingRate, SatOSellingRate);
            objParam[60] = new SqlParameter(DL.Properties.Resources.SunOTSellingRate, SunOTSellingRate);
            objParam[61] = new SqlParameter(DL.Properties.Resources.SunHSellingRate, SunHSellingRate);
            objParam[62] = new SqlParameter(DL.Properties.Resources.SunOSellingRate, SunOSellingRate);

            objParam[63] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            objParam[64] = new SqlParameter(DL.Properties.Resources.HolidayTimeFrom, holidayTimeFrom);
            objParam[65] = new SqlParameter(DL.Properties.Resources.HolidayTimeTo, holidayTimeTo);
            objParam[66] = new SqlParameter(DL.Properties.Resources.HolidayNoOfPersons, holidayNoOfPersons);
            objParam[67] = new SqlParameter(DL.Properties.Resources.HolidaySellingRate, holidaySellingRate);
            objParam[68] = new SqlParameter(DL.Properties.Resources.HolidayPayRate, holidayPayRate);
            objParam[69] = new SqlParameter(DL.Properties.Resources.HolidayOTSellingRate, holidayOTSellingRate);
            objParam[70] = new SqlParameter(DL.Properties.Resources.HolidayOSellingRate, holidayOSellingRate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShift_Insert", objParam);
            return ds;
        }


        /// <summary>
        /// Sales the order deployment shifts update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="weekNo">The week no.</param>
        /// <param name="shiftCode">The shift code.</param>
        /// <param name="monNoOfPersons">The mon no of persons.</param>
        /// <param name="monSellingRate">The mon selling rate.</param>
        /// <param name="monPayRate">The mon pay rate.</param>
        /// <param name="monTimeFrom">The mon time from.</param>
        /// <param name="monTimeTo">The mon time to.</param>
        /// <param name="tueNoOfPersons">The tue no of persons.</param>
        /// <param name="tueSellingRate">The tue selling rate.</param>
        /// <param name="tuePayRate">The tue pay rate.</param>
        /// <param name="tueTimeFrom">The tue time from.</param>
        /// <param name="tueTimeTo">The tue time to.</param>
        /// <param name="wedNoOfPersons">The wed no of persons.</param>
        /// <param name="wedSellingRate">The wed selling rate.</param>
        /// <param name="wedPayRate">The wed pay rate.</param>
        /// <param name="wedTimeFrom">The wed time from.</param>
        /// <param name="wedTimeTo">The wed time to.</param>
        /// <param name="thuNoOfPersons">The thu no of persons.</param>
        /// <param name="thuSellingRate">The thu selling rate.</param>
        /// <param name="thuPayRate">The thu pay rate.</param>
        /// <param name="thuTimeFrom">The thu time from.</param>
        /// <param name="thuTimeTo">The thu time to.</param>
        /// <param name="friNoOfPersons">The fri no of persons.</param>
        /// <param name="friSellingRate">The fri selling rate.</param>
        /// <param name="friPayRate">The fri pay rate.</param>
        /// <param name="friTimeFrom">The fri time from.</param>
        /// <param name="friTimeTo">The fri time to.</param>
        /// <param name="satNoOfPersons">The sat no of persons.</param>
        /// <param name="satSellingRate">The sat selling rate.</param>
        /// <param name="satPayRate">The sat pay rate.</param>
        /// <param name="satTimeFrom">The sat time from.</param>
        /// <param name="satTimeTo">The sat time to.</param>
        /// <param name="sunNoOfPersons">The sun no of persons.</param>
        /// <param name="sunSellingRate">The sun selling rate.</param>
        /// <param name="sunPayRate">The sun pay rate.</param>
        /// <param name="sunTimeFrom">The sun time from.</param>
        /// <param name="sunTimeTo">The sun time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">The status.</param>
        /// <param name="MonOTSellingRate">The mon ot selling rate.</param>
        /// <param name="MonHSellingRate">The mon h selling rate.</param>
        /// <param name="MonOSellingRate">The mon o selling rate.</param>
        /// <param name="TueOTSellingRate">The tue ot selling rate.</param>
        /// <param name="TueHSellingRate">The tue h selling rate.</param>
        /// <param name="TueOSellingRate">The tue o selling rate.</param>
        /// <param name="WedOTSellingRate">The wed ot selling rate.</param>
        /// <param name="WedHSellingRate">The wed h selling rate.</param>
        /// <param name="WedOSellingRate">The wed o selling rate.</param>
        /// <param name="ThuOTSellingRate">The thu ot selling rate.</param>
        /// <param name="ThuHSellingRate">The thu h selling rate.</param>
        /// <param name="ThuOSellingRate">The thu o selling rate.</param>
        /// <param name="FriOTSellingRate">The fri ot selling rate.</param>
        /// <param name="FriHSellingRate">The fri h selling rate.</param>
        /// <param name="FriOSellingRate">The fri o selling rate.</param>
        /// <param name="SatOTSellingRate">The sat ot selling rate.</param>
        /// <param name="SatHSellingRate">The sat h selling rate.</param>
        /// <param name="SatOSellingRate">The sat o selling rate.</param>
        /// <param name="SunOTSellingRate">The sun ot selling rate.</param>
        /// <param name="SunHSellingRate">The sun h selling rate.</param>
        /// <param name="SunOSellingRate">The sun o selling rate.</param>
        /// <param name="holidayTypeCode">holiday type code</param>
        /// <param name="holidayTimeFrom">holiday time from</param>
        /// <param name="holidayTimeTo">holiday time to</param>
        /// <param name="holidayNoOfPersons">holiday no of persons</param>
        /// <param name="holidaySellingRate">holiday selling rate</param>
        /// <param name="holidayPayRate">holiday pay rate</param>
        /// <param name="holidayOTSellingRate">holiday Ot selling rate</param>
        /// <param name="holidayOSellingRate">holiday other selling rate</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsUpdate(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string weekNo, string shiftCode,
            string monNoOfPersons, string monSellingRate, string monPayRate, string monTimeFrom, string monTimeTo,
            string tueNoOfPersons, string tueSellingRate, string tuePayRate, string tueTimeFrom, string tueTimeTo,
            string wedNoOfPersons, string wedSellingRate, string wedPayRate, string wedTimeFrom, string wedTimeTo,
            string thuNoOfPersons, string thuSellingRate, string thuPayRate, string thuTimeFrom, string thuTimeTo,
            string friNoOfPersons, string friSellingRate, string friPayRate, string friTimeFrom, string friTimeTo,
            string satNoOfPersons, string satSellingRate, string satPayRate, string satTimeFrom, string satTimeTo,
            string sunNoOfPersons, string sunSellingRate, string sunPayRate, string sunTimeFrom, string sunTimeTo, string modifiedBy, string status,
            string MonOTSellingRate, string MonHSellingRate, string MonOSellingRate,
            string TueOTSellingRate, string TueHSellingRate, string TueOSellingRate,
            string WedOTSellingRate, string WedHSellingRate, string WedOSellingRate,
            string ThuOTSellingRate, string ThuHSellingRate, string ThuOSellingRate,
            string FriOTSellingRate, string FriHSellingRate, string FriOSellingRate,
            string SatOTSellingRate, string SatHSellingRate, string SatOSellingRate,
            string SunOTSellingRate, string SunHSellingRate, string SunOSellingRate,
            string holidayTypeCode, string holidayTimeFrom, string holidayTimeTo, string holidayNoOfPersons,
            string holidaySellingRate, string holidayPayRate, string holidayOTSellingRate, string holidayOSellingRate)
        {
            SqlParameter[] objParam = new SqlParameter[72];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.WeekNo, weekNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);

            objParam[6] = new SqlParameter(DL.Properties.Resources.MonNoOfPersons, monNoOfPersons);
            objParam[7] = new SqlParameter(DL.Properties.Resources.MonSellingRate, monSellingRate);
            objParam[8] = new SqlParameter(DL.Properties.Resources.MonPayRate, monPayRate);
            objParam[9] = new SqlParameter(DL.Properties.Resources.MonTimeFrom, monTimeFrom);
            objParam[10] = new SqlParameter(DL.Properties.Resources.MonTimeTo, monTimeTo);

            objParam[11] = new SqlParameter(DL.Properties.Resources.TueNoOfPersons, tueNoOfPersons);
            objParam[12] = new SqlParameter(DL.Properties.Resources.TueSellingRate, tueSellingRate);
            objParam[13] = new SqlParameter(DL.Properties.Resources.TuePayRate, tuePayRate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.TueTimeFrom, tueTimeFrom);
            objParam[15] = new SqlParameter(DL.Properties.Resources.TueTimeTo, tueTimeTo);

            objParam[16] = new SqlParameter(DL.Properties.Resources.WedNoOfPersons, wedNoOfPersons);
            objParam[17] = new SqlParameter(DL.Properties.Resources.WedSellingRate, wedSellingRate);
            objParam[18] = new SqlParameter(DL.Properties.Resources.WedPayRate, wedPayRate);
            objParam[19] = new SqlParameter(DL.Properties.Resources.WedTimeFrom, wedTimeFrom);
            objParam[20] = new SqlParameter(DL.Properties.Resources.WedTimeTo, wedTimeTo);

            objParam[21] = new SqlParameter(DL.Properties.Resources.ThuNoOfPersons, thuNoOfPersons);
            objParam[22] = new SqlParameter(DL.Properties.Resources.ThuSellingRate, thuSellingRate);
            objParam[23] = new SqlParameter(DL.Properties.Resources.ThuPayRate, thuPayRate);
            objParam[24] = new SqlParameter(DL.Properties.Resources.ThuTimeFrom, thuTimeFrom);
            objParam[25] = new SqlParameter(DL.Properties.Resources.ThuTimeTo, thuTimeTo);

            objParam[26] = new SqlParameter(DL.Properties.Resources.FriNoOfPersons, friNoOfPersons);
            objParam[27] = new SqlParameter(DL.Properties.Resources.FriSellingRate, friSellingRate);
            objParam[28] = new SqlParameter(DL.Properties.Resources.FriPayRate, friPayRate);
            objParam[29] = new SqlParameter(DL.Properties.Resources.FriTimeFrom, friTimeFrom);
            objParam[30] = new SqlParameter(DL.Properties.Resources.FriTimeTo, friTimeTo);

            objParam[31] = new SqlParameter(DL.Properties.Resources.SatNoOfPersons, satNoOfPersons);
            objParam[32] = new SqlParameter(DL.Properties.Resources.SatSellingRate, satSellingRate);
            objParam[33] = new SqlParameter(DL.Properties.Resources.SatPayRate, satPayRate);
            objParam[34] = new SqlParameter(DL.Properties.Resources.SatTimeFrom, satTimeFrom);
            objParam[35] = new SqlParameter(DL.Properties.Resources.SatTimeTo, satTimeTo);

            objParam[36] = new SqlParameter(DL.Properties.Resources.SunNoOfPersons, sunNoOfPersons);
            objParam[37] = new SqlParameter(DL.Properties.Resources.SunSellingRate, sunSellingRate);
            objParam[38] = new SqlParameter(DL.Properties.Resources.SunPayRate, sunPayRate);
            objParam[39] = new SqlParameter(DL.Properties.Resources.SunTimeFrom, sunTimeFrom);
            objParam[40] = new SqlParameter(DL.Properties.Resources.SunTimeTo, sunTimeTo);

            objParam[41] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[42] = new SqlParameter(DL.Properties.Resources.Status, status);

            objParam[43] = new SqlParameter(DL.Properties.Resources.MonOTSellingRate, MonOTSellingRate);
            objParam[44] = new SqlParameter(DL.Properties.Resources.MonHSellingRate, MonHSellingRate);
            objParam[45] = new SqlParameter(DL.Properties.Resources.MonOSellingRate, MonOSellingRate);
            objParam[46] = new SqlParameter(DL.Properties.Resources.TueOTSellingRate, TueOTSellingRate);
            objParam[47] = new SqlParameter(DL.Properties.Resources.TueHSellingRate, TueHSellingRate);
            objParam[48] = new SqlParameter(DL.Properties.Resources.TueOSellingRate, TueOSellingRate);
            objParam[49] = new SqlParameter(DL.Properties.Resources.WedOTSellingRate, WedOTSellingRate);
            objParam[50] = new SqlParameter(DL.Properties.Resources.WedHSellingRate, WedHSellingRate);
            objParam[51] = new SqlParameter(DL.Properties.Resources.WedOSellingRate, WedOSellingRate);
            objParam[52] = new SqlParameter(DL.Properties.Resources.ThuOTSellingRate, ThuOTSellingRate);
            objParam[53] = new SqlParameter(DL.Properties.Resources.ThuHSellingRate, ThuHSellingRate);
            objParam[54] = new SqlParameter(DL.Properties.Resources.ThuOSellingRate, ThuOSellingRate);
            objParam[55] = new SqlParameter(DL.Properties.Resources.FriOTSellingRate, FriOTSellingRate);
            objParam[56] = new SqlParameter(DL.Properties.Resources.FriHSellingRate, FriHSellingRate);
            objParam[57] = new SqlParameter(DL.Properties.Resources.FriOSellingRate, FriOSellingRate);
            objParam[58] = new SqlParameter(DL.Properties.Resources.SatOTSellingRate, SatOTSellingRate);
            objParam[59] = new SqlParameter(DL.Properties.Resources.SatHSellingRate, SatHSellingRate);
            objParam[60] = new SqlParameter(DL.Properties.Resources.SatOSellingRate, SatOSellingRate);
            objParam[61] = new SqlParameter(DL.Properties.Resources.SunOTSellingRate, SunOTSellingRate);
            objParam[62] = new SqlParameter(DL.Properties.Resources.SunHSellingRate, SunHSellingRate);
            objParam[63] = new SqlParameter(DL.Properties.Resources.SunOSellingRate, SunOSellingRate);

            objParam[64] = new SqlParameter(DL.Properties.Resources.HolidayTypeCode, holidayTypeCode);
            objParam[65] = new SqlParameter(DL.Properties.Resources.HolidayTimeFrom, holidayTimeFrom);
            objParam[66] = new SqlParameter(DL.Properties.Resources.HolidayTimeTo, holidayTimeTo);
            objParam[67] = new SqlParameter(DL.Properties.Resources.HolidayNoOfPersons, holidayNoOfPersons);
            objParam[68] = new SqlParameter(DL.Properties.Resources.HolidaySellingRate, holidaySellingRate);
            objParam[69] = new SqlParameter(DL.Properties.Resources.HolidayPayRate, holidayPayRate);
            objParam[70] = new SqlParameter(DL.Properties.Resources.HolidayOTSellingRate, holidayOTSellingRate);
            objParam[71] = new SqlParameter(DL.Properties.Resources.HolidayOSellingRate, holidayOSellingRate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShift_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order deployment shifts delete.
        /// </summary>
        /// <param name="soDeploymentShiftAutoId">The so deployment shift auto id.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsDelete(string soDeploymentShiftAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SaleOrderDeptShiftAutoId, soDeploymentShiftAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_SODeptShift_Delete", objParam);
            return ds;
        }

        // 02-07-2012 To display Info in header on page 

        /// <summary>
        /// Deployments the header info get.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet DeploymentHeaderInfoGet(string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_DeploymentHeader", objParam);
            return ds;
        }
        public DataSet GetAvailableShiftDetails(string clientCode, string asmtId, string dutyDate)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAvailableShiftDetails", objParam);
            return ds;
        }

        public DataSet ScheduleVsAcualByAsmtGet(string clientCode, string asmtId, string shiftCode, string dutyDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpScheduleVsAcualByAsmtGet", objParam);
            return ds;
        }

        public DataSet EmployeeMultipleDutyDashboardGet(string clientCode, string asmtId, string shiftCode, string dutyDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ShiftCode, shiftCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeeMultipleDutyDashboardGet", objParam);
            return ds;
        }

        public DataSet EmployeePresentDashboardGet(string clientCode, string asmtId, string dutyDate)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DutyDate, dutyDate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_EmployeePresentDashboardGet", objParam);
            return ds;
        }
        #endregion Sale Order Deployment Shift

        #region Function related To Cost Sheet
        #region Get data Functions
        /// <summary>
        /// To get Cost Sheets for the client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetListGet(string locationAutoId, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheetList_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get the CostSheet Header details for a costsheet No. and amendement no.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetHeaderGet(string locationAutoId, string costSheetNo, string costSheetAmendmentNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheet_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get all the Amendment No. of a Costsheet no.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetAmendNoGet(string locationAutoId, string costSheetNo)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_CostSheetAmendNo_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Cost Sheet Services details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetServicesGet(string locationAutoId, string costSheetNo, string costSheetAmendmentNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_CostSheetServices_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Cost Sheet Items details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetItemGet(string locationAutoId, string costSheetNo, string costSheetAmendmentNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_CostSheetItems_Get", objParam);
            return ds;
        }
        #endregion
        #region Save Data
        /// <summary>
        /// Costs the sheet insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetDate">The cost sheet date.</param>
        /// <param name="costSheetStatus">The cost sheet status.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="preparedBy">The prepared by.</param>
        /// <param name="preparedDate">The prepared date.</param>
        /// <param name="verifiedBy">The verified by.</param>
        /// <param name="verifiedDate">The verified date.</param>
        /// <param name="approvedBy">The approved by.</param>
        /// <param name="approvedDate">The approved date.</param>
        /// <param name="margin">The margin.</param>
        /// <param name="bankGuaranteeAmount">The bank guarantee amount.</param>
        /// <param name="contractStampAmount">The contract stamp amount.</param>
        /// <param name="airportFeeAmt">The airport fee amt.</param>
        /// <param name="totalEquipmentCostYearly">The total equipment cost yearly.</param>
        /// <param name="otherAddChargesMonthly">The other add charges monthly.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="totalAmountWithMargin">The total amount with margin.</param>
        /// <param name="equipmentRentalActual">The equipment rental actual.</param>
        /// <param name="totalSellingPriceActual">The total selling price actual.</param>
        /// <param name="minusCostActual">The minus cost actual.</param>
        /// <param name="grossProfitActual">The gross profit actual.</param>
        /// <param name="grossMarginActual">The gross margin actual.</param>
        /// <param name="contributionPerHeadActual">The contribution per head actual.</param>
        /// <param name="equipmentRentalApm">The equipment rental apm.</param>
        /// <param name="totalSellingPriceApm">The total selling price apm.</param>
        /// <param name="minusCostApm">The minus cost apm.</param>
        /// <param name="grossProfitApm">The gross profit apm.</param>
        /// <param name="grossMarginApm">The gross margin apm.</param>
        /// <param name="contributionPerHeadApm">The contribution per head apm.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetInsert(string locationAutoId, string costSheetDate, string costSheetStatus, string clientCode, string preparedBy, string preparedDate, string verifiedBy, string verifiedDate, string approvedBy, string approvedDate, string margin, string bankGuaranteeAmount, string contractStampAmount, string airportFeeAmt, string totalEquipmentCostYearly, string otherAddChargesMonthly, string totalAmount, string totalAmountWithMargin, string equipmentRentalActual, string totalSellingPriceActual, string minusCostActual, string grossProfitActual, string grossMarginActual, string contributionPerHeadActual, string equipmentRentalApm, string totalSellingPriceApm, string minusCostApm, string grossProfitApm, string grossMarginApm, string contributionPerHeadApm, string modifiedBy)
        {
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            SqlParameter[] objParam = new SqlParameter[31];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetDate, costSheetDate);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetStatus, costSheetStatus);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.PreparedBy, preparedBy);
            if (preparedDate.Length == 0)
            { objParam[5] = new SqlParameter(DL.Properties.Resources.PreparedDate, DBNull.Value); }
            else
            { objParam[5] = new SqlParameter(DL.Properties.Resources.PreparedDate, DL.Common.DateFormat(preparedDate)); }
            objParam[6] = new SqlParameter(DL.Properties.Resources.VarifedBy, verifiedBy);
            if (verifiedDate.Length == 0)
            { objParam[7] = new SqlParameter(DL.Properties.Resources.VerifiedDate, DBNull.Value); }
            else
            { objParam[7] = new SqlParameter(DL.Properties.Resources.VerifiedDate, DL.Common.DateFormat(verifiedDate)); }
            objParam[8] = new SqlParameter(DL.Properties.Resources.ApprovedBy, approvedBy);
            if (approvedDate.Length == 0)
            { objParam[9] = new SqlParameter(DL.Properties.Resources.ApprovedDate, DBNull.Value); }
            else
            { objParam[9] = new SqlParameter(DL.Properties.Resources.ApprovedDate, DL.Common.DateFormat(approvedDate)); }
            objParam[10] = new SqlParameter(DL.Properties.Resources.Margin, margin);
            objParam[11] = new SqlParameter(DL.Properties.Resources.BankGuaranteeAmount, bankGuaranteeAmount);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ContractStampAmount, contractStampAmount);
            objParam[13] = new SqlParameter(DL.Properties.Resources.AirportFeeAmt, airportFeeAmt);
            objParam[14] = new SqlParameter(DL.Properties.Resources.TotalEquipmentCostYearly, totalEquipmentCostYearly);
            objParam[15] = new SqlParameter(DL.Properties.Resources.OtherAddChargesMonthly, otherAddChargesMonthly);
            objParam[16] = new SqlParameter(DL.Properties.Resources.TotalAmount, totalAmount);
            objParam[17] = new SqlParameter(DL.Properties.Resources.TotalAmountWithMargin, totalAmountWithMargin);
            objParam[18] = new SqlParameter(DL.Properties.Resources.EquipmentRentalActual, equipmentRentalActual);
            objParam[19] = new SqlParameter(DL.Properties.Resources.TotalSellingPriceActual, totalSellingPriceActual);
            objParam[20] = new SqlParameter(DL.Properties.Resources.MinusCostActual, minusCostActual);
            objParam[21] = new SqlParameter(DL.Properties.Resources.GrossProfitActual, grossProfitActual);
            objParam[22] = new SqlParameter(DL.Properties.Resources.GrossMarginActual, grossMarginActual);
            objParam[23] = new SqlParameter(DL.Properties.Resources.ContributionPerHeadActual, contributionPerHeadActual);
            objParam[24] = new SqlParameter(DL.Properties.Resources.EquipmentRentalAPM, equipmentRentalApm);
            objParam[25] = new SqlParameter(DL.Properties.Resources.TotalSellingPriceAPM, totalSellingPriceApm);
            objParam[26] = new SqlParameter(DL.Properties.Resources.MinusCostAPM, minusCostApm);
            objParam[27] = new SqlParameter(DL.Properties.Resources.GROSSProfitAPM, grossProfitApm);
            objParam[28] = new SqlParameter(DL.Properties.Resources.GrossMarginAPM, grossMarginApm);
            objParam[29] = new SqlParameter(DL.Properties.Resources.ContributionPerHeadAPM, contributionPerHeadApm);
            objParam[30] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheet_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// Costs the sheet service insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="designationDesc">The designation desc.</param>
        /// <param name="uom">The uom.</param>
        /// <param name="numberOfPerson">The number of person.</param>
        /// <param name="workingDay">The working day.</param>
        /// <param name="normalHours">The normal hours.</param>
        /// <param name="otHours">The ot hours.</param>
        /// <param name="hourlyWageRate">The hourly wage rate.</param>
        /// <param name="incentiveAllowanceYearly">The incentive allowance yearly.</param>
        /// <param name="quotedRate">The quoted rate.</param>
        /// <param name="total">The total.</param>
        /// <param name="actual">The actual.</param>
        /// <param name="asPerMargin">As per margin.</param>
        /// <param name="totalHrsVocationSickTraining">The total HRS vocation sick training.</param>
        /// <param name="daysPerWeek">The days per week.</param>
        /// <param name="hoursPerDay">The hours per day.</param>
        /// <param name="postsRequired">The posts required.</param>
        /// <param name="recommendedMenByCategory">The recommended men by category.</param>
        /// <param name="totalHrsPerWeek">The total HRS per week.</param>
        /// <param name="totalHrsPerYearActual">The total HRS per year actual.</param>
        /// <param name="totalRegularHrsPerYear">The total regular HRS per year.</param>
        /// <param name="totalOTHrsPerYear">The total ot HRS per year.</param>
        /// <param name="totalRegularHrsPayPerDay">The total regular HRS pay per day.</param>
        /// <param name="totalOTHrsPayPerDay">The total ot HRS pay per day.</param>
        /// <param name="totalHrsPayPerDay">The total HRS pay per day.</param>
        /// <param name="totalHrsPerWeekAllPost">The total HRS per week all post.</param>
        /// <param name="totalHrsPerYearAllPost">The total HRS per year all post.</param>
        /// <param name="totalRegularHrsPerYearAllPost">The total regular HRS per year all post.</param>
        /// <param name="totalOTHrsPerYearAllPost">The total ot HRS per year all post.</param>
        /// <param name="basicWage12HrsPerDay">The basic wage12 HRS per day.</param>
        /// <param name="otFor9TH12THHoursOTRate">The ot for9 t H12 th hours ot rate.</param>
        /// <param name="ot7THDay12Hrs">The ot7 th day12 HRS.</param>
        /// <param name="incentiveAllowance">The incentive allowance.</param>
        /// <param name="holidayPay13Days8Hrs">The holiday pay13 days8 HRS.</param>
        /// <param name="sickPayCompensation">The sick pay compensation.</param>
        /// <param name="vacationPay">The vacation pay.</param>
        /// <param name="providentFund">The provident fund.</param>
        /// <param name="socialWelfareFund">The social welfare fund.</param>
        /// <param name="workmanCompensationFund">The workman compensation fund.</param>
        /// <param name="monthlyBonusPayment">The monthly bonus payment.</param>
        /// <param name="totalDirectLaborCost">The total direct labor cost.</param>
        /// <param name="equipmentsCost">The equipments cost.</param>
        /// <param name="totalOperationCosts">The total operation costs.</param>
        /// <param name="totalDirectCost">The total direct cost.</param>
        /// <param name="overheadAllocation">The overhead allocation.</param>
        /// <param name="totalLocalAdministrativeCost">The total local administrative cost.</param>
        /// <param name="phoneAndFax">The phone and fax.</param>
        /// <param name="generalLiabilityInsurance">The general liability insurance.</param>
        /// <param name="totalLocalOverheadCost">The total local overhead cost.</param>
        /// <param name="overallTotalCost">The overall total cost.</param>
        /// <param name="ratePerPostAsPerMargin">The rate per post as per margin.</param>
        /// <param name="sumOfTotalPost">The sum of total post.</param>
        /// <param name="sumOfTotalHrs">The sum of total HRS.</param>
        /// <param name="vocationHours">The vocation hours.</param>
        /// <param name="sickProvision">The sick provision.</param>
        /// <param name="trainingHrs">The training HRS.</param>
        /// <param name="otRate">The ot rate.</param>
        /// <param name="holidayRate">The holiday rate.</param>
        /// <param name="ot7THDayRate">The ot7 th day rate.</param>
        /// <param name="sickLeaveValue">The sick leave value.</param>
        /// <param name="vocationDayValue">The vocation day value.</param>
        /// <param name="bonusPerMonthPerGuardRate">The bonus per month per guard rate.</param>
        /// <param name="providentFundRate">The provident fund rate.</param>
        /// <param name="socialWelfareRate">The social welfare rate.</param>
        /// <param name="workmenCompensationRate">The workmen compensation rate.</param>
        /// <param name="totalEquipmentCost">The total equipment cost.</param>
        /// <param name="overheadAllocationRate">The overhead allocation rate.</param>
        /// <param name="phoneFaxRate">The phone fax rate.</param>
        /// <param name="generalLiabilityInsuranceRate">The general liability insurance rate.</param>
        /// <param name="incentiveMonthlyOrYearly">The incentive monthly or yearly.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetServiceInsert(string locationAutoId, string costSheetNo, string costSheetAmendmentNo, string soRank, string designationDesc, string uom, string numberOfPerson, string workingDay, string normalHours, string otHours, string hourlyWageRate, string incentiveAllowanceYearly, string quotedRate, string total, string actual, string asPerMargin, string totalHrsVocationSickTraining, string daysPerWeek, string hoursPerDay, string postsRequired, string recommendedMenByCategory, string totalHrsPerWeek, string totalHrsPerYearActual, string totalRegularHrsPerYear, string totalOTHrsPerYear, string totalRegularHrsPayPerDay, string totalOTHrsPayPerDay, string totalHrsPayPerDay, string totalHrsPerWeekAllPost, string totalHrsPerYearAllPost, string totalRegularHrsPerYearAllPost, string totalOTHrsPerYearAllPost, string basicWage12HrsPerDay, string otFor9TH12THHoursOTRate, string ot7THDay12Hrs, string incentiveAllowance, string holidayPay13Days8Hrs, string sickPayCompensation, string vacationPay, string providentFund, string socialWelfareFund, string workmanCompensationFund, string monthlyBonusPayment, string totalDirectLaborCost, string equipmentsCost, string totalOperationCosts, string totalDirectCost, string overheadAllocation, string totalLocalAdministrativeCost, string phoneAndFax, string generalLiabilityInsurance, string totalLocalOverheadCost, string overallTotalCost, string ratePerPostAsPerMargin, string sumOfTotalPost, string sumOfTotalHrs, string vocationHours, string sickProvision, string trainingHrs, string otRate, string holidayRate, string ot7THDayRate, string sickLeaveValue, string vocationDayValue, string bonusPerMonthPerGuardRate, string providentFundRate, string socialWelfareRate, string workmenCompensationRate, string totalEquipmentCost, string overheadAllocationRate, string phoneFaxRate, string generalLiabilityInsuranceRate, string incentiveMonthlyOrYearly, string modifiedBy)
        {
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            SqlParameter[] objParam = new SqlParameter[74];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[4] = new SqlParameter(DL.Properties.Resources.DesignationDesc, designationDesc);
            objParam[5] = new SqlParameter(DL.Properties.Resources.UOM, uom);
            objParam[6] = new SqlParameter(DL.Properties.Resources.NumberOfPerson, numberOfPerson);
            objParam[7] = new SqlParameter(DL.Properties.Resources.WorkingDay, workingDay);
            objParam[8] = new SqlParameter(DL.Properties.Resources.NormalHours, normalHours);
            objParam[9] = new SqlParameter(DL.Properties.Resources.OTHours, otHours);
            objParam[10] = new SqlParameter(DL.Properties.Resources.HourlyWageRate, hourlyWageRate);
            objParam[11] = new SqlParameter(DL.Properties.Resources.IncentiveAllowanceYearly, incentiveAllowanceYearly);
            objParam[12] = new SqlParameter(DL.Properties.Resources.QuotedRate, quotedRate);
            objParam[13] = new SqlParameter(DL.Properties.Resources.Total, total);
            objParam[14] = new SqlParameter(DL.Properties.Resources.Actual, actual);
            objParam[15] = new SqlParameter(DL.Properties.Resources.AsPerMargin, asPerMargin);
            objParam[16] = new SqlParameter(DL.Properties.Resources.TotalHrsVoccationSickTraining, totalHrsVocationSickTraining);
            objParam[17] = new SqlParameter(DL.Properties.Resources.DaysPerWeek, daysPerWeek);
            objParam[18] = new SqlParameter(DL.Properties.Resources.HoursPerDay, hoursPerDay);
            objParam[19] = new SqlParameter(DL.Properties.Resources.PostsRequired, postsRequired);
            objParam[20] = new SqlParameter(DL.Properties.Resources.RecommendedMenByCategory, recommendedMenByCategory);
            objParam[21] = new SqlParameter(DL.Properties.Resources.TotalHrsPerWeek, totalHrsPerWeek);
            objParam[22] = new SqlParameter(DL.Properties.Resources.TotalHrsPerYearActual, totalHrsPerYearActual);
            objParam[23] = new SqlParameter(DL.Properties.Resources.TotalRegularHrsPerYear, totalRegularHrsPerYear);
            objParam[24] = new SqlParameter(DL.Properties.Resources.TotalOTHrsPerYear, totalOTHrsPerYear);
            objParam[25] = new SqlParameter(DL.Properties.Resources.TotalRegularHrsPayPerDay, totalRegularHrsPayPerDay);
            objParam[26] = new SqlParameter(DL.Properties.Resources.TotalOTHrsPayPerDay, totalOTHrsPayPerDay);
            objParam[27] = new SqlParameter(DL.Properties.Resources.TotalHrsPayPerDay, totalHrsPayPerDay);
            objParam[28] = new SqlParameter(DL.Properties.Resources.TotalHrsPerWeekAllPost, totalHrsPerWeekAllPost);
            objParam[29] = new SqlParameter(DL.Properties.Resources.TotalHrsPerYearAllPost, totalHrsPerYearAllPost);
            objParam[30] = new SqlParameter(DL.Properties.Resources.TotalRegularHrsPerYearAllPost, totalRegularHrsPerYearAllPost);
            objParam[31] = new SqlParameter(DL.Properties.Resources.TotalOTHrsPerYearAllPost, totalOTHrsPerYearAllPost);
            objParam[32] = new SqlParameter(DL.Properties.Resources.BasicWage12HrsPerDay, basicWage12HrsPerDay);
            objParam[33] = new SqlParameter(DL.Properties.Resources.OTFor9th12thHrsOTRate, otFor9TH12THHoursOTRate);
            objParam[34] = new SqlParameter(DL.Properties.Resources.OT7thDay12Hrs, ot7THDay12Hrs);
            objParam[35] = new SqlParameter(DL.Properties.Resources.IncentiveAllowance, incentiveAllowance);
            objParam[36] = new SqlParameter(DL.Properties.Resources.HolidayPay13Days8Hrs, holidayPay13Days8Hrs);
            objParam[37] = new SqlParameter(DL.Properties.Resources.SickPayCompensation, sickPayCompensation);
            objParam[38] = new SqlParameter(DL.Properties.Resources.VacationPay, vacationPay);
            objParam[39] = new SqlParameter(DL.Properties.Resources.ProvidentFund, providentFund);
            objParam[40] = new SqlParameter(DL.Properties.Resources.SocialWelfareFund, socialWelfareFund);
            objParam[41] = new SqlParameter(DL.Properties.Resources.WorkmanCompensationFund, workmanCompensationFund);
            objParam[42] = new SqlParameter(DL.Properties.Resources.MonthlyBonusPayment, monthlyBonusPayment);
            objParam[43] = new SqlParameter(DL.Properties.Resources.TotalDirectLaborCost, totalDirectLaborCost);
            objParam[44] = new SqlParameter(DL.Properties.Resources.EquipmentsCost, equipmentsCost);
            objParam[45] = new SqlParameter(DL.Properties.Resources.TotalOperationCosts, totalOperationCosts);
            objParam[46] = new SqlParameter(DL.Properties.Resources.TotalDirectCost, totalDirectCost);
            objParam[47] = new SqlParameter(DL.Properties.Resources.OverHeadAllocation, overheadAllocation);
            objParam[48] = new SqlParameter(DL.Properties.Resources.TotalLocaladministrativeCost, totalLocalAdministrativeCost);
            objParam[49] = new SqlParameter(DL.Properties.Resources.PhoneAndFax, phoneAndFax);
            objParam[50] = new SqlParameter(DL.Properties.Resources.GeneralLibilityInsurance, generalLiabilityInsurance);
            objParam[51] = new SqlParameter(DL.Properties.Resources.TotalLocalOverheadCost, totalLocalOverheadCost);
            objParam[52] = new SqlParameter(DL.Properties.Resources.OverAllTotalCost, overallTotalCost);
            objParam[53] = new SqlParameter(DL.Properties.Resources.RatePerPostAsPerMargin, ratePerPostAsPerMargin);
            objParam[54] = new SqlParameter(DL.Properties.Resources.SumOfTotalPost, sumOfTotalPost);
            objParam[55] = new SqlParameter(DL.Properties.Resources.SumOfTotalHrs, sumOfTotalHrs);
            objParam[56] = new SqlParameter(DL.Properties.Resources.VoccationHrs, vocationHours);
            objParam[57] = new SqlParameter(DL.Properties.Resources.SickProvision, sickProvision);
            objParam[58] = new SqlParameter(DL.Properties.Resources.TrainingHrs, trainingHrs);
            objParam[59] = new SqlParameter(DL.Properties.Resources.OTRate, otRate);
            objParam[60] = new SqlParameter(DL.Properties.Resources.HolidayRate, holidayRate);
            objParam[61] = new SqlParameter(DL.Properties.Resources.OT7thDayRate, ot7THDayRate);
            objParam[62] = new SqlParameter(DL.Properties.Resources.SickLeaveValue, sickLeaveValue);
            objParam[63] = new SqlParameter(DL.Properties.Resources.VoccationDayValue, vocationDayValue);
            objParam[64] = new SqlParameter(DL.Properties.Resources.BonusPerMonthPerGuardRate, bonusPerMonthPerGuardRate);
            objParam[65] = new SqlParameter(DL.Properties.Resources.PfRate, providentFundRate);
            objParam[66] = new SqlParameter(DL.Properties.Resources.SocialWelfareRate, socialWelfareRate);
            objParam[67] = new SqlParameter(DL.Properties.Resources.WorkmenCommensationRate, workmenCompensationRate);
            objParam[68] = new SqlParameter(DL.Properties.Resources.TotalEquipmentCost, totalEquipmentCost);
            objParam[69] = new SqlParameter(DL.Properties.Resources.OverheadAllocationRate, overheadAllocationRate);
            objParam[70] = new SqlParameter(DL.Properties.Resources.PhoneFaxRate, phoneFaxRate);
            objParam[71] = new SqlParameter(DL.Properties.Resources.GeneralLiabilityInsuranceRate, generalLiabilityInsuranceRate);
            objParam[72] = new SqlParameter(DL.Properties.Resources.IncentiveMonthlyOrYearly, incentiveMonthlyOrYearly);
            objParam[73] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheetService_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// Costs the sheet item insert.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <param name="typeOfItem">The type of item.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="itemDesc">The item desc.</param>
        /// <param name="uom">The uom.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="quotedRate">The quoted rate.</param>
        /// <param name="total">The total.</param>
        /// <param name="depreciationMonthsForEquipment">The depreciation months for equipment.</param>
        /// <param name="equipmentValuePerYear">The equipment value per year.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetItemInsert(string locationAutoId, string costSheetNo, string costSheetAmendmentNo, string typeOfItem, string itemTypeCode, string itemDesc, string uom, string quantity, string quotedRate, string total, string depreciationMonthsForEquipment, string equipmentValuePerYear, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TypeOfItem, typeOfItem);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ItemDesc, itemDesc);
            objParam[6] = new SqlParameter(DL.Properties.Resources.UOM, uom);
            objParam[7] = new SqlParameter(DL.Properties.Resources.Qty, quantity);
            objParam[8] = new SqlParameter(DL.Properties.Resources.QuotedRate, quotedRate);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Total, total);
            objParam[10] = new SqlParameter(DL.Properties.Resources.DepreciationMonthsForEquipment, depreciationMonthsForEquipment);
            objParam[11] = new SqlParameter(DL.Properties.Resources.EquipmentValuePerYear, equipmentValuePerYear);
            objParam[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheetItem_Insert", objParam);
            return ds;
        }
        #endregion
        #region Update Data
        /// <summary>
        /// Costs the sheet update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <param name="costSheetDate">The cost sheet date.</param>
        /// <param name="costSheetStatus">The cost sheet status.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="preparedBy">The prepared by.</param>
        /// <param name="preparedDate">The prepared date.</param>
        /// <param name="verifiedBy">The verified by.</param>
        /// <param name="verifiedDate">The verified date.</param>
        /// <param name="approvedBy">The approved by.</param>
        /// <param name="approvedDate">The approved date.</param>
        /// <param name="margin">The margin.</param>
        /// <param name="bankGuaranteeAmount">The bank guarantee amount.</param>
        /// <param name="contractStampAmount">The contract stamp amount.</param>
        /// <param name="airportFeeAmt">The airport fee amt.</param>
        /// <param name="totalEquipmentCostYearly">The total equipment cost yearly.</param>
        /// <param name="otherAddChargesMonthly">The other add charges monthly.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="totalAmountWithMargin">The total amount with margin.</param>
        /// <param name="equipmentRentalActual">The equipment rental actual.</param>
        /// <param name="totalSellingPriceActual">The total selling price actual.</param>
        /// <param name="minusCostActual">The minus cost actual.</param>
        /// <param name="grossProfitActual">The gross profit actual.</param>
        /// <param name="grossMarginActual">The gross margin actual.</param>
        /// <param name="contributionPerHeadActual">The contribution per head actual.</param>
        /// <param name="equipmentRentalApm">The equipment rental apm.</param>
        /// <param name="totalSellingPriceApm">The total selling price apm.</param>
        /// <param name="minusCostApm">The minus cost apm.</param>
        /// <param name="grossProfitApm">The gross profit apm.</param>
        /// <param name="grossMarginApm">The gross margin apm.</param>
        /// <param name="contributionPerHeadApm">The contribution per head apm.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetUpdate(string locationAutoId, string costSheetNo, string costSheetAmendmentNo, string costSheetDate, string costSheetStatus, string clientCode, string preparedBy, string preparedDate, string verifiedBy, string verifiedDate, string approvedBy, string approvedDate, string margin, string bankGuaranteeAmount, string contractStampAmount, string airportFeeAmt, string totalEquipmentCostYearly, string otherAddChargesMonthly, string totalAmount, string totalAmountWithMargin, string equipmentRentalActual, string totalSellingPriceActual, string minusCostActual, string grossProfitActual, string grossMarginActual, string contributionPerHeadActual, string equipmentRentalApm, string totalSellingPriceApm, string minusCostApm, string grossProfitApm, string grossMarginApm, string contributionPerHeadApm, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[33];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.CostSheetDate, costSheetDate);
            objParam[4] = new SqlParameter(DL.Properties.Resources.CostSheetStatus, costSheetStatus);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.PreparedBy, preparedBy);
            if (preparedDate.Length == 0)
            { objParam[7] = new SqlParameter(DL.Properties.Resources.PreparedDate, DBNull.Value); }
            else
            { objParam[7] = new SqlParameter(DL.Properties.Resources.PreparedDate, DL.Common.DateFormat(preparedDate)); }
            objParam[8] = new SqlParameter(DL.Properties.Resources.VarifedBy, verifiedBy);
            if (verifiedDate.Length == 0)
            { objParam[9] = new SqlParameter(DL.Properties.Resources.VerifiedDate, DBNull.Value); }
            else
            { objParam[9] = new SqlParameter(DL.Properties.Resources.VerifiedDate, DL.Common.DateFormat(verifiedDate)); }
            objParam[10] = new SqlParameter(DL.Properties.Resources.ApprovedBy, approvedBy);
            if (approvedDate.Length == 0)
            { objParam[11] = new SqlParameter(DL.Properties.Resources.ApprovedDate, DBNull.Value); }
            else
            { objParam[11] = new SqlParameter(DL.Properties.Resources.ApprovedDate, DL.Common.DateFormat(approvedDate)); }
            objParam[12] = new SqlParameter(DL.Properties.Resources.Margin, margin);
            objParam[13] = new SqlParameter(DL.Properties.Resources.BankGuaranteeAmount, bankGuaranteeAmount);
            objParam[14] = new SqlParameter(DL.Properties.Resources.ContractStampAmount, contractStampAmount);
            objParam[15] = new SqlParameter(DL.Properties.Resources.AirportFeeAmt, airportFeeAmt);
            objParam[16] = new SqlParameter(DL.Properties.Resources.TotalEquipmentCostYearly, totalEquipmentCostYearly);
            objParam[17] = new SqlParameter(DL.Properties.Resources.OtherAddChargesMonthly, otherAddChargesMonthly);
            objParam[18] = new SqlParameter(DL.Properties.Resources.TotalAmount, totalAmount);
            objParam[19] = new SqlParameter(DL.Properties.Resources.TotalAmountWithMargin, totalAmountWithMargin);
            objParam[20] = new SqlParameter(DL.Properties.Resources.EquipmentRentalActual, equipmentRentalActual);
            objParam[21] = new SqlParameter(DL.Properties.Resources.TotalSellingPriceActual, totalSellingPriceActual);
            objParam[22] = new SqlParameter(DL.Properties.Resources.MinusCostActual, minusCostActual);
            objParam[23] = new SqlParameter(DL.Properties.Resources.GrossProfitActual, grossProfitActual);
            objParam[24] = new SqlParameter(DL.Properties.Resources.GrossMarginActual, grossMarginActual);
            objParam[25] = new SqlParameter(DL.Properties.Resources.ContributionPerHeadActual, contributionPerHeadActual);
            objParam[26] = new SqlParameter(DL.Properties.Resources.EquipmentRentalAPM, equipmentRentalApm);
            objParam[27] = new SqlParameter(DL.Properties.Resources.TotalSellingPriceAPM, totalSellingPriceApm);
            objParam[28] = new SqlParameter(DL.Properties.Resources.MinusCostAPM, minusCostApm);
            objParam[29] = new SqlParameter(DL.Properties.Resources.GROSSProfitAPM, grossProfitApm);
            objParam[30] = new SqlParameter(DL.Properties.Resources.GrossMarginAPM, grossMarginApm);
            objParam[31] = new SqlParameter(DL.Properties.Resources.ContributionPerHeadAPM, contributionPerHeadApm);
            objParam[32] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheet_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Costs the sheet service update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <param name="costSheetLineNo">The cost sheet line no.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="designationDesc">The designation desc.</param>
        /// <param name="uom">The uom.</param>
        /// <param name="numberOfPerson">The number of person.</param>
        /// <param name="workingDay">The working day.</param>
        /// <param name="normalHours">The normal hours.</param>
        /// <param name="otHours">The ot hours.</param>
        /// <param name="hourlyWageRate">The hourly wage rate.</param>
        /// <param name="incentiveAllowanceYearly">The incentive allowance yearly.</param>
        /// <param name="quotedRate">The quoted rate.</param>
        /// <param name="total">The total.</param>
        /// <param name="actual">The actual.</param>
        /// <param name="asPerMargin">As per margin.</param>
        /// <param name="totalHrsVocationSickTraining">The total HRS vocation sick training.</param>
        /// <param name="daysPerWeek">The days per week.</param>
        /// <param name="hoursPerDay">The hours per day.</param>
        /// <param name="postsRequired">The posts required.</param>
        /// <param name="recommendedMenByCategory">The recommended men by category.</param>
        /// <param name="totalHrsPerWeek">The total HRS per week.</param>
        /// <param name="totalHrsPerYearActual">The total HRS per year actual.</param>
        /// <param name="totalRegularHrsPerYear">The total regular HRS per year.</param>
        /// <param name="totalOTHrsPerYear">The total ot HRS per year.</param>
        /// <param name="totalRegularHrsPayPerDay">The total regular HRS pay per day.</param>
        /// <param name="totalOTHrsPayPerDay">The total ot HRS pay per day.</param>
        /// <param name="totalHrsPayPerDay">The total HRS pay per day.</param>
        /// <param name="totalHrsPerWeekAllPost">The total HRS per week all post.</param>
        /// <param name="totalHrsPerYearAllPost">The total HRS per year all post.</param>
        /// <param name="totalRegularHrsPerYearAllPost">The total regular HRS per year all post.</param>
        /// <param name="totalOTHrsPerYearAllPost">The total ot HRS per year all post.</param>
        /// <param name="basicWage12HrsPerDay">The basic wage12 HRS per day.</param>
        /// <param name="otFor9TH12THHoursOTRate">The ot for9 t H12 th hours ot rate.</param>
        /// <param name="ot7THDay12Hrs">The ot7 th day12 HRS.</param>
        /// <param name="incentiveAllowance">The incentive allowance.</param>
        /// <param name="holidayPay13Days8Hrs">The holiday pay13 days8 HRS.</param>
        /// <param name="sickPayCompensation">The sick pay compensation.</param>
        /// <param name="vacationPay">The vacation pay.</param>
        /// <param name="providentFund">The provident fund.</param>
        /// <param name="socialWelfareFund">The social welfare fund.</param>
        /// <param name="workmanCompensationFund">The workman compensation fund.</param>
        /// <param name="monthlyBonusPayment">The monthly bonus payment.</param>
        /// <param name="totalDirectLaborCost">The total direct labor cost.</param>
        /// <param name="equipmentsCost">The equipments cost.</param>
        /// <param name="totalOperationCosts">The total operation costs.</param>
        /// <param name="totalDirectCost">The total direct cost.</param>
        /// <param name="overheadAllocation">The overhead allocation.</param>
        /// <param name="totalLocalAdministrativeCost">The total local administrative cost.</param>
        /// <param name="phoneAndFax">The phone and fax.</param>
        /// <param name="generalLiabilityInsurance">The general liability insurance.</param>
        /// <param name="totalLocalOverheadCost">The total local overhead cost.</param>
        /// <param name="overallTotalCost">The overall total cost.</param>
        /// <param name="ratePerPostAsPerMargin">The rate per post as per margin.</param>
        /// <param name="sumOfTotalPost">The sum of total post.</param>
        /// <param name="sumOfTotalHrs">The sum of total HRS.</param>
        /// <param name="vocationHours">The vocation hours.</param>
        /// <param name="sickProvision">The sick provision.</param>
        /// <param name="trainingHrs">The training HRS.</param>
        /// <param name="otRate">The ot rate.</param>
        /// <param name="holidayRate">The holiday rate.</param>
        /// <param name="ot7THDayRate">The ot7 th day rate.</param>
        /// <param name="sickLeaveValue">The sick leave value.</param>
        /// <param name="vocationDayValue">The vocation day value.</param>
        /// <param name="bonusPerMonthPerGuardRate">The bonus per month per guard rate.</param>
        /// <param name="providentFundRate">The provident fund rate.</param>
        /// <param name="socialWelfareRate">The social welfare rate.</param>
        /// <param name="workmenCompensationRate">The workmen compensation rate.</param>
        /// <param name="totalEquipmentCost">The total equipment cost.</param>
        /// <param name="overheadAllocationRate">The overhead allocation rate.</param>
        /// <param name="phoneFaxRate">The phone fax rate.</param>
        /// <param name="generalLiabilityInsuranceRate">The general liability insurance rate.</param>
        /// <param name="incentiveMonthlyOrYearly">The incentive monthly or yearly.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetServiceUpdate(string locationAutoId, string costSheetNo, string costSheetAmendmentNo, string costSheetLineNo, string soRank, string designationDesc, string uom, string numberOfPerson, string workingDay, string normalHours, string otHours, string hourlyWageRate, string incentiveAllowanceYearly, string quotedRate, string total, string actual, string asPerMargin, string totalHrsVocationSickTraining, string daysPerWeek, string hoursPerDay, string postsRequired, string recommendedMenByCategory, string totalHrsPerWeek, string totalHrsPerYearActual, string totalRegularHrsPerYear, string totalOTHrsPerYear, string totalRegularHrsPayPerDay, string totalOTHrsPayPerDay, string totalHrsPayPerDay, string totalHrsPerWeekAllPost, string totalHrsPerYearAllPost, string totalRegularHrsPerYearAllPost, string totalOTHrsPerYearAllPost, string basicWage12HrsPerDay, string otFor9TH12THHoursOTRate, string ot7THDay12Hrs, string incentiveAllowance, string holidayPay13Days8Hrs, string sickPayCompensation, string vacationPay, string providentFund, string socialWelfareFund, string workmanCompensationFund, string monthlyBonusPayment, string totalDirectLaborCost, string equipmentsCost, string totalOperationCosts, string totalDirectCost, string overheadAllocation, string totalLocalAdministrativeCost, string phoneAndFax, string generalLiabilityInsurance, string totalLocalOverheadCost, string overallTotalCost, string ratePerPostAsPerMargin, string sumOfTotalPost, string sumOfTotalHrs, string vocationHours, string sickProvision, string trainingHrs, string otRate, string holidayRate, string ot7THDayRate, string sickLeaveValue, string vocationDayValue, string bonusPerMonthPerGuardRate, string providentFundRate, string socialWelfareRate, string workmenCompensationRate, string totalEquipmentCost, string overheadAllocationRate, string phoneFaxRate, string generalLiabilityInsuranceRate, string incentiveMonthlyOrYearly, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[75];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.CostSheetLineNO, costSheetLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[5] = new SqlParameter(DL.Properties.Resources.DesignationDesc, designationDesc);
            objParam[6] = new SqlParameter(DL.Properties.Resources.UOM, uom);
            objParam[7] = new SqlParameter(DL.Properties.Resources.NumberOfPerson, numberOfPerson);
            objParam[8] = new SqlParameter(DL.Properties.Resources.WorkingDay, workingDay);
            objParam[9] = new SqlParameter(DL.Properties.Resources.NormalHours, normalHours);
            objParam[10] = new SqlParameter(DL.Properties.Resources.OTHours, otHours);
            objParam[11] = new SqlParameter(DL.Properties.Resources.HourlyWageRate, hourlyWageRate);
            objParam[12] = new SqlParameter(DL.Properties.Resources.IncentiveAllowanceYearly, incentiveAllowanceYearly);
            objParam[13] = new SqlParameter(DL.Properties.Resources.QuotedRate, quotedRate);
            objParam[14] = new SqlParameter(DL.Properties.Resources.Total, total);
            objParam[15] = new SqlParameter(DL.Properties.Resources.Actual, actual);
            objParam[16] = new SqlParameter(DL.Properties.Resources.AsPerMargin, asPerMargin);
            objParam[17] = new SqlParameter(DL.Properties.Resources.TotalHrsVoccationSickTraining, totalHrsVocationSickTraining);
            objParam[18] = new SqlParameter(DL.Properties.Resources.DaysPerWeek, daysPerWeek);
            objParam[19] = new SqlParameter(DL.Properties.Resources.HoursPerDay, hoursPerDay);
            objParam[20] = new SqlParameter(DL.Properties.Resources.PostsRequired, postsRequired);
            objParam[21] = new SqlParameter(DL.Properties.Resources.RecommendedMenByCategory, recommendedMenByCategory);
            objParam[22] = new SqlParameter(DL.Properties.Resources.TotalHrsPerWeek, totalHrsPerWeek);
            objParam[23] = new SqlParameter(DL.Properties.Resources.TotalHrsPerYearActual, totalHrsPerYearActual);
            objParam[24] = new SqlParameter(DL.Properties.Resources.TotalRegularHrsPerYear, totalRegularHrsPerYear);
            objParam[25] = new SqlParameter(DL.Properties.Resources.TotalOTHrsPerYear, totalOTHrsPerYear);
            objParam[26] = new SqlParameter(DL.Properties.Resources.TotalRegularHrsPayPerDay, totalRegularHrsPayPerDay);
            objParam[27] = new SqlParameter(DL.Properties.Resources.TotalOTHrsPayPerDay, totalOTHrsPayPerDay);
            objParam[28] = new SqlParameter(DL.Properties.Resources.TotalHrsPayPerDay, totalHrsPayPerDay);
            objParam[29] = new SqlParameter(DL.Properties.Resources.TotalHrsPerWeekAllPost, totalHrsPerWeekAllPost);
            objParam[30] = new SqlParameter(DL.Properties.Resources.TotalHrsPerYearAllPost, totalHrsPerYearAllPost);
            objParam[31] = new SqlParameter(DL.Properties.Resources.TotalRegularHrsPerYearAllPost, totalRegularHrsPerYearAllPost);
            objParam[32] = new SqlParameter(DL.Properties.Resources.TotalOTHrsPerYearAllPost, totalOTHrsPerYearAllPost);
            objParam[33] = new SqlParameter(DL.Properties.Resources.BasicWage12HrsPerDay, basicWage12HrsPerDay);
            objParam[34] = new SqlParameter(DL.Properties.Resources.OTFor9th12thHrsOTRate, otFor9TH12THHoursOTRate);
            objParam[35] = new SqlParameter(DL.Properties.Resources.OT7thDay12Hrs, ot7THDay12Hrs);
            objParam[36] = new SqlParameter(DL.Properties.Resources.IncentiveAllowance, incentiveAllowance);
            objParam[37] = new SqlParameter(DL.Properties.Resources.HolidayPay13Days8Hrs, holidayPay13Days8Hrs);
            objParam[38] = new SqlParameter(DL.Properties.Resources.SickPayCompensation, sickPayCompensation);
            objParam[39] = new SqlParameter(DL.Properties.Resources.VacationPay, vacationPay);
            objParam[40] = new SqlParameter(DL.Properties.Resources.ProvidentFund, providentFund);
            objParam[41] = new SqlParameter(DL.Properties.Resources.SocialWelfareFund, socialWelfareFund);
            objParam[42] = new SqlParameter(DL.Properties.Resources.WorkmanCompensationFund, workmanCompensationFund);
            objParam[43] = new SqlParameter(DL.Properties.Resources.MonthlyBonusPayment, monthlyBonusPayment);
            objParam[44] = new SqlParameter(DL.Properties.Resources.TotalDirectLaborCost, totalDirectLaborCost);
            objParam[45] = new SqlParameter(DL.Properties.Resources.EquipmentsCost, equipmentsCost);
            objParam[46] = new SqlParameter(DL.Properties.Resources.TotalOperationCosts, totalOperationCosts);
            objParam[47] = new SqlParameter(DL.Properties.Resources.TotalDirectCost, totalDirectCost);
            objParam[48] = new SqlParameter(DL.Properties.Resources.OverHeadAllocation, overheadAllocation);
            objParam[49] = new SqlParameter(DL.Properties.Resources.TotalLocaladministrativeCost, totalLocalAdministrativeCost);
            objParam[50] = new SqlParameter(DL.Properties.Resources.PhoneAndFax, phoneAndFax);
            objParam[51] = new SqlParameter(DL.Properties.Resources.GeneralLibilityInsurance, generalLiabilityInsurance);
            objParam[52] = new SqlParameter(DL.Properties.Resources.TotalLocalOverheadCost, totalLocalOverheadCost);
            objParam[53] = new SqlParameter(DL.Properties.Resources.OverAllTotalCost, overallTotalCost);
            objParam[54] = new SqlParameter(DL.Properties.Resources.RatePerPostAsPerMargin, ratePerPostAsPerMargin);
            objParam[55] = new SqlParameter(DL.Properties.Resources.SumOfTotalPost, sumOfTotalPost);
            objParam[56] = new SqlParameter(DL.Properties.Resources.SumOfTotalHrs, sumOfTotalHrs);
            objParam[57] = new SqlParameter(DL.Properties.Resources.VoccationHrs, vocationHours);
            objParam[58] = new SqlParameter(DL.Properties.Resources.SickProvision, sickProvision);
            objParam[59] = new SqlParameter(DL.Properties.Resources.TrainingHrs, trainingHrs);
            objParam[60] = new SqlParameter(DL.Properties.Resources.OTRate, otRate);
            objParam[61] = new SqlParameter(DL.Properties.Resources.HolidayRate, holidayRate);
            objParam[62] = new SqlParameter(DL.Properties.Resources.OT7thDayRate, ot7THDayRate);
            objParam[63] = new SqlParameter(DL.Properties.Resources.SickLeaveValue, sickLeaveValue);
            objParam[64] = new SqlParameter(DL.Properties.Resources.VoccationDayValue, vocationDayValue);
            objParam[65] = new SqlParameter(DL.Properties.Resources.BonusPerMonthPerGuardRate, bonusPerMonthPerGuardRate);
            objParam[66] = new SqlParameter(DL.Properties.Resources.PfRate, providentFundRate);
            objParam[67] = new SqlParameter(DL.Properties.Resources.SocialWelfareRate, socialWelfareRate);
            objParam[68] = new SqlParameter(DL.Properties.Resources.WorkmenCommensationRate, workmenCompensationRate);
            objParam[69] = new SqlParameter(DL.Properties.Resources.TotalEquipmentCost, totalEquipmentCost);
            objParam[70] = new SqlParameter(DL.Properties.Resources.OverheadAllocationRate, overheadAllocationRate);
            objParam[71] = new SqlParameter(DL.Properties.Resources.PhoneFaxRate, phoneFaxRate);
            objParam[72] = new SqlParameter(DL.Properties.Resources.GeneralLiabilityInsuranceRate, generalLiabilityInsuranceRate);
            objParam[73] = new SqlParameter(DL.Properties.Resources.IncentiveMonthlyOrYearly, incentiveMonthlyOrYearly);
            objParam[74] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheetService_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Costs the sheet item update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <param name="costSheetLineNo">The cost sheet line no.</param>
        /// <param name="typeOfItem">The type of item.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="itemDesc">The item desc.</param>
        /// <param name="uom">The uom.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="quotedRate">The quoted rate.</param>
        /// <param name="total">The total.</param>
        /// <param name="depreciationMonthsForEquipment">The depreciation months for equipment.</param>
        /// <param name="equipmentValuePerYear">The equipment value per year.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetItemUpdate(string locationAutoId, string costSheetNo, string costSheetAmendmentNo, string costSheetLineNo, string typeOfItem, string itemTypeCode, string itemDesc, string uom, string quantity, string quotedRate, string total, string depreciationMonthsForEquipment, string equipmentValuePerYear, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[14];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.CostSheetLineNO, costSheetLineNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TypeOfItem, typeOfItem);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ItemDesc, itemDesc);
            objParam[7] = new SqlParameter(DL.Properties.Resources.UOM, uom);
            objParam[8] = new SqlParameter(DL.Properties.Resources.Qty, quantity);
            objParam[9] = new SqlParameter(DL.Properties.Resources.QuotedRate, quotedRate);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Total, total);
            objParam[11] = new SqlParameter(DL.Properties.Resources.DepreciationMonthsForEquipment, depreciationMonthsForEquipment);
            objParam[12] = new SqlParameter(DL.Properties.Resources.EquipmentValuePerYear, equipmentValuePerYear);
            objParam[13] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheetItem_update", objParam);
            return ds;
        }
        #endregion
        #region Delete Data
        /// <summary>
        /// Costs the sheet delete.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="costSheetNo">The cost sheet no.</param>
        /// <param name="costSheetAmendmentNo">The cost sheet amendment no.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetDelete(string locationAutoId, string costSheetNo, string costSheetAmendmentNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CostSheetNo, costSheetNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CostSheetAmendmentNo, costSheetAmendmentNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSales_CostSheet_Delete", objParam);
            return ds;
        }
        #endregion
        #endregion

        #region Product Master
        /// <summary>
        /// To get the SORank and designation for a Company from ProductMaster
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>SORank,DesignationCode,DesignationDesc in dataset</returns>
        public DataSet SaleOrderRankGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ProductMaster_Get", objParam);
            return ds;
        }
        public DataSet GetChargeRate(string SoNo, string SoRank, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, SoNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SORank, SoRank);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetChargeRateOnTheBasisOfQuotationNo", objParam);
            return ds;
        }
        /// <summary>
        /// To insert a new new sorank in product master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ProductMasterAdd(string companyCode, string soRank, string designationCode, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ProductMaster_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To Update a SORank in Product Master
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="designationCode">The designation code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ProductMasterUpdate(string companyCode, string soRank, string designationCode, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Designationcode, designationCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ProductMaster_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To Delete a SORank in ProductMaster
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="soRank">The so rank.</param>
        /// <returns>DataSet.</returns>
        public DataSet ProductMasterDelete(string companyCode, string soRank)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ProductMaster_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To get SORank effective dates and Rates from ProductDetails
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soRank">The so rank.</param>
        /// <returns>DataSet.</returns>
        public DataSet ProductDetailGet(string locationAutoId, string soRank)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ProductDetails_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get SORank or Product Rates from ProductDetails,
        /// Parameters (LocationAutoId Of Product, ProductCode, LocationAutoId Of saleOrder, saleOrder No., SaleOrder Amendement No. (to get the with effective date))
        /// in case of Modifcation/Amendement in Existing SoLine and SOrank is changed then get the Effective date of Zero Amendement No.
        /// else if SOrank is not changed the Rate get from SOLine no of the Maximum Authorized SO Amendement No.
        /// In case case of new SOLine the effective Date Get from the Maximum Amendement No.
        /// </summary>
        /// <param name="asmtLocationAutoId">The asmt location automatic identifier.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="soStatusAuthorized">The so status authorized.</param>
        /// <returns>DataSet.</returns>
        public DataSet ProductRateForDateGet(string asmtLocationAutoId, string soRank, string locationAutoId, string soNo, string soAmendNo, string soLineNo, string soStatusAuthorized)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtLocationAutoID, asmtLocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[6] = new SqlParameter(DL.Properties.Resources.SoStatusAuthorized, soStatusAuthorized);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ProductRateForSOLine_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Update the Product details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="effectiveTo">The effective to.</param>
        /// <param name="rate">The rate.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ProductDetailUpdate(string locationAutoId, string soRank, string effectiveFrom, string effectiveTo, string rate, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SORank, soRank);
            objParam[2] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, DL.Common.DateFormat(effectiveFrom));
            if (string.IsNullOrEmpty(effectiveTo))
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DBNull.Value);
            }
            else
            {
                objParam[3] = new SqlParameter(DL.Properties.Resources.EffectiveTo, DL.Common.DateFormat(effectiveTo));
            }
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rate, rate);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ProductDetails_Update", objParam);
            return ds;
        }
        #endregion

        #region Post Master
        /// <summary>
        /// Posts the get all.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostGetAll(string clientCode, string asmtId)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Post_GetAll", objParm);
            return ds;
        }


        /// <summary>
        /// functions is used to fetch  post with their OTFactor
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorGetAll(string clientCode, string asmtId)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PostOTFactor_GetAll", objParm);
            return ds;
        }


        /// <summary>
        /// function is used to fetch last amendment records.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorGetLastAmendement(string clientCode, string asmtId)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PostOTFactor_LastAmendment", objParm);
            return ds;
        }


        /// <summary>
        /// function is used to fetch post description
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorFillPostDesc(string clientCode, string asmtId)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PostOTFactor_PostDesc", objParm);
            return ds;
        }

        /// <summary>
        /// Get Post details based on client and assignment with comma
        /// </summary>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet FillPostBasedOnClientAndAssignment(string asmtId)
        {
            var objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PostBasedOnClientAndAssignment_Get", objParm);
            return ds;
        }


        /// <summary>
        /// Get system parameter
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostGetAll(int locationAutoId,string clientCode, string asmtId)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Post_Locationwise_GetAll", objParm);
            return ds;
        }

        /// <summary>
        /// Posts the get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet PostGetAll()
        {

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PostForALocation_GetAll");
            return ds;
        }
        /// <summary>
        /// Positions the get.
        /// </summary>
        /// <param name="postcode">The postcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PosGet(string postcode)
        {
            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Post_GetByPostId", objParm);
            return ds;
        }


        /// <summary>
        /// To get postID
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postcode">The postcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PosOTFactorGet(string clientCode, string asmtId, string postcode)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PostOTFactor_GetByPostId", objParm);
            return ds;
        }
        /// <summary>
        /// Posts the add.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="postDesc">The post desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="shortPostDesc">The short post desc.</param>
        /// <param name="phoneNo">The phone no.</param>
        /// <param name="postpositionNo">The postposition no.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostAdd(string clientCode, string asmtId, string postcode, string postDesc, string userId, string shortPostDesc, string phoneNo, string postpositionNo)
        {
            SqlParameter[] objParm = new SqlParameter[8];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostDesc, postDesc);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ShtPostDesc, shortPostDesc);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PhoneNo, phoneNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.PostPositionNo, int.Parse(postpositionNo));
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Post_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// function is used  for adding records to capture otfactor
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="PostAutoId">The post automatic identifier.</param>
        /// <param name="EffectiveFrom">The effective from.</param>
        /// <param name="EffectiveTo">The effective to.</param>
        /// <param name="ElementCode">The element code.</param>
        /// <param name="PayrollCode">The payroll code.</param>
        /// <param name="OTFactor">The ot factor.</param>
        /// <param name="AmendNo">The amend no.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorAdd(string clientCode, string asmtId, int PostAutoId, DateTime EffectiveFrom, DateTime EffectiveTo, string ElementCode, string PayrollCode, double OTFactor, int AmendNo, string userId)
        {
            SqlParameter[] objParm = new SqlParameter[10];

            objParm[0] = new SqlParameter(DL.Properties.Resources.PostAutoId, PostAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EffectiveFrom, EffectiveFrom);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EffectiveTo, EffectiveTo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.ElementCode, ElementCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.OTFactor, OTFactor);
            objParm[5] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[8] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[9] = new SqlParameter(DL.Properties.Resources.PayrollCode,PayrollCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PostOTFactor_Insert", objParm);
            return ds;
        }


        #region BreakShift

        /// <summary>
        /// To insert Break shift details
        /// </summary>
        /// <param name="locationAutoId">The Location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The Asmt Identifier</param>
        /// <param name="PostAutoId">The post automatic identifier.</param>
        /// <param name="Shift">The Shift Hours</param>
        /// <param name="Break">The Break Minutes</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset .</returns>
        public DataSet BreakShiftAdd(string locationAutoId, string clientCode, string asmtId, string PostAutoId, double Shift, double Break, string userId)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.PostAutoId, PostAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Shift, Shift);
            objParm[3] = new SqlParameter(DL.Properties.Resources.BreakHrs, Break);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_BreakShift_Insert", objParm);
            return ds;
        }


        /// <summary>
        /// Export to Excel
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The Asmt Identifier</param>
        /// <param name="PostAutoId">The Post Identifier</param>
        /// <param name="Shift">The Shift Hours</param>
        /// <param name="Break">The Break Minutes</param>
        /// <param name="status">The status.</param>
        /// <returns>Dataset .</returns>
        public DataSet BreakShiftExport(string locationAutoId, string clientCode, string asmtId, string PostAutoId, double Shift, double Break, string status)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostAutoId, PostAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Shift, Shift);
            objParm[5] = new SqlParameter(DL.Properties.Resources.BreakHrs, Break);
            objParm[6] = new SqlParameter(DL.Properties.Resources.Status, status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udpmst_Breakshift_ExportToExcel", objParm);
            return ds;
        }


        /// <summary>
        /// Break shift Update functionality
        /// </summary>
        /// <param name="locationAutoId">The Location Auto Identifier</param>
        /// <param name="clientCode">The client Code</param>
        /// <param name="asmtId">The assignment identifier</param>
        /// <param name="postAutoId">The post auto identifier</param>
        /// <param name="Shift">The shift Hours</param>
        /// <param name="Break">The Break Hours</param>
        /// <param name="AmendNo">The Amend Number</param>
        /// <param name="userId">The user identifier</param>
        /// <returns>DataSet .</returns>
        public DataSet BreakShiftUpdate(string locationAutoId, string clientCode, string asmtId, string postAutoId, double Shift, double Break, int AmendNo, string userId)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Shift, Shift);
            objParm[5] = new SqlParameter(DL.Properties.Resources.BreakHrs, Break);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_BreakShift_Update", objParm);
            return ds;
        }


        /// <summary>
        /// To fetch Data of BreakShift
        /// </summary>
        /// <param name="locationAutoId">The Location Identifier</param>
        /// <returns>DataSet .</returns>
        public DataSet BreakShift(string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_BreakShift_Get", objParm);
            return ds;
        }

        /// <summary>
        /// To Fetch data of last amendments
        /// </summary>
        /// <param name="locationAutoId">The Location Identifier</param>
        /// <returns>Dataset.</returns>
        public DataSet BreakShiftLastAmendment(string locationAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_BreakShift_GetLastAmendment", objParm);
            return ds;
        }


       #endregion



        /// <summary>
        /// Posts the update.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="postDesc">The post desc.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="shortPostDesc">The short post desc.</param>
        /// <param name="phoneNo">The phone no.</param>
        /// <param name="postpositionNo">The postposition no.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostUpdate(string clientCode, string asmtId, string postcode, string postDesc, string userId, string shortPostDesc, string phoneNo, string postpositionNo)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            Guard.ArgumentConvertibleTo<int>(postpositionNo, "myIntArgument");

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PostDesc, postDesc);
            objParm[4] = new SqlParameter(DL.Properties.Resources.ShtPostDesc, shortPostDesc);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PhoneNo, phoneNo);
            objParm[6] = new SqlParameter(DL.Properties.Resources.PostPositionNo, int.Parse(postpositionNo));
            objParm[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Post_Update", objParm);
            return ds;
        }


        /// <summary>
        /// to update otfactor records
        /// </summary>
        /// <param name="PostAutoId">The post automatic identifier.</param>
        /// <param name="EffectiveTo">The effective to.</param>
        /// <param name="ElementCode">The element code.</param>
        /// <param name="OTFactor">The ot factor.</param>
        /// <param name="AmendNo">The amend no.</param>
        /// <param name="PayrollCode">The payroll code.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorUpdate(int PostAutoId, DateTime EffectiveTo, string ElementCode, double OTFactor, int AmendNo,string PayrollCode)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.PostAutoId, PostAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.EffectiveTo, EffectiveTo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ElementCode, ElementCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.OTFactor, OTFactor);
            objParm[4] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PayrollCode, PayrollCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PostOTFactor_Update", objParm);
            return ds;
        }




        /// <summary>
        /// Posts the delete.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostDelete(string clientCode, string asmtId, string postAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.PostAutoId, postAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Post_Delete", objParm);
            return ds;
        }
        #endregion Post Master

        #region Item Type
        /// <summary>
        /// To get the ItemTypeCode, ItemDesc, Value for a CompanyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleItemTypeGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ItemType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order item rate get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="itemCode">The item code.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemRateGet(string companyCode, string itemCode, string quantity)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemCode, itemCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Qty, quantity);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ItemType_GetRate", objParam);
            return ds;
        }
        /// <summary>
        /// To insert a new ItemType
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="itemDesc">The item desc.</param>
        /// <param name="value">The value.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemTypeAdd(string companyCode, string itemTypeCode, string itemDesc, string value, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ItemDesc, itemDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ItemType_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// To Update a ItemType by CompanyCode and ItemTypeCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="itemDesc">The item desc.</param>
        /// <param name="value">The value.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemTypeUpdate(string companyCode, string itemTypeCode, string itemDesc, string value, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ItemDesc, itemDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ItemType_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To Delete a ItemType by CompanyCode and ItemTypeCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemTypeDelete(string companyCode, string itemTypeCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ItemTypeCode, itemTypeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ItemType_Delete", objParam);
            return ds;
        }
        #endregion

        #region Sale Order Type
        /// <summary>
        /// To get the SaleOrderTypeCode and SaleOrderTypeDesc of a specific CompanyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderTypeGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOType_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To save a New Sale Order type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="saleOrderTypeCode">The sale order type code.</param>
        /// <param name="saleOrderTypeDesc">The sale order type desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderTypeAdd(string companyCode, string saleOrderTypeCode, string saleOrderTypeDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SaleOrderTypeCode, saleOrderTypeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SaleOrderTypeDesc, saleOrderTypeDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOType_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// To Update a Sale Order type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="saleOrderTypeCode">The sale order type code.</param>
        /// <param name="saleOrderTypeDesc">The sale order type desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderTypeUpdate(string companyCode, string saleOrderTypeCode, string saleOrderTypeDesc, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SaleOrderTypeCode, saleOrderTypeCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SaleOrderTypeDesc, saleOrderTypeDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOType_Update", objParam);
            return ds;
        }
        /// <summary>
        /// To Delete a Sale Order type
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="saleOrderTypeCode">The sale order type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderTypeDelete(string companyCode, string saleOrderTypeCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SaleOrderTypeCode, saleOrderTypeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SOType_Delete", objParam);
            return ds;
        }
        #endregion

        #region Sale Order Deployment Pattern grid Related Functions
        /// <summary>
        /// To Get DeploymentPattren for a SOLine of a SaleOrder amendmentNo and LocationAutoId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentPatternGet(string locationAutoId, string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODepPattren_Get", objParam);
            return ds;
        }

        /// <summary>
        /// To Update Sale Order Deployment Patterns
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="dtSODeptPattern">The dt so dept pattern.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">dtSODeptPattern</exception>
        public DataSet SaleOrderDeploymentPatternUpdate(string locationAutoId, string soNo, string soAmendNo, string soLineNo, DataTable dtSODeptPattern, string modifiedBy)
        {
            if (dtSODeptPattern == null || dtSODeptPattern.Rows == null)
            {
                throw new ArgumentNullException("dtSODeptPattern");
            }
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                foreach (DataRow dr in dtSODeptPattern.Rows)
                {
                    SqlParameter[] objParam = new SqlParameter[13];
                    Guard.ArgumentConvertibleTo<Int64>(locationAutoId, "myInt64Argument");
                    Guard.ArgumentConvertibleTo<int>(soAmendNo, "myIntArgument");
                    Guard.ArgumentConvertibleTo<int>(soLineNo, "myIntArgument");
                    Guard.ArgumentConvertibleTo<int>(dr[0].ToString(), "myIntArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[1].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[2].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[3].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[4].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[5].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[6].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(dr[7].ToString(), "myBoolArgument");

                    objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int64.Parse(locationAutoId));
                    objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
                    objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, int.Parse(soAmendNo));
                    objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, int.Parse(soLineNo));
                    objParam[4] = new SqlParameter(DL.Properties.Resources.WeekNo, int.Parse(dr[0].ToString()));
                    objParam[5] = new SqlParameter(DL.Properties.Resources.SUN, bool.Parse(dr[1].ToString()));
                    objParam[6] = new SqlParameter(DL.Properties.Resources.MON, bool.Parse(dr[2].ToString()));
                    objParam[7] = new SqlParameter(DL.Properties.Resources.TUE, bool.Parse(dr[3].ToString()));
                    objParam[8] = new SqlParameter(DL.Properties.Resources.WED, bool.Parse(dr[4].ToString()));
                    objParam[9] = new SqlParameter(DL.Properties.Resources.THU, bool.Parse(dr[5].ToString()));
                    objParam[10] = new SqlParameter(DL.Properties.Resources.FRI, bool.Parse(dr[6].ToString()));
                    objParam[11] = new SqlParameter(DL.Properties.Resources.SAT, bool.Parse(dr[7].ToString()));

                    objParam[12] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODeploymentPattern_Update", objParam);
                }
                tx.Complete();
            }
            return ds;
        }

        /// <summary>
        /// Sales the order deployment pattern get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentPatternGet(string locationAutoId, string soNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SODepPattren_GetALL", objParam);
            return ds;
        }
        #endregion

        #region 


        /// <summary>
        /// To get Skills Language
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientLanguageSkillsGet(string companyCode, string clientCode)
        {
            var objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsLanguage_Get", objParam);
            return ds;
        }

        /// <summary>
        /// To Insert language Detail in sale order skill.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientLanguageSkillsAdd(string companyCode, string clientCode, string languageCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsLanguage_Add", objParam);
            return ds;
        }

        /// <summary>
        /// To update language Detail in sale order skill.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientLanguageSkillsUpdate(string companyCode, string clientCode, string languageCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsLanguage_Update", objParam);
            return ds;

        }
        /// <summary>
        /// To Delete language from Sale order sills
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="languageCode">The language code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientLanguageSkillsDelete(string companyCode, string clientCode, string languageCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsLanguage_Delete", objParam);
            return ds;
        }



        /// <summary>
        /// To get Skills Qualifications
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientQualificationSkillsGet(string companyCode, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsQualification_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Clients the qualification skills add.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientQualificationSkillsAdd(string companyCode, string clientCode, string qualificationCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsQualification_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To update Qualification Rigidity level in sale order skill.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientQualificationSkillsUpdate(string companyCode, string clientCode, string qualificationCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsQualification_Update", objParam);
            return ds;

        }
        /// <summary>
        /// Clients the qualification skills delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientQualificationSkillsDelete(string companyCode, string clientCode, string qualificationCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsQualification_Delete", objParam);
            return ds;
        }


        /// <summary>
        /// To get Skills Training
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientTrainingSkillsGet(string companyCode, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsTraining_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Clients the training skills add.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientTrainingSkillsAdd(string companyCode, string clientCode, string trainingCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsTraining_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To Update training In Sale order Skill
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientTrainingSkillsUpdate(string companyCode, string clientCode, string trainingCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsTraining_Update", objParam);
            return ds;

        }
        /// <summary>
        /// To Delete Training in Sale order Skill
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientTrainingSkillsDelete(string companyCode, string clientCode, string trainingCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsTraining_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// To get Skills Other
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientOtherSkillsGet(string companyCode, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsOther_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Add ID Type In Sale Order Skills
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientOtherSkillsAdd(string companyCode, string clientCode, string otherSkillCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.OtherSkillCode, otherSkillCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsOther_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To Update ID Type In Sale order Skill
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientOtherSkillsUpdate(string companyCode, string clientCode, string otherSkillCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.OtherSkillCode, otherSkillCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsOther_Update", objParam);
            return ds;

        }
        /// <summary>
        /// To Delete ID Type In Sale order Skill
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientOtherSkillsDelete(string companyCode, string clientCode, string otherSkillCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.OtherSkillCode, otherSkillCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientSkillsOther_Delete", objParam);
            return ds;
        }
        #endregion



        #region SaleOrder skills Set/Language/Qualification/Training
        /// <summary>
        /// To get Skills Sets
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderSkillsSetGet(string locationAutoId, string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsSet_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order skills set add.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="shiftRequired">The shift required.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="isMandatoryGender">The is mandatory gender.</param>
        /// <param name="height">The height.</param>
        /// <param name="isMandatoryHeight">Height of the is mandatory.</param>
        /// <param name="maritalStatus">The marital status.</param>
        /// <param name="isMandatoryMaritalStatus">The is mandatory marital status.</param>
        /// <param name="militaryStatus">The military status.</param>
        /// <param name="isMandatoryMilitaryStatus">The is mandatory military status.</param>
        /// <param name="smoker">The smoker.</param>
        /// <param name="isMandatorySmoker">The is mandatory smoker.</param>
        /// <param name="foodStyle">The food style.</param>
        /// <param name="isMandatoryFoodStyle">The is mandatory food style.</param>
        /// <param name="homeState">State of the home.</param>
        /// <param name="isMandatoryHomeState">State of the is mandatory home.</param>
        /// <param name="previousTotalExperience">The previous total experience.</param>
        /// <param name="isMandatoryPreviousTotalExperience">The is mandatory previous total experience.</param>
        /// <param name="religion">The religion.</param>
        /// <param name="isMandatoryReligion">The is mandatory religion.</param>
        /// <param name="nationality">The nationality.</param>
        /// <param name="isMandatoryNationality">The is mandatory nationality.</param>
        /// <param name="otherSkills">The other skills.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderSkillsSetAdd(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string shiftRequired, string gender, string isMandatoryGender, string height, string isMandatoryHeight, string maritalStatus, string isMandatoryMaritalStatus, string militaryStatus, string isMandatoryMilitaryStatus, string smoker, string isMandatorySmoker, string foodStyle, string isMandatoryFoodStyle, string homeState, string isMandatoryHomeState, string previousTotalExperience, string isMandatoryPreviousTotalExperience, string religion, string isMandatoryReligion, string nationality, string isMandatoryNationality, string otherSkills, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[27];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryGender, "myBoolArgument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ShiftRequired, shiftRequired);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Gender, gender);
            objParam[6] = new SqlParameter(DL.Properties.Resources.IsMandatoryGender, bool.Parse(isMandatoryGender));
            if (height.Length == 0)
            {
                objParam[7] = new SqlParameter(DL.Properties.Resources.Height, 0);
            }
            else
            {
                Guard.ArgumentConvertibleTo<double>(height, "myDoubleArgument");
                objParam[7] = new SqlParameter(DL.Properties.Resources.Height, double.Parse(height));
            }
            Guard.ArgumentConvertibleTo<bool>(isMandatoryHeight, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryMaritalStatus, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatorySmoker, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryFoodStyle, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryHomeState, "myBoolArgument");

            objParam[8] = new SqlParameter(DL.Properties.Resources.IsMandatoryHeight, bool.Parse(isMandatoryHeight));
            objParam[9] = new SqlParameter(DL.Properties.Resources.MaritalStatus, maritalStatus);
            objParam[10] = new SqlParameter(DL.Properties.Resources.IsMandatoryMaritalStatus, bool.Parse(isMandatoryMaritalStatus));
            objParam[11] = new SqlParameter(DL.Properties.Resources.MilitaryStatus, militaryStatus);
            objParam[12] = new SqlParameter(DL.Properties.Resources.IsMandatoryMilitaryStatus, bool.Parse(isMandatoryMilitaryStatus));
            objParam[13] = new SqlParameter(DL.Properties.Resources.Smoker, smoker);
            objParam[14] = new SqlParameter(DL.Properties.Resources.IsMandatorySmoker, bool.Parse(isMandatorySmoker));
            objParam[15] = new SqlParameter(DL.Properties.Resources.FoodStyle, foodStyle);
            objParam[16] = new SqlParameter(DL.Properties.Resources.IsMandatoryFoodStyle, bool.Parse(isMandatoryFoodStyle));
            objParam[17] = new SqlParameter(DL.Properties.Resources.HomeState, homeState);
            objParam[18] = new SqlParameter(DL.Properties.Resources.IsMandatoryHomeState, bool.Parse(isMandatoryHomeState));
            if (previousTotalExperience.Length == 0)
            {
                objParam[19] = new SqlParameter(DL.Properties.Resources.PrevTotalExp, 0);
            }
            else
            {
                Guard.ArgumentConvertibleTo<double>(previousTotalExperience, "myDoubleArgument");
                objParam[19] = new SqlParameter(DL.Properties.Resources.PrevTotalExp, double.Parse(previousTotalExperience));
            }
            Guard.ArgumentConvertibleTo<bool>(isMandatoryPreviousTotalExperience, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryReligion, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryNationality, "myBoolArgument");

            objParam[20] = new SqlParameter(DL.Properties.Resources.IsMandatoryPrevTotalExp, bool.Parse(isMandatoryPreviousTotalExperience));
            objParam[21] = new SqlParameter(DL.Properties.Resources.Religion, religion);
            objParam[22] = new SqlParameter(DL.Properties.Resources.IsMandatoryReligion, bool.Parse(isMandatoryReligion));
            objParam[23] = new SqlParameter(DL.Properties.Resources.Nationality, nationality);
            objParam[24] = new SqlParameter(DL.Properties.Resources.IsMandatoryNationality, bool.Parse(isMandatoryNationality));
            objParam[25] = new SqlParameter(DL.Properties.Resources.OtherSkills, otherSkills);
            objParam[26] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsSet_Add", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order skills set update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="shiftRequired">The shift required.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="isMandatoryGender">The is mandatory gender.</param>
        /// <param name="height">The height.</param>
        /// <param name="isMandatoryHeight">Height of the is mandatory.</param>
        /// <param name="maritalStatus">The marital status.</param>
        /// <param name="isMandatoryMaritalStatus">The is mandatory marital status.</param>
        /// <param name="militaryStatus">The military status.</param>
        /// <param name="isMandatoryMilitaryStatus">The is mandatory military status.</param>
        /// <param name="smoker">The smoker.</param>
        /// <param name="isMandatorySmoker">The is mandatory smoker.</param>
        /// <param name="foodStyle">The food style.</param>
        /// <param name="isMandatoryFoodStyle">The is mandatory food style.</param>
        /// <param name="homeState">State of the home.</param>
        /// <param name="isMandatoryHomeState">State of the is mandatory home.</param>
        /// <param name="previousTotalExperience">The previous total experience.</param>
        /// <param name="isMandatoryPreviousTotalExperience">The is mandatory previous total experience.</param>
        /// <param name="religion">The religion.</param>
        /// <param name="isMandatoryReligion">The is mandatory religion.</param>
        /// <param name="nationality">The nationality.</param>
        /// <param name="isMandatoryNationality">The is mandatory nationality.</param>
        /// <param name="otherSkills">The other skills.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderSkillsSetUpdate(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string shiftRequired, string gender, string isMandatoryGender, string height, string isMandatoryHeight, string maritalStatus, string isMandatoryMaritalStatus, string militaryStatus, string isMandatoryMilitaryStatus, string smoker, string isMandatorySmoker, string foodStyle, string isMandatoryFoodStyle, string homeState, string isMandatoryHomeState, string previousTotalExperience, string isMandatoryPreviousTotalExperience, string religion, string isMandatoryReligion, string nationality, string isMandatoryNationality, string otherSkills, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[27];
            Guard.ArgumentConvertibleTo<Int32>(locationAutoId, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryGender, "myBoolArgument");
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Int32.Parse(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ShiftRequired, shiftRequired);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Gender, gender);
            objParam[6] = new SqlParameter(DL.Properties.Resources.IsMandatoryGender, bool.Parse(isMandatoryGender));
            if (height.Length == 0)
            {
                objParam[7] = new SqlParameter(DL.Properties.Resources.Height, 0);
            }
            else
            {
                Guard.ArgumentConvertibleTo<double>(height, "myDoubleArgument");
                objParam[7] = new SqlParameter(DL.Properties.Resources.Height, double.Parse(height));
            }
            Guard.ArgumentConvertibleTo<bool>(isMandatoryHeight, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryMaritalStatus, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryMilitaryStatus, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatorySmoker, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryFoodStyle, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryHomeState, "myBoolArgument");

            objParam[8] = new SqlParameter(DL.Properties.Resources.IsMandatoryHeight, bool.Parse(isMandatoryHeight));
            objParam[9] = new SqlParameter(DL.Properties.Resources.MaritalStatus, maritalStatus);
            objParam[10] = new SqlParameter(DL.Properties.Resources.IsMandatoryMaritalStatus, bool.Parse(isMandatoryMaritalStatus));
            objParam[11] = new SqlParameter(DL.Properties.Resources.MilitaryStatus, militaryStatus);
            objParam[12] = new SqlParameter(DL.Properties.Resources.IsMandatoryMilitaryStatus, bool.Parse(isMandatoryMilitaryStatus));
            objParam[13] = new SqlParameter(DL.Properties.Resources.Smoker, smoker);
            objParam[14] = new SqlParameter(DL.Properties.Resources.IsMandatorySmoker, bool.Parse(isMandatorySmoker));
            objParam[15] = new SqlParameter(DL.Properties.Resources.FoodStyle, foodStyle);
            objParam[16] = new SqlParameter(DL.Properties.Resources.IsMandatoryFoodStyle, bool.Parse(isMandatoryFoodStyle));
            objParam[17] = new SqlParameter(DL.Properties.Resources.HomeState, homeState);
            objParam[18] = new SqlParameter(DL.Properties.Resources.IsMandatoryHomeState, bool.Parse(isMandatoryHomeState));
            if (previousTotalExperience.Length == 0)
            {
                objParam[19] = new SqlParameter(DL.Properties.Resources.PrevTotalExp, 0);
            }
            else
            {
                Guard.ArgumentConvertibleTo<double>(previousTotalExperience, "myDoubleArgument");
                objParam[19] = new SqlParameter(DL.Properties.Resources.PrevTotalExp, double.Parse(previousTotalExperience));
            }
            Guard.ArgumentConvertibleTo<bool>(isMandatoryPreviousTotalExperience, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryReligion, "myBoolArgument");
            Guard.ArgumentConvertibleTo<bool>(isMandatoryNationality, "myBoolArgument");
            objParam[20] = new SqlParameter(DL.Properties.Resources.IsMandatoryPrevTotalExp, bool.Parse(isMandatoryPreviousTotalExperience));
            objParam[21] = new SqlParameter(DL.Properties.Resources.Religion, religion);
            objParam[22] = new SqlParameter(DL.Properties.Resources.IsMandatoryReligion, bool.Parse(isMandatoryReligion));
            objParam[23] = new SqlParameter(DL.Properties.Resources.Nationality, nationality);
            objParam[24] = new SqlParameter(DL.Properties.Resources.IsMandatoryNationality, bool.Parse(isMandatoryNationality));
            objParam[25] = new SqlParameter(DL.Properties.Resources.OtherSkills, otherSkills);
            objParam[26] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsSet_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the order skills set delete.
        /// </summary>
        /// <param name="soLineSkillsAutoId">The so line skills automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderSkillsSetDelete(string soLineSkillsAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SOLineSkillsAutoID, soLineSkillsAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsSet_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// To get Skills Language
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet LanguageSkillsGet(string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsLanguage_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Insert language Detail in sale order skill.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LanguageSkillsAdd(string soNo, string soAmendNo, string soLineNo, string languageCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsLanguage_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To update language Detail in sale order skill.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="languageCode">The language code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet LanguageSkillsUpdate(string soNo, string soAmendNo, string soLineNo, string languageCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsLanguage_Update", objParam);
            return ds;

        }
        /// <summary>
        /// To Delete language from Sale order sills
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="languageCode">The language code.</param>
        /// <returns>DataSet.</returns>
        public DataSet LanguageSkillsDelete(string soNo, string soAmendNo, string soLineNo, string languageCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.LanguageCode, languageCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsLanguage_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// To get Skills Qualifications
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet QualificationSkillsGet(string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsQualification_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Qualifications the skills add.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet QualificationSkillsAdd(string soNo, string soAmendNo, string soLineNo, string qualificationCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsQualification_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To update Qualification Rigidity level in sale order skill.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet QualificationSkillsUpdate(string soNo, string soAmendNo, string soLineNo, string qualificationCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsQualification_Update", objParam);
            return ds;

        }
        /// <summary>
        /// Qualifications the skills delete.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QualificationSkillsDelete(string soNo, string soAmendNo, string soLineNo, string qualificationCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.QualificationCode, qualificationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsQualification_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// To get Skills Training
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingSkillsGet(string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsTraining_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Trainings the skills add.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingSkillsAdd(string soNo, string soAmendNo, string soLineNo, string trainingCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsTraining_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To Update training In Sale order Skill
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingSkillsUpdate( string soNo, string soAmendNo, string soLineNo, string trainingCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsTraining_Update", objParam);
            return ds;

        }
        /// <summary>
        /// To Delete Training in Sale order Skill
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingSkillsDelete(string soNo, string soAmendNo, string soLineNo, string trainingCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.TrainingCode, trainingCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsTraining_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// To get Skills Other
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtherSkillsGet(string soNo, string soAmendNo, string soLineNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsOther_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To Add ID Type In Sale Order Skills
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtherSkillsAdd(string soNo, string soAmendNo, string soLineNo, string otherSkillCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.OtherSkillCode, otherSkillCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsOther_Add", objParam);
            return ds;
        }
        /// <summary>
        /// To Update ID Type In Sale order Skill
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtherSkillsUpdate(string soNo, string soAmendNo, string soLineNo, string otherSkillCode, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.OtherSkillCode, otherSkillCode);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsOther_Update", objParam);
            return ds;

        }
        /// <summary>
        /// To Delete ID Type In Sale order Skill
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtherSkillsDelete(string soNo, string soAmendNo, string soLineNo, string otherSkillCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            Guard.ArgumentConvertibleTo<Int32>(soAmendNo, "myInt32Argument");
            Guard.ArgumentConvertibleTo<Int32>(soLineNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SOAmendNo, Int32.Parse(soAmendNo));
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, Int32.Parse(soLineNo));
            objParam[3] = new SqlParameter(DL.Properties.Resources.OtherSkillCode, otherSkillCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SkillsOther_Delete", objParam);
            return ds;
        }
        #endregion

        #region Function Related to Get System Parameters
        /// <summary>
        /// Gets the Days in month and remaining days of saleorder
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParametersGet(string companyCode, string hrLocationCode, string locationCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HrLocationCode, hrLocationCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SystemParameters_Get", objParm);
            return ds;
        }
        #endregion

        #region Function Related to Sales Report
        /// <summary>
        /// Fuction related to Post Composition
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="branchCode">The branch code.</param>
        /// <param name="divisionCode">The division code.</param>
        /// <param name="asOnDate">As on date.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostCompositionGet(string companyCode, string branchCode, string divisionCode, string asOnDate)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.BranchCode, branchCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DivisionCode, divisionCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AsOnDate, asOnDate);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_salesrpt_postcomposition_Egypt", objParam);
            return ds;
        }
        #endregion

        /// <summary>
        /// Schedules the roster hours get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ScheduleRosterHoursGet(string locationAutoId, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SchHrsVsContractedHrs_ToDoList", objParam);
            return ds;
        }

        #region POP
        /// <summary>
        /// Clients the assignments get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientAssignmentsGet(string companyCode, string locationAutoId, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AssignmentClientWise", objParam);
            return ds;

        }


        /// <summary>
        /// Tags the master get.
        /// </summary>
        /// <param name="tourId">The tour identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TagMasterGet(string tourId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TourId, tourId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagCreationGuardTour_Fetch", objParam);
            return ds;
        }


        /// <summary>
        /// Tags the master update.
        /// </summary>
        /// <param name="tourId">The tour identifier.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="tagDesc">The tag desc.</param>
        /// <param name="scheduleTime">The schedule time.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TagMasterUpdate(string tourId, string tagId, string tagDesc, string scheduleTime, int interval, string duration, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TourId, tourId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TagDesc, tagDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ScheduleTime, scheduleTime);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Interval, interval);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Duration, duration);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagCreation_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Tags the identifier delete.
        /// </summary>
        /// <param name="tourId">The tour identifier.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TagIdDelete(string tourId, string tagId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TourId, tourId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagCreation_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Tours the identifier get.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postcode">The postcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet TourIdGet(string clientCode, string asmtCode, string postcode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagTourID_Fetch", objParam);
            return ds;
        }

        /// <summary>
        /// Tours the interval.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet TourInterval(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "upd_IntervalFeq", objParam);
            return ds;
        }
        //upd_IntervalFeq
        #endregion


        /// <summary>
        /// Tags the creation.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TagCreation(string clientCode, string asmtCode, string postcode, string startTime, string endTime, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.StartTime, startTime);
            objParam[4] = new SqlParameter(DL.Properties.Resources.EndTime, endTime);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GuardTourID_create", objParam);
            return ds;
        }

        /// <summary>
        /// Tags the insert.
        /// </summary>
        /// <param name="tourId">The tour identifier.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="tagDesc">The tag desc.</param>
        /// <param name="scheduleTime">The schedule time.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TagInsert(string tourId, string tagId, string tagDesc, string scheduleTime, int interval, string duration, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.TourId, tourId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TagId, tagId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TagDesc, tagDesc);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ScheduleTime, scheduleTime);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Interval, interval);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Duration, duration);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GuardTourID_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Postcodes the get.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postcode">The postcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostcodeGet(string locationCode, string asmtCode, string postcode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtCode, asmtCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.PostCode, postcode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "POSTCODE_POP", objParam);
            return ds;
        }

        #region Function Related to Customer Constraint

        /// <summary>
        /// Clients the constraint get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientConstraintGet(string companyCode, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientConstraint_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the constraint insert.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <param name="constraintDescAutoId">The constraint desc automatic identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="operatorValue">The operator value.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientConstraintInsert(string companyCode, string constraintTypeAutoId, string constraintDescAutoId, string value, string operatorValue, string rigidityLevel, string modifiedBy, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintDescAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Operator, operatorValue);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientConstraint_Insert", objParam);
            return ds;
        }
        /// <summary>
        /// Clients the constraint update.
        /// </summary>
        /// <param name="clientConstraintAutoId">The client constraint automatic identifier.</param>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="operatorValue">The operator value.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientConstraintUpdate(string clientConstraintAutoId, string constraintTypeAutoId, string constraintAutoId, string value, string operatorValue, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientConstraintAutoID, clientConstraintAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Operator, operatorValue);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientConstraint_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Clients the constraint delete.
        /// </summary>
        /// <param name="clientConstraintAutoId">The client constraint automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientConstraintDelete(string clientConstraintAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientConstraintAutoID, clientConstraintAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientConstraint_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To update the Sale orders with client Constraints
        /// </summary>
        /// <param name="CompanyCode">The company code.</param>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="Status">The status.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientConstraintsUpdateToSaleOrders(string CompanyCode, string LocationAutoId, string ClientCode, string Status, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Status, Status);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_ClientConstraint_UpdateToSaleOrder", objParam);
            return ds;
        }
        #endregion

        #region Function Related to sales Constraint

        /// <summary>
        /// Sales the constraint get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleConstraintGet(string companyCode, string soNo, string soLineNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[2] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SaleConstraint_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To insert a new Sale order constraint
        /// </summary>
        /// <param name="LocationAutoId">The location automatic identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <param name="constraintDescAutoId">The constraint desc automatic identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="operatorValue">The operator value.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleConstraintInsert(string LocationAutoId, string companyCode, string constraintTypeAutoId, string constraintDescAutoId, string value, string operatorValue, string rigidityLevel, string modifiedBy, string soNo, string soLineNo, string soAmendNo)
        {
            SqlParameter[] objParam = new SqlParameter[11];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintDescAutoId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Operator, operatorValue);
            objParam[6] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[7] = new SqlParameter(DL.Properties.Resources.SONO, soNo);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            objParam[9] = new SqlParameter(DL.Properties.Resources.SoLineNo, soLineNo);
            objParam[10] = new SqlParameter(DL.Properties.Resources.SOAmendNo, soAmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SaleConstraint_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Sales the constraint update.
        /// </summary>
        /// <param name="saleConstraintAutoId">The sale constraint automatic identifier.</param>
        /// <param name="constraintTypeAutoId">The constraint type automatic identifier.</param>
        /// <param name="constraintAutoId">The constraint automatic identifier.</param>
        /// <param name="value">The value.</param>
        /// <param name="operatorValue">The operator value.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleConstraintUpdate(string saleConstraintAutoId, string constraintTypeAutoId, string constraintAutoId, string value, string operatorValue, string rigidityLevel, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SaleConstraintAutoID, saleConstraintAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ConstraintTypeAutoId, constraintTypeAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ConstraintAutoId, constraintAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Value, value);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Operator, operatorValue);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Rigiditylevel, rigidityLevel);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SaleConstraint_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Sales the constraint delete.
        /// </summary>
        /// <param name="saleConstraintAutoId">The sale constraint automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleConstraintDelete(string saleConstraintAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.SaleConstraintAutoID, saleConstraintAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_SaleConstraint_Delete", objParam);
            return ds;

        }

        #endregion

        #region function related to client weekly holiday timings
        /// <summary>
        /// Defaults the weekly holiday times for client add.
        /// </summary>
        /// <param name="dayFrom">The day from.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="dayTo">The day to.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet DefaultWeeklyHolidayTimesForClientAdd(string dayFrom, string timeFrom, string dayTo, string timeTo, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DayFrom, dayFrom);
            objParam[1] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[2] = new SqlParameter(DL.Properties.Resources.DayTo, dayTo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_ClientDefaultWHTime_Save", objParam);
            return ds;
        }


        /// <summary>
        /// Weeklies the holiday times for client add.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="dayFrom">The day from.</param>
        /// <param name="timeFrom">The time from.</param>
        /// <param name="dayTo">The day to.</param>
        /// <param name="timeTo">The time to.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet WeeklyHolidayTimesForClientAdd(string clientCode, string dayFrom, string timeFrom, string dayTo, string timeTo, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.DayFrom, dayFrom);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TimeFrom, timeFrom);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DayTo, dayTo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.TimeTo, timeTo);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_ClientWHTime_Save", objParam);
            return ds;
        }


        /// <summary>
        /// Defaults the weekly holiday times for client get.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet DefaultWeeklyHolidayTimesForClientGet()
        {
            SqlParameter[] objParam = new SqlParameter[0];
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "updSale_ClientDefaultWHTime_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Weeklies the holiday times for client get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet WeeklyHolidayTimesForClientGetAll()
        {
            SqlParameter[] objParam = new SqlParameter[0];
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSale_ClientWHTime_GetAll", objParam);
            return ds;
        }

        #endregion

        #region Function Related to Assignment Address Contact Details

        /// <summary>
        /// Clients the contact information get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientContactInformationGetAll(string companyCode, string clientCode, string asmtId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SaleClientDetails_ContactInformation_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the contact information add.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="contactName">Name of the contact.</param>
        /// <param name="contactDesignation">The contact designation.</param>
        /// <param name="contactDepartment">The contact department.</param>
        /// <param name="contactNumber">The contact number.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientContactInformationAdd(string companyCode, string clientCode, string asmtId, string contactName, string contactDesignation, string contactDepartment, string contactNumber, string emailAddress, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ContactName, contactName);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ContactDesignation, contactDesignation);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ContactDepartment, contactDepartment);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ContactNumber, contactNumber);
            objParam[7] = new SqlParameter(DL.Properties.Resources.EMailAddress, emailAddress);
            objParam[8] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SaleClientDetails_ContactInformation_Add", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the contact information delete.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="contactUniqueNo">The contact unique no.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientContactInformationDelete(string companyCode, string clientCode, string asmtId, string contactUniqueNo)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            Guard.ArgumentConvertibleTo<Int32>(contactUniqueNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ContactUniqueNo, int.Parse(contactUniqueNo));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SaleClientDetails_ContactInformation_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Clients the contact information update.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="contactUniqueNo">The contact unique no.</param>
        /// <param name="contactName">Name of the contact.</param>
        /// <param name="contactDesignation">The contact designation.</param>
        /// <param name="contactDepartment">The contact department.</param>
        /// <param name="contactNumber">The contact number.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientContactInformationUpdate(string companyCode, string clientCode, string asmtId, string contactUniqueNo, string contactName, string contactDesignation, string contactDepartment, string contactNumber, string emailAddress, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            Guard.ArgumentConvertibleTo<Int32>(contactUniqueNo, "myInt32Argument");

            objParam[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ContactUniqueNo, int.Parse(contactUniqueNo));
            objParam[4] = new SqlParameter(DL.Properties.Resources.ContactName, contactName);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ContactDesignation, contactDesignation);
            objParam[6] = new SqlParameter(DL.Properties.Resources.ContactDepartment, contactDepartment);
            objParam[7] = new SqlParameter(DL.Properties.Resources.ContactNumber, contactNumber);
            objParam[8] = new SqlParameter(DL.Properties.Resources.EMailAddress, emailAddress);
            objParam[9] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SaleClientDetails_ContactInformation_Update", objParam);
            return ds;
        }



        #endregion

        /// <summary>
        /// Insert Additional YLM Details for Client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="company">The company.</param>
        /// <param name="sectorCode">The sector code.</param>
        /// <param name="blMarketRegulation">if set to <c>true</c> [bl market regulation].</param>
        /// <returns>SqlDataReader.</returns>

        public SqlDataReader ClientAdditionalDetailsAdd(string locationAutoId, string clientCode,
                                                              string clientName, string company,
                                                              string sectorCode, bool blMarketRegulation)
        {

            SqlDataReader dsSale = null;
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AbvtClientName, clientName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.PvtCompanyNo, company);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SectorNo, sectorCode);
            objParam[5] = new SqlParameter(DL.Properties.Resources.MarketRegulation, blMarketRegulation);


            dsSale = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "udpClientCodeAdditionalDetailsInsert", objParam);
            return dsSale;

        }

        /// <summary>
        /// Retrieve all Additional Details for Client
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>SqlDataReader.</returns>
        /// <exception cref="System.ArgumentNullException">clientCode</exception>
        public SqlDataReader ClientAdditionalDetailsGetAll(string clientCode)
        {
            if (clientCode == null)
            {
                throw new ArgumentNullException("clientCode");
            }
            SqlDataReader dsSale = null;
            dsSale = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "udpClientCodeAdditionalDetailsGet",
                                             new SqlParameter(DL.Properties.Resources.ClientCode,
                                                              clientCode.ToString()));
            return dsSale;
        }

        /// <summary>
        /// Delete Additional Details Client Wise
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>SqlDataReader.</returns>
        /// <exception cref="System.ArgumentNullException">clientCode</exception>
        public SqlDataReader ClientAdditionalDetailsDelete(string clientCode)
        {
            if (clientCode == null)
            {
                throw new ArgumentNullException("clientCode");
            }
            SqlDataReader dsSale = null;
            dsSale = SqlHelper.ExecuteReader(CommandType.StoredProcedure, "udpClientCodeAdditionalDetailsDelete",
                                             new SqlParameter(DL.Properties.Resources.ClientCode,
                                                              clientCode.ToString()));
            return dsSale;
        }

        /*Code added by  on 8-Sep-2011 */
        /// <summary>
        /// Gets AreaIncharge Name for the AreaID
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGet(string locationAutoId, string areaId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstOperation_AreaIncharge_ByName", objParam);
            return ds;
        }

        /*Code added by  on 20-Jan-2012 */
        /// <summary>
        /// Client Assignment Export to Excel
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientListGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Sales_clientlist", objParam);
            return ds;
        }
        /// <summary>
        /// Clients the list a register get.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="Billable">if set to <c>true</c> [billable].</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientListARegisterGet(string locationCode, bool Billable)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationCode, locationCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Billable, Billable);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpCustomerGet", objParam);
            return ds;
        }
        /// <summary>
        /// Client Assignment And Sale Order Number Export
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientListGet(string companyCode, string isIncharge, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.Company, companyCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isIncharge);
            objParam[2] = new SqlParameter(DL.Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_Sales_clientlist_AreaWise", objParam);
            return ds;
        }

        /// <summary>
        /// Asmts the identifier amend no get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader AsmtIdAmendNoGet(string locationAutoId, string clientCode, string asmtId)
        {

            SqlDataReader dsSale = null;
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[2] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            dsSale = SqlHelper.ExecuteReader("udp_SaleClientDetails_AttendanceType_GetAmendNo", objParam);
            return dsSale;
        }


        #region YLMDETAILS

        /// <summary>
        /// Ylms the details insert.
        /// </summary>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="superAlertPriority">The super alert priority.</param>
        /// <param name="superAlertType">Type of the super alert.</param>
        /// <param name="superSms">The super SMS.</param>
        /// <param name="superEmail">The super email.</param>
        /// <param name="superAlertTimeGap">The super alert time gap.</param>
        /// <param name="officerAlertPriority">The officer alert priority.</param>
        /// <param name="officerAlertType">Type of the officer alert.</param>
        /// <param name="officer2Sms">The officer2 SMS.</param>
        /// <param name="officer2Email">The officer2 email.</param>
        /// <param name="officer2AlertTimeGap">The officer2 alert time gap.</param>
        /// <param name="minimumWorkTime">The minimum work time.</param>
        /// <param name="crossSiteFixEnable">if set to <c>true</c> [cross site fix enable].</param>
        /// <param name="blockOverQuantityShifts">if set to <c>true</c> [block over quantity shifts].</param>
        /// <param name="cutToTakenEnter">if set to <c>true</c> [cut to taken enter].</param>
        /// <param name="cutToTakenExit">if set to <c>true</c> [cut to taken exit].</param>
        /// <param name="roundEnterCut">The round enter cut.</param>
        /// <param name="roundExitCut">The round exit cut.</param>
        /// <param name="roundEnter">if set to <c>true</c> [round enter].</param>
        /// <param name="roundExit">if set to <c>true</c> [round exit].</param>
        /// <param name="enterSunday">The enter sunday.</param>
        /// <param name="exitSunday">The exit sunday.</param>
        /// <param name="enterMonday">The enter monday.</param>
        /// <param name="exitMonday">The exit monday.</param>
        /// <param name="enterTuesday">The enter tuesday.</param>
        /// <param name="exitTuesday">The exit tuesday.</param>
        /// <param name="enterWednesday">The enter wednesday.</param>
        /// <param name="exitWednesday">The exit wednesday.</param>
        /// <param name="enterThursday">The enter thursday.</param>
        /// <param name="exitThursday">The exit thursday.</param>
        /// <param name="enterFriday">The enter friday.</param>
        /// <param name="exitFriday">The exit friday.</param>
        /// <param name="enterSaturday">The enter saturday.</param>
        /// <param name="exitSaturday">The exit saturday.</param>
        /// <param name="dayHoursSunday">The day hours sunday.</param>
        /// <param name="dayHoursMonday">The day hours monday.</param>
        /// <param name="dayHoursTuesday">The day hours tuesday.</param>
        /// <param name="dayHoursWednesday">The day hours wednesday.</param>
        /// <param name="dayHoursThursday">The day hours thursday.</param>
        /// <param name="dayHoursFriday">The day hours friday.</param>
        /// <param name="dayHoursSaturday">The day hours saturday.</param>
        /// <param name="festival">if set to <c>true</c> [festival].</param>
        /// <param name="isInspectorCode">if set to <c>true</c> [is inspector code].</param>
        /// <param name="isOnetimeContract">if set to <c>true</c> [is onetime contract].</param>
        /// <param name="isReinforcementContract">if set to <c>true</c> [is reinforcement contract].</param>
        /// <param name="numberOfInspections">The number of inspections.</param>
        /// <param name="wefDate">The wef date.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataTable.</returns>
        public DataTable YlmDetailsInsert(string asmtId, string locationAutoId, string clientCode, int superAlertPriority, int superAlertType, string superSms, string superEmail, int superAlertTimeGap, int officerAlertPriority, int officerAlertType, string officer2Sms, string officer2Email, int officer2AlertTimeGap, float minimumWorkTime, bool crossSiteFixEnable, bool blockOverQuantityShifts, bool cutToTakenEnter, bool cutToTakenExit, int roundEnterCut, int roundExitCut, bool roundEnter, bool roundExit, string enterSunday, string exitSunday, string enterMonday, string exitMonday, string enterTuesday, string exitTuesday, string enterWednesday, string exitWednesday, string enterThursday, string exitThursday, string enterFriday, string exitFriday, string enterSaturday, string exitSaturday, float dayHoursSunday, float dayHoursMonday, float dayHoursTuesday, float dayHoursWednesday, float dayHoursThursday, float dayHoursFriday, float dayHoursSaturday, bool festival,
                                                 bool isInspectorCode, bool isOnetimeContract, bool isReinforcementContract, string numberOfInspections,string wefDate,string amendNo,string status)
        {
            DataTable dsSale = null;
            SqlParameter[] objParam = new SqlParameter[51];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.SuperAlertPriority, superAlertPriority);
            objParam[4] = new SqlParameter(DL.Properties.Resources.SuperAlertType, superAlertType);
            objParam[5] = new SqlParameter(DL.Properties.Resources.SuperSMS, superSms);
            objParam[6] = new SqlParameter(DL.Properties.Resources.SuperEmail, superEmail);
            objParam[7] = new SqlParameter(DL.Properties.Resources.SuperAlertTimeGap, superAlertTimeGap);
            objParam[8] = new SqlParameter(DL.Properties.Resources.OfficerAlertPriority, officerAlertPriority);
            objParam[9] = new SqlParameter(DL.Properties.Resources.OfficerAlertType, officerAlertType);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Officer2SMS, officer2Sms);
            objParam[11] = new SqlParameter(DL.Properties.Resources.Officer2Email, officer2Email);
            objParam[12] = new SqlParameter(DL.Properties.Resources.Officer2AlertTimeGap, officer2AlertTimeGap);
            objParam[13] = new SqlParameter(DL.Properties.Resources.MinWorkTime, minimumWorkTime);
            objParam[14] = new SqlParameter(DL.Properties.Resources.CrossSiteFixEnable, crossSiteFixEnable);
            objParam[15] = new SqlParameter(DL.Properties.Resources.BlockOverQtyShifts, blockOverQuantityShifts);
            objParam[16] = new SqlParameter(DL.Properties.Resources.CutToTekenEnter, cutToTakenEnter);
            objParam[17] = new SqlParameter(DL.Properties.Resources.CutToTekenExit, cutToTakenExit);
            objParam[18] = new SqlParameter(DL.Properties.Resources.RoundEnterCut, roundEnterCut);
            objParam[19] = new SqlParameter(DL.Properties.Resources.RoundExitCut, roundExitCut);
            objParam[20] = new SqlParameter(DL.Properties.Resources.RoundEnter, roundEnter);
            objParam[21] = new SqlParameter(DL.Properties.Resources.RoundExit, roundExit);
            Guard.ArgumentValidDate(enterSunday, "myDateArgument");
            Guard.ArgumentValidDate(exitSunday, "myDateArgument");
            Guard.ArgumentValidDate(enterMonday, "myDateArgument");
            Guard.ArgumentValidDate(exitMonday, "myDateArgument");
            Guard.ArgumentValidDate(enterTuesday, "myDateArgument");
            Guard.ArgumentValidDate(exitTuesday, "myDateArgument");
            Guard.ArgumentValidDate(enterWednesday, "myDateArgument");
            Guard.ArgumentValidDate(exitWednesday, "myDateArgument");
            Guard.ArgumentValidDate(enterFriday, "myDateArgument");
            Guard.ArgumentValidDate(exitFriday, "myDateArgument");
            Guard.ArgumentValidDate(enterSaturday, "myDateArgument");
            Guard.ArgumentValidDate(exitSaturday, "myDateArgument");

            objParam[22] = new SqlParameter(DL.Properties.Resources.EnterSunday, DateTime.Parse(enterSunday));
            objParam[23] = new SqlParameter(DL.Properties.Resources.ExitSunday, DateTime.Parse(exitSunday));
            objParam[24] = new SqlParameter(DL.Properties.Resources.EnterMonday, DateTime.Parse(enterMonday));
            objParam[25] = new SqlParameter(DL.Properties.Resources.ExitMonday, DateTime.Parse(exitMonday));
            objParam[26] = new SqlParameter(DL.Properties.Resources.EnterTuesday, DateTime.Parse(enterTuesday));
            objParam[27] = new SqlParameter(DL.Properties.Resources.ExitTuesday, DateTime.Parse(exitTuesday));
            objParam[28] = new SqlParameter(DL.Properties.Resources.EnterWed, DateTime.Parse(enterWednesday));
            objParam[29] = new SqlParameter(DL.Properties.Resources.ExitWed, DateTime.Parse(exitWednesday));
            objParam[30] = new SqlParameter(DL.Properties.Resources.EnterThru, DateTime.Parse(enterThursday));
            objParam[31] = new SqlParameter(DL.Properties.Resources.ExitThru, DateTime.Parse(exitThursday));
            objParam[32] = new SqlParameter(DL.Properties.Resources.EnterFri, DateTime.Parse(enterFriday));
            objParam[33] = new SqlParameter(DL.Properties.Resources.ExitFri, DateTime.Parse(exitFriday));
            objParam[34] = new SqlParameter(DL.Properties.Resources.EnterSat, DateTime.Parse(enterSaturday));
            objParam[35] = new SqlParameter(DL.Properties.Resources.ExitSat, DateTime.Parse(exitSaturday));
            objParam[36] = new SqlParameter(DL.Properties.Resources.DayHrSun, dayHoursSunday);
            objParam[37] = new SqlParameter(DL.Properties.Resources.DayHrMon, dayHoursMonday);
            objParam[38] = new SqlParameter(DL.Properties.Resources.DayHrTue, dayHoursTuesday);
            objParam[39] = new SqlParameter(DL.Properties.Resources.DayHrWed, dayHoursWednesday);
            objParam[40] = new SqlParameter(DL.Properties.Resources.DayHrThu, dayHoursThursday);
            objParam[41] = new SqlParameter(DL.Properties.Resources.DayHrFri, dayHoursFriday);
            objParam[42] = new SqlParameter(DL.Properties.Resources.DayHrSat, dayHoursSaturday);

            objParam[43] = new SqlParameter(DL.Properties.Resources.YoMan, festival);
            objParam[44] = new SqlParameter(DL.Properties.Resources.IsInspectorCode, isInspectorCode);
            objParam[45] = new SqlParameter(DL.Properties.Resources.IsOneTimeContract, isOnetimeContract);
            objParam[46] = new SqlParameter(DL.Properties.Resources.IsReinforcementContract, isReinforcementContract);
            objParam[47] = new SqlParameter(DL.Properties.Resources.NoOfInspection, numberOfInspections);
            objParam[48] = new SqlParameter(DL.Properties.Resources.WEFDate, DateTime.Parse(wefDate));
            objParam[49] = new SqlParameter(DL.Properties.Resources.AmendNo, int.Parse(amendNo));

            objParam[50] = new SqlParameter(DL.Properties.Resources.Status, (status)); 
            dsSale = SqlHelper.ExecuteDatatable("udp_SaleClientAsmtYLM_Insert", objParam);
            return dsSale;


        }

        /// <summary>
        /// Ylms the details delete.
        /// </summary>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataTable.</returns>
        public DataTable YlmDetailsDelete(string asmtId, string locationAutoId, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataTable dsSale = SqlHelper.ExecuteDatatable("udp_SaleClientAsmtYLM_delete", objParam);
            return dsSale;
        }

        /// <summary>
        /// Ylms the details get all.
        /// </summary>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <returns>DataTable.</returns>
        public DataTable YlmDetailsGetAll(string asmtId, string locationAutoId, string clientCode, string amendNo)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AmendNo, int.Parse(amendNo));
            DataTable dsSale = SqlHelper.ExecuteDatatable("udp_SaleClientAsmtYLM_GETALL", objParam);
            return dsSale;
        }

        /// <summary>
        /// Gets the AmendNo for the Client Assignment combination for YLM
        /// </summary>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataTable.</returns>
        public DataTable YlmAmendNo(string asmtId, string locationAutoId, string clientCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AsmtId, asmtId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);

            DataTable dsSale = SqlHelper.ExecuteDatatable("udp_SaleClientAsmtYLM_AmendNo", objParam);
            return dsSale;
        }
        #endregion



        // Sync Secuer trax 


        #region Function Related to Guard Tour

        /// <summary>
        /// Dls the guard tour clients location mapped get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlGuardTourClientsLocationMappedGet(string locationAutoId, string userID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter("@LocationAutoId", locationAutoId);
            objParm[1] = new SqlParameter("@UserID", userID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_GuardTourClientLocationMapped_GetBasedOnUserType", objParm);
            return ds;
        }

        /// <summary>
        /// Dls the guard tour client get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlGuardTourClientGet(string companyCode, string hrLocationCode, string locationCode)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter("@CompanyCode", companyCode);
            objParm[1] = new SqlParameter("@HrLocationCode", hrLocationCode);
            objParm[2] = new SqlParameter("@LocationCode", locationCode);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_GuardTourClientOfCompHRLoc_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Dls the asmt identifier based on client.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlAsmtIDBasedOnClient(string locationAutoID, string clientCode, string fromDate, string toDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter("@FromDate", DL.Common.DateFormat(fromDate));
            objParam[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParam[2] = new SqlParameter("@ClientCode", clientCode);
            objParam[3] = new SqlParameter("@ToDate", DL.Common.DateFormat(toDate));
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AssignmentClientWise", objParam);
            return ds;

        }

        /// <summary>
        /// Dls the asmt identifier based on client for active guard tour.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlAsmtIDBasedOnClientForActiveGuardTour(string locationAutoID, string clientCode, string fromDate, string toDate)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter("@FromDate", DL.Common.DateFormat(fromDate));
            objParam[1] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParam[2] = new SqlParameter("@ClientCode", clientCode);
            objParam[3] = new SqlParameter("@ToDate", DL.Common.DateFormat(toDate));
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_AssignmentClientWise_ForActiveGuardTour", objParam);
            return ds;
        }

        /// <summary>
        /// Dls the tag tour identifier.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postCode">The post code.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlTagTourID(string clientCode, string asmtCode, string postCode)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter("@ClientCode", clientCode);
            objParam[1] = new SqlParameter("@AsmtCode", asmtCode);
            objParam[2] = new SqlParameter("@PostCode", postCode);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagTourID_Fetch", objParam);
            return ds;
        }

        /// <summary>
        /// Dls the tag insert.
        /// </summary>
        /// <param name="tourID">The tour identifier.</param>
        /// <param name="tagID">The tag identifier.</param>
        /// <param name="tagDesc">The tag desc.</param>
        /// <param name="scheduleTime">The schedule time.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="graceTime">The grace time.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlTagInsert(string tourID, string tagID, string tagDesc, string scheduleTime, int interval, string graceTime, string duration, string userID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter("@TourID", tourID);
            objParam[1] = new SqlParameter("@TagID", tagID);
            objParam[2] = new SqlParameter("@TagDesc", tagDesc);
            objParam[3] = new SqlParameter("@ScheduleTime", scheduleTime);
            objParam[4] = new SqlParameter("@Interval", interval);
            objParam[5] = new SqlParameter("@GraceTime", graceTime);
            objParam[6] = new SqlParameter("@duration", duration);
            objParam[7] = new SqlParameter("@modifiedby", userID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GuardTourID_Insert", objParam);
            return ds;
        }

        //-----------------------1-June-2011-------------------------------
        //public DataSet dlTagMaster_Update(string strTourID, string strTagId, string strTagDesc, string strScheduleTime, int strInterval, string strDuration, string strUserID)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter[] objParam = new SqlParameter[7];
        //    objParam[0] = new SqlParameter("@TourId", strTourID);
        //    objParam[1] = new SqlParameter("@TagID", strTagId);
        //    objParam[2] = new SqlParameter("@TagDesc", strTagDesc);
        //    objParam[3] = new SqlParameter("@ScheduleTime", strScheduleTime);
        //    objParam[4] = new SqlParameter("@Interval", strInterval);
        //    objParam[5] = new SqlParameter("@Duration", strDuration);
        //    objParam[6] = new SqlParameter("@ModifiedBy", strUserID);

        //    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagCreation_Update", objParam);
        //    return ds;
        //}
        /// <summary>
        /// Dls the tag master update.
        /// </summary>
        /// <param name="tourID">The tour identifier.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <param name="tagDesc">The tag desc.</param>
        /// <param name="scheduleTime">The schedule time.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="graceTime">The grace time.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlTagMasterUpdate(string tourID, string tagId, string tagDesc, string scheduleTime, int interval, string graceTime, string duration, string userID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter("@TourId", tourID);
            objParam[1] = new SqlParameter("@TagID", tagId);
            objParam[2] = new SqlParameter("@TagDesc", tagDesc);
            objParam[3] = new SqlParameter("@ScheduleTime", scheduleTime);
            objParam[4] = new SqlParameter("@Interval", interval);
            objParam[5] = new SqlParameter("@Duration", duration);
            objParam[6] = new SqlParameter("@ModifiedBy", userID);
            objParam[7] = new SqlParameter("@GraceTime", graceTime);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagCreation_Update", objParam);
            return ds;
        }

        /// <summary>
        /// Dls the tag identifier delete.
        /// </summary>
        /// <param name="tourId">The tour identifier.</param>
        /// <param name="tagID">The tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlTagIDDelete(string tourId, string tagID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter("@TourID", tourId);
            objParam[1] = new SqlParameter("@TagID", tagID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagCreation_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Dls the tag master get.
        /// </summary>
        /// <param name="tourID">The tour identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlTagMasterGet(string tourID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter("@TourId", tourID);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_TagCreationGuardTour_Fetch", objParam);
            return ds;
        }

        /// <summary>
        /// Dls the tag identifier get.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postID">The post identifier.</param>
        /// <param name="supervision">The supervision.</param>
        /// <returns>DataSet.</returns>
        public DataSet DlTagIDGet(string locationAutoID, string clientCode, string asmtCode, string postID, string supervision)
        {
            DataSet ds = new DataSet();
            SqlParameter[] objParm = new SqlParameter[5];

            objParm[0] = new SqlParameter("@LocationAutoID", locationAutoID);
            objParm[1] = new SqlParameter("@ClientCode", clientCode);
            objParm[2] = new SqlParameter("@AsmtCode", asmtCode);
            objParm[3] = new SqlParameter("@PostID", postID);
            objParm[4] = new SqlParameter("@Supervision", Boolean.Parse(supervision));

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSale_LocationTagID_Get", objParm);
            return ds;

        }

        #endregion

        /// <summary>
        /// Sales the order rates system parameter get.
        /// </summary>
        /// <param name="ParamCode">The parameter code.</param>
        /// <param name="Level1">The level1.</param>
        /// <param name="LevelCode1">The level code1.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderRatesSystemParameterGet(string ParamCode, string Level1, string LevelCode1)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ParamCode, ParamCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Level1, Level1);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LevelCode1, LevelCode1);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSaleOrderRatesSystemParameter_Get", objParam);
            return ds;
        }

        #region Function Related To Sales Termination
        /// <summary>
        /// Gets the type of the data based on termination.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="isAreaIncharge">The is area incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="terminationType">Type of the termination.</param>
        /// <param name="SortedBy">The sorted by.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetDataBasedOnTerminationType(string locationAutoId, string areaId, string clientCode, string areaIncharge, string isAreaIncharge, string fromDate, string toDate, string terminationType, string SortedBy)
        {

            var ds = new DataSet();
            var objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaId, areaId);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, clientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaIncharge, areaIncharge);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, isAreaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(toDate));
            objParm[7] = new SqlParameter(DL.Properties.Resources.TerminationType, terminationType);
            objParm[8] = new SqlParameter(DL.Properties.Resources.SortedBy, SortedBy);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSales_Termination_GetDataBasedOnTermination", objParm);
            return ds;
        }
        #endregion



        /// <summary>
        /// Fill Client drop down
        /// Same sp called that used in Scheduling
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="Areaid">The areaid.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="AreaIncharge">The area incharge.</param>
        /// <param name="IsAreaIncharge">The is area incharge.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsLocationWiseGetNew(string locationAutoId, string Areaid, string ClientCode, string AreaIncharge, string IsAreaIncharge, string FromDate, string ToDate)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AreaId, Areaid);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AreaIncharge, AreaIncharge);
            objParm[4] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, IsAreaIncharge);
            objParm[5] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpTran_ScheduleEmpWise_GetAllClients", objParm);
            return ds;
        }
        /// <summary>
        /// Assignmentses the of client schedule lock unlock get new.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="ClientCode">The client code.</param>
        /// <param name="AreaIncharge">The area incharge.</param>
        /// <param name="IsAreaIncharge">The is area incharge.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="Areaid">The areaid.</param>
        /// <returns>DataSet.</returns>
        public DataSet AssignmentsOfClientScheduleLockUnlockGetNew(string locationAutoId, string ClientCode, string AreaIncharge, string IsAreaIncharge, string FromDate, string ToDate, string Areaid)
        {
            SqlParameter[] objParm = new SqlParameter[7];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
           
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AreaIncharge, AreaIncharge);
            objParm[3] = new SqlParameter(DL.Properties.Resources.IsAreaIncharge, IsAreaIncharge);
            objParm[4] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParm[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParm[6] = new SqlParameter(DL.Properties.Resources.AreaId, Areaid);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpOPS_AsmtsOfClient_Get", objParm);
            return ds;
        }


        // created by smdoss 05-Feb-2015
        // Get Subcompany and bank name from database.
        /// <summary>
        /// Subs the company get.
        /// </summary>
        /// <param name="prmCompanyCode">The PRM company code.</param>
        /// <param name="prmDivisionCode">The PRM division code.</param>
        /// <param name="prmBranchCode">The PRM branch code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SubCompanyGet(String prmCompanyCode, String prmDivisionCode, String prmBranchCode)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar);
            objParm[0].Value = prmCompanyCode;
            objParm[1] = new SqlParameter("@DivisionCode", SqlDbType.NVarChar);
            objParm[1].Value = prmDivisionCode;
            objParm[2] = new SqlParameter("@BranchCode", SqlDbType.NVarChar);
            objParm[2].Value = prmBranchCode;
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "subCompany_Get", objParm);
            return ds;
        }

        // created by smdoss 05-Feb-2015
        // Get Subcompany and bank name from database.
        /// <summary>
        /// Banknames the get.
        /// </summary>
        /// <param name="prmCompanyCode">The PRM company code.</param>
        /// <param name="prmDivisionCode">The PRM division code.</param>
        /// <param name="prmBranchCode">The PRM branch code.</param>
        /// <param name="prmSubCompanyCode">The PRM sub company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet banknameGet(String prmCompanyCode, String prmDivisionCode, String prmBranchCode, String prmSubCompanyCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar);
            objParm[0].Value = prmCompanyCode;
            objParm[1] = new SqlParameter("@DivisionCode", SqlDbType.NVarChar);
            objParm[1].Value = prmDivisionCode;
            objParm[2] = new SqlParameter("@BranchCode", SqlDbType.NVarChar);
            objParm[2].Value = prmBranchCode;
            objParm[3] = new SqlParameter("@SubCompanyCode", SqlDbType.NVarChar);
            objParm[3].Value = prmSubCompanyCode;
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "bankname_Get", objParm);
            return ds;
        }


        // created by smdoss 05-Feb-2015

        /// <summary>
        /// Banks the number get.
        /// </summary>
        /// <param name="prmCompanyCode">The PRM company code.</param>
        /// <param name="prmDivisionCode">The PRM division code.</param>
        /// <param name="prmBranchCode">The PRM branch code.</param>
        /// <param name="prmSubCompanyCode">The PRM sub company code.</param>
        /// <param name="prmbankCode">The prmbank code.</param>
        /// <returns>DataTable.</returns>
        public DataTable BankNumberGet(String prmCompanyCode, String prmDivisionCode, String prmBranchCode, String prmSubCompanyCode, String prmbankCode)
        {
            SqlParameter[] objParm = new SqlParameter[5];

            objParm[0] = new SqlParameter("@CompanyCode", SqlDbType.NVarChar);
            objParm[0].Value = prmCompanyCode;
            objParm[1] = new SqlParameter("@DivisionCode", SqlDbType.NVarChar);
            objParm[1].Value = prmDivisionCode;
            objParm[2] = new SqlParameter("@BranchCode", SqlDbType.NVarChar);
            objParm[2].Value = prmBranchCode;
            objParm[3] = new SqlParameter("@SubCompanyCode", SqlDbType.NVarChar);
            objParm[3].Value = prmSubCompanyCode;

            objParm[4] = new SqlParameter("@BankCode", SqlDbType.NVarChar);
            objParm[4].Value = prmbankCode;

            // objParm[0] = new SqlParameter("@BankCode", prmbankCode);

            DataTable ds = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "txtBankNumber_Get", objParm);
            return ds;
        }

        #region function related to Work Order
        public DataSet GetService()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_ServiceDetail_Get");
            return ds;
        }
        public DataSet GetUserId()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_UserIdDetail_Get");
            return ds;
        }
        public DataSet GetUserIdDetails(string UserId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, UserId);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_UserId_GetDetails", objParam);
            return ds;
        }
        public DataSet CreateOrder(string UserId,string ClientName,string ClientEmail, string Location, int ServiceAutoId, string FromDate, string ToDate, string FromTime, string ToTime, string Mobile, string BuildingNo, string FloorNo, string Locality, string Landmark, string city, string District, string State, string Pin, string ModifiedBy, string ModifiedDate, Decimal Lat, Decimal Long,string status)
        {
            SqlParameter[] objParam = new SqlParameter[26];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, UserId);
            objParam[1] = new SqlParameter(Properties.Resources.Location, Location);
            objParam[2] = new SqlParameter(Properties.Resources.ServiceAutoId, ServiceAutoId);
            objParam[3] = new SqlParameter(Properties.Resources.PreferredFromDate, Common.DateFormat(FromDate));
            objParam[4] = new SqlParameter(Properties.Resources.PreferredToDate, Common.DateFormat(ToDate));
            objParam[5] = new SqlParameter(Properties.Resources.PreferredFromTime, FromTime);
            objParam[6] = new SqlParameter(Properties.Resources.PreferredToTime, ToTime);
            objParam[7] = new SqlParameter(Properties.Resources.Mobile, Mobile);
            objParam[8] = new SqlParameter(Properties.Resources.BuildingNo, BuildingNo);
            objParam[9] = new SqlParameter(Properties.Resources.FloorNo, FloorNo);
            objParam[10] = new SqlParameter(Properties.Resources.Locality, Locality);
            objParam[11] = new SqlParameter(Properties.Resources.Landmark, Landmark);
            objParam[12] = new SqlParameter(Properties.Resources.City, city);
            objParam[13] = new SqlParameter(Properties.Resources.District, District);
            objParam[14] = new SqlParameter(Properties.Resources.State, State);
            objParam[15] = new SqlParameter(Properties.Resources.Pin, Pin);
            objParam[16] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[17] = new SqlParameter(Properties.Resources.ModifiedDate, Common.DateFormat(ModifiedDate, true));
            objParam[18] = new SqlParameter(Properties.Resources.Lat, Lat);
            objParam[19] = new SqlParameter(Properties.Resources.Long, Long);
            objParam[20] = new SqlParameter(Properties.Resources.ClientName, ClientName);
            objParam[21] = new SqlParameter(Properties.Resources.Email, ClientEmail);
            objParam[22] = new SqlParameter(Properties.Resources.Status, status);
            objParam[23] = new SqlParameter(Properties.Resources.Unit, "0");
            objParam[24] = new SqlParameter(Properties.Resources.Price, "1");
            objParam[25] = new SqlParameter(Properties.Resources.AddressAutoId,"0");
         
         



            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpWorkOrderInsert", objParam);
            return ds;
        }
        public DataSet WorkOrderListGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_GetWorkOrderDetail");
            return ds;
        }
        public DataSet WorkOrderDetailForUpdate(string WorkOrderAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.WorkOrderAutoId, WorkOrderAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpWorkOrderDetailForUpdate", objParam);
            return ds;
        }
        public DataSet UpdateWorkOrder(int WorkOrderAutoId, string UserId, string Location, int ServiceAutoId, string FromDate, string ToDate, string FromTime, string ToTime, string Mobile, string BuildingNo, string FloorNo, string Locality, string Landmark, string city, string District, string State, string Pin, string ModifiedBy, string ModifiedDate, Decimal Lat, Decimal Long)
        {
            SqlParameter[] objParam = new SqlParameter[21];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, UserId);
            objParam[1] = new SqlParameter(Properties.Resources.Location, Location);
            objParam[2] = new SqlParameter(Properties.Resources.ServiceAutoId, ServiceAutoId);
            objParam[3] = new SqlParameter(Properties.Resources.PreferredFromDate, Common.DateFormat(FromDate));
            objParam[4] = new SqlParameter(Properties.Resources.PreferredToDate, Common.DateFormat(ToDate));
            objParam[5] = new SqlParameter(Properties.Resources.PreferredFromTime, FromTime);
            objParam[6] = new SqlParameter(Properties.Resources.PreferredToTime, ToTime);
            objParam[7] = new SqlParameter(Properties.Resources.Mobile, Mobile);
            objParam[8] = new SqlParameter(Properties.Resources.BuildingNo, BuildingNo);
            objParam[9] = new SqlParameter(Properties.Resources.FloorNo, FloorNo);
            objParam[10] = new SqlParameter(Properties.Resources.Locality, Locality);
            objParam[11] = new SqlParameter(Properties.Resources.Landmark, Landmark);
            objParam[12] = new SqlParameter(Properties.Resources.City, city);
            objParam[13] = new SqlParameter(Properties.Resources.District, District);
            objParam[14] = new SqlParameter(Properties.Resources.State, State);
            objParam[15] = new SqlParameter(Properties.Resources.Pin, Pin);
            objParam[16] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[17] = new SqlParameter(Properties.Resources.ModifiedDate, Common.DateFormat(ModifiedDate, true));
            objParam[18] = new SqlParameter(Properties.Resources.Lat, Lat);
            objParam[19] = new SqlParameter(Properties.Resources.Long, Long);
            objParam[20] = new SqlParameter(Properties.Resources.WorkOrderAutoId, WorkOrderAutoId);



            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpWorkOrderUpdate", objParam);
            return ds;
        }
        public DataSet GetWorkOrderDetailBySearch(string OrderStatus, string FromDate, string ToDate, string workOrderNo, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.Status, OrderStatus);
            objParam[1] = new SqlParameter(Properties.Resources.FromDate,Common.DateFormat( FromDate,true));
            objParam[2] = new SqlParameter(Properties.Resources.ToDate, Common.DateFormat(ToDate,true));
            objParam[3] = new SqlParameter(Properties.Resources.WorkOrderNo, workOrderNo);
            objParam[4] = new SqlParameter(Properties.Resources.UserId, userId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetWorkOrderDetailBySearch", objParam);
            return ds;
        }

        public DataSet WorkOrderDetailGetByWoNo(string workOrderNo)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.WorkOrderNo, workOrderNo);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_WorkOrderDetailGetByWoNo", objParam);
            return ds;
        }
        public DataSet GetWorkOrderDetail(string workOrderNo)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.WorkOrderNo, workOrderNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetWorkOrderDetail", objParam);
            return ds;
        }
        public DataSet GetWorkOrderStatusHistory(string workOrderNo)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.WorkOrderNo, workOrderNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetWorkOrderStatusHistory", objParam);
            return ds;
        }
        public DataSet UpdateWorkOrderDetail(string workOrderNo, string orderStatus, string orderPrice, string modifiedBy, string Time, string Reason, string TransactionId, string Mode)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.WorkOrderNo, workOrderNo);
            objParam[1] = new SqlParameter(Properties.Resources.Status, orderStatus);
            objParam[2] = new SqlParameter(Properties.Resources.Amount, orderPrice);
            objParam[3] = new SqlParameter(Properties.Resources.UserId, modifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.CheckInTime, Time);
            objParam[5] = new SqlParameter(Properties.Resources.ReasonToHold, Reason);
            objParam[6] = new SqlParameter(Properties.Resources.TransactionID, TransactionId);
            objParam[7] = new SqlParameter(Properties.Resources.PaymentMethod, Mode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateWorkOrderDetails", objParam);
            return ds;
        }
        #endregion

        #region Plumbing WorkOrder
        public DataSet SutableEmployeeForWorkOrderGet(string workOrderNo)
        {
            SqlParameter[] objParm = new SqlParameter[1];

            objParm[0] = new SqlParameter(DL.Properties.Resources.WorkOrderNo, workOrderNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpSutableEmployeeForWorkOrderGet", objParm);
            return ds;
        }

        public DataSet PlumbingScheduleInsert(string workOrderAutoId, string workOrderNo, string employeeNumber, string schDate, string schTimeSlot, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[6];

            objParm[0] = new SqlParameter(DL.Properties.Resources.WorkOrderAutoId, workOrderAutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.WorkOrderNo, workOrderNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParm[3] = new SqlParameter(DL.Properties.Resources.SchDate, DL.Common.DateFormat(schDate));
            objParm[4] = new SqlParameter(DL.Properties.Resources.SchTimeSlot, schTimeSlot);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "PlumbingScheduleInsert", objParm);
            return ds;
        }

        public DataSet PlumbingScheduleGetByWoNo(string workOrderNo)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.WorkOrderNo, workOrderNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "PlumbingScheduleGetByWoNo", objParm);
            return ds;
        }

        public DataSet PlumbingEmployeeDashboard(string fromDate)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(fromDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPlumbingEmployeeDashboard", objParm);
            return ds;
        }

        public DataSet GetAllUser()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udp_GetAllInstaServiceUser");
            return ds;
        }
        public DataSet GetTimeSlotDetail()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Udp_TimeSlotDetail");
            return ds;
        }
        public DataSet GetCategory()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Udp_GetServiceCategory");
            return ds;
        }
        public DataSet GetSubCategory()
        {
            DataSet ds = SqlHelper.ExecuteDataset("Udp_GetServiceSubCategory");
            return ds;
        }
        public DataSet GetService(string CategoryId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CategoryCode, Convert.ToInt32(CategoryId));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetService", objParm);
            return ds;
        }

        public DataSet GetRate(string ServiceId)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ServiceAutoId, Convert.ToInt32(ServiceId));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetRate", objParm);
            return ds;
        }


        public DataSet InsertOrder(string UserId, string Location, int ServiceAutoId, string PreferredFromDate, string PreferredToDate, string PreferredFromTime, string PreferredToTime, string MobileNo,
                   string BuildingNo, string FloorNo, string Locality, string Landmark, string City, string District, string State, string PIN, string ModifiedBy, string ModifiedDate, Decimal Lat, Decimal Long, string ClientName, string ClientEmail, string status, string Unit, string Price, int AddressAutoId)
        {
          
                 SqlParameter[] objParm = new SqlParameter[26];
                objParm[0] = new SqlParameter(DL.Properties.Resources.UserId, UserId);
                objParm[1] = new SqlParameter(DL.Properties.Resources.Location, Location);
                objParm[2] = new SqlParameter(DL.Properties.Resources.ServiceAutoId, ServiceAutoId);
                objParm[3] = new SqlParameter(DL.Properties.Resources.PreferredFromDate, DL.Common.DateFormat(PreferredFromDate));
                objParm[4] = new SqlParameter(DL.Properties.Resources.PreferredToDate, DL.Common.DateFormat(PreferredToDate));
                objParm[5] = new SqlParameter(DL.Properties.Resources.PreferredFromTime, PreferredFromTime);
                objParm[6] = new SqlParameter(DL.Properties.Resources.PreferredToTime, PreferredToTime);
                objParm[7] = new SqlParameter(DL.Properties.Resources.Mobile, MobileNo);
                objParm[8] = new SqlParameter(DL.Properties.Resources.BuildingNo, BuildingNo);
                objParm[9] = new SqlParameter(DL.Properties.Resources.FloorNo, FloorNo);
                objParm[10] = new SqlParameter(DL.Properties.Resources.Locality, Locality);
                objParm[11] = new SqlParameter(DL.Properties.Resources.Landmark, Landmark);
                objParm[12] = new SqlParameter(DL.Properties.Resources.City, City);
                objParm[13] = new SqlParameter(DL.Properties.Resources.District, District);
                objParm[14] = new SqlParameter(DL.Properties.Resources.State, State);
                objParm[15] = new SqlParameter(DL.Properties.Resources.Pin, PIN);
                objParm[16] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
                objParm[17] = new SqlParameter(DL.Properties.Resources.ModifiedDate, DL.Common.DateFormat(ModifiedDate));
                objParm[18] = new SqlParameter(DL.Properties.Resources.Lat, Lat);
                objParm[19] = new SqlParameter(DL.Properties.Resources.Long, Long);
                objParm[20] = new SqlParameter(DL.Properties.Resources.ClientName, ClientName);
                objParm[21] = new SqlParameter(DL.Properties.Resources.Email, ClientEmail);
                objParm[22] = new SqlParameter(DL.Properties.Resources.Status, status);
                objParm[23] = new SqlParameter(DL.Properties.Resources.Unit, Unit);
                objParm[24] = new SqlParameter(DL.Properties.Resources.Price, Price);
                objParm[25] = new SqlParameter(DL.Properties.Resources.AddressAutoId, AddressAutoId);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpWorkOrderInsert", objParm);
              
                var WorkOrderNo = ds.Tables[0].Rows[0]["WorkOrderNo"].ToString();
                ConsumerOTPDs(UserId, "SmsTemplateOrderBooking", ClientName, WorkOrderNo);
                if ((ClientEmail.ToString() != string.Empty) || (ClientEmail.ToString() != ""))
                {
                   SendMail(ClientEmail, ClientName, WorkOrderNo, "MailTemplateOrderBooking");
                }
                return ds;
        }
        public DataSet InsertCustomer(string MobileNo, string FirstName, string LastName, string Email, string Password)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.UserId, MobileNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.FirstName, FirstName);
            objParm[2] = new SqlParameter(DL.Properties.Resources.LastName, LastName);
            objParm[3] = new SqlParameter(DL.Properties.Resources.PassWord, Password);
            objParm[4] = new SqlParameter(DL.Properties.Resources.EmailID, Email);
            objParm[5] = new SqlParameter(DL.Properties.Resources.MobileNo, MobileNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ConsumerLoginDetailInsert", objParm);
            return ds;
        }
        public DataSet SearchCustomer(string MobileNo)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Mobile, MobileNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetCustomerDetail", objParm);
            return ds;
        }
        public DataSet InsertAddress(string MobileNo, string HouseNo, string Location, string Landmark, string City, string Pincode)
        {
            SqlParameter[] objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(DL.Properties.Resources.UserId, MobileNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.HouseNo, HouseNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Location, Location);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Landmark, Landmark);
            objParm[4] = new SqlParameter(DL.Properties.Resources.City, City);
            objParm[5] = new SqlParameter(DL.Properties.Resources.PinCode, Pincode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_InsertAddress", objParm);
            return ds;
        }

        public string GenerateOTP()
        {
            string characters = "1234567890";
            string otp = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }
        public void ConsumerOTPDs(string UserId, string TemplateType, string Username, string WorkOrderNo)
        {
            var OTP = GenerateOTP();
            SendOTPDs(UserId, OTP, TemplateType, Username, WorkOrderNo);
        }
        protected string SendOTPDs(string mobileNumber, string strOTP, string TemplateType, string UserName, string WorkOrderNo)
        {
            string ActiveSMS = ConfigurationManager.AppSettings["ActivateSms"];
            if (ActiveSMS.ToString() == "1")
            {
                    string MsgBody = string.Empty;
                    if (TemplateType == "SmsTemplateOrderBooking")
                    {
                        MsgBody = "Hello " + UserName + "%0D%0AThanks for your request. We have received your booking with " + WorkOrderNo + ". We will revert shortly with details of the professional assigned to you. Call 0120-4011011 if you need help.%0D%0A-InstaService.";
                    }
                    string strUrl = "http://msg.msgclub.net/rest/services/sendSMS/sendGroupSms?AUTH_KEY=584add4831605d894c75e2d7922b566f&message=" + MsgBody + "&senderId=INSTAS" + "&routeId=1" + "&mobileNos=" + mobileNumber + "&smsContentType=english";
                    try
                    {
                        WebRequest request = HttpWebRequest.Create(strUrl);

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream s = (Stream)response.GetResponseStream();
                        StreamReader readStream = new StreamReader(s);
                        string dataString = readStream.ReadToEnd();
                        response.Close();
                        s.Close();
                        readStream.Close();
                    }
                    catch (Exception ex)
                    { }

                    return "Success";
            }
            else
            {
                return "SMS not send";
            }
        }
        public void SendMail(string txtMailTo, string clientName, string orderNo, string MailTemplate)
        {
            string ActivateMail = ConfigurationManager.AppSettings["ActivateMail"];
            if (ActivateMail.ToString() == "1")
            {
                string Address = string.Empty;
                string addressline1 = string.Empty;
                string addressline2 = string.Empty;
                string serviceName = string.Empty;
                string orderDate = string.Empty;
                string orderTime = string.Empty;
                string bookingDate = string.Empty;
                string Price = string.Empty;
                SqlParameter[] objParm = new SqlParameter[1];
                objParm[0] = new SqlParameter(DL.Properties.Resources.WorkOrderNo, orderNo);
                  DataSet ds1 = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetOrderDetail", objParm);
                Address = ds1.Tables[0].Rows[0]["OrderAddress"].ToString();
                string[] lbladdress = Address.Split(',');
                addressline1 = lbladdress[0] + "," + lbladdress[1] + "," + lbladdress[2];
                addressline2 = lbladdress[3] + "," + lbladdress[4];
                serviceName = ds1.Tables[0].Rows[0]["ServiceCategoryName"].ToString();
                orderDate = ds1.Tables[0].Rows[0]["PreferredFromDate"].ToString();
                orderTime = ds1.Tables[0].Rows[0]["PreferredFromTime"].ToString();
                bookingDate = ds1.Tables[0].Rows[0]["ModifiedDate"].ToString();
                Price = ds1.Tables[0].Rows[0]["Price"].ToString();
                string Body = string.Empty;
                string Subject = string.Empty;
               if (MailTemplate == "MailTemplateOrderBooking")
                {
                    string Body1 = "Dear " + clientName + ",<br/><br/>Thank you for your booking with us! <br/><br/>We have received your booking with number " + orderNo + ". We are now processing your request.<br/><br/>Here’re your booking Details:<br/>" + "Order Date  :  " + DateTime.Now.ToString("dd MMM yyyy") + " , " + DateTime.Now.ToShortTimeString();
                    string Body2 = "<br/><br/> Product  -    " + serviceName + "<br/><br/> When  -    " + DateTime.Parse(orderDate).ToString("dddd, MMM dd") + " , " + orderTime + "<br/><br/> Total  :  Rs." + Price + "<br/><br/>Service Address  :  <br/>" + clientName + "<br/>" + addressline1 + "<br/>" + addressline2 + "<br/>" + "<br/>";
                    string Body3 = "What happens next? <br/><br/>- You will receive SMS/Email with professional details.<br/><br/>For assistance, please visit <a href='instaservice.in/FAQ.aspx'> instaservice.in/FAQ </a> <br/><br/>Cheers!<br/>Team InstaService<br/><br/>" + "SERVICES BY CATEGORY<br/><br/> <a href='instaservice.in/Default.aspx'> Plumber </a> | <a href='instaservice.in/Default.aspx'> Bathroom Remodeling </a> | <a href='instaservice.in/Default.aspx'> RO </a> | <a href='instaservice.in/Default.aspx'> Bathroom Cleaning </a> | <a href='instaservice.in/Default.aspx'> Whirlpool & Steam </a> | <a href='instaservice.in/Default.aspx'> Product Catalog </a> <br/><br/>" + "<a href='instaservice.in/AboutUs.aspx'> About Us </a> | <a href='#'> Team </a> | <a href='instaservice.in/PrivacyPolicy.aspx'> Privacy Policy </a> | <a href='#'> User Agreement </a> | Copyright © 2016 InstaService. To unsubscribe from all of our mailings, click here";
                    Body = Body1 + Body2 + Body3;
                    Subject = "InstaService - Order Booking Confirmation";
                }
                try
                {
                    using (MailMessage mm = new MailMessage("mail.admin@instaservice.in", txtMailTo))
                    {
                        mm.Subject = Subject;
                        mm.Body = Body;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("customercare@instaservice.in", "care@1234");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        public DataSet GetPaymentDetail(string status, string orderNo)
        {
          
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.Status, status);
            objParm[1] = new SqlParameter(DL.Properties.Resources.WorkOrderNo, orderNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetPaymentDetail", objParm);
            return ds;
        }
        #endregion Plumbing WorkOrder
        #region Function related Price Hiking Module
        public DataSet GetCompanyCode()
        {
            SqlParameter[] objParm = new SqlParameter[0];
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetCompanyCode", objParm);
            return ds;
        }
        public DataSet GetDesignationCode(string CompanyCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetDesignationCode", objParm);
            return ds;
        }
        public DataSet GetGradeCode(string CompanyCode,string DesignationCode)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Designationcode, DesignationCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_Grade_GetAll", objParm);
            return ds;
        }
        public DataSet GetQuotationMasterDetail(string CompanyCode, int state)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.StateId, state);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetQuotationMaster", objParm);
            return ds;
        }
        public DataSet GetQuotationDesignation(string QuotationNo, string AmendNo)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetQuotationDetail", objParm);
            return ds;
        }
        public DataSet GetDesignation(string CompanyCode, int state)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.StateId, state);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetDesignationDesc", objParm);
            return ds;
        }
        public DataSet GetAmendNo(string QuotationNo, string CompanyCode, int state)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAmendNo", objParm);
            return ds;
        }
        public DataSet GetAmendNoDetail(string QuotationNo, string CompanyCode, int state, int AmendNo)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            objParm[3] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAmendNoDetail", objParm);
            return ds;
        }
        public DataSet UpdateAuthorize(string QuotationNo, int AmendNo, string CompanyCode, int State)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[3] = new SqlParameter(DL.Properties.Resources.StateId, State);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_updateQuotationToAuthorized", objParm);
            return ds;
        }
        public DataSet UpdateAmend(string QuotationNo, string CompanyCode, int State)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, State);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_updateQuotationToAmend", objParm);
            return ds;
        }
        public DataSet GetQuotationDetail(string QuotationNo, string CompanyCode, int state)
        {
            SqlParameter[] objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetQuotationMasterDetail", objParm);
            return ds;
        }
        public DataSet InsertHeadConfigDetail(string CompanyCode, string Designation, int state, string FormatCode, string HeadCode, string HeadCodeDesc, string HeadCodeType, string HeadCodeValueType, decimal HeadCodeValue, string HeadCodeValuePerof, string GroupHeadFormula, string sequenceNo, string FromDay, string ToDay, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[15];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FormatCode, FormatCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.HeadCode, HeadCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.HeadCodeDesc, HeadCodeDesc);
            objParm[6] = new SqlParameter(DL.Properties.Resources.HeadCodeType, HeadCodeType);
            objParm[7] = new SqlParameter(DL.Properties.Resources.HeadCodeValueType, HeadCodeValueType);
            objParm[8] = new SqlParameter(DL.Properties.Resources.HeadCodeValue, HeadCodeValue);
            objParm[9] = new SqlParameter(DL.Properties.Resources.HeadCodeValuePerof, HeadCodeValuePerof);
            objParm[10] = new SqlParameter(DL.Properties.Resources.GroupHeadFormula, GroupHeadFormula);
            objParm[11] = new SqlParameter(DL.Properties.Resources.Sequence, Convert.ToInt32( sequenceNo));
            objParm[12] = new SqlParameter(DL.Properties.Resources.DayFrom, FromDay);
            objParm[13] = new SqlParameter(DL.Properties.Resources.DayTo, ToDay);
            objParm[14] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_InsertHeadConfig", objParm);
            return ds;
        }
        public DataSet InsertTotalCosting(string QuotationNo, int AmendNo, string Designation, int TotalEmployee, decimal Discount, string ModifiedBy, string CompanyCode, int state, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[9];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Designationcode, Designation);
            objParm[3] = new SqlParameter(DL.Properties.Resources.EmployeeCount, TotalEmployee);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Discount, Discount);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[8] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_InsertQuotationDetail", objParm);
            return ds;
        }
        public DataSet UpdateTotalCosting(string QuotationNo, int AmendNo, string Designation, int TotalEmployee, decimal Discount, string ModifiedBy, string CompanyCode, int state, int AutoId, int UpdateFlag, decimal PricePerHead, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[12];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.Designationcode, Designation);
            objParm[3] = new SqlParameter(DL.Properties.Resources.EmployeeCount, TotalEmployee);
            objParm[4] = new SqlParameter(DL.Properties.Resources.Discount, Discount);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[7] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[8] = new SqlParameter(DL.Properties.Resources.AutoId, AutoId);
            objParm[9] = new SqlParameter(DL.Properties.Resources.Flag, UpdateFlag);
            objParm[10] = new SqlParameter(DL.Properties.Resources.PayPrice, PricePerHead);
            objParm[11] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateQuotationDetail", objParm);
            return ds;
        }
        public DataSet DeleteDesignationDetail(int AutoId, string QuotationNo, int AmendNo, string Designation, int state, string CompanyCode, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.AutoId, AutoId);
            objParm[1] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[2] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            objParm[3] = new SqlParameter(DL.Properties.Resources.Designationcode, Designation);
            objParm[4] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[5] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[6] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_DeleteQuotationDetail", objParm);
            return ds;
        }
        public DataSet UpdateQuotationMaster(string QuotationNo, string ClientCode, string clientname, string CompanyCode, int state, string ModifiedBy, int AutoId, int AmendNo)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientName, clientname);
            objParm[3] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AutoId, AutoId);
            objParm[7] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateQuotationMaster", objParm);
            return ds;
        }
        public DataSet InsertQuotationMaster(string QuotationNo, string ClientCode, string clientname, string CompanyCode, int state, string ModifiedBy, int AmendNo)
        {
            SqlParameter[] objParm = new SqlParameter[7];
            objParm[0] = new SqlParameter(DL.Properties.Resources.QuotationRefNo, QuotationNo);
            objParm[1] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParm[2] = new SqlParameter(DL.Properties.Resources.ClientName, clientname);
            objParm[3] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.State, state);
            objParm[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParm[6] = new SqlParameter(DL.Properties.Resources.AmendNo, AmendNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_InsertQuotationMaster", objParm);
            return ds;
        }
        public DataSet GetHeadCode(string CompanyCode, string Designation, int state, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            objParm[3] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_getHeadCode", objParm);
            return ds;
        }
        public DataSet GetClientName(string ClientCode)
        {
            SqlParameter[] objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_getClientName", objParm);
            return ds;
        }
        public DataSet GetQuotationHeadDetail(string CompanyCode, string Designation, int state, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            objParm[3] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_getHeadCodeDetail", objParm);
            return ds;
        }
        public DataSet GetCosting(string CompanyCode, string Designation, int state, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            objParm[3] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_getCostingDetail", objParm);
            return ds;
        }
        public DataSet CalculateValues(string CompanyCode, string Designation, int state, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            objParm[3] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_getCosting", objParm);
            return ds;
        }

        public DataSet updateStatus(string CompanyCode, string Designation, int state, string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            objParm[3] = new SqlParameter(DL.Properties.Resources.GradeCode, GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateStatusAmend", objParm);
            return ds;
        }
        public DataSet UpdateHeadConfigDetail(string CompanyCode, string Designation, int state, string FormatCode, string HeadCode, string HeadCodeDesc, string HeadCodeType, string HeadCodeValueType, decimal HeadCodeValue, string HeadCodeValuePerof, string GroupHeadFormula, string sequenceNo, string FromDay, string ToDay, string AutoID,string GradeCode)
        {
            SqlParameter[] objParm = new SqlParameter[16];
            objParm[0] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            objParm[1] = new SqlParameter(DL.Properties.Resources.Designation, Designation);
            objParm[2] = new SqlParameter(DL.Properties.Resources.StateId, state);
            objParm[3] = new SqlParameter(DL.Properties.Resources.FormatCode, FormatCode);
            objParm[4] = new SqlParameter(DL.Properties.Resources.HeadCode, HeadCode);
            objParm[5] = new SqlParameter(DL.Properties.Resources.HeadCodeDesc, HeadCodeDesc);
            objParm[6] = new SqlParameter(DL.Properties.Resources.HeadCodeType, HeadCodeType);
            objParm[7] = new SqlParameter(DL.Properties.Resources.HeadCodeValueType, HeadCodeValueType);
            objParm[8] = new SqlParameter(DL.Properties.Resources.HeadCodeValue, HeadCodeValue);
            objParm[9] = new SqlParameter(DL.Properties.Resources.HeadCodeValuePerof, HeadCodeValuePerof);
            objParm[10] = new SqlParameter(DL.Properties.Resources.GroupHeadFormula, GroupHeadFormula);
            objParm[11] = new SqlParameter(DL.Properties.Resources.Sequence, Convert.ToInt32(sequenceNo));
            objParm[12] = new SqlParameter(DL.Properties.Resources.DayFrom, FromDay);
            objParm[13] = new SqlParameter(DL.Properties.Resources.DayTo, ToDay);
            objParm[14] = new SqlParameter(DL.Properties.Resources.AutoId,Convert.ToInt32(AutoID));
            objParm[15] = new SqlParameter(DL.Properties.Resources.GradeCode,GradeCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateHeadConfig", objParm);
            return ds;
        }
       #endregion

        #region Function Related to Adding Quotation in Sale Order

        public DataSet GetQuotationNo(string companyCode, int locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Get_FreshQuotationNo", objParam);
            return ds;
        }
        #endregion


        public System.Data.DataSet GetLoginType(string BaseUserID,string LocationAutoID)
        {
            SqlParameter[] objParm = new SqlParameter[2];

            objParm[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParm[1] = new SqlParameter(DL.Properties.Resources.BaseUserID, BaseUserID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetUserTypeForResturant", objParm);
            return ds;
        }
    }
}
