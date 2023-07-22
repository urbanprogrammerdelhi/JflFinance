// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="MyMasterPages.master.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// Class MyMasterPages
/// </summary>
public partial class MyMasterPages : System.Web.UI.MasterPage
{

    //public PageAuthorizationDataModel UserPageAuthorization { get; set; }
    //public string MyProp { get; set; }

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //string[] URL = System.Web.HttpContext.Current.Request.Url.AbsolutePath.Split('/');
        //string RequestedPageName = URL[URL.GetUpperBound(0)];
        

    }
    /// <summary>
    /// Handles the PreRender event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //if (UserPageAuthorization.IsAuthorizeToAccessThisPage == false)
        //{
        //    Response.Write("you are not authorized to access this page. Validated from master page.");
        //    Response.End();
        //}
    }

}
