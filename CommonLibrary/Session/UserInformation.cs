// ***********************************************************************
// Assembly         : CommonLibrary
// Author           : Administrator
// Created          : 04-27-2015
//
// Last Modified By : Administrator
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="UserInformation.cs" company="Microsoft">
//     Copyright © Microsoft 2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;

/// <summary>
/// The Session namespace.
/// </summary>
namespace CommonLibrary.Session
{
    /// <summary>
    /// Class UserInformation.
    /// </summary>
   [Serializable]
   public class UserInformation
    {
        /// <summary>
        /// The session name
        /// </summary>
        private const string SessionName = "UserInformation";
        /// <summary>
        /// The login user identifier
        /// </summary>
        private string loginUserId;
        /// <summary>
        /// The login user name
        /// </summary>
        private string loginUserName;
        /// <summary>
        /// The login user role
        /// </summary>
        private string loginUserRole;
        /// <summary>
        /// The login user mobile no
        /// </summary>
        private string loginUserMobileNo;
        /// <summary>
        /// The login user email identifier
        /// </summary>
        private string loginUserEmailId;
        /// <summary>
        /// The login user employee number
        /// </summary>
        private string loginUserEmployeeNumber;
        /// <summary>
        /// The login user is area incharge
        /// </summary>
        private string loginUserIsAreaIncharge;
        /// <summary>
        /// The login user ip
        /// </summary>
        private string loginUserIp;
        /// <summary>
        /// The login date time
        /// </summary>
        private DateTime loginDateTime;
        /// <summary>
        /// The login country code
        /// </summary>
        private string loginCountryCode;
        /// <summary>
        /// The login country name
        /// </summary>
        private string loginCountryName;
        /// <summary>
        /// The login language code
        /// </summary>
        private string loginLanguageCode;
        /// <summary>
        /// The login language name
        /// </summary>
        private string loginLanguageName;
        /// <summary>
        /// The login database name
        /// </summary>
        private string loginDatabaseName;

        /// <summary>
        /// Checks the existing.
        /// </summary>
        private void CheckExisting()
        {
            if (HttpContext.Current.Session[SessionName] == null)
            {
                //Save this instance to the session
                HttpContext.Current.Session[SessionName] = this;
                UserId = string.Empty;
                loginUserName = string.Empty;
                UserRole = string.Empty;
                UserMobileNo = string.Empty;
                UserEmailId = string.Empty;
                EmployeeNumber = string.Empty;
                IsAreaIncharge = string.Empty;
                UserIp = string.Empty;
                CurrentLoginDateTime = DateTime.Now;
                CountryCode = string.Empty;
                CountryName = string.Empty;
                LanguageCode = string.Empty;
                LanguageName = string.Empty;
                DatabaseName = string.Empty;
            }
            else
            {
                //Initialize our object based on existing session
                var uInfo = (UserInformation)HttpContext.Current.Session[SessionName];
                this.UserId = uInfo.UserId;
                this.loginUserName = uInfo.loginUserName;
                this.UserRole = uInfo.UserRole;
                this.UserMobileNo = uInfo.UserMobileNo;
                this.UserEmailId = uInfo.UserEmailId;
                this.EmployeeNumber = uInfo.EmployeeNumber;
                this.IsAreaIncharge = uInfo.IsAreaIncharge;
                this.UserIp = uInfo.UserIp;
                this.CurrentLoginDateTime = uInfo.CurrentLoginDateTime;
                this.CountryCode = uInfo.CountryCode;
                this.CountryName = uInfo.CountryName;
                this.LanguageCode = uInfo.LanguageCode;
                this.LanguageName = uInfo.LanguageName;
                this.DatabaseName = uInfo.DatabaseName;
                uInfo = null;
            }
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            //Save our object to the session
            HttpContext.Current.Session[SessionName] = this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInformation"/> class.
        /// </summary>
        public UserInformation()
        {
            //userId = string.Empty;
            //loginUserName = string.Empty;
            //userRole = string.Empty;
            //employeeNumber = string.Empty;
            //isAreaIncharge = false;
            //userIP = string.Empty;
            //currentLoginDateTime = DateTime.Now;

            CheckExisting();
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId
        {
            get { return this.loginUserId; }
            set { this.loginUserId = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName
        {
            get { return this.loginUserName; }
            set { this.loginUserName = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>The user role.</value>
        public string UserRole
        {
            get { return this.loginUserRole; }
            set { this.loginUserRole = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the user mobile no.
        /// </summary>
        /// <value>The user mobile no.</value>
        public string UserMobileNo
        {
            get { return this.loginUserMobileNo; }
            set { this.loginUserMobileNo = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the user email identifier.
        /// </summary>
        /// <value>The user email identifier.</value>
        public string UserEmailId
        {
            get { return this.loginUserEmailId; }
            set { this.loginUserEmailId = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the employee number.
        /// </summary>
        /// <value>The employee number.</value>
        public string EmployeeNumber
        {
            get { return this.loginUserEmployeeNumber; }
            set { this.loginUserEmployeeNumber = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the is area incharge.
        /// </summary>
        /// <value>The is area incharge.</value>
        public string IsAreaIncharge
        {
            get { return this.loginUserIsAreaIncharge; }
            set { this.loginUserIsAreaIncharge = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the user ip.
        /// </summary>
        /// <value>The user ip.</value>
        public string UserIp
        {
            get { return this.loginUserIp; }
            set { this.loginUserIp = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the current login date time.
        /// </summary>
        /// <value>The current login date time.</value>
        public DateTime CurrentLoginDateTime
        {
            get { return this.loginDateTime; }
            set { this.loginDateTime = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>The country code.</value>
        public string CountryCode
        {
            get { return this.loginCountryCode; }
            set { this.loginCountryCode = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>The name of the country.</value>
        public string CountryName
        {
            get { return this.loginCountryName; }
            set { this.loginCountryName = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the language code.
        /// </summary>
        /// <value>The language code.</value>
        public string LanguageCode
        {
            get { return this.loginLanguageCode; }
            set { this.loginLanguageCode = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the name of the language.
        /// </summary>
        /// <value>The name of the language.</value>
        public string LanguageName
        {
            get { return this.loginLanguageName; }
            set { this.loginLanguageName = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>The name of the database.</value>
        public string DatabaseName
        {
            get { return this.loginDatabaseName; }
            set { this.loginDatabaseName = value; Save(); }
        }
    }
}
