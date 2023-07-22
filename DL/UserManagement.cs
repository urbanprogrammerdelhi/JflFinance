// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="UserManagement.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Globalization;
using System.Collections.Generic;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class UserManagement.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class UserManagement
    {
        #region Constants
        /// <summary>
        /// The user detail table index in get user information sp
        /// </summary>
        private const int UserDetailTableIndexInGetUserInfoSP = 0;
        /// <summary>
        /// The password policy table index in get user information sp
        /// </summary>
        private const int PasswordPolicyTableIndexInGetUserInfoSP = 1;
        /// <summary>
        /// The unsuccessful password attempt table index in get user information sp
        /// </summary>
        private const int UnsuccessfulPasswordAttemptTableIndexInGetUserInfoSP = 2;
        /// <summary>
        /// The password changed table index in get user information sp
        /// </summary>
        private const int PasswordChangedTableIndexInGetUserInfoSP = 3;
        /// <summary>
        /// The active area change table index in get user information sp
        /// </summary>
        private const int ActiveAreaChangeTableIndexInGetUserInfoSP = 4;

        #endregion

        #region Function Related To User Management

        #region Function Related To User Login
        /// <summary>
        /// To get the Loged in User Information
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>Dataset with UserID, UserName,UserType</returns>
        public DataSet InsertPasswordPolicyCredentials(string userid)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userid);
            DataSet insertStatus = SqlHelper.ExecuteDataset("udpMstUser_PasswordPolicyCredentialsInsert", objParam);
            return insertStatus;
        }
        /// <summary>
        /// Inserts the current login details.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="sessionID">The session identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet InsertCurrentLoginDetails(string userId, string sessionID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.SessionID, sessionID);

            DataSet insertStatus = SqlHelper.ExecuteDataset("udpMstUser_UserLoginDetails_Insert", objParam);
            return insertStatus;
        }
        /// <summary>
        /// Disables the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DisableUser(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet insertStatus = SqlHelper.ExecuteDataset("udpMstUser_DisableUser", objParam);
            return insertStatus;
        }
        /// <summary>
        /// Checks the last login details.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckLastLoginDetails(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet insertStatus = SqlHelper.ExecuteDataset("udpMstUser_UserLoginDetails_Fetch", objParam);
            return insertStatus;
        }
        /// <summary>
        /// Users the detail get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserDetailGet(string userId, string password)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.PassWord, password);

            //Get the User Detail which will include
            //User Information including Password, Password Policy,Unsuccessful Login attempt Details so far,
            //Password Changed Details and also whether user is active incharge
            //This information is seggregated across multiple Tables.
            DataSet ds = SqlHelper.ExecuteDataset("udp_UserInfo_Get", objParam);

            if (ds != null && ds.Tables.Count > 0 &&
                    ds.Tables[PasswordPolicyTableIndexInGetUserInfoSP].Rows.Count > 0 &&
                        ds.Tables[UnsuccessfulPasswordAttemptTableIndexInGetUserInfoSP].Rows.Count > 0)
            {
                ds.Tables[UserDetailTableIndexInGetUserInfoSP].Locale = CultureInfo.InvariantCulture;
                ds.Tables[PasswordPolicyTableIndexInGetUserInfoSP].Locale = CultureInfo.InvariantCulture;
                ds.Tables[UnsuccessfulPasswordAttemptTableIndexInGetUserInfoSP].Locale = CultureInfo.InvariantCulture;

                if (ds.Tables.Count > 2 && ds.Tables[UnsuccessfulPasswordAttemptTableIndexInGetUserInfoSP].Rows.Count > 0)
                {
                    Guard.ArgumentConvertibleTo<int>(ds.Tables[UnsuccessfulPasswordAttemptTableIndexInGetUserInfoSP].Rows[0][Properties.Resources.fldUnSuccessfulAttempt].ToString(), "myIntArgument");
                }
                if (ds.Tables.Count > 1 && ds.Tables[PasswordPolicyTableIndexInGetUserInfoSP].Rows.Count > 0)
                {
                    Guard.ArgumentConvertibleTo<int>(ds.Tables[PasswordPolicyTableIndexInGetUserInfoSP].Rows[0][Properties.Resources.fldUnSuccessfulAtemptAllowed].ToString(), "myIntArgument");
                }
                int unsuccessfulPasswordAttempt = int.Parse(ds.Tables[UnsuccessfulPasswordAttemptTableIndexInGetUserInfoSP].Rows[0][Properties.Resources.fldUnSuccessfulAttempt].ToString()) ;
                int unsuccessfulPasswordAttemptAllowed = int.Parse(ds.Tables[PasswordPolicyTableIndexInGetUserInfoSP].Rows[0][Properties.Resources.fldUnSuccessfulAtemptAllowed].ToString());
                bool disableOnUnsuccessfulAttempt = bool.Parse(ds.Tables[PasswordPolicyTableIndexInGetUserInfoSP].Rows[0][Properties.Resources.fldIsDisableAcAfterUnSuccessAttempt].ToString());
                //In case user has crossed the maximum number of attempts allowed for unsuccessful logins.
                if (unsuccessfulPasswordAttempt >= unsuccessfulPasswordAttemptAllowed)
                {
                        ds.Dispose();
                        var ds1 = new DataSet { Locale = CultureInfo.InvariantCulture };
                        var errorTable = new DataTable { Locale = CultureInfo.InvariantCulture, TableName = "LoginFail" };
                        errorTable.Columns.Add(new DataColumn(Properties.Resources.fldMessageId, typeof(int)));
                        errorTable.Columns.Add(new DataColumn(Properties.Resources.fldMessageString, typeof(string)));

                        DataRow myDataRow = errorTable.NewRow();
                        myDataRow[Properties.Resources.fldMessageId] = 2;

                        Guard.ArgumentConvertibleTo<bool>(ds.Tables[PasswordPolicyTableIndexInGetUserInfoSP].Rows[0][Properties.Resources.fldIsDisableAcAfterUnSuccessAttempt].ToString(), "myBoolArgument");
                        if (disableOnUnsuccessfulAttempt)
                        {
                            SqlParameter[] objParam1 = new SqlParameter[1];
                            objParam1[0] = new SqlParameter(Properties.Resources.UserId, userId);
                            SqlHelper.ExecuteDataset("udpUser_Inactive", objParam1);
                            myDataRow[Properties.Resources.fldMessageString] = "YourAccountHasBeenDisabledPleaseContactAdmin";
                        }
                        else
                        {
                            myDataRow[Properties.Resources.fldMessageId] = 3;
                            myDataRow[Properties.Resources.fldMessageString] = "YouHaveCrossedMaximumAttemptPleaseContactAdmin";
                        }

                        errorTable.Rows.Add(myDataRow);
                        ds1.Tables.Add(errorTable);
                        return ds1;
                    }
                }
            return ds;
        }

        /// <summary>
        /// Checks the password unsuccessful attempt.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckPasswordUnsuccessfulAttempt(string userId)
        {
            
                SqlParameter[] objParam3 = new SqlParameter[1];
                objParam3[0] = new SqlParameter(Properties.Resources.UserId, userId);
                DataSet ds= SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_Getunsuccessfullattempts", objParam3);
                return ds;
        }

        /// <summary>
        /// Depending on the status of the Login the DB needs to be updated accordingly.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="isSuccessful">This indicates whether the Login is Successful or not</param>
        public void UserLoginDetailsUpdate(string userId, bool isSuccessful)
        {
            if (isSuccessful)
            {
                SqlParameter[] objParam3 = new SqlParameter[2];
                objParam3[0] = new SqlParameter(Properties.Resources.UserId, userId);
                objParam3[1] = new SqlParameter(Properties.Resources.Flag, 2);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_NoofAttempts_Update", objParam3);
            }
            else
            {
                SqlParameter[] objParam2 = new SqlParameter[2];
                objParam2[0] = new SqlParameter(Properties.Resources.UserId, userId);
                objParam2[1] = new SqlParameter(Properties.Resources.Flag, 1);

                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_NoofAttempts_Update", objParam2);
            }
        }

        /// <summary>
        /// To get the Number of Active users in database
        /// </summary>
        /// <returns>Dataset with NoOfActiveUsers In Database</returns>
        public DataSet NoOfActiveUserGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NoofActiveUsers_Get");
            return ds;
        }

        /// <summary>
        /// To get the Number of Total users in database
        /// </summary>
        /// <returns>Dataset with NoOfTotalUsers In Database</returns>
        public DataSet TotalUserGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_NoofTotalUsers_Get");
            return ds;

        }

        /// <summary>
        /// To get the UserName and UserType by UserID
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with UserName, UserType</returns>
        public DataSet UserNameAndTypeGet(string userId)
        {
            var ds = new DataSet {Locale = CultureInfo.InvariantCulture};
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UserNameAndType_Get", objParam);
            return ds;
        }

        /// <summary>
        /// Users the get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet UserGetAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udp_User_Get");
            return ds;
        }
        #endregion

        #region Functions related to Get Companies for user

        /// <summary>
        /// To get the Companies for Loged in User have access
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with CompanyCode, companyDesc</returns>
        public DataSet UserCompanyAccessGet(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset("udp_UserCompaniesAccess_Get", objParam);
            return ds;

        }

        #endregion

        #region Functions related to get HRLocations for user

        /// <summary>
        /// To get the HRLocations for Loged in User have access
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with HRLocationAutoID, HRLocationCode, CompanyCode and HRLocationDesc</returns>
        public DataSet UserHRLocationAccessGet(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset("udp_UserHRLocationAccess_Get", objParam);
            return ds;

        }

        /// <summary>
        /// To get the HRLocations for (Selected CompanyCode and Loged in User have access)
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with HRLocationCode and HRLocationDesc</returns>
        public DataSet UserHRLocationAccessGet(string userId, string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset("udp_UserHRLocationAccess_BasedonCompanyAndUserId_Get", objParam);
            return ds;
        }

        #endregion

        #region Functions related to Get Locations for user

        /// <summary>
        /// To get the Locations for Loged in User have access
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with LocationAutoId, LocationCode, CompanyCode, HRLocationCode and LocationDesc</returns>
        public DataSet UserLocationAccessGet(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset("udp_UserLocationAccess_Get", objParam);
            return ds;

        }

        /// <summary>
        /// To get the Locations for (Selected CompanyCode, HRLocationCode and Loged in User have access)
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>Dataset with LocationAutoId, LocationCode and LocationDesc</returns>
        public DataSet UserLocationAccessGet(string userId, string companyCode, string hrLocationCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParam[2] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);

            DataSet ds = SqlHelper.ExecuteDataset("udp_UserLocationAccess_BasedOnCompanyHRLocationUserID_Get", objParam);
            return ds;
        }

        #endregion

        #region Functions Related to Menus
        /// <summary>
        /// Get The menu items in a dataset
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="treeViewCodeNo">The tree view code no.</param>
        /// <returns>Data set</returns>
        public DataSet UserMenuGet(string userId, string locationAutoId, int treeViewCodeNo)
        {
            var objMenuDataSet = new DataSet {Locale = CultureInfo.InvariantCulture};
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.TreeViewCode, treeViewCodeNo);

            DataTable objDataTableMenuHead = SqlHelper.ExecuteDatatable("udp_MenuHead_Get", objParam);
            DataTable objDataTableMenuChild = SqlHelper.ExecuteDatatable("udp_MenuGetChild", objParam);

            objMenuDataSet.Tables.Add(objDataTableMenuHead);
            objMenuDataSet.Tables.Add(objDataTableMenuChild);

            return objMenuDataSet;
        }
        /// <summary>
        /// Menus the node get all.
        /// </summary>
        /// <param name="menuHeadAutoId">The menu head automatic identifier.</param>
        /// <param name="menuNodeAutoId">The menu node automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet MenuNodeGetAll(string menuHeadAutoId, string menuNodeAutoId)
        {
            SqlParameter[] objParm = new SqlParameter[2];
            objParm[0] = new SqlParameter(Properties.Resources.MenuHeadAutoId, menuHeadAutoId);
            objParm[1] = new SqlParameter(Properties.Resources.MenuHeadAutoId, menuNodeAutoId);

            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuNode_GetAllByMenuNodeAutoIdExceptParam", objParm);
            return ds;
        }
        /// <summary>
        /// Supers the admin level2 get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <returns>DataSet.</returns>
        public DataSet SuperAdminLevel2Get(string UGCode, string MenuHeadCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UGCode, UGCode);
            objParam[1] = new SqlParameter(Properties.Resources.MenuHeadCode, MenuHeadCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpLevel2_UserScreenRight_4SA_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Menus the type get.
        /// </summary>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <returns>DataSet.</returns>
        public DataSet MenuTypeGet(string MenuHeadCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadCode, MenuHeadCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMenuType", objParam);
            return ds;
        }

        /// <summary>
        /// to get the MenuHeads
        /// </summary>
        /// <returns>Data set with MenuHeadCode MenuHeadName PositionNo Isactive</returns>
        public DataSet MenuHeadGetAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuHead_GetAll");
            return ds;
        }
        /// <summary>
        /// To get The MenuHeadAutoId, MenuHeadCode and MenuHeadName Except the MenuHeadCode Given in the Parameter List
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <returns>To get The MenuHeadAutoId, MenuHeadCode and MenuHeadName Except the MenuHeadCode Given in the Parameter List</returns>
        public DataSet MenuHeadCodeGetAll(string menuHeadCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadCode, menuHeadCode);

            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuHead_GetAllByMenuHeadCodeExceptParam", objParam);
            return ds;
        }
        /// <summary>
        /// To get The MenuHeadAutoId, MenuHeadCode and MenuHeadName Except the MenuHeadAutoId Given in the Parameter List
        /// </summary>
        /// <param name="menuHeadAutoId">The menu head automatic identifier.</param>
        /// <returns>To get The MenuHeadAutoId, MenuHeadCode and MenuHeadName Except the MenuHeadAutoId Given in the Parameter List</returns>
        public DataSet MenuHeadAutoIdGetAll(string menuHeadAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadAutoId, menuHeadAutoId);

            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuHead_GetAllByMenuHeadAutoIdExceptParam", objParam);
            return ds;
        }
        /// <summary>
        /// to get the MenuNodes
        /// </summary>
        /// <returns>Data set with MenuNodeAutoID MenuHeadCode MenuNodeCode MenuNodeName PageName PositionNo Isactive</returns>
        public DataSet MenuNodeGetAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuNode_GetAll");
            return ds;
        }
        /// <summary>
        /// to get the MenuNodes for MenuHeadCode
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <returns>Data set with MenuNodeAutoID MenuHeadCode MenuNodeCode MenuNodeName PageName PositionNo Isactive</returns>
        public DataSet MenuNodeGet(string menuHeadCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadCode, menuHeadCode);
            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuNode_Get4Head", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Menu Heads
        /// </summary>
        /// <returns>DataSet with MenuHeadCode and MenuHeadName</returns>
        public DataSet MenuHeadCodeDescGetAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuHead_Codedesc_GetAll");
            return ds;
        }
        /// <summary>
        /// to Save the MenuHead
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <param name="positionNo">The position no.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="parentMenuHeadAutoId">The parent menu head automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuHeadAdd(string menuHeadCode, string menuHeadName, int positionNo, string isActive, string parentMenuHeadAutoId, string modifiedBy)
        {
            if (string.IsNullOrEmpty(parentMenuHeadAutoId))
            {
                parentMenuHeadAutoId = "0";
            }
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadCode, menuHeadCode);
            objParam[1] = new SqlParameter(Properties.Resources.MenuHeadName, menuHeadName);
            objParam[2] = new SqlParameter(Properties.Resources.PositionNo, positionNo);
            objParam[3] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[4] = new SqlParameter(Properties.Resources.ParentMenuHeadAutoId, parentMenuHeadAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuHead_Add", objParam);
            return ds;
        }
        /// <summary>
        /// x
        /// to Update the MenuHead
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <param name="positionNo">The position no.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="parentMenuHeadAutoId">The parent menu head automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuHeadUpdate(string menuHeadCode, string menuHeadName, int positionNo, string isActive, string parentMenuHeadAutoId, string modifiedBy)
        {
            if (string.IsNullOrEmpty(parentMenuHeadAutoId))
            {
                parentMenuHeadAutoId = "0";
            }
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadCode, menuHeadCode);
            objParam[1] = new SqlParameter(Properties.Resources.MenuHeadName, menuHeadName);
            objParam[2] = new SqlParameter(Properties.Resources.PositionNo, positionNo);
            objParam[3] = new SqlParameter(Properties.Resources.IsActive, isActive);
            if (string.IsNullOrEmpty(parentMenuHeadAutoId))
            {
                objParam[4] = new SqlParameter(Properties.Resources.ParentMenuHeadAutoId, "0");
            }
            else
            {
                objParam[4] = new SqlParameter(Properties.Resources.ParentMenuHeadAutoId, parentMenuHeadAutoId);
            }
            objParam[5] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuHead_Update", objParam);
            return ds;
        }
        /// <summary>
        /// to Delete the MenuHead
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuHeadDelete(string menuHeadCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadCode, menuHeadCode);
            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuHead_Delete", objParam);
            return ds;
        }
        /// <summary>
        /// To Save Nodes
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuNodeCode">The menu node code.</param>
        /// <param name="menuNodeName">Name of the menu node.</param>
        /// <param name="pageName">Name of the page.</param>
        /// <param name="dependOn">The depend on.</param>
        /// <param name="positionNo">The position no.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MenuNodeAdd(string menuHeadCode, string menuNodeCode, string menuNodeName, string pageName, int dependOn, int positionNo, string isActive, string modifiedBy)
        {
            SqlParameter[] objParm = new SqlParameter[8];
            objParm[0] = new SqlParameter(Properties.Resources.MenuHeadCode, menuHeadCode);
            objParm[1] = new SqlParameter(Properties.Resources.MenuHeadCode, menuNodeCode);
            objParm[2] = new SqlParameter(Properties.Resources.MenuHeadName, menuNodeName);
            objParm[3] = new SqlParameter(Properties.Resources.PageName, pageName);
            objParm[4] = new SqlParameter(Properties.Resources.DependOn, dependOn);
            objParm[5] = new SqlParameter(Properties.Resources.PositionNo, positionNo);
            objParm[6] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParm[7] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuNode_Add", objParm);
            return ds;
        }
        /// <summary>
        /// to Update the MenuNode
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuNodeCode">The menu node code.</param>
        /// <param name="menuNodeName">Name of the menu node.</param>
        /// <param name="pageName">Name of the page.</param>
        /// <param name="dependOn">The depend on.</param>
        /// <param name="positionNo">The position no.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuNodeUpdate(string menuHeadCode, string menuNodeCode, string menuNodeName, string pageName, int dependOn, int positionNo, string isActive, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadCode, menuHeadCode);
            objParam[1] = new SqlParameter(Properties.Resources.MenuNodeCode, menuNodeCode);
            objParam[2] = new SqlParameter(Properties.Resources.MenuNodeName, menuNodeName);
            objParam[3] = new SqlParameter(Properties.Resources.PageName, pageName);
            objParam[4] = new SqlParameter(Properties.Resources.DependOn, dependOn);
            objParam[5] = new SqlParameter(Properties.Resources.PositionNo, positionNo);
            objParam[6] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_MenuNode_Update", objParam);
            return ds;
        }
        /// <summary>
        /// to Delete the MenuNode
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuNodeCode">The menu node code.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuNodeDelete(string menuHeadCode, string menuNodeCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.MenuHeadCode, menuHeadCode);
            objParam[1] = new SqlParameter(Properties.Resources.MenuNodeCode, menuNodeCode);

            DataSet ds = SqlHelper.ExecuteDataset("udp_MenuNode_Delete", objParam);
            return ds;
        }
        #endregion

        #endregion

        #region Function Related To Super Administrator Management

        #region Function Related To Super Administrator

        /// <summary>
        /// To get the Loged in SuperAdministrator Information
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with CompanyCode, companyDesc</returns>
        public DataSet SuperAdminInfoGet(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SuperAdminInfo_Get", objParam);
            return ds;
        }

        #endregion

        #region Functions related to Get Companies for Super administrator

        /// <summary>
        /// To get the all Companies for Super administrator
        /// </summary>
        /// <returns>Dataset with CompanyCode, companyDesc</returns>
        public DataSet SuperAdminCompanyAccessGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SuperAdminCompaniesAccess_Get");
            return ds;
        }

        #endregion

        #region Functions related to Get HRLocations for Super Administrator

        /// <summary>
        /// To get the all HRLocation for Super administrator
        /// </summary>
        /// <returns>Dataset with HRLocationAutoID, HRLocationCode, CompanyCode and HRLocationDesc</returns>
        public DataSet SuperAdminHRLocationAccessGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SuperAdminHRLocationAccess_Get");
            return ds;
        }

        /// <summary>
        /// To get the all HRLocation for (Selected CompanyCode for Super administrator)
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with HRLocationCode and HRLocationDesc</returns>
        public DataSet SuperAdminHRLocationAccessGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset("udp_SuperAdminHRLocationAccess_BasedonCompany_Get", objParam);
            return ds;
        }

        #endregion

        #region Functions related to Get Locations for Super Administrator

        /// <summary>
        /// To get the all Location for Super administrator
        /// </summary>
        /// <returns>Dataset with LocationAutoId, LocationCode, CompanyCode, HRLocationCode and LocationDesc</returns>
        public DataSet SuperAdminLocationAccessGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SuperAdminLocationAccess_Get");
            return ds;
        }

        /// <summary>
        /// To get the Locations for (Selected CompanyCode, HRLocationCode and Super administrator)
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>Dataset with LocationAutoId, LocationCode and LocationDesc</returns>
        public DataSet SuperAdminLocationAccessGet(string companyCode, string hrLocationCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            objParam[1] = new SqlParameter(Properties.Resources.HrLocationCode, hrLocationCode);

            DataSet ds = SqlHelper.ExecuteDataset("udp_SuperAdminLocationAccess_BasedonCompanyCodeAndHRLocationCode_Get", objParam);
            return ds;
        }

        /// <summary>
        /// getting Location Description Based on Location AutoID
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLoggedInLocation(string locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);

            DataSet ds = SqlHelper.ExecuteDataset("udpReports_Location_Get", objParam);
            return ds;
        }
        #endregion

        #region Functions Related to Get Menus for Super Administrator
        /// <summary>
        /// Get The menu items in a dataset
        /// </summary>
        /// <param name="treeViewCode">The tree view code.</param>
        /// <returns>Data Set</returns>
        public DataSet SuperAdministratorMenuGet(int treeViewCode)
        {
            var objMenuDataSet = new DataSet {Locale = CultureInfo.InvariantCulture};

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.TreeViewCode, treeViewCode);

            DataTable objDataTableMenuHead = SqlHelper.ExecuteDatatable("udp_MenuHead_SuperAdministrator_Get", objParam);
            DataTable objDataTableMenuChild = SqlHelper.ExecuteDatatable("udp_MenuNode_SuperAdministrator_Get", objParam);

            objMenuDataSet.Tables.Add(objDataTableMenuHead);
            objMenuDataSet.Tables.Add(objDataTableMenuChild);

            return objMenuDataSet;
        }

        #endregion

        #endregion

        #region Function Related to Users Creation

        #region Create New User

        /*Code added by   on 30-Aug-2011*/
        /// <summary>
        /// This is OverLoaded method when the "ISEmployee" is active key
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userType">Type of the user.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="contactNo">The contact no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userGroup">The user group.</param>
        /// <param name="isEmployee">if set to <c>true</c> [is employee].</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserAdd(string userId, string password, string userName, string userType, bool isActive, string modifiedBy, string emailId, string contactNo, string locationAutoId, string userGroup, bool isEmployee, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.UserName, userName);
            objParam[2] = new SqlParameter(Properties.Resources.PassWord, password);
            objParam[3] = new SqlParameter(Properties.Resources.IsAdmin, userType);
            objParam[4] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[5] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(Properties.Resources.EmailID, emailId);
            objParam[7] = new SqlParameter(Properties.Resources.ContactNo, contactNo);
            objParam[8] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParam[9] = new SqlParameter(Properties.Resources.UserGroup, userGroup);
            objParam[10] = new SqlParameter(Properties.Resources.IsEmployee, isEmployee);
            objParam[11] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);

            DataSet insertStatus = SqlHelper.ExecuteDataset("udpMstUser_User_Insert", objParam);
            /*End of Code added by   for EMAIL ID and MOBILE NO*/
            return insertStatus;
        }
        /*Code added by Mayank for Registering Employee for Insta Service Portal*/
        public DataSet UserAddEngineer(string userId, string password, string userName, bool isActive, string modifiedBy, string emailId, string mobileNo, bool isEmployee, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.UserName, userName);
            objParam[2] = new SqlParameter(Properties.Resources.PassWord, password);
            objParam[3] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.EmailID, emailId);
            objParam[6] = new SqlParameter(Properties.Resources.ContactNo, mobileNo);
            objParam[7] = new SqlParameter(Properties.Resources.IsEmployee, isEmployee);
            objParam[8] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);

            DataSet insertStatus = SqlHelper.ExecuteDataset("udp_InsertPlumbingEngineer", objParam);
            /*End of Code added by   for EMAIL ID and MOBILE NO*/
            return insertStatus;
        }

        /* End of Code added by  on 30-Aug-2011*/
        #endregion

        #region Function Related to Get All Users of Logged in users
        #region Function Related to Gets all the users of logged in Users[to get all users who are under admin,superadmin etc]
        /// <summary>
        /// Gets all the users of logged in Users[to get all users who are under admin,superadmin etc]
        /// </summary>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="user">The user.</param>
        /// <param name="superUser">The super user.</param>
        /// <param name="administrator">The administrator.</param>
        /// <returns>Dataset with all users</returns>
        public DataSet ChildUserGetAll(string modifiedBy, string user, string superUser, string administrator,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[1] = new SqlParameter(Properties.Resources.User, user);
            objParam[2] = new SqlParameter(Properties.Resources.SuperUser, superUser);
            objParam[3] = new SqlParameter(Properties.Resources.Administrator, administrator);
            objParam[4] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_UserOfLoggedInUser_GetAll", objParam);
            return ds;

        }
        #endregion
        #region Function Related to Get Users In DDLUSer ComboBox
        /// <summary>
        /// To Fill ddlUser ComboBox in UserDetail delete
        /// </summary>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userType">Type of the user.</param>
        /// <returns>dataset</returns>
        public DataSet ChildUsersGet(string modifiedBy, string userId, string userType)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[2] = new SqlParameter(Properties.Resources.UserType, userType);

            DataSet ds = SqlHelper.ExecuteDataset("udpMstUser_UserOfLoggedInUser_GetUsers", objParam);
            return ds;
        }
        #endregion
        #region Function Related to fill comboBox DdlUserType
        /// <summary>
        /// to fill comboBox DdlUserType
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="superUser">The super user.</param>
        /// <param name="administrator">The administrator.</param>
        /// <returns>DataSet</returns>
        public DataSet ChildUserTypeGet(string userId, string user, string superUser, string administrator)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.User, user);
            objParam[2] = new SqlParameter(Properties.Resources.SuperUser, superUser);
            objParam[3] = new SqlParameter(Properties.Resources.Administrator, administrator);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_UserOfLoggedInUser_GetUserType", objParam);
            return ds;
        }
        #endregion
        #region Function Related to Get Data In ddlTransfer UserId
        /// <summary>
        /// to Get Data In ddlTransfer UserId if user type is changed to lesser position
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userType">Type of the user.</param>
        /// <returns>dataset</returns>
        public DataSet ChildUserGetAll(string userId, string userType)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.IsAdmin, userType);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_UserOfLoggedInUser_GetNewUserID", objParam);
            return ds;
        }
        #endregion
        #region Function Related to Get Users Of SA
        /// <summary>
        /// get users of SA
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="superUser">The super user.</param>
        /// <param name="administrator">The administrator.</param>
        /// <returns>DataSet.</returns>
        public DataSet ChildUsersOfSuperAdminGetAll(string user, string superUser, string administrator, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.User, user);
            objParam[1] = new SqlParameter(Properties.Resources.SuperUser, superUser);
            objParam[2] = new SqlParameter(Properties.Resources.Administrator, administrator);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_UserOfLoggedInUserSA_GetAll", objParam);
            return ds;
        }
        #endregion
        #region Function Related To Update data before deleting User ID
        /// <summary>
        /// Childs the user update.
        /// </summary>
        /// <param name="htUpdateDate">The ht update date.</param>
        /// <returns>DataSet.</returns>
        /// <exception cref="System.ArgumentNullException">htUpdateDate</exception>
        public DataSet ChildUserUpdate(Hashtable htUpdateDate)
        {
            if (htUpdateDate == null)
            {
                throw new ArgumentNullException("htUpdateDate");
            }

            var ds = new DataSet {Locale = CultureInfo.InvariantCulture};
            SqlParameter[] objParam = new SqlParameter[2];
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                foreach (DictionaryEntry item in htUpdateDate)
                {
                    objParam[0] = new SqlParameter(Properties.Resources.ModifiedBy, item.Key.ToString());
                    objParam[1] = new SqlParameter(Properties.Resources.UserId, item.Value.ToString());

                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_UserOfLoggedInUser_Update", objParam);
                }
                tx.Complete();
            }

            return ds;
        }
        #endregion
        /// <summary>
        /// Users the delete.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserDelete(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);

            DataSet deleteStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_User_DeleteUser", objParam);
            return deleteStatus;
        }
        /// <summary>
        /// Users the profile update.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="userType">Type of the user.</param>
        /// <param name="userGroup">The user group.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="status">if set to <c>true</c> [status].</param>
        /// <returns>DataSet.</returns>
        public DataSet UserProfileUpdate(string userId, string userName, string userType, string userGroup, bool isActive, string modifiedBy, bool status)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.UserName, userName);
            objParam[2] = new SqlParameter(Properties.Resources.IsAdmin, userType);
            objParam[3] = new SqlParameter(Properties.Resources.UserGroup, userGroup);
            objParam[4] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[5] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[6] = new SqlParameter(Properties.Resources.Status, status);

            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_User_UpdateUser", objParam);

        }
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet ChangePassword(string userId, string password, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.PassWord, password);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet changePasswordStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_User_ChangePassword", objParam);
            return changePasswordStatus;
        }

        /// <summary>
        /// Checks the password resuse.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckPasswordResuse(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet changePasswordStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_User_CheckPasswordResue", objParam);
            return changePasswordStatus;
        }
        /// <summary>
        /// To Get The User Password
        /// </summary>
        /// <param name="userId">UserID of The User</param>
        /// <returns>DataSet.</returns>
        public DataSet UserPasswordGet(string userId)
        {
            var ds = new DataSet {Locale = CultureInfo.InvariantCulture};

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UserPassword_Get", objParam);

            const string strSqlQuery = "Select 4 as MessageID, 'MsgNotFound' as MessageString, 'Invalid Password' as comment";
            DataSet dsFail = SqlHelper.ExecuteDataset(CommandType.Text, strSqlQuery);
            dsFail.Tables[0].TableName = "PasswordFail";
            ds.Tables.Add(dsFail.Tables[0].Copy());
            return ds;
        }

        /// <summary>
        /// Ghange Password
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Data set with message only</returns>
        public DataSet ChangePassword(string userId, string newPassword, string oldPassword, string modifiedBy)
        {
            var ds = new DataSet {Locale = CultureInfo.InvariantCulture};

            SqlParameter[] objParam1 = new SqlParameter[3];
            objParam1[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam1[1] = new SqlParameter(Properties.Resources.PassWord, newPassword);
            objParam1[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstUser_User_ChangePassword", objParam1);
            return ds;
        }
        #endregion
        #endregion

        #region Function Related to User Location Rights
        /// <summary>
        /// To get the Location Rights for a user and for whome alloting the rights to user
        /// </summary>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>ds with CompanyCode, CompanyDesc, HRLocationCode, HRLocationDesc, LocationAutoID, LocationCode, LocationDesc, Right</returns>
        public DataSet UserLocationRightGet(string adminUserId, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AdminUserID, adminUserId);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);

            DataSet ds = SqlHelper.ExecuteDataset("udpMstUser_UserLocationRight_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Location Rights for Super Administrator to allote a user
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>ds with CompanyCode, CompanyDesc, HRLocationCode, HRLocationDesc, LocationAutoID, LocationCode, LocationDesc, Right</returns>
        public DataSet LocationRight4SuperAdminGet(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset("udp_LocationRight4SuperAdmin_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get the Location Rights for a user and for whome alloting the rights to user for Screen Rights Page
        /// </summary>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>ds with CompanyCode, CompanyDesc, HRLocationCode, HRLocationDesc, LocationAutoID, LocationCode, LocationDesc, Right</returns>
        public DataSet LocationRight4ScreenGet(string adminUserId, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AdminUserID, adminUserId);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);

            DataSet ds = SqlHelper.ExecuteDataset("udpMstUser_UserLocationRight4Screen_Get", objParam);
            return ds;
        }
        // Created : By  
        // Dated : 17-Feb-2012
        // Purpose : To get Menu Head Names order By Position No
        /// <summary>
        /// To get the Location Rights for Super Administrator for Screen Right page
        /// </summary>
        /// <returns>ds with CompanyCode, CompanyDesc, HRLocationCode, HRLocationDesc, LocationAutoID, LocationCode, LocationDesc, Right</returns>
        public DataSet LocationRight4SAScreenGet()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_LocationRight4SA4screen_Get");
            return ds;
        }
        /// <summary>
        /// to Add Delete and Update the User Locationm rights
        /// </summary>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="htLocationAutoId">The ht location automatic identifier.</param>
        /// <returns>DataSet</returns>
        /// <exception cref="System.ArgumentNullException">htLocationAutoId</exception>
        public DataSet LocationRightAdd(string modifiedBy, string userId, Hashtable htLocationAutoId)
        {
            if (htLocationAutoId == null)
            {
                throw new ArgumentNullException("htLocationAutoId");
            }

            var ds = new DataSet {Locale = CultureInfo.InvariantCulture};
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);

            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                foreach (DictionaryEntry item in htLocationAutoId)
                {
                    Guard.ArgumentConvertibleTo<int>(item.Key.ToString(), "myLongArgument");
                    Guard.ArgumentConvertibleTo<bool>(item.Value.ToString(), "myBoolArgument");
                    objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, int.Parse(item.Key.ToString()));
                    objParam[3] = new SqlParameter(Properties.Resources.IsChecked, bool.Parse(item.Value.ToString()));
                    ds = SqlHelper.ExecuteDataset("udpMstUser_UserLocationRight_Insert", objParam);
                }
                tx.Complete();
            }
            return ds;
        }
        #endregion

        #region Function Related to  User Site Rights
        public DataSet UserSiteRightGet(string adminUserId, string userId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AdminUserID, adminUserId);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);

            DataSet ds = SqlHelper.ExecuteDataset("udpUserSiteRightGet", objParam);
            return ds;
        }
        public DataSet SiteRight4SuperAdminGet(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset("udpSuperAdminSiteRightGet", objParam);
            return ds;
        }

        public DataSet SiteRightAdd(string modifiedBy, string userId, string locationAutoId, string clientCode, string asmtId, string isChecked)
        {
            var ds = new DataSet { Locale = CultureInfo.InvariantCulture };
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, int.Parse(locationAutoId));
            objParam[3] = new SqlParameter(Properties.Resources.ClientCode, clientCode);
            objParam[4] = new SqlParameter(Properties.Resources.AsmtId, asmtId);
            objParam[5] = new SqlParameter(Properties.Resources.IsChecked, bool.Parse(isChecked));
            ds = SqlHelper.ExecuteDataset("udpMstUserSiteRightInsert", objParam);
            return ds;
        }
        public DataSet SiteRightAdd(string modifiedBy, string userId, DataTable siteRights)
        {
            var ds = new DataSet { Locale = CultureInfo.InvariantCulture };
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);
            //objParam[2] = new SqlParameter("@SiteRights", siteRights);
            //SqlParameter param = new SqlParameter("@SiteRights", siteRights);
            //param.TypeName = "dbo.udtSiteRights";
            //param.UdtTypeName = "dbo.udtSiteRights";
            //param.SqlDbType = SqlDbType.Structured;
            //objParam[2] = param;
            //ds = SqlHelper.ExecuteDataset("udpMstUserSiteRightInsert", objParam);

            //using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            //{
                foreach (DataRow item in siteRights.Rows)
                {
                    objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, int.Parse(item[0].ToString()));
                    objParam[3] = new SqlParameter(Properties.Resources.ClientCode, item[1].ToString());
                    objParam[4] = new SqlParameter(Properties.Resources.AsmtId, item[2].ToString());
                    objParam[5] = new SqlParameter(Properties.Resources.IsChecked, bool.Parse(item[3].ToString()));
                    ds = SqlHelper.ExecuteDataset("udpMstUserSiteRightInsert", objParam);
                }
            //    tx.Complete();
            //}
            return ds;
        }
        #endregion Function Related to  User Site Rights

        #region Function Related to User Screen Rights
        /// <summary>
        /// To get the User screens Write for Usper Administrator
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <returns>dataSet with MenuHeadCode,MenuHeadName,MenuNodeAutoID,MenuNodeCode,MenuNodeName,LocationAutoID,UserLocationAccessAutoID,IsRead,IsWrite,IsModify,IsDelete</returns>
        public DataSet ScreenRightSuperAdminGet(string UGCode, string MenuHeadCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UGCode, UGCode);
            objParam[1] = new SqlParameter(Properties.Resources.MenuHeadCode, MenuHeadCode);

            DataSet ds = SqlHelper.ExecuteDataset("udpMstUser_UserScreenRight_4SA_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To get the User screens Write for User
        /// </summary>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <returns>dataSet with MenuHeadCode,MenuHeadName,MenuNodeAutoID,MenuNodeCode,MenuNodeName,LocationAutoID,UserLocationAccessAutoID,IsRead,IsWrite,IsModify,IsDelete</returns>
        public DataSet ScreenRightGet(string adminUserId, string userId, int locationAutoId, string menuHeadName)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AdminUserID, adminUserId);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(Properties.Resources.MenuHeadName, menuHeadName);

            DataSet ds = SqlHelper.ExecuteDataset("udpMstUser_UserScreenRight_Get", objParam);
            return ds;
        }
        /// <summary>
        /// To save edit and delete the User Screens Right
        /// </summary>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="table">The table.</param>
        /// <returns>DataSet</returns>
        /// <exception cref="System.ArgumentNullException">table</exception>
        public DataSet ScreenRightAdd(string modifiedBy, string ugCode, DataTable table)
        {
            if (table == null || table.Rows == null)
            {
                throw new ArgumentNullException("table");
            }

            var ds = new DataSet {Locale = CultureInfo.InvariantCulture};
            SqlParameter[] objParam = new SqlParameter[8];
            using (TransactionScope tx = TransactionUtility.CreateTransactionScope())
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    Guard.ArgumentConvertibleTo<int>(table.Rows[i][Properties.Resources.fldMenuNodeAutoId].ToString(), "myIntArgument");
                    Guard.ArgumentConvertibleTo<bool>(table.Rows[i][Properties.Resources.fldIsRead].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(table.Rows[i][Properties.Resources.fldIsWrite].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(table.Rows[i][Properties.Resources.fldIsModify].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(table.Rows[i][Properties.Resources.fldIsDelete].ToString(), "myBoolArgument");
                    Guard.ArgumentConvertibleTo<bool>(table.Rows[i][Properties.Resources.fldIsAuthorization].ToString(), "myBoolArgument");

                    objParam[0] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
                    objParam[1] = new SqlParameter(Properties.Resources.UGCode, ugCode);
                    objParam[2] = new SqlParameter(Properties.Resources.MenuNodeAutoID, Int64.Parse(table.Rows[i][Properties.Resources.fldMenuNodeAutoId].ToString()));
                    objParam[3] = new SqlParameter(Properties.Resources.IsRead, bool.Parse(table.Rows[i][Properties.Resources.fldIsRead].ToString()));
                    objParam[4] = new SqlParameter(Properties.Resources.IsWrite, bool.Parse(table.Rows[i][Properties.Resources.fldIsWrite].ToString()));
                    objParam[5] = new SqlParameter(Properties.Resources.IsModify, bool.Parse(table.Rows[i][Properties.Resources.fldIsModify].ToString()));
                    objParam[6] = new SqlParameter(Properties.Resources.IsDelete, bool.Parse(table.Rows[i][Properties.Resources.fldIsDelete].ToString()));
                    objParam[7] = new SqlParameter(Properties.Resources.IsAuthorization, bool.Parse(table.Rows[i][Properties.Resources.fldIsAuthorization].ToString()));


                    ds = SqlHelper.ExecuteDataset("udpMstUser_UserScreenRight_Insert", objParam);
                }
                tx.Complete();
            }
            return ds;
        }
        /// <summary>
        /// Function to get the Given Page rights of the user for Read or Write or Modify or Delete or Authorization any one at a time
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rwmda">The rwmda.</param>
        /// <returns>Read/Write/Modify/Delete/Authorization right</returns>
        public bool PageRightGet(string pageName, string userId, string rwmda)
        {
            bool blRight;

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.PageName, pageName);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);

            DataSet ds = SqlHelper.ExecuteDataset("udp_User_PageRight_Get", objParam);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                if (rwmda == "R")
                {
                    Guard.ArgumentConvertibleTo<bool>(ds.Tables[0].Rows[0][Properties.Resources.fldIsRead].ToString(), "myBoolArgument");
                    blRight = bool.Parse(ds.Tables[0].Rows[0][Properties.Resources.fldIsRead].ToString());
                }
                else if (rwmda == "W")
                {
                    Guard.ArgumentConvertibleTo<bool>(ds.Tables[0].Rows[0][Properties.Resources.fldIsWrite].ToString(), "myBoolArgument");
                    blRight = bool.Parse(ds.Tables[0].Rows[0][Properties.Resources.fldIsWrite].ToString());
                }
                else if (rwmda == "M")
                {
                    Guard.ArgumentConvertibleTo<bool>(ds.Tables[0].Rows[0][Properties.Resources.fldIsModify].ToString(), "myBoolArgument");
                    blRight = bool.Parse(ds.Tables[0].Rows[0][Properties.Resources.fldIsModify].ToString());
                }
                else if (rwmda == "D")
                {
                    Guard.ArgumentConvertibleTo<bool>(ds.Tables[0].Rows[0][Properties.Resources.fldIsDelete].ToString(), "myBoolArgument");
                    blRight = bool.Parse(ds.Tables[0].Rows[0][Properties.Resources.fldIsDelete].ToString());
                }
                else if (rwmda == "A")
                {
                    Guard.ArgumentConvertibleTo<bool>(ds.Tables[0].Rows[0][Properties.Resources.fldIsAuthorization].ToString(), "myBoolArgument");
                    blRight = bool.Parse(ds.Tables[0].Rows[0][Properties.Resources.fldIsAuthorization].ToString());
                }
                else { blRight = false; }
            }
            else
            {
                blRight = false;
            }
            return blRight;
        }

        /// <summary>
        /// Return rights of a page in Location of user
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="pageName">Name of the page.</param>
        /// <returns>DataTable.</returns>
        public DataTable DLPageRightGet(string locationAutoId, string userId, string pageName)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[2] = new SqlParameter(Properties.Resources.PageName, pageName);

            DataTable dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpMst_MenuAccess_Get", objParam);
            return dt;
        }

        #endregion

        /// <summary>
        /// Get Password security parameters
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Data set with record only</returns>
        public DataSet PasswordPolicyGet(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_PasswordPolicy_Get", objParam);
            return ds;
        }

        #region System Parameter
        /// <summary>
        /// Systems the parameter get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterGetAll()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SystemParameter_Get");
            return ds;
        }
        /// <summary>
        /// Systems the parameter add.
        /// </summary>
        /// <param name="paramCode">The parameter code.</param>
        /// <param name="paramDesc">The parameter desc.</param>
        /// <param name="paramImplementationLevel">The parameter implementation level.</param>
        /// <param name="paramType">Type of the parameter.</param>
        /// <param name="paramDataType">Type of the parameter data.</param>
        /// <param name="isEditable">The is editable.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="userLevelToDefinedValues">The user level to defined values.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterAdd(string paramCode, string paramDesc, string paramImplementationLevel, string paramType, string paramDataType, string isEditable, string isActive, string userLevelToDefinedValues, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.ParamCode, paramCode);
            objParam[1] = new SqlParameter(Properties.Resources.ParamDesc, paramDesc);
            objParam[2] = new SqlParameter(Properties.Resources.ParamImplementationLevel, paramImplementationLevel);
            objParam[3] = new SqlParameter(Properties.Resources.ParamType, paramType);
            objParam[4] = new SqlParameter(Properties.Resources.ParamDataType, paramDataType);
            objParam[5] = new SqlParameter(Properties.Resources.IsEditable, isEditable);
            objParam[6] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[7] = new SqlParameter(Properties.Resources.UserLevelToDefinedValues, userLevelToDefinedValues);
            objParam[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SystemParameter_Add", objParam);
            return ds;
        }
        /// <summary>
        /// Systems the parameter update.
        /// </summary>
        /// <param name="paramCode">The parameter code.</param>
        /// <param name="paramDesc">The parameter desc.</param>
        /// <param name="paramImplementationLevel">The parameter implementation level.</param>
        /// <param name="paramType">Type of the parameter.</param>
        /// <param name="paramDataType">Type of the parameter data.</param>
        /// <param name="isEditable">The is editable.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="userLevelToDefinedValues">The user level to defined values.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterUpdate(string paramCode, string paramDesc, string paramImplementationLevel, string paramType, string paramDataType, string isEditable, string isActive, string userLevelToDefinedValues, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.ParamCode, paramCode);
            objParam[1] = new SqlParameter(Properties.Resources.ParamDesc, paramDesc);
            objParam[2] = new SqlParameter(Properties.Resources.ParamImplementationLevel, paramImplementationLevel);
            objParam[3] = new SqlParameter(Properties.Resources.ParamType, paramType);
            objParam[4] = new SqlParameter(Properties.Resources.ParamDataType, paramDataType);
            objParam[5] = new SqlParameter(Properties.Resources.IsEditable, isEditable);
            objParam[6] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[7] = new SqlParameter(Properties.Resources.UserLevelToDefinedValues, userLevelToDefinedValues);
            objParam[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SystemParameter_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Systems the parameter delete.
        /// </summary>
        /// <param name="paramCode">The parameter code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterDelete(string paramCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.ParamCode, paramCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SystemParameter_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Systems the parameter values add.
        /// </summary>
        /// <param name="level1">The level1.</param>
        /// <param name="levelCode1">The level code1.</param>
        /// <param name="level2">The level2.</param>
        /// <param name="levelCode2">The level code2.</param>
        /// <param name="level3">The level3.</param>
        /// <param name="levelCode3">The level code3.</param>
        /// <param name="level4">The level4.</param>
        /// <param name="levelCode4">The level code4.</param>
        /// <param name="paramCode">The parameter code.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="paramValue1">The parameter value1.</param>
        /// <param name="paramValue2">The parameter value2.</param>
        /// <param name="paramValue3">The parameter value3.</param>
        /// <param name="paramValue4">The parameter value4.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterValuesAdd(
           string level1, string levelCode1,
           string level2, string levelCode2,
           string level3, string levelCode3,
           string level4, string levelCode4,
           string paramCode, string isActive,
           string paramValue1, string paramValue2, string paramValue3, string paramValue4,
           string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[15];

            objParam[0] = new SqlParameter(Properties.Resources.Level1, level1);
            objParam[1] = new SqlParameter(Properties.Resources.LevelCode1, levelCode1);
            objParam[2] = new SqlParameter(Properties.Resources.Level2, level2);
            objParam[3] = new SqlParameter(Properties.Resources.LevelCode2, levelCode2);
            objParam[4] = new SqlParameter(Properties.Resources.Level3, level3);
            objParam[5] = new SqlParameter(Properties.Resources.LevelCode3, levelCode3);
            objParam[6] = new SqlParameter(Properties.Resources.Level4, level4);
            objParam[7] = new SqlParameter(Properties.Resources.LevelCode4, levelCode4);
            objParam[8] = new SqlParameter(Properties.Resources.ParamCode, paramCode);
            objParam[9] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[10] = new SqlParameter(Properties.Resources.ParamValue1, paramValue1);
            objParam[11] = new SqlParameter(Properties.Resources.ParamValue2, paramValue2);
            objParam[12] = new SqlParameter(Properties.Resources.ParamValue3, paramValue3);
            objParam[13] = new SqlParameter(Properties.Resources.ParamValue4, paramValue4);
            objParam[14] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SystemParameterValues_Add", objParam);
            return ds;
        }
        /// <summary>
        /// Systems the parameter values update.
        /// </summary>
        /// <param name="paramValuesAutoId">The parameter values automatic identifier.</param>
        /// <param name="level1">The level1.</param>
        /// <param name="levelCode1">The level code1.</param>
        /// <param name="level2">The level2.</param>
        /// <param name="levelCode2">The level code2.</param>
        /// <param name="level3">The level3.</param>
        /// <param name="levelCode3">The level code3.</param>
        /// <param name="level4">The level4.</param>
        /// <param name="levelCode4">The level code4.</param>
        /// <param name="paramCode">The parameter code.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="paramValue1">The parameter value1.</param>
        /// <param name="paramValue2">The parameter value2.</param>
        /// <param name="paramValue3">The parameter value3.</param>
        /// <param name="paramValue4">The parameter value4.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterValuesUpdate(string paramValuesAutoId,
            string level1, string levelCode1,
            string level2, string levelCode2,
            string level3, string levelCode3,
            string level4, string levelCode4,
            string paramCode, string isActive,
            string paramValue1, string paramValue2, string paramValue3, string paramValue4,
            string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[16];
            objParam[0] = new SqlParameter(Properties.Resources.ParamValuesAutoId, paramValuesAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.Level1, level1);
            objParam[2] = new SqlParameter(Properties.Resources.LevelCode1, levelCode1);
            objParam[3] = new SqlParameter(Properties.Resources.Level2, level2);
            objParam[4] = new SqlParameter(Properties.Resources.LevelCode2, levelCode2);
            objParam[5] = new SqlParameter(Properties.Resources.Level3, level3);
            objParam[6] = new SqlParameter(Properties.Resources.LevelCode3, levelCode3);
            objParam[7] = new SqlParameter(Properties.Resources.Level4, level4);
            objParam[8] = new SqlParameter(Properties.Resources.LevelCode4, levelCode4);
            objParam[9] = new SqlParameter(Properties.Resources.ParamCode, paramCode);
            objParam[10] = new SqlParameter(Properties.Resources.IsActive, isActive);
            objParam[11] = new SqlParameter(Properties.Resources.ParamValue1, paramValue1);
            objParam[12] = new SqlParameter(Properties.Resources.ParamValue2, paramValue2);
            objParam[13] = new SqlParameter(Properties.Resources.ParamValue3, paramValue3);
            objParam[14] = new SqlParameter(Properties.Resources.ParamValue4, paramValue4);
            objParam[15] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SystemParameterValues_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Systems the parameter values get all.
        /// </summary>
        /// <param name="paramCode">The parameter code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterValuesGetAll(string paramCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.ParamCode, paramCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SystemParameterValues_Get", objParam);
            return ds;
        }
        /// <summary>
        /// Systems the parameter values delete.
        /// </summary>
        /// <param name="paramValuesAutoId">The parameter values automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterValuesDelete(string paramValuesAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.ParamValuesAutoId, paramValuesAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_SystemParameterValues_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Systems the parameter values get.
        /// </summary>
        /// <param name="paramCode">The parameter code.</param>
        /// <param name="level">The level.</param>
        /// <param name="levelCode">The level code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterValuesGet(string paramCode, string level, string levelCode)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.ParamCode, paramCode);
            objParam[1] = new SqlParameter(Properties.Resources.Level1, level);
            objParam[2] = new SqlParameter(Properties.Resources.LevelCode1, levelCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstSystemParameter_Get", objParam);
            return ds;

        }

        /// <summary>
        /// Systems the parameter values get based on Location.
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="paramCode">The parameter code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterValuesByCompany(int locationAutoId, string paramCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.ParamCode, paramCode);
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetSystemParameterValueByCompany", objParam);
        }
        #endregion System Parameter

        #region User-Authorized Hours Mapping
        /// <summary>
        /// To Get All Authorized Hours Mapping of A User ID
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursMappingGetAll(string userId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UserAuthorizedHoursMapping_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To Get All Authorized Hours Mapping of Company
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursGetAll(string companyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, companyCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMst_AuthorizedHours_GetAll", objParam);
            return ds;
        }
        /// <summary>
        /// To add  Authorized Hours of User in Table
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="authorizedHours">The authorized hours.</param>
        /// <param name="hoursPerWeek">The hours per week.</param>
        /// <param name="hoursPerMonth">The hours per month.</param>
        /// <param name="daysInWeek">The days in week.</param>
        /// <param name="gapBetTwoShifts">The gap bet two shifts.</param>
        /// <param name="restAfterTotalHoursInAWeek">The rest after total hours in a week.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursMappingAdd(string userId, string authorizedHours, string hoursPerWeek, string hoursPerMonth, string daysInWeek, string gapBetTwoShifts, string restAfterTotalHoursInAWeek, string attendanceType, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];

            Guard.ArgumentConvertibleTo<int>(hoursPerWeek, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(hoursPerMonth, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(daysInWeek, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(gapBetTwoShifts, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(restAfterTotalHoursInAWeek, "myIntArgument");

            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.AuthorizedHours, authorizedHours);
            objParam[2] = new SqlParameter(Properties.Resources.HoursPerWeek, int.Parse(hoursPerWeek));
            objParam[3] = new SqlParameter(Properties.Resources.HoursPerMonth, int.Parse(hoursPerMonth));
            objParam[4] = new SqlParameter(Properties.Resources.NumDaysInWeek, int.Parse(daysInWeek));
            objParam[5] = new SqlParameter(Properties.Resources.GapBetTwoShifts, int.Parse(gapBetTwoShifts));
            objParam[6] = new SqlParameter(Properties.Resources.RestAfterTotalHoursInAWeek, int.Parse(restAfterTotalHoursInAWeek));
            objParam[7] = new SqlParameter(Properties.Resources.AttendanceType, attendanceType);
            objParam[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_UserAuthorizedHoursMapping_Insert", objParam);
            return addStatus;
        }
        /// <summary>
        /// To Update the existing record of User ID in Authorized Hours Mapping
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="authorizedHours">The authorized hours.</param>
        /// <param name="hoursPerWeek">The hours per week.</param>
        /// <param name="hoursPerMonth">The hours per month.</param>
        /// <param name="daysInWeek">The days in week.</param>
        /// <param name="gapBetTwoShifts">The gap bet two shifts.</param>
        /// <param name="restAfterTotalHoursInAWeek">The rest after total hours in a week.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Data Set</returns>
        public DataSet AuthorizedHoursMappingUpdate(string userId, string authorizedHours, string hoursPerWeek, string hoursPerMonth, string daysInWeek, string gapBetTwoShifts, string restAfterTotalHoursInAWeek, string attendanceType, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[9];

            Guard.ArgumentConvertibleTo<int>(hoursPerWeek, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(hoursPerMonth, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(daysInWeek, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(gapBetTwoShifts, "myIntArgument");
            Guard.ArgumentConvertibleTo<int>(restAfterTotalHoursInAWeek, "myIntArgument");

            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.AuthorizedHours, authorizedHours);
            objParam[2] = new SqlParameter(Properties.Resources.HoursPerWeek, int.Parse(hoursPerWeek));
            objParam[3] = new SqlParameter(Properties.Resources.HoursPerMonth, int.Parse(hoursPerMonth));
            objParam[4] = new SqlParameter(Properties.Resources.NumDaysInWeek, int.Parse(daysInWeek));
            objParam[5] = new SqlParameter(Properties.Resources.GapBetTwoShifts, int.Parse(gapBetTwoShifts));
            objParam[6] = new SqlParameter(Properties.Resources.RestAfterTotalHoursInAWeek, int.Parse(restAfterTotalHoursInAWeek));
            objParam[7] = new SqlParameter(Properties.Resources.AttendanceType, attendanceType);
            objParam[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);

            DataSet updateStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMst_UserAuthorizedHoursMapping_Update", objParam);
            ////updateStatus = SqlHelper.ExecuteDataset("udpMst_UserAuthorizedHoursMapping_Update", CreateSQLParametersList(CreateSQLParameterArray(strSQLUserID, strSQLModifiedBy), objParam));
            return updateStatus;
        }
        /// <summary>
        /// To Delete entry of User From Authorized Hours
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>Data Set</returns>
        public DataSet AuthorizedHoursMappingDelete(string userId, string attendanceType)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.AttendanceType, attendanceType);

            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMst_UserAuthorizedHoursMapping_Delete", objParam);
            return deleteStatus;
        }
        /// <summary>
        /// Get Element Types Used in Processed Rota Report of Australia
        /// </summary>
        /// <param name="locationAutoID">The location automatic identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet getelementtrantype(string locationAutoID, string fromDate, string toDate)
        {
            SqlParameter[] objParm = new SqlParameter[3];

            objParm[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            objParm[1] = new SqlParameter(Properties.Resources.FromDate, fromDate);
            objParm[2] = new SqlParameter(Properties.Resources.ToDate, toDate);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_gettrnasactiontype_all_Aus", objParm);
            return ds;
        }

        /// <summary>
        /// To Get Authorized User Name
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="baseUserId">The base user identifier.</param>
        /// <returns>Data Set</returns>
        public DataSet AuthorizedHoursUserNameGet(string userId, string baseUserId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.BaseUserID, baseUserId);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UserAuthorizedHours_GetUserName", objParam);
            return ds;
        }

        #endregion

        /// <summary>
        /// To Update EmployeeNumber reference in user Record.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <returns>DataTable.</returns>
        public DataTable EmployeeNumberReferenceInUserDetailUpdate(string userId, string employeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.UserId, userId);
            objParam[1] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);

            DataTable dt = SqlHelper.ExecuteDatatable(CommandType.StoredProcedure, "udpUser_EmployeeNumber_Update", objParam);
            return dt;
        }

        #region Temp Functions
        /// <summary>
        /// Resets all passwords with new encription.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet ResetAllPasswordsWithNewEncription()
        {
            return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "GetAllUserAndPasswords");
        }
        #endregion Temp Functions

        #region Function Related to Caping Rules

        /// <summary>
        /// Gets the capping header.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet GetCappingHeader()
        {
            DataSet ds = SqlHelper.ExecuteDataset("udpUser_CapingHeader_GetAll");
            return ds;
        }

        /// <summary>
        /// Gets the capping header users.
        /// </summary>
        /// <param name="cappingLevel">The capping level.</param>
        /// <param name="cappingCode">The capping code.</param>
        /// <param name="operationType">Type of the operation.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetCappingHeaderUsers(string cappingLevel, string cappingCode, string operationType)
        {
            var objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.CappingLevel, cappingLevel);
            objParam[1] = new SqlParameter(Properties.Resources.CappingCode, cappingCode);
            objParam[2] = new SqlParameter(Properties.Resources.OperationType, operationType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_CapingHeader_GetCappingLevelAll", objParam);
            return ds;
        }

        /// <summary>
        /// Cappings the header insert.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <param name="cappingDescription">The capping description.</param>
        /// <param name="cappingLevel">The capping level.</param>
        /// <param name="cappingLevelDesc">The capping level desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CappingHeaderInsert(string cappingCode, string cappingDescription, string cappingLevel, string cappingLevelDesc, string modifiedBy)
        {
            var objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.CappingCode, cappingCode);
            objParam[1] = new SqlParameter(Properties.Resources.CappingDescription, cappingDescription);
            objParam[2] = new SqlParameter(Properties.Resources.CappingLevel, cappingLevel);
            objParam[3] = new SqlParameter(Properties.Resources.CappingLevelDesc, cappingLevelDesc);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_CapingHeader_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Cappings the header update.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <param name="cappingDescription">The capping description.</param>
        /// <param name="cappingLevel">The capping level.</param>
        /// <param name="cappingLevelDesc">The capping level desc.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet CappingHeaderUpdate(string cappingCode, string cappingDescription, string cappingLevel, string cappingLevelDesc, string modifiedBy)
        {
            var objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.CappingCode, cappingCode);
            objParam[1] = new SqlParameter(Properties.Resources.CappingDescription, cappingDescription);
            objParam[2] = new SqlParameter(Properties.Resources.CappingLevel, cappingLevel);
            objParam[3] = new SqlParameter(Properties.Resources.CappingLevelDesc, cappingLevelDesc);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_CapingHeader_Update", objParam);
            return ds;
        }

        /// <summary>
        /// Cappings the header delete.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CappingHeaderDelete(string cappingCode)
        {
            var objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CappingCode, cappingCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_CapingHeader_Delete", objParam);
            return ds;
        }

        /// <summary>
        /// Gets the capping details.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetCappingDetails(string cappingCode)
        {
            var objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CappingCode, cappingCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_CappingDetail_GetAll", objParam);
            return ds;
        }

        /// <summary>
        /// Cappings the detail insert.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <param name="contractDays">The contract days.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="maxNumberOfHoursPerDay">The max number of hours per day.</param>
        /// <param name="breakBetweenShift">The break between shift.</param>
        /// <param name="maxWorkingDaysInWeek">The max working days in week.</param>
        /// <param name="maxNightShiftInWeek">The max night shift in week.</param>
        /// <param name="maxWeekHours">The max week hours.</param>
        /// <param name="weeklyRest">The weekly rest.</param>
        /// <param name="maxHoursInShift">The maximum hours in shift.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="profitabilityCheck">The profitability check.</param>
        /// <returns>DataSet.</returns>
        public DataSet CappingDetailInsert(string cappingCode, string contractDays, string attendanceType, string maxNumberOfHoursPerDay, string breakBetweenShift, string maxWorkingDaysInWeek, string maxNightShiftInWeek, string maxWeekHours, string weeklyRest, string maxHoursInShift, string modifiedBy, string profitabilityCheck)
        {
            var objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(Properties.Resources.CappingCode, cappingCode);
            objParam[1] = new SqlParameter(Properties.Resources.ContractDays, contractDays);
            objParam[2] = new SqlParameter(Properties.Resources.AttendanceType, attendanceType);
            objParam[3] = new SqlParameter(Properties.Resources.MaxNumberOfHoursPerDay, maxNumberOfHoursPerDay);
            objParam[4] = new SqlParameter(Properties.Resources.BreakBetweenShift, breakBetweenShift);
            objParam[5] = new SqlParameter(Properties.Resources.MaxWorkingDaysInWeek, maxWorkingDaysInWeek);
            objParam[6] = new SqlParameter(Properties.Resources.MaxNightShiftInWeek, maxNightShiftInWeek);
            objParam[7] = new SqlParameter(Properties.Resources.MaxWeekHours, maxWeekHours);
            objParam[8] = new SqlParameter(Properties.Resources.WeeklyRest, weeklyRest);
            objParam[9] = new SqlParameter(Properties.Resources.MaxHoursInShift, maxHoursInShift);
            objParam[10] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[11] = new SqlParameter(Properties.Resources.ProfitabilityCheck, profitabilityCheck);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_CappingDetail_Insert", objParam);
            return ds;
        }

        /// <summary>
        /// Cappings the detail update.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <param name="contractDays">The contract days.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="maxNumberOfHoursPerDay">The max number of hours per day.</param>
        /// <param name="breakBetweenShift">The break between shift.</param>
        /// <param name="maxWorkingDaysInWeek">The max working days in week.</param>
        /// <param name="maxNightShiftInWeek">The max night shift in week.</param>
        /// <param name="maxWeekHours">The max week hours.</param>
        /// <param name="weeklyRest">The weekly rest.</param>
        /// <param name="maxHoursInShift">The maximum hours in shift.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="profitabilityCheck">The profitability check.</param>
        /// <returns>DataSet.</returns>
        public DataSet CappingDetailUpdate(string cappingCode, string contractDays, string attendanceType, string maxNumberOfHoursPerDay, string breakBetweenShift, string maxWorkingDaysInWeek, string maxNightShiftInWeek, string maxWeekHours, string weeklyRest, string maxHoursInShift, string modifiedBy, string profitabilityCheck)
        {
            var objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(Properties.Resources.CappingCode, cappingCode);
            objParam[1] = new SqlParameter(Properties.Resources.ContractDays, contractDays);
            objParam[2] = new SqlParameter(Properties.Resources.AttendanceType, attendanceType);
            objParam[3] = new SqlParameter(Properties.Resources.MaxNumberOfHoursPerDay, maxNumberOfHoursPerDay);
            objParam[4] = new SqlParameter(Properties.Resources.BreakBetweenShift, breakBetweenShift);
            objParam[5] = new SqlParameter(Properties.Resources.MaxWorkingDaysInWeek, maxWorkingDaysInWeek);
            objParam[6] = new SqlParameter(Properties.Resources.MaxNightShiftInWeek, maxNightShiftInWeek);
            objParam[7] = new SqlParameter(Properties.Resources.MaxWeekHours, maxWeekHours);
            objParam[8] = new SqlParameter(Properties.Resources.WeeklyRest, weeklyRest);
            objParam[9] = new SqlParameter(Properties.Resources.MaxHoursInShift, maxHoursInShift);
            objParam[10] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[11] = new SqlParameter(Properties.Resources.ProfitabilityCheck, profitabilityCheck);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_CappingDetail_Update", objParam);
            return ds;
        }
        /// <summary>
        /// Cappings the detail delete.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <param name="contractDays">The contract days.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet CappingDetailDelete(string cappingCode, string contractDays, string attendanceType)
        {
            var objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.CappingCode, cappingCode);
            objParam[1] = new SqlParameter(Properties.Resources.ContractDays, contractDays);
            objParam[2] = new SqlParameter(Properties.Resources.AttendanceType, attendanceType);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpUser_CappingDetail_Delete", objParam);
            return ds;
        }
        #endregion
    }
}

