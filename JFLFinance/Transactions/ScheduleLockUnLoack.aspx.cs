// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 16-06-2014
// ***********************************************************************
// <copyright file="ScheduleLockUnLoack.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_ScheduleLockUnLoack.
/// </summary>
public partial class Transactions_ScheduleLockUnLoack : BasePage//System.Web.UI.Page
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    /// <summary>
    /// Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                var bp = new BasePage();
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }
    #endregion

    #region page Load
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ViewState["MonthChangeStatus"] = 0;

            if (IsReadAccess)
            {
                btnProceed.Visible = IsAuthorizationAccess;
                if (IsAuthorizationAccess)
                {
                    var objblUserManagement = new BL.UserManagement();
                    var dsUnlockSchedule = objblUserManagement.SystemParameterValuesByCompany(Convert.ToInt32(BaseLocationAutoID), "UnlockScheduleAllowed");
                    if (dsUnlockSchedule != null &&dsUnlockSchedule.Tables[0].Rows.Count>0 )
                    {
                        if (Convert.ToString(dsUnlockSchedule.Tables[0].Rows[0]["ParamValue1"]) == "1")
                        {
                            rbUnlock.Visible = IsAuthorizationAccess;
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            txtYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            SetFromAndToDate(GetDatebasedOnSystemParameters());
            GetDatebasedOnSystemParameters();
            txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            txtFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            txtToDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            weekStartDate.Value = txtFromDate.Text;
            weekEndDate.Value = txtToDate.Text;



            MakeTempTable();
            //var strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Year.ToString()));
            //txtFromDate.Text = strArray[0];
            //txtToDate.Text = strArray[1];
            //txtYear.Text = DateTime.Now.Year.ToString();
            DefaultTheWeekDates();
            FillddlBranch();
            if (ViewState["dt"] != null)
            {
                ViewState["dt"] = null;
            }

            if (!IsAuthorizationAccess)
            {
                rbUnlock.Visible = false;
                rbLock.Checked = true;
            }

        }

        panel1.GroupingText = "";
    }

    #endregion

    #region fill controls

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        var objSales = new BL.Sales();
        ddlClientCode.Items.Clear();
        var ds = objSales.ClientsLocationWiseGetNew(ddlBranch.SelectedValue, "ALL", "", "", "0", txtFromDate.Text, txtToDate.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientCodeName";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            ddlClientCode.SelectedIndex = 0;


            var li1 = new RadComboBoxItem { Text = @Resources.Resource.All , Value = @"0" };
            ddlClientCode.Items.Insert(0, li1);
            ddlClientCode.SelectedIndex = 0;

        }
        else
        {
            var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlClientCode.Items.Insert(0, li);
            ddlClientCode.SelectedIndex = 0;
        }
        FillddlAsmt();

    }
    /// <summary>
    /// fills the branch
    /// </summary>
    private void FillddlBranch()
    {
        ViewState["dt"] = null; 
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        var objblUserManagement = new BL.UserManagement();
        var dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, BaseHrLocationCode);
        if (dsBranch != null && dsBranch.Tables.Count > 0 && dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationAutoId";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
        }
        FillddlClient();
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        ddlAsmtCode.Items.Clear();
        var objSale = new BL.Sales();
        var dsAsmt = objSale.AssignmentsOfClientScheduleLockUnlockGetNew(ddlBranch.SelectedValue, ddlClientCode.SelectedValue, "", "0", txtFromDate.Text, txtToDate.Text, "");
        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = dsAsmt.Tables[0];
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();
            ddlAsmtCode.SelectedIndex = 0;

            var li1 = new RadComboBoxItem { Text = @Resources.Resource.All , Value = @"0" };
            ddlAsmtCode.Items.Insert(0, li1);
            ddlAsmtCode.SelectedIndex = 0;
        }
        else
        {
            if (ddlClientCode.SelectedValue == "0")
            {
                var li1 = new RadComboBoxItem { Text = @Resources.Resource.All , Value = @"0" };
                ddlAsmtCode.Items.Insert(0, li1);
                ddlAsmtCode.SelectedIndex = 0;
            }
            else
            {
                var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
                ddlAsmtCode.Items.Insert(0, li);
                ddlAsmtCode.SelectedIndex = 0;
            }
        }
        FillPost();
    }
    /// <summary>
    /// Fills the post.
    /// </summary>
    protected void FillPost()
    {
        ddlPost.Items.Clear();
        var objOperationManagement = new BL.OperationManagement();
        var dsPost = objOperationManagement.PostForSelectedAsmtGet(int.Parse(ddlBranch.SelectedValue), ddlClientCode.SelectedValue, ddlAsmtCode.SelectedValue.Trim());
        if (dsPost != null && dsPost.Tables.Count > 0 && dsPost.Tables[0].Rows.Count > 0)
        {
            ddlPost.DataSource = dsPost.Tables[0];
            ddlPost.DataTextField = "PostDesc";
            ddlPost.DataValueField = "PostAutoId";
            ddlPost.DataBind();
            ddlPost.SelectedIndex = 0;

            var li1 = new RadComboBoxItem { Text = @Resources.Resource.All , Value = @"0" };
            ddlPost.Items.Insert(0, li1);
            ddlPost.SelectedIndex = 0;
        }
        else
        {
            if (ddlAsmtCode.SelectedValue.Trim() == "0")
            {
                var li1 = new RadComboBoxItem { Text = @Resources.Resource.All , Value = @"0" };
                ddlPost.Items.Insert(0, li1);
                ddlPost.SelectedIndex = 0;
            }
            else
            {
                var li = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
                ddlPost.Items.Insert(0, li);
                ddlPost.SelectedIndex = 0;
            }
        }
        ddlLockUnlockFor.SelectedIndex = 0;
    }
    #endregion

    #region Control events
    /// <summary>
    /// Makes the temporary table.
    /// </summary>
    private void MakeTempTable()
    {
        var dtDates = new DataTable();
        var dCol1 = new DataColumn("Date", typeof(System.String));
        var dCol2 = new DataColumn("WeekNo", typeof(System.Int32));
        dtDates.Columns.Add(dCol1);
        dtDates.Columns.Add(dCol2);
        ViewState["Dates"] = dtDates;
    }

    /// <summary>
    /// Fillddls the week.
    /// </summary>
    protected void FillddlWeek()
    {
        ViewState["dt"] = null;
        ddlWeek.Items.Clear();
        var li = new RadComboBoxItem();
        var intMonth = int.Parse(ddlMonth.SelectedItem.Value);
        var intYear = int.Parse(txtYear.Text);
        var intDays = decimal.Parse(DateTime.DaysInMonth(intYear, intMonth).ToString());
        var decNoOfWeeks = (intDays - GetDatebasedOnSystemParameters().Day) / 7;
        var intNoOfWeek = 0;
        if (decNoOfWeeks < 1) { intNoOfWeek = 1; }
        if (decNoOfWeeks > 1 && decNoOfWeeks < 2) { intNoOfWeek = 2; }
        if (decNoOfWeeks > 2 && decNoOfWeeks < 3) { intNoOfWeek = 3; }
        if (decNoOfWeeks > 3 && decNoOfWeeks < 4) { intNoOfWeek = 4; }
        else if (decNoOfWeeks > 4 && decNoOfWeeks < 5) { intNoOfWeek = 5; }
        else { intNoOfWeek = 6; }
        var i = 1;
        while (intNoOfWeek >= i)
        {
            li = new RadComboBoxItem { Text = i.ToString(), Value = i.ToString() };
            ddlWeek.Items.Add(li);
            i++;
        }

        SetFromAndToDate(GetDatebasedOnSystemParameters());
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;
        ddlWeek.Focus();
    }
    /// <summary>
    /// Defaults the week dates.
    /// </summary>
    private void DefaultTheWeekDates()
    {
        ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
        txtYear.Text = DateTime.Now.Year.ToString();
        ViewState["MonthChangeStatus"] = 0;
        GetWeekStartDay();
        GetStartEndDate();
        txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate.Value;
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;
    }
    /// <summary>
    /// Gets the week start day.
    /// </summary>
    private void GetWeekStartDay()
    {
        if (int.Parse(ViewState["MonthChangeStatus"].ToString()) == 0)
        {
            var dtDates = (DataTable)ViewState["Dates"];
            dtDates.Clear();
            ddlWeek.Items.Clear();
            var dtSelectedMonthFirstDay = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), 1);
            int nextMonth;
            var strYear = txtYear.Text;
            if (int.Parse(ddlMonth.SelectedValue) == 12)
            {
                strYear = Convert.ToString(int.Parse(txtYear.Text) + 1);
                nextMonth = 1;
            }
            else
            {
                nextMonth = int.Parse(ddlMonth.SelectedValue) + 1;
            }

            var dtNextMonthFirstDay = new DateTime(int.Parse(strYear), int.Parse(nextMonth.ToString()), 1);
            var dtCurrentMonthLastDay = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), 1).AddMonths(1).AddDays(-1);
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
                    var strCurrentMonthStartDate = ViewState["ScheduleWeeklyFromDay"].ToString();
                    var cultureInfo = new CultureInfo("en-us");
                    strScheduleWeeklyStartDay = DateTime.Parse(strCurrentMonthStartDate).ToString("dddd", cultureInfo);
                    strScheduleWeeklyEndDay = DateTime.Parse(DateTime.Parse(strCurrentMonthStartDate).AddDays(double.Parse("-1")).ToString()).ToString("dddd", cultureInfo);
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

            var weekNumberAndRange = "";
            while (status < count)
            {
                weekNumberAndRange = "";
                var tableDates = new DataTable();
                var dvDates = new DataView(dtDates);
                dvDates.RowFilter = "[WeekNo]='" + status + "'";
                tableDates = dvDates.ToTable();
                try
                {
                    weekNumberAndRange = DateTime.Parse(tableDates.Rows[0]["Date"].ToString()).ToString("dd-MMM-yy") + " - " + DateTime.Parse(tableDates.Rows[6]["Date"].ToString()).ToString("dd-MMM-yy");
                }
                catch (Exception)
                {
                }
                RadComboBoxItem li = new RadComboBoxItem
                {
                    Text = status + @"   [" + weekNumberAndRange + @"]",
                    Value = status.ToString()
                };
                ddlWeek.Items.Add(li);
                status = status + 1;
                tableDates.Dispose();
            }
            ViewState["Dates"] = dtDates;
        }
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
            HFToDate.Value = DateTime.Parse(dtStartEndDate.Rows[6]["Date"].ToString()).ToString("dd-MMM-yyyy");
            HFMaxDate.Value = DateTime.Parse(dtDates.Rows[dtDates.Rows.Count - 1]["Date"].ToString()).ToString("dd-MMM-yyyy");
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
            var objRoster = new BL.Roster();
            var strSelectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth.SelectedValue)) + "-" + txtYear.Text);
            var dt = objRoster.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strSelectedMonthStartDate, "weekly");
            var dtSelectedMonthFirstDate = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), 1);

            if (dt != null && dt.Rows.Count > 0)
            {
                var strScheduleWeeklyStartDay = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
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
            lblErrorMsg.Text = Resources.Resource.InvalidYear;
            return DateTime.Now;
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        ViewState["MonthChangeStatus"] = 0;
        GetWeekStartDay();
        GetStartEndDate();

        txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate.Value;
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;
        FillddlClient();
    }

  
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlWeek control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlWeek_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        ViewState["MonthChangeStatus"] = 1;
        if (ViewState["MonthChangeStatus"] == "0")
        {
            GetWeekStartDay();
        }
        GetStartEndDate();

        txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate.Value;
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;
        FillddlClient();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (txtYear.Text == "")
        {
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        if (txtYear.Text.Length < 4)
        {
            Show("Invalid Year");
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        try
        {
            FillddlWeek();
            SetFromAndToDate(GetDatebasedOnSystemParameters());
            txtYear.Focus();
        }
        catch (Exception ex)
        {
            Show("Invalid Year");
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        GetWeekStartDay();
        GetStartEndDate();
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
            dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
            txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
            weekStartDate.Value = txtFromDate.Text;
            weekEndDate.Value = txtToDate.Text;
        }
    }
    /// <summary>
    /// Handles the IndexChange event of the ddlLockUnlockFor control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlLockUnlockFor_IndexChange(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        gvScheduleLockUnLock.Visible = ddlLockUnlockFor.SelectedValue == "Sel";
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        gvScheduleLockUnLock.Visible = false;
        FillddlAsmt();

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        FillddlClient();

        gvScheduleLockUnLock.Visible = false;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        FillPost();
        gvScheduleLockUnLock.Visible = false;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPost control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlPost_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ViewState["dt"] = null;
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        GridView1.DataSource = null;
        GridView1.DataBind();
        gvScheduleLockUnLock.Visible = false;
    }


    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        try
        {
            if (DateTime.Parse(txtFromDate.Text) > DateTime.Parse(txtToDate.Text))
            {
                ViewState["dt"] = null;
                gvScheduleLockUnLock.DataSource = null;
                gvScheduleLockUnLock.DataBind();
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblErrorMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                return;
            }
            else if (DateTime.Parse(txtFromDate.Text) < DateTime.Parse(weekStartDate.Value))
            {
                ViewState["dt"] = null;
                gvScheduleLockUnLock.DataSource = null;
                gvScheduleLockUnLock.DataBind();
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblErrorMsg.Text = Resources.Resource.InvalidateFromDate + " " + Resources.Resource.WeekDay + " " + Resources.Resource.GreaterThan + " " + Resources.Resource.FromDate;
                return;
            }
            else if (DateTime.Parse(txtToDate.Text) > DateTime.Parse(weekEndDate.Value))
            {
                ViewState["dt"] = null;
                gvScheduleLockUnLock.DataSource = null;
                gvScheduleLockUnLock.DataBind();
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblErrorMsg.Text = Resources.Resource.InvalidToDate + " " + Resources.Resource.ToDate + " " + Resources.Resource.GreaterThan + " " + Resources.Resource.WeekEndDay;
                return;
            }
        }
        catch
        {
            ViewState["dt"] = null;
            gvScheduleLockUnLock.DataSource = null;
            gvScheduleLockUnLock.DataBind();
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblErrorMsg.Text = Resources.Resource.MsgInvalidDate;
            return;
        }

        if (rbUnlock.Checked)
        {
            switch (ddlClientCode.SelectedValue)
            {
                case "0":
                    Show(Resources.Resource.SelectClient);
                    return;
            }

            switch (ddlAsmtCode.SelectedValue)
            {
                case "0":
                    Show(Resources.Resource.SelectAssignment);
                    return;
            }
        }

        if (ViewState["dt"] != null)
        {
            ViewState["dt"] = null;
        }
        if (ddlLockUnlockFor.SelectedValue == "Sel")
        {

            FillgvScheduleLockUnLock();
            gvScheduleLockUnLock.Visible = true;

            panel1.GroupingText = Resources.Resource.ConvertScheduleToActual;
        }
        else
        {
            if (ddlPost.SelectedItem.Value != "-1")
            {
                if (rbLock.Checked)
                {
                    var objtran = new BL.Roster();
                    using (var ds = objtran.TransScheduleLockForAll(ddlAsmtCode.SelectedValue, txtFromDate.Text, txtToDate.Text, ddlBranch.SelectedValue, ddlClientCode.SelectedValue, ddlPost.SelectedValue, BaseUserID, "L"))
                    {

                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0][3].ToString()))
                        {
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            GridView1.DataSource = null;
                            GridView1.DataBind();
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgCanNotLockedScheduleIsAuthorized.Split(',')[0];
                            GridView1.DataSource = ds.Tables[0];
                            GridView1.DataBind();
                        }
                    }
                }

                if (rbUnlock.Checked == true)
                {
                    var objtran = new BL.Roster();
                    using (
                        var ds = objtran.TransScheduleUnlockForAll(ddlAsmtCode.SelectedValue, txtFromDate.Text,
                            txtToDate.Text, BaseLocationAutoID, ddlClientCode.SelectedValue, ddlPost.SelectedValue,
                            BaseUserID, "U"))
                    {
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            lblErrorMsg.Text = ds.Tables[0].Rows[0][1].ToString();
                        }
                    }
                }

            }
            else
            {
                DisplayMessageString(lblErrorMsg, Resources.Resource.Select + " " + Resources.Resource.Post);
            }
            gvScheduleLockUnLock.Visible = false;
        }

    }
    /// <summary>
    /// Handles the Changed event of the rbLock control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void rbLock_Changed(object sender, EventArgs e)
    {
        if (ViewState["dt"] != null)
        {
            ViewState["dt"] = null;
        }
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        
    }
    /// <summary>
    /// Handles the Changed event of the rbUnLock control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void rbUnLock_Changed(object sender, EventArgs e)
    {
        if (ViewState["dt"] != null)
        {
            ViewState["dt"] = null;
        }
        gvScheduleLockUnLock.DataSource = null;
        gvScheduleLockUnLock.DataBind();
        
    }
    #endregion

    #region function related to grid

    /// <summary>
    /// Fillgvs the schedule lock un lock.
    /// </summary>
    protected void FillgvScheduleLockUnLock()
    {
        try
        {
            if (DateTime.Parse(txtFromDate.Text) > DateTime.Parse(txtToDate.Text))
            {
                lblErrorMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                return;
            }
        }
        catch
        {
            lblErrorMsg.Text = Resources.Resource.MsgInvalidDate;
            return;
        }

        var objtran = new BL.Roster();
        var lockUnlock = rbLock.Checked ? "L" : "U";
        var objCommon = new BL.Common();
        if (!objCommon.IsValidDate(txtFromDate.Text) || !objCommon.IsValidDate(txtToDate.Text))
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            return;
        }

        DataTable dt;
        using (var ds = objtran.ScheduleLockUnlockGet(int.Parse(ddlBranch.SelectedValue), ddlClientCode.SelectedValue, ddlAsmtCode.SelectedValue, txtFromDate.Text, txtToDate.Text, ddlPost.SelectedValue.Trim(), lockUnlock))
        {
            dt = ds.Tables[0];
        }
        ViewState["dt"] = dt;

        gvScheduleLockUnLock.DataSource = ViewState["dt"];
        gvScheduleLockUnLock.DataBind();
        if (gvScheduleLockUnLock.FooterRow != null)
        {
            var btnLock = (Button)gvScheduleLockUnLock.FooterRow.FindControl("btnLock");
            var chkSelectAll = (CheckBox)gvScheduleLockUnLock.FooterRow.FindControl("chkSelectAll");
            if (btnLock != null)
            {
                btnLock.Text = rbLock.Checked ? "Lock Empoyees" : "UnLock Employees";
            }
            if (chkSelectAll != null)
            {
                chkSelectAll.Checked = false;
            }

        }
    }


    /// <summary>
    /// Handles the PageIndexChanging event of the gvScheduleLockUnLock control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleLockUnLock_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvScheduleLockUnLock.PageIndex = e.NewPageIndex;
        gvScheduleLockUnLock.EditIndex = -1;
        FillgvScheduleLockUnLock();
    }

    /// <summary>
    /// Handles the CheckedChanged event of the chkSelect control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        var chk = (CheckBox)sender;
        var row = (GridViewRow)chk.NamingContainer;
        var chkSelect = (CheckBox)gvScheduleLockUnLock.Rows[row.RowIndex].FindControl("chkSelect");

        var lblScheduleLockUnLockSno = (Label)gvScheduleLockUnLock.Rows[row.RowIndex].FindControl("lblScheduleLockUnLockSno");

        var ind = int.Parse(lblScheduleLockUnLockSno.Text);

        var dt = (DataTable)ViewState["dt"];

        if (chkSelect.Checked)
        {
            dt.Rows[ind - 1]["fldChk"] = true;
        }
        else
        {
            dt.Rows[ind - 1]["fldChk"] = false;
        }
        dt.AcceptChanges();
        ViewState["dt"] = dt;

    }

    /// <summary>
    /// Handles the Datechanged event
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Datechanged_Click(object sender, EventArgs e)
    {
            ViewState["dt"] = null;
            gvScheduleLockUnLock.DataSource = null;
            gvScheduleLockUnLock.DataBind();
            GridView1.DataSource = null;
            GridView1.DataBind();
    }
    /// <summary>
    /// Handles the CheckedChanged event of the chkSelectAll control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {

        var chkSelectAll = (CheckBox)sender;
        var dt = (DataTable)ViewState["dt"];
        for (var i = 0; i < dt.Rows.Count; i++)
        {
            if (chkSelectAll.Checked)
            {
                dt.Rows[i]["fldChk"] = true;
                hid_SelectAll.Value = "1";
            }
            else
            {
                dt.Rows[i]["fldChk"] = false;
                hid_SelectAll.Value = "0";
            }
        }

        dt.AcceptChanges();
        ViewState["dt"] = dt;
    }

    /// <summary>
    /// Handles the RowCommand event of the gvScheduleLockUnLock control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleLockUnLock_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "LockUnlockSchedule")
        {
            if (rbLock.Checked)
            {
                var objRost = new BL.Roster();

                var dt = (DataTable)ViewState["dt"];

                var schRosterAutoId = "";
                var dv = new DataView(dt) { RowFilter = "fldChk='" + true + "'" };
                var dtFilter = dv.ToTable();

                for (var i = 0; i < dtFilter.Rows.Count; i++)
                {
                    schRosterAutoId = schRosterAutoId + "," + dtFilter.Rows[i]["SchRosterAutoID"];
                }
                var ds = objRost.ScheduleLock(schRosterAutoId, txtFromDate.Text, txtToDate.Text, BaseUserID);
                if (ds != null && ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 0)
                {
                    
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0][3].ToString()))
                    {
                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                    }
                    else
                    {
                    lblErrorMsg.Text = Resources.Resource.MsgCanNotLockedScheduleIsAuthorized.Split(',')[0];
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                    }
                }
                gvScheduleLockUnLock.DataSource = null;
                gvScheduleLockUnLock.DataBind();
                hid_SelectAll.Value = "";
                FillgvScheduleLockUnLock();
            }
            else if (rbUnlock.Checked)
            {
                switch (ddlClientCode.SelectedValue)
                {
                    case "0":
                        Show(Resources.Resource.SelectClient);
                        return;
                }

                switch (ddlAsmtCode.SelectedValue)
                {
                    case "0":
                        Show(Resources.Resource.SelectAssignment);
                        return;
                }

                var objRost = new BL.Roster();

                var dt = (DataTable)ViewState["dt"];
                var dv = new DataView(dt);
                var schRosterAutoId = "";
                dv.RowFilter = "fldChk='" + true + "'";
                var dtFilter = dv.ToTable();
                for (var i = 0; i < dtFilter.Rows.Count; i++)
                {
                    schRosterAutoId = schRosterAutoId + "," + dtFilter.Rows[i]["SchRosterAutoID"];
                }

                if (schRosterAutoId == string.Empty) return;

                var ds = objRost.ScheduleUnlock(schRosterAutoId, txtFromDate.Text, txtToDate.Text, BaseUserID);

                if (ds != null && ds.Tables.Count > 0 & ds.Tables[0].Rows.Count > 0)
                {
                    lblErrorMsg.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                FillgvScheduleLockUnLock();
            }
        }

    }

    /// <summary>
    /// Handles the RowDataBound event of the gvScheduleLockUnLock control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleLockUnLock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
            chkSelectAll.Checked = hid_SelectAll.Value == "";
        }
    }
    #endregion


}
