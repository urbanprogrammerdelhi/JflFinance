// ***********************************************************************
// Assembly         : 
// Author           : Administrator
// Created          : 09-13-2013
//
// Last Modified By : Administrator
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="MasterHeader.master.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;

/// <summary>
/// Class MasterHeader
/// </summary>
public partial class MasterHeader : MasterPage
{

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var uInfo = new CommonLibrary.Session.UserInformation();
            if (!string.IsNullOrEmpty(uInfo.UserName))
            {
                lblwelcome.Text = Resources.Resource.Welcome + @": " + uInfo.UserName;
                string strUsername = Resources.Resource.UserName + " : ";
                string strLoginCountry = Resources.Resource.Country + " : ";
                //string text = "<FONT SIZE='2' COLOR=black><MARQUEE SCROLLDELAY=140>" + strUsername + " [" + uInfo.UserName + "] " + strLoginCountry + "[" + uInfo.CountryName + "] " + "</MARQUEE></FONT>";
                //lblLoginInfo.Text = text;
            }
            ReadXml();
            if (!string.IsNullOrEmpty(uInfo.UserIp))
                lblIPAddress.Text = @" [" + uInfo.UserIp + @"]";
        }

    }

    /// <summary>
    /// Reads the XML.
    /// </summary>
    protected void ReadXml()
    {
        var objUserManagement = new BL.UserManagement();
        DataSet ds = objUserManagement.WebConfigXmlGet(Server.MapPath("../"));
        lblSoftwareName.Text = ds.Tables[0].Rows[0][0].ToString();
        lblSoftwareVersion.Text = ds.Tables[0].Rows[0][1].ToString();
    }

    /// <summary>
    /// Handles the Click event of the ImgBtnLogout control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ImageClickEventArgs" /> instance containing the event data.</param>
    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Logout();
        //Session.Abandon();
        //Response.Redirect("../Default.aspx");
    }

    /// <summary>
    /// Handles the Click event of the lbLogout control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Logout();
        //Session.Abandon();
        //Response.Redirect("../Default.aspx");
    }

    /// <summary>
    /// Logouts this instance.
    /// </summary>
    private void Logout()
    {
        FormsAuthentication.SignOut();
        Session.Abandon();

        var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "") { Expires = DateTime.Now.AddYears(-1) };
        Response.Cookies.Add(cookie1);

        var cookie2 = new HttpCookie("ASP.NET_SessionId", "") { Expires = DateTime.Now.AddYears(-1) };
        Response.Cookies.Add(cookie2);

        FormsAuthentication.RedirectToLoginPage();
    }
}