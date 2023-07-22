// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="ResponseRedirectExtension.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Web;
using System.Web.UI;

/// <summary>
///     Class ResponseRedirectExtension
/// </summary>
public static class ResponseRedirectExtension
{
    /// <summary>
    ///     Redirects the specified response.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <param name="url">The URL.</param>
    /// <param name="target">The target.</param>
    /// <param name="windowFeatures">The window features.</param>
    /// <exception cref="System.InvalidOperationException">Cannot redirect to new window outside Page context.</exception>
    public static void Redirect(this HttpResponse response, string url, string target, string windowFeatures)
    {
        if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) &&
            String.IsNullOrEmpty(windowFeatures))
        {
            response.Redirect(url);
        }
        else
        {
            var page = (Page) HttpContext.Current.Handler;
            if (page == null)
            {
                throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
            }
            url = page.ResolveClientUrl(url);
            string script;
            if (!String.IsNullOrEmpty(windowFeatures))
            {
                script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
            }
            else
            {
                script = @"window.open(""{0}"", ""{1}"");";
            }

            script = String.Format(script, url, target, windowFeatures);
            ScriptManager.RegisterStartupScript(page, typeof (Page), "Redirect", script, true);
        }
    }
}