// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="processRota.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Transactions_processRota.
/// </summary>
public partial class Transactions_processRota : BasePage //System.Web.UI.Page
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

        if (!IsPostBack)
        {
            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{
            //    lblPageHdrTitle.Text = Resources.Resource.ProcessRota;
            //}

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.ProcessRota + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                //fillPayPeriod();
                txtYear.Text = DateTime.Now.Year.ToString();
                int intMonth = DateTime.Now.Month;
                ddlMonth.Items[intMonth - 1].Selected = true;

                //code modified by Manish on 5-feb 2010 
                //description set start date * End date according to company payperiod 

                //Commented by ritul bakshi
                //string[] strArray = new string[2];
                //strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, intMonth, int.Parse(txtYear.Text));
                //txtFromDate.Text = strArray[0];
                //txtToDate.Text = strArray[1];

                int monthval = DateTime.Now.Month;
                ddlMonth.SelectedValue = monthval.ToString();

                txtYear.Text = DateTime.Now.Year.ToString();

                txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

                GetWeekStartDay();

                txtFromDate.Text = HDFromDate.Value;
                txtToDate.Text = HDToDate.Value;

                if (IsWriteAccess == true)
                {
                    btnProcess.Visible = true;
                }
                else
                {
                    btnProcess.Visible = false;
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }

    }

    ////protected void fillPayPeriod()
    ////{
    ////    BL.MastersManagement objMastersManagement = new BL.MastersManagement();
    ////    DataSet ds = new DataSet();
    ////    ds = objMastersManagement.blPayPeriodOfCompany_Get(BaseCompanyCode.ToString());
    ////    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    ////    {
    ////        ddlPayPeriod.DataSource = ds.Tables[0];
    ////        ddlPayPeriod.DataTextField = "PayPeriodDesc";
    ////        ddlPayPeriod.DataValueField = "PayPeriodDesc";
    ////        ddlPayPeriod.DataBind();
    ////    }
    ////}

    /// <summary>
    /// Gets the week start day.
    /// </summary>
    private void GetWeekStartDay()
    {
        DataTable dtDates = new DataTable();
        //if (MonthChangeStatus == 0)
        //{
        DataColumn dCol1 = new DataColumn("Date", typeof(System.String));
        DataColumn dCol2 = new DataColumn("WeekNo", typeof(System.Int32));
        dtDates.Columns.Add(dCol1);
        dtDates.Columns.Add(dCol2);

        dtDates.Clear();
        //ddlWeek.Items.Clear();
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
        while (dtSelectedMonthFirstDay.DayOfWeek != DayOfWeek.Sunday)
        {
            dtSelectedMonthFirstDay = dtSelectedMonthFirstDay.AddDays(1);
        }
        if (dtCurrentMonthLastDay.DayOfWeek != DayOfWeek.Saturday)
        {
            while (dtNextMonthFirstDay.DayOfWeek != DayOfWeek.Saturday)
            {
                dtNextMonthFirstDay = dtNextMonthFirstDay.AddDays(1);
            }
        }
        else
        {
            dtNextMonthFirstDay = dtCurrentMonthLastDay;
        }
        string dtSelectedMonthFirstDate = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
        string dtNextMonthFirstDate = dtNextMonthFirstDay.ToString("dd-MMM-yyyy");

        HDFromDate.Value = dtSelectedMonthFirstDate.ToString();
        HDToDate.Value = dtNextMonthFirstDate.ToString();

        //int Count = 1;
        //int RowIndex = 1;
        //DateTime nextDate;
        //nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
        //while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
        //{
        //    DataRow dr = dtDates.NewRow();
        //    dr["Date"] = nextDate;
        //    dr["WeekNo"] = Count;
        //    nextDate = nextDate.AddDays(1);
        //    if (nextDate.DayOfWeek == DayOfWeek.Sunday)
        //    {
        //        Count = Count + 1;
        //    }
        //    RowIndex = RowIndex + 1;
        //    dtDates.Rows.Add(dr);
        //}
        //int Status = 1;
        //ListItem li;
        //while (Status < Count)
        //{
        //    li = new ListItem();
        //    li.Text = Status.ToString();
        //    li.Value = Status.ToString();
        //    //ddlWeek.Items.Add(li);
        //    Status = Status + 1;
        //}
        //}

    }





    /// <summary>
    /// Handles the Click event of the btnProcess control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        BL.Roster objRost = new BL.Roster();
        DataSet ds = new DataSet();
        //code commented by Manish on 4-feb 2010
        //description  passing from date & To Date according to payperiod 
        //ds = objRost.blTran_EmployeeAttendance_Process(BaseCompanyCode,0,int.Parse(BaseLocationAutoID.ToString()), int.Parse(ddlMonth.SelectedValue),int.Parse(txtYear.Text), BaseUserID.ToString());
        if (BaseCountryName != null && BaseCountryName.ToUpper() == "Morocco".ToUpper())
        {
            ds = objRost.EmployeeAttendanceProcess(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, txtFromDate.Text, txtToDate.Text, BaseUserID);
            lblErrorMsg.Text = Resources.Resource.ProcessCompleted;
        }
        else if (BaseCountryName != null && BaseCountryName.ToUpper() == "Barbados".ToUpper())
        {
            ds = objRost.EmployeeAttendanceProcessGreece(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, txtFromDate.Text, txtToDate.Text, BaseUserID);
            lblErrorMsg.Text = Resources.Resource.ProcessCompleted;
        }
        else
        {
            ds = objRost.EmployeeAttendanceProcess(BaseCompanyCode, BaseHrLocationCode, int.Parse(BaseLocationAutoID.ToString()), txtFromDate.Text, txtToDate.Text, BaseUserID.ToString());
            lblErrorMsg.Text = Resources.Resource.ProcessCompleted;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //
            }
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPayPeriod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPayPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //code modified by Manish on 5-feb 2010 
        //description set start date * End date according to company payperiod 
        GetWeekStartDay();

        txtFromDate.Text = HDFromDate.Value;
        txtToDate.Text = HDToDate.Value;

        //commented by ritul bakshi
        //string[] strArray = new string[2];
        //strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(ddlMonth.SelectedValue.ToString()), int.Parse(txtYear.Text));
        //txtFromDate.Text = strArray[0];
        //txtToDate.Text = strArray[1];
    }
    /// <summary>
    /// Handles the OnTextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_OnTextChanged(object sender, EventArgs e)
    {
        txtFromDate.Text = DateFormat(DateTime.Parse("01" + "-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text).ToString("dd-MMM-yyyy"));
        txtToDate.Text = DateFormat(DateTime.Parse(LastDateOfMonth(txtFromDate.Text) + "-" + GetMonthName(int.Parse(ddlMonth.SelectedValue.ToString())) + "-" + txtYear.Text).ToString("dd-MMM-yyyy"));
    }
    /// <summary>
    /// Lasts the date of month.
    /// </summary>
    /// <param name="date1">The date1.</param>
    /// <returns>String.</returns>
    protected string LastDateOfMonth(string date1)
    {
        string totalDays = DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue.ToString())).ToString();
        return totalDays;
    }
    /// <summary>
    /// Gets the name of the month.
    /// </summary>
    /// <param name="month">The month.</param>
    /// <returns>System.String.</returns>
    private static string GetMonthName(int month)
    {
        DateTime date = new DateTime(1900, month, 1);
        return date.ToString("MMMM");
    }


}
