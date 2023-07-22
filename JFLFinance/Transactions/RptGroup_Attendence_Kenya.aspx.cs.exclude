// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_Attendence_Kenya.aspx.cs" company="Magnon">
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
/// <summary>
/// Class Transactions_RptGroup_Attendence_Kenya.
/// </summary>
public partial class Transactions_RptGroup_Attendence_Kenya : BasePage
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
        //btnViewReport.Attributes["onMouseDown"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ViewReport1.aspx';";
        //this.Form.Attributes["onMouseOver"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";

        if (!IsPostBack)
        {
            //======================================================
            /* code added by Manish to Open report in New Page*/
            //Button1.Attributes["onMouseDown"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ViewReport1.aspx';";
            // this.Form.Attributes["onMouseOver"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";
            //this.Button1.Attributes.Add("onclick","this.form.target='_blank'");

            /* code added by Manish to Open report in New Page*/
            //======================================================

            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.Rostering; }

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Rostering + "');");
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
                MakeTempTable();



                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }


                //// *******  modified by Manish on 16-mar-2010 added new common bl function SetDatesFromPayPeriod *********
                //// ******* due to getting dates according to pay period ***********************************************

                string[] strArray = new string[2];
                strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Year.ToString()));
                txtFromDate.Text = strArray[0];
                txtToDate.Text = strArray[1];
                txtYear.Text = DateTime.Now.Year.ToString();
                txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

                //txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                //txtToDate.Text = LastDateOfCurrentMonth_Get();


                txtStartDate.Text = FirstDateOfCurrentMonth_Get();

                FillddlReportName();
                FillddlDesignation();
                FillddlDivision();
                //FillddlEmployeeNumber();
                FillddlVariation();
                FillddlClient();
                FillddlAreaID();//Added by Manoj(New Parameter for All Reports) on 17/01/2012
                FillDDLCategory();
                ShowHideReportParameterControls();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
        lblErrorMsg.Text = "";
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlEmployeeNumber();
        FillddlClient();
    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Fills the DDL category.
    /// </summary>
    private void FillDDLCategory()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DDLCategory.DataSource = objMastersManagement.CategoryMasterGetAll(BaseCompanyCode);
        DDLCategory.DataTextField = "CategoryDesc";
        DDLCategory.DataValueField = "CategoryCode";
        DDLCategory.DataBind();
        ListItem li = new ListItem();
        li.Text = Resources.Resource.All;
        li.Value = "All";
        DDLCategory.Items.Insert(0, li);
    }

    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        ListItem li = new ListItem();
        //li.Text = Resources.Resource.AttendenceRegister.ToString();
        //li.Value = "AttendanceRegister.rpt";
        //ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.rptDesignationWiseTotalHours.ToString();
        li.Value = "DesignationWiseTotHrsSum";
        ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.TimeSheet.ToString();
        //li.Value = "TimeSheet";
        //ddlReportName.Items.Add(li);

        if (BaseCompanyCode == "G4EGPGRD") // only for egypt
        {
            li = new ListItem();
            li.Text = Resources.Resource.MonthlyAtten.ToString();
            li.Value = "MonthlyAttendance.rpt";
            ddlReportName.Items.Add(li);
        }

        li = new ListItem();
        li.Text = Resources.Resource.MusterRollreport.ToString();
        li.Value = "MusterRoll";
        ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.DutyAssgnTermEmp.ToString();
        //li.Value = "DutyAssignTermEmp";
        //ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.EmpWorkedWithoutSch.ToString();
        //li.Value = "EmpWorkedWithoutSch";
        //ddlReportName.Items.Add(li); 

        //li = new ListItem();
        //li.Text = Resources.Resource.rptRotaEntryStatusBasedonContractedHours.ToString();
        //li.Value = "RotaStatusAsmtwise.rpt";
        //ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.ClockRegister.ToString();
        //li.Value = "Clockregister.rpt";
        //ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.ClockSummary.ToString();
        //li.Value = "Clocksummary.rpt";
        //ddlReportName.Items.Add(li);



        //li = new ListItem();
        //li.Text = Resources.Resource.rptUnitRegister.ToString();
        //li.Value = "UnitRegisterRpt";
        //ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.rptUnitSummary.ToString();
        //li.Value = "UnitRegisterSummary";
        //ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.rptUnitRegisterSummaryAsgnBreakUp.ToString();
        //li.Value = "unitsummary_Breakup.rpt";
        //ddlReportName.Items.Add(li);

        //if (BaseCompanyCode == "GRECMSS") // only for egypt
        //{
        //    li = new ListItem();
        //    li.Text = Resources.Resource.rptManpowerDetails.ToString();
        //    li.Value = "ManpowerDetailsGreece.rpt";
        //    ddlReportName.Items.Add(li);

        //    lblSwingStartTime.Text = "Afternoon Shift Starts From";
        //}
        //else
        //{
        //    li = new ListItem();
        //    li.Text = Resources.Resource.rptManpowerDetails.ToString();
        //    li.Value = "ManpowerDetails.rpt";
        //    ddlReportName.Items.Add(li);
        //}

        //li = new ListItem();
        //li.Text = Resources.Resource.AdjustmentHours;
        //li.Value = "AdjustmentHrs";
        //ddlReportName.Items.Add(li);

        //li = new ListItem();
        //li.Text = Resources.Resource.DeploymentDetail;
        //li.Value = "DeploymentDetail.rpt";
        //ddlReportName.Items.Add(li);
    }
    /// <summary>
    /// Fillddls the variation.
    /// </summary>
    private void FillddlVariation()
    {
        ListItem li = new ListItem();
        li.Text = Resources.Resource.All;
        li.Value = "All";
        ddlVariation.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.Variation;
        li.Value = "Var";
        ddlVariation.Items.Add(li);


    }
    /// <summary>
    /// Fillddls the designation.
    /// </summary>
    private void FillddlDesignation()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlDesignation.DataSource = ds.Tables[0];
            ddlDesignation.DataTextField = "DesignationDesc";
            ddlDesignation.DataValueField = "DesignationCode";
            ddlDesignation.DataBind();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlDesignation.Items.Insert(0, li);
        }
    }
    /// <summary>
    /// Fillddls the division.
    /// </summary>
    private void FillddlDivision()
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

            ddlDivision.SelectedValue = BaseHrLocationCode.ToString();

            FillddlBranch();
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
            while (dtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleStartDay.Trim().ToLower())
            {
                dtSelectedMonthFirstDay = dtSelectedMonthFirstDay.AddDays(1);
            }
            //if (dtCurrentMonthLastDay.DayOfWeek != DayOfWeek.Saturday)
            if (dtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleEndDay.Trim().ToLower())
            {
                //while (dtNextMonthFirstDay.DayOfWeek != DayOfWeek.Saturday)
                while (dtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != BaseScheduleEndDay.Trim().ToLower())
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
                //if (nextDate.DayOfWeek == DayOfWeek.Sunday)
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
    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch()
    {
        var dsBranch = new DataSet();
        //Modify by  on 5-Nov-2014 (Bug #2145)
        //BL.UserManagement objblUserManagement = new BL.UserManagement();
        //dsBranch = objblUserManagement.GetLoggedInLocation(BaseLocationAutoID);
        var objKpi = new BL.KPI();
        dsBranch = objKpi.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedItem.Value);
        //End
        if (dsBranch.Tables[0].Rows.Count > 0 && dsBranch.Tables.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
        }
        else
        {
            ddlBranch.Items.Clear();
            var li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "-1";
            ddlBranch.Items.Insert(0, li);
        }
    }
    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    private void FillddlEmployeeNumber()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objHRManagement.EmployeesOfLocationAreaWiseGet(BaseCompanyCode, BaseHrLocationCode, ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text, ddlAreaID.SelectedValue.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlEmployeeNumber.DataSource = ds.Tables[0];
            ddlEmployeeNumber.DataTextField = "EmployeeName";
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataBind();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlEmployeeNumber.Items.Insert(0, li);
        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlEmployeeNumber.Items.Insert(0, li1);

        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.ClientAreaInchargeWiseGet(BaseLocationAutoID, ddlAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, BaseLocationCode, txtFromDate.Text, txtToDate.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            ddlClientCode.DataSource = ds;
            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            ListItem li1 = new ListItem();
            li1.Text = "All";
            li1.Value = "All";
            ddlClientCode.Items.Insert(0, li1);

            if (ddlClientCode.SelectedItem.Value.ToString() != null)
            {
                FillddlAsmt(ddlClientCode.SelectedItem.Value.ToString());
            }

        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlClientCode.Items.Insert(0, li1);
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    /// <param name="strClientCode">The string client code.</param>
    private void FillddlAsmt(string strClientCode)
    {
        ddlAsmtCode.Items.Clear();
        if (ddlClientCode.SelectedValue == "-1")
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlAsmtCode.Items.Insert(0, li1);
        }

        if (ddlClientCode.SelectedValue == "All")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "All";
            ddlAsmtCode.Items.Insert(0, li);
        }
        else
        {
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();
            DataSet ds = new DataSet();
            ds = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
            ddlAsmtCode.DataSource = ds.Tables[0];
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "All";
            ddlAsmtCode.Items.Insert(0, li);
        }
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
        ShowHideReportParameterControls();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlBranch();
    }

    /// <summary>
    /// Handles the Click event of the RefreshEmpList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void RefreshEmpList_Click(object sender, EventArgs e)
    {
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlMonth control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["MonthChangeStatus"] = 0;
        GetWeekStartDay();
        GetStartEndDate();
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

        ViewState["MonthChangeStatus"] = 0;
        if (txtYear.Text == "")
        {
            txtYear.Text = DateTime.Now.Year.ToString();

        }
        GetWeekStartDay();
        GetStartEndDate();


    }
    //protected void txtFromDate_TextChanged(object sender, EventArgs e)
    //{
    //    DateFormat(txtFromDate.Text.ToString());
    //    txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text.ToString());
    //}
    //protected void txtToDate_TextChanged(object sender, EventArgs e)
    //{
    //    DateFormat(txtToDate.Text.ToString());
    //}
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt(ddlClientCode.SelectedItem.Value.ToString());
    }
    /// <summary>
    /// Shows the hide report parameter controls.
    /// </summary>
    private void ShowHideReportParameterControls()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        HideAllControls();
        switch (strReportName)
        {
            case "AttendanceRegister.rpt":
                PanelDates.Visible = true;
                PanelEmployee.Visible = true;
                break;
            case "DesignationWiseTotHrsSum":
                PanelLocation.Visible = false;
                PanelDesignation.Visible = true;
                PanelDates.Visible = true;
                PanelddlReportType.Visible = false;
                PanelLocation.Visible = true;
                break;
            case "TimeSheet":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                if (ddlEmployeeNumber.SelectedValue == "-1")
                {
                    btnViewReport.Enabled = false;
                }
                else
                {
                    btnViewReport.Enabled = true;
                }
                break;
            case "MusterRoll":
                PanelDates.Visible = true;
                //PanelEmployee.Visible = true;
                //PanelCheckBox.Visible = true;
                PanelLocation.Visible = true;
                //PanelDesignation.Visible = true;
                PnlCategory.Visible = true;
                break;
            case "RotaStatusAsmtwise.rpt":
                PanelDates.Visible = true;
                PanelVariation.Visible = true;
                PanelLocation.Visible = true;
                break;
            case "Clockregister.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                break;
            case "Clocksummary.rpt":
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                break;

            case "UnitRegisterRpt":
                PanelDates.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                PanelLocation.Visible = true;
                PanelRadioButtonForUnitregister.Visible = true;
                if (ddlClientCode.SelectedValue == "-1")
                {
                    btnViewReport.Enabled = false;
                }
                else
                {
                    btnViewReport.Enabled = true;
                }

                break;
            case "UnitRegisterSummary":
                PanelDates.Visible = true;
                PanelClientCode.Visible = true;
                PanelVariation.Visible = true;
                PanelLocation.Visible = true;
                if (ddlClientCode.SelectedValue == "-1")
                {
                    btnViewReport.Enabled = false;
                }
                else
                {
                    btnViewReport.Enabled = true;
                }
                //PanelddlReportType1.Visible = true;
                if (BaseCompanyCode == "AMSSKW")
                {
                    PanelInvoiceType.Visible = true;
                }
                break;



            case "unitsummary_Breakup.rpt":
                PanelDates.Visible = true;
                PanelClientCode.Visible = true;
                PanelVariation.Visible = true;
                PanelLocation.Visible = true;
                // PanelddlReportType1.Visible = true;
                break;

            case "MonthlyAttendance.rpt":
                PanelDates.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                break;
            case "ManpowerDetails.rpt":
                // PanelLocation.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                PanelShift.Visible = true;
                PanelLocation.Visible = true;
                break;

            case "ManpowerDetailsGreece.rpt":
                // PanelLocation.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                PanelShift.Visible = true;
                PanelLocation.Visible = true;
                break;

            case "AdjustmentHrs":
                PanelLocation.Visible = true;
                PanelDates.Visible = true;
                break;
            case "DeploymentDetail.rpt":
                PanelDates.Visible = true;
                PanelEmployee.Visible = true;

                break;
            case "DutyAssignTermEmp":
                PanelDates.Visible = true;
                PnlReportOption.Visible = true;
                break;
            case "EmpWorkedWithoutSch":
                PanelDates.Visible = true;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Hides all controls.
    /// </summary>
    private void HideAllControls()
    {
        PnlCategory.Visible = false;
        PanelLocation.Visible = false;
        PanelDesignation.Visible = false;
        PanelDates.Visible = false;
        PanelddlReportType.Visible = false;
        PanelEmployee.Visible = false;
        PanelCheckBox.Visible = false;
        PanelVariation.Visible = false;
        PanelAsmtCode.Visible = false;
        PanelClientCode.Visible = false;
        PanelInvoiceType.Visible = false;
        PanelShift.Visible = false;
        PanelddlReportType1.Visible = false;
        PanelMonth.Visible = false;
        PanelWeek.Visible = false;
        PanelRadioButtonForUnitregister.Visible = false;
        PnlReportOption.Visible = false;
        PanelAreaID.Visible = false;
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

            System.Collections.Generic.List<ReportParameter> hshRptParameters = new System.Collections.Generic.List<ReportParameter>();
            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());

            Context.Items.Remove("cxtReportName");
            Context.Items.Add("cxtReportName", ddlReportName.SelectedItem.Value.ToString());

            //Comment Date: (15/01/2012)
            //Comment By	: (Manoj Kumar)
            //Changes done: (A New Report Added for New Column(Post) and Two New Radio Buton added for Selection only)               
            if (ddlReportName.SelectedItem.Value == "UnitRegisterRpt" && rdoAssigmentWise.Checked)
            {
                Context.Items.Remove("cxtReportName");
                Context.Items.Add("cxtReportName", ddlReportName.SelectedItem.Value.ToString());
            }
            else if (ddlReportName.SelectedItem.Value == "UnitRegisterRpt" && rdoPostWise.Checked)
            {
                Context.Items.Remove("cxtReportName");
                Context.Items.Add("cxtReportName", "UnitRegisterPostWiseRpt");
                hshRptParameters = ReportParameter_Get("UnitRegisterPostWiseRpt");
            }
            //End Added by Manoj Kumar


            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Attendence_Kenya.aspx?ReportName=" + ddlReportName.SelectedItem.Value.ToString();


            Server.Transfer("~/Reports/ViewReport.aspx");
        }
    }
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    private void FillddlAreaID()
    {
        ddlAreaID.Items.Clear();
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsArea = new DataSet();
        //Added by Manoj on 03/09/12
        dsArea = objSale.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID);
        ddlAreaID.DataTextField = "AreaDesc";
        ddlAreaID.DataValueField = "AreaID";
        ddlAreaID.DataSource = dsArea;
        ddlAreaID.DataBind();

        ListItem li = new ListItem();
        li.Text = "All";
        li.Value = "All";
        ddlAreaID.Items.Insert(0, li);

        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>System.Collections.Generic.List&lt;ReportParameter&gt;.</returns>
    private List<ReportParameter> ReportParameter_Get(string strReportName)
    {
        var connectionstring = BaseCountryCode;

        var objCon = new DL.ConnectionString();
        DataTable dt = objCon.ConnectionStringGet(connectionstring, "1");
        var aParamList=new List<ReportParameter>();
        switch (strReportName)
        {
            case "DesignationWiseTotHrsSum":
                aParamList = new List<ReportParameter>
                {
                    new ReportParameter(DL.Properties.Resources.Company.ToLower().Remove(0, 1), BaseCompanyCode),
                    new ReportParameter(DL.Properties.Resources.Division.ToLower().Remove(0, 1), ddlDivision.SelectedItem.Value.ToString()),
                    new ReportParameter(DL.Properties.Resources.Branch.ToLower().Remove(0, 1), ddlBranch.SelectedValue.ToString()),
                    new ReportParameter(DL.Properties.Resources.Designation.ToLower().Remove(0, 1), ddlDesignation.SelectedItem.Value.ToString()),
                    new ReportParameter(DL.Properties.Resources.FromDate.ToLower().Remove(0,1), DL.Common.DateFormat(txtFromDate.Text,new CultureInfo("en-US"))),
                    new ReportParameter(DL.Properties.Resources.ToDate.ToLower().Remove(0,1), DL.Common.DateFormat(txtToDate.Text,new CultureInfo("en-US"))),
                    new ReportParameter(DL.Properties.Resources.Option.ToLower().Remove(0,1), ddlReportStatus.SelectedItem.Value.ToString()),
                    new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                    new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                    new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                    new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                    new ReportParameter("Password", dt.Rows[0][5].ToString())
                };
                
                Context.Items["cxtReportFileName"] = "DesignationWiseTotHrsSum";
                return aParamList;
                
            case "TimeSheet":
                if (ddlEmployeeNumber.SelectedItem.Value == null)
                {
                    ddlEmployeeNumber.SelectedItem.Text = "All";
                    ddlEmployeeNumber.SelectedValue = "All";
                }
                 aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.EmployeeNumber.Remove(0, 1), ddlEmployeeNumber.SelectedItem.Value.ToString()),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("Todate", DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), ddlBranch.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0, 1), ddlDivision.SelectedItem.Value.ToString()),
                new ReportParameter("optionParam", "1".ToString()),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0, 1), ddlAreaID.SelectedItem.Value.ToString()),
                new ReportParameter("UserID", BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                new ReportParameter("Password", dt.Rows[0][5].ToString())
                };
                return aParamList;

            case "MusterRoll":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), ddlBranch.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.CategoryCode.Remove(0, 1), DDLCategory.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                new ReportParameter("Password", dt.Rows[0][5].ToString())
                };
                return aParamList;

            case "UnitRegisterRpt":
                 aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1).ToUpper(), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1).ToUpper(), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0, 1).ToUpper(), ddlClientCode.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.AsmtCode.Remove(0, 1).ToUpper(), ddlAsmtCode.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0, 1).ToUpper(), ddlDivision.SelectedItem.Value.ToString()),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1).ToUpper(), ddlBranch.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0, 1).ToUpper(), ddlAreaID.SelectedValue),
                new ReportParameter("ReportOption".ToUpper(), "1"),
                new ReportParameter(DL.Properties.Resources.UserId.Remove(0, 1).ToUpper(), BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),    
                new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                new ReportParameter("Password", dt.Rows[0][5].ToString())
            
                };
                return aParamList;
           
            case "UnitRegisterPostWiseRpt":
                aParamList= new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0, 1), ddlClientCode.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.AsmtCode.Remove(0, 1), ddlAsmtCode.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0, 1), ddlDivision.SelectedItem.Value.ToString()),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), ddlBranch.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0, 1), ddlAreaID.SelectedValue),
                new ReportParameter("ReportOption", "0"),
                new ReportParameter(DL.Properties.Resources.UserId.Remove(0, 1), BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                new ReportParameter("Password", dt.Rows[0][5].ToString())
                };   
                return aParamList;

            case "UnitRegisterSummary":
                aParamList= new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.Variation.Remove(0, 1).ToUpper(), ddlVariation.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1).ToUpper(), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1).ToUpper(), ddlBranch.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0, 1).ToUpper(), ddlClientCode.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0, 1).ToUpper(), ddlDivision.SelectedItem.Value.ToString()),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0, 1).ToUpper(), ddlAreaID.SelectedValue),
                new ReportParameter(DL.Properties.Resources.UserId.Remove(0, 1).ToUpper(), BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                new ReportParameter("Password", dt.Rows[0][5].ToString())
                };   
                if (BaseCompanyCode == "AMSSKW")
                {
                    aParamList.Add(new ReportParameter(DL.Properties.Resources.InvType, ddlInvoiceType.SelectedValue.ToString()));
                    Context.Items.Remove("cxtReportFileName");
                    Context.Items.Add("cxtReportFileName", "UnitSummary_KWT.rpt");
                }

                if (ddlReportStatus1.SelectedValue.ToString() == "Summary")
                {
                    Context.Items["cxtReportFileName"] = "unitsummaryClient.rpt";
                }
                else
                {
                    Context.Items["cxtReportFileName"] = "UnitRegisterSummary";
                }

                return aParamList;

            case "AdjustmentHrs":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.Company.Remove(0, 1).ToUpper(), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.HrLocation.Remove(0, 1).ToUpper(), ddlDivision.SelectedItem.Value.ToString()),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1).ToUpper(), ddlBranch.SelectedValue.ToString()),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1).ToUpper(), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1).ToUpper(), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.AdjCode.Remove(0, 1).ToUpper(), "all"),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0, 1).ToUpper(), ddlAreaID.SelectedValue),
                new ReportParameter(DL.Properties.Resources.UserId.Remove(0, 1).ToUpper(), BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                new ReportParameter("Password", dt.Rows[0][5].ToString())
                };
                return aParamList;
           
            case "DutyAssignTermEmp":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter("LocationAutoID", BaseLocationAutoID),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("Option", ddlReportOption.SelectedValue.ToString()),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                new ReportParameter("Password", dt.Rows[0][5].ToString())
                };
                return aParamList;

            case "EmpWorkedWithoutSch":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0, 1), BaseHrLocationCode),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), DL.Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), DL.Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),dt.Rows[0][4].ToString()),
                new ReportParameter("Password", dt.Rows[0][5].ToString())
                };
                return aParamList;
            default: return aParamList;
        }
    }
    /// <summary>
    /// Validates the shift.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool validateShift()
    {

        BL.Common objCommon = new BL.Common();
        if (objCommon.IsValidDate("01-01-1900 " + txtDayStartTime.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtDayStartTime.Focus();
            return false;
        }
        if (objCommon.IsValidDate("01-01-1900 " + txtDayEndTime.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtDayEndTime.Focus();
            return false;
        }
        if (objCommon.IsValidDate("01-01-1900 " + txtNightStartTime.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtNightStartTime.Focus();
            return false;
        }
        if (objCommon.IsValidDate("01-01-1900 " + txtNightEndTime.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtNightEndTime.Focus();
            return false;
        }
        if (objCommon.IsValidDate("01-01-1900 " + txtSwingStartTime.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtSwingStartTime.Focus();
            return false;
        }
        if (objCommon.IsValidDate("01-01-1900 " + txtSwingEndTime.Text) != true)
        {
            lblErrorMsg.Text = Resources.Resource.InvalidDate;
            txtSwingEndTime.Focus();
            return false;
        }
        return true;
    }
    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool validateFromToDate()
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

        if (txtToDate.Text != "" && txtFromDate.Text != "")
        {
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
    }
    /// <summary>
    /// Validates the controles.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateControles(string strReportName)
    {
        if (ddlBranch.SelectedValue.ToString() == "")
        {
            lblErrorMsg.Text = Resources.Resource.Location + " " + Resources.Resource.CannotBeLeftBlank;
            return false;
        }
        switch (strReportName)
        {
            case "AttendanceRegister.rpt":
                return validateFromToDate();
            case "DesignationWiseTotHrsSum":
                return validateFromToDate();
            case "TimeSheet":
                return validateFromToDate();
            case "MusterRoll":
                return validateFromToDate();
            case "RotaStatusAsmtwise.rpt":
                return validateFromToDate();
            case "Clockregister.rpt":
                return validateFromToDate();
            case "Clocksummary.rpt":
                return validateFromToDate();
            case "UnitRegisterRpt":
                return validateFromToDate();
            case "UnitRegisterSummary":
                return validateFromToDate();
            case "unitsummary_Breakup.rpt":
                return validateFromToDate();
            case "MonthlyAttendance.rpt":
                return validateFromToDate();
            case "ManpowerDetails.rpt":
                return validateShift();
            case "ManpowerDetailsGreece.rpt":
                return validateShift();
            case "AdjustmentHrs":
                return validateFromToDate();
            case "DeploymentDetail.rpt":
                return validateFromToDate();
            case "DutyAssignTermEmp":
                return true;
            case "EmpWorkedWithoutSch":
                return true;
            default:
                return false;
        }
    }
    #endregion
}
