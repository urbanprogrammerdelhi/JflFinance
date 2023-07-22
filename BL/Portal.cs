// ***********************************************************************
// Assembly         : BL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Portal.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary>Portal Class</summary>
// ***********************************************************************

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    using System;
    using System.Data;

    /// <summary>
    /// Portal Class
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Portal
    {
        #region Function Related to Customer portal

        /// <summary>
        /// Customers incharge detail get.
        /// </summary>
        /// <param name="portalLogOnGuid">The portal login GUID.</param>
        /// <returns>Dataset ds</returns>
        public DataSet CustomerInchargeDetailGet(string portalLogOnGuid)
        {
            var objPortal = new DL.Portal();
            DataSet ds = objPortal.CustomerInchargeDetailGet(portalLogOnGuid);
            return ds;
        }

        /// <summary>
        /// Customers incharge detail insert.
        /// </summary>
        /// <param name="inchargeId">The incharge id.</param>
        /// <param name="emailId">The email id.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="portalLogOnGuid">The portal login GUID.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Dataset ds</returns>
        public DataSet CustomerInchargeDetailInsert(string inchargeId, string emailId, string phoneNumber, string portalLogOnGuid, string companyCode, string modifiedBy)
        {
            var objPortal = new DL.Portal();
            DataSet ds = objPortal.CustomerInchargeDetailInsert(inchargeId, emailId, phoneNumber, portalLogOnGuid, companyCode, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Customers incharge detail update.
        /// </summary>
        /// <param name="inchargeId">The incharge id.</param>
        /// <param name="emailId">The email id.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="customerInchargeGuid">The customer incharge GUID.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Datset ds</returns>
        public DataSet CustomerInchargeDetailUpdate(string inchargeId, string emailId, string phoneNumber, string customerInchargeGuid, string modifiedBy)
        {
            var objPortal = new DL.Portal();
            DataSet ds = objPortal.CustomerInchargeDetailUpdate(inchargeId, emailId, phoneNumber, customerInchargeGuid, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Customers incharge detail delete.
        /// </summary>
        /// <param name="customerInchargeGuid">The customer incharge GUID.</param>
        /// <returns>Datset ds</returns>
        public DataSet CustomerInchargeDetailDelete(string customerInchargeGuid)
        {
            var objPortal = new DL.Portal();
            DataSet ds = objPortal.CustomerInchargeDetailDelete(customerInchargeGuid);
            return ds;
        }

        /// <summary>
        /// Portals user detail get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="portalLogOnGuid">The portal login GUID.</param>
        /// <returns>Datset ds</returns>
        public DataSet PortalUserDetailGet(string companyCode, string portalLogOnGuid)
        {
            var objPortal = new DL.Portal();
            DataSet ds = objPortal.PortalUserDetailGet(companyCode, portalLogOnGuid);
            return ds;
        }

        /// <summary>
        /// Portals user insert.
        /// </summary>
        /// <param name="userType">Type of the user.</param>
        /// <param name="customerCode">The customer code.</param>
        /// <param name="accountId">The account id.</param>
        /// <param name="logOnId">The login id.</param>
        /// <param name="email">The email.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="active">if set to <c>true</c> [active].</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="keyForEncryption">Tkey ForEncryption.</param>
        /// <returns>Datset ds</returns>
        public DataSet PortalUserInsert(string userType, string customerCode, string accountId, string logOnId, string email, string userName, string password, bool active, string companyCode, string modifiedBy, string keyForEncryption)
        {
            var objPortal = new DL.Portal();
            var objblUserManagement = new UserManagement();
            var encodedPassword = objblUserManagement.EncryptPassword(accountId + password, true, keyForEncryption);
            DataSet ds = objPortal.PortalUserInsert(userType, customerCode, accountId, logOnId, email, userName, encodedPassword, password, active, companyCode, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Portals user update.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="userPassword">The user password.</param>
        /// <param name="portalLogOnGuid">The portal login GUID.</param>
        /// <param name="logOnId">The login id.</param>
        /// <param name="email">The email.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="active">if set to <c>true</c> [active].</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="keyForEncryption">The key for encryption.</param>
        /// <returns>Datset ds</returns>
        public DataSet PortalUserUpdate(string accountId, string userPassword, string portalLogOnGuid, string logOnId, string email, string userName, string password, bool active, string companyCode, string modifiedBy, string keyForEncryption)
        {
            var objPortal = new DL.Portal();
            string encodedPassword = string.Empty;
            var objblUserManagement = new UserManagement();
            if (password.ToLower() != Properties.Resources.ChangePasswordPortal.ToLower())
            {
                encodedPassword = objblUserManagement.EncryptPassword(accountId + password, true, keyForEncryption);
            }

            if (userPassword == encodedPassword)
            {
                encodedPassword = string.Empty;
            }

            DataSet ds = objPortal.PortalUserUpdate(portalLogOnGuid, logOnId, email, userName, encodedPassword, active, companyCode, modifiedBy);
            return ds;
        }

        /// <summary>
        /// Customers the inbox details get.
        /// </summary>
        /// <param name="isAdmin">The is admin.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <returns>Dataset ds</returns>
        public DataSet CustomerInboxDetailsGet(string isAdmin, string userId, string locationAutoId)
        {
            var objPortal = new DL.Portal();
            var isSuperUser = isAdmin == Properties.Resources.AdminType ? "1" : "0";
            DataSet ds = objPortal.CustomerInboxDetailsGet(isSuperUser, userId, locationAutoId);
            return ds;
        }

        /// <summary>
        /// Customers the change request get details.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <returns>Dataset ds</returns>
        public DataSet CustomerChangeRequestGetDetails(string guid, string requestType)
        {
            var objPortal = new DL.Portal();
            DataSet ds = objPortal.CustomerChangeRequestGetDetails(guid, requestType);
            return ds;
        }

        /// <summary>
        /// Customers the portal total request get.
        /// </summary>
        /// <param name="isAdmin">The is admin.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <returns>Return Dataset ds</returns>
        public DataSet CustomerPortalTotalRequestGet(string isAdmin, string userId, string locationAutoId)
        {
            var objPortal = new DL.Portal();
            var isSuperUser = isAdmin == Properties.Resources.AdminType ? "1" : "0";
            DataSet ds = objPortal.CustomerPortalTotalRequestGet(isSuperUser, userId, locationAutoId);
            return ds;
        }
        #endregion

        /// <summary>
        /// Customers the change request detail update.
        /// </summary>
        /// <param name="requestGuid">The request GUID.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="operationType">Type of the operation.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Dataset Ds</returns>
        public DataSet CustomerChangeRequestDetailUpdate(string requestGuid, string requestType, string comment, string operationType, string modifiedBy)
        {
            var objPortal = new DL.Portal();
            DataSet ds = objPortal.CustomerChangeRequestDetailUpdate(requestGuid, requestType, comment, operationType, modifiedBy);
            return ds;
        }

        #region Function Related to Employee Portal

        /// <summary>
        /// Fills the Details of requests generated on Series Based
        /// </summary>
        /// <param name="isAdmin">The is admin.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="seriesName">Name of the series.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeInboxDetailsGet(string isAdmin, string userId, string locationAutoId, string seriesName)
        {
            var objPortal = new DL.Portal();
            var isSuperUser = isAdmin == Properties.Resources.AdminType ? "1" : "0";
            DataSet ds = objPortal.EmployeeInboxDetailsGet(isSuperUser, userId, locationAutoId, seriesName);
            return ds;
        }


        /// <summary>
        /// Employees the reject request.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="ticketNo">The ticket no.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="seriesName">Name of the series.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeRejectRequest(string userId, string ticketNo, string companyCode, string seriesName)
        {

            var objPortal = new DL.Portal();

            DataSet ds = objPortal.EmployeeRejectRequest(userId, ticketNo, companyCode, seriesName);
            return ds;
        }

        /// <summary>
        /// Employees the approve request.
        /// </summary>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="seriesName">Name of the series.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="ticketNo">The ticket no.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeApproveRequest(string employeeNumber, string seriesName, string companyCode, string locationAutoId, string ticketNo,string modifiedBy)
        {
            var objPortal = new DL.Portal();

            DataSet ds = objPortal.EmployeeApproveRequest(employeeNumber, seriesName, companyCode, locationAutoId,ticketNo,modifiedBy);
            return ds;
        }

        /// <summary>
        /// Employees the change request get details.
        /// </summary>
        /// <param name="requestNo">The request no.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeChangeRequestGetDetails(string requestNo, string requestType, string companyCode)
        {
            var objPortal = new DL.Portal();
            DataSet ds = objPortal.EmployeeChangeRequestGetDetails(requestNo, requestType,companyCode);
            return ds;
        }

        #endregion

    }
}
