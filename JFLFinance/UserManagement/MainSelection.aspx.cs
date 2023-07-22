// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="MainSelection.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

/// <summary>
/// Class MainSelection
/// </summary>
public partial class MainSelection : BasePage //System.Web.UI.Page
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
                HttpContext.Current.Response.Redirect("../default.aspx");
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
                //HttpContext.Current.Response.Redirect("../default.aspx");
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
                //HttpContext.Current.Response.Redirect("../default.aspx");
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
        if (!IsPostBack)
        {
            if (Master != null)
            {
                var lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
                if (lblPageHdrTitle != null)
                {
                    lblPageHdrTitle.Text = Resources.Resource.LocationSelection;
                }
            }
            lblErrMsg.Text = "";
            FillddlCompany();
            if (Request.QueryString["strUserID"] !=null && Request.QueryString["strUserID"] != null)
            {
                HFUserID.Value = Request.QueryString["strUserID"];
                HFCountryCode.Value = Request.QueryString["CountryCode"];
            }
            //hlMasterMenu.Visible = SessionIsadmin == "SA";
            if (Request.QueryString["msg"] != null)
            {
                if (Request.QueryString["msg"] != "")
                {
                    Show(Request.QueryString["msg"]);
                }
            }

            if(ddlCompany.Items.Count == 1 && ddlHrLocation.Items.Count == 1 && ddlLocation.Items.Count == 1)
            {
                SetParameters();
            }
        }

        var hlnkMenuCreation = (HyperLink)Master.FindControl("hlnkMenuCreation");
        var hlnkCreateCompany = (HyperLink)Master.FindControl("hlnkCreateCompany");
        var hlnkCreateHrLocation = (HyperLink)Master.FindControl("hlnkCreateHrLocation");
        var hlnkCreateLocation = (HyperLink)Master.FindControl("hlnkCreateLocation");
        var HLSystemParameter = (HyperLink)Master.FindControl("HLSystemParameter");

        if (SessionIsadmin != "SA")
        {
            hlnkMenuCreation.Visible = false;
            hlnkCreateCompany.Visible = false;
            hlnkCreateHrLocation.Visible = false;
            hlnkCreateLocation.Visible = false;
            HLSystemParameter.Visible = false;
        }
        else
        {
            hlnkMenuCreation.Visible = true;
            hlnkCreateCompany.Visible = true;
            hlnkCreateHrLocation.Visible = true;
            hlnkCreateLocation.Visible = true;
            HLSystemParameter.Visible = true;
        }
    }

    #region Functions Related to DropDown Company

    /// <summary>
    /// Fillddls the company.
    /// </summary>
    protected void FillddlCompany()
    {
        var objblUserManagement = new BL.UserManagement();
        DataSet dsCompany = objblUserManagement.UserCompanyAccessGet(SessionUserID);
        if (dsCompany.Tables[0].Rows.Count > 0)
        {
            ddlCompany.DataSource = dsCompany.Tables[0];
            ddlCompany.DataValueField = "CompanyCode";
            ddlCompany.DataTextField = "CompanyDesc";
            ddlCompany.DataBind();
            ddlCompany.AutoPostBack = true;

            lblCompany.Visible = true;
            ddlCompany.Visible = true;
            //lblvalCompany.Visible = true;
            lblErrMsg.Text = "";
            btnContinue.Visible = true;

            lblCompanyCode.Text = ddlCompany.SelectedItem.Value;
            //lblvalCompany.Text = ddlCompany.SelectedItem.Value;
            FillddlHrLocation();
        }
        else
        {
            RemoveAccessInformationFromSession();

            //Session.Remove("LocationAutoID");
            //Session.Remove("CompanyCode");
            //Session.Remove("CompanyDesc");
            //Session.Remove("HrLocationCode");
            //Session.Remove("LocationCode");

            lblCompany.Visible = false;
            lblCompanyCode.Visible = false;
            lblErrMsg.Text = Resources.Resource.NoDataToShow;
            ddlCompany.Visible = false;
            //lblvalCompany.Visible = false;

            lblHrLocation.Visible = false;
            lblHrLocationCode.Visible = false;
            ddlHrLocation.Visible = false;
            //lblvalHrLocation.Visible = false;

            lblLocation.Visible = false;
            lblLocation.Visible = false;
            ddlLocation.Visible = false;
            //lblvalLocation.Visible = false;

            btnContinue.Visible = false;
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblCompanyCode.Text = ddlCompany.SelectedItem.Value;
        //lblvalCompany.Text = ddlCompany.SelectedItem.Value;
        FillddlHrLocation();
    }

    #endregion

    #region Functions Related to DropDown HrLocation

    /// <summary>
    /// Fillddls the hr location.
    /// </summary>
    protected void FillddlHrLocation()
    {
        var objblUserManagement = new BL.UserManagement();
        DataSet dsHrLocation = objblUserManagement.UserHRLocationAccessGet(SessionUserID, lblCompanyCode.Text);
        if (dsHrLocation.Tables[0].Rows.Count > 0)
        {
            ddlHrLocation.DataSource = dsHrLocation.Tables[0];
            ddlHrLocation.DataValueField = "HrLocationCode";
            ddlHrLocation.DataTextField = "HrLocationDesc";
            ddlHrLocation.DataBind();
            ddlHrLocation.AutoPostBack = true;

            lblHrLocation.Visible = true;
            //lblvalHrLocation.Visible = true;
            ddlHrLocation.Visible = true;
            lblErrMsg.Text = "";
            btnContinue.Visible = true;

            lblHrLocationCode.Text = ddlHrLocation.SelectedItem.Value;
            //lblvalHrLocation.Text = ddlHrLocation.SelectedItem.Value;
            FillddlLocation();
        }
        else
        {
            RemoveAccessInformationFromSession();

            //Session.Remove("LocationAutoID");
            //Session.Remove("CompanyCode");
            //Session.Remove("CompanyDesc");
            //Session.Remove("HrLocationCode");
            //Session.Remove("LocationCode");

            lblHrLocation.Visible = false;
            lblHrLocationCode.Visible = false;
            lblErrMsg.Text = Resources.Resource.NoDataToShow;

            ddlHrLocation.Visible = false;
            //lblvalHrLocation.Visible = false;

            lblLocation.Visible = false;
            lblLocation.Visible = false;
            ddlLocation.Visible = false;
            //lblvalLocation.Visible = false;
            btnContinue.Visible = false;
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlHrLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlHrLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblHrLocationCode.Text = ddlHrLocation.SelectedItem.Value;
        //lblvalHrLocation.Text = ddlHrLocation.SelectedItem.Value;
        FillddlLocation();
    }

    #endregion

    #region Functions Related to DropDown Location

    /// <summary>
    /// Fillddls the location.
    /// </summary>
    protected void FillddlLocation()
    {
        var objblUserManagement = new BL.UserManagement();
        DataSet dsLocation = objblUserManagement.UserLocationAccessGet(SessionUserID, lblCompanyCode.Text, lblHrLocationCode.Text);
        if (dsLocation.Tables[0].Rows.Count > 0)
        {
            ddlLocation.DataSource = dsLocation.Tables[0];
            ddlLocation.DataValueField = "LocationCode";
            ddlLocation.DataTextField = "LocationDesc";
            ddlLocation.DataBind();
            ddlLocation.AutoPostBack = true;

            lblLocation.Visible = true;
            //lblvalLocation.Visible = true;
            ddlLocation.Visible = true;

            lblLocationCode.Text = ddlLocation.SelectedItem.Value;
            //lblvalLocation.Text = ddlLocation.SelectedItem.Value;
            btnContinue.Visible = true;
            lblErrMsg.Text = "";

            btnContinue.Visible = true;

            SetAccessInformationToSession();

            //BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
            //DataSet ds = new DataSet();
            //ds = objblMasterManagement.LocationAutoIdGet(ddlCompany.SelectedItem.Value.ToString(), ddlHrLocation.SelectedItem.Value.ToString(), ddlLocation.SelectedItem.Value.ToString());
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Session["LocationAutoID"] = ds.Tables[0].Rows[0]["LocationAutoID"].ToString();
            //}
            //Session["CompanyCode"] = ddlCompany.SelectedItem.Value.ToString();
            //Session["HrLocationCode"] = ddlHrLocation.SelectedItem.Value.ToString();
            //Session["LocationCode"] = ddlLocation.SelectedItem.Value.ToString();

            //*************** Code added by  on 5 feb 2010 for creating new session variable ************************
            //DataSet dsPayPeriod = new DataSet();
            //dsPayPeriod = objblMasterManagement.CompanyPayPeriodGet("", ddlCompany.SelectedItem.Value.ToString(), ddlHrLocation.SelectedItem.Value.ToString(), ddlLocation.SelectedItem.Value.ToString());
            //if (dsPayPeriod != null && dsPayPeriod.Tables.Count > 0 && dsPayPeriod.Tables[0].Rows.Count > 0)
            //{
            //    Session["PayPeriodFromDay"] = dsPayPeriod.Tables[0].Rows[0]["FromDay"].ToString();
            //    Session["PayPeriodToDay"] = dsPayPeriod.Tables[0].Rows[0]["ToDay"].ToString();
            //    Session["PayPeriodMonthRange"] = dsPayPeriod.Tables[0].Rows[0]["MonthRange"].ToString();

            //}
            //else
            //{
            //    Session["PayPeriodFromDay"] = "";
            //    Session["PayPeriodToDay"] = "";
            //    Session["PayPeriodMonthRange"] = "";

            //}
        }
        else
        {
            RemoveAccessInformationFromSession();
            //Session.Remove("LocationAutoID");
            //Session.Remove("CompanyCode");
            //Session.Remove("HrLocationCode");
            //Session.Remove("LocationCode");

            lblLocation.Visible = false;
            lblLocation.Visible = false;
            lblErrMsg.Text = Resources.Resource.NoDataToShow;
            ddlLocation.Visible = false;
            //lblvalLocation.Visible = false;
            btnContinue.Visible = false;
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlLocation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblLocationCode.Text = ddlLocation.SelectedItem.Value;
        //lblvalLocation.Text = ddlLocation.SelectedItem.Value;
        btnContinue.Visible = true;

        SetAccessInformationToSession();
        //Session["CompanyCode"] = ddlCompany.SelectedItem.Value.ToString();
        //Session["CompanyDesc"] = ddlCompany.SelectedItem.Text.ToString();
        //Session["HrLocationCode"] = ddlHrLocation.SelectedItem.Value.ToString();
        //Session["LocationCode"] = ddlLocation.SelectedItem.Value.ToString();
        //BL.MastersManagement objblMasterManagement = new BL.MastersManagement();
        //DataSet ds = new DataSet();
        //ds = objblMasterManagement.LocationAutoIdGet(ddlCompany.SelectedItem.Value.ToString(), ddlHrLocation.SelectedItem.Value.ToString(), ddlLocation.SelectedItem.Value.ToString());
        //Session["LocationAutoID"] = ds.Tables[0].Rows[0]["LocationAutoID"].ToString();
    }

    #endregion

    #region Function Related to Button Continue

    /// <summary>
    /// Handles the Click event of the btnContinue control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        SetParameters();
    }

    private void SetParameters()
    {
        if (lblCompanyCode.Text != "" && lblHrLocationCode.Text != "" && lblLocationCode.Text != "" && BaseLocationAutoID != string.Empty)
        {
            if (Request.QueryString["strUserID"] == null)
            {
                var objblMasterManagement = new BL.MastersManagement();
                DataSet dsPayPeriod = objblMasterManagement.CompanyPayPeriodGet("", ddlCompany.SelectedItem.Value, ddlHrLocation.SelectedItem.Value, ddlLocation.SelectedItem.Value);
                if (dsPayPeriod != null && dsPayPeriod.Tables.Count > 0 && dsPayPeriod.Tables[0].Rows.Count > 0)
                {
                    //Session["PayPeriodFromDay"] = dsPayPeriod.Tables[0].Rows[0]["FromDay"].ToString();
                    //Session["PayPeriodToDay"] = dsPayPeriod.Tables[0].Rows[0]["ToDay"].ToString();
                    //Session["PayPeriodMonthRange"] = dsPayPeriod.Tables[0].Rows[0]["MonthRange"].ToString();
                    BaseSystemParameters.PayPeriodFromDay = dsPayPeriod.Tables[0].Rows[0]["FromDay"].ToString();
                    BaseSystemParameters.PayPeriodToDay = dsPayPeriod.Tables[0].Rows[0]["ToDay"].ToString();
                    BaseSystemParameters.PayPeriodMonthRange = dsPayPeriod.Tables[0].Rows[0]["MonthRange"].ToString();
                }
                else
                {
                    //Session["PayPeriodFromDay"] = "";
                    //Session["PayPeriodToDay"] = "";
                    //Session["PayPeriodMonthRange"] = "";
                    BaseSystemParameters.PayPeriodFromDay = string.Empty;
                    BaseSystemParameters.PayPeriodToDay = string.Empty;
                    BaseSystemParameters.PayPeriodMonthRange = string.Empty;
                }

                //code modified by   on 29-Mar-2010 for redirecting the Page to new developed Calling Page 
                var objblCommon = new BL.Common();
                if (BaseLocationAutoID != string.Empty)
                {
                    DataSet ds = objblCommon.SystemParameterDefaultCurrencyGet(BaseLocationAutoID);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        //Session["DefaultCurrency"] = ds.Tables[0].Rows[0][0].ToString();
                        BaseSystemParameters.DefaultCurrency = ds.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        //Session["DefaultCurrency"] = "INR";
                        BaseSystemParameters.DefaultCurrency = "INR";
                    }
                }
                DataSet dsCommon = objblCommon.SystemParametersGet(BaseUserID, BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);
                if (dsCommon != null && dsCommon.Tables.Count > 0 && dsCommon.Tables[0].Rows.Count > 0)
                {
                    if (dsCommon.Tables[0].Rows[0]["AutoGenerateNumberStatus"].ToString() == "" || dsCommon.Tables[0].Rows[0]["CompanyCode"].ToString() == "" || dsCommon.Tables[0].Rows[0]["HrLocationCode"].ToString() == "" || dsCommon.Tables[0].Rows[0]["LocationCode"].ToString() == "" || dsCommon.Tables[0].Rows[0]["SaleOrderDefaultNumberOfDays"].ToString() == "" || dsCommon.Tables[0].Rows[0]["SaleOrderRemainingDays"].ToString() == "" || dsCommon.Tables[0].Rows[0]["DigitsAfterDecimalPlace"].ToString() == "" || dsCommon.Tables[0].Rows[0]["RoundOffCheck"].ToString() == "" || dsCommon.Tables[0].Rows[0]["CommaAfterPlace"].ToString() == "" || dsCommon.Tables[0].Rows[0]["SchEmpMaxDutyMinInMonth"].ToString() == "" || dsCommon.Tables[0].Rows[0]["SchEmpMaxDutyMinInDay"].ToString() == "" || dsCommon.Tables[0].Rows[0]["SchMinBreakBetweenDuty"].ToString() == "" || dsCommon.Tables[0].Rows[0]["DefaultScheduleType"].ToString() == "" || dsCommon.Tables[0].Rows[0]["MonthlyScheduleType"].ToString() == "" || dsCommon.Tables[0].Rows[0]["ScheduleMonthlyFromDay"].ToString() == "0" || dsCommon.Tables[0].Rows[0]["ScheduleMonthlyToDay"].ToString() == "0" || (dsCommon.Tables[0].Rows[0]["ScheduleWeeklyFromDay"].ToString() == "0" && dsCommon.Tables[0].Rows[0]["ScheduleWeeklyStartDay"].ToString() == "" && dsCommon.Tables[0].Rows[0]["ScheduleWeeklyEndDay"].ToString() == "") || dsCommon.Tables[0].Rows[0]["SchEmpMaxDutyMin"].ToString() == "" || dsCommon.Tables[0].Rows[0]["UpdateRunningSeqStatus"].ToString() == "" || dsCommon.Tables[0].Rows[0]["ScheduleApplyPatternType"].ToString() == "")
                    {
                        //Page page = HttpContext.Current.Handler as Page;
                        Show("System Parameters not Defined !");
                        return;
                    }
                    //Session["DigitsAfterDecimalPlace"] = dsCommon.Tables[0].Rows[0]["DigitsAfterDecimalPlace"].ToString();
                    //Session["RoundOffCheck"] = dsCommon.Tables[0].Rows[0]["RoundOffCheck"].ToString();
                    //Session["CommaAfterPlace"] = dsCommon.Tables[0].Rows[0]["CommaAfterPlace"].ToString();

                    BaseSystemParameters.DigitsAfterDecimalPlaces = dsCommon.Tables[0].Rows[0]["DigitsAfterDecimalPlace"].ToString();
                    BaseSystemParameters.RoundOffCheck = dsCommon.Tables[0].Rows[0]["RoundOffCheck"].ToString();
                    BaseSystemParameters.CommaAfterPlace = dsCommon.Tables[0].Rows[0]["CommaAfterPlace"].ToString();

                    BaseSystemParameters.RotaTimeShow = dsCommon.Tables[0].Rows[0]["RotaTimeShow"].ToString();
                    BaseSystemParameters.ScheduleStartDay = dsCommon.Tables[0].Rows[0]["ScheduleWeeklyStartDay"].ToString();
                    BaseSystemParameters.ScheduleEndDay = dsCommon.Tables[0].Rows[0]["ScheduleWeeklyEndDay"].ToString();
                    BaseSystemParameters.DefaultScheduleType = dsCommon.Tables[0].Rows[0]["DefaultScheduleType"].ToString();
                    BaseUserInformation.UserEmailId = dsCommon.Tables[0].Rows[0]["USEREMAILID"].ToString();
                    BaseUserInformation.UserMobileNo = dsCommon.Tables[0].Rows[0]["USERMOBILENO"].ToString();

                    //Session["RotaTimeShow"] = dsCommon.Tables[0].Rows[0]["RotaTimeShow"].ToString();
                    //Session["ScheduleStartDay"] = dsCommon.Tables[0].Rows[0]["ScheduleWeeklyStartDay"].ToString();
                    //Session["ScheduleEndDay"] = dsCommon.Tables[0].Rows[0]["ScheduleWeeklyEndDay"].ToString();
                    //Session["DefaultScheduleType"] = dsCommon.Tables[0].Rows[0]["DefaultScheduleType"].ToString();
                    //Session["USEREMAILID"] = dsCommon.Tables[0].Rows[0]["USEREMAILID"].ToString();
                    //Session["USERMOBILENO"] = dsCommon.Tables[0].Rows[0]["USERMOBILENO"].ToString();
                    //Session["ShowRoleInAssignment"] = dsCommon.Tables[0].Rows[0]["ShowRoleInAssignment"].ToString();
                    //Session["UserIDType"] = dsCommon.Tables[0].Rows[0]["IsAdmin"].ToString(); //same as userRole - duplicate variable defined
                }
                else
                {
                    //Session["UserIDType"] = "";
                    //Page page = HttpContext.Current.Handler as Page;
                    Show("System Parameters not Defined !");
                    return;
                }
                Response.Redirect("../Admin/CallingPage.aspx");
            }

            lblErrMsg.Text = Resources.Resource.PasswordNotComply;
            lblErrMsg1.Text = Resources.Resource.PasswordChangeRedirectNow;
            Response.Redirect("ChangePasswordAdmin.aspx?strUserID=" + HFUserID.Value + "&CompanyCode=" + lblCompanyCode.Text + "&CountryCode=" + HFCountryCode.Value);
            //HtmlMeta meta = new HtmlMeta();
            //meta.HttpEquiv = "Refresh";
            //meta.Content = "5;url=ChangePasswordAdmin.aspx?strUserID=" + HFUserID.Value + "&CompanyCode=" + lblCompanyCode.Text;
            //this.Page.Controls.Add(meta);
            return;
        }
    }

    #endregion
    //private string ShowAlertMessage(string error)
    //{

    //    Page page = HttpContext.Current.Handler as Page;
    //    if (page != null)
    //    {
    //        error = error.Replace("'", "\'");
    //        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "if (confirm('" + error + "') return '" + error + "'=true else return '" + error + "' false;", true);
    //        return error;

    //    }
    //    return "ddddddd";
    //}
    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event to initialize the page.
    /// </summary>
    protected void RemoveAccessInformationFromSession()
    {
        BaseAccessInformation.CompanyCode = string.Empty;
        BaseAccessInformation.CompanyDesc = string.Empty;
        BaseAccessInformation.HrLocationCode = string.Empty;
        BaseAccessInformation.HrLocationDesc = string.Empty;
        BaseAccessInformation.LocationCode = string.Empty;
        BaseAccessInformation.LocationDesc = string.Empty;
        BaseAccessInformation.LocationAutoId = string.Empty;
    }
    protected void SetAccessInformationToSession()
    {
        var objblMasterManagement = new BL.MastersManagement();
        DataSet ds = objblMasterManagement.LocationAutoIdGet(ddlCompany.SelectedItem.Value, ddlHrLocation.SelectedItem.Value, ddlLocation.SelectedItem.Value);
        if (ds.Tables[0].Rows.Count > 0)
        {
            BaseAccessInformation.LocationAutoId = ds.Tables[0].Rows[0]["LocationAutoID"].ToString();
        }
        BaseAccessInformation.CompanyCode = ddlCompany.SelectedItem.Value;
        BaseAccessInformation.CompanyDesc = ddlCompany.SelectedItem.Text;
        BaseAccessInformation.HrLocationCode = ddlHrLocation.SelectedItem.Value;
        BaseAccessInformation.HrLocationDesc = ddlHrLocation.SelectedItem.Text;
        BaseAccessInformation.LocationCode = ddlLocation.SelectedItem.Value;
        BaseAccessInformation.LocationDesc = ddlLocation.SelectedItem.Text;
    }
}
