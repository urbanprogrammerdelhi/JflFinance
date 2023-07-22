// ***********************************************************************
// Assembly         : CommonLibrary
// Author           : Administrator
// Created          : 04-27-2015
//
// Last Modified By : Administrator
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="AccessInformation.cs" company="Microsoft">
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
    /// Class AccessInformation.
    /// </summary>
    [Serializable]
    public class AccessInformation
    {
        /// <summary>
        /// The session name
        /// </summary>
        private const string SessionName = "AccessInformation";
        /// <summary>
        /// The login company code
        /// </summary>
        private string loginCompanyCode;
        /// <summary>
        /// The login company desc
        /// </summary>
        private string loginCompanyDesc;
        /// <summary>
        /// The login hr location code
        /// </summary>
        private string loginHrLocationCode;
        /// <summary>
        /// The login hr location desc
        /// </summary>
        private string loginHrLocationDesc;
        /// <summary>
        /// The login location code
        /// </summary>
        private string loginLocationCode;
        /// <summary>
        /// The login location desc
        /// </summary>
        private string loginLocationDesc;
        /// <summary>
        /// The login location automatic identifier
        /// </summary>
        private string loginLocationAutoId;

        /// <summary>
        /// Checks the existing.
        /// </summary>
        private void CheckExisting()
        {
            if (HttpContext.Current.Session[SessionName] == null)
            {
                //Save this instance to the session
                HttpContext.Current.Session[SessionName] = this;
                CompanyCode = string.Empty;
                CompanyDesc = string.Empty;
                HrLocationCode = string.Empty;
                HrLocationDesc = string.Empty;
                LocationCode = string.Empty;
                LocationDesc = string.Empty;
                LocationAutoId = string.Empty;
            }
            else
            {
                //Initialize our object based on existing session
                var accessInfo = (AccessInformation)HttpContext.Current.Session[SessionName];
                this.CompanyCode = accessInfo.CompanyCode;
                this.CompanyDesc = accessInfo.CompanyDesc;
                this.HrLocationCode = accessInfo.HrLocationCode;
                this.HrLocationDesc = accessInfo.HrLocationDesc;
                this.LocationCode = accessInfo.LocationCode;
                this.LocationDesc = accessInfo.LocationDesc;
                this.LocationAutoId = accessInfo.LocationAutoId;

                accessInfo = null;
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
        /// Initializes a new instance of the <see cref="AccessInformation"/> class.
        /// </summary>
        public AccessInformation()
        {
            CheckExisting();
        }

        /// <summary>
        /// Gets or sets the company code.
        /// </summary>
        /// <value>The company code.</value>
        public string CompanyCode
        {
            get { return this.loginCompanyCode; }
            set { this.loginCompanyCode = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the company desc.
        /// </summary>
        /// <value>The company desc.</value>
        public string CompanyDesc
        {
            get { return this.loginCompanyDesc; }
            set { this.loginCompanyDesc = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the hr location code.
        /// </summary>
        /// <value>The hr location code.</value>
        public string HrLocationCode
        {
            get { return this.loginHrLocationCode; }
            set { this.loginHrLocationCode = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the hr location desc.
        /// </summary>
        /// <value>The hr location desc.</value>
        public string HrLocationDesc
        {
            get { return this.loginHrLocationDesc; }
            set { this.loginHrLocationDesc = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the location code.
        /// </summary>
        /// <value>The location code.</value>
        public string LocationCode
        {
            get { return this.loginLocationCode; }
            set { this.loginLocationCode = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the location desc.
        /// </summary>
        /// <value>The location desc.</value>
        public string LocationDesc
        {
            get { return this.loginLocationDesc; }
            set { this.loginLocationDesc = value; Save(); }
        }

        /// <summary>
        /// Gets or sets the location automatic identifier.
        /// </summary>
        /// <value>The location automatic identifier.</value>
        public string LocationAutoId
        {
            get { return this.loginLocationAutoId; }
            set { this.loginLocationAutoId = value; Save(); }
        }
    }
}
