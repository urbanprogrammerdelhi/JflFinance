// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="ChangePasswordAdmin.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;



/// <summary>
/// Class UserManagement_ChangePasswordAdmin
/// </summary>
public partial class UserManagement_ChangePasswordAdmin : BasePage //System.Web.UI.Page
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
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        BL.HRManagement objHrManagement = new BL.HRManagement();
        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.ChangePassword;
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


            if (IsModifyAccess == true)
            {
                txtUserID.Text = Request.QueryString["strUserID"];
                HFCompanyCode.Value = Request.QueryString["CompanyCode"];
                HFCountryCode.Value = Request.QueryString["CountryCode"];
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            
            if (HFCompanyCode.Value == "")
            {
                 lblErrorMsg1.Text=string.Empty;
            }
            else
            {
                lblErrorMsg1.Text = Resources.Resource.PasswordChangeMessage;
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnSubmit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        Regex uppercaseCharacterMatcher = new Regex("[A-Z]");
        BL.UserManagement objUserManagement = new BL.UserManagement();
        if (txtPassword.Text != BaseUserID || txtPassword.Text != txtUserID.Text)
        {
            if (txtPassword.Text == txtConfirmPassword.Text)
            {
                if (txtPassword.Text.Length >= 8)
                {
                    if (uppercaseCharacterMatcher.Matches(txtPassword.Text).Count >= 1)
                    {
                        if (HFCompanyCode.Value == "")
                        {
                            string strkey = GetDecryptkey(BaseCountryCode);
                            ds = objUserManagement.ChangePassword(txtUserID.Text, txtPassword.Text, BaseUserID, BaseCompanyCode, strkey);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables.Count >= 1 && ds.Tables[0].TableName == "PasswordFail" && ds.Tables[0].Rows.Count > 0)
                                {
                                    lblErrorMsg.Text = Resources.Resource.PasswordNotComply;
                                    //DisplayMessageString(lblErrorMsg, ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString()));
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
                        else 
                        {
                            string strkey = GetDecryptkey(HFCountryCode.Value);
                            ds = objUserManagement.ChangePassword(txtUserID.Text, txtPassword.Text, BaseUserID, HFCompanyCode.Value, strkey);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables.Count >= 1 && ds.Tables[0].TableName == "PasswordFail" && ds.Tables[0].Rows.Count > 0)
                                {
                                    lblErrorMsg.Text = Resources.Resource.PasswordNotComply;
                                    //DisplayMessageString(lblErrorMsg, ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString()));
                                }
                                else
                                {
                                    //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                    //lblErrorMsg1.Text = Resources.Resource.RedirectToHomePage;
                                    var url = Request.Url.AbsolutePath;
                                    //url.Replace("/UserManagement/ChangePasswordAdmin.aspx", "/Default.aspx");
                                    url=Request.ApplicationPath;
                                    Response.Redirect("~/Default.aspx");
                                    //HtmlMeta meta = new HtmlMeta();
                                    //meta.HttpEquiv ="Refresh";
                                    //meta.Content ="5;url=/Default.aspx" ;
                                    //this.Page.Controls.Add(meta);
                                    return;
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
            DisplayMessageString(lblErrorMsg, Resources.Resource.UserIDPasswordCouldNotSame.ToString());

        }
    }
    /// <summary>
    /// Handles the Click event of the btnBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (HFCompanyCode.Value == "")
        {
            Response.Redirect("../UserManagement/UserDetail.aspx");
        }
        else {

            Response.Redirect("~/Default.aspx");
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

}
