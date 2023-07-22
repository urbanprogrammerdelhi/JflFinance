// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Portal.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

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
        /// <returns>Dataset Ds</returns>
        public DataSet CustomerInchargeDetailGet(string portalLogOnGuid)
        {
            var objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(Properties.Resources.PortalLoginGuid, portalLogOnGuid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_InCharge_Get", objParm);
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
        /// <returns>Dataset Ds</returns>
        public DataSet CustomerInchargeDetailInsert(string inchargeId, string emailId, string phoneNumber, string portalLogOnGuid, string companyCode, string modifiedBy)
        {
            var objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(Properties.Resources.InchargeId, inchargeId);
            objParm[1] = new SqlParameter(Properties.Resources.EmailID, emailId);
            objParm[2] = new SqlParameter(Properties.Resources.PhoneNo, phoneNumber);
            objParm[3] = new SqlParameter(Properties.Resources.PortalLoginGuid, portalLogOnGuid);
            objParm[4] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[5] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_InCharge_Insert", objParm);
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
        /// <returns>Dataset Ds</returns>
        public DataSet CustomerInchargeDetailUpdate(string inchargeId, string emailId, string phoneNumber, string customerInchargeGuid, string modifiedBy)
        {
            var objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(Properties.Resources.InchargeId, inchargeId);
            objParm[1] = new SqlParameter(Properties.Resources.EmailID, emailId);
            objParm[2] = new SqlParameter(Properties.Resources.PhoneNo, phoneNumber);
            objParm[3] = new SqlParameter(Properties.Resources.CustomerInchargeGuid, customerInchargeGuid);
            objParm[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_InCharge_Update", objParm);
            return ds;
        }

        /// <summary>
        /// Customers incharge detail delete.
        /// </summary>
        /// <param name="customerInchargeGuid">The customer incharge GUID.</param>
        /// <returns>Dataset Ds</returns>
        public DataSet CustomerInchargeDetailDelete(string customerInchargeGuid)
        {
            var objParm = new SqlParameter[1];
            objParm[0] = new SqlParameter(Properties.Resources.CustomerInchargeGuid, customerInchargeGuid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_InCharge_Delete", objParm);
            return ds;
        }

        /// <summary>
        /// Portals user detail get.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="portalLogOnGuid">The portal login GUID.</param>
        /// <returns>Dataset DsDataset Ds</returns>
        public DataSet PortalUserDetailGet(string companyCode, string portalLogOnGuid)
        {
            var objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[1] = new SqlParameter(Properties.Resources.PortalLoginGuid, portalLogOnGuid);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_User_GetAll", objParm);
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
        /// <param name="encodedPassword">The encoded password.</param>
        /// <param name="password">The password.</param>
        /// <param name="active">Act ive</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Dataset Ds</returns>
        public DataSet PortalUserInsert(string userType, string customerCode, string accountId, string logOnId, string email, string userName, string encodedPassword, string password, bool active, string companyCode, string modifiedBy)
        {
            var objParm = new SqlParameter[10];
            objParm[0] = new SqlParameter(Properties.Resources.UserType, userType);
            objParm[1] = new SqlParameter(Properties.Resources.CustomerCode, customerCode);
            objParm[2] = new SqlParameter(Properties.Resources.AccountID, accountId);
            objParm[3] = new SqlParameter(Properties.Resources.LoginID, logOnId);
            objParm[4] = new SqlParameter(Properties.Resources.EmailID, email);
            objParm[5] = new SqlParameter(Properties.Resources.UserName, userName);
            objParm[6] = new SqlParameter(Properties.Resources.PassWord, encodedPassword);
            objParm[7] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParm[9] = new SqlParameter(Properties.Resources.Active, active);
           // objParm[10] = new SqlParameter(Properties.Resources.PassSystemAdmin, password);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_User_Insert", objParm);
            return ds;
        }

        /// <summary>
        /// Portals user update.
        /// </summary>
        /// <param name="portalLogOnGuid">The portal login GUID.</param>
        /// <param name="logOnId">The login id.</param>
        /// <param name="email">The email.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="encodedPassword">The encoded password.</param>
        /// <param name="active">if set to <c>true</c> [active].</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Dataset Ds</returns>
        public DataSet PortalUserUpdate(string portalLogOnGuid, string logOnId, string email, string userName, string encodedPassword, bool active, string companyCode, string modifiedBy)
        {
            var objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(Properties.Resources.PortalLoginGuid, portalLogOnGuid);
            objParm[1] = new SqlParameter(Properties.Resources.LoginID, logOnId);
            objParm[2] = new SqlParameter(Properties.Resources.EmailID, email);
            objParm[3] = new SqlParameter(Properties.Resources.UserName, userName);
            objParm[4] = new SqlParameter(Properties.Resources.PassWord, encodedPassword);

            objParm[5] = new SqlParameter(Properties.Resources.Active, active);
            objParm[6] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[7] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_User_Update", objParm);
            return ds;
        }

        /// <summary>
        /// Customers the inbox details get.
        /// </summary>
        /// <param name="isSuperUser">The is super user.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <returns>Dataset Ds</returns>
        public DataSet CustomerInboxDetailsGet(string isSuperUser, string userId, string locationAutoId)
        {
            var objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(Properties.Resources.IsAdmin, isSuperUser);
            objParm[1] = new SqlParameter(Properties.Resources.UserId, userId);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_CustomerInboxDetails_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Customers the change request get details.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <param name="requestType">Type of the request.</param>
        /// <returns>Dataset Ds</returns>
        public DataSet CustomerChangeRequestGetDetails(string guid, string requestType)
        {
            var objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(Properties.Resources.Guid, guid);
            objParm[1] = new SqlParameter(Properties.Resources.RequestType, requestType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_CustomerChangeRequestDetails_Get", objParm);
            return ds;
        }

        /// <summary>
        /// Customers the portal total request get.
        /// </summary>
        /// <param name="isSuperUser">The is super user.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="locationAutoId">The location auto id.</param>
        /// <returns>Dataset Ds</returns>
        public DataSet CustomerPortalTotalRequestGet(string isSuperUser, string userId, string locationAutoId)
        {
            var objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(Properties.Resources.IsAdmin, isSuperUser);
            objParm[1] = new SqlParameter(Properties.Resources.UserId, userId);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_CustomerChangeRequestDetailCount_GetAll", objParm);
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
        /// <returns>Dataset ds</returns>
        public DataSet CustomerChangeRequestDetailUpdate(string requestGuid, string requestType, string comment, string operationType, string modifiedBy)
        {
            var objParm = new SqlParameter[5];
            objParm[0] = new SqlParameter(Properties.Resources.Guid, requestGuid);
            objParm[1] = new SqlParameter(Properties.Resources.RequestType, requestType);
            objParm[2] = new SqlParameter(Properties.Resources.Comment, comment);
            objParm[3] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParm[4] = new SqlParameter(Properties.Resources.OperationType, operationType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_CustomerChangeRequestDetailUpdate", objParm);
            return ds;
        }

        #region Fills the Details of Employee Portal Inbox

        /// <summary>
        /// Employees the inbox details get.
        /// </summary>
        /// <param name="isSuperUser">The is super user.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="seriesName">Name of the series.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeInboxDetailsGet(string isSuperUser, string userId, string locationAutoId,string seriesName)
        {
            var objParm = new SqlParameter[4];
            objParm[0] = new SqlParameter(Properties.Resources.IsAdmin, isSuperUser);
            objParm[1] = new SqlParameter(Properties.Resources.UserId, userId);
            objParm[2] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[3] = new SqlParameter(Properties.Resources.SeriesName, seriesName);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpPortal_EmployeeInboxDetails_Get", objParm);
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
        public DataSet EmployeeRejectRequest(string userId,string ticketNo, string companyCode, string seriesName)
        {
            var objParm = new SqlParameter[4];
            
            objParm[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParm[1] = new SqlParameter(Properties.Resources.SeriesName, seriesName);
            objParm[2] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[3] = new SqlParameter(Properties.Resources.RequestNo, ticketNo);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpEPortalRejectRequestBySeries", objParm);
            return ds;
        }

        /// <summary>
        /// Employees the change request get details.
        /// </summary>
        /// <param name="requestNo">The request no.</param>
        /// <param name="seriesName">Name of the series.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet EmployeeChangeRequestGetDetails(string requestNo, string seriesName, string companyCode)
        {
            var objParm = new SqlParameter[3];
            objParm[0] = new SqlParameter(Properties.Resources.RequestNo, requestNo);
            objParm[1] = new SqlParameter(Properties.Resources.SeriesName, seriesName);
            objParm[2] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpEPortalChangeRequestDetails_Get", objParm);
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
        public DataSet EmployeeApproveRequest(string employeeNumber, string seriesName, string companyCode, string locationAutoId, string ticketNo, string modifiedBy)
        {
            var objParm = new SqlParameter[6];
            objParm[0] = new SqlParameter(Properties.Resources.EmployeeId, employeeNumber);
            objParm[1] = new SqlParameter(Properties.Resources.SeriesName, seriesName);
            objParm[2] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParm[3] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParm[4] = new SqlParameter(Properties.Resources.RequestNo, ticketNo);
            objParm[5] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpEPortalApprovedRequestBySeries", objParm);
            return ds;
        }
        #endregion
    }
}
