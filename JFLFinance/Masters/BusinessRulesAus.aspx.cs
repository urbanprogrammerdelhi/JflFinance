// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="BusinessRulesAus.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Class Masters_BusinessRulesAus
/// </summary>
public partial class Masters_BusinessRulesAus : BasePage
{
    /// <summary>
    /// Gets the session_ user ID.
    /// </summary>
    /// <value>The session_ user ID.</value>
    /// <exception cref="System.Exception">Session has expired! Login again</exception>
    protected string SessionUserID
    {
        get
        {
            try
            {
                if (BaseUserID != null)
                {
                    return BaseUserID;
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../default.aspx", "MainMasterPage_top", "");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            TabLeave.Visible = false;
            FillddlCompany();
            lblStartDate.Visible = false;
            txtStartDate.Visible = false;
            lblEndDate.Visible = false;
            txtEndDate.Visible = false;
            imgStartDate.Visible = false;
            imgEndDate.Visible = false;
            lblStartDay.Visible = true;
            ddlStartDay.Visible = true;
            lblEndDay.Visible = true;
            ddlEndDay.Visible = true;
            rbFortnightly.Checked = true;
            FillgvOTDetail();
            FillddlBR();
        }
    }
    /// <summary>
    /// Fillddls the company.
    /// </summary>
    protected void FillddlCompany()
    {
        TabLeave.Visible = false;
        ddlCompany.Items.Clear();
        DataSet dsCompany = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsCompany = objblUserManagement.UserCompanyAccessGet(SessionUserID);
        if (dsCompany.Tables[0].Rows.Count > 0)
        {
            ddlCompany.DataSource = dsCompany.Tables[0];
            ddlCompany.DataValueField = "CompanyCode";
            ddlCompany.DataTextField = "CompanyDesc";
            ddlCompany.DataBind();
            ddlCompany.AutoPostBack = true;
            FillddlDivision();
            FillddlBR();
        }
    }
    /// <summary>
    /// Fillddls the division.
    /// </summary>
    protected void FillddlDivision()
    {
        TabLeave.Visible = false;
        ddlDivision.Items.Clear();
        DataSet dsHrLocation = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsHrLocation = objblUserManagement.UserHRLocationAccessGet(SessionUserID, ddlCompany.SelectedValue);
        if (dsHrLocation.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsHrLocation.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();
            ddlDivision.AutoPostBack = true;
            FillddlBranch();
            // FillddlBR();
        }
    }
    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    protected void FillddlBranch()
    {
        TabLeave.Visible = false;
        ddlBranch.Items.Clear();
        DataSet ds = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        ds = objblUserManagement.UserLocationAccessGet(SessionUserID, ddlCompany.SelectedValue, ddlDivision.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = ds.Tables[0];
            ddlBranch.DataValueField = "LocationAutoID";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
            ddlBranch.AutoPostBack = true;
            FillddlArea();
        }
        //  FillddlBR();
    }
    /// <summary>
    /// Fillddls the area.
    /// </summary>
    protected void FillddlArea()
    {
        TabLeave.Visible = false;
        ddlArea.Items.Clear();
        DataSet ds = new DataSet();
        BL.OperationManagement objblUserManagement = new BL.OperationManagement();
        ds = objblUserManagement.AreaMasterGetAll(ddlBranch.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlArea.DataSource = ds.Tables[0];
            ddlArea.DataValueField = "AreaID";
            ddlArea.DataTextField = "AreaDesc";
            ddlArea.DataBind();
            ddlArea.AutoPostBack = true;
            FillddlClient();
        }
        // FillddlBR();
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        TabLeave.Visible = false;
        ddlClient.Items.Clear();
        DataSet ds = new DataSet();
        BL.OperationManagement objblUserManagement = new BL.OperationManagement();
        ds = objblUserManagement.ClientGetAll(ddlBranch.SelectedValue, ddlArea.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataTextField = "ClientName";
            ddlClient.DataBind();
            ddlClient.AutoPostBack = true;
        }
        ddlClient.Items.Insert(0, "All");
        //  FillddlBR();
    }
    /// <summary>
    /// Handles the SelectedIndexChange event of the ddlCompany control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlCompany_SelectedIndexChange(object sender, EventArgs e)
    {
        FillddlDivision();
        FillddlBR();
    }
    /// <summary>
    /// Handles the SelectedIndexChange event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChange(object sender, EventArgs e)
    {
        FillddlBranch();
        FillddlBR();
    }
    /// <summary>
    /// Handles the SelectedIndexChange event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChange(object sender, EventArgs e)
    {
        FillddlArea();
        FillddlBR();
    }
    /// <summary>
    /// Handles the SelectedIndexChange event of the ddlArea control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlArea_SelectedIndexChange(object sender, EventArgs e)
    {
        FillddlClient();
        FillddlBR();
    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        BL.MastersManagement obj = new BL.MastersManagement();
        ds = obj.BusinessRuleMainInsert(txtBusinessRule.Text, txtBusinessRuleDesc.Text, ddlCompany.SelectedValue, ddlDivision.SelectedValue, ddlBranch.SelectedValue, ddlArea.SelectedValue, ddlClient.SelectedValue, SessionUserID);
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() != "0")
        {
            lblerror.Text = MessageString_Get(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()));
            txtBusinessRule.Text = "";
            txtBusinessRuleDesc.Text = "";
            TabLeave.Visible = false;
        }
        else
        {
            TabLeave.Visible = true;
        }
        FillddlBR();

    }
    /// <summary>
    /// Handles the Click event of the btnSavePayPeriod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSavePayPeriod_Click(object sender, EventArgs e)
    {
        FillddlBR();
        DataSet ds = new DataSet();
        BL.MastersManagement obj = new BL.MastersManagement();
        string PayPeriodType = "";
        string StartDay = "";
        string EndDay = "";
        string StartDate = "";
        string EndDate = "";
        if (rbMonthly.Checked == true)
        {
            PayPeriodType = "MN";
            StartDate = txtStartDate.Text;
            EndDate = txtEndDate.Text;
            StartDay = "NA";
            EndDay = "NA";
        }
        else if (rbFortnightly.Checked == true)
        {
            PayPeriodType = "FR";
            StartDate = "01-01-1900";
            EndDate = "01-01-1900";
            StartDay = ddlStartDay.SelectedValue;
            EndDay = ddlEndDay.SelectedValue;
        }
        else if (rbWeekly.Checked == true)
        {
            PayPeriodType = "WK";
            StartDate = "01-01-1900";
            EndDate = "01-01-1900";
            StartDay = ddlStartDay.SelectedValue;
            EndDay = ddlEndDay.SelectedValue;
        }
        ds = obj.BusinessRulePayPeriodInsert(txtBusinessRule.Text, PayPeriodType, StartDate, EndDate, StartDay, EndDay, SessionUserID);
    }
    /// <summary>
    /// Handles the Click event of the btnSaveHrsDist control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSaveHrsDist_Click(object sender, EventArgs e)
    {
        FillddlBR();
        DataSet ds = new DataSet();
        BL.MastersManagement obj = new BL.MastersManagement();
        String NormalDays = "";

        if (chkSunday.Checked == true)
        {
            NormalDays = "Sun~";
        }
        if (chkMonday.Checked == true)
        {
            NormalDays = NormalDays + "Mon~";
        }
        if (chkTuesday.Checked == true)
        {
            NormalDays = NormalDays + "Tue~";
        }
        if (chkWednesday.Checked == true)
        {
            NormalDays = NormalDays + "Wed~";
        }
        if (chkThursday.Checked == true)
        {
            NormalDays = NormalDays + "Thu~";
        }
        if (chkFriday.Checked == true)
        {
            NormalDays = NormalDays + "Fri~";
        }
        if (chkSaturday.Checked == true)
        {
            NormalDays = NormalDays + "Sat~";
        }
        ds = obj.BusinessRuleHoursDistributionInsert(txtBusinessRule.Text, chkDaily.Checked, chkWeekly.Checked, chkFortNightly.Checked, chkMonthly.Checked, chkLeaveHrs.Checked, chkAbesnteesimHrs.Checked, txtMinHrsRqDaily.Text, txtMinHrsRqWeekly.Text, txtMinHrsRqFortNightly.Text, txtMinHrsRqMonthly.Text, txtMinHrsRqLeaveHrs.Text, txtMinHrsRqAbesnteesimHrs.Text, txtMaxHrsPrDaily.Text, txtMaxHrsPrWeekly.Text, txtMaxHrsPrFortNightly.Text, txtMaxHrsPrMonthly.Text, NormalDays, SessionUserID);
    }
    /// <summary>
    /// Handles the CheckedChange event of the rbFortNightly control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void rbFortNightly_CheckedChange(object sender, EventArgs e)
    {
        if (rbFortnightly.Checked == true)
        {
            lblStartDate.Visible = false;
            txtStartDate.Visible = false;
            lblEndDate.Visible = false;
            txtEndDate.Visible = false;
            imgStartDate.Visible = false;
            imgEndDate.Visible = false;
            lblStartDay.Visible = true;
            ddlStartDay.Visible = true;
            lblEndDay.Visible = true;
            ddlEndDay.Visible = true;

        }
    }
    /// <summary>
    /// Handles the CheckedChange event of the rbWeekly control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void rbWeekly_CheckedChange(object sender, EventArgs e)
    {
        if (rbWeekly.Checked == true)
        {
            lblStartDate.Visible = false;
            txtStartDate.Visible = false;
            lblEndDate.Visible = false;
            txtEndDate.Visible = false;
            imgStartDate.Visible = false;
            imgEndDate.Visible = false;
            lblStartDay.Visible = true;
            ddlStartDay.Visible = true;
            lblEndDay.Visible = true;
            ddlEndDay.Visible = true;

        }
    }
    /// <summary>
    /// Handles the CheckedChange event of the rbMonthly control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void rbMonthly_CheckedChange(object sender, EventArgs e)
    {
        if (rbMonthly.Checked == true)
        {
            lblStartDate.Visible = true;
            txtStartDate.Visible = true;
            lblEndDate.Visible = true;
            txtEndDate.Visible = true;
            imgStartDate.Visible = true;
            imgEndDate.Visible = true;
            lblStartDay.Visible = false;
            ddlStartDay.Visible = false;
            lblEndDay.Visible = false;
            ddlEndDay.Visible = false;
        }
    }
    /// <summary>
    /// Fillgvs the OT detail.
    /// </summary>
    protected void FillgvOTDetail()
    {

        BL.MastersManagement obj = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = obj.BusinessRuleOTDetailsGet(txtBusinessRule.Text);
        ViewState["AsmtSitePost"] = ds.Tables[0];
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    gvOTDetails.DataKeyNames = new string[] { "BusinessRuleCode" };
                    gvOTDetails.DataSource = dt;
                    gvOTDetails.DataBind();
                }
                else if (dt.Rows.Count > 0)
                {
                    gvOTDetails.DataKeyNames = new string[] { "BusinessRuleCode" };
                    gvOTDetails.DataSource = dt;
                    gvOTDetails.DataBind();
                }
            }
        }
    }
    /// <summary>
    /// Handles the RowCommad event of the gvOTDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvOTDetail_RowCommad(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtOTCode = (TextBox)gvOTDetails.FooterRow.FindControl("txtOTCode");
        TextBox txtOTRate = (TextBox)gvOTDetails.FooterRow.FindControl("txtOTRate");
        DropDownList ddlApplicableOn = (DropDownList)gvOTDetails.FooterRow.FindControl("ddlApplicableOn");

        if (e.CommandName == "Add")
        {
            BL.MastersManagement obj = new BL.MastersManagement();
            DataSet ds = new DataSet();
            ds = obj.BusinessRuleOTDetailsInsert(txtBusinessRule.Text, txtOTCode.Text, txtOTRate.Text, ddlApplicableOn.SelectedValue, SessionUserID);
            FillgvOTDetail();
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvOTDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvOTDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtOTCode = (TextBox)gvOTDetails.Rows[e.RowIndex].FindControl("txtOTCode");
        TextBox txtOTRate = (TextBox)gvOTDetails.Rows[e.RowIndex].FindControl("txtOTRate");
        DropDownList ddlApplicableOn = (DropDownList)gvOTDetails.Rows[e.RowIndex].FindControl("ddlApplicableOn");
        HiddenField hfOTDetailAutoID = (HiddenField)gvOTDetails.Rows[e.RowIndex].FindControl("hfOTDetailAutoID");
        BL.MastersManagement obj = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = obj.BusinessRuleOTDetailsUpdate(hfOTDetailAutoID.Value, txtBusinessRule.Text, txtOTCode.Text, txtOTRate.Text, ddlApplicableOn.SelectedValue, SessionUserID);
        gvOTDetails.EditIndex = -1;
        FillgvOTDetail();
    }
    /// <summary>
    /// Handles the Deleteing event of the gvOTDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvOTDetail_Deleteing(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField hfOTDetailAutoID = (HiddenField)gvOTDetails.Rows[e.RowIndex].FindControl("hfOTDetailAutoID");
        BL.MastersManagement obj = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = obj.BusinessRuleOTDetailsDelete(hfOTDetailAutoID.Value);
        FillgvOTDetail();
    }
    /// <summary>
    /// Handles the RowCanceling event of the gvOTDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvOTDetail_RowCanceling(object sender, GridViewCancelEditEventArgs e)
    {
        gvOTDetails.EditIndex = -1;
        FillgvOTDetail();
    }
    /// <summary>
    /// Handles the Click event of the btnGenratePayPeriod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnGenratePayPeriod_Click(object sender, EventArgs e)
    {
        BL.MastersManagement obj = new BL.MastersManagement();
        DataSet ds = new DataSet();
        string strPayPeriodType = string.Empty;
        if (rbMonthly.Checked == true)
        {
            strPayPeriodType = "M";
        }
        if (rbFortnightly.Checked == true)
        {
            strPayPeriodType = "F";
        }
        if (rbWeekly.Checked == true)
        {
            strPayPeriodType = "W";
        }
        ds = obj.BusinessRuleGeneratePayPeriodClientWise(ddlBranch.SelectedValue, ddlClient.SelectedValue, txtBusinessRule.Text, txtFirstDate.Text, SessionUserID, strPayPeriodType); 
    }
    /// <summary>
    /// Handles the RowEditing event of the gvOTDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvOTDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvOTDetails.EditIndex = e.NewEditIndex;
        FillgvOTDetail();
        DropDownList ddlApplicableOn = (DropDownList)gvOTDetails.Rows[e.NewEditIndex].FindControl("ddlApplicableOn");
        HiddenField hfApplicableOn = (HiddenField)gvOTDetails.Rows[e.NewEditIndex].FindControl("hfApplicableOn");
        //TextBox txtOTCode = (TextBox)gvOTDetails.Rows[e.RowIndex].FindControl("txtOTCode");
        //TextBox txtOTRate = (TextBox)gvOTDetails.Rows[e.RowIndex].FindControl("txtOTRate");
        ddlApplicableOn.SelectedValue = hfApplicableOn.Value;

    }

    /// <summary>
    /// Handles the CheckedChanged event of the chkDaily control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkDaily_CheckedChanged(object sender, EventArgs e)
    {
        ///*code modified by Manish  on 2-june-2011*/
        //if (chkDaily.Checked == true)
        //{
        //    chkMonthly.Checked = false;
        //    chkFortNightly.Checked = false;
        //    chkWeekly.Checked = false;
        //}

        ///*cpde modified by Manish  on 2-june-2011*/
    }
    /// <summary>
    /// Handles the CheckedChanged event of the chkWeekly control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkWeekly_CheckedChanged(object sender, EventArgs e)
    {
        ///*code modified by Manish  on 2-june-2011*/
        //if (chkWeekly.Checked == true)
        //{
        //    chkMonthly.Checked = false;
        //    chkFortNightly.Checked = false;
        //    chkDaily.Checked = false;
        //}

        ///*cpde modified by Manish  on 2-june-2011*/

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBR control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBR_SelectedIndexChanged(object sender, EventArgs e)
    {
        TabLeave.Visible = true;
        FillddlBRValue();
        FillgvOTDetail_Fetch();

    }
    /// <summary>
    /// Handles the Load event of the ddlBR control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBR_Load(object sender, EventArgs e)
    {
        //FillddlBR();
        //FillddlHoursDist();

    }

    /// <summary>
    /// Fillddls the BR.
    /// </summary>
    protected void FillddlBR()
    {
        lblerror.Text = "";
        ddlBR.Items.Clear();
        DataSet ds = new DataSet();
        BL.MastersManagement objblUserManagement = new BL.MastersManagement();
        ds = objblUserManagement.BusinessRuleGet(BaseCompanyCode, BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlBR.DataSource = ds.Tables[0];
            ddlBR.DataValueField = "RuleCode";
            ddlBR.DataTextField = "RuleDesc";
            ddlBR.DataBind();
            ddlBR.Items.Insert(0, "-Select-");
            ddlBR.AutoPostBack = true;

            //Attributes.Add("Select", "Select");
            //FillddlArea();
        }
    }

    /// <summary>
    /// Fillddls the BR value.
    /// </summary>
    protected void FillddlBRValue()
    {
        lblerror.Text = "";

        DataSet ds = new DataSet();
        BL.MastersManagement objblUserManagement = new BL.MastersManagement();
        ds = objblUserManagement.BusinessRuleGet(ddlBR.SelectedItem.Value.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtBusinessRule.Text = ds.Tables[0].Rows[0][0].ToString();
            txtBusinessRuleDesc.Text = ds.Tables[0].Rows[0][1].ToString();

            ddlCompany.Items.FindByText(ds.Tables[0].Rows[0][2].ToString()).Selected = true;
            ddlCompany.SelectedValue = ddlCompany.Items.FindByText(ds.Tables[0].Rows[0][2].ToString()).Value;
            FillddlDivision();
            ddlDivision.Items.FindByText(ds.Tables[0].Rows[0][3].ToString()).Selected = true;
            ddlDivision.SelectedValue = ddlDivision.Items.FindByText(ds.Tables[0].Rows[0][3].ToString()).Value;
            FillddlBranch();
            ddlBranch.Items.FindByText(ds.Tables[0].Rows[0][4].ToString()).Selected = true;
            ddlBranch.SelectedValue = ddlBranch.Items.FindByText(ds.Tables[0].Rows[0][4].ToString()).Value;
            FillddlArea();
            ddlArea.Items.FindByValue(ds.Tables[0].Rows[0][5].ToString()).Selected = true;
            FillddlClient();
            ddlClient.Items.FindByText(ds.Tables[0].Rows[0][6].ToString()).Selected = true;
        }
        TabLeave.Visible = true;
        if (ds.Tables[1].Rows.Count > 0)
        {


            if (ds.Tables[1].Rows[0][0].ToString() == "FR")
            { rbFortnightly.Checked = true; }

            if (ds.Tables[1].Rows[0][0].ToString() == "MN")
            { rbMonthly.Checked = true; }

            if (ds.Tables[1].Rows[0][0].ToString() == "WK")
            { rbWeekly.Checked = true; }

            txtStartDate.Text = ds.Tables[1].Rows[0][1].ToString();
            txtEndDate.Text = ds.Tables[1].Rows[0][2].ToString();
            if (ds.Tables[1].Rows[0][3].ToString() != "")
            {
                ddlStartDay.Text = ds.Tables[1].Rows[0][3].ToString();
                //ddlStartDay.Items.FindByText(ds.Tables[1].Rows[0][3].ToString()).Selected = true;
            }//ds.Tables[1].Rows[0][3].ToString();
            if (ds.Tables[1].Rows[0][4].ToString() != "" )
            {
                ddlEndDay.Text = ds.Tables[1].Rows[0][4].ToString();
            }
            txtPayPeriod.Text = ds.Tables[1].Rows[0][5].ToString();
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            chkDaily.Checked = bool.Parse(ds.Tables[2].Rows[0][0].ToString());
            chkWeekly.Checked = bool.Parse(ds.Tables[2].Rows[0][1].ToString());
            chkFortNightly.Checked = bool.Parse(ds.Tables[2].Rows[0][2].ToString());
            chkMonthly.Checked = bool.Parse(ds.Tables[2].Rows[0][3].ToString());
            chkLeaveHrs.Checked = bool.Parse(ds.Tables[2].Rows[0][4].ToString());
            chkAbesnteesimHrs.Checked = bool.Parse(ds.Tables[2].Rows[0][5].ToString());
            txtMinHrsRqDaily.Text = ds.Tables[2].Rows[0][6].ToString();
            txtMinHrsRqWeekly.Text = ds.Tables[2].Rows[0][7].ToString();
            txtMinHrsRqFortNightly.Text = ds.Tables[2].Rows[0][8].ToString();
            txtMinHrsRqMonthly.Text = ds.Tables[2].Rows[0][9].ToString();
            txtMinHrsRqLeaveHrs.Text = ds.Tables[2].Rows[0][10].ToString();
            txtMinHrsRqAbesnteesimHrs.Text = ds.Tables[2].Rows[0][11].ToString();

            txtMaxHrsPrDaily.Text = ds.Tables[2].Rows[0][12].ToString();
            txtMaxHrsPrWeekly.Text = ds.Tables[2].Rows[0][13].ToString();
            txtMaxHrsPrFortNightly.Text = ds.Tables[2].Rows[0][14].ToString();
            txtMaxHrsPrMonthly.Text = ds.Tables[2].Rows[0][15].ToString();

            if (ds.Tables[2].Rows[0][16].ToString() == "Sun")
            { chkSunday.Checked = true; }
            if (ds.Tables[2].Rows[0][16].ToString() == "Mon")
            { chkMonday.Checked = true; }
            if (ds.Tables[2].Rows[0][16].ToString() == "Tue")
            { chkTuesday.Checked = true; }
            if (ds.Tables[2].Rows[0][16].ToString() == "Wed")
            { chkWednesday.Checked = true; }
            if (ds.Tables[2].Rows[0][16].ToString() == "Thu")
            { chkThursday.Checked = true; }
            if (ds.Tables[2].Rows[0][16].ToString() == "Fri")
            { chkFriday.Checked = true; }
            if (ds.Tables[2].Rows[0][16].ToString() == "Sat")
            { chkSaturday.Checked = true; }

            if (ds.Tables[2].Rows[0][17].ToString() == "Sun")
            { chkSunday.Checked = true; }
            if (ds.Tables[2].Rows[0][17].ToString() == "Mon")
            { chkMonday.Checked = true; }
            if (ds.Tables[2].Rows[0][17].ToString() == "Tue")
            { chkTuesday.Checked = true; }
            if (ds.Tables[2].Rows[0][17].ToString() == "Wed")
            { chkWednesday.Checked = true; }
            if (ds.Tables[2].Rows[0][17].ToString() == "Thu")
            { chkThursday.Checked = true; }
            if (ds.Tables[2].Rows[0][17].ToString() == "Fri")
            { chkFriday.Checked = true; }
            if (ds.Tables[2].Rows[0][17].ToString() == "Sat")
            { chkSaturday.Checked = true; }

            if (ds.Tables[2].Rows[0][18].ToString() == "Sun")
            { chkSunday.Checked = true; }
            if (ds.Tables[2].Rows[0][18].ToString() == "Mon")
            { chkMonday.Checked = true; }
            if (ds.Tables[2].Rows[0][18].ToString() == "Tue")
            { chkTuesday.Checked = true; }
            if (ds.Tables[2].Rows[0][18].ToString() == "Wed")
            { chkWednesday.Checked = true; }
            if (ds.Tables[2].Rows[0][18].ToString() == "Thu")
            { chkThursday.Checked = true; }
            if (ds.Tables[2].Rows[0][18].ToString() == "Fri")
            { chkFriday.Checked = true; }
            if (ds.Tables[2].Rows[0][18].ToString() == "Sat")
            { chkSaturday.Checked = true; }

            if (ds.Tables[2].Rows[0][19].ToString() == "Sun")
            { chkSunday.Checked = true; }
            if (ds.Tables[2].Rows[0][19].ToString() == "Mon")
            { chkMonday.Checked = true; }
            if (ds.Tables[2].Rows[0][19].ToString() == "Tue")
            { chkTuesday.Checked = true; }
            if (ds.Tables[2].Rows[0][19].ToString() == "Wed")
            { chkWednesday.Checked = true; }
            if (ds.Tables[2].Rows[0][19].ToString() == "Thu")
            { chkThursday.Checked = true; }
            if (ds.Tables[2].Rows[0][19].ToString() == "Fri")
            { chkFriday.Checked = true; }
            if (ds.Tables[2].Rows[0][19].ToString() == "Sat")
            { chkSaturday.Checked = true; }

            if (ds.Tables[2].Rows[0][20].ToString() == "Sun")
            { chkSunday.Checked = true; }
            if (ds.Tables[2].Rows[0][20].ToString() == "Mon")
            { chkMonday.Checked = true; }
            if (ds.Tables[2].Rows[0][20].ToString() == "Tue")
            { chkTuesday.Checked = true; }
            if (ds.Tables[2].Rows[0][20].ToString() == "Wed")
            { chkWednesday.Checked = true; }
            if (ds.Tables[2].Rows[0][20].ToString() == "Thu")
            { chkThursday.Checked = true; }
            if (ds.Tables[2].Rows[0][20].ToString() == "Fri")
            { chkFriday.Checked = true; }
            if (ds.Tables[2].Rows[0][20].ToString() == "Sat")
            { chkSaturday.Checked = true; }

            if (ds.Tables[2].Rows[0][21].ToString() == "Sun")
            { chkSunday.Checked = true; }
            if (ds.Tables[2].Rows[0][21].ToString() == "Mon")
            { chkMonday.Checked = true; }
            if (ds.Tables[2].Rows[0][21].ToString() == "Tue")
            { chkTuesday.Checked = true; }
            if (ds.Tables[2].Rows[0][21].ToString() == "Wed")
            { chkWednesday.Checked = true; }
            if (ds.Tables[2].Rows[0][21].ToString() == "Thu")
            { chkThursday.Checked = true; }
            if (ds.Tables[2].Rows[0][21].ToString() == "Fri")
            { chkFriday.Checked = true; }
            if (ds.Tables[2].Rows[0][21].ToString() == "Sat")
            { chkSaturday.Checked = true; }

            if (ds.Tables[2].Rows[0][22].ToString() == "Sun")
            { chkSunday.Checked = true; }
            if (ds.Tables[2].Rows[0][22].ToString() == "Mon")
            { chkMonday.Checked = true; }
            if (ds.Tables[2].Rows[0][22].ToString() == "Tue")
            { chkTuesday.Checked = true; }
            if (ds.Tables[2].Rows[0][22].ToString() == "Wed")
            { chkWednesday.Checked = true; }
            if (ds.Tables[2].Rows[0][22].ToString() == "Thu")
            { chkThursday.Checked = true; }
            if (ds.Tables[2].Rows[0][22].ToString() == "Fri")
            { chkFriday.Checked = true; }
            if (ds.Tables[2].Rows[0][22].ToString() == "Sat")
            { chkSaturday.Checked = true; }
        }

    }

    /// <summary>
    /// Fillgvs the OT detail_ fetch.
    /// </summary>
    protected void FillgvOTDetail_Fetch()
    {

        BL.MastersManagement obj = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = obj.BusinessRuleOTDetailsGet(ddlBR.SelectedItem.Value.ToString());
        ViewState["AsmtSitePost"] = ds.Tables[0];
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add(dt.NewRow());
                    gvOTDetails.DataKeyNames = new string[] { "BusinessRuleCode" };
                    gvOTDetails.DataSource = dt;
                    gvOTDetails.DataBind();
                }
                else if (dt.Rows.Count > 0)
                {
                    gvOTDetails.DataKeyNames = new string[] { "BusinessRuleCode" };
                    gvOTDetails.DataSource = dt;
                    gvOTDetails.DataBind();
                }
            }
        }
    }


    /// <summary>
    /// Handles the Click event of the btnClose control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnClose_Click(object sender, EventArgs e)
    {
        BL.MastersManagement obj = new BL.MastersManagement();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds = obj.BusinessRuleDelete(ddlBR.SelectedItem.Value.ToString());
        FillddlBR();
        txtBusinessRule.Text = "";
        txtBusinessRuleDesc.Text = "";
        FillddlCompany();

        lblerror.Text = MessageString_Get(int.Parse(ds.Tables[0].Rows[0][0].ToString()));
        TabLeave.Visible = false;
    }
}
