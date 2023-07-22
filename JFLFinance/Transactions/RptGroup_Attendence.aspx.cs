// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_Attendence.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_RptGroup_Attendence.
/// </summary>
public partial class Transactions_RptGroup_Attendence : BasePage
{
    #region Member Declaration
    private const string DeploymentDetailReport = "DeploymentDetailReport";
    private const string DeploymentDetailEmployeeWise = "DeploymentDetailEmployeeWise.rpt";
    private const string DeploymentDetailCustomerWise = "DeploymentDetailCustomerWise.rpt";
    #endregion

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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
            //Page Title from resource file
            var javaScript = new System.Text.StringBuilder();
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
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                MakeTempTable();

                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }


                //// *******  modified by Manish on 16-mar-2010 added new common bl function SetDatesFromPayPeriod *********
                //// ******* due to getting dates according to pay period ***********************************************

                var strArray = new string[2];
                strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString()), int.Parse(DateTime.Now.Year.ToString()));
                txtFromDate.Text = strArray[0];
                txtToDate.Text = strArray[1];
                txtYear.Text = DateTime.Now.Year.ToString();
                txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

               
                txtStartDate.Text = FirstDateOfCurrentMonth_Get();

                FillddlReportName();
                FillddlDesignation();
                FillddlDivision();
                FillddlVariation();
                FillddlClient();
                FillddlAreaId();//Added by Manoj(New Parameter for All Reports) on 17/01/2012
                FillddlEmployeePaidOnlyAll();
                ShowHideReportParameterControls();
                FillSoType();

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
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        var li = new ListItem();
        

        li = new ListItem {Text = Resources.Resource.TimeSheet, Value = @"TimeSheetWithAdjNAllowance.rpt"};
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resources.Resource.rptTimeSheet, Value = @"TimeSheet.rpt" };
        ddlReportName.Items.Add(li);

        if (BaseCompanyCode == "G4EGPGRD") // only for egypt
        {
            li = new ListItem();
            li.Text = Resources.Resource.MonthlyAtten;
            li.Value = @"MonthlyAttendance.rpt";
            ddlReportName.Items.Add(li);
        }

        li = new ListItem();
        li.Text = Resources.Resource.rptUnitRegister;
        li.Value = "UnitRegister.rpt";
        ddlReportName.Items.Add(li);

        li = new ListItem();
        li.Text = Resources.Resource.rptUnitSummary;
        li.Value = "UnitSummary.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.AdjustmentHours;
        li.Value = "AdjustmentHrsRpt.rpt";
        ddlReportName.Items.Add(li);

       // if (BaseCompanyCode == "G4FLKGRD") // only for India
        {

            li = new ListItem();
            li.Text = Resources.Resource.ClockRegister;
            li.Value = "ClockregisterNew.rpt";
            ddlReportName.Items.Add(li);
        }

        #region SAT#1191 TFS #2626 UAE - Deployment Detail Report
        //if (BaseCompanyCode != "UAE") return;
        li = new ListItem { Text = Resources.Resource.DeploymentDetail, Value = DeploymentDetailReport };
        ddlReportName.Items.Add(li);
        #endregion
    }
    /// <summary>
    /// Fillddls the variation.
    /// </summary>
    private void FillddlVariation()
    {
        var li = new ListItem();
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
        var objMastersManagement = new BL.MastersManagement();
        var ds = new DataSet();
        ds = objMastersManagement.DesignationMasterGetAll(BaseCompanyCode);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlDesignation.DataSource = ds.Tables[0];
            ddlDesignation.DataTextField = "DesignationDesc";
            ddlDesignation.DataValueField = "DesignationCode";
            ddlDesignation.DataBind();
            var li = new ListItem();
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
        var dsDivision = new DataSet();
        var objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = dsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();

            ddlDivision.SelectedValue = BaseHrLocationCode;

            FillddlBranch();
        }
    }
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
    /// Gets the week start day.
    /// </summary>
    private void GetWeekStartDay()
    {
        if (int.Parse(ViewState["MonthChangeStatus"].ToString()) == 0)
        {
            var dtDates = new DataTable();
            dtDates = (DataTable)ViewState["Dates"];
            dtDates.Clear();
            // dtDates.Clear();
            ddlWeek.Items.Clear();
            var dtSelectedMonthFirstDay = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), 1);
            int NextMonth;
            var strYear = txtYear.Text;
            if (int.Parse(ddlMonth.SelectedValue) == 12)
            {
                strYear = Convert.ToString(int.Parse(txtYear.Text) + 1);
                NextMonth = 1;
            }
            else
            {
                NextMonth = int.Parse(ddlMonth.SelectedValue) + 1;
            }

            var dtNextMonthFirstDay = new DateTime(int.Parse(strYear), int.Parse(NextMonth.ToString()), 1);
            var dtCurrentMonthLastDay = new DateTime(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue), 1).AddMonths(1).AddDays(-1);
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
            var dtSelectedMonthFirstDate = dtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
            var dtNextMonthFirstDate = dtNextMonthFirstDay.ToString("dd-MMM-yyyy");
            var Count = 1;
            var RowIndex = 1;


            DateTime nextDate;
            nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
            while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
            {
                var dr = dtDates.NewRow();
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
            var Status = 1;
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
        var dtDates = (DataTable)ViewState["Dates"];
        var dv = new DataView(dtDates);
        dv.RowFilter = "[WeekNo]='" + (ddlWeek.SelectedValue) + "'";
        var dtStartEndDate = new DataTable();
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
        var objblUserManagement = new BL.UserManagement();

        dsBranch = objblUserManagement.GetLoggedInLocation(BaseLocationAutoID);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = dsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
        }
    }
    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    private void FillddlEmployeeNumber()
    {
        var objHRManagement = new BL.HRManagement();
        var ds = new DataSet();
        ds = objHRManagement.EmployeesOfLocationAreaWiseGet(BaseCompanyCode, BaseHrLocationCode, ddlBranch.SelectedValue, txtFromDate.Text, txtToDate.Text, ddlAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlEmployeeNumber.DataSource = ds.Tables[0];
            ddlEmployeeNumber.DataTextField = "EmployeeName";
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataBind();
            var li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlEmployeeNumber.Items.Insert(0, li);
        }
    }

    /// <summary>
    /// Fillddls the employee options Paid only and all.
    /// </summary>
    private void FillddlEmployeePaidOnlyAll()
    {
        var li = new ListItem {Text = Resources.Resource.All, Value = "ALL"};
        ddlEmployeePaidOnlyAll.Items.Add(li);

        li = new ListItem { Text = Resources.Resource.PaidOnly, Value = "PaidOnly" };
        ddlEmployeePaidOnlyAll.Items.Insert(0,li);
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        var objSales = new BL.Sales();
        var ds = new DataSet();
        ds = objSales.ClientAreaInchargeWiseGet(BaseLocationAutoID, ddlAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, BaseLocationCode, txtFromDate.Text, txtToDate.Text);

        ddlClientCode.DataSource = ds;
        ddlClientCode.DataTextField = "ClientNameCode";
        ddlClientCode.DataValueField = "ClientCode";
        ddlClientCode.DataBind();
        var li1 = new ListItem();
        li1.Text = "All";
        li1.Value = "All";
        ddlClientCode.Items.Insert(0, li1);

        if (ddlClientCode.SelectedItem.Value != null)
        {
            FillddlAsmt(ddlClientCode.SelectedItem.Value);
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    /// <param name="strClientCode">The string client code.</param>
    private void FillddlAsmt(string strClientCode)
    {
        ddlAsmtCode.Items.Clear();
        if (ddlClientCode.SelectedValue == "All")
        {
            var li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "All";
            ddlAsmtCode.Items.Insert(0, li);
        }
        else
        {
            var objOperationManagement = new BL.OperationManagement();
            var ds = new DataSet();
            ds = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
            ddlAsmtCode.DataSource = ds.Tables[0];
            ddlAsmtCode.DataTextField = "AsmtDetail";
            ddlAsmtCode.DataValueField = "AsmtCode";
            ddlAsmtCode.DataBind();
            var li = new ListItem();
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
        switch (ddlReportName.SelectedValue)
        {
            case "ClockregisterNew.rpt":
                FillddlBranch1();
                FillddlEmployeeNumber1();
                break;
        }
    }

    /// <summary>
    /// Handles the Click event of the RefreshEmpList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void RefreshEmpList_Click(object sender, EventArgs e)
    {
        FillddlEmployeeNumber();
        switch (ddlReportName.SelectedValue)
        {
            case "ClockregisterNew.rpt":
                FillddlEmployeeNumber1();
                break;
        }
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
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt(ddlClientCode.SelectedItem.Value);
    }
    /// <summary>
    /// Shows the hide report parameter controls.
    /// </summary>
    private void ShowHideReportParameterControls()
    {
        var strReportName = ddlReportName.SelectedItem.Value;
        HideAllControls();
        switch (strReportName)
        {
            case "AttendanceRegister.rpt":
                PanelDates.Visible = true;
                PanelEmployee.Visible = true;
                break;
            case "DesgtothrsSummary.rpt":
                PanelLocation.Visible = false;
                PanelDesignation.Visible = true;
                PanelDates.Visible = true;
                PanelddlReportType.Visible = true;
                PanelLocation.Visible = true;
                break;
            case "TimeSheetWithAdjNAllowance.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                PanelEmployeePaidOnlyAll.Visible = true;
                ddlBranch.Visible = true;
                break;
            case "TimeSheet.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                PanelEmployeePaidOnlyAll.Visible = false;
                ddlBranch.Visible = true;
                break;
            case "EmployeeAbsense.rpt":
                PanelDates.Visible = true;
                PanelEmployee.Visible = true;
                PanelCheckBox.Visible = true;
                PanelLocation.Visible = true;
                PanelDesignation.Visible = true;
                break;
            case "RotaStatusAsmtwise.rpt":
                PanelDates.Visible = true;
                PanelVariation.Visible = true;
                PanelLocation.Visible = true;
                break;
            case "ClockregisterNew.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                PanelAreaID.Visible = false;
                msddlBranch.Visible = true;
                ddlBranch.Visible = false;
                FillddlBranch1();
                FillddlEmployeeNumber1();
                break;

            case "Clocksummary.rpt":
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                break;

            case "UnitRegister.rpt":
                PanelDates.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                PanelLocation.Visible = true;
                PanelRadioButtonForUnitregister.Visible = true;
                if (rdoPostWise.Checked)
                {
                    pnlSoType.Visible = true;
                }
                ddlBranch.Visible = true;
                break;
            case "UnitSummary.rpt":
                PanelDates.Visible = true;
                PanelClientCode.Visible = true;
                PanelVariation.Visible = true;
                PanelLocation.Visible = true;
                //PanelddlReportType1.Visible = true;
                if (BaseCompanyCode == "AMSSKW")
                {
                    PanelInvoiceType.Visible = true;
                }
                ddlBranch.Visible = true;
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

            case "AdjustmentHrsRpt.rpt":
                PanelLocation.Visible = true;
                PanelDates.Visible = true;
                ddlBranch.Visible = true;
                break;
            case "DeploymentDetail.rpt":
                PanelDates.Visible = true;
                PanelEmployee.Visible = true;
                break;

            // SAT#1191 TFS #2626 UAE - Deployment Detail Report
            case DeploymentDetailReport:
                PanelLocation.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmtCode.Visible = true;
                pnlDeploymentDetailType.Visible = true;
                PanelDates.Visible = true;
                PanelAreaID.Visible = false;
                ddlBranch.Visible = true;
                msddlBranch.Visible = false;
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
        PanelLocation.Visible = false;
        PanelDesignation.Visible = false;
        PanelDates.Visible = false;
        PanelddlReportType.Visible = false;
        PanelEmployee.Visible = false;
        PanelEmployeePaidOnlyAll.Visible = false;
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

        msddlBranch.Visible = false;
        pnlSoType.Visible = false;

        pnlDeploymentDetailType.Visible = false;            // Added for SAT1191 - UAE Deployment Detail Report
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
        
        if (ValidateControles(ddlReportName.SelectedItem.Value))
        {
            
            var strReportPagePath = "../Reports/Rostering/";

            var hshRptParameters = new Hashtable();            
            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value);
            Context.Items.Remove("cxtReportFileName");
            Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value);

            if (ddlReportName.SelectedItem.Value == "UnitRegister.rpt" && rdoAssigmentWise.Checked)
            {
                Context.Items.Remove("cxtReportFileName");
                Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value);
            }
            else if (ddlReportName.SelectedItem.Value == @"UnitRegister.rpt" && rdoPostWise.Checked)
            {
                Context.Items.Remove("cxtReportFileName");
                Context.Items.Add("cxtReportFileName", "UnitRegisterPostWise.rpt");
                hshRptParameters = ReportParameter_Get("UnitRegisterPostWise.rpt");
            }
            
            // SAT#1191 TFS #2626 UAE - Deployment Detail Report
            if (ddlReportName.SelectedItem.Value == DeploymentDetailReport && rdbEmployeeWise.Checked)
            {
                Context.Items.Remove("cxtReportFileName");
                Context.Items.Add("cxtReportFileName", DeploymentDetailEmployeeWise);
                hshRptParameters = ReportParameter_Get(DeploymentDetailEmployeeWise);
            }
            else if (ddlReportName.SelectedItem.Value == DeploymentDetailReport && rdbCustomerWise.Checked)
            {
                Context.Items.Remove("cxtReportFileName");
                Context.Items.Add("cxtReportFileName", DeploymentDetailCustomerWise);
                hshRptParameters = ReportParameter_Get(DeploymentDetailCustomerWise);
            }
            //ENd SAT#1191

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Attendence.aspx?ReportName=" + ddlReportName.SelectedItem.Value;


            Server.Transfer("../Reports/ViewReport1.aspx");
        }

        
    }
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    private void FillddlAreaId()
    {   
        ddlAreaID.Items.Clear();
        var objSale = new BL.OperationManagement();
        //Added by Manoj on 03/09/12
        using (var dsArea = objSale.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID))
        {
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataSource = dsArea;
        }
        ddlAreaID.DataBind();
        var li = new ListItem {Text = @"All", Value = @"All"};
        ddlAreaID.Items.Insert(0, li);
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        var hshRptParameters = new Hashtable();
        switch (strReportName)
        {
            case "AttendanceRegister.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value);
                return hshRptParameters;
            case "DesgtothrsSummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Designationcode, ddlDesignation.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Option, ddlReportStatus.SelectedItem.Value);

                if (ddlReportStatus.SelectedValue == "Summary")
                {
                    Context.Items["cxtReportFileName"] = "DesgtothrsSummary.rpt";
                }
                else
                {
                    Context.Items["cxtReportFileName"] = "Desgtothrsdetail.rpt";
                }
                return hshRptParameters;
            case "TimeSheetWithAdjNAllowance.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.OptionParam, ddlEmployeePaidOnlyAll.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                return hshRptParameters;
            case "TimeSheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.OptionParam, "");
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                return hshRptParameters;
            case "EmployeeAbsense.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.PresentOption, bool.Parse(chkPresent.Checked.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.AbsentOption, bool.Parse(chkAbsent.Checked.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.LeaveOption, bool.Parse(chkLeave.Checked.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.WeekOffOption, bool.Parse(chkWeekOff.Checked.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.Emp, ddlEmployeeNumber.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Designationcode, ddlDesignation.SelectedItem.Value);

                return hshRptParameters;
            case "RotaStatusAsmtwise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Variation, ddlVariation.SelectedValue);
                return hshRptParameters;
            case "ClockregisterNew.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
            case "Clocksummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                return hshRptParameters;

            case "UnitRegister.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                hshRptParameters.Add("@ReportOption", 1);//Assignment Wise
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                hshRptParameters.Add(DL.Properties.Resources.SOType, "All");

                return hshRptParameters;
            //Added by Manoj(Unit Register Report(Assignment Wise/Post Wise))27/02/2012
            case "UnitRegisterPostWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                hshRptParameters.Add("@ReportOption", 0);//Post Wise         
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                hshRptParameters.Add(DL.Properties.Resources.SOType, ddlSoType.SelectedValue);

                return hshRptParameters;
            //End Added by Manoj(Unit Register Report(Assignment Wise/Post Wise))27/02/2012

            case "UnitSummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Variation, ddlVariation.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                if (BaseCompanyCode == "AMSSKW")
                {
                    hshRptParameters.Add(DL.Properties.Resources.InvType, ddlInvoiceType.SelectedValue);
                    Context.Items.Remove("cxtReportFileName");
                    Context.Items.Add("cxtReportFileName", "UnitSummary_KWT.rpt");
                }

                if (ddlReportStatus1.SelectedValue == "Summary")
                {
                    Context.Items["cxtReportFileName"] = "unitsummaryClient.rpt";
                }
                else
                {
                    Context.Items["cxtReportFileName"] = "UnitSummary.rpt";
                }

                return hshRptParameters;

            case "unitsummary_Breakup.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Variation, ddlVariation.SelectedValue);
                return hshRptParameters;

            case "MonthlyAttendance.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue);
                return hshRptParameters;

            case "ManpowerDetails.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtStartDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.DayStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.DayEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayEndTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.NightStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.NightEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightEndTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.SwingStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtSwingStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.SwingEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtSwingEndTime.Text)));
                return hshRptParameters;
            case "ManpowerDetailsGreece.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtStartDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.DayStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.DayEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayEndTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.NightStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.NightEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightEndTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.SwingStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtSwingStartTime.Text)));
                hshRptParameters.Add(DL.Properties.Resources.SwingEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtSwingEndTime.Text)));
                return hshRptParameters;

            case "AdjustmentHrsRpt.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocation, ddlDivision.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AdjCode, "all");
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                return hshRptParameters;
            case "DeploymentDetail.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value);
                return hshRptParameters;

            // SAT#1191 TFS #2626 UAE - Deployment Detail Report
            case DeploymentDetailEmployeeWise:
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, ddlAsmtCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ReportType, "Employee Wise");
                return hshRptParameters;
            case DeploymentDetailCustomerWise:
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, ddlAsmtCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ReportType, "Customer Wise");
                return hshRptParameters;
            //ENd SAT#1191
            default: return hshRptParameters;
        }
    }

    /// <summary>
    /// Validates the shift.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool ValidateShift()
    {

        var objCommon = new BL.Common();
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
    private bool ValidateFromToDate()
    {
        lblErrorMsg.Text = string.Empty;
        var objCommon = new BL.Common();
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
        if (ddlBranch.SelectedValue == "")
        {
            lblErrorMsg.Text = Resources.Resource.Location + " " + Resources.Resource.CannotBeLeftBlank;
            return false;
        }


        switch (strReportName)
        {
            case "AttendanceRegister.rpt":
                return ValidateFromToDate();
            case "DesgtothrsSummary.rpt":
                return ValidateFromToDate();
            case "TimeSheetWithAdjNAllowance.rpt":
                return ValidateFromToDate();
            case "TimeSheet.rpt":
                return ValidateFromToDate();
            case "EmployeeAbsense.rpt":
                return ValidateFromToDate();
            case "RotaStatusAsmtwise.rpt":
                return ValidateFromToDate();
            case "ClockregisterNew.rpt":
                return ValidateFromToDate();
            case "Clocksummary.rpt":
                return ValidateFromToDate();
            case "UnitRegister.rpt":
                return ValidateFromToDate();
            case "UnitSummary.rpt":
                return ValidateFromToDate();
            case "unitsummary_Breakup.rpt":
                return ValidateFromToDate();
            case "MonthlyAttendance.rpt":
                return ValidateFromToDate();
            case "ManpowerDetails.rpt":
                return ValidateShift();
            case "ManpowerDetailsGreece.rpt":
                return ValidateShift();
            case "AdjustmentHrsRpt.rpt":
                return ValidateFromToDate();
            case "DeploymentDetail.rpt":
                return ValidateFromToDate();
            // SAT#1191 TFS #2626 UAE - Deployment Detail Report
            case DeploymentDetailReport:
                return ValidateFromToDate();

            default:
                return false;
        }
    }


    #endregion



    /// <summary>
    /// Fillddls the branch.
    /// </summary>
    private void FillddlBranch1()
    {
        var objblUserManagement = new BL.UserManagement();
        using (var dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedItem.Value))
        {
            if (dsBranch.Tables[0].Rows.Count > 0)
            {
                var dr = dsBranch.Tables[0].NewRow();
                dr["LocationCode"] = "All";
                dr["LocationDesc"] = "All";
                dsBranch.Tables[0].Rows.InsertAt(dr, 0);
                msddlBranch.CreateCheckBox(dsBranch.Tables[0], "LocationDesc", "LocationCode");

                var msddlBranchselectedIndex = 0;
                for (var i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
                {
                    if (dsBranch.Tables[0].Rows[i]["LocationCode"].ToString() == BaseLocationCode)
                    {
                        msddlBranch.selectedIndex = i.ToString(CultureInfo.InvariantCulture);
                        i = dsBranch.Tables[0].Rows.Count;
                    }
                }

                if (msddlBranchselectedIndex != 0)
                {
                    msddlBranch.selectedIndex = "1";
                }
            }
        }
    }



    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    private void FillddlEmployeeNumber1()
    {
        var objHrManagement = new BL.HRManagement();
        ddlEmployeeNumber.Items.Clear();
        using (var ds = objHrManagement.EmployeesOfLocationGetAll(msddlBranch.sValue, BaseHrLocationCode, txtFromDate.Text, txtToDate.Text))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlEmployeeNumber.DataSource = ds.Tables[0];
                ddlEmployeeNumber.DataTextField = "Name";
                ddlEmployeeNumber.DataValueField = "EmployeeNumber";
                ddlEmployeeNumber.DataBind();
                var li = new ListItem {Text = @Resources.Resource.All, Value = @"ALL"};
                ddlEmployeeNumber.Items.Insert(0, li);
            }
        }
    }




    /// <summary>
    /// Function to Fill Sale Order Types in a DropDown.
    /// </summary>
    protected void FillSoType()
    {
        var objSales = new BL.Sales();
        var ds = objSales.SaleOrderTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSoType.DataSource = ds.Tables[0];
            ddlSoType.DataValueField = "SaleOrderTypeCode";
            ddlSoType.DataTextField = "SaleOrderTypeDesc";
            ddlSoType.DataBind();
            var li1 = new ListItem();
            li1.Text = "All";
            li1.Value = "All";
            ddlSoType.Items.Insert(0, li1);
           
          
        }
        else
        {
            var li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlSoType.Items.Add(li);
        }
    }

    protected void rdoAssigmentWise_CheckedChanged(object sender, EventArgs e)
    {
        pnlSoType.Visible = false;
    }
    protected void rdoPostWise_CheckedChanged(object sender, EventArgs e)
    {
        pnlSoType.Visible = true;
    }
}
