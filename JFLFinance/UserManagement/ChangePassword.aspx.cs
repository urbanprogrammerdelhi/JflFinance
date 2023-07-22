// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="ChangePassword.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Text.RegularExpressions;



/// <summary>
/// Class UserManagement_ChangePassword
/// </summary>
public partial class UserManagement_ChangePassword : BasePage // System.Web.UI.Page
{
    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsReadAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Write Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Modify Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Delete Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    #region Page Functions
    /// <summary>
    /// Handles the PreInit event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void Page_PreInit(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(BaseLocationAutoID))
        {
            this.MasterPageFile = "~/MasterPage/MasterPage.master";
        }
        else
        {
            this.MasterPageFile = "~/MasterPage/MasterHeader.master";
        }
    }
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsReadAccess == true)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.ChangePassword.ToString();
            //}
            //Code added by  on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ChangePassword + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            btnApply.Attributes.Add("onclick", "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "')");
            if ((IsModifyAccess == true || IsWriteAccess == true) && BaseUserID != "system")
            {
                EnableAllControles();
            }
            else
            {
                DisableAllControles();
                lblErrorMsg.Text = Resources.Resource.MsgNoRightToChangePassword.ToString();
            }
        }
    }
    /// <summary>
    /// Disables all controles.
    /// </summary>
    protected void DisableAllControles()
    {
        txtOldPassword.Enabled = false;
        txtNewPassword.Enabled = false;
        txtConfirmPassword.Enabled = false;
        btnApply.Enabled = false;
    }
    /// <summary>
    /// Enables all controles.
    /// </summary>
    protected void EnableAllControles()
    {
        txtOldPassword.Enabled = true;
        txtNewPassword.Enabled = true;
        txtConfirmPassword.Enabled = true;
        btnApply.Enabled = true;
    }
    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    /// <summary>
    /// Handles the Click event of the btnApply control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnApply_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        Regex uppercaseCharacterMatcher = new Regex("[A-Z]");
        BL.UserManagement objUserManagement = new BL.UserManagement();
        if (txtNewPassword.Text != BaseUserID)
        {
            if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                if (txtNewPassword.Text.Length >= 8)
                {
                    if (uppercaseCharacterMatcher.Matches(txtNewPassword.Text).Count >= 1)
                        
                    {
                        BL.UserManagement objDlUserManagement = new BL.UserManagement();
                        DataSet dsPasswordCheck = new DataSet();
                        dsPasswordCheck.Locale = System.Globalization.CultureInfo.InvariantCulture;
                        dsPasswordCheck = objDlUserManagement.CheckPasswordExpression(BaseCompanyCode, txtNewPassword.Text);
                        if (dsPasswordCheck != null && dsPasswordCheck.Tables.Count > 0 && dsPasswordCheck.Tables[0].Rows.Count > 0)
                        {
                            lblErrorMsg.Text = Resources.Resource.PasswordNotComply;
                        } 
                        else
                        {
                            string strkey = GetDecryptkey(BaseCountryCode);
                            ds = objUserManagement.ChangePassword(BaseUserID, txtNewPassword.Text, txtOldPassword.Text, BaseUserID, BaseCompanyCode, strkey);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables.Count >= 1 && ds.Tables[0].TableName == "PasswordFail" && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessageString(lblErrorMsg, ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString()));
                                }
                                else
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                }
                            }
                            else
                            {
                                DisplayMessageString(lblErrorMsg, Resources.Resource.UsedPassword.ToString());
                            }
                    }
                    }
                    else
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.PasswordNotComply.ToString());
                    }
                }
                else
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.PasswordLength.ToString());
                }
            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.PasswordConfirmPasswordShouldMatch.ToString());
            }

        }
        else
        {
            DisplayMessageString(lblErrorMsg,Resources.Resource.UserIDPasswordCouldNotSame.ToString());
        
        }


    }

    /// <summary>
    /// Get the  key vlaue from Encrypted file.
    /// </summary>
    /// <param name="strCountry">The STR country.</param>
    /// <returns>Key that we are using to Decrypt the string</returns>
    string GetDecryptkey(string strCountry)
    {
        DL.ConnectionString objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }
    #endregion
}
