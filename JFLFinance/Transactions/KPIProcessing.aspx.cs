// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="KPIProcessing.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Globalization;
using Telerik.Web.UI;

/// <summary>
/// Class Transactions_KPIProcessing.
/// </summary>
public partial class Transactions_KPIProcessing : BasePage
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
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["MonthChangeStatus"] = 0;
            ddlWeek.Visible = false;
            lblWeekNo.Visible = false;
            txtYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            MakeTempTable();
            if (ddlProcessing.SelectedValue.ToString() != "Month")
            {
                FillddlWeek();
                SetFromAndToDate(GetDatebasedOnSystemParameters());
                GetDatebasedOnSystemParameters();
            }
            else
            {

                ProcessingTypeDateGet();
            }

        }
    }

    /// <summary>
    /// Sets from and automatic date.
    /// </summary>
    /// <param name="dtSelectedMonthFirstDate">The dt selected month first date.</param>
    private void SetFromAndToDate(DateTime dtSelectedMonthFirstDate)
    {
        if (ddlWeek.SelectedItem != null)
        {
            dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays((int.Parse(ddlWeek.SelectedItem.Value.ToString()) - 1) * 7);
            txtFromDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
            dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
            txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
            weekStartDate.Value = txtFromDate.Text;
            weekEndDate.Value = txtToDate.Text;
        }
    }

    /// <summary>
    /// Processings the type date get.
    /// </summary>
    private void ProcessingTypeDateGet()
    {
        if (ddlProcessing.SelectedValue.ToString() == "Month")
        {
            ddlWeek.Visible = false;
            lblWeekNo.Visible = false;
            DateTime from = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), 1);
            //DateTime todate = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), from.());
            DateTime todate = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue)));
            HFFromDate.Value = DateFormat(from);
            HFToDate.Value = DateFormat(todate);
            txtFromDate.Text = HFFromDate.Value;
            txtToDate.Text = HFToDate.Value;
            weekStartDate.Value = txtFromDate.Text;
            weekEndDate.Value = txtToDate.Text;
        }
    }


    /// <summary>
    /// Gets the datebased configuration system parameters.
    /// </summary>
    /// <returns>DateTime.</returns>
    private DateTime GetDatebasedOnSystemParameters()
    {

        try
        {
            DataTable dt = new DataTable();
            BL.Roster objRoster = new BL.Roster();
            string strSelectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text);
            dt = objRoster.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strSelectedMonthStartDate, "Weekly".Trim().ToLower());
            DateTime dtSelectedMonthFirstDate = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue.ToString()), 1);

            if (dt != null && dt.Rows.Count > 0)
            {
                string strScheduleWeeklyStartDay = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                string strScheduleWeeklyEndDay = dt.Rows[0]["ScheduleWeeklyEndDay"].ToString();

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
            lblErrorMsg.Text = "Invalid Year Selected";
            return DateTime.Now;
        }

    }
    /// <summary>
    /// Makes the temporary table.
    /// </summary>
    private void MakeTempTable()
    {
        DataTable dtDates = new DataTable();
        DataColumn dCol1 = new DataColumn("Date", typeof(System.String));
        DataColumn dCol2 = new DataColumn("WeekNo", typeof(System.Int32));
        dtDates.Columns.Add(dCol1);
        dtDates.Columns.Add(dCol2);
        ViewState["Dates"] = dtDates;
    }

    /// <summary>
    /// Fillddls the week.
    /// </summary>
    protected void FillddlWeek()
    {
        ddlWeek.Items.Clear();
        RadComboBoxItem li = new RadComboBoxItem();
        int intMonth = int.Parse(ddlMonth.SelectedItem.Value.ToString());
        int intYear = int.Parse(txtYear.Text);
        decimal intDays = decimal.Parse(System.DateTime.DaysInMonth(intYear, intMonth).ToString());
        decimal decNoOfWeeks = (intDays - GetDatebasedOnSystemParameters().Day) / 7;
        int intNoOfWeek = 0;
        if (decNoOfWeeks < 1) { intNoOfWeek = 1; }
        if (decNoOfWeeks > 1 && decNoOfWeeks < 2) { intNoOfWeek = 2; }
        if (decNoOfWeeks > 2 && decNoOfWeeks < 3) { intNoOfWeek = 3; }
        if (decNoOfWeeks > 3 && decNoOfWeeks < 4) { intNoOfWeek = 4; }
        else if (decNoOfWeeks > 4 && decNoOfWeeks < 5) { intNoOfWeek = 5; }
        else { intNoOfWeek = 6; }
        int i = 1;
        while (intNoOfWeek >= i)
        {
            li = new RadComboBoxItem();
            li.Text = i.ToString();
            li.Value = i.ToString();
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
            DataTable dtDates = new DataTable();
            dtDates = (DataTable)ViewState["Dates"];
            dtDates.Clear();
            // dtDates.Clear();
            ddlWeek.Items.Clear();
            DateTime dtSelectedMonthFirstDay = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue.ToString()), 1);
            int NextMonth;
            string strYear = txtYear.Text;
            if (int.Parse(ddlMonth.SelectedValue.ToString()) == 12)
            {
                strYear = Convert.ToString(int.Parse(txtYear.Text) + 1);
                NextMonth = 1;
            }
            else
            {
                NextMonth = int.Parse(ddlMonth.SelectedValue.ToString()) + 1;
            }

            DateTime dtNextMonthFirstDay = new DateTime(int.Parse(strYear), int.Parse(NextMonth.ToString()), 1);
            DateTime dtCurrentMonthLastDay = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue.ToString()), 1).AddMonths(1).AddDays(-1);
            // while (dtSelectedMonthFirstDay.DayOfWeek != DayOfWeek.Sunday)
            string strScheduleWeeklyStartDay = string.Empty;
            string strScheduleWeeklyEndDay = string.Empty;
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
                    CultureInfo CultureInfo = new CultureInfo("en-us");
                    strScheduleWeeklyStartDay = DateTime.Parse(strCurrentMonthStartDate).ToString("dddd", CultureInfo);
                    strScheduleWeeklyEndDay = DateTime.Parse(DateTime.Parse(strCurrentMonthStartDate).AddDays(double.Parse("-1")).ToString()).ToString("dddd", CultureInfo);
                }
            }

            while (dtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyStartDay.ToString().Trim().ToLower())
            {
                if (strScheduleWeeklyStartDay == null || strScheduleWeeklyStartDay == "")
                {
                    break;
                }
                dtSelectedMonthFirstDay = dtSelectedMonthFirstDay.AddDays(1);
            }
            if (dtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyEndDay.ToString().Trim().ToLower())
            {
                while (dtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != strScheduleWeeklyEndDay.ToString().Trim().ToLower())
                {
                    if (strScheduleWeeklyEndDay == null || strScheduleWeeklyEndDay == "")
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

            string dtSelectedMonthFirstDate = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
            string dtNextMonthFirstDate = dtNextMonthFirstDay.ToString("dd-MMM-yyyy");
            int Count = 1;
            int RowIndex = 1;

            DateTime nextDate;
            nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
            while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
            {
                DataRow dr = dtDates.NewRow();
                dr["Date"] = nextDate.ToString("dd-MMM-yyyy");
                dr["WeekNo"] = Count;
                nextDate = nextDate.AddDays(1);
                if (nextDate.DayOfWeek.ToString().Trim().ToLower() == strScheduleWeeklyStartDay.ToString().Trim().ToLower())
                {
                    Count = Count + 1;
                }
                RowIndex = RowIndex + 1;
                dtDates.Rows.Add(dr);
            }

            int Status = 1;
            RadComboBoxItem li;

            var weekNumberAndRange = "";
            while (Status < Count)
            {
                weekNumberAndRange = "";
                DataTable tableDates = new DataTable();
                DataView dvDates = new DataView(dtDates);
                dvDates.RowFilter = "[WeekNo]='" + Status.ToString() + "'";
                tableDates = dvDates.ToTable();
                try
                {
                    weekNumberAndRange = DateTime.Parse(tableDates.Rows[0]["Date"].ToString()).ToString("dd-MMM-yy") + " - " + DateTime.Parse(tableDates.Rows[6]["Date"].ToString()).ToString("dd-MMM-yy");
                }
                catch (Exception ex)
                {
                }
                li = new RadComboBoxItem();
                li.Text = Status.ToString() + "   [" + weekNumberAndRange + "]";
                li.Value = Status.ToString();
                ddlWeek.Items.Add(li);
                Status = Status + 1;
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
        DataTable dtDates = (DataTable)ViewState["Dates"];
        DataView dv = new DataView(dtDates);
        if (ddlWeek != null && ddlWeek.SelectedValue != "")
        {
            dv.RowFilter = "[WeekNo]='" + (ddlWeek.SelectedValue.ToString()) + "'";
            DataTable dtStartEndDate = new DataTable();
            dtStartEndDate = dv.ToTable();
            HFFromDate.Value = DateTime.Parse(dtStartEndDate.Rows[0]["Date"].ToString()).ToString("dd-MMM-yyyy");
            HFToDate.Value = DateTime.Parse(dtStartEndDate.Rows[6]["Date"].ToString()).ToString("dd-MMM-yyyy");
            HFMaxDate.Value = DateTime.Parse(dtDates.Rows[dtDates.Rows.Count - 1]["Date"].ToString()).ToString("dd-MMM-yyyy");
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (ddlProcessing.SelectedValue.ToString() == "Month")
        {
            ProcessingTypeDateGet();
            return;
        }

        ddlWeek.Visible = true;
        lblWeekNo.Visible = true;
        ViewState["MonthChangeStatus"] = 0;
        FillddlWeek();
        SetFromAndToDate(GetDatebasedOnSystemParameters());
        GetWeekStartDay();
        GetStartEndDate();

        txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate.Value;
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlProcessing control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlProcessing_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (ddlProcessing.SelectedValue.ToString() == "Month")
        {
            ProcessingTypeDateGet();
            return;
        }
        ddlWeek.Visible = true;
        lblWeekNo.Visible = true;
        ViewState["MonthChangeStatus"] = 0;
        FillddlWeek();
        SetFromAndToDate(GetDatebasedOnSystemParameters());
        GetWeekStartDay();
        GetStartEndDate();

        txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate.Value;
        weekStartDate.Value = txtFromDate.Text;
        weekEndDate.Value = txtToDate.Text;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlWeek control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs" /> instance containing the event data.</param>
    protected void ddlWeek_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (ddlProcessing.SelectedValue.ToString() == "Month")
        {
            ProcessingTypeDateGet();
            return;
        }
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
    }
    /// <summary>
    /// Handles the TextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        if (txtYear.Text == "")
        {
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        if (txtYear.Text.Length < 4)
        {
            Show("Invalid Year");
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        if (ddlProcessing.SelectedValue.ToString() == "Month")
        {
            ProcessingTypeDateGet();
            return;
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
    /// Handles the Click event of the btnProcess control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected void btnProcess_Click(object sender, EventArgs e)
    {

        BL.KPI objKpi = new BL.KPI();
        DataSet ds = new DataSet();
        ds = objKpi.KPIProcessing(BaseCompanyCode, txtFromDate.Text, txtToDate.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
           // DisplayMessage(lblErrorMsg,"54");

        }
    }
}