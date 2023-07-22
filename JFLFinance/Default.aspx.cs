// ***********************************************************************
// Assembly         : 
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="Default.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>       c
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// Class _Default.
/// </summary>
public partial class _Default : BasePage //System.Web.UI.Page
{

    protected void Page_PreRender(object sender, EventArgs e)
    {
        // setup client-side input processing
        SampleCaptcha.UserInputClientID = CaptchaCodeTextBox.ClientID;

        if (IsPostBack)
        {
            CaptchaCodeTextBox.Text = null; // clear previous user input

            //if (Page.IsValid)
            //{
            //    ValidationPassedLabel.Visible = true;
            //}
            //else
            //{
            //    ValidationPassedLabel.Visible = false;
            //}
        }
    }
        /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // added by  on 29-apr-2010 =====================
            //SampleCaptcha.ImageStyle = BotDetect.ImageStyle.Overlap2;
            SampleCaptcha.ImageStyle = BotDetect.ImageStyle.Bubbles;
            SampleCaptcha.CustomLightColor = System.Drawing.Color.White;
            SampleCaptcha.CustomDarkColor = System.Drawing.Color.Black;
            SampleCaptcha.CodeLength = 3;

            SampleCaptcha.CodeStyle = BotDetect.CodeStyle.Alphanumeric;
            //SampleCaptcha.Height = 20;
            //SampleCaptcha.Width = 200;
            if (Request.UrlReferrer != null)
            {
                string mainString = Request.UrlReferrer.ToString().ToLower();
                const string searchString = "default";
                int firstChr = mainString.IndexOf(searchString, StringComparison.Ordinal);
                if (firstChr == -1)
                {
                    Response.Redirect("default.aspx", "_top", string.Empty);
                }
            }
            //========================================================
            //Session.RemoveAll();  //manish
            // PlayMediaMessage(100);

            lbErrMsg.Text = string.Empty;
            FillCountryDropDown();
            BaseUserInformation.CountryCode = ddlCountry.SelectedValue;
            txtUserID.Focus();
            ReadXml();
            if (Request.QueryString["Language"] != null && Request.QueryString["Language"] != string.Empty)
            {
                SetCulture(Request.QueryString["Language"], Request.QueryString["Language"]);
                ddllanguage.SelectedValue = Request.QueryString["Language"];
            }
        }
    }
    /// <summary>
    /// Reads the XML.
    /// </summary>
    protected void ReadXml()
    {
        var ds = new DataSet();
        ds.ReadXml(Server.MapPath("App_Data/Webconfig.xml"));
        lblSoftwareName.Text = ds.Tables[0].Rows[0][0].ToString();
        lblSoftwareVersion.Text = ds.Tables[0].Rows[0][1].ToString();
        lblRelease.Text = ds.Tables[0].Rows[0][4].ToString();
    }

    /// <summary>
    /// Handles the onclick event of the btnLogin control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnLogin_onclick(object sender, EventArgs e)
    {

        bool isHuman = SampleCaptcha.Validate(CaptchaCodeTextBox.Text);
        if(!isHuman)
        {
            CaptchaCodeTextBox.Text = null;
            CaptchaCodeTextBox.Focus();
            return;
        }

        var objblUserManagement = new BL.UserManagement();
        txtUserID.Text = txtUserID.Text.Replace("'", "-");

        //CommonLibrary.Session.UserInformation uInfo = new CommonLibrary.Session.UserInformation();
        //uInfo.userIP = "10.10.14.88";
        //uInfo.currentLoginDateTime = System.DateTime.Now;

        BaseUserInformation.UserIp = GetClientIpAddress(HttpContext.Current.Request);
        if (ddlCountry.Items.Count > 0)
        {
            BaseUserInformation.CountryName = ddlCountry.SelectedItem.Text;
            BaseUserInformation.CountryCode = ddlCountry.SelectedValue;
            objblUserManagement.InsertPasswordPolicyCredentials(txtUserID.Text);
            //Finding the decrypt key on the basis of selected country from encrypted file  14-oct-2011.
            string strPwdkey = GetDecryptkey(ddlCountry.SelectedValue);

            //Passing the decrypt key vlaue as strSaPwdkey.With the help of this key decrypt the string. 
            DataSet ds = objblUserManagement.UserDetailGet(txtUserID.Text, txtPassword.Text, strPwdkey);

            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].TableName != "ErrorTable")
            {
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].TableName == "LoginFail")
                    {
                        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "2")
                        {
                            lbErrMsg.Text = Resources.Resource.AccountDisabled;
                            txtUserID.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            txtUserID.Focus();
                            return;
                        }
                        else if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "3")
                        {
                            lbErrMsg.Text = Resources.Resource.CrossedMaxPasswordAttempts;
                            txtUserID.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            txtUserID.Focus();
                            return;
                        }
                        else
                        {
                            lbErrMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                            txtUserID.Text = string.Empty;
                            txtPassword.Text = string.Empty;
                            txtUserID.Focus();
                            return;
                        }
                    }

                    //----Temp Code
                    // To change the Password Encription of Existing Users
                    //DataSet ds1 = new DataSet();
                    //ds1 = objblUserManagement.UserGetAll();
                    //string oldPassword, newPassword;
                    //DataSet changePasswordStatus = new DataSet();
                    //DL.UserManagement objdlUserManagement = new DL.UserManagement();
                    //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    //{
                    //    oldPassword = objblUserManagement.DecryptPassword(ds1.Tables[0].Rows[i]["Password"].ToString(), true, "Syed Moshiur Murshed");
                    //    newPassword = objblUserManagement.EncryptPassword(oldPassword, true, "Syed Moshiur Murshed");
                    //    changePasswordStatus = objdlUserManagement.ChangePassword(ds1.Tables[0].Rows[i]["UserId"].ToString(), newPassword, ds1.Tables[0].Rows[i]["ModifiedBy"].ToString());
                    //}
                    //---Temp Code

                    BaseUserInformation.UserId = ds.Tables[0].Rows[0]["UserID"].ToString();
                    BaseUserInformation.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                    BaseUserInformation.UserRole = ds.Tables[0].Rows[0]["IsAdmin"].ToString();
                    BaseUserInformation.EmployeeNumber = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
                    BaseUserInformation.IsAreaIncharge = ds.Tables[0].Rows[0]["IsAreaIncharge"].ToString();
                    BaseUserInformation.LanguageCode = ddllanguage.SelectedValue;


                    // get the role now
                    string roles = ds.Tables[0].Rows[0]["IsAdmin"].ToString();
                    // get user Name
                    string userName = ds.Tables[0].Rows[0]["UserName"].ToString();
                    // set remember me default false as UI have not option to capture.
                    const bool rememberUserName = false;

                    // Create forms authentication ticket
                    var ticket = new FormsAuthenticationTicket(
                    1, // Ticket version
                    userName,// Username to be associated with this ticket
                    DateTime.Now, // Date/time ticket was issued
                    DateTime.Now.AddMinutes(50), // Date and time the cookie will expire
                    rememberUserName, // if user has chcked rememebr me then create persistent cookie
                    roles, // store the user data, in this case roles of the user
                    FormsAuthentication.FormsCookiePath); // Cookie path specified in the web.config file in <Forms> tag if any.

                    // To give more security it is suggested to hash it
                    string hashCookies = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies); // Hashed ticket

                    // Add the cookie to the response, user browser
                    Response.Cookies.Add(cookie);

                    string redirectUrl;
                    if (ds.Tables[0].Rows[0]["IsAdmin"].ToString() == "SA")
                    {
                        Response.Write("<script type='text/javascript' language='JavaScript'>");
                        Response.Write("</script>");
                        redirectUrl = "UserManagement/MainSelection.aspx";
                    }

                    else
                    {
                        try
                        {
                            if (ds.Tables[4].Rows[0]["IsActiveAreaIncharge"].ToString().Trim().ToLower() ==
                                string.Empty.Trim().ToLower() && BaseUserIsAreaIncharge == "1")
                            {
                                Show("Area Incharge is not valid");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            ExceptionLog(ex);
                        }
                        //DataSet dsCheckPassword = new DataSet();
                        //dsCheckPassword = objblUserManagement.CheckPasswordResuse(txtUserID.Text);
                        //if (dsCheckPassword != null && dsCheckPassword.Tables.Count > 0 && dsCheckPassword.Tables[0].Rows.Count > 0)
                        //{
                        //    DataTable dtCheckPassword = dsCheckPassword.Tables[0];
                        //    foreach (DataRow row in dsCheckPassword.Tables[0].Rows)
                        //    {
                        //        bool dsPasswordMatch;
                        //        dsPasswordMatch = objblUserManagement.DoesPasswordMatch(dsCheckPassword.Tables[0].Rows[0]["OldPassword"].ToString(), txtUserID.Text + txtPassword.Text, true, strPwdkey);
                        //        if (dsPasswordMatch)
                        //        {
                        //            lbErrMsg.Text = Resources.Resource.PasswordNotComply;
                        //            HtmlMeta meta = new HtmlMeta();
                        //            meta.HttpEquiv = "Refresh";
                        //            meta.Content = "5;url=UserManagement/MainSelection.aspx?strUserID=" + txtUserID.Text +"&CountryCode=" + ddlCountry.SelectedValue;
                        //            this.Page.Controls.Add(meta);
                        //            lbErrMsg1.Text = Resources.Resource.PasswordChangeRedirect;
                        //            return;
                        //        }
                        //    }
                        //}
                        Regex  numericmatcher = new Regex("[0-9]");
                        Regex uppercaseCharacterMatcher = new Regex("[A-Z]");
                        Regex secialChars = new Regex(@"[\\\-~!@#$%^*()_+{}:|""?`;',./[\]]+");
                        string strPasswordValidityMsg = CheckPasswordValidity(ds);
                        BaseUserInformation.CurrentLoginDateTime = DateTime.Now;
                        var dsCurrentLogindetails = new DataSet();
                        dsCurrentLogindetails = objblUserManagement.InsertCurrentLoginDetails(BaseUserID, Session.SessionID);
                        
                        if (txtPassword.Text.Length < 8 || uppercaseCharacterMatcher.Matches(txtPassword.Text).Count < 1 || numericmatcher.Matches(txtPassword.Text).Count < 1 || secialChars.Matches(txtPassword.Text).Count < 1)
                        {
                            //lbErrMsg.Text = Resources.Resource.PasswordNotComply;
                            var meta = new HtmlMeta();
                            meta.HttpEquiv = "Refresh";
                            meta.Content = "5;url=UserManagement/MainSelection.aspx?strUserID=" + txtUserID.Text + "&CountryCode=" + ddlCountry.SelectedValue;
                            this.Page.Controls.Add(meta);
                            lbErrMsg1.Text = Resources.Resource.PasswordChangeRedirect;
                            return;
                        }
                        //If this vlaue is 0 then password has been expired  and we are restricting to user on same Screen
                        if (strPasswordValidityMsg == "0")
                        {
                            lbErrMsg.Text = Resources.Resource.ErrMsgExpireLogin;
                            return;
                        }
                        redirectUrl = "UserManagement/MainSelection.aspx?msg=" + strPasswordValidityMsg;
                    }
                    SetCulture(ddllanguage.SelectedValue, ddllanguage.SelectedValue);
                    BaseUserInformation.DatabaseName = GetDataBaseName();
                    Response.Redirect(redirectUrl);
                }
                else
                {
                    lbErrMsg.Text = Resources.Resource.ErrMsgInvalidLogin ; //"Login failed! invalid userid or password";
                    txtUserID.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUserID.Focus();
                }
            }
            else
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lbErrMsg.Text = Resources.Resource.ErrMsgExceedLicense;
                    txtUserID.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUserID.Focus();
                }
            }
        }
    }

    /// <summary>
    /// Checks the password validity.
    /// </summary>
    /// <param name="ds">The ds.</param>
    /// <returns>System.String.</returns>
    private string CheckPasswordValidity(DataSet ds)
    {
        string strLastPasswordChanged
         = ds.Tables[3].Rows[0]["PasswordChangedDate"].ToString() != string.Empty
         ? DateTime.Parse(ds.Tables[3].Rows[0]["PasswordChangedDate"].ToString()).ToString("dd-MMM-yyyy")
         : DateTime.Now.ToString("dd-MMM-yyyy");


        int intDisabledUnusedAccountAfter = int.Parse(ds.Tables[1].Rows[0]["Disable_Ac_after_days"].ToString());
        int intPasswordExpDays = int.Parse(ds.Tables[1].Rows[0]["Password_Exp_after_days"].ToString());
        int intFlashExpiryMsgDays = int.Parse(ds.Tables[1].Rows[0]["Password_Exp_warn_before"].ToString());
        var objUsermanagement = new BL.UserManagement();
        var dslastlogin = new DataSet();
        dslastlogin = objUsermanagement.CheckLastLoginDetails(BaseUserID);
        if (dslastlogin != null && dslastlogin.Tables.Count > 0 && dslastlogin.Tables[0].Rows.Count > 1)
        {
            DateTime lastlogindate = (DateTime)dslastlogin.Tables[0].Rows[0]["LoginTime"];
            DateTime currentDateTime = (DateTime)dslastlogin.Tables[0].Rows[0]["CurrentTime"];
            TimeSpan calcduration = currentDateTime.Subtract(lastlogindate);
            int timespancalc = int.Parse(calcduration.Days.ToString());
            if (intDisabledUnusedAccountAfter < timespancalc)
            {
                objUsermanagement.DisableUser(txtUserID.Text);
                return "0";

            }
            strLastPasswordChanged = DateTime.Parse(strLastPasswordChanged).AddDays(intPasswordExpDays - intFlashExpiryMsgDays).ToString("dd-MMM-yyyy");
            DateTime dtLastPasswordChanged = DateTime.Parse(strLastPasswordChanged);
            if (dtLastPasswordChanged <= DateTime.Now)
            {
                TimeSpan ts = DateTime.Now - DateTime.Parse(strLastPasswordChanged);
                if (intFlashExpiryMsgDays - ts.Days < 0)
                {
                    //handle password Expired.If password expired then user should not Enter into application 
                    //Response.Redirect("UserManagement/ChangePassword.aspx");
                    return "0";
                }
                return "Your Password will expire after " + (intFlashExpiryMsgDays - ts.Days) + "day(s)";
            }
        }

        return string.Empty;
    }

    /// <summary>
    /// Added By   Dated 04-Feb-2010
    /// Function Added to Get DataBase Name From Connection String in Web.Config
    /// //Code Changed 0n 14-oct-2011
    /// Get data base name from stored Encrypted File.
    /// </summary>
    /// <returns>String DatabaseName</returns>
    private string GetDataBaseName()
    {
        var objConString = new DL.ConnectionString();
        string strDatabaseName = objConString.DatabaseNameGet(ddlCountry.SelectedValue);
        return strDatabaseName;
    }
    /// <summary>
    /// Handles the onclick event of the btnReSet control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnReSet_onclick(object sender, EventArgs e)
    {
        txtPassword.Text = string.Empty;
        txtUserID.Text = string.Empty;
        lbErrMsg.Text = string.Empty;
        txtUserID.Focus();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddllanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void ddllanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetCulture(ddllanguage.SelectedValue, ddllanguage.SelectedValue);
        Response.Redirect("Default.aspx?Language=" + ddllanguage.SelectedValue);
    }

    /// <summary>
    /// Fill the country dropDown from the Encrypted File.
    /// </summary>
    protected void FillCountryDropDown()
    {
        var objConString = new DL.ConnectionString();
        DataSet ds = objConString.CountryConnectionsGet();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlCountry.DataSource = ds.Tables[0].DefaultView;
            ddlCountry.DataTextField = "Country";
            ddlCountry.DataValueField = "Key";
            ddlCountry.DataBind();
        }

        if (Request.QueryString["DB"] != null)
        {
            System.Web.UI.WebControls.ListItem selectedListItem = ddlCountry.Items.FindByValue(Request.QueryString["DB"].ToString());
            if (selectedListItem != null)
            {
                selectedListItem.Selected = true;
            }
        }
    }
    /// <summary>
    /// Get the  key vlaue from Encrypted file.
    /// </summary>
    /// <param name="strCountry">The string country.</param>
    /// <returns>Key that we are using to Decrypt the string</returns>
    protected string GetDecryptkey(string strCountry)
    {
        var objConString = new DL.ConnectionString();
        return objConString.DecryptKeyGet(strCountry);

    }
    /// <summary>
    /// Handles the Click event of the ImgConfiguration control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.ImageClickEventArgs" /> instance containing the event data.</param>
    protected void ImgConfiguration_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        if (txtPassword.Text == lblSoftwareVersion.Text)
        {
            Response.Redirect(@"EncryptDecrypt\GenerateConnectionStrings.aspx");
        }
    }
}