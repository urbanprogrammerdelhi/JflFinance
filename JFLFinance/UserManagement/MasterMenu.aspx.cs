// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="MasterMenu.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Web.UI.WebControls;
using BL;

/// <summary>
/// Class UserManagement_MasterMenu
/// </summary>
public partial class UserManagement_MasterMenu : BasePage //System.Web.UI.Page
{
    #region Session Variables
    /// <summary>
    /// Returns UserID.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The session_ user ID.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionUserID
    {
        get
        {
            try
            {
                if (BaseUserInformation.UserId != string.Empty)
                { return BaseUserInformation.UserId; }
                HttpContext.Current.Response.Redirect("../default.aspx", "MainMasterPage_top", "");
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Returns UserName.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The name of the session_ user.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionUserName
    {
        get
        {
            try
            {
                if (BaseUserInformation.UserName != string.Empty)
                { return BaseUserInformation.UserName; }
                HttpContext.Current.Response.Redirect("../default.aspx", "MainMasterPage_top", "");
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Returns UserType IsAdmin.
    /// Throws Sessions has expired exception.
    /// </summary>
    /// <value>The session_ isadmin.</value>
    /// <exception cref="System.Exception">Session has expired! Login again.</exception>
    protected string SessionIsadmin
    {
        get
        {
            try
            {
                if (BaseUserInformation.UserRole != string.Empty)
                { return BaseUserInformation.UserRole; }
                HttpContext.Current.Response.Redirect("../default.aspx", "MainMasterPage_top", "");
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again.", ex); }
        }
    }
    #endregion

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("../Admin/CallingPage.aspx");

        //if (Master != null)
        //{
        //    var lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");

        //    if (lblPageHdrTitle != null)
        //    {
        //        lblPageHdrTitle.Text = Resources.Resource.MainMenu;
        //    }
        //}
        //if (SessionIsadmin != "SA")
        //    {
        //        lblErrMsg.Text = Resources.Resource.NOAccessRights;
        //        PnlMainMenu.Visible = false;
        //    }
        //    else
        //    {
        //        lblErrMsg.Text = "";
        //        PnlMainMenu.Visible = true;
        //    }
        //    BaseAccessInformation.CompanyCode = string.Empty;
        //    BaseAccessInformation.CompanyDesc = string.Empty;
        //    BaseAccessInformation.HrLocationCode = string.Empty;
        //    BaseAccessInformation.HrLocationDesc = string.Empty;
        //    BaseAccessInformation.LocationCode = string.Empty;
        //    BaseAccessInformation.LocationDesc = string.Empty;
        //    BaseAccessInformation.LocationAutoId = string.Empty;
    }
    /// <summary>
    /// Handles the Click event of the ImgConfiguration control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.ImageClickEventArgs" /> instance containing the event data.</param>
    protected void ImgResetPassword_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        var objUm = new UserManagement();
        if (!string.IsNullOrEmpty(BaseUserInformation.CountryCode))
        {
            var objConString = new DL.ConnectionString();
            string dKey = objConString.DecryptKeyGet(BaseUserInformation.CountryCode);

            lblErrMsg.Text = objUm.ResetAllPasswordsWithNewEncription(dKey);
        }
    }
}
