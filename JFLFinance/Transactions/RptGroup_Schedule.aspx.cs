// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-25-2014
// ***********************************************************************
// <copyright file="RptGroup_Schedule.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;
using Common = DL.Common;
using Resource = Resources.Resource;

/// <summary>
/// Class Sales_RptGroup_Schedule.
/// </summary>
public partial class Sales_RptGroup_Schedule : BasePage
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
                var virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString(CultureInfo.InvariantCulture));
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString(CultureInfo.InvariantCulture));
                return IsWriteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString(CultureInfo.InvariantCulture));
                return IsModifyAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString(CultureInfo.InvariantCulture));
                return IsDeleteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion

    //
    #region Page Functions
    /// <summary>
    /// Function used to call on Page Load Event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID + "');";
                ImgAsOnDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtAsOnDate.ClientID + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                txtAsOnDate.Attributes.Add("readonly", "readonly");
                txtDayStartTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtDayStartTime.ClientID + "');";
                txtDayStartTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtDayStartTime.ClientID + "');";

                txtDayEndTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtDayEndTime.ClientID + "');";
                txtDayEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtDayEndTime.ClientID + "');";

                txtNightStartTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtNightStartTime.ClientID + "');";
                txtNightStartTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtNightStartTime.ClientID + "');";

                txtNightEndTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtNightEndTime.ClientID + "');";
                txtNightEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtNightEndTime.ClientID + "');";

                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();
                txtAsOnDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                FillddlReportName();
                FillDivision();
                FillBranch();
                FillddlClient();
                FillDDlAreaId();
                FillDDlShift();
                FillShiftTimeFromTo();
                btnViewReport.Enabled = true;

                ViewState["MonthChangeStatus"] = 0;
                ViewState["MonthChangeStatus2"] = 0;

                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }
                ShowHideReportParameterControles();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Function used to fill Report Name in ReportName Drop Down List.
    /// </summary>
    private void FillddlReportName()
    {
        var li = new ListItem { Text = Resource.EmployeeWiseSchdule, Value = @"schempwise.rpt" };
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resource.assignWiseSchedule, Value = @"schasmtwise.rpt" };
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resource.PostingSheet, Value = @"Postingsheet.rpt" };
        ddlReportName.Items.Add(li);

        //li = new ListItem { Text = Resource.WeeklyScheduleReport, Value = @"rpt_ActualSchedule_AsmtWise.rpt1" };
        //ddlReportName.Items.Add(li);

        //li = new ListItem
        //{
        //    Text = Resource.MonthlyScheduleReport,
        //    Value = @"rpt_ActualSchedule_AsmtWise.rpt2"
        //};
        //ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resource.UnscheduledEmployees, Value = @"UnscheduledEmployees" };
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resource.BarredEmployees, Value = @"BarredEmployees" };
        ddlReportName.Items.Add(li);


        li = new ListItem { Text = Resource.WeeklyRest, Value = @"WeeklyRest" };
        ddlReportName.Items.Add(li);


        //li = new ListItem { Text = Resource.EmployeeConstraint, Value = @"EmployeeConstraint" };
        //ddlReportName.Items.Add(li);
        //li = new ListItem { Text = Resource.ClientConstraints, Value = @"CustomerConstraint" };
        //ddlReportName.Items.Add(li);


        if (BaseCountryName.Trim().ToLower() == "Israel".Trim().ToLower())
        {
            li = new ListItem { Text = Resource.rptWeeklyPosting, Value = @"WeeklyPostingSheetISRN.rpt" };
            ddlReportName.Items.Add(li);

            li = new ListItem { Text = Resource.WeeklyPostingIsrael, Value = @"PostingSheetIsrael.rpt" };
            ddlReportName.Items.Add(li);
        }
        else
        {
            li = new ListItem { Text = Resource.rptWeeklyPosting, Value = @"WeeklyPostingSheet.rpt" };
            ddlReportName.Items.Add(li);

            #region Added New Report Posting Sheet Consolidate by  on 13-Mar-14
            //Added New Report Posting Sheet Consolidate by  on 13-Mar-14
            li = new ListItem { Text = Resource.WeeklyPostingConsolidate, Value = @"WeeklyPostingSheetConsolidate.rpt" };
            ddlReportName.Items.Add(li);
            #endregion
        }

        if (BaseCountryName.Trim().ToLower() == "Barbados".Trim().ToLower())
        {
            li = new ListItem { Text = Resource.rptAvailPersonnel, Value = @"availpersonnel_Barbados.rpt" };
            ddlReportName.Items.Add(li);
        }

        if (BaseCountryName.Trim().ToLower() == "Greece".Trim().ToLower())
        {
            li = new ListItem { Text = Resource.rptAvailPersonnel, Value = @"availpersonnel_Greece.rpt" };
            ddlReportName.Items.Add(li);
        }

        if (BaseCountryName.Trim().ToLower() == "Greece".Trim().ToLower())
        {
            li = new ListItem { Text = Resource.rptAvailPersonnel, Value = @"availpersonnel_Greece.rpt" };
            ddlReportName.Items.Add(li);
        }
    }

    /// <summary>
    /// Fillddls the name of the employee.
    /// </summary>
    private void FillddlEmployeeName()
    {
        var objHrManagement = new HRManagement();

        using (var ds = objHrManagement.EmployeesOfLocationAreaWiseGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, txtFromDate.Text, txtToDate.Text, "ALL", BaseUserEmployeeNumber, "0"))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].DefaultView.Sort = "EmployeeNumber ASC";
                ddlEmployeeNumber.DataSource = ds.Tables[0].DefaultView;

                ddlEmployeeNumber.DataTextField = "EmployeeName";
                ddlEmployeeNumber.DataValueField = "EmployeeNumber";
                ddlEmployeeNumber.DataBind();

                var li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"All" };
                ddlEmployeeNumber.Items.Insert(0, li2);
                ddlEmployeeNumber.SelectedIndex = 0;

            }
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {

        var objSales = new Sales();
        using (var ds = BaseIsAdmin.Trim().ToLower() == "c" ? objSales.ClientGet(BaseLocationAutoID, BaseUserID) : objSales.ClientsLocationWiseGet(BaseLocationAutoID))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientNameCode";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();
                var li1 = new ListItem { Text = Resource.All, Value = @"ALL" };
                ddlClientCode.Items.Insert(0, li1);
                FillddlAsmt();
            }
        }
    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        var objblUserManagement = new UserManagement();
        using (var dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue))
        {
            if (dsBranch.Tables[0].Rows.Count > 0)
            {
                ddlBranch.DataSource = dsBranch.Tables[0];
                ddlBranch.DataValueField = "LocationCode";
                ddlBranch.DataTextField = "LocationDesc";
                ddlBranch.DataBind();
                var li = new ListItem { Text = Resource.All, Value = @"ALL" };
                ddlBranch.Items.Insert(0, li);
            }
        }
    }
    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision()
    {
        var objblUserManagement = new UserManagement();
        using (var dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode))
        {
            if (dsDivision.Tables[0].Rows.Count > 0)
            {
                ddlDivision.DataSource = dsDivision.Tables[0];
                ddlDivision.DataValueField = "HrLocationCode";
                ddlDivision.DataTextField = "HrLocationDesc";
                ddlDivision.DataBind();
                FillBranch();
            }
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    private void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();

        var strClientCode = ddlClientCode.SelectedItem.Value == @"ALL" ? "" : ddlClientCode.SelectedItem.Value;

        if (ddlReportName.SelectedValue == "DailyPostingSheet.rpt" || ddlReportName.SelectedValue == "DailyDispositionSheet.rpt")
        {
            strClientCode = "ALL";
            txtFromDate.Text = txtAsOnDate.Text;
            txtToDate.Text = txtAsOnDate.Text;
        }

        var objOperationManagement = new OperationManagement();

        if (ddlClientCode.SelectedValue == "All")
        {
            var li = new ListItem { Text = Resource.All, Value = @"All" };
            ddlAsmtCode.Items.Insert(0, li);
        }
        else
        {
            using (var dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, ""))
            {
                if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
                {
                    ddlAsmtCode.DataSource = dsAsmt.Tables[0];
                    ddlAsmtCode.DataTextField = "AsmtDetail";
                    ddlAsmtCode.DataValueField = "AsmtCode";
                    ddlAsmtCode.DataBind();

                    var li1 = new ListItem { Text = Resource.All, Value = @"ALL" };
                    ddlAsmtCode.Items.Insert(0, li1);
                }
                else
                {
                    var li1 = new ListItem { Text = Resource.NoDataToShow, Value = @"-1" };
                    ddlAsmtCode.Items.Insert(0, li1);
                }
            }
        }
        FillDdlPost();
    }

    /// <summary>
    /// Fills the DDL client post.
    /// </summary>
    private void FillDdlClientPost()
    {
        DDLClientDetail.Items.Clear();
        var objSales = new Sales();
        using (var ds = objSales.ClientAreaInchargeWiseGet(BaseLocationAutoID, DDLAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, BaseLocationCode, txtFromDate.Text, txtToDate.Text))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DDLClientDetail.DataSource = ds;
                DDLClientDetail.DataTextField = "ClientNameCode";
                DDLClientDetail.DataValueField = "ClientCode";
                DDLClientDetail.DataBind();

                var li1 = new ListItem { Text = Resource.All, Value = @"ALL" };
                DDLClientDetail.Items.Insert(0, li1);
                DDLClientDetail.SelectedIndex = 0;
            }
            else
            {
                var li1 = new ListItem { Text = Resource.NoDataToShow, Value = @"-1" };
                DDLClientDetail.Items.Insert(0, li1);
            }
        }
        FillddlAsmtPost();
    }
    /// <summary>
    /// Fillddls the asmt post.
    /// </summary>
    private void FillddlAsmtPost()
    {
        var strClientCode = DDLClientDetail.SelectedValue == "ALL" ? "" : DDLClientDetail.SelectedValue;
        var strAreaId = DDLAreaID.SelectedValue == "ALL" ? "" : DDLAreaID.SelectedValue;
        var objOperationManagement = new OperationManagement();
        DDLAsmtID.Items.Clear();

        if (DDLClientDetail.SelectedValue == "ALL")
        {
            var li = new ListItem { Text = Resource.All, Value = @"All" };
            DDLAsmtID.Items.Insert(0, li);
        }
        else
        {
            DDLAsmtID.DataSource = objOperationManagement.AssignmentGet(BaseLocationAutoID, strClientCode, strAreaId);
            DDLAsmtID.DataTextField = "AsmtNameCode";
            DDLAsmtID.DataValueField = "AsmtCode";
            DDLAsmtID.DataBind();

            var li = new ListItem { Text = Resource.All, Value = @"ALL" };
            DDLAsmtID.Items.Insert(0, li);
            DDLAsmtID.SelectedIndex = 0;
        }

        FillDDlShift();
    }
    /// <summary>
    /// Fills the d dl area identifier.
    /// </summary>
    private void FillDDlAreaId()
    {
        DDLAreaID.Items.Clear();
        var objOps = new OperationManagement();
        using (var ds = objOps.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DDLAreaID.DataSource = ds;
                DDLAreaID.DataTextField = "AreaDesc";
                DDLAreaID.DataValueField = "AreaID";
                DDLAreaID.DataBind();
            }
        }

        var li = new ListItem { Text = @"All", Value = @"All" };
        DDLAreaID.Items.Insert(0, li);

        FillDdlClientPost();
        FillddlAsmtPost();
        FillddlEmployeeName();
    }
    /// <summary>
    /// Fills the d dl shift.
    /// </summary>
    private void FillDDlShift()
    {
        ddlShift.Items.Clear();

        var objOps = new OperationManagement();
        using (var ds = objOps.ShiftOnAsmtOfClientGet(BaseLocationAutoID, DDLClientDetail.SelectedItem.Value, DDLAsmtID.SelectedItem.Value))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlShift.DataSource = ds;
                ddlShift.DataTextField = "Shift";
                ddlShift.DataValueField = "Shift";
                ddlShift.DataBind();
            }
        }
        var li2 = new ListItem { Text = Resource.All, Value = @"ALL" };
        ddlShift.Items.Insert(0, li2);

        var li3 = new ListItem { Text = @"0", Value = @"0" };
        ddlShift.Items.Insert(1, li3);
        ddlShift.SelectedIndex = 0;


    }


    /// <summary>
    /// Fills the DDL post.
    /// </summary>
    private void FillDdlPost()
    {
        DDLPost.Items.Clear();
        var objMasterManagement = new MastersManagement();
        using (var ds = objMasterManagement.AsmtPostGet(BaseLocationAutoID, BaseUserEmployeeNumber, DDLAreaID.SelectedValue, ddlClientCode.SelectedValue, ddlAsmtCode.SelectedItem.Value))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DDLPost.DataSource = ds.Tables[0];
                DDLPost.DataTextField = "Site";
                DDLPost.DataValueField = "Site";
                DDLPost.DataBind();
            }
        }
        var li2 = new ListItem { Text = Resource.All, Value = @"ALL" };
        DDLPost.Items.Insert(0, li2);

    }
    /// <summary>
    /// Fills the shift time from to.
    /// </summary>
    private void FillShiftTimeFromTo()
    {

        var objMasterManagement = new MastersManagement();
        using (var ds = objMasterManagement.StandardSiftsGet(BaseLocationAutoID, DDLShiftCode.SelectedValue))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var dt = ds.Tables[0];
                TxtTimeFrom.Text = dt.Rows[0]["TimeFrom"].ToString();
                TxtTimeTo.Text = dt.Rows[0]["TimeTo"].ToString();
            }
        }
    }


    #endregion

    #region Controles Events

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillDdlPost();

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLClientDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLClientDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmtPost();
        FillDDlShift();
    }
    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the DDLAsmtID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLAsmtID_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDlShift();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDdlClientPost();
        FillDDlShift();
        FillddlEmployeeName();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtFromDate, lblErrorMsg))
        {
            btnViewReport.Enabled = true;
            if (ddlReportName.SelectedItem.Value == @"WeeklyPostingSheet.rpt" || ddlReportName.SelectedItem.Value == @"Weeklyscheduleroster.rpt" || ddlReportName.SelectedItem.Value == @"WeeklyPostingSheetISRN.rpt")
            {
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
            }
            else
            {
                txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
            }
        }
        else
        {
            btnViewReport.Enabled = false;
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        btnViewReport.Enabled = ConvertStringToDateFormat(txtToDate, lblErrorMsg);
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideReportParameterControles();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBranch();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt();
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLShiftCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLShiftCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillShiftTimeFromTo();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtAsOnDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAsOnDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtAsOnDate, lblErrorMsg);
    }

    /// <summary>
    /// Function used to Show Hide Report Input Parameter
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        var strReportName = ddlReportName.SelectedItem.Value;
        if (strReportName == "rpt_ActualSchedule_AsmtWise.rpt1" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt2" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt3" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt4")
        {
            strReportName = "rpt_ActualSchedule_AsmtWise.rpt";
        }
        HideAllControles();
        switch (strReportName)
        {
            case "schempwise.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                break;

            case "schasmtwise.rpt":
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelDates.Visible = true;
                break;

            case "Postingsheet.rpt":
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelShift.Visible = true;
                PanelAreaID.Visible = true;
                PanelSource.Visible = true;
                break;

            case "WeeklyPostingSheet.rpt":
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelShift.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                break;

            //Added New Report Weekly Posting Sheet Consolidate by  on 13-Mar-14
            case "WeeklyPostingSheetConsolidate.rpt":
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelShift.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                //Added New Panel for Weekly Postingsheet Consolidate Postwise by  on 24-Mar-2014
                PanelGroupOnPost.Visible = true;
                break;
            //Manish Added new report for Israel.    
            case "WeeklyPostingSheetISRN.rpt":
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelShift.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                //Manish 18-12-2012
                PanelGropOnShift.Visible = true;
                break;

            case "Actualvsschedule.rpt":
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                PanelAsmt.Visible = true;
                PanelScheduleType.Visible = true;
                break;

            case "leaveconfliction.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelDates.Visible = true;
                break;

            case "deploymentexception.rpt":
                PanelHours.Visible = true;
                PanelOption.Visible = true;
                PanelDates.Visible = true;
                break;
            case "mismatch.rpt":
                PanelDates.Visible = true;
                break;

            case "siteroster.rpt":
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                PanelAsmt.Visible = true;
                break;

            case "Personnelroster.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                break;

            case "availpersonnel_Greece.rpt":
                PanelDates.Visible = true;
                break;

            case "availpersonnel_Barbados.rpt":
                PanelAsOnDate.Visible = true;
                PanelLAType.Visible = true;
                PanelShiftCode.Visible = true;
                PanelOptAvailPersonnel.Visible = true;
                PanelShiftTimeFromTo.Visible = true;
                break;

            case "ManpowerDetails.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelDayShift.Visible = true;
                PanelNightShift.Visible = true;
                break;

            case "Weeklyscheduleroster.rpt":
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                PanelAsmt.Visible = true;
                PanelDates.Visible = true;
                break;

            case "DailyPostingSheet.rpt":
                PanelAsmt.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelPost.Visible = true;
                break;
            case "DailyDispositionSheet.rpt":
                PanelAsmt.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelPost.Visible = true;
                PanelDayShift.Visible = false;
                PanelNightShift.Visible = false;
                pnlShiftType.Visible = true;
                PanelShiftTimeFromTo.Visible = false;
                break;

            case @"rpt_ActualSchedule_AsmtWise.rpt":
                PanelAreaIncharge.Visible = true;
                PanelAreaID1.Visible = true;
                PanelClientCode1.Visible = true;
                PanelAsmtID1.Visible = true;
                PanelDates.Visible = true;
                PanelReportGrid.Visible = true;
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                ddlDivision1.Items.Clear();
                ddlBranch1.Items.Clear();
                FillddlAreaInchargeDetails();
                break;

            case "UnscheduledEmployees":
                PanelDivision1.Visible = true;
                PanelBranch1.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID1.Visible = true;
                PanelDates.Visible = true;
                PanelRosterOrSchedule.Visible = true;
                FillDivision1();
                FillddlAreaInchargeDetails();
                break;

            case "BarredEmployees":
                PanelBranch1.Visible = true;
                PanelAreaID1.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelEmployee1.Visible = true;
                PanelDivision1.Visible = true;
                FillDivision1();
                FillddlAreaInchargeDetails();
                break;


            case "WeeklyRest":
                PanelBranch1.Visible = true;
                PanelAreaID1.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelEmployee1.Visible = true;
                Panelrest.Visible = true;
                PanelDivision1.Visible = true;
                PanelWeek.Visible = true;
                FillDivision1();
                FillddlAreaInchargeDetails();
                txtYear1.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
                txtYear2.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
                FillparameterBasedOnWeeklyRest();
                break;

            case "EmployeeConstraint":
                PanelDivision1.Visible = true;
                PanelBranch1.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID1.Visible = true;
                PanelEmployee1.Visible = true;
                PnlConstraint.Visible = true;
                PnlIdType.Visible = true;
                PnlLang.Visible = true;
                PnlQual.Visible = true;
                PnlSkill.Visible = true;
                pnlTraining.Visible = true;
                FillDivision1();
                FillddlAreaInchargeDetails();
                //FillAllTrainings();
                //FillAllConstraint();
                //FillAllIdType();
                //FillAllLanguage();
                //FillAllQualification();
                //FillAllSkill();

                break;

            case "CustomerConstraint":
                PanelDivision1.Visible = true;
                PanelBranch1.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID1.Visible = true;
                PanelClientCode1.Visible = true;
                PanelAsmtID1.Visible = true;
                PanelPost1.Visible = true;
                PnlIsMandatory.Visible = true;
                pnlTraining.Visible = true;
                 FillDivision1();
                FillddlAreaInchargeDetails();
                break;


            case "PostingSheetIsrael.rpt":
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelDates.Visible = true;
                PanelShift.Visible = true;
                PanelAreaID.Visible = true;
                PanelGroupOnPost.Visible = true;
                break;
        }
    }
    /// <summary>
    /// Hides all controles.
    /// </summary>
    private void HideAllControles()
    {
        PanelShift.Visible = false;
        PanelDates.Visible = false;
        PanelClientCode.Visible = false;
        PanelAsOnDate.Visible = false;
        PanelEmployee.Visible = false;
        PanelAsmt.Visible = false;
        PanelClientDetail.Visible = false;
        PanelAsmtId.Visible = false;
        PanelSource.Visible = false;
        PanelScheduleType.Visible = false;
        PanelDivision.Visible = false;
        PanelBranch.Visible = false;
        PanelHours.Visible = false;
        PanelOption.Visible = false;
        PanelLAType.Visible = false;
        PanelShiftCode.Visible = false;
        PanelDayShift.Visible = false;
        PanelNightShift.Visible = false;
        PanelOptAvailPersonnel.Visible = false;
        PanelShiftTimeFromTo.Visible = false;
        PanelPost.Visible = false;
        pnlShiftType.Visible = false;
        //Manish 18-12-2012
        PanelGropOnShift.Visible = false;
        PanelAreaID.Visible = false;
        PanelGroupOnPost.Visible = false;

        PanelAreaIncharge.Visible = false;
        PanelAreaID1.Visible = false;
        PanelClientCode1.Visible = false;
        PanelAsmtID1.Visible = false;
        PanelReportGrid.Visible = false;
        PanelDivision1.Visible = false;
        PanelBranch1.Visible = false;
        PanelRosterOrSchedule.Visible = false;
        PanelEmployee1.Visible = false;
        Panelrest.Visible = false;
        PanelWeek.Visible = false;
        PnlConstraint.Visible = false;
        PnlIdType.Visible = false;
        PnlLang.Visible = false;
        PnlQual.Visible = false;
        PnlSkill.Visible = false;
        pnlTraining.Visible = false;
        PanelPost1.Visible = false;
        PnlIsMandatory.Visible = false;
        pnlTraining.Visible = false;


    }
    #endregion

    #region Function Button event
    /// <summary>
    /// Function called on Button View Report Click Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        var strRptName = ddlReportName.SelectedValue;

        var strReportGridExport = ddlReportGrid.SelectedItem.Value;
        if (strRptName == "rpt_ActualSchedule_AsmtWise.rpt1" || strRptName == "rpt_ActualSchedule_AsmtWise.rpt2" || strRptName == "rpt_ActualSchedule_AsmtWise.rpt3" || strRptName == "rpt_ActualSchedule_AsmtWise.rpt4")
        {
            strRptName = "rpt_ActualSchedule_AsmtWise.rpt";
        }

        if (chkShiftGroping.Checked && ddlReportName.SelectedItem.Value == @"WeeklyPostingSheetISRN.rpt")
        {

            strRptName = "WeeklyPostingSheetISRNShiftwise.rpt";
        }

        //Added New Panel for Weekly Posting Sheet Consolidate Postwise by  on 24-Mar-2014
        if (chkPostGroping.Checked && ddlReportName.SelectedItem.Value == @"WeeklyPostingSheetConsolidate.rpt")
        {
            strRptName = @"WeeklyPostingSheetConsolidatePostWise.rpt";
        }

        if (!ValidateControles(strRptName)) return;
        const string strReportPagePath = "../Reports/Rostering/";
        Context.Items.Add("cxtReportFileName", strRptName);
        Context.Items.Add("cxtReportGridExport", strReportGridExport);
        var hshRptParameters = ReportParameter_Get(ddlReportName.SelectedValue);
        Context.Items.Add("cxtHashParameters", hshRptParameters);
        Context.Items.Add("cxtReportID", "ReportID");
        Context.Items.Add("cxtReportPagePath", strReportPagePath);
        Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Schedule.aspx?ReportName=" + ddlReportName.SelectedValue;

         if (
            (ddlReportName.SelectedItem.Text == Resource.WeeklyScheduleReport
             || ddlReportName.SelectedItem.Text == Resource.MonthlyScheduleReport
             || ddlReportName.SelectedItem.Text == Resource.WeeklyActualReport
             || ddlReportName.SelectedItem.Text == Resource.MonthlyActualReport
                )
            && ddlReportGrid.SelectedItem.Value == @"Grid"
            )
        {
            Context.Items.Remove("cxtHashParameters");
            Session["cxtHashParameters"] = hshRptParameters;

            Server.Transfer("../Transactions/AsmtWiseSchAct.aspx?ReportName=" + ddlReportName.SelectedItem.Text);
        }
        else switch (ddlReportName.SelectedItem.Value)
        {
            case @"UnscheduledEmployees":
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                Server.Transfer("../Transactions/UnscheduledEmployeesRpt.aspx");
                break;
            case @"EmployeeConstraint":
                if (ddlEmployeeNumber.SelectedValue != string.Empty)
                {
                    Context.Items.Remove("cxtHashParameters");
                    Session["cxtHashParameters"] = hshRptParameters;
                    Server.Transfer("../Transactions/ConstraintGridReport.aspx");
                }
                break;
            case @"CustomerConstraint":
                if (ddlClientCode.SelectedValue != @"-1" || ddlClientCode.SelectedValue != string.Empty)
                {
                    Context.Items.Remove("cxtHashParameters");
                    Session["cxtHashParameters"] = hshRptParameters;
                    Server.Transfer("../Transactions/ConstraintGridReport.aspx");
                }
                break;
            case @"BarredEmployees":
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                Server.Transfer("../Transactions/BarredEmployees.aspx?");
                break;
            case @"WeeklyRest":
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                Server.Transfer("../Transactions/WeeklyRest.aspx?");
                break;
            default:
                Server.Transfer("../Reports/ViewReport1.aspx");
                break;

        }
    }

    /// <summary>
    /// Function used to get Report Parameters.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        var postGroup = 0;
        var hshRptParameters = new Hashtable();
        if (strReportName == "rpt_ActualSchedule_AsmtWise.rpt1" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt2" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt3" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt4")
        {
            strReportName = "rpt_ActualSchedule_AsmtWise.rpt";
        }
        if (chkShiftGroping.Checked && ddlReportName.SelectedItem.Value == @"WeeklyPostingSheetISRN.rpt")
        {

            strReportName = "WeeklyPostingSheetISRNShiftwise.rpt";
        }

        var strCulture = BaseLanguageCode;

        switch (strReportName)
        {
            case "schempwise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                if (ddlEmployeeNumber.SelectedItem == null)
                {
                    ddlEmployeeNumber.SelectedIndex = 0;
                }
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.StartDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.EndDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                if (hshRptParameters.ContainsValue(""))
                {
                    Response.Redirect("../Transactions/RptGroup_Schedule.aspx?lblErrorMsg=Cannot Have any Control value as Blank");
                    lblErrorMsg.Visible = true;
                }

                return hshRptParameters;
            case "schasmtwise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, DDLAsmtID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.StartDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.EndDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                return hshRptParameters;
            case "Postingsheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.DutyDate, Common.DateFormat(txtAsOnDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Client, DDLClientDetail.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Assign, DDLAsmtID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Source, ddlRptType.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Shift, ddlShift.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                return hshRptParameters;
            case "WeeklyPostingSheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, DDLAsmtID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ShiftCode, ddlShift.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                if (BaseCountryName.Trim().ToLower() == "Kuwait-AlMulla".Trim().ToLower())
                {
                    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                    Context.Items["cxtReportFileName"] = BaseCountryName + "_" + ddlReportName.SelectedItem.Value;
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.Country, BaseCountryName);
                }
                //Added AreaID 30-07-2012  Manish
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);

                return hshRptParameters;

            //Added New Report Weekly Posting Sheet Consolidate by  on 13-Mar-14
            case "WeeklyPostingSheetConsolidate.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, DDLAsmtID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ShiftCode, ddlShift.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                hshRptParameters.Add(DL.Properties.Resources.Country, BaseCountryName);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                if (hshRptParameters.ContainsValue(""))
                {
                    Response.Redirect("../Transactions/RptGroup_Schedule.aspx?lblErrorMsg=Cannot Have any Control value as Blank");
                    lblErrorMsg.Visible = true;
                }

                return hshRptParameters;

            //Added New Report For Israel 28-11-2012.Hiding Employee Numebr and Showing YLMUID 
            case "WeeklyPostingSheetISRN.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, DDLAsmtID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ShiftCode, ddlShift.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                //if (BaseCountryName.ToString().Trim().ToLower() == "Kuwait-AlMulla".Trim().ToLower() || BaseCountryName.ToString().Trim().ToLower() == "Saudi".Trim().ToLower())
                if (BaseCountryName.Trim().ToLower() == "Kuwait-AlMulla".Trim().ToLower())
                {
                    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                    Context.Items["cxtReportFileName"] = BaseCountryName + "_" + ddlReportName.SelectedItem.Value;
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.Country, BaseCountryName);
                }
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                return hshRptParameters;
            case "WeeklyPostingSheetISRNShiftwise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, DDLAsmtID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ShiftCode, ddlShift.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                if (BaseCountryName.Trim().ToLower() == "Kuwait-AlMulla".Trim().ToLower())
                {
                    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                    Context.Items["cxtReportFileName"] = BaseCountryName + "_" + ddlReportName.SelectedItem.Value;
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.Country, BaseCountryName);
                }
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);

                return hshRptParameters;

            case "Actualvsschedule.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Assign, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ReportType, ddlReporttype.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
            case "leaveconfliction.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Branch, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Division, ddlDivision.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
            case "deploymentexception.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.nHrs, txtHours.Text);
                hshRptParameters.Add(DL.Properties.Resources.Option, ddlOption.SelectedValue);
                return hshRptParameters;
            case "mismatch.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
            case "siteroster.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                return hshRptParameters;
            case "Personnelroster.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
            case "availpersonnel_Greece.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
            case "availpersonnel_Barbados.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ShiftCode, DDLShiftCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.StartTime, TxtTimeFrom.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToTime, TxtTimeTo.Text);
                hshRptParameters.Add(DL.Properties.Resources.DutyDate, Common.DateFormat(txtAsOnDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Option, DDLAType.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Condition, ddlOptionAvailPersonnel.SelectedItem.ToString());
                return hshRptParameters;
            case "ManpowerDetails.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.DutyDate, Common.DateFormat(txtAsOnDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.DayStartTime, Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.DayEndTime, Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayEndTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.NightStartTime, Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.NightEndTime, Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightEndTime.Text)));
                return hshRptParameters;

            case "Weeklyscheduleroster.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Source, ddlRptType.SelectedValue);
                return hshRptParameters;

            case "DailyPostingSheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtAsOnDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value);
                return hshRptParameters;
            case "DailyDispositionSheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtAsOnDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.DayStartTime, Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.DayEndTime, Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayEndTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.NightStartTime, Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.NightEndTime, Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightEndTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.ShiftType, ddlShiftType.SelectedValue);
                return hshRptParameters;

            case "rpt_ActualSchedule_AsmtWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode1.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode1.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID1.SelectedItem.Value);
                if (ddlReportGrid.SelectedItem.Value == @"Grid")
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                }

                if (ddlReportName.SelectedItem.Text == Resource.WeeklyScheduleReport
                    || ddlReportName.SelectedItem.Text == Resource.MonthlyScheduleReport)
                {
                    hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "SCH");
                }
                else if (ddlReportName.SelectedItem.Text == Resource.WeeklyActualReport
                        || ddlReportName.SelectedItem.Text == Resource.MonthlyActualReport)
                {
                    hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                }
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Option, strCulture);
                return hshRptParameters;

            case "UnscheduledEmployees":

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(ddlBranch1.SelectedItem.Value));
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID1.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.RosterOrSchedule, ddlRosterOrSchedule.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.IsAreaIncharge, BaseUserIsAreaIncharge);

                return hshRptParameters;

            case "BarredEmployees":

                hshRptParameters.Add(DL.Properties.Resources.FromDate, DateTime.Now);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DateTime.Now);
                hshRptParameters.Add(DL.Properties.Resources.DivisionCode, ddlDivision1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Division, ddlDivisionName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.BranchCode, ddlBranch1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Branch, ddlBranchName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaDesc, ddlAreaName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNameCondition, ddlEmployeeName.SelectedValue);
                return hshRptParameters;

            case "WeeklyRest":

                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.WeeklyRest, Restcombo.SelectedValue);
                return hshRptParameters;


            case "EmployeeConstraint":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.TrainingCode, ddlTraining.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.QualificationCode, DdlQual.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.SkillCode, DdlSkill.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ConstraintCode, DdlConstraint.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.IDType, DdlIdType.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.LanguageCode, DdlLanguage.SelectedValue);
                return hshRptParameters;
            case "CustomerConstraint":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, ddlAsmtCode1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.PostCode, ddlPostCode1.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ConstraintCode, DdlIsMandatory.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.TrainingCode, ddlTraining.SelectedValue);
                return hshRptParameters;


            case "PostingSheetIsrael.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, DDLAsmtID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.PostCode, DDLPost.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ShiftCode, ddlShift.SelectedValue);
                if (chkPostGroping.Checked)
                {
                    postGroup = 1;
                    Context.Items["cxtReportFileName"] = "PostingSheetIsraelPostWise.rpt";
                }
                hshRptParameters.Add(DL.Properties.Resources.PostGroup, postGroup);
                return hshRptParameters;

            default: return hshRptParameters;
        }
    }
    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateFromToDate()
    {
        if (txtToDate.Text != "" && txtFromDate.Text != "")
        {
            if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
            {
                return true;
            }
            lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
            return false;
        }
        lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
        return false;
    }
    /// <summary>
    /// Validates the controles.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateControles(string strReportName)
    {
        if (strReportName == "rpt_ActualSchedule_AsmtWise.rpt1" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt2" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt3" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt4")
        {
            strReportName = "rpt_ActualSchedule_AsmtWise.rpt";
        }

        switch (strReportName)
        {
            case "schempwise.rpt":
                return ValidateFromToDate();
            case "schasmtwise.rpt":
                return ValidateFromToDate();
            case "Postingsheet.rpt":
                return true;
            case "WeeklyPostingSheet.rpt":
                return ValidateFromToDate();
            case "WeeklyPostingSheetConsolidate.rpt":
                return ValidateFromToDate();
            case "WeeklyPostingSheetConsolidatePostWise.rpt":
                return ValidateFromToDate();
            case "WeeklyPostingSheetISRN.rpt":
                return ValidateFromToDate();
            case "WeeklyPostingSheetISRNShiftwise.rpt":
                return ValidateFromToDate();
            case "Actualvsschedule.rpt":
                return ValidateFromToDate();
            case "leaveconfliction.rpt":
                return ValidateFromToDate();
            case "mismatch.rpt":
                return ValidateFromToDate();
            case "deploymentexception.rpt":
                return ValidateFromToDate();
            case "siteroster.rpt":
                return ValidateFromToDate();
            case "Personnelroster.rpt":
                return ValidateFromToDate();
            case "availpersonnel_Barbados.rpt":
                return true;
            case "availpersonnel_Greece.rpt":
                return ValidateFromToDate();
            case "DailyPostingSheet.rpt":
                return ValidateFromToDate();
            case "Weeklyscheduleroster.rpt":
                return ValidateFromToDate();
            case "DailyDispositionSheet.rpt":
                return ValidateFromToDate();
            case "rpt_ActualSchedule_AsmtWise.rpt":
                return ValidateFromToDate();
            case "UnscheduledEmployees":
                return ValidateFromToDate();
            case "BarredEmployees":
                return ValidateFromToDate();

            case "WeeklyRest":
                return ValidateFromToDate();
            case "EmployeeConstraint":
                return true;
            case "CustomerConstraint":
                return true;

            case "ManpowerDetails.rpt":
                if (txtAsOnDate.Text != "" && txtDayStartTime.Text != "" && txtDayEndTime.Text != "" && txtNightStartTime.Text != "" && txtNightEndTime.Text != "")
                {
                    return true;
                }
                lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                return false;
            case "PostingSheetIsrael.rpt":
                return ValidateFromToDate();
            default:
                return false;
        }
    }


    #endregion




    /// <summary>
    /// Fill AreaIncharge Dropdown on Location Basis
    /// </summary>
    private void FillddlAreaInchargeDetails()
    {
        string employeeNumber;

        if (BaseUserIsAreaIncharge == "0" && BaseUserID != "system")
        {
            employeeNumber = BaseUserEmployeeNumber;
        }
        else
        {
            employeeNumber = "0";

        }
        var objHrManagement = new HRManagement();

        ddlAreaInchargeCode.Items.Clear();
        ddlAreaInchargeName.Items.Clear();

        var ds = objHrManagement.AreaInchargeGetBasedonUserID(ddlBranch1.SelectedValue != string.Empty ? ddlBranch1.SelectedItem.Value : BaseLocationAutoID, employeeNumber, BaseUserID);


        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaInchargeCode.DataSource = ds.Tables[0];
            ddlAreaInchargeCode.DataTextField = "EmployeeCode";
            ddlAreaInchargeCode.DataValueField = "EmployeeCode";
            ddlAreaInchargeCode.DataBind();

            ddlAreaInchargeName.DataSource = ds.Tables[0];
            ddlAreaInchargeName.DataTextField = "Employee";
            ddlAreaInchargeName.DataValueField = "EmployeeCode";
            ddlAreaInchargeName.DataBind();

            var li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
            ddlAreaInchargeCode.Items.Insert(0, li2);

            li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
            ddlAreaInchargeName.Items.Insert(0, li2);

        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAreaInchargeCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAreaInchargeName.Items.Insert(0, li1);
        }

        FillddlAreaId1();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeName.SelectedValue = ddlAreaInchargeCode.SelectedValue;
        FillddlAreaId1();
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeCode.SelectedValue = ddlAreaInchargeName.SelectedValue;
        FillddlAreaId1();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLAreaID control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaName.SelectedValue = ddlAreaID1.SelectedValue;
        FillddlClient1();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaID1.SelectedValue = ddlAreaName.SelectedValue;
        FillddlClient1();
    }


    /// <summary>
    /// Fill AreaId Dropdown on AreaIncharge Basis
    /// </summary>
    private void FillddlAreaId1()
    {
        ddlAreaID1.Items.Clear();
        ddlAreaName.Items.Clear();

        var objOps = new OperationManagement();

        var ds = objOps.AreaIdGet(ddlBranch1.SelectedValue != string.Empty ? ddlBranch1.SelectedItem.Value : BaseLocationAutoID, ddlAreaInchargeCode.SelectedValue);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaID1.DataSource = ds;
            ddlAreaID1.DataTextField = "AreaID";
            ddlAreaID1.DataValueField = "AreaID";
            ddlAreaID1.DataBind();

            ddlAreaName.DataSource = ds;
            ddlAreaName.DataTextField = "AreaDesc";
            ddlAreaName.DataValueField = "AreaID";
            ddlAreaName.DataBind();

            var li = new RadComboBoxItem { Text = Resource.All, Value = @"All" };
            ddlAreaID1.Items.Insert(0, li);

            li = new RadComboBoxItem { Text = Resource.All, Value = @"All" };
            ddlAreaName.Items.Insert(0, li);
        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAreaID1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAreaName.Items.Insert(0, li1);
        }

        if (ddlReportName.SelectedValue == @"BarredEmployees" || ddlReportName.SelectedValue == @"WeeklyRest" || ddlReportName.SelectedValue == @"EmployeeConstraint" || ddlReportName.SelectedValue == @"CustomerConstraint")
        {
            FillddlEmployeeNumber();

            if (ddlReportName.SelectedValue == @"CustomerConstraint")
            {
                FillddlClient1();    
            }

        }
        else
        {
            FillddlClient1();
        }
    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient1()
    {
        ddlClientCode1.Items.Clear();
        ddlClientName.Items.Clear();
        var objSales = new Sales();
        var ds = String.Equals(BaseIsAdmin.Trim(), "C".Trim(), StringComparison.CurrentCultureIgnoreCase) ? objSales.ClientGet(BaseLocationAutoID, BaseUserID) : objSales.ClientAreaWiseGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaID1.SelectedItem.Value);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode1.DataSource = ds.Tables[0];
            ddlClientCode1.DataTextField = "ClientCode";
            ddlClientCode1.DataValueField = "ClientCode";
            ddlClientCode1.DataBind();

            ddlClientName.DataSource = ds.Tables[0];
            ddlClientName.DataTextField = "ClientName";
            ddlClientName.DataValueField = "ClientCode";
            ddlClientName.DataBind();

            var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlClientCode1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlClientName.Items.Insert(0, li1);

            FillddlAsmt1();
        }
        else
        {
            ddlAsmtCode1.Items.Clear();
            ddlAsmtName.Items.Clear();
            var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlClientCode1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlClientName.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAsmtName.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
            ddlAsmtCode1.Items.Insert(0, li1);
        }

    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    private void FillddlAsmt1()
    {
        ddlAsmtCode1.Items.Clear();
        ddlAsmtName.Items.Clear();
        var objOperationManagement = new OperationManagement();

        if (ddlClientCode1.SelectedItem.Value == @"ALL")
        {
            var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlAsmtCode1.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlAsmtName.Items.Insert(0, li1);

        }
        else
        {
            string strClientCode = ddlClientCode1.SelectedValue;

            var dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaID1.SelectedItem.Value);

            if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
            {
                ddlAsmtCode1.DataSource = dsAsmt.Tables[0];
                ddlAsmtCode1.DataTextField = "AsmtCode";
                ddlAsmtCode1.DataValueField = "AsmtCode";
                ddlAsmtCode1.DataBind();

                ddlAsmtName.DataSource = dsAsmt.Tables[0];
                ddlAsmtName.DataTextField = "AsmtAddress";
                ddlAsmtName.DataValueField = "AsmtCode";
                ddlAsmtName.DataBind();

                var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                ddlAsmtCode1.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                ddlAsmtName.Items.Insert(0, li1);
            }
            else
            {
                var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlAsmtCode1.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlAsmtName.Items.Insert(0, li1);
            }
        }

        if (ddlReportName.SelectedValue == @"CustomerConstraint")
        {
            FillDdlPost1();
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientName.SelectedValue = ddlClientCode1.SelectedValue;
        FillddlAsmt1();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientCode1.SelectedValue = ddlClientName.SelectedValue;
        FillddlAsmt1();
    }


    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode1_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtName.SelectedValue = ddlAsmtCode1.SelectedValue;

    }
    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtName_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtCode1.SelectedValue = ddlAsmtName.SelectedValue;

    }


    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision1()
    {
        ddlDivision1.Items.Clear();
        ddlBranch1.Items.Clear();
        var objblUserManagement = new UserManagement();
        var dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision1.DataSource = dsDivision.Tables[0];
            ddlDivision1.DataValueField = "HrLocationCode";
            ddlDivision1.DataTextField = "HrLocationCode";
            ddlDivision1.DataBind();

            ddlDivisionName.DataSource = dsDivision.Tables[0];
            ddlDivisionName.DataValueField = "HrLocationCode";
            ddlDivisionName.DataTextField = "HrLocationDesc";
            ddlDivisionName.DataBind();

            ddlDivision1.SelectedValue = BaseHrLocationCode;
            ddlDivisionName.SelectedValue = ddlDivision1.SelectedValue;

            FillBranch1();
        }
    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch1()
    {
        var objblUserManagement = new UserManagement();
        //Added By  for Weekly Rest Report
        var dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision1.SelectedValue);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch1.DataSource = dsBranch.Tables[0];
            ddlBranch1.DataValueField = "LocationAutoId";
            ddlBranch1.DataTextField = "LocationCode";
            ddlBranch1.DataBind();

            ddlBranchName.DataSource = dsBranch.Tables[0];
            ddlBranchName.DataValueField = "LocationAutoId";
            ddlBranchName.DataTextField = "LocationDesc";
            ddlBranchName.DataBind();
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivision1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivisionName.SelectedValue = ddlDivision1.SelectedValue;
        FillBranch1();
        FillddlAreaInchargeDetails();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivisionName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivisionName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivision1.SelectedValue = ddlDivisionName.SelectedValue;
        FillBranch1();
        FillddlAreaInchargeDetails();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranch1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranchName.SelectedValue = ddlBranch1.SelectedValue;
        FillddlAreaInchargeDetails();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranchName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranchName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranch1.SelectedValue = ddlBranchName.SelectedValue;
        FillddlAreaInchargeDetails();
    }


    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    private void FillddlEmployeeNumber()
    {
        ddlEmployeeNumber1.Items.Clear();
        ddlEmployeeName.Items.Clear();
        var objHrManagement = new HRManagement();

        if (ddlDivision1.SelectedValue == @"ALL")
        {
            var liEmp = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlEmployeeNumber1.Items.Insert(0, liEmp);

            liEmp = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlEmployeeName.Items.Insert(0, liEmp);
        }
        else
        {
            DataSet ds;
            if (ddlReportName.SelectedValue == @"EmployeeConstraint" || ddlReportName.SelectedValue == @"CustomerConstraint")
            {

                ds = objHrManagement.EmployeesOfLocationAreaWiseGetForTraining(BaseCompanyCode,
                    ddlDivision1.SelectedValue, ddlBranch1.SelectedItem.Text, DateTime.Now.ToString("dd-MMM-yyyy"),
                    DateTime.Now.ToString("dd-MMM-yyyy"),
                    ddlAreaID1.SelectedValue, ddlAreaInchargeCode.SelectedValue, BaseUserIsAreaIncharge);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlEmployeeNumber1.DataSource = ds.Tables[0];
                    ddlEmployeeNumber1.DataTextField = "EmployeeNumber";
                    ddlEmployeeNumber1.DataValueField = "EmployeeNumber";
                    ddlEmployeeNumber1.DataBind();

                    ddlEmployeeName.DataSource = ds.Tables[0];
                    ddlEmployeeName.DataTextField = "EmployeeName";
                    ddlEmployeeName.DataValueField = "EmployeeNumber";
                    ddlEmployeeName.DataBind();

                    var li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
                    ddlEmployeeNumber1.Items.Insert(0, li2);

                    li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
                    ddlEmployeeName.Items.Insert(0, li2);

                    FillAllConstraint();
                    FillAllIdType();
                    FillAllLanguage();
                    FillAllQualification();
                    FillAllSkill();
                    FillAllTrainings();
                }
                else
                {
                    var li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    ddlEmployeeNumber.Items.Insert(0, li2);


                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    ddlEmployeeName.Items.Insert(0, li2);

                    DdlConstraint.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlConstraint.Items.Insert(0, li2);

                    DdlIdType.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlIdType.Items.Insert(0, li2);

                    DdlLanguage.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlLanguage.Items.Insert(0, li2);

                    DdlQual.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlQual.Items.Insert(0, li2);

                    DdlSkill.Items.Clear();
                    li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                    DdlSkill.Items.Insert(0, li2);

                    if (ddlReportName.SelectedValue == @"EmployeeConstraint")
                    {
                        ddlTraining.Items.Clear();
                        li2 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = string.Empty };
                        ddlTraining.Items.Insert(0, li2);
                    }
                }
            }
            else
            {

                try
                {
                    ds = objHrManagement.EmployeesOfLocationAreaWiseGetForTraining(BaseCompanyCode,
                        ddlDivision1.SelectedValue, ddlBranch1.SelectedItem.Text, txtFromDate.Text, txtToDate.Text,
                        ddlAreaID1.SelectedValue, ddlAreaInchargeCode.SelectedValue, BaseUserIsAreaIncharge);


                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ddlEmployeeNumber1.DataSource = ds.Tables[0];
                        ddlEmployeeNumber1.DataTextField = "EmployeeNumber";
                        ddlEmployeeNumber1.DataValueField = "EmployeeNumber";
                        ddlEmployeeNumber1.DataBind();

                        ddlEmployeeName.DataSource = ds.Tables[0];
                        ddlEmployeeName.DataTextField = "EmployeeName";
                        ddlEmployeeName.DataValueField = "EmployeeNumber";
                        ddlEmployeeName.DataBind();

                        var li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
                        ddlEmployeeNumber1.Items.Insert(0, li2);

                        li2 = new RadComboBoxItem { Text = Resource.SelectAll, Value = @"ALL" };
                        ddlEmployeeName.Items.Insert(0, li2);
                    }
                    else
                    {
                        var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                        ddlEmployeeNumber1.Items.Insert(0, li1);

                        li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                        ddlEmployeeName.Items.Insert(0, li1);
                    }
                }
                catch (Exception) { }
            }
        }
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployeeNumber control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeNumber1_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeName.SelectedValue = ddlEmployeeNumber1.SelectedValue;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployeeName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeNumber1.SelectedValue = ddlEmployeeName.SelectedValue;
    }



    #region Code for Panel Week For Weekly Rest
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlMonth1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlMonth1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ViewState["MonthChangeStatus"] = 0;
            GetWeekStartDay();
            GetStartEndDate();
            txtFromDate.Text = HFFromDate.Value;
        }
        catch (Exception) { }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlWeek control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlWeek_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        try
        {
            ViewState["MonthChangeStatus"] = 1;
            if (ViewState["MonthChangeStatus"].ToString() == "0")
            {
                GetWeekStartDay();
            }
            GetStartEndDate();

            txtFromDate.Text = HFFromDate.Value;
        }
        catch (Exception) { }
    }
    /// <summary>
    /// Handles the TextChanged event of the TxtYear1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtYear1_TextChanged(object sender, EventArgs e)
    {
        if (txtYear1.Text == "")
        {
            txtYear1.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
        }
        if (txtYear1.Text.Length < 4)
        {
            Show("Invalid Year");
            txtYear1.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
        }
        try
        {
            FillddlWeek();
            SetFromAndToDate(GetDatebasedOnSystemParameters());
            txtYear1.Focus();
        }
        catch (Exception ex)
        {
            Show("Invalid Year");
            txtYear1.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
        }
        try
        {
            GetWeekStartDay();
            GetStartEndDate();
        }
        catch (Exception) { }
    }
    /// <summary>
    /// Gets the week start day.
    /// </summary>
    private void GetWeekStartDay()
    {
        try
        {
            if (int.Parse(ViewState["MonthChangeStatus"].ToString()) == 0)
            {
                var dtDates = (DataTable)ViewState["Dates"];
                dtDates.Clear();
                ddlWeek.Items.Clear();
                var dtSelectedMonthFirstDay = new DateTime(int.Parse(txtYear1.Text), int.Parse(ddlMonth1.SelectedValue), 1);
                int nextMonth;
                string strYear = txtYear1.Text;
                if (int.Parse(ddlMonth1.SelectedValue) == 12)
                {
                    strYear = Convert.ToString(int.Parse(txtYear1.Text) + 1);
                    nextMonth = 1;
                }
                else
                {
                    nextMonth = int.Parse(ddlMonth1.SelectedValue) + 1;
                }

                var dtNextMonthFirstDay = new DateTime(int.Parse(strYear), int.Parse(nextMonth.ToString(CultureInfo.InvariantCulture)), 1);
                var dtCurrentMonthLastDay = new DateTime(int.Parse(txtYear1.Text), int.Parse(ddlMonth1.SelectedValue), 1).AddMonths(1).AddDays(-1);
                var strScheduleWeeklyStartDay = string.Empty;
                var strScheduleWeeklyEndDay = string.Empty;
                if (ViewState["ScheduleWeeklyStartDay"] != null && ViewState["ScheduleWeeklyStartDay"].ToString() != "")
                {
                    strScheduleWeeklyStartDay = ViewState["ScheduleWeeklyStartDay"].ToString();
                    strScheduleWeeklyEndDay = ViewState["ScheduleWeeklyEndDay"].ToString();
                }
                else
                {
                    if (ViewState["ScheduleWeeklyFromDay"] != null && ViewState["ScheduleWeeklyFromDay"].ToString() != "")
                    {
                        string strCurrentMonthStartDate = ViewState["ScheduleWeeklyFromDay"].ToString();
                        var cultureInfo = new CultureInfo("en-us");
                        strScheduleWeeklyStartDay = DateTime.Parse(strCurrentMonthStartDate).ToString("dddd", cultureInfo);
                        strScheduleWeeklyEndDay = DateTime.Parse(DateTime.Parse(strCurrentMonthStartDate).AddDays(double.Parse("-1")).ToString(CultureInfo.InvariantCulture)).ToString("dddd", cultureInfo);
                    }
                }

                while (dtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyStartDay.Trim().ToLower())
                {
                    if (strScheduleWeeklyStartDay == "")
                    {
                        break;
                    }
                    dtSelectedMonthFirstDay = dtSelectedMonthFirstDay.AddDays(1);
                }
                if (dtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyEndDay.Trim().ToLower())
                {
                    while (dtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyEndDay.Trim().ToLower())
                    {
                        if (strScheduleWeeklyEndDay == "")
                        {
                            break;
                        }
                        dtNextMonthFirstDay = dtNextMonthFirstDay.AddDays(1);
                    }
                }
                else
                {
                    dtNextMonthFirstDay = dtCurrentMonthLastDay;
                }

                var dtSelectedMonthFirstDate = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
                var dtNextMonthFirstDate = dtNextMonthFirstDay.ToString("dd-MMM-yyyy");
                var count = 1;
                var rowIndex = 1;

                var nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
                while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
                {
                    var dr = dtDates.NewRow();
                    dr["Date"] = nextDate.ToString("dd-MMM-yyyy");
                    dr["WeekNo"] = count;
                    nextDate = nextDate.AddDays(1);
                    if (nextDate.DayOfWeek.ToString().Trim().ToLower() == strScheduleWeeklyStartDay.Trim().ToLower())
                    {
                        count = count + 1;
                    }
                    rowIndex = rowIndex + 1;
                    dtDates.Rows.Add(dr);
                }

                var status = 1;

                while (status < count)
                {
                    var weekNumberAndRange = "";
                    var dvDates = new DataView(dtDates) { RowFilter = "[WeekNo]='" + status + "'" };
                    var tableDates = dvDates.ToTable();
                    try
                    {
                        weekNumberAndRange = DateTime.Parse(tableDates.Rows[0]["Date"].ToString()).ToString("dd-MMM-yy") + " - " + DateTime.Parse(tableDates.Rows[6]["Date"].ToString()).ToString("dd-MMM-yy");
                    }
                    catch (Exception ex)
                    {
                        lblErrorMsg.Text = Resource.ErrorMessage;
                    }
                    var li = new RadComboBoxItem
                    {
                        Text = status + @"   [" + weekNumberAndRange + @"]",
                        Value = status.ToString(CultureInfo.InvariantCulture)
                    };
                    ddlWeek.Items.Add(li);
                    status = status + 1;
                    tableDates.Dispose();
                }
                ViewState["Dates"] = dtDates;
            }
        }
        catch (Exception) { }

    }
    /// <summary>
    /// Gets the start end date.
    /// </summary>
    private void GetStartEndDate()
    {
        var dtDates = (DataTable)ViewState["Dates"];
        var dv = new DataView(dtDates);
        if (ddlWeek != null && ddlWeek.SelectedValue != "")
        {
            dv.RowFilter = "[WeekNo]='" + (ddlWeek.SelectedValue) + "'";
            var dtStartEndDate = dv.ToTable();
            HFFromDate.Value = DateTime.Parse(dtStartEndDate.Rows[0]["Date"].ToString()).ToString("dd-MMM-yyyy");
        }
    }
    /// <summary>
    /// Fillddls the week.
    /// </summary>
    private void FillddlWeek()
    {
        ddlWeek.Items.Clear();
        var intMonth = int.Parse(ddlMonth1.SelectedItem.Value);
        var intYear = int.Parse(txtYear1.Text);
        var intDays = decimal.Parse(DateTime.DaysInMonth(intYear, intMonth).ToString(CultureInfo.InvariantCulture));
        var decNoOfWeeks = (intDays - GetDatebasedOnSystemParameters().Day) / 7;
        int intNoOfWeek;
        if (decNoOfWeeks < 1) { intNoOfWeek = 1; }
        else if (decNoOfWeeks > 1 && decNoOfWeeks < 2) { intNoOfWeek = 2; }
        else if (decNoOfWeeks > 2 && decNoOfWeeks < 3) { intNoOfWeek = 3; }
        else if (decNoOfWeeks > 3 && decNoOfWeeks < 4) { intNoOfWeek = 4; }
        else if (decNoOfWeeks > 4 && decNoOfWeeks < 5) { intNoOfWeek = 5; }
        else { intNoOfWeek = 6; }
        var I = 1;
        while (intNoOfWeek >= I)
        {
            var li = new RadComboBoxItem { Text = I.ToString(CultureInfo.InvariantCulture), Value = I.ToString(CultureInfo.InvariantCulture) };
            ddlWeek.Items.Add(li);
            I++;
        }
        SetFromAndToDate(GetDatebasedOnSystemParameters());
        ddlWeek.Focus();
    }
    /// <summary>
    /// Sets from and to date.
    /// </summary>
    /// <param name="dtSelectedMonthFirstDate">The dt selected month first date.</param>
    private void SetFromAndToDate(DateTime dtSelectedMonthFirstDate)
    {
        if (ddlWeek.SelectedItem != null)
        {
            dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays((int.Parse(ddlWeek.SelectedItem.Value) - 1) * 7);
            txtFromDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
        }
    }
    /// <summary>
    /// Gets the datebased on system parameters.
    /// </summary>
    /// <returns>DateTime.</returns>
    private DateTime GetDatebasedOnSystemParameters()
    {
        try
        {
            var objRoster = new Roster();
            var strSelectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth1.SelectedValue)) + "-" + txtYear1.Text);
            var dt = objRoster.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strSelectedMonthStartDate, "Weekly".Trim().ToLower());
            var dtSelectedMonthFirstDate = new DateTime(int.Parse(txtYear1.Text), int.Parse(ddlMonth1.SelectedValue), 1);

            if (dt != null && dt.Rows.Count > 0)
            {
                var strScheduleWeeklyStartDay = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                //// while condition modified by Manish. new CultureInfo("en-US") is used to compare  
                while (dtSelectedMonthFirstDate.ToString("dddd", new CultureInfo("en-US")).ToUpper() != strScheduleWeeklyStartDay.ToUpper())
                {
                    dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(1);
                }
                if (int.Parse(ViewState["MonthChangeStatus"].ToString()) == 0)
                {
                    MakeTempTable();
                    ViewState["ScheduleWeeklyFromDay"] = dt.Rows[0]["ScheduleWeeklyFromDay"].ToString();
                    ViewState["ScheduleWeeklyStartDay"] = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                    ViewState["ScheduleWeeklyEndDay"] = dt.Rows[0]["ScheduleWeeklyEndDay"].ToString();
                    GetWeekStartDay();
                }
            }
            return dtSelectedMonthFirstDate;
        }
        catch
        {
            lblErrorMsg.Text = @"Invalid Year Selected";
            return DateTime.Now;
        }

    }
    /// <summary>
    /// Makes the temporary table.
    /// </summary>
    private void MakeTempTable()
    {
        var dtDates = new DataTable();
        var dCol1 = new DataColumn("Date", typeof(String));
        var dCol2 = new DataColumn("WeekNo", typeof(Int32));
        dtDates.Columns.Add(dCol1);
        dtDates.Columns.Add(dCol2);
        ViewState["Dates"] = dtDates;
    }

    #endregion


    #region Code for Panel Week For Weekly Rest 2
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlMonth2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlMonth2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ViewState["MonthChangeStatus2"] = 0;
        GetWeekStartDay2();
        GetStartEndDate2();
        txtToDate.Text = HFToDate2.Value;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlWeek2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlWeek2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ViewState["MonthChangeStatus2"] = 1;
        if (ViewState["MonthChangeStatus2"].ToString() == @"0")
        {
            GetWeekStartDay2();
        }
        GetStartEndDate2();
        txtToDate.Text = HFToDate2.Value;
    }
    /// <summary>
    /// Handles the TextChanged event of the TxtYear2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void TxtYear2_TextChanged(object sender, EventArgs e)
    {
        if (txtYear2.Text == "")
        {
            txtYear2.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
        }
        if (txtYear2.Text.Length < 4)
        {
            Show("Invalid Year");
            txtYear2.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
        }
        try
        {
            FillddlWeek2();
            SetFromAndToDate2(GetDatebasedOnSystemParameters2());
            txtYear2.Focus();
        }
        catch (Exception ex)
        {
            Show("Invalid Year");
            txtYear2.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
        }
        GetWeekStartDay2();
        GetStartEndDate2();
    }
    /// <summary>
    /// Gets the week start day2.
    /// </summary>
    private void GetWeekStartDay2()
    {
        if (int.Parse(ViewState["MonthChangeStatus2"].ToString()) == 0)
        {
            var dtDates = (DataTable)ViewState["Dates2"];
            dtDates.Clear();
            ddlWeek2.Items.Clear();
            var dtSelectedMonthFirstDay = new DateTime(int.Parse(txtYear2.Text), int.Parse(ddlMonth2.SelectedValue), 1);
            int nextMonth;
            var strYear = txtYear2.Text;
            if (int.Parse(ddlMonth2.SelectedValue) == 12)
            {
                strYear = (int.Parse(txtYear2.Text) + 1).ToString(CultureInfo.InvariantCulture);
                nextMonth = 1;
            }
            else
            {
                nextMonth = int.Parse(ddlMonth2.SelectedValue) + 1;
            }

            var dtNextMonthFirstDay = new DateTime(int.Parse(strYear), int.Parse(nextMonth.ToString(CultureInfo.InvariantCulture)), 1);
            var dtCurrentMonthLastDay = new DateTime(int.Parse(txtYear2.Text), int.Parse(ddlMonth2.SelectedValue), 1).AddMonths(1).AddDays(-1);
            var strScheduleWeeklyStartDay = string.Empty;
            var strScheduleWeeklyEndDay = string.Empty;
            if (ViewState["ScheduleWeeklyStartDay2"] != null && ViewState["ScheduleWeeklyStartDay2"].ToString() != "")
            {
                strScheduleWeeklyStartDay = ViewState["ScheduleWeeklyStartDay2"].ToString();
                strScheduleWeeklyEndDay = ViewState["ScheduleWeeklyEndDay2"].ToString();
            }
            else
            {
                if (ViewState["ScheduleWeeklyFromDay2"] != null && ViewState["ScheduleWeeklyFromDay2"].ToString() != "")
                {
                    var strCurrentMonthStartDate = ViewState["ScheduleWeeklyFromDay2"].ToString();
                    var cultureInfo = new CultureInfo("en-us");
                    strScheduleWeeklyStartDay = DateTime.Parse(strCurrentMonthStartDate).ToString("dddd", cultureInfo);
                    strScheduleWeeklyEndDay = DateTime.Parse(DateTime.Parse(strCurrentMonthStartDate).AddDays(double.Parse("-1")).ToString(CultureInfo.InvariantCulture)).ToString("dddd", cultureInfo);
                }
            }

            while (dtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyStartDay.Trim().ToLower())
            {
                if (strScheduleWeeklyStartDay == "")
                {
                    break;
                }
                dtSelectedMonthFirstDay = dtSelectedMonthFirstDay.AddDays(1);
            }
            if (dtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyEndDay.Trim().ToLower())
            {
                while (dtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyEndDay.Trim().ToLower())
                {
                    if (strScheduleWeeklyEndDay == "")
                    {
                        break;
                    }
                    dtNextMonthFirstDay = dtNextMonthFirstDay.AddDays(1);
                }
            }
            else
            {
                dtNextMonthFirstDay = dtCurrentMonthLastDay;
            }

            var dtSelectedMonthFirstDate = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
            var dtNextMonthFirstDate = dtNextMonthFirstDay.ToString("dd-MMM-yyyy");
            var count = 1;
            var rowIndex = 1;

            var nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
            while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
            {
                var dr = dtDates.NewRow();
                dr["Date"] = nextDate.ToString("dd-MMM-yyyy");
                dr["WeekNo"] = count;
                nextDate = nextDate.AddDays(1);
                if (nextDate.DayOfWeek.ToString().Trim().ToLower() == strScheduleWeeklyStartDay.Trim().ToLower())
                {
                    count = count + 1;
                }
                rowIndex = rowIndex + 1;
                dtDates.Rows.Add(dr);
            }

            var status = 1;

            while (status < count)
            {
                var weekNumberAndRange = "";
                var dvDates = new DataView(dtDates) { RowFilter = "[WeekNo]='" + status + "'" };
                var tableDates = dvDates.ToTable();
                try
                {
                    weekNumberAndRange = DateTime.Parse(tableDates.Rows[0]["Date"].ToString()).ToString("dd-MMM-yy") + " - " + DateTime.Parse(tableDates.Rows[6]["Date"].ToString()).ToString("dd-MMM-yy");
                }
                catch (Exception ex)
                {
                }
                var li = new RadComboBoxItem { Text = status + @"   [" + weekNumberAndRange + @"]", Value = status.ToString(CultureInfo.InvariantCulture) };
                ddlWeek2.Items.Add(li);
                status = status + 1;
                tableDates.Dispose();
            }
            ViewState["Dates2"] = dtDates;
        }

    }
    /// <summary>
    /// Gets the start end date2.
    /// </summary>
    private void GetStartEndDate2()
    {
        var dtDates = (DataTable)ViewState["Dates2"];
        var dv = new DataView(dtDates);
        if (ddlWeek != null && ddlWeek2.SelectedValue != "")
        {
            dv.RowFilter = "[WeekNo]='" + (ddlWeek2.SelectedValue) + "'";
            var dtStartEndDate = dv.ToTable();
            HFToDate2.Value = DateTime.Parse(dtStartEndDate.Rows[6]["Date"].ToString()).ToString("dd-MMM-yyyy");
        }
    }
    /// <summary>
    /// Fillddls the week2.
    /// </summary>
    private void FillddlWeek2()
    {
        ddlWeek2.Items.Clear();
        var intMonth = int.Parse(ddlMonth2.SelectedItem.Value);
        var intYear = int.Parse(txtYear2.Text);
        var intDays = decimal.Parse(DateTime.DaysInMonth(intYear, intMonth).ToString(CultureInfo.InvariantCulture));
        var decNoOfWeeks = (intDays - GetDatebasedOnSystemParameters2().Day) / 7;
        int intNoOfWeek;
        if (decNoOfWeeks < 1) { intNoOfWeek = 1; }
        else if (decNoOfWeeks > 1 && decNoOfWeeks < 2) { intNoOfWeek = 2; }
        else if (decNoOfWeeks > 2 && decNoOfWeeks < 3) { intNoOfWeek = 3; }
        else if (decNoOfWeeks > 3 && decNoOfWeeks < 4) { intNoOfWeek = 4; }
        else if (decNoOfWeeks > 4 && decNoOfWeeks < 5) { intNoOfWeek = 5; }
        else { intNoOfWeek = 6; }
        var i = 1;
        while (intNoOfWeek >= i)
        {
            var li = new RadComboBoxItem { Text = i.ToString(CultureInfo.InvariantCulture), Value = i.ToString(CultureInfo.InvariantCulture) };
            ddlWeek2.Items.Add(li);
            i++;
        }
        SetFromAndToDate2(GetDatebasedOnSystemParameters2());
        ddlWeek2.Focus();
    }
    /// <summary>
    /// Sets from and to date2.
    /// </summary>
    /// <param name="dtSelectedMonthFirstDate">The dt selected month first date.</param>
    private void SetFromAndToDate2(DateTime dtSelectedMonthFirstDate)
    {
        if (ddlWeek2.SelectedItem != null)
        {
            dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays((int.Parse(ddlWeek2.SelectedItem.Value) - 1) * 7);
            dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
            txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
        }
    }
    /// <summary>
    /// Gets the datebased on system parameters2.
    /// </summary>
    /// <returns>DateTime.</returns>
    private DateTime GetDatebasedOnSystemParameters2()
    {
        try
        {
            var objRoster = new Roster();
            var strSelectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth2.SelectedValue)) + "-" + txtYear2.Text);
            var dt = objRoster.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strSelectedMonthStartDate, "Weekly".Trim().ToLower());
            var dtSelectedMonthFirstDate = new DateTime(int.Parse(txtYear2.Text), int.Parse(ddlMonth2.SelectedValue), 1);

            if (dt != null && dt.Rows.Count > 0)
            {
                var strScheduleWeeklyStartDay = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();

                //// while condition modified by Manish. new CultureInfo("en-US") is used to compare  
                while (dtSelectedMonthFirstDate.ToString("dddd", new CultureInfo("en-US")).ToUpper() != strScheduleWeeklyStartDay.ToUpper())
                {
                    dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(1);
                }
                if (int.Parse(ViewState["MonthChangeStatus2"].ToString()) == 0)
                {
                    MakeTempTable2();
                    ViewState["ScheduleWeeklyFromDay2"] = dt.Rows[0]["ScheduleWeeklyFromDay"].ToString();
                    ViewState["ScheduleWeeklyStartDay2"] = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                    ViewState["ScheduleWeeklyEndDay2"] = dt.Rows[0]["ScheduleWeeklyEndDay"].ToString();
                    GetWeekStartDay2();
                }
            }
            return dtSelectedMonthFirstDate;
        }
        catch
        {
            lblErrorMsg.Text = @"Invalid Year Selected";
            return DateTime.Now;
        }

    }
    /// <summary>
    /// Makes the temporary table2.
    /// </summary>
    private void MakeTempTable2()
    {
        var dtDates = new DataTable();
        var dCol1 = new DataColumn("Date", typeof(String));
        var dCol2 = new DataColumn("WeekNo", typeof(Int32));
        dtDates.Columns.Add(dCol1);
        dtDates.Columns.Add(dCol2);
        ViewState["Dates2"] = dtDates;
    }

    #endregion


    private void FillparameterBasedOnWeeklyRest()
    {
        if (ddlReportName.SelectedItem.Text != Resource.WeeklyRest) return;
        try
        {
            GetDatebasedOnSystemParameters();
            GetDatebasedOnSystemParameters2();
            GetWeekStartDay();
            GetStartEndDate();

            txtFromDate.Text = HFFromDate.Value;
            GetWeekStartDay2();
            GetStartEndDate2();
            txtToDate.Text = HFToDate2.Value;
        }
        catch (Exception)
        { }

    }


    /// <summary>
    /// Function used to fill Training Drop Down List.
    /// </summary>
    private void FillAllTrainings()
    {
        ddlTraining.Items.Clear();

        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlTraining.DataSource = ds.Tables[0];
                ddlTraining.DataValueField = "TrainingCode";
                ddlTraining.DataTextField = "TrainingDesc";
                ddlTraining.DataBind();
            }
        }

        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        ddlTraining.Items.Insert(0, li);

    }


    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllQualification()
    {
        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.QualificationMasterGetAll())
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlQual.DataSource = ds.Tables[0];
                DdlQual.DataValueField = "QualificationCode";
                DdlQual.DataTextField = "QualificationDesc";
                DdlQual.DataBind();
            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        DdlQual.Items.Insert(0, li);

    }

    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllLanguage()
    {
        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.LanguageMasterGetAll())
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlLanguage.DataSource = ds.Tables[0];
                DdlLanguage.DataValueField = "LanguageCode";
                DdlLanguage.DataTextField = "LanguageDesc";
                DdlLanguage.DataBind();
            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        DdlLanguage.Items.Insert(0, li);

    }

    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllIdType()
    {
        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.IdTypeGetAll())
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlIdType.DataSource = ds.Tables[0];
                DdlIdType.DataValueField = "IDTypeCode";
                DdlIdType.DataTextField = "IDTypeDesc";
                DdlIdType.DataBind();
            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        DdlIdType.Items.Insert(0, li);

    }

    /// <summary>
    /// Function used to fill Skill Drop Down List.
    /// </summary>
    private void FillAllSkill()
    {
        var objMastersManagement = new HRManagement();
        using (var ds = objMastersManagement.SkillTypeMasterGet(BaseCompanyCode))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlSkill.DataSource = ds;
                DdlSkill.DataTextField = "ItemDesc";
                DdlSkill.DataValueField = "ItemCode";
                DdlSkill.DataBind();

            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
        DdlSkill.Items.Insert(0, li);

    }

    /// <summary>
    /// Function used to fill Skill Drop Down List.
    /// </summary>
    private void FillAllConstraint()
    {
        DdlConstraint.Items.Clear();
        var objMastersManagement = new MastersManagement();
        using (var ds = objMastersManagement.ConstraintGetAll(BaseCompanyCode, null, Page.ID))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DdlConstraint.DataSource = ds.Tables[0];
                DdlConstraint.DataTextField = "ConstraintDesc";
                DdlConstraint.DataValueField = "ConstraintCode";
                DdlConstraint.DataBind();
            }
        }
        var li = new RadComboBoxItem { Text = Resource.All, Value = @"All" };
        DdlConstraint.Items.Insert(0, li);
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the DdlPostCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlPostCode1_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlPost1.SelectedValue = ddlPostCode1.SelectedValue;
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the DDlPost control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlPost1_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlPostCode1.SelectedValue = ddlPost1.SelectedValue;
    }


    /// <summary>
    /// Fills the DDL post.
    /// </summary>
    private void FillDdlPost1()
    {
        ddlPostCode1.Items.Clear();
        ddlPost1.Items.Clear();
        var objMasterManagement = new MastersManagement();
        switch (ddlAsmtCode1.SelectedItem.Value)
        {
            case @"ALL":
            {
                var li1 = new RadComboBoxItem {Text = Resource.All, Value = @"ALL"};
                ddlPostCode1.Items.Insert(0, li1);

                li1 = new RadComboBoxItem {Text = Resource.All, Value = @"ALL"};
                ddlPost1.Items.Insert(0, li1);

            }
                break;
            case @"-1":
            {
                var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlPostCode1.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlPost1.Items.Insert(0, li1);
            }
                break;
            default:
                using (var ds = objMasterManagement.AsmtPostGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaID1.SelectedItem.Value, ddlClientCode1.SelectedItem.Value, ddlAsmtCode1.SelectedItem.Value))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ddlPostCode1.DataSource = ds.Tables[0];
                        ddlPostCode1.DataTextField = "Site";
                        ddlPostCode1.DataValueField = "Site";
                        ddlPostCode1.DataBind();
                        ddlPost1.DataSource = ds.Tables[0];
                        ddlPost1.DataTextField = "SiteDesc";
                        ddlPost1.DataValueField = "Site";
                        ddlPost1.DataBind();
                        var li2 = new RadComboBoxItem {Text = Resource.All, Value = @"ALL"};
                        ddlPostCode1.Items.Insert(0, li2);
                        li2 = new RadComboBoxItem {Text = Resource.All, Value = @"ALL"};
                        ddlPost1.Items.Insert(0, li2);
                    }
                    else
                    {
                        var li2 = new RadComboBoxItem {Text = Resource.NoDataToShow, Value = @"-1"};
                        ddlPostCode1.Items.Insert(0, li2);
                        li2 = new RadComboBoxItem {Text = Resource.NoDataToShow, Value = @"-1"};
                        ddlPost1.Items.Insert(0, li2);
                    }
                }
                break;
        }

    }
}
