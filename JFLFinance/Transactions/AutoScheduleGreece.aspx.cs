// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="AutoScheduleGreece.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_AutoScheduleGreece.
/// </summary>
public partial class Transactions_AutoScheduleGreece : BasePage
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
            //    lblPageHdrTitle.Text = Resources.Resource.AutoSchedule;
            //}
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.AutoSchedule + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            //fillPayPeriod();
            fillClients();
            FillAsmtDetails();
            txtYear.Text = DateTime.Now.Year.ToString();
            txtYear_Nextperiod.Text = DateTime.Now.Year.ToString();
            setDates(ddlMonth, txtYear, txtFromDate, txtToDate,"Current");
            setDates(ddlMonth_Nextperiod, txtYear_Nextperiod, txtFromDate_NextPeriod, txtToDate_NextPeriod,"Next");
        }
    }

    //protected void fillPayPeriod()
    //{
    //    BL.MastersManagement objMastersManagement = new BL.MastersManagement();
    //    DataSet ds = new DataSet();
    //    ds = objMastersManagement.blPayPeriodOfCompany_Get("", BaseCompanyCode.ToString());
    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        ddlPayPeriod.DataSource = ds.Tables[0];
    //        ddlPayPeriod.DataTextField = "PayPeriodDesc";
    //        ddlPayPeriod.DataValueField = "PayPeriodDesc";
    //        ddlPayPeriod.DataBind();
    //    }
    //}

    /// <summary>
    /// Fills the clients.
    /// </summary>
    protected void fillClients()
    {

        BL.Sales objSale = new BL.Sales();
        DataSet dsClient = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            dsClient = objSale.ClientsMappedToLocationGet(BaseLocationAutoID);
        }

        if (dsClient.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = dsClient.Tables[0].DefaultView;
            ddlClient.DataTextField = "ClientCodeName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem(Resources.Resource.All, ""));
        }
        else
        {
            ddlAssignment.Items.Clear();
            ddlClient.Items.Clear();
            btnProceed.Enabled = false;
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlClient.Items.Add(li);
            ddlAssignment.Items.Add(li);
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
        setDates(ddlMonth, txtYear, txtFromDate, txtToDate,"Current");
        fillClients();
        ddlAssignment.Items.Clear();
        FillAsmtDetails();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth_Nextperiod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_Nextperiod_SelectedIndexChanged(object sender, EventArgs e)
    {
        setDates(ddlMonth_Nextperiod, txtYear_Nextperiod, txtFromDate_NextPeriod, txtToDate_NextPeriod,"Next");
    }
    /// <summary>
    /// Handles the TextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        setDates(ddlMonth,txtYear,txtFromDate,txtToDate,"Current");
    }
    /// <summary>
    /// Handles the TextChanged event of the txtYear_Nextperiod control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_Nextperiod_TextChanged(object sender, EventArgs e)
    {
        setDates(ddlMonth_Nextperiod,txtYear_Nextperiod,txtFromDate_NextPeriod,txtToDate_NextPeriod,"Next");
    }
    /// <summary>
    /// Sets the dates.
    /// </summary>
    /// <param name="ddlMonth">The DDL month.</param>
    /// <param name="txtYear">The text year.</param>
    /// <param name="txtFromDate">The text from date.</param>
    /// <param name="txtToDate">The text to date.</param>
    /// <param name="strDateStatus">The string date status.</param>
    protected void setDates(DropDownList ddlMonth, TextBox txtYear, TextBox txtFromDate, TextBox txtToDate,string strDateStatus)
    {
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
        while (dtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleStartDay.Trim().ToLower())
        {
            dtSelectedMonthFirstDay = dtSelectedMonthFirstDay.AddDays(1);
        }
        if (dtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleEndDay.Trim().ToLower())
        {
            while (dtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleEndDay.Trim().ToLower())
            {
                dtNextMonthFirstDay = dtNextMonthFirstDay.AddDays(1);
            }
        }
        else
        {
            dtNextMonthFirstDay = dtCurrentMonthLastDay;
        }
       //txtFromDate.Text = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
        txtToDate.Text = dtNextMonthFirstDay.ToString("dd-MMM-yyyy");
        if (strDateStatus.Trim().ToLower() == "Current".Trim().ToLower())
        {
            TimeSpan ts = new TimeSpan();
            ts = TimeSpan.Parse("6");
            txtFromDate.Text = DateTime.Parse(txtToDate.Text).Subtract(ts).ToString("dd-MMM-yyyy");
            HFStartDate.Value = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
        }
        else
        {
            txtFromDate.Text = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
           // HFStartDate.Value = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
        }
       

    }


    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {

        if (int.Parse(txtYear.Text) == int.Parse(txtYear_Nextperiod.Text) && int.Parse(ddlMonth_Nextperiod.SelectedItem.Value) <= int.Parse(ddlMonth.SelectedItem.Value))
        {
            lblErrorMsg.Text = Resources.Resource.NextPeriodDateShouldBeGreaterThanScheduledPeriodDate;
        }
        else if (int.Parse(txtYear.Text) > int.Parse(txtYear_Nextperiod.Text))
        {
            lblErrorMsg.Text = Resources.Resource.NextPeriodDateShouldBeGreaterThanScheduledPeriodDate;
        }
        else if (ddlClient.SelectedValue != "" && ddlAssignment.SelectedValue == "")
        {
            lblErrorMsg.Text = Resources.Resource.MsgRequiredAssignment;
        }
        else if (txtFromDate.Text == "" || txtToDate.Text == "")
        {
            lblErrorMsg.Text = Resources.Resource.PayPeriodNotDefined;
        }

        else
        {
            BL.Roster objRost = new BL.Roster();
            DataSet ds = new DataSet();
            ds = objRost.EmployeeWiseAutoSchedule(int.Parse(BaseLocationAutoID), ddlClient.SelectedValue.ToString(), ddlAssignment.SelectedValue.ToString(), DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text), DateTime.Parse(txtFromDate_NextPeriod.Text), DateTime.Parse(txtToDate_NextPeriod.Text), BaseUserID.ToString(), DateTime.Parse(HFStartDate.Value));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClient control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillAsmtDetails();

    }
    /// <summary>
    /// Fills the asmt details.
    /// </summary>
    private void FillAsmtDetails()
    {
        if (ddlClient.SelectedItem.Value != "")
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet dsAsmt = new DataSet();
            string strClientCode = ddlClient.SelectedValue;
            dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge,"");

            if (dsAsmt.Tables[0].Rows.Count > 0)
            {
                ddlAssignment.DataSource = dsAsmt.Tables[0].DefaultView;
                ddlAssignment.DataTextField = "AsmtDetail";
                ddlAssignment.DataValueField = "AsmtCode";
                ddlAssignment.DataBind();
                btnProceed.Enabled = true;
            }
            else
            {
                ddlAssignment.Items.Clear();
                ListItem li = new ListItem();
                li.Text = Resources.Resource.NoDataToShow;
                li.Value = "-1";
                ddlAssignment.Items.Add(li);
                btnProceed.Enabled = false;
            }


        }
        else
        {
            ddlAssignment.Items.Clear();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "";
            ddlAssignment.Items.Add(li);
            btnProceed.Enabled = true;
        }
    }
}
