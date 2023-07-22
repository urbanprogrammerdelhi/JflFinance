// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="ReportCreditentials.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{
    /// <summary>
    /// Class ReportCredentials.
    /// </summary>
    public class ReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {
        /// <summary>
        /// The _user name
        /// </summary>
        string _userName, _password, _domain;
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportCredentials" /> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="domain">The domain.</param>
        public ReportCredentials(string userName, string password, string domain)
        {
            _userName = userName;
            _password = password;
            _domain = domain;
        }
        /// <summary>
        /// Gets or sets the <see cref="T:System.Security.Principal.WindowsIdentity" /> of the user to impersonate when the <see cref="T:Microsoft.Reporting.WebForms.ReportViewer" /> control connects to a report server.
        /// </summary>
        /// <value>The impersonation user.</value>
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;
            }
        }
        /// <summary>
        /// Gets or sets the network credentials that are used for authentication with the report server.
        /// </summary>
        /// <value>The network credentials.</value>
        public System.Net.ICredentials NetworkCredentials
        {
            get
            {
                return new System.Net.NetworkCredential(_userName, _password, _domain);
            }
        }
        /// <summary>
        /// Gets the forms credentials.
        /// </summary>
        /// <param name="authCoki">The authentication coki.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="authority">The authority.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool GetFormsCredentials(out System.Net.Cookie authCoki, out string userName, out string password, out string authority)
        {
            userName = _userName;
            password = _password;
            authority = _domain;
            authCoki = new System.Net.Cookie(".ASPXAUTH", ".ASPXAUTH", "/", "hhi");
            return true;
        }
    }
}
