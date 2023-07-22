// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_Hours_Kenya.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Threading;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
/// <summary>
/// Class Sales_RptGroup_Hours_Kenya.
/// </summary>
public partial class Sales_RptGroup_Hours_Kenya : BasePage
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
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //======================================================
            /* code added by Manish to Open report in New Page*/

            //btnViewReport.Attributes["onMouseDown"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ViewReport.aspx';";
            //this.Form.Attributes["onMouseOver"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";
            // this.btnViewReport.Attributes.Add("onclick", "this.form.target='_blank'");

            /* code added by Manish to Open report in New Page*/
            //======================================================

            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.HoursComparison; }

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.HoursComparison + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID.ToString() + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID.ToString() + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                ////  ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientName.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");

                FillddlReportName();
                btnViewReport.Enabled = true;
                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }

                HFStartDate.Value = FirstDateOfCurrentMonth_Get();
                HFEndDate.Value = LastDateOfCurrentMonth_Get();
                MakeTempTable();
                ddlMonth.SelectedValue = DateTime.Parse(HFStartDate.Value).Month.ToString();
                txtYear.Text = DateTime.Now.Year.ToString();
                txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                //// *******  modified by Manish on 16-mar-2010 added new common bl function SetDatesFromPayPeriod *********
                //// ******* due to getting dates according to pay period ***********************************************

                string[] strArray = new string[2];
                strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Year.ToString()));
                txtFromDate.Text = strArray[0];
                txtToDate.Text = strArray[1];
                ViewState["MonthChangeStatus"] = 0;
                GetWeekStartDay();
                GetStartEndDate();
                //txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                //txtToDate.Text = LastDateOfCurrentMonth_Get();

                FillDivision(string.Empty);
                FillddlClient();
                FillddlClientID();
                FillddlAreaID();//Added by Manoj(New Parameter for All Reports) on 17/01/2012
                ShowHideReportParameterControles();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
        else
        {
            if(string.IsNullOrEmpty(txtYear.Text))
            {
                txtYear.Text = Convert.ToString(DateTime.Now.Year);
            }

        }

        lblErrorMsg.Text = "";

    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
       
        ListItem li = new ListItem();
        li = new ListItem();
        li.Text = Resources.Resource.rptRedHours.ToString();
        li.Value = "RedHourDetail";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.rptMIS.ToString();
        li.Value = "MIS";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.RotaOnContractedHrs.ToString();
        li.Value = "RotaContractedHrs";
        ddlReportName.Items.Add(li);
    }
    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision(string status)
    {
        DataSet dsDivision = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();
            if (status == string.Empty)
            {
                ddlDivision.SelectedValue = BaseHrLocationCode;
            }
            FillBranch(status);
        }

       
    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch(string status)
    {
        ddlBranch.Items.Clear();
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
            if (status == string.Empty)
            {
                ddlBranch.SelectedValue = BaseLocationCode;
            }
            FillddlAreaID();
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlBranch.Items.Insert(0, li);
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        ddlClientCode.Items.Clear();
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsclient = new DataSet();
        dsclient = objSale.GetCurrentLocationAutoID(BaseCompanyCode, ddlBranch.SelectedValue, ddlDivision.SelectedValue);
        string currentCellValue = string.Empty;
        DataTable dtarea = dsclient.Tables[0];
        foreach (DataRow dr in dtarea.Rows)
        {
            currentCellValue = dr["LocationAutoID"].ToString();
        }
        ds = objSales.ClientAreaInchargeWiseGet(currentCellValue, ddlAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text);        
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();

            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlClientCode.Items.Insert(0, li1);
            if (ddlClientCode.SelectedItem.Value.ToString() != null)
            {
                FillddlAsmt();
            }
        }
        else{
        
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlClientCode.Items.Insert(0, li);
         }

        
  }
    
    
    /// <summary>
    /// Fillddls the client identifier.
    /// </summary>
    protected void FillddlClientID()
    {

        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.ClientsLocationWiseGet(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientId.DataSource = ds.Tables[0];
            ddlClientId.DataTextField = "ClientNameCode";
            ddlClientId.DataValueField = "ClientCode";
            ddlClientId.DataBind();

            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlClientId.Items.Insert(0, li1);
        }

    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();
        DataSet dsAsmt = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        BL.Sales objSales = new BL.Sales();
        
        DataSet dsasmt = new DataSet();
        dsasmt = objOperationManagement.GetCurrentLocationAutoID(BaseCompanyCode, ddlBranch.Text, ddlDivision.SelectedValue);
        string currentCellValue = string.Empty;
        DataTable dtarea = dsasmt.Tables[0];
        foreach (DataRow dr in dtarea.Rows)
        {
            currentCellValue = dr["LocationAutoID"].ToString();
        }
        if(ddlClientCode.SelectedItem.Value.ToString() == "ALL")
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlAsmtCode.Items.Insert(0, li1);
        }
        else
        {
        dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(currentCellValue), ddlClientCode.SelectedItem.Value.ToString(), HFStartDate.Value, HFEndDate.Value, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
        if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
        {
            ddlAsmtCode.DataSource = dsAsmt.Tables[0];
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();

            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlAsmtCode.Items.Insert(0, li);
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlAsmtCode.Items.Insert(0, li);
        }
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
    /// Gets the week start day.
    /// </summary>
    private void GetWeekStartDay()
    {
        if (int.Parse(ViewState["MonthChangeStatus"].ToString()) == 0)
        {
            DataTable dtDates = new DataTable();
            dtDates = (DataTable)ViewState["Dates"];
            dtDates.Clear();
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
                while (dtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleStartDay.Trim().ToLower())
                {
                    dtSelectedMonthFirstDay = dtSelectedMonthFirstDay.AddDays(1);
                }
                if (dtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleEndDay.Trim().ToLower())
                {
                    while (dtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleStartDay.Trim().ToLower())
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
                int Count = 1;
                int RowIndex = 1;


                DateTime nextDate;
                nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
                while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
                {
                    DataRow dr = dtDates.NewRow();
                    dr["Date"] = nextDate;
                    dr["WeekNo"] = Count;
                    nextDate = nextDate.AddDays(1);
                    if (nextDate.DayOfWeek.ToString().Trim().ToLower() == BaseScheduleStartDay.Trim().ToLower())
                    {
                        Count = Count + 1;
                    }
                    RowIndex = RowIndex + 1;
                    dtDates.Rows.Add(dr);
                }
                int Status = 1;
                ListItem li;
                while (Status < Count)
                {
                    li = new ListItem();
                    li.Text = Status.ToString();
                    li.Value = Status.ToString();
                    ddlWeek.Items.Add(li);
                    Status = Status + 1;
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
        dv.RowFilter = "[WeekNo]='" + (ddlWeek.SelectedValue.ToString()) + "'";
        DataTable dtStartEndDate = new DataTable();
        dtStartEndDate = dv.ToTable();
        HFFromDate.Value = DateFormat(dtStartEndDate.Rows[0]["Date"].ToString());
        HFToDate.Value = DateFormat(dtStartEndDate.Rows[6]["Date"].ToString());
        HFMaxDate.Value = DateFormat(dtDates.Rows[dtDates.Rows.Count - 1]["Date"].ToString());
    }
    #endregion

    #region Controles Events
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
        FillBranch("Changed");

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedItem.Value.ToString() != null)
        {
            FillddlAreaID();
            FillddlClient();
            

        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClient();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtYear.Text == "0000")
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
        }
        else
        {
            FillHiddenDate();
            FillddlAsmt();
            ViewState["MonthChangeStatus"] = 0;
            GetWeekStartDay();
            GetStartEndDate();
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlWeek control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["MonthChangeStatus"] = 1;
        if (ViewState["MonthChangeStatus"] == "0")
        {
            GetWeekStartDay();
        }
        GetStartEndDate();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtYear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtYear_TextChanged(object sender, EventArgs e)
    {
        int year = Convert.ToInt32(txtYear.Text);
        if (year >= 0000 && year <= 1752 || year == 9999)
        {
            lblErrorMsg.Text = Resources.Resource.MsgInvalidDate;
            txtYear.Text = string.Empty;
        }
        else
        {
            FillHiddenDate();
            FillddlAsmt();
            ViewState["MonthChangeStatus"] = 0;
            if (txtYear.Text == "")
            {
                txtYear.Text = DateTime.Now.Year.ToString();

            }
            GetWeekStartDay();
            GetStartEndDate();
            lblErrorMsg.Text = string.Empty;
        
    }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClientCode.SelectedItem.Value.ToString() != null)
        {
            FillddlAsmt();
        }
    }
    /// <summary>
    /// Fills the hidden date.
    /// </summary>
    protected void FillHiddenDate()
    {
        string[] strArray = new string[2];
        strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(ddlMonth.SelectedItem.Value.ToString()), int.Parse(txtYear.Text.ToString()));
        HFStartDate.Value = strArray[0];
        HFEndDate.Value = strArray[1];
    }
    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        HideAllControles();
        switch (strReportName)
        {
            case "ActualScheduleContractedHrs":
                PanelClientId.Visible = true;
                PanelDates.Visible = true;
                PanelPriceOption.Visible = true;
                PanelVariance.Visible = true;
                PanelAreaID.Visible = true;
                break;
            case "ScheduleContractedHrs.rpt":

                PanelClientId.Visible = true;
                PanelDates.Visible = true;
                PanelPriceOption.Visible = true;
                PanelVariance.Visible = true;
                PanelAreaID.Visible = true;
                break;

            case "RedHourDetail":
                PanelDates.Visible = true;
                FillddlAreaID();
                break;

            case "HourAnalysis":
                PanelClientId.Visible = true;
                PanelTypeOfService.Visible = true;
                PanelMonth.Visible = true;
                PanelVariance.Visible = true;
                PanelBranch.Visible = true;
                break;

            case "MIS":
                PanelBranch.Visible = true;
                PanelClientName.Visible = true;
                PanelMonth.Visible = true;
                PanelAsmt.Visible = true;
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                break;
            case "RotaContractedHrs":
                PanelDates.Visible = true;
                PanelClientName.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaID.Visible = true;
                PanelWorking.Visible = true;
                ddlReportType.Visible = false;
                PanelBranch.Visible = true;
                break;
            case "rostrpt_WeekHrs.rpt":
                PanelBranch.Visible = true;
                PanelMonth.Visible = true;
                PanelWeek.Visible = true;
                break;
            case "ContVsActual_Greece.rpt":
                PanelBranch.Visible = true;
                PanelClientName.Visible = true;
                PanelDates.Visible = true;
                break;

            case "ActualVsscheduleMonthly.rpt":
                PanelBranch.Visible = true;
                PanelDates.Visible = true;
                break;
            case "TotalVsOvertime.rpt":
                PanelBranch.Visible = true;
                PanelDates.Visible = true;
                break;

            case "ContractualVsScheduledVsActual.rpt":
                PanelClientName.Visible = true;
                PanelDates.Visible = true;
                break;

            case "ScheduledOTVsActualOT.rpt":
                PanelClientName.Visible = true;
                PanelDates.Visible = true;
                PanelAreaID.Visible = true;
                break;

            case "HoursGreaterThanRules.rpt":
                PanelDivision.Visible=true;
                PanelDates.Visible=true;
                PanelBranch.Visible=true;
                PanelWorking.Visible = true;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Hides all controles.
    /// </summary>
    private void HideAllControles()
    {
        PanelDates.Visible = false;
        PanelClientName.Visible = false;
        PanelClientId.Visible = false;
        PanelAsmt.Visible = false;
        PanelDivision.Visible = false;
        PanelBranch.Visible = false;
        PanelTypeOfService.Visible = false;
        PanelMonth.Visible = false;
        PanelVariance.Visible = false;
        PanelPriceOption.Visible = false;
        PanelVariance.Visible = false;
        PanelWeek.Visible = false;
        PanelWorking.Visible = false;
    }
    #endregion

    #region Function Button event
    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
        {
            string strReportPagePath = "../Reports/Rostering/";
            
            Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value.ToString());

            System.Collections.Generic.List<ReportParameter> hshRptParameters = new System.Collections.Generic.List<ReportParameter>();
            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());
            Context.Items.Remove("cxtReportName");
            Context.Items.Add("cxtReportName", ddlReportName.SelectedItem.Value.ToString());

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Hours_Kenya.aspx?ReportName=" + ddlReportName.SelectedItem.Value.ToString();
            Server.Transfer("../Reports/ViewReport.aspx");
        }
    }
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    private void FillddlAreaID()
    {
        ddlAreaID.Items.Clear();
        ddlClientCode.Items.Clear();
        ddlAsmtCode.Items.Clear();
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsArea = new DataSet();
        DataSet dsArea1 = new DataSet();
        dsArea = objSale.GetCurrentLocationAutoID(BaseCompanyCode, ddlBranch.SelectedValue, ddlDivision.SelectedValue);
        string currentCellValue = string.Empty;
        DataTable dtarea = dsArea.Tables[0];
        //Added by Manoj on 03/09/12
        
        foreach (DataRow dr in dtarea.Rows)
        {
            currentCellValue = dr["LocationAutoID"].ToString();
        }
        dsArea1 = objSale.AreaIdGetUserWise(currentCellValue, BaseUserID);
        if (dsArea1 != null && dsArea1.Tables.Count > 0 && dsArea1.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataSource = dsArea1;
            ddlAreaID.DataBind();

            ListItem li = new ListItem();
            li.Text = "All";
            li.Value = "All";
            ddlAreaID.Items.Insert(0, li);
            FillddlClient();
        }
        
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlAreaID.Items.Insert(0, li);
            ddlClientCode.Items.Insert(0, li);
            ddlAsmtCode.Items.Insert(0, li);
            
        }

    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>System.Collections.Generic.List&lt;ReportParameter&gt;.</returns>
    private List<ReportParameter> ReportParameter_Get(string strReportName)
    {
        var HshRptParameters = new Hashtable();
        var Connectionstring = BaseCountryCode;
        var ObjCon = new DL.ConnectionString();
        var Dt = ObjCon.ConnectionStringGet(Connectionstring, "1");
        var aParamList = new List<ReportParameter>();
       
        switch (strReportName)
        {
            case "ActualScheduleContractedHrs":
                 aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0,1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0,1), BaseLocationCode),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0,1), ddlClientId.SelectedItem.Value),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0,1), DL.Common.DateFormat(txtFromDate.Text.ToString(),new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0,1), DL.Common.DateFormat(txtToDate.Text.ToString(),new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.PriceOption.Remove(0,1), ddlPriceOption.SelectedItem.Value),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),Dt.Rows[0][4].ToString()),
                new ReportParameter("Password", Dt.Rows[0][5].ToString()),
                new ReportParameter(DL.Properties.Resources.Variance.Remove(0,1), ddlVariance.SelectedItem.Value),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0,1), ddlAreaID.SelectedValue),
                new ReportParameter("UserID", BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name)
                };
                
                if (ddlVariance.SelectedItem.Value == "1")
                {
                    Context.Items.Remove("cxtReportFileName");
                    Context.Items.Add("cxtReportFileName", "ActualScheduleContractedBreakUpHrs.rpt");
                };
                return aParamList;

            case "RotaContractedHrs":
                aParamList = new List<ReportParameter>
               {
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text.ToString(), new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text.ToString(), new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0, 1), ddlClientCode.SelectedItem.Value),
                new ReportParameter("AsmtId", ddlAsmtCode.SelectedItem.Value),
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), BaseLocationCode),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0, 1), ddlAreaID.SelectedItem.Value),
                new ReportParameter("ReportOption", ddlAttendType.SelectedItem.Value),
                new ReportParameter("UserID", BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),Dt.Rows[0][4].ToString()),
                new ReportParameter("Password", Dt.Rows[0][5].ToString()),
               };
                return aParamList;

            case "RedHourDetail":
                aParamList = new List<ReportParameter>
               {
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.DivisionCode.Remove(0, 1), BaseHrLocationCode),
                new ReportParameter(DL.Properties.Resources.BranchCode.Remove(0, 1), BaseLocationCode),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0, 1), "ALL"),
                new ReportParameter(DL.Properties.Resources.Variance.Remove(0, 1), "ALL"),
                new ReportParameter(DL.Properties.Resources.TypeOfService.Remove(0, 1), "ALL"),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text.ToString(), new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text.ToString(), new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0, 1), ddlAreaID.SelectedItem.Value.ToString()),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),Dt.Rows[0][4].ToString()),
                new ReportParameter("Password", Dt.Rows[0][5].ToString()),
               };
                return aParamList;

            case "HourAnalysis":
                 aParamList = new List<ReportParameter>
               {
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(HFStartDate.Value, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(HFEndDate.Value, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0, 1), ddlClientId.SelectedItem.Value.ToString()),
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.BranchCode.Remove(0, 1), BaseLocationCode),
                new ReportParameter(DL.Properties.Resources.DivisionCode.Remove(0, 1), BaseHrLocationCode),
                new ReportParameter(DL.Properties.Resources.Variance.Remove(0, 1), ddlVariance.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.TypeOfService.Remove(0, 1), ddlTypeOfService.SelectedValue.ToString()),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),Dt.Rows[0][4].ToString()),
                new ReportParameter("Password", Dt.Rows[0][5].ToString()),
               };
               if (BaseCountryName == "Egypt")
                {
                    Context.Items["cxtReportFileName"] = BaseCountryName + "_" + ddlReportName.SelectedItem.Value.ToString();
                }
                return aParamList;
                
            case "MIS":
                aParamList = new List<ReportParameter>
               {
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(HFStartDate.Value, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(HFEndDate.Value, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0, 1), ddlClientCode.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.BranchCode.Remove(0, 1), ddlBranch.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0,1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.DivisionCode.Remove(0, 1), ddlDivision.SelectedValue.ToString()),
                new ReportParameter("AsmtID", ddlAsmtCode.SelectedValue.ToString()),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),Dt.Rows[0][4].ToString()),
                new ReportParameter("Password", Dt.Rows[0][5].ToString()),
               };
                return aParamList;
            default: return aParamList;
        }
    }
    /// <summary>
    /// Validates the controles.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateControles(string strReportName)
    {
        switch (strReportName)
        {
            case "ActualScheduleContractedHrs":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ScheduleContractedHrs.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "RedHourDetail":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "RotaContractedHrs":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    ///===================================================================
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    ///=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "HourAnalysis":
                return true;

            case "MIS":
                return true;
            case "rostrpt_WeekHrs.rpt":
                return true;
            case "ContVsActual_Greece.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    ///===================================================================
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    ///=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ActualVsscheduleMonthly.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    ///===================================================================
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    ///=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "TotalVsOvertime.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    ///===================================================================
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    ///=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ContractualVsScheduledVsActual.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    ///===================================================================
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    ///=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ScheduledOTVsActualOT.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    ///===================================================================
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    ///=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "HoursGreaterThanRules.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    ///===================================================================
                    BL.Common objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    ///=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }

            default:
                return false;
        }
    }
    #endregion
}
