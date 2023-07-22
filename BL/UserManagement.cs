// ***********************************************************************
// Assembly         : BL
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
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using DL;
using System.Globalization;
using System.Collections.Generic;

/// <summary>
/// The BL namespace.
/// </summary>
namespace BL
{
    /// <summary>
    /// Class UserManagement.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class UserManagement
    {
        #region global variables
        /// <summary>
        /// The super admin identifier
        /// </summary>
        private string superAdminId;
        /// <summary>
        /// The super admin password
        /// </summary>
        private string superAdminPassword;
        /// <summary>
        /// The is super admin
        /// </summary>
        private string isSuperAdmin;
        /// <summary>
        /// The culture code
        /// </summary>
        private string cultureCode;
        /// <summary>
        /// The number of licenses
        /// </summary>
        private int numberOfLicenses;
        #endregion

        #region Function Related to User Management

        #region Function Related To get Hard Coded Values
        /// <summary>
        /// To Get Default Culture of Application
        /// </summary>
        /// <returns>String Culture Code</returns>
        public string CultureGet()
        {
            // cultureCode = "hi-IN";
            cultureCode = "en-us";
            return cultureCode;
        }
        /// <summary>
        /// To Get Super Admin ID of Application
        /// Modify by  2-Aug-2013 private to public
        /// To access same function in different class
        /// </summary>
        /// <returns>System.String.</returns>
        public string SuperAdminIdGet()
        {
            superAdminId = BL.Properties.Resources.SuperAdminId;
            return superAdminId;
        }
        /// <summary>
        /// To Get Password of Super Admin
        /// Reading Encrypted password from Web config
        /// </summary>
        /// <returns>System.String.</returns>
        private string SuperAdminPasswordGet()
        {
            superAdminPassword = System.Configuration.ConfigurationSettings.AppSettings[BL.Properties.Resources.saPwd];
            return superAdminPassword;
        }
        /// <summary>
        /// To Check Super Admin isAdmin property
        /// </summary>
        /// <returns>System.String.</returns>
        private string IsSuperAdmin()
        {
            //The Value "SA" will never be changed
            isSuperAdmin = BL.Properties.Resources.AdminType;
            return isSuperAdmin;
        }
        /// <summary>
        /// To Get the Max no of Licenses allowed
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int NumberOfLicensesGet()
        {
            numberOfLicenses = 999;
            return numberOfLicenses;
        }
        /// <summary>
        /// To get the Web config XML into Data Set Format
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>return Dataset of the XML File for which path is provided</returns>
        public DataSet WebConfigXmlGet(string path)
        {
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            ds.ReadXml(path + "/App_Data/Webconfig.xml");
            return ds;
        }
        #endregion

        #region Function Related to Login
        /// <summary>
        /// Disables the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet DisableUser(string userId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            var dsCurrentLoginDetails = new DataSet();
            dsCurrentLoginDetails = objdlUserManagement.DisableUser(userId);
            return dsCurrentLoginDetails;
        }
        /// <summary>
        /// Checks the last login details.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckLastLoginDetails(string userId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            var dsCurrentLoginDetails = new DataSet();
            dsCurrentLoginDetails = objdlUserManagement.CheckLastLoginDetails(userId);
            return dsCurrentLoginDetails;
        }
        /// <summary>
        /// Inserts the password policy credentials.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns>DataSet.</returns>
        public DataSet InsertPasswordPolicyCredentials(string userid)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            var dsCurrentLoginDetails = new DataSet();
            dsCurrentLoginDetails = objdlUserManagement.InsertPasswordPolicyCredentials(userid);
            return dsCurrentLoginDetails;
        
        }
        /// <summary>
        /// Inserts the current login details.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="sessionID">The session identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet InsertCurrentLoginDetails(string userId, string sessionID)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            var dsCurrentLoginDetails = new DataSet();
            dsCurrentLoginDetails= objdlUserManagement.InsertCurrentLoginDetails(userId, sessionID);
            return dsCurrentLoginDetails;
        }
        /// <summary>
        /// To get the Loged in User Information
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        /// <param name="key">The key.</param>
        /// <returns>Dataset with UserID, UserName, UserType</returns>
        public DataSet UserDetailGet(string userId, string password, string key)
        {
            DL.Algorithm objAlgo = new Algorithm();
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            BL.UserManagement objblUserManagement = new BL.UserManagement();
            BL.Common objCommon = new BL.Common();

            string strEncodedPassword;
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            //************** New encription using bcryipt
            bool PasswordMatchStatus = false;
            //Decrypting the Encrypted  password and chech the condition.
            if (userId != SuperAdminIdGet() && password != objAlgo.Decryption(key, SuperAdminPasswordGet()))
            {
                if (NumberOfLicensesGet() >= ActiveUsersGet())
                {
                    strEncodedPassword = string.Empty; // objblUserManagement.EncryptPassword(userId + password, true, key);
                    ds = objdlUserManagement.UserDetailGet(userId, strEncodedPassword);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 &&
                            !ds.Tables[0].TableName.Trim().ToUpper().Equals("LOGINFAIL"))
                    {
                        PasswordMatchStatus = DoesPasswordMatch(ds.Tables[0].Rows[0]["Password"].ToString(), userId + password, true, key);
                        if (PasswordMatchStatus == false)
                        {
                            ds.Tables[0].Rows.Clear();
                        }
                        //After Login update the login attempt status in DB
                        objdlUserManagement.UserLoginDetailsUpdate(userId, PasswordMatchStatus);
                        var ds1 = new DataSet();
                        ds1=objdlUserManagement.CheckPasswordUnsuccessfulAttempt(userId);
                        if (ds1.Tables[0].Rows[0]["UnSuccessful_Attempt"].ToString() == "3")
                        {
                            ds1.Tables[0].Rows.Clear();
                            ds1.Tables[0].Clear();
                            ds1.Tables.Remove("Table");
                            var errorTable = new DataTable { Locale = CultureInfo.InvariantCulture, TableName = "LoginFail" };
                            errorTable.Columns.Add(new DataColumn(Properties.Resources.fldMessageId, typeof(int)));
                            errorTable.Columns.Add(new DataColumn(Properties.Resources.fldMessageString, typeof(string)));
                            DataRow myDataRow = errorTable.NewRow();
                            myDataRow[Properties.Resources.fldMessageId] = 2;
                            myDataRow[Properties.Resources.fldMessageString] = Properties.Resources.AccountLock;
                            errorTable.Rows.Add(myDataRow);
                            ds1.Tables.Add(errorTable);
                            return ds1;
                        }
                    }
                }
                else
                {
                    ds.Tables.Add(objCommon.CreateErrorMessage(BL.Properties.Resources.ErrorTable, "50", BL.Properties.Resources.ErrMsgExceedLicense, string.Empty));
                }
            }
            else if (userId == SuperAdminIdGet() && password == objAlgo.Decryption(key, SuperAdminPasswordGet()))
            {
                ds = objdlUserManagement.SuperAdminInfoGet(userId);
            }
            return ds;

            // Decrypting the Encrypted  password and chech the condition.
            //if (userId != SuperAdminIdGet() || password != objAlgo.Decryption(key, SuperAdminPasswordGet()))
            //{
            //    if (NumberOfLicensesGet() >= ActiveUsersGet())
            //    {
            //        strEncodedPassword = objblUserManagement.EncryptPassword(userId + password, true, key);
            //        ds = objdlUserManagement.UserDetailGet(userId, strEncodedPassword);
            //    }
            //    else
            //    {
            //        ds.Tables.Add(objCommon.CreateErrorMessage(BL.Properties.Resources.ErrorTable, "50", BL.Properties.Resources.ErrMsgExceedLicense, string.Empty));
            //    }
            //}
            //else if (userId == SuperAdminIdGet() && password == objAlgo.Decryption(key, SuperAdminPasswordGet()))
            //{
            //    ds = objdlUserManagement.SuperAdminInfoGet(userId);
            //}
            //return ds;
        }
        /// <summary>
        /// To get the UserName and UserType by UserID
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with UserName, UserType</returns>
        public DataSet UserNameAndTypeGet(string userId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.UserNameAndTypeGet(userId);
            return ds;
        }
        /// <summary>
        /// To get the Number of Active Users in Database
        /// </summary>
        /// <returns>integer value number of Users</returns>
        private int ActiveUsersGet()
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            int activeUsers;
            DataSet ds = objdlUserManagement.NoOfActiveUserGet();

            DL.Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][BL.Properties.Resources.fldNoOfActiveUsers].ToString(), "myIntArgument");
            activeUsers = int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldNoOfActiveUsers].ToString());
            return activeUsers;
        }
        /// <summary>
        /// To get the Number of Total Users in Database
        /// </summary>
        /// <returns>integer value number of Users</returns>
        private int TotalUserGet()
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            int totalUsers;
            DataSet ds = objdlUserManagement.TotalUserGet();

            DL.Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][BL.Properties.Resources.fldNoOfTotalUsers].ToString(), "myIntArgument");
            totalUsers = int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldNoOfTotalUsers].ToString());
            return totalUsers;
        }
        /// <summary>
        /// Users the get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet UserGetAll()
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.UserGetAll();
            return ds;
        }
        #endregion

        #region Function Realted to Get Companies for user

        /// <summary>
        /// To get the Companies for User
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with CompanyCode, companyDesc</returns>
        public DataSet UserCompanyAccessGet(string userId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (userId != SuperAdminIdGet())
            {
                ds = objdlUserManagement.UserCompanyAccessGet(userId);
            }
            else
            {
                ds = objdlUserManagement.SuperAdminCompanyAccessGet();
            }
            return ds;
        }

        #endregion

        #region Function Realted to Get HrLocations for user

        /// <summary>
        /// To get the HrLocations for Loged in User have access
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with HrLocationAutoID, HrLocationCode, CompanyCode and HrLocationDesc</returns>
        public DataSet UserHRLocationAccessGet(string userId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (userId != SuperAdminIdGet())
            {
                ds = objdlUserManagement.UserHRLocationAccessGet(userId);
            }
            else
            {
                ds = objdlUserManagement.SuperAdminHRLocationAccessGet();
            }
            return ds;
        }

        /// <summary>
        /// To get the HrLocations for (Selected CompanyCode and Loged in User have access)
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns>Dataset with HrLocationCode and HrLocationDesc</returns>
        public DataSet UserHRLocationAccessGet(string userId, string companyCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (userId != SuperAdminIdGet())
            {
                ds = objdlUserManagement.UserHRLocationAccessGet(userId, companyCode);
            }
            else
            {
                ds = objdlUserManagement.SuperAdminHRLocationAccessGet(companyCode);
            }
            return ds;
        }

        #endregion

        #region Function Realted to Get Locations for user

        /// <summary>
        /// To get the Locations for Loged in User have access
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Dataset with LocationAutoId, LocationCode, CompanyCode, HrLocationCode and LocationDesc</returns>
        public DataSet UserLocationAccessGet(string userId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (userId != SuperAdminIdGet())
            {
                ds = objdlUserManagement.UserLocationAccessGet(userId);
            }
            else
            {
                ds = objdlUserManagement.SuperAdminLocationAccessGet();
            }
            return ds;
        }

        /// <summary>
        /// To get the Locations for (Selected CompanyCode, HrLocationCode and Loged in User have access)
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="hrLocationCode">The hr location code.</param>
        /// <returns>Dataset with LocationAutoId, LocationCode and LocationDesc</returns>
        public DataSet UserLocationAccessGet(string userId, string companyCode, string hrLocationCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (userId != SuperAdminIdGet())
            {
                ds = objdlUserManagement.UserLocationAccessGet(userId, companyCode, hrLocationCode);
            }
            else
            {
                ds = objdlUserManagement.SuperAdminLocationAccessGet(companyCode, hrLocationCode);
            }
            return ds;
        }
        /// <summary>
        /// getting Location Description Based on Location AutoID
        /// </summary>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetLoggedInLocation(string locationAutoId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            return objdlUserManagement.GetLoggedInLocation(locationAutoId);
        }
        #endregion

        #region Functions Related to Menus
        /// <summary>
        /// Users the menu get.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="treeViewCodeNo">The tree view code no.</param>
        /// <returns>DataSet.</returns>
        public DataSet UserMenuGet(string userId, string locationAutoId, int treeViewCodeNo)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet objMenuDataSet = new DataSet();
            objMenuDataSet.Locale = CultureInfo.InvariantCulture;
            if (userId != SuperAdminIdGet())
            {
                objMenuDataSet = objdlUserManagement.UserMenuGet(userId, locationAutoId, treeViewCodeNo);
            }
            else
            {
                objMenuDataSet = objdlUserManagement.SuperAdministratorMenuGet(treeViewCodeNo);
            }
            objMenuDataSet.Relations.Add("Parent", objMenuDataSet.Tables[0].Columns[BL.Properties.Resources.fldMenuHeadCode], objMenuDataSet.Tables[0].Columns[BL.Properties.Resources.fldParentMenuHeadCode]);
            objMenuDataSet.Relations.Add("Children", objMenuDataSet.Tables[0].Columns[BL.Properties.Resources.fldMenuHeadCode], objMenuDataSet.Tables[1].Columns[BL.Properties.Resources.fldMenuHeadCode]);
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
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuNodeGetAll(menuHeadAutoId, menuNodeAutoId);
            return ds;
        }
        /// <summary>
        /// Supers the admin level2 get.
        /// </summary>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <returns>DataSet.</returns>
        public DataSet SuperAdminLevel2Get(string UGCode, string MenuHeadCode)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.SuperAdminLevel2Get(UGCode, MenuHeadCode);
            return ds;
        }
        /// <summary>
        /// Menus the type get.
        /// </summary>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <returns>DataSet.</returns>
        public DataSet MenuTypeGet(string menuHeadCode)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.MenuTypeGet(menuHeadCode);
            return ds;
        }

        /// <summary>
        /// to get the MenuHeads
        /// </summary>
        /// <returns>Data set with MenuHeadCode MenuHeadName PositionNo Isactive</returns>
        public DataSet MenuHeadGetAll()
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuHeadGetAll();
            return ds;
        }
        /// <summary>
        /// To get The MenuHeadAutoId, MenuHeadCode and MenuHeadName Except the MenuHeadCode Given in the Parameter List
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <returns>To get The MenuHeadAutoId, MenuHeadCode and MenuHeadName Except the MenuHeadCode Given in the Parameter List</returns>
        public DataSet MenuHeadCodeGetAll(string menuHeadCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuHeadCodeGetAll(menuHeadCode);
            return ds;
        }
        /// <summary>
        /// To get The MenuHeadAutoId, MenuHeadCode and MenuHeadName Except the MenuHeadAutoId Given in the Parameter List
        /// </summary>
        /// <param name="menuHeadAutoId">The menu head automatic identifier.</param>
        /// <returns>To get The MenuHeadAutoId, MenuHeadCode and MenuHeadName Except the MenuHeadAutoId Given in the Parameter List</returns>
        public DataSet MenuHeadAutoIdGetAll(string menuHeadAutoId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuHeadAutoIdGetAll(menuHeadAutoId);
            return ds;
        }
        /// <summary>
        /// to get the MenuNodes
        /// </summary>
        /// <returns>Data set with MenuNodeAutoID MenuHeadCode MenuNodeCode MenuNodeName PageName PositionNo Isactive</returns>
        public DataSet MenuNodeGetAll()
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuNodeGetAll();
            return ds;
        }
        /// <summary>
        /// to get the MenuNodes
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <returns>Data set with MenuNodeAutoID MenuHeadCode MenuNodeCode MenuNodeName PageName PositionNo Isactive</returns>
        public DataSet MenuNodeGet(string menuHeadCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuNodeGet(menuHeadCode);
            return ds;
        }
        /// <summary>
        /// To get the Menu Heads Code and Description
        /// </summary>
        /// <returns>DataSet with MenuHeadCode and MenuHeadName</returns>
        public DataSet MenuHeadCodeDescGetAll()
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuHeadCodeDescGetAll();
            return ds;
        }
        /// <summary>
        /// To save the Menu heads
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <param name="positionNumber">The position number.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="parentMenuHeadAutoId">The parent menu head automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuHeadAdd(string menuHeadCode, string menuHeadName, int positionNumber, string isActive, string parentMenuHeadAutoId, string modifiedBy)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuHeadAdd(menuHeadCode, menuHeadName, positionNumber, isActive, parentMenuHeadAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update the Menu head
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <param name="positionNumber">The position number.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="parentMenuHeadAutoId">The parent menu head automatic identifier.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuHeadUpdate(string menuHeadCode, string menuHeadName, int positionNumber, string isActive, string parentMenuHeadAutoId, string modifiedBy)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuHeadUpdate(menuHeadCode, menuHeadName, positionNumber, isActive, parentMenuHeadAutoId, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Delete the Menu head
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuHeadDelete(string menuHeadCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuHeadDelete(menuHeadCode);
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
        /// <param name="positionNumber">The position number.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet MenuNodeAdd(string menuHeadCode, string menuNodeCode, string menuNodeName, string pageName, int dependOn, int positionNumber, string isActive, string modifiedBy)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuNodeAdd(menuHeadCode, menuNodeCode, menuNodeName, pageName, dependOn, positionNumber, isActive, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Update the Menu Nodes
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuNodeCode">The menu node code.</param>
        /// <param name="menuNodeName">Name of the menu node.</param>
        /// <param name="pageName">Name of the page.</param>
        /// <param name="dependOn">The depend on.</param>
        /// <param name="positionNumber">The position number.</param>
        /// <param name="isActive">The is active.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuNodeUpdate(string menuHeadCode, string menuNodeCode, string menuNodeName, string pageName, int dependOn, int positionNumber, string isActive, string modifiedBy)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuNodeUpdate(menuHeadCode, menuNodeCode, menuNodeName, pageName, dependOn, positionNumber, isActive, modifiedBy);
            return ds;
        }
        /// <summary>
        /// To Delete the Menu Nodes
        /// </summary>
        /// <param name="menuHeadCode">The menu head code.</param>
        /// <param name="menuNodeCode">The menu node code.</param>
        /// <returns>Data set with message</returns>
        public DataSet MenuNodeDelete(string menuHeadCode, string menuNodeCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.MenuNodeDelete(menuHeadCode, menuNodeCode);
            return ds;
        }
        #endregion

        #region Function Related to Users Creation

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
        /// <param name="mobileNo">The mobile no.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="userGroup">The user group.</param>
        /// <param name="isEmployee">if set to <c>true</c> [is employee].</param>
        /// <param name="employeeNumber">The employee number.</param>
        /// <param name="key">The key.</param>
        /// <returns>Data Set</returns>
        public DataSet UserAdd(string userId, string password, string userName, string userType, bool isActive, string modifiedBy, string emailId, string mobileNo, string locationAutoId, string userGroup, bool isEmployee, string employeeNumber, string key)
        {
            if ((isActive == true && NumberOfLicensesGet() > ActiveUsersGet()) || isActive == false)
            {
                DataSet AddStatus = new DataSet();
                AddStatus.Locale = CultureInfo.InvariantCulture;

                if (userId == SuperAdminIdGet())
                {
                    BL.Common objblCommon = new Common();
                    AddStatus.Tables.Add(objblCommon.CreateErrorMessage(BL.Properties.Resources.MsgTable, "51", BL.Properties.Resources.UserIdNotAvailable, BL.Properties.Resources.UserIdNotAvailable));
                    return AddStatus;
                }

                string strEncodedPassword;
                BL.UserManagement objblUserManagement = new BL.UserManagement();
                strEncodedPassword = objblUserManagement.EncryptPassword(userId + password, true, key);

                DL.UserManagement objdlUserManagement = new DL.UserManagement();
                /*Code added by   for EMAIL ID and MOBILE NO*/
                AddStatus = objdlUserManagement.UserAdd(userId, strEncodedPassword, userName, userType, isActive, modifiedBy, emailId, mobileNo, locationAutoId, userGroup, isEmployee, employeeNumber);
                /*End of Code added by   for EMAIL ID and MOBILE NO*/
                return AddStatus;
            }
            else
            {
                BL.Common objblCommon = new Common();
                DataSet AddStatus = new DataSet();
                AddStatus.Locale = CultureInfo.InvariantCulture;

                AddStatus.Tables.Add(objblCommon.CreateErrorMessage(BL.Properties.Resources.MsgTable, "50", BL.Properties.Resources.ExceedThenLicanceLimit, BL.Properties.Resources.ExceedThenLicanceLimit));
                return AddStatus;
            }
        }
       
        /*End of Code added by  */
        /*Code added by Mayank for Registering Employee for Insta Service Portal*/
        public DataSet UserAddEngineer(string userId, string password, string userName, bool isActive, string modifiedBy, string emailId, string mobileNo, bool isEmployee, string employeeNumber, string key)
        {

            DataSet AddStatus = new DataSet();
            AddStatus.Locale = CultureInfo.InvariantCulture;
            string strEncodedPassword;
            BL.UserManagement objblUserManagement = new BL.UserManagement();
            strEncodedPassword = objblUserManagement.EncryptPassword(userId + password, true, key);
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            AddStatus = objdlUserManagement.UserAddEngineer(userId, strEncodedPassword, userName, isActive, modifiedBy, emailId, mobileNo, isEmployee, employeeNumber);
            return AddStatus;

        }

        #region Function Related to Get All Users of Logged in users

        /// <summary>
        /// Childs the user get all.
        /// </summary>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="isAdmin">The is admin.</param>
        /// <param name="user">The user.</param>
        /// <param name="superUser">The super user.</param>
        /// <param name="administrator">The administrator.</param>
        /// <returns>DataSet.</returns>
        public DataSet ChildUserGetAll(string modifiedBy, string isAdmin, string user, string superUser, string administrator,string CompanyCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (isAdmin == BL.Properties.Resources.AdminType)
            {
                ds = objdlUserManagement.ChildUsersOfSuperAdminGetAll(user, superUser, administrator, CompanyCode);
            }
            else
            {
                ds = objdlUserManagement.ChildUserGetAll(modifiedBy, user, superUser, administrator, CompanyCode);
            }
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
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.ChildUsersGet(modifiedBy, userId, userType);
            return ds;
        }
        #endregion
        #region Function Related to fill comboBox ddlUserType
        /// <summary>
        /// to fill comboBox ddlUserType
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="user">The user.</param>
        /// <param name="superUser">The super user.</param>
        /// <param name="administrator">The administrator.</param>
        /// <returns>DataSet</returns>
        public DataSet ChildUserTypeGet(string userId, string user, string superUser, string administrator)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.ChildUserTypeGet(userId, user, superUser, administrator);
            return ds;
        }
        #endregion
        #region Function Related to Get Data In ddlTransfer UserId
        /// <summary>
        /// to Get Data In ddlTransfer UserId if user type is changed to lesser position
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="userType">Type of the user.</param>
        /// <returns>DataSet.</returns>
        public DataSet ChildUserGetAll(string userId, string userType)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.ChildUserGetAll(userId, userType);
            return ds;
        }
        #endregion
        #region Function Related To Update data before deleting User ID
        /// <summary>
        /// Childs the user update.
        /// </summary>
        /// <param name="tableUpdateDate">The table update date.</param>
        /// <returns>DataSet.</returns>
        public DataSet ChildUserUpdate(Hashtable tableUpdateDate)
        {
            DL.UserManagement objuserManagement = new DL.UserManagement();
            DataSet ds = objuserManagement.ChildUserUpdate(tableUpdateDate);
            return ds;
        }
        #endregion
        #region Function Related TO Delete data
        /// <summary>
        /// To Delete a User
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet message string</returns>
        public DataSet UserDelete(string userId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet deleteStatus = objdlUserManagement.UserDelete(userId);
            return deleteStatus;
        }
        #endregion
        #region Function Related To Update Data
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
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet updateStatus = objdlUserManagement.UserProfileUpdate(userId, userName, userType, userGroup, isActive, modifiedBy, status);
            return updateStatus;
        }
        #endregion
        #region Function Related to Change Password
        /// <summary>
        /// To Change Password Of the User
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="key">The key.</param>
        /// <returns>change Password Status</returns>
        public DataSet ChangePassword(string userId, string password, string modifiedBy, string companyCode, string key)
        {
            BL.UserManagement objblUserManagement = new BL.UserManagement();
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet changePasswordStatus = new DataSet();
            changePasswordStatus.Locale = CultureInfo.InvariantCulture;

            changePasswordStatus = CheckPasswordExpression(companyCode, password);
            if (changePasswordStatus != null && changePasswordStatus.Tables.Count > 0 && changePasswordStatus.Tables[0].Rows.Count > 0)
            {
                return changePasswordStatus;
            }

            string Encryptedpassword = objblUserManagement.EncryptPassword(userId + password, true, key);
            DataSet dsCheckPassword = new DataSet();
            dsCheckPassword = objdlUserManagement.CheckPasswordResuse(userId);
            if (dsCheckPassword != null && dsCheckPassword.Tables.Count > 0 && dsCheckPassword.Tables[0].Rows.Count > 0)
            {

                DataTable dtCheckPassword = dsCheckPassword.Tables[0];
                foreach (DataRow row in dsCheckPassword.Tables[0].Rows)
                {
                    bool dsPasswordMatch;
                    dsPasswordMatch = objblUserManagement.DoesPasswordMatch(row["OldPassword"].ToString(), userId + password, true, key);
                    if (dsPasswordMatch)
                    {
                        var dsPasswordNotSet = new DataSet();
                        return dsPasswordNotSet;
                    } 
                } 
            }
            changePasswordStatus = objdlUserManagement.ChangePassword(userId, Encryptedpassword, modifiedBy);
            return changePasswordStatus;
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="newPassword">The new password.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="modifier">The modifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="key">The key.</param>
        /// <returns>data set as message</returns>
        public DataSet ChangePassword(string userId, string newPassword, string oldPassword, string modifier, string companyCode, string key)
        {   
            string encodedNewPassword;
            BL.UserManagement objblUserManagement = new BL.UserManagement();
            DL.UserManagement objDlUserManagement = new DL.UserManagement();

            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            ds = CheckPasswordExpression(companyCode, newPassword);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            encodedNewPassword = objblUserManagement.EncryptPassword(userId + newPassword, true, key);
            DataSet dsCheckPassword = new DataSet();
            dsCheckPassword = objDlUserManagement.CheckPasswordResuse(userId);
            if (dsCheckPassword != null && dsCheckPassword.Tables.Count > 0 && dsCheckPassword.Tables[0].Rows.Count > 0)
            {
                DataTable dtCheckPassword = dsCheckPassword.Tables[0];
                foreach (DataRow row in dsCheckPassword.Tables[0].Rows)
                 {
                    bool dsPasswordMatch;
                    dsPasswordMatch = objblUserManagement.DoesPasswordMatch(row["OldPassword"].ToString(), userId+newPassword, true, key);
                    if (dsPasswordMatch)
                    {
                        var dsPasswordNotSet = new DataSet();
                        return dsPasswordNotSet;
                    }
                }
            }
            DataSet userPwd = objDlUserManagement.UserPasswordGet(userId);
            bool passwordMatch = false;
            if (userPwd != null && userPwd.Tables.Count > 0 && userPwd.Tables[0].Rows.Count > 0)
            {
                passwordMatch = DoesPasswordMatch(userPwd.Tables[0].Rows[0][0].ToString(), userId + oldPassword, true, key);
            }
            if (passwordMatch)
            {
                ds = objDlUserManagement.ChangePassword(userId, encodedNewPassword, modifier);
                return ds;
            }
            else
            {
                DataSet ds1 = new  DataSet();
                ds1.Tables.Add(userPwd.Tables["PasswordFail"].Copy());
                return ds1;
            }
        }

        /// <summary>
        /// Checks the password resuse.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckPasswordResuse(string userId)
        {
            DataSet ds = new DataSet();
            DL.UserManagement objDlUserManagement = new DL.UserManagement();
            ds = objDlUserManagement.CheckPasswordResuse(userId);
            return ds;
        }

        #endregion
        #endregion

        #region Function Related To EnCrypt/Decrypt password
        #region MD5
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string EncryptPasswordByMd5(string toEncrypt, bool useHashing, string key)
        {
            //public string EncryptPassword(string toEncrypt, bool useHashing, string key)
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            //    System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();
            // Get the key from config file
            //(string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="password">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string DecryptPassword(string password, bool useHashing, string key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(password);

            //   System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            //string key = "Syed Moshiur Murshed"; //(string)settingsReader.GetValue("SecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion MD5

        #region BCrypt
        /// <summary>
        /// Encrypt a string using Bcrypt encryption method. Return a encrypted Text EncryptPasswordByBCrypt
        /// </summary>
        /// <param name="toEncrypt">To encrypt.</param>
        /// <param name="useGivenSalt">if set to <c>true</c> [use given salt].</param>
        /// <param name="Key">The key.</param>
        /// <returns>System.String.</returns>
        public string EncryptPassword(string toEncrypt, bool useGivenSalt, string Key)
        {
            //public string EncryptPasswordByBCrypt(string toEncrypt, bool useGivenSalt, string Key)
            //string pwdToHash = toEncrypt + "^Y8~JJ"; // ^Y8~JJ is my hard-coded salt
            //return BCrypt.HashPassword(pwdToHash, BCrypt.GenerateSalt());
            string pwdToHash = string.Empty;
            if (useGivenSalt)
            {
                pwdToHash = toEncrypt + Key;
            }
            else
            {
                pwdToHash = toEncrypt + Properties.Resources.DefaultSalt;
            }
            return BCrypt.HashPassword(pwdToHash, BCrypt.GenerateSalt());
        }
        /// <summary>
        /// To compare the Stored Password with the Entered Password
        /// </summary>
        /// <param name="hashedPwdFromDatabase">The hashed password from database.</param>
        /// <param name="userEnteredPassword">The user entered password.</param>
        /// <param name="useGivenSalt">if set to <c>true</c> [use given salt].</param>
        /// <param name="Key">The key.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DoesPasswordMatch(string hashedPwdFromDatabase, string userEnteredPassword, bool useGivenSalt, string Key)
        {
            if (useGivenSalt)
            {
                return BCrypt.CheckPassword(userEnteredPassword + Key, hashedPwdFromDatabase);
            }
            else
            {
                return BCrypt.CheckPassword(userEnteredPassword + Properties.Resources.DefaultSalt, hashedPwdFromDatabase);
            }
        }
        #endregion BCrypt

        #region Temp Functions

        /// <summary>
        /// Resets all passwords with new encription.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String.</returns>
        public string ResetAllPasswordsWithNewEncription(string key)
        {
            DL.UserManagement objUser = new DL.UserManagement();
            DataSet ds = objUser.ResetAllPasswordsWithNewEncription();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int userRecords = 0; userRecords < ds.Tables[0].Rows.Count; userRecords++)
                {
                    string userId = ds.Tables[0].Rows[userRecords]["UserID"].ToString();
                    string oldEncriptedPassword = ds.Tables[0].Rows[userRecords]["Password"].ToString();
                    string modifiedBy = ds.Tables[0].Rows[userRecords]["ModifiedBy"].ToString();

                    BL.UserManagement objblUserManagement = new BL.UserManagement();
                    DL.UserManagement objdlUserManagement = new DL.UserManagement();
                    DataSet changePasswordStatus = new DataSet();
                    changePasswordStatus.Locale = CultureInfo.InvariantCulture;

                    string oldPassword = objblUserManagement.DecryptPassword(oldEncriptedPassword, true, key);

                    string newPassword = objblUserManagement.EncryptPassword(oldPassword, true, key);
                    changePasswordStatus = objdlUserManagement.ChangePassword(userId, newPassword, modifiedBy);
                }
            }
            return "sucessfully Complete";
        }
        #endregion Temp Functions

        #endregion
        #region Function Related to User Location Rights
        /// <summary>
        /// To get the Location Rights
        /// </summary>
        /// <param name="adminUserId">The admin user identifier.</param>
        /// <param name="isAdmin">The is admin.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>ds with CompanyCode, CompanyDesc, HrLocationCode, HrLocationDesc, LocationAutoID, LocationCode, LocationDesc, Right</returns>
        public DataSet UserLocationRightGet(string adminUserId, string isAdmin, string userId)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            if (isAdmin == BL.Properties.Resources.AdminType)
            {
                ds = objUserManagement.LocationRight4SuperAdminGet(userId);
            }
            else
            {
                ds = objUserManagement.UserLocationRightGet(adminUserId, userId);
            }
            return ds;
        }

        /// <summary>
        /// To get the Location Rights for Screens Rights page
        /// </summary>
        /// <param name="isAdmin">The is admin.</param>
        /// <returns>ds with CompanyCode, CompanyDesc, HrLocationCode, HrLocationDesc, LocationAutoID, LocationCode, LocationDesc, Right</returns>
        public DataSet LocationAccessRightGet(string isAdmin)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;

            if (isAdmin == BL.Properties.Resources.AdminType)
            {
                ds = objUserManagement.LocationRight4SAScreenGet();
            }
            else
            {
                //                ds = objUserManagement.User_LocationRight4screen_Get(adminUserId, userId);
                ds = objUserManagement.LocationRight4SAScreenGet();
            }
            return ds;
        }

        /// <summary>
        /// To add update and Delete the user location Rights
        /// </summary>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tableLocationAutoId">The table location automatic identifier.</param>
        /// <returns>DataSet</returns>
        public DataSet LocationRightAdd(string modifiedBy, string userId, Hashtable tableLocationAutoId)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.LocationRightAdd(modifiedBy, userId, tableLocationAutoId);
            return ds;
        }
        #endregion

        #region Function Related to  User Site Rights
        public DataSet UserSiteRightGet(string adminUserId, string isAdmin, string userId)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            if (isAdmin == BL.Properties.Resources.AdminType)
            {
                ds = objUserManagement.SiteRight4SuperAdminGet(userId);
            }
            else
            {
                ds = objUserManagement.UserSiteRightGet(adminUserId, userId);
            }
            return ds;
        }

        public DataSet SiteRightAdd(string modifiedBy, string userId, string locationAutoId, string clientCode, string asmtId, string isChecked)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.SiteRightAdd(modifiedBy, userId, locationAutoId, clientCode, asmtId, isChecked);
            return ds;
        }
        public DataSet SiteRightAdd(string modifiedBy, string userId, DataTable siteRights)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.SiteRightAdd(modifiedBy, userId, siteRights);
            return ds;
        }
        #endregion Function Related to  User Site Rights

        #region Function Related to User Screen Rights
        /// <summary>
        /// To get the user Screen Rights in both cases whether loged in by user or SuperAdmin
        /// </summary>
        /// <param name="isAdmin">The is admin.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="locationAutoId">The location automatic identifier.</param>
        /// <param name="menuHeadName">Name of the menu head.</param>
        /// <returns>dataSet with MenuHeadCode,MenuHeadName,MenuNodeAutoID,MenuNodeCode,MenuNodeName,LocationAutoID,UserLocationAccessAutoID,IsRead,IsWrite,IsModify,IsDelete,IsReadDisabled,IsWriteDisabled,IsModifyDisabled,IsDeleteDisabled</returns>
        public DataSet FunctionalityAccessRightGet(string UGCode, string MenuHeadCode)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            //if (isAdmin == BL.Properties.Resources.AdminType)
            //{
                ds = objUserManagement.ScreenRightSuperAdminGet(UGCode, MenuHeadCode);
            //}
            //else
            //{
            //    ds = objUserManagement.ScreenRightSuperAdminGet(userId, locationAutoId, menuHeadName);
            //}
            return ds;
        }
        /// <summary>
        /// To add Update and delete the User screens rights
        /// </summary>
        /// <param name="modifiedBy">The modified by.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="table">The table.</param>
        /// <returns>DataSet</returns>
        public DataSet FunctionalityAccessRightAdd(string modifiedBy, string ugCode, DataTable table)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.ScreenRightAdd(modifiedBy, ugCode, table);
            return ds;
        }
        /// <summary>
        /// Function to get the Given Page rights of the user for Read or Write or Modify or Delete or Authorization any one at a time
        /// </summary>
        /// <param name="pageName">Name of the page.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rwmda">The rwmda.</param>
        /// <returns>Read/Write/Modify/Delete/Authorization rights</returns>
        public bool PageAccessRightGet(string pageName, string userId, string rwmda)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            bool accessRight;
            accessRight = objUserManagement.PageRightGet(pageName, userId, rwmda);
            return accessRight;
        }
        #endregion
        #endregion

        #region System Parameter
        /// <summary>
        /// Systems the parameter get all.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterGetAll()
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterGetAll();
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
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterAdd(paramCode, paramDesc, paramImplementationLevel, paramType, paramDataType, isEditable, isActive, userLevelToDefinedValues, modifiedBy);
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
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterUpdate(paramCode, paramDesc, paramImplementationLevel, paramType, paramDataType, isEditable, isActive, userLevelToDefinedValues, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Systems the parameter delete.
        /// </summary>
        /// <param name="paramCode">The parameter code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterDelete(string paramCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterDelete(paramCode);
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
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterValuesAdd(
           level1, levelCode1,
           level2, levelCode2,
           level3, levelCode3,
           level4, levelCode4,
           paramCode, isActive,
           paramValue1, paramValue2, paramValue3, paramValue4,
           modifiedBy);
            return ds;
        }
        /// <summary>
        /// Systems the parameter values update.
        /// </summary>
        /// <param name="paramValueAutoId">The parameter value automatic identifier.</param>
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
        public DataSet SystemParameterValuesUpdate(string paramValueAutoId,
            string level1, string levelCode1,
            string level2, string levelCode2,
            string level3, string levelCode3,
            string level4, string levelCode4,
            string paramCode, string isActive,
            string paramValue1, string paramValue2, string paramValue3, string paramValue4,
            string modifiedBy)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterValuesUpdate(paramValueAutoId,
           level1, levelCode1,
           level2, levelCode2,
           level3, levelCode3,
           level4, levelCode4,
           paramCode, isActive,
           paramValue1, paramValue2, paramValue3, paramValue4,
           modifiedBy);
            return ds;
        }

        /// <summary>
        /// Systems the parameter values get all.
        /// </summary>
        /// <param name="paramCode">The parameter code.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterValuesGetAll(string paramCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterValuesGetAll(paramCode);
            return ds;
        }
        /// <summary>
        /// Systems the parameter values delete.
        /// </summary>
        /// <param name="paramValueAutoId">The parameter value automatic identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet SystemParameterValuesDelete(string paramValueAutoId)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterValuesDelete(paramValueAutoId);
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
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterValuesGet(paramCode, level, levelCode);
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
            var objdlUserManagement = new DL.UserManagement();
            return objdlUserManagement.SystemParameterValuesByCompany(locationAutoId, paramCode);
        }
        #endregion System Parameter

        #region Function related to password expression
        /// <summary>
        /// To Check Password Policy
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <param name="password">The password.</param>
        /// <returns>DataSet.</returns>
        public DataSet CheckPasswordExpression(string companyCode, string password)
        {
            DL.UserManagement objDlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            ds = objDlUserManagement.PasswordPolicyGet(companyCode);
            DataSet ds1 = new DataSet();
            ds1.Locale = CultureInfo.InvariantCulture;

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                DL.Guard.ArgumentConvertibleTo<int>(ds.Tables[0].Rows[0][BL.Properties.Resources.fldPasswordMinLen].ToString(), "myIntArgument");

                if (password.Length < int.Parse(ds.Tables[0].Rows[0][BL.Properties.Resources.fldPasswordMinLen].ToString()))
                {
                    DataTable dt = new DataTable();
                    dt.Locale = CultureInfo.InvariantCulture;
                    dt.Columns.Add(new DataColumn(BL.Properties.Resources.fldMessageId, typeof(int)));
                    dt.Columns.Add(new DataColumn(BL.Properties.Resources.fldMessageString, typeof(string)));

                    DataRow myDataRow = dt.NewRow();
                    myDataRow[BL.Properties.Resources.fldMessageId] = 2;
                    myDataRow[BL.Properties.Resources.fldMessageString] = "PasswordIsTooShort";
                    dt.Rows.Add(myDataRow);
                    dt.TableName = "PasswordFail";
                    ds1.Tables.Add(dt);
                    return ds1;
                }

                Regex regex = new Regex(ds.Tables[0].Rows[0][BL.Properties.Resources.fldRegularExpression].ToString());
                Match m = regex.Match(password);
                if (m.Success == false)
                {
                    DataTable dt = new DataTable();
                    dt.Locale = CultureInfo.InvariantCulture;

                    dt.Columns.Add(new DataColumn(BL.Properties.Resources.fldMessageId, typeof(int)));
                    dt.Columns.Add(new DataColumn(BL.Properties.Resources.fldMessageString, typeof(string)));

                    DataRow myDataRow = dt.NewRow();
                    myDataRow[BL.Properties.Resources.fldMessageId] = 2;
                    myDataRow[BL.Properties.Resources.fldMessageString] = "PasswordExpressionDoesNotMatchWithSecurityParameters";
                    dt.Rows.Add(myDataRow);
                    dt.TableName = "PasswordFail";
                    ds1.Tables.Add(dt);
                    return ds1;
                }

            }
            return ds1;
        }
        #endregion

        #region User-Authorized Hours Mapping
        /// <summary>
        /// Authorizeds the hours mapping get all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursMappingGetAll(string userId)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.AuthorizedHoursMappingGetAll(userId);
            return ds;
        }
        /// <summary>
        /// Authorizeds the hours get all.
        /// </summary>
        /// <param name="companyCode">The company code.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursGetAll(string companyCode)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = objdlUserManagement.AuthorizedHoursGetAll(companyCode);
            return ds;
        }
        /// <summary>
        /// Authorizeds the hours mapping add.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="authorizedHours">The authorized hours.</param>
        /// <param name="newHoursPerWeek">The new hours per week.</param>
        /// <param name="newHoursPerMonth">The new hours per month.</param>
        /// <param name="newDaysInWeek">The new days in week.</param>
        /// <param name="newGapBetweenTwoShifts">The new gap between two shifts.</param>
        /// <param name="newRestAfterTotalHoursInWeek">The new rest after total hours in week.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursMappingAdd(string userId, string authorizedHours, string newHoursPerWeek, string newHoursPerMonth, string newDaysInWeek, string newGapBetweenTwoShifts, string newRestAfterTotalHoursInWeek, string attendanceType, string modifiedBy)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet addStatus = objdlUserManagement.AuthorizedHoursMappingAdd(userId, authorizedHours, newHoursPerWeek, newHoursPerMonth, newDaysInWeek, newGapBetweenTwoShifts, newRestAfterTotalHoursInWeek, attendanceType, modifiedBy);
            return addStatus;
        }
        /// <summary>
        /// Authorizeds the hours mapping update.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="authorizedHours">The authorized hours.</param>
        /// <param name="editHoursPerWeek">The edit hours per week.</param>
        /// <param name="editHoursPerMonth">The edit hours per month.</param>
        /// <param name="editDaysInWeek">The edit days in week.</param>
        /// <param name="editGapBetweenTwoShifts">The edit gap between two shifts.</param>
        /// <param name="editRestAfterTotalHoursInWeek">The edit rest after total hours in week.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <param name="modifiedBy">The modified by.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursMappingUpdate(string userId, string authorizedHours, string editHoursPerWeek, string editHoursPerMonth, string editDaysInWeek, string editGapBetweenTwoShifts, string editRestAfterTotalHoursInWeek, string attendanceType, string modifiedBy)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet updateStatus = objdlUserManagement.AuthorizedHoursMappingUpdate(userId, authorizedHours, editHoursPerWeek, editHoursPerMonth, editDaysInWeek, editGapBetweenTwoShifts, editRestAfterTotalHoursInWeek, attendanceType, modifiedBy);
            return updateStatus;
        }
        /// <summary>
        /// Authorizeds the hours mapping delete.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="attendanceType">Type of the attendance.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursMappingDelete(string userId, string attendanceType)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet deleteStatus = objdlUserManagement.AuthorizedHoursMappingDelete(userId, attendanceType);
            return deleteStatus;
        }
        /// <summary>
        /// Get Element Types Used in Processed Rota Report of Australia
        /// </summary>
        /// <param name="LocationAutoID">The location automatic identifier.</param>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <returns>DataSet.</returns>
        public DataSet getelementtrantype(string LocationAutoID, string FromDate, string ToDate)
        {
            DL.UserManagement objdlUserManagement = new DL.UserManagement();
            DataSet ds = new DataSet();
            ds = objdlUserManagement.getelementtrantype(LocationAutoID, FromDate, ToDate);
            return ds;
        }

        /// <summary>
        /// Authorizeds the hours user name get.
        /// </summary>
        /// <param name="userId">The STR user ID.</param>
        /// <param name="baseUserId">The STR base user ID.</param>
        /// <returns>DataSet.</returns>
        public DataSet AuthorizedHoursUserNameGet(string userId, string baseUserId)
        {
            DL.UserManagement objUserManagement = new DL.UserManagement();
            DataSet ds = objUserManagement.AuthorizedHoursUserNameGet(userId, baseUserId);
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
            DL.UserManagement objUser = new DL.UserManagement();
            DataTable dt = objUser.EmployeeNumberReferenceInUserDetailUpdate(userId, employeeNumber);
            return dt;
        }

        #region Function Related to Caping Rules

        /// <summary>
        /// Gets the capping header.
        /// </summary>
        /// <returns>DataSet.</returns>
        public DataSet GetCappingHeader()
        {
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.GetCappingHeader();
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
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.GetCappingHeaderUsers(cappingLevel, cappingCode, operationType);
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
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.CappingHeaderInsert(cappingCode, cappingDescription, cappingLevel, cappingLevelDesc, modifiedBy);
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
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.CappingHeaderUpdate(cappingCode, cappingDescription, cappingLevel, cappingLevelDesc, modifiedBy);
            return ds;
        }
        /// <summary>
        /// Cappings the header delete.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <returns>DataSet.</returns>
        public DataSet CappingHeaderDelete(string cappingCode)
        {
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.CappingHeaderDelete(cappingCode);
            return ds;
        }


        /// <summary>
        /// Gets the capping details.
        /// </summary>
        /// <param name="cappingCode">The capping code.</param>
        /// <returns>DataSet.</returns>
        public DataSet GetCappingDetails(string cappingCode)
        {
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.GetCappingDetails(cappingCode);
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
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.CappingDetailInsert(cappingCode, contractDays, attendanceType, maxNumberOfHoursPerDay, breakBetweenShift, maxWorkingDaysInWeek, maxNightShiftInWeek, maxWeekHours, weeklyRest, maxHoursInShift, modifiedBy, profitabilityCheck);
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
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.CappingDetailUpdate(cappingCode, contractDays, attendanceType, maxNumberOfHoursPerDay, breakBetweenShift, maxWorkingDaysInWeek, maxNightShiftInWeek, maxWeekHours, weeklyRest, maxHoursInShift, modifiedBy, profitabilityCheck);
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
            var objUser = new DL.UserManagement();
            DataSet ds = objUser.CappingDetailDelete(cappingCode, contractDays, attendanceType);
            return ds;
        }
        #endregion
    }
}
