// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-14-2014
// ***********************************************************************
// <copyright file="PageAuthorization.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using DL;

/// <summary>
///     Summary description for PageAuthorization
/// </summary>
public class PageAuthorizationDataModel
{
    /// <summary>
    ///     Gets or sets the user ID.
    /// </summary>
    /// <value>The user ID.</value>
    public string UserID { get; set; }

    /// <summary>
    ///     Gets or sets the location ID.
    /// </summary>
    /// <value>The location ID.</value>
    public string LocationID { get; set; }

    /// <summary>
    ///     Gets or sets the name of the page.
    /// </summary>
    /// <value>The name of the page.</value>
    public string PageName { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is read access.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    public bool IsReadAccess { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is write access.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    public bool IsWriteAccess { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is modify access.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    public bool IsModifyAccess { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is delete access.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    public bool IsDeleteAccess { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is authorize to access this page.
    /// </summary>
    /// <value><c>true</c> if this instance is authorize to access this page; otherwise, <c>false</c>.</value>
    public bool IsAuthorizeToAccessThisPage { get; set; }
}

/// <summary>
///     Class PageAuthorizationManager
/// </summary>
public class PageAuthorizationManager
{
    /// <summary>
    ///     Gets the autho for page.
    /// </summary>
    /// <param name="pageName">Name of the page.</param>
    /// <param name="userID">The user ID.</param>
    /// <param name="locationId">The location Id.</param>
    /// <returns>PageAuthorizationDataModel.</returns>
    /// <exception cref="System.Exception">Duplicate page request found.</exception>
    public static PageAuthorizationDataModel GetAuthoForPage(string pageName, string userID, string locationId)
    {
        var model = new PageAuthorizationDataModel {UserID = userID, PageName = pageName, LocationID = locationId};
        var objUserMgmt = new UserManagement();

        var dt = objUserMgmt.DLPageRightGet(locationId, userID, pageName);

        if (dt != null && dt.Rows.Count == 0)
        {
            model.IsReadAccess = false;
            model.IsWriteAccess = false;
            model.IsModifyAccess = false;
            model.IsDeleteAccess = false;
            model.IsAuthorizeToAccessThisPage = false;
            return model;
        }
        if (dt != null && dt.Rows.Count == 1)
        {
            model.IsReadAccess = Convert.ToBoolean(dt.Rows[0]["IsRead"].ToString());
            model.IsWriteAccess = Convert.ToBoolean(dt.Rows[0]["IsWrite"].ToString());
            model.IsModifyAccess = Convert.ToBoolean(dt.Rows[0]["IsModify"].ToString());
            model.IsDeleteAccess = Convert.ToBoolean(dt.Rows[0]["IsDelete"].ToString());
            model.IsAuthorizeToAccessThisPage = Convert.ToBoolean(dt.Rows[0]["IsAuthorization"].ToString());
            return model;
        }
        if (dt != null && dt.Rows.Count > 1)
        {
            throw new Exception("Duplicate page request found.");
        }
        return model;
    }
}