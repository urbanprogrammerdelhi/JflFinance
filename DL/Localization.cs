// ***********************************************************************
// Assembly         : DL
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-29-2015
// ***********************************************************************
// <copyright file="Resources.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using System.Globalization;
using System.Resources;

/// <summary>
/// The DL namespace.
/// </summary>
namespace DL
{

    /// <summary>
    /// Set culture and get resources according to culture.
    /// </summary>
    [CLSCompliantAttribute(false)]
    public class Localization
    {
        /// <summary>
        /// Sets the culture.
        /// </summary>
        /// <param name="cultureName">Name of the culture.</param>
        public void SetCulture(String cultureName)
        {

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
        }

        /// <summary>
        /// Resources the specified resource key.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <returns>System.String.</returns>
        public string Resource( string resourceKey)
        {
            ResourceManager m_resourceManger = new ResourceManager("DL.Resources.Resources", this.GetType().Assembly);
            return m_resourceManger.GetString(resourceKey).ToString();
            
        }

    }
}
