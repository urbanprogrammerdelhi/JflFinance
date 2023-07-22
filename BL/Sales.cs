// ***********************************************************************
// Assembly         : BL
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

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class Sales.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Sales
    {
        #region Function Related to Client Master

        #region Function Related to GetData
        /// <summary>
        /// Get List of Client AreaWise
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientMasterGetAll(locationAutoId, areaId, areaIncharge, isIncharge, fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// Retrieve Client Name by Client Code
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientNameGet(string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientNameGet(clientCode);
            return ds;
        }
        /// <summary>
        /// Clients the get.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientGet(string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientGet(clientCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemDeploymentPatternGet(locationAutoId, soNo, soAmendNo, asmtId, itemTypeCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemDeploymentPatternGetAll(locationAutoId, soNo, soAmendNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemRateGet(soNo, locationAutoId, asmtId, soAmendNo, itemTypeCode);
            return ds;
        }


        /// <summary>
        /// Sales the order item deployment pattern update.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="saleOrderDeploymentPattern">The sale order deployment pattern.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDeploymentPatternUpdate(string locationAutoId, string soNo, string soAmendNo, string asmtId, DataTable saleOrderDeploymentPattern, string itemTypeCode, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemDeploymentPatternUpdate(locationAutoId, soNo, soAmendNo, asmtId, saleOrderDeploymentPattern, itemTypeCode, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemDaysInMonthUpdate(locationAutoId, soNo, soAmendNo, asmtId, itemTypeCode, daysInMonth, totalRate, modifiedBy);
            return ds;
        }

        /// <summary>
        /// to get clientCode client name and clientCode(clientName) for a Location
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsLocationWiseGet(string locationAutoId)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientsLocationWiseGet(locationAutoId);
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
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.SOClientWiseGet(locationAutoId, clientCode);
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientGet(locationAutoId, userId);
            return ds;
        }
        /// <summary>
        /// Clients the details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsGet(string companyCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailsGet(companyCode);
            return ds;
        }
        /// <summary>
        /// Contracts the details get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractDetailsGet(string companyCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ContractDetailsGet(companyCode);
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientLocationWiseGet(companyCode, divisionCode, branchCode);
            return ds;
        }
        /// <summary>
        /// To Get AsmtId and clientCode based on LocationAutoId[SalesOPSTermination Screen]
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientCodeAndAsmtIdGet(string clientCode, string locationAutoId)
        {
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ClientCodeAndAsmtIdGet(clientCode, locationAutoId);
            return ds;
        }

        /// <summary>
        /// To Get PostCode, AsmtId and clientCode based on LocationAutoId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientCodeAsmtIdPostCodeGet(string locationAutoId)
        {
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ClientCodeAsmtIdPostcodeGet(locationAutoId);
            return ds;
        }

        /// <summary>
        /// To the Client Name by clientCode
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientNameDetailGet(string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientNameDetailGet(clientCode);
            return ds;
        }
        /// <summary>
        /// To get the search result
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
        public DataSet ClientSearch(string clientCode, string operatorClientCode, string andOrClientCode, string clientName, string operatorClientName, string andOrClientName, string clientAddress, string operatorClientAddress)//, string andOrClientAddress, string AsmtAddress, string strOperatorAssignmentAddress)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ClientSearch(clientCode, operatorClientCode, andOrClientCode, clientName, operatorClientName, andOrClientName, clientAddress, operatorClientAddress);//, andOrClientAddress, AsmtAddress, strOperatorAssignmentAddress);
            return ds;
        }
        /// <summary>
        /// To get the client details [Normal Search]
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientSearch(string value, string locationAutoId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ClientSearch(value, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Check if the manual client code already exists in database
        /// </summary>
        /// <param name="manualClientCode">The manual client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckClientCodeAvailability(string manualClientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.CheckClientCodeAvailability(manualClientCode);
            return ds;
        }
        /// <summary>
        /// Checks the client name availability.
        /// </summary>
        /// <param name="clientName">Name of the client.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckClientNameAvailability(string clientName)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.CheckClientNameAvailability(clientName);
            return ds;
        }
        /// <summary>
        /// To get all the details based on Client Code
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailGet(string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailGet(clientCode);
            return ds;
        }
        /// <summary>
        /// To get the address and other details for client Company Mapping
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailGet(string companyCode, string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailGet(companyCode, clientCode);
            return ds;
        }
        /// <summary>
        /// To get All the clientCode, manual client code client name and combine code and name not mapped with company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsNotMappedWithCompanyGet(string companyCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientsNotMappedWithCompanyGet(companyCode);
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientAreaWiseGet(locationAutoId, AreaIncharge, areaId);
            return ds;
        }

        /// <summary>
        /// To get clientCode, clientName, Client ManualCode
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>To get clientCode, clientName, Client ManualCode</returns>
        public DataSet ClientAreaWiseGet(string locationAutoId, string areaId)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientAreaWiseGet(locationAutoId, areaId);
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

            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientAreaInchargeWiseGet(locationAutoId, areaId, areaIncharge, isAreaIncharge, locationCode, fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// to get clientCode, clientName and clientCode(clientName) for The Given parameters
        /// the HrLocationCode and the LocationCode can be pass as blank "" or ALL.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientHRLocationWiseGet(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientHRLocationWiseGet(companyCode, hrLocationCode, locationCode);
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientSaleOrderGet(locationAutoId, clientCode, soStatus, isBillable, billingPattern);
            return ds;

        }
        /// <summary>
        /// This will get the value from the system parameters if the Code would be Manually generated or System Generated
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="autoGenerateCode">The automatic generate code.</param>
        /// <returns>DataTable.</returns>
        public DataTable SetAutoGenerateCodeForClient(string companyCode, string autoGenerateCode)
        {
            DL.Sales objSale = new DL.Sales();
            DataTable dt = objSale.SetAutoGenerateCodeForClient(companyCode, autoGenerateCode);
            return dt;
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientsLocationStatusWiseGet(locationAutoId, month, year, status, areaIncharge, isAreaIncharge, areaId, fromDate, toDate);
            return ds;
        }

        #endregion

        #region Function Related to Insert data
        /// <summary>
        /// Create AutoGenerated Client Code
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
        /// <param name="otherLanguageAddress1">The other language address1.</param>
        /// <param name="otherLanguageAddress2">The other language address2.</param>
        /// <param name="otherLanguageAddress3">The other language address3.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMasterInsert(string companyCode, string locationAutoId, string manualClientCode, string clientName, string addressLine1, string addressLine2, string addressLine3, string city, string state, string pin, string countryCode, string countryOrigin, string phone, string fax, string website, string email, string contactPersonEmail, string clientContactPerson, string clientContactPersonDesignation, string clientContactPersonMobile, string ourContactPerson, string ourContactPersonEmployeeNo, string ourContactPersonMobile, float turnover, string industryType, string classification, string customerType, string isInternational, string sector, string subsegment, string comments, string modifiedBy, string otherLanguageClientName, string otherLanguageAddress1, string otherLanguageAddress2, string otherLanguageAddress3)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientMasterInsert(companyCode, locationAutoId, manualClientCode, clientName, addressLine1, addressLine2, addressLine3, city, state, pin, countryCode, countryOrigin, phone, fax, website, email, contactPersonEmail, clientContactPerson, clientContactPersonDesignation, clientContactPersonMobile, ourContactPerson, ourContactPersonEmployeeNo, ourContactPersonMobile, turnover, industryType, classification, customerType, isInternational, sector, subsegment, comments, modifiedBy, otherLanguageClientName, otherLanguageAddress1, otherLanguageAddress2, otherLanguageAddress3);
            return ds;
        }

        /// <summary>
        /// Create Client Code Manually
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
        /// <param name="otherLanguageAddress1">The other language address1.</param>
        /// <param name="otherLanguageAddress2">The other language address2.</param>
        /// <param name="otherLanguageAddress3">The other language address3.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMasterManualInsert(string companyCode, string locationAutoId, string clientCode, string manualClientCode, string clientName, string addressLine1, string addressLine2, string addressLine3, string city, string state, string pin, string countryCode, string countryOrigin, string phone, string fax, string website, string email, string contactPersonEmail, string clientContactPerson, string clientContactPersonDesignation, string clientContactPersonMobile, string ourContactPerson, string ourContactPersonEmployeeNo, string ourContactPersonMobile, float turnover, string industryType, string classification, string customerType, string isInternational, string sector, string subsegment, string comments, string modifiedBy, string otherLanguageClientName, string otherLanguageAddress1, string otherLanguageAddress2, string otherLanguageAddress3)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientMasterManualInsert(companyCode, locationAutoId, clientCode, manualClientCode, clientName, addressLine1, addressLine2, addressLine3, city, state, pin, countryCode, countryOrigin, phone, fax, website, email, contactPersonEmail, clientContactPerson, clientContactPersonDesignation, clientContactPersonMobile, ourContactPerson, ourContactPersonEmployeeNo, ourContactPersonMobile, turnover, industryType, classification, customerType, isInternational, sector, subsegment, comments, modifiedBy, otherLanguageClientName, otherLanguageAddress1, otherLanguageAddress2, otherLanguageAddress3);
            return ds;
        }
        #endregion

        #region Function Related to Update data

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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientMasterUpdate(manualClientCode, clientName, addressLine1, addressLine2, addressLine3, city, state, pin, countryCode, countryOrigin, phone, fax, website, email, contactPersonEmail, clientContactPerson, clientContactPersonDesignation, clientContactPersonMobile, ourContactPerson, ourContactPersonEmployeeNo, ourContactPersonMobile, turnover, industryType, classification, customerType, isInternational, sector, subsegment, comments, clientCode, modifiedBy);
            return ds;
        }
        #endregion

        #region Function Related to Delete data
        /// <summary>
        /// Clients the master delete.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMasterDelete(string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientMasterDelete(clientCode);
            return ds;
        }

        #endregion

        #endregion

        #region Function Related to Client Company Mapping
        #region GetData
        /// <summary>
        /// Clientses the company wise get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsCompanyWiseGet(string companyCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientsCompanyWiseGet(companyCode);
            return ds;
        }
        #endregion

        #region Insert data
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientCompanyMappingInsert(companyCode, clientCode, addressLine1, addressLine2, addressLine3, city, state, pin, countryCode, phone, fax, website, email, clientContactPerson, clientContactPersonDesignation, clientContactPersonMobile, ourContactPerson, ourContactPersonEmployeeNo, ourContactPersonMobile, comments, modifiedBy);
            return ds;
        }
        #endregion

        #region Delete data
        /// <summary>
        /// Clients the company mapping delete.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientCompanyMappingDelete(string clientCode, string companyCode, int locationAutoId)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientCompanyMappingDelete(clientCode, companyCode, locationAutoId);
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientCompanyMappingUpdate(companyCode, clientCode, addressLine1, addressLine2, addressLine3, city, state, pin, countryCode, phone, fax, website, email, clientContactPerson, clientContactPersonDesignation, clientContactPersonMobile, ourContactPerson, ourContactPersonEmployeeNo, ourContactPersonMobile, comments, modifiedBy);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related to Client Location Mapping
        /// <summary>
        /// Clients the mapping to location add.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMappingToLocationAdd(int locationAutoId, string clientCode, string modifiedBy)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientMappingToLocationAdd(locationAutoId, clientCode, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Clients the mapping to location remove.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientMappingToLocationRemove(int locationAutoId, string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientMappingToLocationRemove(locationAutoId, clientCode);
            return ds;
        }

        /// <summary>
        /// Function Related to Get UnMapped LocationClients
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientNotMappedToLocationGet(string locationAutoId)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientNotMappedToLocationGet(locationAutoId);
            return ds;
        }

        /// <summary>
        /// Function Related to Get Mapped LocationClients
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsMappedToLocationGet(string locationAutoId)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientsMappedToLocationGet(locationAutoId);
            return ds;
        }
        /// <summary>
        /// Function Related to Get Mapped LocationClients AreaWise
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientsMappedToLocationGet(locationAutoId, areaId, clientCode, employeeNumber, isAreaIncharge, fromDate, toDate);
            return ds;
        }
        /// <summary>
        /// Function Related to Get Mapped AreaId ClientWise for ClientPortal
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientsMappedToLocationGet(string locationAutoId, string userId)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientsMappedToLocationGet(locationAutoId, userId);
            return ds;
        }
        /*End of Code Modified By   on 1-Sep-2011*/
        /// <summary>
        /// Fills for clients details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetCustomerMeetingDetail(string locationAutoId, string clientCode)
        {
            DL.Sales obj = new DL.Sales();
            DataTable dt = obj.GetCustomerMeetingDetail(locationAutoId, clientCode);
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
            DL.Sales obj = new DL.Sales();
            DataTable dt = obj.UpdateCustomerMeetingDetail(locationAutoId, clientCode, custMeetingUnit);
            return dt;
        }
        #endregion

        #region Function Related to ClientDetails

        #region Function Related to Get data
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

            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailsGet(locationAutoId, clientCode, areaId, employeeNumber, isIncharge, fromDate, toDate);
            return ds;
        }

        /// <summary>
        /// Get Assignment detail when client code is passed with comma
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="isIncharge">The is incharge.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetAssignmentDetails(string locationAutoId, string clientCode, string areaId, string employeeNumber, string isIncharge, string fromDate, string toDate)
        {
            var objdlSales = new DL.Sales();

            DataSet ds = objdlSales.GetAssignmentDetails(locationAutoId, clientCode, areaId, employeeNumber, isIncharge, fromDate, toDate);
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientAsmtIdsGet(locationAutoId, clientCode);
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

            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailsGet(locationAutoId, clientCode, asmtId);
            return ds;
        }
        /// <summary>
        /// To get all the LocationAutoId, LocationCode, LocationDesc, LocationCodeDesc for a Client where any AsmtId is exists
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>ds with To get the LocationAutoId, LocationCode, LocationDesc, LocationCodeDesc for a Client where any AsmtId is exists</returns>
        public DataSet ClientAssignmentsGet(string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientAssignmentsGet(clientCode);
            return ds;
        }
        /// <summary>
        /// To Get All the AsmtId's for a Client and LocationAutoId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>ds with All the AsmtId for a Client and LocationAutoId</returns>
        public DataSet ClientAsmtIdsGetAll(string locationAutoId, string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientAsmtIdsGetAll(locationAutoId, clientCode);
            return ds;
        }
        /// <summary>
        /// To Get All the AsmtId's for a Client and LocationAutoId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <param name="wefDate">The wef date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientAsmtIdsGetAll(string locationAutoId, string clientCode, string areaIncharge, string wefDate)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientAsmtIdsGetAll(locationAutoId, clientCode, areaIncharge, wefDate);
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ActiveAsmtIdsGet(locationAutoId, clientCode);
            return ds;
        }
        /// <summary>
        /// to get the AsmtId , Address, and AsmtId(Address) where AsmtId starts with "B" For a Location and Client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtBillingIdGet(string locationAutoId, string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.AsmtBillingIdGet(locationAutoId, clientCode);
            return ds;
        }
        /// <summary>
        /// To Get Client for Branch
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>dataset</returns>
        public DataSet ClientGetBasedOnClientCode(string locationAutoId)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.ClientGetBasedOnClientCode(locationAutoId);
            return ds;
        }

        #endregion

        #region Function Related to Insert data
        /// <summary>
        /// Clients the details insert.
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailsInsert(locationAutoId, clientCode, asmtIdType, areaId, asmtName, jobNo, asmtAddress, city, state, pin, countryCode, phone, fax, email, clientContactPerson, clientContactPersonDesignation, clientContactPersonMobile, premisesType, comments, modifiedBy, otherLanguageAsmtAddress, fromdate);
            return ds;
        }

        /// <summary>
        /// This Allows to create New Address Id Manually
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
        public DataSet ClientDetailsManuallyInsert(string locationAutoId, string clientCode, string asmtIdType, string asmtId, string areaId, string asmtName, string jobNo, string asmtAddress, string city, string state, string pin, string countryCode, string phone, string fax, string email, string clientContactPerson, string clientContactPersonDesignation, string clientContactPersonMobile, string premisesType, string comments, string modifiedBy, string otherLanguageAsmtAddress, string fromDate)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailsManuallyInsert(locationAutoId, clientCode, asmtIdType, asmtId, areaId, asmtName, jobNo, asmtAddress, city, state, pin, countryCode, phone, fax, email, clientContactPerson, clientContactPersonDesignation, clientContactPersonMobile, premisesType, comments, modifiedBy, otherLanguageAsmtAddress, fromDate);
            return ds;
        }
        #endregion

        #region Function Related to Update data
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailsUpdate(locationAutoId, clientCode, asmtId, areaId, asmtName, jobNo, asmtAddress, city, state, pin, countryCode, phone, fax, email, clientContactPerson, clientContactPersonDesignation, clientContactPersonMobile, premisesType, comments, modifiedBy);
            return ds;
        }
        #endregion

        #region Function Related to delete data
        /// <summary>
        /// Clients the details delete.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientDetailsDelete(string locationAutoId, string clientCode, string asmtId)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientDetailsDelete(locationAutoId, clientCode, asmtId);
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
        /// <param name="otherLanguageAddress1">The other language address1.</param>
        /// <param name="otherLanguageAddress2">The other language address2.</param>
        /// <param name="otherLanguageAddress3">The other language address3.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MultilingualClientDetailInsert(string clientCode, string otherLanguageClientName, string otherLanguageAddress1, string otherLanguageAddress2, string otherLanguageAddress3, string modifiedBy)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.MultilingualClientDetailInsert(clientCode, otherLanguageClientName, otherLanguageAddress1, otherLanguageAddress2, otherLanguageAddress3, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Multilinguals the client detail get all.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet MultilingualClientDetailGetAll(string clientCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.MultilingualClientDetailGetAll(clientCode);
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.MultilingualAsmtDetailInsert(clientCode, asmtId, otherLanguageAsmtAddress, locationAutoId, modifiedBy);
            return ds;
        }

        #endregion

        #region Function Related To Contract Master

        #region Function Related to get Data
        /// <summary>
        /// To Get  Maximum AmendNo of Authorized-- ContractNumber, ManualContractNumber, and ContractNumber(ManualContractNumber) for a Client
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="statusAuthorized">The status authorized.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractNumberGetAll(string clientCode, string statusAuthorized)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractNumberGetAll(clientCode, statusAuthorized);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractNumberGetAll(locationAutoId, clientCode, statusAuthorized);
            return ds;
        }

        /// <summary>
        /// to get all contract details of the selected client code
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterGetAll(string clientCode, string locationAutoId)//, string contractNumber)
        {

            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ContractMasterGetAll(clientCode, locationAutoId);//, contractNumber);
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

            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ContractDetailGet(locationAutoId, clientCode, contractNumber);
            return ds;
        }
        /// <summary>
        /// Contracts the value get.
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="statusAuthorized">The status authorized.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractValueGet(string contractNumber, string statusAuthorized)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractValueGet(contractNumber, statusAuthorized);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.PendingContractGet(locationAutoId, statusFresh, statusAmend, userId);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ContractReviewGet(locationAutoId, userId);
            return ds;
        }
        public DataSet ContractDashboardGet(string locationAutoId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ContractDashboardGet(locationAutoId);
            return ds;
        }
        /// <summary>
        /// To get The amend number of the selected client code
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet ContractMasterAmendNoGet(string clientCode, string contractNumber)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterAmendNoGet(clientCode, contractNumber);
            return ds;
        }
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterDetailsGet(amendNo, clientCode, contractNumber, locationAutoId);
            return ds;
        }
        /// <summary>
        /// To Get All Amendment Number Based on the Contract Number
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet AmendmentNoBasedOnContractNoGetAll(string contractNumber)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.AmendmentNoBasedOnContractNoGetAll(contractNumber);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ExpiringContractGet(locationAutoId, userId);
            return ds;
        }

        #endregion

        #region Function Related To insert Data
        /// <summary>
        /// To insert new Contract of the client
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
        public DataSet ContractMasterInsert(int amendmentNo, string issuingAuthority, string deliveryDate, string deliveryTo,
            string expectedSignDate, string loiDate, string loiStartDate, string loiEndDate, string manualContractNo,
            string clientSigningAuthority, string designationAuthority, string contractSignDate, string contractStartDate,
            string contractEndDate, string ContractReviewDate, string modifiedBy, string clientCode, string locationAutoId, string withEffectFrom,
            string status, float contractValue, bool contractPaperDelivered, string paramValue1,
            string noticePeriodDaysToTerminate, string totalWarrantyAmount, string renewalInMonths, string clientNoticeToRenewalInDays,
            string insurance, bool isAutoRenewal, bool isLimitedWarranty, bool isScanCopyExists, bool ifTerminatePossible)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterInsert(amendmentNo, issuingAuthority, deliveryDate, deliveryTo,
                                                  expectedSignDate, loiDate, loiStartDate, loiEndDate,
                                                  manualContractNo, clientSigningAuthority,
                                                  designationAuthority, contractSignDate, contractStartDate,
                                                  contractEndDate, ContractReviewDate, modifiedBy, clientCode, locationAutoId,
                                                  withEffectFrom, status, contractValue,
                                                  contractPaperDelivered, paramValue1,
                                                  noticePeriodDaysToTerminate, totalWarrantyAmount, renewalInMonths,
                                                  clientNoticeToRenewalInDays, insurance, isAutoRenewal,
                                                  isLimitedWarranty, isScanCopyExists, ifTerminatePossible);
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
        /// <para name="ContractReviewDate">The contract Review Date</para>
        public DataSet ContractMasterManuallyInsert(int amendmentNo, string issuingAuthority, string deliveryDate, string deliveryTo, string expectedSignDate, string loiDate, string loiStartDate, string loiEndDate, string manualContractNo, string clientSigningAuthority, string designationAuthority, string contractSignDate, string contractStartDate, string contractEndDate, string ContractReviewDate, string modifiedBy, string clientCode, string locationAutoId, string withEffectFrom, string status, float contractValue, bool contractPaperDelivered, string paramValue1, string contractNo)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterManuallyInsert(amendmentNo, issuingAuthority, deliveryDate, deliveryTo, expectedSignDate, loiDate, loiStartDate, loiEndDate, manualContractNo, clientSigningAuthority, designationAuthority, contractSignDate, contractStartDate, contractEndDate, ContractReviewDate, modifiedBy, clientCode, locationAutoId, withEffectFrom, status, contractValue, contractPaperDelivered, paramValue1, contractNo);
            return ds;
        }

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
        /// <param name="contractReviewDate">The contract sReview Date</param>
        /// <param name="contractEndDate">The contract end date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="withEffectFrom">The with effect from.</param>
        /// <param name="status">The status.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="shortCloseDate">The short close date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ShortCloseContractMaster(int amendmentNo, string issuingAuthority, string deliveryDate, string deliveryTo, string expectedSignDate, string loiDate, string loiStartDate, string loiEndDate, string manualContractNo, string clientSigningAuthority, string designationAuthority, string contractSignDate, string contractStartDate, string contractReviewDate, string contractEndDate, string modifiedBy, string clientCode, string locationAutoId, string withEffectFrom, string status, string contractNumber, string shortCloseDate)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ShortCloseContractMaster(amendmentNo, issuingAuthority, deliveryDate, deliveryTo, expectedSignDate, loiDate, loiStartDate, loiEndDate, manualContractNo, clientSigningAuthority, designationAuthority, contractSignDate, contractStartDate, contractEndDate, contractReviewDate, modifiedBy, clientCode, locationAutoId, withEffectFrom, status, contractNumber, shortCloseDate);
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
        /// <param name="breakHoursApplication">The break hours application.</param>
        /// <param name="breakHours">The break hours.</param>
        /// <param name="siteSuperVisionNo">The site super vision no.</param>
        /// <param name="siteSuperVisionUnit">The site super vision unit.</param>
        /// <returns>DataTable.</returns>
        public DataTable AttendanceTypeInsert(string locationAutoId, string clientCode, string asmtId, string attendanceType, string modifiedBy, string breakHoursApplication, string breakHours, int siteSuperVisionNo, string siteSuperVisionUnit)
        {
            DL.Sales objSales = new DL.Sales();
            //int rowsaffected = 0;
            DataTable dt = objSales.AttendanceTypeInsert(locationAutoId, clientCode, asmtId, attendanceType, modifiedBy, breakHoursApplication, breakHours, siteSuperVisionNo, siteSuperVisionUnit);
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
            DL.Sales objSales = new DL.Sales();
            SqlDataReader reader = null;
            reader = objSales.AsmtAttendanceDetailsGet(locationAutoId, clientCode, asmtId);
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
            DL.Sales objSales = new DL.Sales();
            SqlDataReader reader = null;
            reader = objSales.AsmtAttendDetailsByAmendNoGet(locationAutoId, clientCode, asmtId, amendNo);
            return reader;
        }
        #endregion

        #region Function Related to update
        //---------------------------------------------------------------------- 
        //   Method:      blContractMaster_Update 
        //   Author:        
        //   Description:    Updates the Data in Contract Master 
        //   Creation Date:   
        // 
        //   Inputs:    The input parameters being used and purpose (optional) 
        //   Outputs:    The output parameters being used and purpose (optional) 
        //   Throws:    The exceptions this method throws (optional) 
        // 
        //--------------------------------------------------------------------- 



        /// <summary>
        /// to update when Save button is clicked
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="amendmentNo">The amendment no.</param>
        /// <param name="clientSigningAuthority">The client signing authority.</param>
        /// <param name="contractEndDate">The contract end date.</param>
        /// <param name="contractReviewDate">The contract review date.</param>
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
        /// <para name="contractReviewDate">The Contract Review Date.</para>
        public DataSet ContractMasterUpdate(string clientCode, string contractNumber, int amendmentNo, string clientSigningAuthority, string contractEndDate, string contractReviewDate, string contractSignDate, string contractStartDate, string deliveryDate, string deliveryTo, string designationAuthority, string expectedSignDate, string issuingAuthority, string loiDate, string loiEndDate, string loiStartDate, string manualContractNo, string modifiedBy, string locationAutoId, string status, string withEffectFrom, float contractValue, bool contractPaperDelivered, string paramValue, string noticePeriodDaysToTerminate, string totalWarrantyAmount, string renewalInMonths,
            string clientNoticeToRenewalInDays, string insurance, bool isAutoRenewal, bool isLimitedWarranty,
            bool isScanCopyExists, bool ifTerminatePossible)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterUpdate(clientCode, contractNumber, amendmentNo, clientSigningAuthority, contractEndDate, contractReviewDate, contractSignDate, contractStartDate, deliveryDate, deliveryTo, designationAuthority, expectedSignDate, issuingAuthority, loiDate, loiEndDate, loiStartDate, manualContractNo, modifiedBy, locationAutoId, status, withEffectFrom, contractValue, contractPaperDelivered, paramValue, noticePeriodDaysToTerminate, totalWarrantyAmount, renewalInMonths,
                                                  clientNoticeToRenewalInDays, insurance, isAutoRenewal,
                                                  isLimitedWarranty, isScanCopyExists, ifTerminatePossible);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterDelete(contractNumber);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterInsertAmendRecord(amendmentNo, issuingAuthority, deliveryDate, deliveryTo, expectedSignDate, loiDate, loiStartDate, loiEndDate, manualContractNo, clientSigningAuthority, designationAuthority, contractSignDate, contractStartDate, contractEndDate, contractReviewDate, modifiedBy, clientCode, locationAutoId, withEffectFrom, status, contractNumber, contractValue, contractPaperDelivered, noticePeriodDaysToTerminate, totalWarrantyAmount, renewalInMonths,
                                                  clientNoticeToRenewalInDays, insurance, isAutoRenewal,
                                                  isLimitedWarranty, isScanCopyExists, ifTerminatePossible);
            return ds;
        }
        /// <summary>
        /// Determines whether [is sale order exists for contract] [the specified contract number].
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <returns>DataSet.</returns>
        public DataSet IsSaleOrderExistsForContract(string contractNumber)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.IsSaleOrderExistsForContract(contractNumber);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterAuthorized(clientCode, contractNumber, amendmentNo, modifiedBy, locationAutoId, status);
            return ds;
        }
        #endregion

        #region Contract Documents Upload and Download
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractUpload(contractNumber, amendmentNo, uploadDesc, fileName, modifiedBy);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractMasterDownload(contractNumber, amendmentNo);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractUploadDelete(fileName, contractNumber, amendmentNo);
            return ds;
        }
        #endregion

        #region Function TO get clientName BAsed On clientCode
        /// <summary>
        /// TO get clientName BAsed On clientCode
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientNameGet(string clientCode, string locationAutoId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ClientNameGet(clientCode, locationAutoId);
            return ds;
        }
        #endregion

        /// <summary>
        /// To fill AutoComplete textbox in SearchClient.aspx
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="type">The type.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader ClientListGet(string clientCode, string type)
        {
            DL.Sales objSales = new DL.Sales();
            SqlDataReader reader = objSales.ClientListGet(clientCode, type);
            return reader;
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractDetailsGet(locationAutoId, contractNumber);
            return ds;
        }
        #endregion

        #region Insert Data
        /// <summary>
        /// To insert data for contract details cubic
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="clientRegistrationNo">The client registration no.</param>
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
        public DataSet ContractDetailsInsert(string locationAutoId, string contractNumber, string clientRegistrationNo, string primInternalArea, string accessExitControl, string passSystemAdmin, string screeningServices, string responseServices, string otherGuardingServices, string technicalServices, string technicalServicesIncomePerMonth, string safetyServices, string safetyServicesIncomePerMonth, string otherServices, string otherServicesIncomePerMonth, string nuclearRiskCovered, string nuclearIncident, string nuclearAggregate, string consequentialLosses, string consequentialLossesIncident, string consequentialLossesAggregate, string generalClaimsAnyone, string generalClaimsAggregate, string thirdPartyIndemnity, string forceMajorClause, string highRiskContract, string personsMoreThenFiveThousand, string jurisdiction, string applicableLaw, string modifiedBy)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractDetailsInsert(locationAutoId, contractNumber, clientRegistrationNo, primInternalArea, accessExitControl, passSystemAdmin, screeningServices, responseServices, otherGuardingServices, technicalServices, technicalServicesIncomePerMonth, safetyServices, safetyServicesIncomePerMonth, otherServices, otherServicesIncomePerMonth, nuclearRiskCovered, nuclearIncident, nuclearAggregate, consequentialLosses, consequentialLossesIncident, consequentialLossesAggregate, generalClaimsAnyone, generalClaimsAggregate, thirdPartyIndemnity, forceMajorClause, highRiskContract, personsMoreThenFiveThousand, jurisdiction, applicableLaw, modifiedBy);
            return ds;
        }
        #endregion

        #region Update Data
        /// <summary>
        /// To update Contract details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="clientRegistrationNo">The client registration no.</param>
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
        public DataSet ContractDetailsUpdate(string locationAutoId, string contractNumber, string clientRegistrationNo, string primInternalArea, string accessExitControl, string passSystemAdmin, string screeningServices, string responseServices, string otherGuardingServices, string technicalServices, string technicalServicesIncomePerMonth, string safetyServices, string safetyServicesIncomePerMonth, string otherServices, string otherServicesIncomePerMonth, string nuclearRiskCovered, string nuclearIncident, string nuclearAggregate, string consequentialLosses, string consequentialLossesIncident, string consequentialLossesAggregate, string generalClaimsAnyone, string generalClaimsAggregate, string thirdPartyIndemnity, string forceMajorClause, string highRiskContract, string personsMoreThenFiveThousand, string jurisdiction, string applicableLaw, string modifiedBy)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractDetailsUpdate(locationAutoId, contractNumber, clientRegistrationNo, primInternalArea, accessExitControl, passSystemAdmin, screeningServices, responseServices, otherGuardingServices, technicalServices, technicalServicesIncomePerMonth, safetyServices, safetyServicesIncomePerMonth, otherServices, otherServicesIncomePerMonth, nuclearRiskCovered, nuclearIncident, nuclearAggregate, consequentialLosses, consequentialLossesIncident, consequentialLossesAggregate, generalClaimsAnyone, generalClaimsAggregate, thirdPartyIndemnity, forceMajorClause, highRiskContract, personsMoreThenFiveThousand, jurisdiction, applicableLaw, modifiedBy);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ContractDetailsDelete(locationAutoId, contractNumber);
            return ds;
        }
        #endregion
        #endregion

        #region Functions related to Sale Order

        #region Sale Order Get Functions
        /// <summary>
        /// to get SaleOrder Information for a Location and a Client
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="soStatus">The so status.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderInfoGet(string locationAutoId, string clientCode, string asmtId, string soStatus)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.SaleOrderInfoGet(locationAutoId, clientCode, asmtId, soStatus);
            return ds;
        }

        /// <summary>
        /// To get Sale Orders of Given LocationAutoId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderGet(string locationAutoId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.SaleOrderGet(locationAutoId);
            return ds;
        }

        /// <summary>
        /// To get Sale Orders of Given LocationAutoId, SaleOrder and SoAmendNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderGet(string locationAutoId, string soNo, string soAmendNo)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.SaleOrderGet(locationAutoId, soNo, soAmendNo);
            return ds;
        }

        /// <summary>
        /// Get Sale Order Details For LocationAutoId, SONO, SOAmendNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailGet(string locationAutoId, string soNo, string soAmendNo, string asmtId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailGet(locationAutoId, soNo, soAmendNo, asmtId);
            return ds;
        }

        /// <summary>
        /// Get Sale Order Details For LocationAutoId, SONO, SOAmendNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="areaIncharge">The area incharge.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailGet(string locationAutoId, string soNo, string soAmendNo, string asmtId, string areaIncharge)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailGet(locationAutoId, soNo, soAmendNo, asmtId, areaIncharge);
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
            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailGetSolineNo(locationAutoId, soNo, soAmendNo, asmtId);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailGet(locationAutoId, soNo, soAmendNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemDetailsGet(locationAutoId, soNo, soAmendNo);
            return ds;
        }

        /// <summary>
        /// Get Sale Order Details For LocationAutoId, SONO, SOAmendNo, AsmtId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailsGet(string locationAutoId, string soNo, string soAmendNo, string asmtId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailsGet(locationAutoId, soNo, soAmendNo, asmtId);
            return ds;
        }

        /// <summary>
        /// Get Assignment Address of Sale Order Details For LocationAutoId Sono and SOAmendementNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailsGet(string locationAutoId, string clientCode, string asmtId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailsGet(locationAutoId, clientCode, asmtId);
            return ds;
        }

        /// <summary>
        /// Get SaleOrderAmendement Numbers For LocationAutoId and SaleOrder
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderAmendNoGet(string locationAutoId, string soNo)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderAmendNoGet(locationAutoId, soNo);
            return ds;
        }

        /// <summary>
        /// Get AsmtId For LocationAutoId SONO and SOAmendementNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet AsmtIdGet(string locationAutoId, string soNo, string soAmendNo)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.AsmtIdGet(locationAutoId, soNo, soAmendNo);
            return ds;
        }

        /// <summary>
        /// Get SOType for LocationAutoId SONO and SOAmendementNo
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderTypeGet(string locationAutoId, string soNo, string soAmendNo)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderTypeGet(locationAutoId, soNo, soAmendNo);
            return ds;
        }

        /// <summary>
        /// To get the Deployment Pattren for a company with ItemDesc and DeploymentPattern
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet QuickCodeDeploymentPatternGet(string companyCode)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.QuickCodeDeploymentPatternGet(companyCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.QuickCode2ItemsGet(companyCode, quickCode);
            return ds;
        }

        /// <summary>
        /// To View All So OF the Selected Contract number and clientCode [ContractMaster View So Click]
        /// </summary>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="clientCode">The client code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderViewGet(string contractNumber, string clientCode)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderViewGet(contractNumber, clientCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderMaxAmendNoGet(locationAutoId, soNo);
            return ds;
        }

        /// <summary>
        /// Pendings the sale orders get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="statusFresh">The status fresh.</param>
        /// <param name="statusAmend">The status amend.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PendingSaleOrdersGet(string locationAutoId, string statusFresh, string statusAmend, string userId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.PendingSaleOrdersGet(locationAutoId, statusFresh, statusAmend, userId);
            return ds;
        }
        /// <summary>
        /// Sales the order detail maximum authorized no of post get.
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailMaximumAuthorizedNoOfPostGet(string soNo, int soLineNo, int locationAutoId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailMaximumAuthorizedNoOfPostGet(soNo, soLineNo, locationAutoId);
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
        /// <param name="centralizeBilling">if set to <c>true</c> [centralize billing].</param>
        /// <param name="centralizeBillingLocationAutoId">The centralize billing location automatic identifier.</param>
        /// <param name="asmtBillingId">The asmt billing identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="remarks">The remarks.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderMasterSave(string locationAutoId, string wefDate, string clientCode, string soStatus, string soTerminationDate, string soTerminationReason, string soTerminatedBy, string soType, bool centralizeBilling, string centralizeBillingLocationAutoId, string asmtBillingId, string modifiedBy, string invoiceType, string remarks,string QuotationNo)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderMasterSave(locationAutoId, wefDate, clientCode, soStatus, soTerminationDate, soTerminationReason, soTerminatedBy, soType, centralizeBilling, centralizeBillingLocationAutoId, asmtBillingId, modifiedBy, invoiceType, remarks, QuotationNo);
            return ds;
        }
        /// <summary>
        /// To save the SaleOrder service details
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="contractNumber">The contract number.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postAutoId">The post automatic identifier.</param>
        /// <param name="soRank">The so rank.</param>
        /// <param name="billingDesignation">The billing designation.</param>
        /// <param name="numberOfPost">The number of post.</param>
        /// <param name="hours">The hours.</param>
        /// <param name="deploymentPattern">The deployment pattern.</param>
        /// <param name="minimumManpower">The minimum manpower.</param>
        /// <param name="maximumManpower">The maximum manpower.</param>
        /// <param name="daysInMonth">The days in month.</param>
        /// <param name="hoursInMonth">The hours in month.</param>
        /// <param name="soLineStartDate">The so line start date.</param>
        /// <param name="soLineEndDate">The so line end date.</param>
        /// <param name="soLineWefDate">The so line wef date.</param>
        /// <param name="typeOfService">The type of service.</param>
        /// <param name="typeOfItem">The type of item.</param>
        /// <param name="isBillable">if set to <c>true</c> [is billable].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="minimumWages">The minimum wages.</param>
        /// <param name="otherAllowances">The other allowances.</param>
        /// <param name="allowancesMode">The allowances mode.</param>
        /// <param name="isAllowanceBillable">if set to <c>true</c> [is allowance billable].</param>
        /// <param name="chargeRatePerHours">The charge rate per hours.</param>
        /// <param name="sellingPrice">The selling price.</param>
        /// <param name="minimumProfitability">The minimum profitability.</param>
        /// <param name="optimumProfitability">The optimum profitability.</param>
        /// <param name="serviceCategoryCode">The service category code.</param>
        /// <param name="postposition">The postposition.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="payRateType">Type of the pay rate.</param>
        /// <returns>DataSet.</returns>
        /// <para name="postcode"></para>
        public DataSet SaleOrderDetailAddNew(string locationAutoId, string soNo, string soAmendNo, string contractNumber, string asmtId, string postAutoId, string soRank,
                                                string billingDesignation, string numberOfPost, string hours, string deploymentPattern, string minimumManpower, string maximumManpower,
                                                string daysInMonth, string hoursInMonth, string soLineStartDate, string soLineEndDate, string soLineWefDate, string typeOfService,
                                                string typeOfItem, bool isBillable, bool isActive, string minimumWages, string otherAllowances, string allowancesMode, bool isAllowanceBillable,
                                                string chargeRatePerHours, double sellingPrice, string minimumProfitability, string optimumProfitability, string serviceCategoryCode,
                                                string postposition, string modifiedBy, string payRateType
                                            )
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailAddNew(locationAutoId, soNo, soAmendNo, contractNumber, asmtId, postAutoId, soRank, billingDesignation,
                                                        numberOfPost, hours, deploymentPattern, minimumManpower, maximumManpower, daysInMonth, hoursInMonth,
                                                        soLineStartDate, soLineEndDate, soLineWefDate, typeOfService, typeOfItem, isBillable, isActive,
                                                        minimumWages, otherAllowances, allowancesMode, isAllowanceBillable, chargeRatePerHours, sellingPrice,
                                                        minimumProfitability, optimumProfitability, serviceCategoryCode, postposition, modifiedBy, payRateType
                                                        );
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
        /// <param name="isBillable">if set to <c>true</c> [is billable].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="itemStartDate">The item start date.</param>
        /// <param name="itemEndDate">The item end date.</param>
        /// <param name="itemWefDate">The item wef date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDetailAddNew(string soNo, string soAmendNo, string itemTypeCode, string contractNumber, string quantity, string rate, bool isBillable, bool isActive, string itemStartDate, string itemEndDate, string itemWefDate, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemDetailAddNew(soNo, soAmendNo, itemTypeCode, contractNumber, quantity, rate, isBillable, isActive, itemStartDate, itemEndDate, itemWefDate, modifiedBy);
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
        /// <param name="centralizeBilling">if set to <c>true</c> [centralize billing].</param>
        /// <param name="centralizeBillingLocationAutoId">The centralize billing location automatic identifier.</param>
        /// <param name="asmtBillingId">The asmt billing identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="myStatus">My status.</param>
        /// <param name="invoiceType">Type of the invoice.</param>
        /// <param name="remarks">The remarks.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderMasterUpdate(string locationAutoId, string soNo, string soAmendNo, string wefDate, string clientCode, string soStatus, string soTerminationDate, string soTerminationReason, string soTerminatedBy, string soType, bool centralizeBilling, string centralizeBillingLocationAutoId, string asmtBillingId, string modifiedBy, string myStatus, string invoiceType, string remarks)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderMasterUpdate(locationAutoId, soNo, soAmendNo, wefDate, clientCode, soStatus, soTerminationDate, soTerminationReason, soTerminatedBy, soType, centralizeBilling, centralizeBillingLocationAutoId, asmtBillingId, modifiedBy, myStatus, invoiceType, remarks);
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
        /// <param name="numberOfPost">The number of post.</param>
        /// <param name="hours">The hours.</param>
        /// <param name="deploymentPattern">The deployment pattern.</param>
        /// <param name="minimumManpower">The minimum manpower.</param>
        /// <param name="maximumManpower">The maximum manpower.</param>
        /// <param name="daysInMonth">The days in month.</param>
        /// <param name="hoursInMonth">The hours in month.</param>
        /// <param name="soLineStartDate">The so line start date.</param>
        /// <param name="soLineEndDate">The so line end date.</param>
        /// <param name="soLineWefDate">The so line wef date.</param>
        /// <param name="typeOfService">The type of service.</param>
        /// <param name="typeOfItem">The type of item.</param>
        /// <param name="isBillable">if set to <c>true</c> [is billable].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="minimumWages">The minimum wages.</param>
        /// <param name="otherAllowances">The other allowances.</param>
        /// <param name="allowancesMode">The allowances mode.</param>
        /// <param name="isAllowanceBillable">if set to <c>true</c> [is allowance billable].</param>
        /// <param name="chargeRatePerHours">The charge rate per hours.</param>
        /// <param name="sellingPrice">The selling price.</param>
        /// <param name="minimumProfitability">The minimum profitability.</param>
        /// <param name="optimumProfitability">The optimum profitability.</param>
        /// <param name="serviceCategoryCode">The service category code.</param>
        /// <param name="postposition">The postposition.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="strStatusFresh">The string status fresh.</param>
        /// <param name="payRateType">Type of the pay rate.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDetailUpdate(string locationAutoId, string soNo, string soAmendNo, string soLineNo, string contractNumber, string asmtId, string postAutoId, string soRank, string billingDesignation, string numberOfPost, string hours, string deploymentPattern, string minimumManpower, string maximumManpower, string daysInMonth, string hoursInMonth, string soLineStartDate, string soLineEndDate, string soLineWefDate, string typeOfService, string typeOfItem, bool isBillable, bool isActive, string minimumWages, string otherAllowances, string allowancesMode, bool isAllowanceBillable, double chargeRatePerHours, string sellingPrice, string minimumProfitability, string optimumProfitability, string serviceCategoryCode, string postposition, string modifiedBy, string strStatusFresh, string payRateType)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailUpdate(locationAutoId, soNo, soAmendNo, soLineNo, contractNumber, asmtId, postAutoId, soRank, billingDesignation, numberOfPost, hours, deploymentPattern, minimumManpower, maximumManpower, daysInMonth, hoursInMonth, soLineStartDate, soLineEndDate, soLineWefDate, typeOfService, typeOfItem, isBillable, isActive, minimumWages, otherAllowances, allowancesMode, isAllowanceBillable, chargeRatePerHours, sellingPrice, minimumProfitability, optimumProfitability, serviceCategoryCode, postposition, modifiedBy, strStatusFresh, payRateType);
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
        /// <param name="isBillable">if set to <c>true</c> [is billable].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="itemStartDate">The item start date.</param>
        /// <param name="itemEndDate">The item end date.</param>
        /// <param name="itemWefDate">The item wef date.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemDetailUpdate(string soNo, string soAmendNo, string itemTypeCode, string contractNumber, string quantity, string rate, bool isBillable, bool isActive, string itemStartDate, string itemEndDate, string itemWefDate, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemDetailUpdate(soNo, soAmendNo, itemTypeCode, contractNumber, quantity, rate, isBillable, isActive, itemStartDate, itemEndDate, itemWefDate, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SellingDaysInMonthGet(soLineNo, locationAutoId, soNo, soAmendNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SellingPriceUpdate(soNo, soAmendNo, soLineNo, locationAutoId, sellingPrice, daysInMonth, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ServiceDetailsShiftUpdate(soNo, soAmendNo, soLineNo, locationAutoId, sellingPrice, daysInMonth, hoursInMonth, payPrice, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDelete(locationAutoId, soNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDetailsDelete(soNo, soAmendNo, soLineNo);
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
        public DataSet SaleOrderItemDetailsDelete(string soNo, string soAmendNo, string itemTypeCode, string contractNumber, string itemStartDate)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemDetailsDelete(soNo, soAmendNo, itemTypeCode, contractNumber, itemStartDate);
            return ds;
        }


        #endregion

        #region function to shortclose
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.SaleOrderShortClose(locationAutoId, soNo, soStatus, soStatusAuthorized, statusTerminated, soStatusShortClosed, terminationDate, terminationReason, userId);
            return ds;
        }

        #endregion

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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderMasterAmend(locationAutoId, soNo, soStatus, modifiedBy, myStatus, wefDate);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderMasterAuthorized(locationAutoId, soNo, soAmendNo, soStatus, modifiedBy, myStatus);
            return ds;
        }
        #endregion

        #region functin related to saleOrder Deletion
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.SaleOrderDelete(locationAutoId, soNo, soStatus, soStatusFresh, soStatusDeleted, userId);
            return ds;
        }
        #endregion

        /// <summary>
        /// To get the Days in month from system parameters
        /// </summary>
        /// <param name="locationAutoId">Location Auto Id</param>
        /// <returns>Data Set</returns>
        public DataSet DaysInMonthSysParamGet(string locationAutoId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.DaysInMonthSysParamGet(locationAutoId);
            return ds;
        }
        #endregion



        #region Sale Order Deployment Shift


        /// <summary>
        /// Sales the order deployment shifts get.
        /// </summary>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsGet(string locationAutoId, string soNo, string soAmendNo, string soLineNo)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentShiftsGet(locationAutoId, soNo, soAmendNo, soLineNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentShiftsInsert(locationAutoId, soNo, soAmendNo, soLineNo, weekNo, shiftCode,
                monNoOfPersons, monSellingRate, monPayRate, monTimeFrom, monTimeTo,
                tueNoOfPersons, tueSellingRate, tuePayRate, tueTimeFrom, tueTimeTo,
                wedNoOfPersons, wedSellingRate, wedPayRate, wedTimeFrom, wedTimeTo,
                thuNoOfPersons, thuSellingRate, thuPayRate, thuTimeFrom, thuTimeTo,
                friNoOfPersons, friSellingRate, friPayRate, friTimeFrom, friTimeTo,
                satNoOfPersons, satSellingRate, satPayRate, satTimeFrom, satTimeTo,
                sunNoOfPersons, sunSellingRate, sunPayRate, sunTimeFrom, sunTimeTo, modifiedBy,
                MonOTSellingRate, MonHSellingRate, MonOSellingRate,
                TueOTSellingRate, TueHSellingRate, TueOSellingRate,
                WedOTSellingRate, WedHSellingRate, WedOSellingRate,
                ThuOTSellingRate, ThuHSellingRate, ThuOSellingRate,
                FriOTSellingRate, FriHSellingRate, FriOSellingRate,
                SatOTSellingRate, SatHSellingRate, SatOSellingRate,
                SunOTSellingRate, SunHSellingRate, SunOSellingRate,
                holidayTypeCode, holidayTimeFrom, holidayTimeTo, holidayNoOfPersons, 
                holidaySellingRate, holidayPayRate, holidayOTSellingRate, holidayOSellingRate);
            return ds;
        }
        /// <summary>
        /// Sales the order deployment shifts update.
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
        /// <param name="status">The status.</param>
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentShiftsUpdate(locationAutoId, soNo, soAmendNo, soLineNo, weekNo, shiftCode,
                monNoOfPersons, monSellingRate, monPayRate, monTimeFrom, monTimeTo,
                tueNoOfPersons, tueSellingRate, tuePayRate, tueTimeFrom, tueTimeTo,
                wedNoOfPersons, wedSellingRate, wedPayRate, wedTimeFrom, wedTimeTo,
                thuNoOfPersons, thuSellingRate, thuPayRate, thuTimeFrom, thuTimeTo,
                friNoOfPersons, friSellingRate, friPayRate, friTimeFrom, friTimeTo,
                satNoOfPersons, satSellingRate, satPayRate, satTimeFrom, satTimeTo,
                sunNoOfPersons, sunSellingRate, sunPayRate, sunTimeFrom, sunTimeTo, modifiedBy, status,
                MonOTSellingRate, MonHSellingRate, MonOSellingRate,
                TueOTSellingRate, TueHSellingRate, TueOSellingRate,
                WedOTSellingRate, WedHSellingRate, WedOSellingRate,
                ThuOTSellingRate, ThuHSellingRate, ThuOSellingRate,
                FriOTSellingRate, FriHSellingRate, FriOSellingRate,
                SatOTSellingRate, SatHSellingRate, SatOSellingRate,
                SunOTSellingRate, SunHSellingRate, SunOSellingRate,
                holidayTypeCode, holidayTimeFrom, holidayTimeTo, holidayNoOfPersons,
                holidaySellingRate, holidayPayRate, holidayOTSellingRate, holidayOSellingRate);
            return ds;
        }
        /// <summary>
        /// Sales the order deployment shifts delete.
        /// </summary>
        /// <param name="saleOrderDeploymentShiftAutoId">The sale order deployment shift auto id.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentShiftsDelete(string saleOrderDeploymentShiftAutoId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentShiftsDelete(saleOrderDeploymentShiftAutoId);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.DeploymentHeaderInfoGet(soNo, soAmendNo, soLineNo);
            return ds;
        }

        public DataSet GetAvailableShiftDetails(string clientCode, string asmtId, string dutyDate)
        {
            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.GetAvailableShiftDetails(clientCode, asmtId, dutyDate);
            return ds;
        }

        public DataSet ScheduleVsAcualByAsmtGet(string clientCode, string asmtId, string shiftCode, string dutyDate)
        {
            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ScheduleVsAcualByAsmtGet(clientCode, asmtId, shiftCode, dutyDate);
            return ds;
        }

        public DataSet EmployeeMultipleDutyDashboardGet(string clientCode, string asmtId, string shiftCode, string dutyDate)
        {
            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.EmployeeMultipleDutyDashboardGet(clientCode, asmtId, shiftCode, dutyDate);
            return ds;
        }

        public DataSet EmployeePresentDashboardGet(string clientCode, string asmtId, string dutyDate)
        {
            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.EmployeePresentDashboardGet(clientCode, asmtId, dutyDate);
            return ds;
        }
        #endregion Sale Order Deployment Shift

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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentShiftsBreakGet(locationAutoId, soNo, soAmendNo, soLineNo, shiftCode, weekNo);
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
          string modifiedBy, string billable, string payable)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentShiftsBreakInsert(locationAutoId, soNo, soAmendNo, soLineNo, weekNo, shiftCode,
                monTimeFrom, monTimeTo,
                tueTimeFrom, tueTimeTo,
                wedTimeFrom, wedTimeTo,
                thuTimeFrom, thuTimeTo,
                friTimeFrom, friTimeTo,
                satTimeFrom, satTimeTo,
                sunTimeFrom, sunTimeTo,
                holidayTimeFrom, holidayTimeTo,
                modifiedBy, billable, payable
                );
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentCheckBreakRule(locationAutoId, soNo, soAmendNo, soLineNo, weekNo, shiftCode,
                timeFrom, timeTo, breakMin, status, breakLineNo
                );
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
            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentShiftsBreakUpdate(locationAutoId, soNo, soAmendNo, soLineNo, weekNo, shiftCode,
                monTimeFrom, monTimeTo,
                tueTimeFrom, tueTimeTo,
                wedTimeFrom, wedTimeTo,
                thuTimeFrom, thuTimeTo,
                friTimeFrom, friTimeTo,
                satTimeFrom, satTimeTo,
                sunTimeFrom, sunTimeTo,
                holidayTimeFrom, holidayTimeTo, 
                modifiedBy, breakLineNo, billable, payable
                );
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

            var objSales = new DL.Sales();
            var ds = objSales.BreakShiftDelete(locationAutoId, clientCode, asmtId, postAutoId, Shift, Break, AmendNo);
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
            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentShiftsBreakDelete(locationAutoId, soNo, soAmendNo, soLineNo, weekNo, shiftCode, breakLineNo);
            return ds;
        }

        #endregion Sale order Shift Break Mechanism

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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetListGet(locationAutoId, clientCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetHeaderGet(locationAutoId, costSheetNo, costSheetAmendmentNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetAmendNoGet(locationAutoId, costSheetNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetServicesGet(locationAutoId, costSheetNo, costSheetAmendmentNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetItemGet(locationAutoId, costSheetNo, costSheetAmendmentNo);
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
        /// <param name="airportFeeAmount">The airport fee amount.</param>
        /// <param name="totalEquipmentCostYearly">The total equipment cost yearly.</param>
        /// <param name="otherAdditionalChargesMonthly">The other additional charges monthly.</param>
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
        public DataSet CostSheetInsert(string locationAutoId, string costSheetDate, string costSheetStatus, string clientCode, string preparedBy, string preparedDate, string verifiedBy, string verifiedDate, string approvedBy, string approvedDate, string margin, string bankGuaranteeAmount, string contractStampAmount, string airportFeeAmount, string totalEquipmentCostYearly, string otherAdditionalChargesMonthly, string totalAmount, string totalAmountWithMargin, string equipmentRentalActual, string totalSellingPriceActual, string minusCostActual, string grossProfitActual, string grossMarginActual, string contributionPerHeadActual, string equipmentRentalApm, string totalSellingPriceApm, string minusCostApm, string grossProfitApm, string grossMarginApm, string contributionPerHeadApm, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetInsert(locationAutoId, costSheetDate, costSheetStatus, clientCode, preparedBy, preparedDate, verifiedBy, verifiedDate, approvedBy, approvedDate, margin, bankGuaranteeAmount, contractStampAmount, airportFeeAmount, totalEquipmentCostYearly, otherAdditionalChargesMonthly, totalAmount, totalAmountWithMargin, equipmentRentalActual, totalSellingPriceActual, minusCostActual, grossProfitActual, grossMarginActual, contributionPerHeadActual, equipmentRentalApm, totalSellingPriceApm, minusCostApm, grossProfitApm, grossMarginApm, contributionPerHeadApm, modifiedBy);
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
        /// <param name="pfRate">The pf rate.</param>
        /// <param name="socialWelfareRate">The social welfare rate.</param>
        /// <param name="workmenCompensationRate">The workmen compensation rate.</param>
        /// <param name="totalEquipmentCost">The total equipment cost.</param>
        /// <param name="overheadAllocationRate">The overhead allocation rate.</param>
        /// <param name="phoneFaxRate">The phone fax rate.</param>
        /// <param name="generalLiabilityInsuranceRate">The general liability insurance rate.</param>
        /// <param name="incentiveMonthlyOrYearly">The incentive monthly or yearly.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetServiceInsert(string locationAutoId, string costSheetNo, string costSheetAmendmentNo, string soRank, string designationDesc, string uom, string numberOfPerson, string workingDay, string normalHours, string otHours, string hourlyWageRate, string incentiveAllowanceYearly, string quotedRate, string total, string actual, string asPerMargin, string totalHrsVocationSickTraining, string daysPerWeek, string hoursPerDay, string postsRequired, string recommendedMenByCategory, string totalHrsPerWeek, string totalHrsPerYearActual, string totalRegularHrsPerYear, string totalOTHrsPerYear, string totalRegularHrsPayPerDay, string totalOTHrsPayPerDay, string totalHrsPayPerDay, string totalHrsPerWeekAllPost, string totalHrsPerYearAllPost, string totalRegularHrsPerYearAllPost, string totalOTHrsPerYearAllPost, string basicWage12HrsPerDay, string otFor9TH12THHoursOTRate, string ot7THDay12Hrs, string incentiveAllowance, string holidayPay13Days8Hrs, string sickPayCompensation, string vacationPay, string providentFund, string socialWelfareFund, string workmanCompensationFund, string monthlyBonusPayment, string totalDirectLaborCost, string equipmentsCost, string totalOperationCosts, string totalDirectCost, string overheadAllocation, string totalLocalAdministrativeCost, string phoneAndFax, string generalLiabilityInsurance, string totalLocalOverheadCost, string overallTotalCost, string ratePerPostAsPerMargin, string sumOfTotalPost, string sumOfTotalHrs, string vocationHours, string sickProvision, string trainingHrs, string otRate, string holidayRate, string ot7THDayRate, string sickLeaveValue, string vocationDayValue, string bonusPerMonthPerGuardRate, string pfRate, string socialWelfareRate, string workmenCompensationRate, string totalEquipmentCost, string overheadAllocationRate, string phoneFaxRate, string generalLiabilityInsuranceRate, string incentiveMonthlyOrYearly, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetServiceInsert(locationAutoId, costSheetNo, costSheetAmendmentNo, soRank, designationDesc, uom, numberOfPerson, workingDay, normalHours, otHours, hourlyWageRate, incentiveAllowanceYearly, quotedRate, total, actual, asPerMargin, totalHrsVocationSickTraining, daysPerWeek, hoursPerDay, postsRequired, recommendedMenByCategory, totalHrsPerWeek, totalHrsPerYearActual, totalRegularHrsPerYear, totalOTHrsPerYear, totalRegularHrsPayPerDay, totalOTHrsPayPerDay, totalHrsPayPerDay, totalHrsPerWeekAllPost, totalHrsPerYearAllPost, totalRegularHrsPerYearAllPost, totalOTHrsPerYearAllPost, basicWage12HrsPerDay, otFor9TH12THHoursOTRate, ot7THDay12Hrs, incentiveAllowance, holidayPay13Days8Hrs, sickPayCompensation, vacationPay, providentFund, socialWelfareFund, workmanCompensationFund, monthlyBonusPayment, totalDirectLaborCost, equipmentsCost, totalOperationCosts, totalDirectCost, overheadAllocation, totalLocalAdministrativeCost, phoneAndFax, generalLiabilityInsurance, totalLocalOverheadCost, overallTotalCost, ratePerPostAsPerMargin, sumOfTotalPost, sumOfTotalHrs, vocationHours, sickProvision, trainingHrs, otRate, holidayRate, ot7THDayRate, sickLeaveValue, vocationDayValue, bonusPerMonthPerGuardRate, pfRate, socialWelfareRate, workmenCompensationRate, totalEquipmentCost, overheadAllocationRate, phoneFaxRate, generalLiabilityInsuranceRate, incentiveMonthlyOrYearly, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetItemInsert(locationAutoId, costSheetNo, costSheetAmendmentNo, typeOfItem, itemTypeCode, itemDesc, uom, quantity, quotedRate, total, depreciationMonthsForEquipment, equipmentValuePerYear, modifiedBy);
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
        /// <param name="airportFeeAmount">The airport fee amount.</param>
        /// <param name="totalEquipmentCostYearly">The total equipment cost yearly.</param>
        /// <param name="otherAdditionalChargesMonthly">The other additional charges monthly.</param>
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
        public DataSet CostSheetUpdate(string locationAutoId, string costSheetNo, string costSheetAmendmentNo, string costSheetDate, string costSheetStatus, string clientCode, string preparedBy, string preparedDate, string verifiedBy, string verifiedDate, string approvedBy, string approvedDate, string margin, string bankGuaranteeAmount, string contractStampAmount, string airportFeeAmount, string totalEquipmentCostYearly, string otherAdditionalChargesMonthly, string totalAmount, string totalAmountWithMargin, string equipmentRentalActual, string totalSellingPriceActual, string minusCostActual, string grossProfitActual, string grossMarginActual, string contributionPerHeadActual, string equipmentRentalApm, string totalSellingPriceApm, string minusCostApm, string grossProfitApm, string grossMarginApm, string contributionPerHeadApm, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetUpdate(locationAutoId, costSheetNo, costSheetAmendmentNo, costSheetDate, costSheetStatus, clientCode, preparedBy, preparedDate, verifiedBy, verifiedDate, approvedBy, approvedDate, margin, bankGuaranteeAmount, contractStampAmount, airportFeeAmount, totalEquipmentCostYearly, otherAdditionalChargesMonthly, totalAmount, totalAmountWithMargin, equipmentRentalActual, totalSellingPriceActual, minusCostActual, grossProfitActual, grossMarginActual, contributionPerHeadActual, equipmentRentalApm, totalSellingPriceApm, minusCostApm, grossProfitApm, grossMarginApm, contributionPerHeadApm, modifiedBy);
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
        /// <param name="pfRate">The pf rate.</param>
        /// <param name="socialWelfareRate">The social welfare rate.</param>
        /// <param name="workmenCompensationRate">The workmen compensation rate.</param>
        /// <param name="totalEquipmentCost">The total equipment cost.</param>
        /// <param name="overheadAllocationRate">The overhead allocation rate.</param>
        /// <param name="phoneFaxRate">The phone fax rate.</param>
        /// <param name="generalLiabilityInsuranceRate">The general liability insurance rate.</param>
        /// <param name="incentiveMonthlyOrYearly">The incentive monthly or yearly.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CostSheetServiceUpdate(string locationAutoId, string costSheetNo, string costSheetAmendmentNo, string costSheetLineNo, string soRank, string designationDesc, string uom, string numberOfPerson, string workingDay, string normalHours, string otHours, string hourlyWageRate, string incentiveAllowanceYearly, string quotedRate, string total, string actual, string asPerMargin, string totalHrsVocationSickTraining, string daysPerWeek, string hoursPerDay, string postsRequired, string recommendedMenByCategory, string totalHrsPerWeek, string totalHrsPerYearActual, string totalRegularHrsPerYear, string totalOTHrsPerYear, string totalRegularHrsPayPerDay, string totalOTHrsPayPerDay, string totalHrsPayPerDay, string totalHrsPerWeekAllPost, string totalHrsPerYearAllPost, string totalRegularHrsPerYearAllPost, string totalOTHrsPerYearAllPost, string basicWage12HrsPerDay, string otFor9TH12THHoursOTRate, string ot7THDay12Hrs, string incentiveAllowance, string holidayPay13Days8Hrs, string sickPayCompensation, string vacationPay, string providentFund, string socialWelfareFund, string workmanCompensationFund, string monthlyBonusPayment, string totalDirectLaborCost, string equipmentsCost, string totalOperationCosts, string totalDirectCost, string overheadAllocation, string totalLocalAdministrativeCost, string phoneAndFax, string generalLiabilityInsurance, string totalLocalOverheadCost, string overallTotalCost, string ratePerPostAsPerMargin, string sumOfTotalPost, string sumOfTotalHrs, string vocationHours, string sickProvision, string trainingHrs, string otRate, string holidayRate, string ot7THDayRate, string sickLeaveValue, string vocationDayValue, string bonusPerMonthPerGuardRate, string pfRate, string socialWelfareRate, string workmenCompensationRate, string totalEquipmentCost, string overheadAllocationRate, string phoneFaxRate, string generalLiabilityInsuranceRate, string incentiveMonthlyOrYearly, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetServiceUpdate(locationAutoId, costSheetNo, costSheetAmendmentNo, costSheetLineNo, soRank, designationDesc, uom, numberOfPerson, workingDay, normalHours, otHours, hourlyWageRate, incentiveAllowanceYearly, quotedRate, total, actual, asPerMargin, totalHrsVocationSickTraining, daysPerWeek, hoursPerDay, postsRequired, recommendedMenByCategory, totalHrsPerWeek, totalHrsPerYearActual, totalRegularHrsPerYear, totalOTHrsPerYear, totalRegularHrsPayPerDay, totalOTHrsPayPerDay, totalHrsPayPerDay, totalHrsPerWeekAllPost, totalHrsPerYearAllPost, totalRegularHrsPerYearAllPost, totalOTHrsPerYearAllPost, basicWage12HrsPerDay, otFor9TH12THHoursOTRate, ot7THDay12Hrs, incentiveAllowance, holidayPay13Days8Hrs, sickPayCompensation, vacationPay, providentFund, socialWelfareFund, workmanCompensationFund, monthlyBonusPayment, totalDirectLaborCost, equipmentsCost, totalOperationCosts, totalDirectCost, overheadAllocation, totalLocalAdministrativeCost, phoneAndFax, generalLiabilityInsurance, totalLocalOverheadCost, overallTotalCost, ratePerPostAsPerMargin, sumOfTotalPost, sumOfTotalHrs, vocationHours, sickProvision, trainingHrs, otRate, holidayRate, ot7THDayRate, sickLeaveValue, vocationDayValue, bonusPerMonthPerGuardRate, pfRate, socialWelfareRate, workmenCompensationRate, totalEquipmentCost, overheadAllocationRate, phoneFaxRate, generalLiabilityInsuranceRate, incentiveMonthlyOrYearly, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetItemUpdate(locationAutoId, costSheetNo, costSheetAmendmentNo, costSheetLineNo, typeOfItem, itemTypeCode, itemDesc, uom, quantity, quotedRate, total, depreciationMonthsForEquipment, equipmentValuePerYear, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.CostSheetDelete(locationAutoId, costSheetNo, costSheetAmendmentNo);
            return ds;
        }
        #endregion

        #endregion

        #region Product Master
        /// <summary>
        /// To get the SORank and designation for a Company from ProductMaster
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderRankGet(string companyCode)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderRankGet(companyCode);
            return ds;
        }

        public DataSet GetChargeRate(string SoNo,string SoRank,string CompanyCode)
        {
            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.GetChargeRate(SoNo, SoRank, CompanyCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ProductMasterAdd(companyCode, soRank, designationCode, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ProductMasterUpdate(companyCode, soRank, designationCode, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ProductMasterDelete(companyCode, soRank);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ProductDetailGet(locationAutoId, soRank);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ProductRateForDateGet(asmtLocationAutoId, soRank, locationAutoId, soNo, soAmendNo, soLineNo, soStatusAuthorized);
            return ds;
        }

        /// <summary>
        /// To update the Product details
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ProductDetailUpdate(locationAutoId, soRank, effectiveFrom, effectiveTo, rate, modifiedBy);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostGetAll(clientCode, asmtId);
            return ds;
        }

        /// <summary>
        /// parameters are passed to fetch post for OTFactor
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorGetAll(string clientCode, string asmtId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostOTFactorGetAll(clientCode, asmtId);
            return ds;
        }


        #region BreakShift

        /// <summary>
        /// To fetch Data of BreakShift
        /// </summary>
        /// <param name="locationAutoId">The Location Identifier</param>
        /// <returns>DataSet .</returns>
        public DataSet BreakShift(string locationAutoId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.BreakShift(locationAutoId);
            return ds;
        }

        /// <summary>
        /// To Fetch data of last amendments
        /// </summary>
        /// <param name="locationAutoId">The Location Identifier</param>
        /// <returns>Dataset.</returns>
        public DataSet BreakShiftLastAmendment(string locationAutoId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.BreakShiftLastAmendment(locationAutoId);
            return ds;
        }

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
            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.BreakShiftAdd(locationAutoId, clientCode, asmtId, PostAutoId, Shift, Break, userId);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.BreakShiftUpdate(locationAutoId, clientCode, asmtId, postAutoId, Shift, Break, AmendNo, userId);
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
            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.BreakShiftExport(locationAutoId, clientCode, asmtId, PostAutoId, Shift, Break, status);
            return ds;
        }
        #endregion



        /// <summary>
        /// parameters are passed to fetch last amendments data
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorGetLastAmendement(string clientCode, string asmtId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostOTFactorGetLastAmendement(clientCode, asmtId);
            return ds;
        }



        /// <summary>
        /// parameters are passed to fetch post description
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorFillPostDesc(string clientCode, string asmtId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostOTFactorFillPostDesc(clientCode, asmtId);
            return ds;
        }
        /// <summary>
        /// Get Post Detail when client and assignment are passed with comma
        /// </summary>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet FillPostBasedOnClientAndAssignment(string asmtId)
        {

            var objSales = new DL.Sales();
            DataSet ds = objSales.FillPostBasedOnClientAndAssignment(asmtId);
            return ds;
        }

        /// <summary>
        /// Get system parameter
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostGetAll(int locationAutoId, string clientCode, string asmtId)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostGetAll(locationAutoId, clientCode, asmtId);
            return ds;
        }

        /// <summary>
        /// Posts the get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet PostGetAll()
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostGetAll();
            return ds;
        }


        /// <summary>
        /// Positions the get.
        /// </summary>
        /// <param name="postcode">The postcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PosGet(string postcode)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PosGet(postcode);
            return ds;
        }

        /// <summary>
        /// Parameters are passed
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtId">The asmt identifier.</param>
        /// <param name="postcode">The postcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PosOTFactorGet(string clientCode, string asmtId, string postcode)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PosOTFactorGet(clientCode, asmtId, postcode);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostAdd(clientCode, asmtId, postcode, postDesc, userId, shortPostDesc, phoneNo, postpositionNo);
            return ds;
        }

        /// <summary>
        /// parameters are passed for adding records to capture otfactor
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
            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostOTFactorAdd(clientCode, asmtId, PostAutoId, EffectiveFrom, EffectiveTo, ElementCode, PayrollCode, OTFactor, AmendNo, userId);
            return ds;
        }







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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostUpdate(clientCode, asmtId, postcode, postDesc, userId, shortPostDesc, phoneNo, postpositionNo);
            return ds;
        }

        /// <summary>
        /// parameters are passed for updation
        /// </summary>
        /// <param name="PostAutoId">The post automatic identifier.</param>
        /// <param name="EffectiveTo">The effective to.</param>
        /// <param name="ElementCode">The element code.</param>
        /// <param name="PayrollCode">The payroll code.</param>
        /// <param name="OTFactor">The ot factor.</param>
        /// <param name="AmendNo">The amend no.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostOTFactorUpdate(int PostAutoId, DateTime EffectiveTo, string ElementCode, string PayrollCode, double OTFactor, int AmendNo)
        {

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostOTFactorUpdate(PostAutoId, EffectiveTo, ElementCode, OTFactor, AmendNo, PayrollCode);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostDelete(clientCode, asmtId, postAutoId);
            return ds;
        }
        #endregion Post Master

        #region Item Type
        /// <summary>
        /// To get the itemTypeCode, ItemDesc, Value for a CompanyCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleItemTypeGet(string companyCode)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleItemTypeGet(companyCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemRateGet(companyCode, itemCode, quantity);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemTypeAdd(companyCode, itemTypeCode, itemDesc, value, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update a ItemType by CompanyCode and itemTypeCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <param name="itemDesc">The item desc.</param>
        /// <param name="value">The value.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemTypeUpdate(string companyCode, string itemTypeCode, string itemDesc, string value, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemTypeUpdate(companyCode, itemTypeCode, itemDesc, value, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Delete a ItemType by CompanyCode and itemTypeCode
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="itemTypeCode">The item type code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderItemTypeDelete(string companyCode, string itemTypeCode)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderItemTypeDelete(companyCode, itemTypeCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderTypeGet(companyCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderTypeAdd(companyCode, saleOrderTypeCode, saleOrderTypeDesc, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderTypeUpdate(companyCode, saleOrderTypeCode, saleOrderTypeDesc, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderTypeDelete(companyCode, saleOrderTypeCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentPatternGet(locationAutoId, soNo, soAmendNo, soLineNo);
            return ds;
        }
        /// <summary>
        /// To update the Deployment Patterns
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="soDeploymentPattern">The so deployment pattern.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderDeploymentPatternUpdate(string locationAutoId, string soNo, string soAmendNo, string soLineNo, DataTable soDeploymentPattern, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentPatternUpdate(locationAutoId, soNo, soAmendNo, soLineNo, soDeploymentPattern, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderDeploymentPatternGet(locationAutoId, soNo, soAmendNo);
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

            var objsales = new DL.Sales();
            DataSet ds = objsales.ClientLanguageSkillsGet(companyCode, clientCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientLanguageSkillsAdd(companyCode, clientCode, languageCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientLanguageSkillsUpdate(companyCode, clientCode, languageCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientLanguageSkillsDelete(companyCode, clientCode, languageCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientQualificationSkillsGet(companyCode, clientCode);
            return ds;
        }
        /// <summary>
        /// To Insert Qualification SoLine Wise
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="qualificationCode">The qualification code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientQualificationSkillsAdd(string companyCode, string clientCode, string qualificationCode, string rigidityLevel, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientQualificationSkillsAdd(companyCode, clientCode, qualificationCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientQualificationSkillsUpdate(companyCode, clientCode, qualificationCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientQualificationSkillsDelete(companyCode, clientCode, qualificationCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientTrainingSkillsGet(companyCode, clientCode);
            return ds;
        }
        /// <summary>
        /// To Insert Training in Sale Order Skills
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientTrainingSkillsAdd(string companyCode, string clientCode, string trainingCode, string rigidityLevel, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientTrainingSkillsAdd(companyCode, clientCode, trainingCode, rigidityLevel, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update Training in Sale order Skill
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientTrainingSkillsUpdate(string companyCode, string clientCode, string trainingCode, string rigidityLevel, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientTrainingSkillsUpdate(companyCode, clientCode, trainingCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientTrainingSkillsDelete(companyCode, clientCode, trainingCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientOtherSkillsGet(companyCode, clientCode);
            return ds;
        }
        /// <summary>
        /// To Add Id Type In Sale Order Skills
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientOtherSkillsAdd(string companyCode, string clientCode, string otherSkillCode, string rigidityLevel, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientOtherSkillsAdd(companyCode, clientCode, otherSkillCode, rigidityLevel, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update Id Type In Sale order Skill
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientOtherSkillsUpdate(string companyCode, string clientCode, string otherSkillCode, string rigidityLevel, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientOtherSkillsUpdate(companyCode, clientCode, otherSkillCode, rigidityLevel, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Delete Id Type In Sale order Skill
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientOtherSkillsDelete(string companyCode, string clientCode, string otherSkillCode)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ClientOtherSkillsDelete(companyCode, clientCode, otherSkillCode);
            return ds;
        }
        #endregion

        #region SaleOrder skills Set/Language/Qualification/Training
        /// <summary>
        /// To get skills Sets
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderSkillsSetGet(string locationAutoId, string soNo, string soAmendNo, string soLineNo)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderSkillsSetGet(locationAutoId, soNo, soAmendNo, soLineNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderSkillsSetAdd(locationAutoId, soNo, soAmendNo, soLineNo, shiftRequired, gender, isMandatoryGender, height, isMandatoryHeight, maritalStatus, isMandatoryMaritalStatus, militaryStatus, isMandatoryMilitaryStatus, smoker, isMandatorySmoker, foodStyle, isMandatoryFoodStyle, homeState, isMandatoryHomeState, previousTotalExperience, isMandatoryPreviousTotalExperience, religion, isMandatoryReligion, nationality, isMandatoryNationality, otherSkills, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderSkillsSetUpdate(locationAutoId, soNo, soAmendNo, soLineNo, shiftRequired, gender, isMandatoryGender, height, isMandatoryHeight, maritalStatus, isMandatoryMaritalStatus, militaryStatus, isMandatoryMilitaryStatus, smoker, isMandatorySmoker, foodStyle, isMandatoryFoodStyle, homeState, isMandatoryHomeState, previousTotalExperience, isMandatoryPreviousTotalExperience, religion, isMandatoryReligion, nationality, isMandatoryNationality, otherSkills, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Sales the order skills set delete.
        /// </summary>
        /// <param name="soLineSkillsAutoId">The so line skills automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleOrderSkillsSetDelete(string soLineSkillsAutoId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SaleOrderSkillsSetDelete(soLineSkillsAutoId);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.LanguageSkillsGet(soNo, soAmendNo, soLineNo);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.LanguageSkillsAdd(soNo, soAmendNo, soLineNo, languageCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.LanguageSkillsUpdate(soNo, soAmendNo, soLineNo, languageCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.LanguageSkillsDelete(soNo, soAmendNo, soLineNo, languageCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.QualificationSkillsGet(soNo, soAmendNo, soLineNo);
            return ds;
        }
        /// <summary>
        /// To Insert Qualification SoLine Wise
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.QualificationSkillsAdd(soNo, soAmendNo, soLineNo, qualificationCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.QualificationSkillsUpdate(soNo, soAmendNo, soLineNo, qualificationCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.QualificationSkillsDelete(soNo, soAmendNo, soLineNo, qualificationCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.TrainingSkillsGet(soNo, soAmendNo, soLineNo);
            return ds;
        }
        /// <summary>
        /// To Insert Training in Sale Order Skills
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.TrainingSkillsAdd(soNo, soAmendNo, soLineNo, trainingCode, rigidityLevel, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update Training in Sale order Skill
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="trainingCode">The training code.</param>
        /// <param name="rigidityLevel">The rigidity level.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet TrainingSkillsUpdate(string soNo, string soAmendNo, string soLineNo, string trainingCode, string rigidityLevel, string modifiedBy)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.TrainingSkillsUpdate(soNo, soAmendNo, soLineNo, trainingCode, rigidityLevel, modifiedBy);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.TrainingSkillsDelete(soNo, soAmendNo, soLineNo, trainingCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.OtherSkillsGet(soNo, soAmendNo, soLineNo);
            return ds;
        }
        /// <summary>
        /// To Add Id Type In Sale Order Skills
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.OtherSkillsAdd(soNo, soAmendNo, soLineNo, otherSkillCode, rigidityLevel, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update Id Type In Sale order Skill
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.OtherSkillsUpdate(soNo, soAmendNo, soLineNo, otherSkillCode, rigidityLevel, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Delete Id Type In Sale order Skill
        /// </summary>
        /// <param name="soNo">The so no.</param>
        /// <param name="soAmendNo">The so amend no.</param>
        /// <param name="soLineNo">The so line no.</param>
        /// <param name="otherSkillCode">The other skill code.</param>
        /// <returns>DataSet.</returns>
        public DataSet OtherSkillsDelete(string soNo, string soAmendNo, string soLineNo, string otherSkillCode)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.OtherSkillsDelete(soNo, soAmendNo, soLineNo, otherSkillCode);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.SystemParametersGet(companyCode, hrLocationCode, locationCode);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.PostCompositionGet(companyCode, branchCode, divisionCode, asOnDate);
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

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.ScheduleRosterHoursGet(locationAutoId, userId);
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
            DL.Sales objAsmtCode = new DL.Sales();
            DataSet dsAsmt = objAsmtCode.ClientAssignmentsGet(companyCode, locationAutoId, clientCode);
            return dsAsmt;
        }
        /// <summary>
        /// Tags the master get.
        /// </summary>
        /// <param name="tourId">The tour identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TagMasterGet(string tourId)
        {
            DL.Sales objTagFetch = new DL.Sales();
            DataSet dsTag = objTagFetch.TagMasterGet(tourId);
            return dsTag;
        }

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
            DL.Sales objTagCrt = new DL.Sales();

            DataSet dsTag = objTagCrt.TagCreation(clientCode, asmtCode, postcode, startTime, endTime, userId);
            return dsTag;
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
        public DataSet TagInsert(string tourId, string tagId, string tagDesc, string scheduleTime, string interval, string duration, string userId)
        {
            DL.Sales objTagCrt = new DL.Sales();

            DL.Guard.ArgumentConvertibleTo<int>(interval, "myIntArgument");

            DataSet dsTag = objTagCrt.TagInsert(tourId, tagId, tagDesc, scheduleTime, int.Parse(interval), duration, userId);
            return dsTag;
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
        public DataSet TagMasterUpdate(string tourId, string tagId, string tagDesc, string scheduleTime, string interval, string duration, string userId)
        {
            DL.Sales objTagUpd = new DL.Sales();

            DL.Guard.ArgumentConvertibleTo<int>(interval, "myIntArgument");

            DataSet dsTag = objTagUpd.TagMasterUpdate(tourId, tagId, tagDesc, scheduleTime, int.Parse(interval), duration, userId);
            return dsTag;
        }

        /// <summary>
        /// Tags the identifier delete.
        /// </summary>
        /// <param name="tourId">The tour identifier.</param>
        /// <param name="tagId">The tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet TagIdDelete(string tourId, string tagId)
        {
            DL.Sales objTagDel = new DL.Sales();

            DataSet ds = objTagDel.TagIdDelete(tourId, tagId);
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
            DL.Sales objTagTourId = new DL.Sales();

            DataSet ds = objTagTourId.TourIdGet(clientCode, asmtCode, postcode);
            return ds;
        }

        /// <summary>
        /// Tours the interval.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet TourInterval(string companyCode)
        {
            DL.Sales objTagCrt = new DL.Sales();
            DataSet dsTag = objTagCrt.TourInterval(companyCode);
            return dsTag;
        }
        #endregion



        /// <summary>
        /// Postcodes the get.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postcode">The postcode.</param>
        /// <returns>DataSet.</returns>
        public DataSet PostcodeGet(string locationCode, string asmtCode, string postcode)
        {
            DL.Sales objTagCrt = new DL.Sales();
            DataSet dsTag = objTagCrt.PostcodeGet(locationCode, asmtCode, postcode);
            return dsTag;
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
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ClientConstraintGet(companyCode, clientCode);
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
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ClientConstraintInsert(companyCode, constraintTypeAutoId, constraintDescAutoId, value, operatorValue, rigidityLevel, modifiedBy, clientCode);
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
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ClientConstraintUpdate(clientConstraintAutoId, constraintTypeAutoId, constraintAutoId, value, operatorValue, rigidityLevel, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Clients the constraint delete.
        /// </summary>
        /// <param name="clientConstraintAutoId">The client constraint automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientConstraintDelete(string clientConstraintAutoId)
        {
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ClientConstraintDelete(clientConstraintAutoId);
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
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.ClientConstraintsUpdateToSaleOrders(CompanyCode, LocationAutoId, ClientCode, Status, modifiedBy);
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

            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.SaleConstraintGet(companyCode, soNo, soLineNo, soAmendNo);
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
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.SaleConstraintInsert(LocationAutoId, companyCode, constraintTypeAutoId, constraintDescAutoId, value, operatorValue, rigidityLevel, modifiedBy, soNo, soLineNo, soAmendNo);
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
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.SaleConstraintUpdate(saleConstraintAutoId, constraintTypeAutoId, constraintAutoId, value, operatorValue, rigidityLevel, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Sales the constraint delete.
        /// </summary>
        /// <param name="saleConstraintAutoId">The sale constraint automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SaleConstraintDelete(string saleConstraintAutoId)
        {
            DL.Sales objSales = new DL.Sales();

            DataSet ds = objSales.SaleConstraintDelete(saleConstraintAutoId);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ClientContactInformationGetAll(companyCode, clientCode, asmtId);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ClientContactInformationAdd(companyCode, clientCode, asmtId, contactName, contactDesignation, contactDepartment, contactNumber, emailAddress, modifiedBy);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ClientContactInformationDelete(companyCode, clientCode, asmtId, contactUniqueNo);
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

            DL.Sales objSales = new DL.Sales();
            DataSet ds = objSales.ClientContactInformationUpdate(companyCode, clientCode, asmtId, contactUniqueNo, contactName, contactDesignation, contactDepartment, contactNumber, emailAddress, modifiedBy);
            return ds;
        }

        #endregion

        /*Code added by  on 8-Sep-2011 */
        /// <summary>
        /// Gets AreaIncharge Name for the AreaId
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="areaId">The area identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AreaInchargeGet(string locationAutoId, string areaId)
        {
            DL.Sales objSale = new DL.Sales();
            DataSet dsSale = objSale.AreaInchargeGet(locationAutoId, areaId);
            return dsSale;
        }
        /*Code added by  on 20-Jan-2012 */
        /// <summary>
        /// Client Assignment Export to Excel
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientListGet(string companyCode)
        {
            DL.Sales objSale = new DL.Sales();
            DataSet dsSale = objSale.ClientListGet(companyCode);
            return dsSale;
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
            DL.Sales objSale = new DL.Sales();
            DataSet dsSale = objSale.ClientListGet(companyCode, isIncharge, userId);
            return dsSale;
        }
        /// <summary>
        /// Clients the list a register get.
        /// </summary>
        /// <param name="locationCode">The location code.</param>
        /// <param name="Billable">if set to <c>true</c> [billable].</param>
        /// <returns>DataSet.</returns>
        public DataSet ClientListARegisterGet(string locationCode, bool Billable)
        {
            DL.Sales objSale = new DL.Sales();
            DataSet dsSale = objSale.ClientListARegisterGet(locationCode, Billable);
            return dsSale;
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
            DL.Sales objSale = new DL.Sales();
            SqlDataReader dsSale = null;
            dsSale = objSale.AsmtIdAmendNoGet(locationAutoId, clientCode, asmtId);
            return dsSale;
        }

        /// <summary>
        /// Clients the additional details add.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="clientName">Name of the client.</param>
        /// <param name="company">The company.</param>
        /// <param name="sectorCode">The sector code.</param>
        /// <param name="marketRegulation">if set to <c>true</c> [market regulation].</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader ClientAdditionalDetailsAdd(string locationAutoId, string clientCode, string clientName, string company, string sectorCode, bool marketRegulation)
        {
            DL.Sales objSaleAddDetail = new DL.Sales();
            SqlDataReader drAddDetail = objSaleAddDetail.ClientAdditionalDetailsAdd(locationAutoId, clientCode, clientName, company, sectorCode, marketRegulation);
            return drAddDetail;
        }

        /// <summary>
        /// Clients the additional details get all.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader ClientAdditionalDetailsGetAll(string clientCode)
        {
            DL.Sales objSaleAddDetail = new DL.Sales();
            SqlDataReader drAddDetail = objSaleAddDetail.ClientAdditionalDetailsGetAll(clientCode);
            return drAddDetail;
        }

        /// <summary>
        /// Clients the additional details delete.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <returns>SqlDataReader.</returns>
        public SqlDataReader ClientAdditionalDetailsDelete(string clientCode)
        {
            DL.Sales objSaleAddDetail = new DL.Sales();
            SqlDataReader drAddDetail = objSaleAddDetail.ClientAdditionalDetailsDelete(clientCode);
            return drAddDetail;
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
        /// <param name="enterWed">The enter wed.</param>
        /// <param name="exitWed">The exit wed.</param>
        /// <param name="enterThru">The enter thru.</param>
        /// <param name="exitThru">The exit thru.</param>
        /// <param name="enterFri">The enter fri.</param>
        /// <param name="exitFri">The exit fri.</param>
        /// <param name="enterSat">The enter sat.</param>
        /// <param name="exitSat">The exit sat.</param>
        /// <param name="dayHoursSun">The day hours sun.</param>
        /// <param name="dayHoursMon">The day hours mon.</param>
        /// <param name="dayHoursTue">The day hours tue.</param>
        /// <param name="dayHoursWed">The day hours wed.</param>
        /// <param name="dayHoursThu">The day hours thu.</param>
        /// <param name="dayHoursFri">The day hours fri.</param>
        /// <param name="dayHoursSat">The day hours sat.</param>
        /// <param name="festival">if set to <c>true</c> [festival].</param>
        /// <param name="isInspectorCode">if set to <c>true</c> [is inspector code].</param>
        /// <param name="isOnetimeContract">if set to <c>true</c> [is onetime contract].</param>
        /// <param name="isReinforcementContract">if set to <c>true</c> [is reinforcement contract].</param>
        /// <param name="numberOfInspection">The number of inspection.</param>
        /// <param name="wefDate">The wef date.</param>
        /// <param name="amendNo">The amend no.</param>
        /// <param name="status">The status.</param>
        /// <returns>DataTable.</returns>
        public DataTable YlmDetailsInsert(string asmtId, string locationAutoId, string clientCode, int superAlertPriority, int superAlertType, string superSms, string superEmail, int superAlertTimeGap, int officerAlertPriority, int officerAlertType, string officer2Sms, string officer2Email, int officer2AlertTimeGap, float minimumWorkTime, bool crossSiteFixEnable, bool blockOverQuantityShifts, bool cutToTakenEnter, bool cutToTakenExit, int roundEnterCut, int roundExitCut, bool roundEnter, bool roundExit, string enterSunday, string exitSunday, string enterMonday, string exitMonday, string enterTuesday, string exitTuesday, string enterWed, string exitWed, string enterThru, string exitThru, string enterFri, string exitFri, string enterSat, string exitSat, float dayHoursSun, float dayHoursMon, float dayHoursTue, float dayHoursWed, float dayHoursThu, float dayHoursFri, float dayHoursSat, bool festival,
                                                 bool isInspectorCode, bool isOnetimeContract, bool isReinforcementContract, string numberOfInspection, string wefDate, string amendNo, string status)
        {
            DL.Sales objSaleInsert = new DL.Sales();
            DataTable drAddDetail = objSaleInsert.YlmDetailsInsert(asmtId, locationAutoId, clientCode, superAlertPriority, superAlertType, superSms, superEmail, superAlertTimeGap, officerAlertPriority, officerAlertType, officer2Sms, officer2Email, officer2AlertTimeGap, minimumWorkTime, crossSiteFixEnable, blockOverQuantityShifts, cutToTakenEnter, cutToTakenExit, roundEnterCut, roundExitCut, roundEnter, roundExit, enterSunday, exitSunday, enterMonday, exitMonday, enterTuesday, exitTuesday, enterWed, exitWed, enterThru, exitThru, enterFri, exitFri, enterSat, exitSat, dayHoursSun, dayHoursMon, dayHoursTue, dayHoursWed, dayHoursThu, dayHoursFri, dayHoursSat, festival, isInspectorCode, isOnetimeContract, isReinforcementContract, numberOfInspection, wefDate, amendNo, status);
            return drAddDetail;
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
            DL.Sales objSaleInsert = new DL.Sales();
            DataTable drAddDetail = objSaleInsert.YlmDetailsDelete(asmtId, locationAutoId, clientCode);
            return drAddDetail;
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
            DL.Sales objSaleInsert = new DL.Sales();
            DataTable drAddDetail = objSaleInsert.YlmDetailsGetAll(asmtId, locationAutoId, clientCode, amendNo);
            return drAddDetail;
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
            DL.Sales objSaleGet = new DL.Sales();
            DataTable dt = objSaleGet.YlmAmendNo(asmtId, locationAutoId, clientCode);
            return dt;
        }
        #endregion

        // Sync Secure Trax 


        #region Function Related Guard Tour

        /// <summary>
        /// Bls the guard tour clients location mapped get.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlGuardTourClientsLocationMappedGet(string locationAutoId, string userID)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = new DataSet();
            ds = objdlSales.DlGuardTourClientsLocationMappedGet(locationAutoId, userID);
            return ds;
        }

        /// <summary>
        /// Bls the guard tour client get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <param name="locationCode">The location code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlGuardTourClientGet(string companyCode, string hrLocationCode, string locationCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = new DataSet();
            ds = objdlSales.DlGuardTourClientGet(companyCode, hrLocationCode, locationCode);
            return ds;
        }

        /// <summary>
        /// Bls the asmt identifier based on client.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlAsmtIDBasedOnClient(string locationAutoID, string clientCode, string fromDate, string toDate)
        {
            DL.Sales objAsmtCode = new DL.Sales();
            DataSet dsAsmt = new DataSet();
            dsAsmt = objAsmtCode.DlAsmtIDBasedOnClient(locationAutoID, clientCode, fromDate, toDate);
            return dsAsmt;
        }

        /// <summary>
        /// Bls the asmt identifier based on client for active guard tour.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlAsmtIDBasedOnClientForActiveGuardTour(string locationAutoID, string clientCode, string fromDate, string toDate)
        {
            DL.Sales objAsmtCode = new DL.Sales();
            DataSet dsAsmt = new DataSet();
            dsAsmt = objAsmtCode.DlAsmtIDBasedOnClientForActiveGuardTour(locationAutoID, clientCode, fromDate, toDate);
            return dsAsmt;
        }

        /// <summary>
        /// Bls the tag tour identifier.
        /// </summary>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postCode">The post code.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlTagTourID(string clientCode, string asmtCode, string postCode)
        {
            DL.Sales objTagTourID = new DL.Sales();
            DataSet ds = new DataSet();
            ds = objTagTourID.DlTagTourID(clientCode, asmtCode, postCode);
            return ds;
        }

        /// <summary>
        /// Bls the tag master update.
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
        public DataSet BlTagMasterUpdate(string tourID, string tagId, string tagDesc, string scheduleTime, int interval, string graceTime, string duration, string userID)
        {
            DL.Sales objTagUpd = new DL.Sales();
            DataSet dsTag = new DataSet();
            dsTag = objTagUpd.DlTagMasterUpdate(tourID, tagId, tagDesc, scheduleTime, interval, graceTime, duration, userID);
            return dsTag;
        }

        /// <summary>
        /// Bls the tag insert.
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
        public DataSet BlTagInsert(string tourID, string tagID, string tagDesc, string scheduleTime, int interval, string graceTime, string duration, string userID)
        {
            DL.Sales objTagCrt = new DL.Sales();
            DataSet dsTag = new DataSet();
            dsTag = objTagCrt.DlTagInsert(tourID, tagID, tagDesc, scheduleTime, interval, graceTime, duration, userID);
            return dsTag;
        }

        /// <summary>
        /// Bls the tag identifier delete.
        /// </summary>
        /// <param name="tourId">The tour identifier.</param>
        /// <param name="tagID">The tag identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlTagIDDelete(string tourId, string tagID)
        {
            DL.Sales objTagDel = new DL.Sales();
            DataSet ds = new DataSet();
            ds = objTagDel.DlTagIDDelete(tourId, tagID);
            return ds;
        }

        /// <summary>
        /// Bls the tag master get.
        /// </summary>
        /// <param name="tourID">The tour identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlTagMasterGet(string tourID)
        {
            DL.Sales objTagFetch = new DL.Sales();
            DataSet dsTag = new DataSet();
            dsTag = objTagFetch.DlTagMasterGet(tourID);
            return dsTag;
        }
        /// <summary>
        /// Bls the tag identifier get.
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="clientCode">The client code.</param>
        /// <param name="asmtCode">The asmt code.</param>
        /// <param name="postID">The post identifier.</param>
        /// <param name="supervision">The supervision.</param>
        /// <returns>DataSet.</returns>
        public DataSet BlTagIDGet(string locationAutoID, string clientCode, string asmtCode, string postID, string supervision)
        {

            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = new DataSet();
            ds = objdlSales.DlTagIDGet(locationAutoID, clientCode, asmtCode, postID, supervision);
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
            DL.Sales objSale = new DL.Sales();
            DataSet dsSale = objSale.SaleOrderRatesSystemParameterGet(ParamCode, Level1, LevelCode1);
            return dsSale;
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
            var saleObject = new DL.Sales();
            ds = saleObject.GetDataBasedOnTerminationType(locationAutoId, areaId, clientCode, areaIncharge, isAreaIncharge, fromDate, toDate, terminationType, SortedBy);
            return ds;
        }

        #endregion


        // For Lock  and Unlock.
        /// <summary>
        /// Filling Active client
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.ClientsLocationWiseGetNew(locationAutoId, Areaid, ClientCode, AreaIncharge, IsAreaIncharge, FromDate, ToDate);
            return ds;
        }
        /// <summary>
        /// Fill Assignment dropdown
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
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.AssignmentsOfClientScheduleLockUnlockGetNew(locationAutoId, ClientCode, AreaIncharge, IsAreaIncharge, FromDate, ToDate, Areaid);
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
            DL.Sales objdlSales = new DL.Sales();

            //DataSet ds = objdlSales.dlbanknameGet(prmCompanyCode, prmDivisionCode, prmBranchCode);
            DataSet ds = objdlSales.banknameGet(prmCompanyCode, prmDivisionCode, prmBranchCode, prmSubCompanyCode);
            return ds;
        }
        // created by smdoss 05-Feb-2015
        // Get Subcompany and bank name from database.
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
            DL.Sales objdlSales = new DL.Sales();

            DataTable ds = objdlSales.BankNumberGet(prmCompanyCode, prmDivisionCode, prmBranchCode, prmSubCompanyCode, prmbankCode);
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
        public DataSet SubCompanyGet(string prmCompanyCode, string prmDivisionCode, string prmBranchCode)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.SubCompanyGet(prmCompanyCode, prmDivisionCode, prmBranchCode);
            return ds;
        }

        #region function related to Work Order
        public DataSet GetService()
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetService();
            return ds;
        }
        public DataSet GetUserId()
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetUserId();
            return ds;

        }
        public DataSet GetUserIdDetails(string UserId)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetUserIdDetails(UserId);
            return ds;

        }
        public DataSet CreateOrder(string UserId,string ClientName,string ClientEmail, string Location, int ServiceAutoId, string FromDate, string ToDate, string FromTime, string ToTime, string Mobile, string BuildingNo, string FloorNo, string Locality, string Landmark, string city, string District, string State, string Pin, string ModifiedBy, string ModifiedDate, Decimal Lat, Decimal Long,string status)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.CreateOrder(UserId,ClientName,ClientEmail, Location, ServiceAutoId, FromDate, ToDate, FromTime, ToTime, Mobile, BuildingNo, FloorNo, Locality, Landmark, city, District, State, Pin, ModifiedBy, ModifiedDate, Lat, Long,status);
            return ds;
        }
        public DataSet WorkOrderListGet()
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.WorkOrderListGet();
            return ds;
        }
        public DataSet WorkOrderDetailForUpdate(string WorkOrderAutoId)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.WorkOrderDetailForUpdate(WorkOrderAutoId);
            return ds;
        }
        public DataSet UpdateWorkOrder(int WorkOrderAutoId, string UserId, string Location, int ServiceAutoId, string FromDate, string ToDate, string FromTime, string ToTime, string Mobile, string BuildingNo, string FloorNo, string Locality, string Landmark, string city, string District, string State, string Pin, string ModifiedBy, string ModifiedDate, Decimal Lat, Decimal Long)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.UpdateWorkOrder(WorkOrderAutoId, UserId, Location, ServiceAutoId, FromDate, ToDate, FromTime, ToTime, Mobile, BuildingNo, FloorNo, Locality, Landmark, city, District, State, Pin, ModifiedBy, ModifiedDate, Lat, Long);
            return ds;
        }
        public DataSet GetWorkOrderDetailBySearch(string OrderStatus,string FromDate,string ToDate, string workOrderNo, string userId)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetWorkOrderDetailBySearch(OrderStatus, FromDate, ToDate, workOrderNo, userId);
            return ds;
        }
        public DataSet WorkOrderDetailGetByWoNo(string workOrderNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.WorkOrderDetailGetByWoNo(workOrderNo);
            return ds;
        }
        
        public DataSet GetWorkOrderDetail(string workOrderNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetWorkOrderDetail(workOrderNo);
            return ds;
        }
        public DataSet GetWorkOrderStatusHistory(string workOrderNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetWorkOrderStatusHistory(workOrderNo);
            return ds;
        }
        public DataSet UpdateWorkOrderDetail(string workOrderNo,string orderStatus,string orderPrice,string modifiedBy,string Time,string Reason,string TransactionId,string Mode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.UpdateWorkOrderDetail(workOrderNo, orderStatus, orderPrice, modifiedBy, Time, Reason, TransactionId, Mode);
            return ds;
        }
        #endregion

        #region Plumbing WorkOrder
        public DataSet SutableEmployeeForWorkOrderGet(string workOrderNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.SutableEmployeeForWorkOrderGet(workOrderNo);
            return ds;
        }
        public DataSet PlumbingScheduleInsert(string workOrderAutoId, string workOrderNo, string employeeNumber, string schDate, string schTimeSlot, string modifiedBy)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.PlumbingScheduleInsert(workOrderAutoId, workOrderNo, employeeNumber, schDate, schTimeSlot, modifiedBy);
            return ds;
        }
        public DataSet PlumbingScheduleGetByWoNo(string workOrderNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.PlumbingScheduleGetByWoNo(workOrderNo);
            return ds;
        }

        public DataSet PlumbingEmployeeDashboard(string fromDate)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.PlumbingEmployeeDashboard(fromDate);
            return ds;
        }

        public DataSet GetAllUser()
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetAllUser();
            return ds;
        }
        public DataSet GetTimeSlotDetail()
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetTimeSlotDetail();
            return ds;
        }
        public DataSet GetCategory()
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetCategory();
            return ds;
        }
        public DataSet GetSubCategory()
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetSubCategory();
            return ds;
        }
        public DataSet GetService(string CategoryId)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetService(CategoryId);
            return ds;
        }
        public DataSet GetRate(string ServiceId)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetRate(ServiceId);
            return ds;
        }
        public DataSet InsertOrder(string UserId, string Location, int ServiceAutoId, string PreferredFromDate, string PreferredToDate, string PreferredFromTime, string PreferredToTime, string MobileNo,
            string BuildingNo, string FloorNo, string Locality, string Landmark, string City, string District, string State, string PIN, string ModifiedBy, string ModifiedDate, Decimal Lat, Decimal Long, string ClientName, string ClientEmail, string status,string Unit,string Price,int AddressAutoId)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.InsertOrder(UserId, Location, ServiceAutoId, PreferredFromDate, PreferredToDate, PreferredFromTime, PreferredToTime, MobileNo, BuildingNo, FloorNo, Locality, Landmark, City, District, State, PIN, ModifiedBy, ModifiedDate, Lat, Long, ClientName, ClientEmail, status, Unit, Price, AddressAutoId);
            return ds;
        }
        public DataSet SearchCustomer(string MobileNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.SearchCustomer(MobileNo);
            return ds;
        }
        public DataSet InsertCustomer(string MobileNo,string FirstName,string LastName,string Email,string Password)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.InsertCustomer(MobileNo, FirstName, LastName, Email, Password);
            return ds;
        }
        public DataSet InsertAddress(string MobileNo, string HouseNo, string Location, string Landmark, string City,string Pincode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.InsertAddress(MobileNo, HouseNo, Location, Landmark, City, Pincode);
            return ds;
           
        }
        public DataSet GetPaymentDetail(string status,string orderNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetPaymentDetail(status, orderNo);
            return ds;
        }
        #endregion Plumbing WorkOrder

        #region Function related Price Hiking Module
        public DataSet GetCompanyCode()
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetCompanyCode();
            return ds;
        }
        public DataSet GetDesignationCode(string CompanyCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetDesignationCode(CompanyCode);
            return ds;
        }
        public DataSet GetGradeCode(string CompanyCode,string DesignationCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetGradeCode(CompanyCode, DesignationCode);
            return ds;
        }
        public DataSet InsertHeadConfigDetail(string CompanyCode,string Designation,int state,string FormatCode,string HeadCode,string HeadCodeDesc,string HeadCodeType,string HeadCodeValueType,decimal HeadCodeValue,string HeadCodeValuePerof,string GroupHeadFormula ,string sequenceNo,string FromDay,string ToDay,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.InsertHeadConfigDetail(CompanyCode, Designation, state, FormatCode, HeadCode, HeadCodeDesc, HeadCodeType, HeadCodeValueType, HeadCodeValue, HeadCodeValuePerof, GroupHeadFormula, sequenceNo, FromDay, ToDay, GradeCode);
            return ds;
        }
        public DataSet GetQuotationMasterDetail(string CompanyCode,int state)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetQuotationMasterDetail(CompanyCode, state);
            return ds;
        }
        public DataSet GetQuotationDesignation(string QuotationNo, string AmendNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetQuotationDesignation(QuotationNo, AmendNo);
            return ds;
        }
        public DataSet GetDesignation(string CompanyCode, int state)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetDesignation(CompanyCode, state);
            return ds;
        }
        public DataSet GetAmendNo(string QuotationNo, string CompanyCode, int state)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetAmendNo(QuotationNo, CompanyCode, state);
            return ds;
        }
        public DataSet GetAmendNoDetail(string QuotationNo, string CompanyCode, int state,int AmendNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetAmendNoDetail(QuotationNo, CompanyCode, state, AmendNo);
            return ds;
        }
        public DataSet UpdateAuthorize(string QuotationNo, int AmendNo, string CompanyCode,int State)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.UpdateAuthorize(QuotationNo, AmendNo, CompanyCode, State);
            return ds;
        }
        public DataSet UpdateAmend(string QuotationNo, string CompanyCode, int State)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.UpdateAmend(QuotationNo, CompanyCode, State);
            return ds;
        }
        public DataSet GetQuotationDetail(string QuotationNo, string CompanyCode, int state)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetQuotationDetail(QuotationNo, CompanyCode, state);
            return ds;
        }
        public DataSet InsertTotalCosting(string QuotationNo, int AmendNo, string Designation,int TotalEmployee, decimal Discount, string ModifiedBy,string CompanyCode , int state,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.InsertTotalCosting(QuotationNo, AmendNo, Designation, TotalEmployee, Discount, ModifiedBy, CompanyCode, state, GradeCode);
            return ds;
        }
        public DataSet UpdateTotalCosting(string QuotationNo, int AmendNo, string Designation, int TotalEmployee, decimal Discount, string ModifiedBy, string CompanyCode, int state, int AutoId, int UpdateFlag, decimal PricePerHead, string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.UpdateTotalCosting(QuotationNo, AmendNo, Designation, TotalEmployee, Discount, ModifiedBy, CompanyCode, state, AutoId, UpdateFlag, PricePerHead, GradeCode);
            return ds;
        }
        public DataSet DeleteDesignationDetail(int AutoId,string QuotationNo, int AmendNo, string Designation, int state,string CompanyCode,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.DeleteDesignationDetail(AutoId, QuotationNo, AmendNo, Designation, state, CompanyCode, GradeCode);
            return ds;
        }
        public DataSet InsertQuotationMaster(string QuotationNo, string ClientCode,  string clientname,string CompanyCode,int state,string ModifiedBy,int AmendNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.InsertQuotationMaster(QuotationNo, ClientCode, clientname, CompanyCode, state, ModifiedBy, AmendNo);
            return ds;
        }
        public DataSet UpdateQuotationMaster(string QuotationNo, string ClientCode, string clientname, string CompanyCode, int state, string ModifiedBy,int AutoId,int AmendNo)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.UpdateQuotationMaster(QuotationNo, ClientCode, clientname, CompanyCode, state, ModifiedBy, AutoId, AmendNo);
            return ds;
        }
        public DataSet GetClientName(string ClientCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetClientName(ClientCode);
            return ds;
        }
        public DataSet GetHeadCode(string CompanyCode,string Designation,int state,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetHeadCode(CompanyCode, Designation, state, GradeCode);
            return ds;
        }
        public DataSet GetQuotationHeadDetail(string CompanyCode, string Designation, int state,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetQuotationHeadDetail(CompanyCode, Designation, state, GradeCode);
            return ds;
        }
        public DataSet GetCosting(string CompanyCode, string Designation, int state,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.GetCosting(CompanyCode, Designation, state, GradeCode);
            return ds;
        }
        public DataSet CalculateValues(string CompanyCode, string Designation, int state,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.CalculateValues(CompanyCode, Designation, state, GradeCode);
            return ds;
        }
        public DataSet updateStatus(string CompanyCode, string Designation, int state,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.updateStatus(CompanyCode, Designation, state, GradeCode);
            return ds;
        }
        public DataSet UpdateHeadConfigDetail(string CompanyCode, string Designation, int state, string FormatCode, string HeadCode, string HeadCodeDesc, string HeadCodeType, string HeadCodeValueType, decimal HeadCodeValue, string HeadCodeValuePerof, string GroupHeadFormula, string sequenceNo, string FromDay, string ToDay,string AutoID,string GradeCode)
        {
            DL.Sales objdlSales = new DL.Sales();
            DataSet ds = objdlSales.UpdateHeadConfigDetail(CompanyCode, Designation, state, FormatCode, HeadCode, HeadCodeDesc, HeadCodeType, HeadCodeValueType, HeadCodeValue, HeadCodeValuePerof, GroupHeadFormula,sequenceNo,FromDay,ToDay,AutoID,GradeCode);
            return ds;
        }
        #endregion

        #region Function Related to Adding Quotation in Sale Order

        public DataSet GetQuotationNo(string companyCode,int locationAutoId)
        {

            DL.Sales objsales = new DL.Sales();
            DataSet ds = objsales.GetQuotationNo(companyCode, locationAutoId);
            return ds;
        }

        #endregion



        public DataSet GetLoginType(string BaseUserID,string LocationAutoID)
        {
            DL.Sales objdlSales = new DL.Sales();

            DataSet ds = objdlSales.GetLoginType(BaseUserID, LocationAutoID);
            return ds;
        }
    }
}
