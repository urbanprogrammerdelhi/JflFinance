// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_Hours.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;
using Common = DL.Common;
using Resource = Resources.Resource;

/// <summary>
/// Class Sales_RptGroup_Hours.
/// </summary>
public partial class Sales_RptGroup_Hours : BasePage
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
            var javaScript = new StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resource.HoursComparison + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID + "');";
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                FillddlReportName();
                btnViewReport.Enabled = true;
                HFStartDate.Value = FirstDateOfCurrentMonth_Get();
                HFEndDate.Value = LastDateOfCurrentMonth_Get();
                MakeTempTable();
                ddlMonth.SelectedValue = DateTime.Parse(HFStartDate.Value).Month.ToString(CultureInfo.InvariantCulture);
                txtYear.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
                txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resource.ValidationExpressionNum + ");";
                txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resource.ValidationExpressionNum + ");";
                //// *******  modified by Manish on 16-mar-2010 added new common bl function SetDatesFromPayPeriod *********
                //// ******* due to getting dates according to pay period ***********************************************

                string[] strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)), int.Parse(DateTime.Now.Year.ToString(CultureInfo.InvariantCulture)));
                txtFromDate.Text = strArray[0];
                txtToDate.Text = strArray[1];
                ViewState["MonthChangeStatus"] = 0;
                GetWeekStartDay();
                GetStartEndDate();
                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                    if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
                    {
                        txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                    }
                }



                FillDivision();
                FillddlAreaInchargeDetails();
                FillddlClient();
                FillddlClientId();
                FillddlAreaId();//Added by Manoj(New Parameter for All Reports) on 17/01/2012
                FillddlVariation();
                ShowHideReportParameterControles();


            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
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
        var li = new ListItem { Text = Resource.rptHourAnalysis, Value = @"HourAnalysis.rpt" };
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resource.ExceptionScheduleVsActual, Value = @"ExceptionsActualVsTeken.rpt" };
        ddlReportName.Items.Add(li);

        li = new ListItem { Text = Resource.ScheduleControlReport, Value = @"ScheduleControl.rpt" };
        ddlReportName.Items.Add(li);


        //if (BaseCompanyCode == "G4FLKGRD") // only for India
        {
            li = new ListItem { Text = Resource.rptMIS, Value = @"MISInd.rpt" };
            ddlReportName.Items.Add(li);
        }

        li = new ListItem { Text = Resource.rptRotaEntryStatusBasedonContractedHours, Value = @"rotaStatusAsmtwisenewInd.rpt" };
        ddlReportName.Items.Add(li);

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
                ddlDivision.DataTextField = "HrLocationCode";
                ddlDivision.DataBind();

                ddlDivisionName.DataSource = dsDivision.Tables[0];
                ddlDivisionName.DataValueField = "HrLocationCode";
                ddlDivisionName.DataTextField = "HrLocationDesc";
                ddlDivisionName.DataBind();
                FillBranch();
            }
        }
    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        ddlBranch.Items.Clear();
        ddlBranchName.Items.Clear();
        var objblUserManagement = new UserManagement();
        using (var dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue))
        {
            if (dsBranch.Tables[0].Rows.Count > 0)
            {


                ddlBranch.DataSource = dsBranch.Tables[0];
                ddlBranch.DataValueField = "LocationAutoId";
                ddlBranch.DataTextField = "LocationCode";
                ddlBranch.DataBind();
                ddlBranchName.DataSource = dsBranch.Tables[0];
                ddlBranchName.DataValueField = "LocationAutoId";
                ddlBranchName.DataTextField = "LocationDesc";
                ddlBranchName.DataBind();
                if (ddlReportName.SelectedItem.Value != @"ScheduleControl.rpt")
                {
                    ddlBranch.Items.Insert(0, new RadComboBoxItem(Resources.Resource.SelectAll, "0"));
                    ddlBranchName.Items.Insert(0, new RadComboBoxItem(Resources.Resource.SelectAll, "All"));
                }
            }
            else
            {
                var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlBranch.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlBranchName.Items.Insert(0, li1);
            }
        }


        if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
        {
            FillddlAreaInchargeDetails();
        }
    }

    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {

        CheckReportType();
    }

    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {

        CheckReportType();
    }

    private void CheckReportType()
    {
        if (ddlReportName.SelectedValue.ToLower() == "misind.rpt")
        {
            if (DateTime.Parse(txtFromDate.Text) <= DateTime.Parse(txtToDate.Text))
            {
                HFStartDate.Value = txtFromDate.Text;
                HFEndDate.Value = txtToDate.Text;
                FillddlAsmt();

            }

        }
    }
    /// <summary>
    /// Fill AreaId Dropdown on AreaIncharge Basis
    /// </summary>
    private void FillddlAreaIdCode()
    {
        ddlAreaIdCode.Items.Clear();
        ddlAreaName.Items.Clear();


        var objOps = new OperationManagement();

        using (var ds = objOps.AreaIdGet(ddlBranch.SelectedValue != string.Empty ? ddlBranch.SelectedItem.Value : BaseLocationAutoID, ddlAreaInchargeCode.SelectedValue))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAreaIdCode.DataSource = ds;
                ddlAreaIdCode.DataTextField = "AreaID";
                ddlAreaIdCode.DataValueField = "AreaID";
                ddlAreaIdCode.DataBind();

                ddlAreaName.DataSource = ds;
                ddlAreaName.DataTextField = "AreaDesc";
                ddlAreaName.DataValueField = "AreaID";
                ddlAreaName.DataBind();

                var li = new RadComboBoxItem { Text = Resource.All, Value = @"All" };
                ddlAreaIdCode.Items.Insert(0, li);

                li = new RadComboBoxItem { Text = Resource.All, Value = @"All" };
                ddlAreaName.Items.Insert(0, li);




            }
            else
            {
                var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlAreaIdCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlAreaName.Items.Insert(0, li1);
            }
        }

        FillddlCustomer(); //Code Added By Ajay Datta On 01-Nov-2012 To refill Client for Training Report



    }


    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlCustomer()
    {
        ddlCustomerCode.Items.Clear();
        ddlCustomerName.Items.Clear();
        var objSales = new Sales();
        using (var ds = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? objSales.ClientGet(BaseLocationAutoID, BaseUserID) : objSales.ClientAreaWiseGet(ddlBranch.SelectedItem.Value, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaIdCode.SelectedItem.Value))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlCustomerCode.DataSource = ds.Tables[0];
                ddlCustomerCode.DataTextField = "ClientCode";
                ddlCustomerCode.DataValueField = "ClientCode";
                ddlCustomerCode.DataBind();

                ddlCustomerName.DataSource = ds.Tables[0];
                ddlCustomerName.DataTextField = "ClientName";
                ddlCustomerName.DataValueField = "ClientCode";
                ddlCustomerName.DataBind();

                var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                ddlCustomerCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                ddlCustomerName.Items.Insert(0, li1);

                FillddlAssignment();
            }
            else
            {
                ddlAssignmtCode.Items.Clear();
                ddlAssignmtName.Items.Clear();
                var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlCustomerCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlCustomerName.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlAssignmtName.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                ddlAssignmtCode.Items.Insert(0, li1);
            }
        }
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
    /// Fillddls the asmt.
    /// </summary>
    private void FillddlAssignment()
    {
        ddlAssignmtCode.Items.Clear();
        ddlAssignmtName.Items.Clear();


        if (ddlCustomerCode.SelectedItem.Value == @"ALL")
        {
            var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlAssignmtCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
            ddlAssignmtName.Items.Insert(0, li1);


        }
        else
        {
            var strClientCode = ddlCustomerCode.SelectedValue;
            var objOperationManagement = new OperationManagement();

            using (var dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(ddlBranch.SelectedItem.Value), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value, ddlAreaIdCode.SelectedItem.Value))
            {
                if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
                {
                    ddlAssignmtCode.DataSource = dsAsmt.Tables[0];
                    ddlAssignmtCode.DataTextField = "AsmtCode";
                    ddlAssignmtCode.DataValueField = "AsmtCode";
                    ddlAssignmtCode.DataBind();

                    ddlAssignmtName.DataSource = dsAsmt.Tables[0];
                    ddlAssignmtName.DataTextField = "AsmtAddress";
                    ddlAssignmtName.DataValueField = "AsmtCode";
                    ddlAssignmtName.DataBind();

                    var li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                    ddlAssignmtCode.Items.Insert(0, li1);

                    li1 = new RadComboBoxItem { Text = Resource.All, Value = @"ALL" };
                    ddlAssignmtName.Items.Insert(0, li1);
                }
                else
                {
                    var li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                    ddlAssignmtCode.Items.Insert(0, li1);

                    li1 = new RadComboBoxItem { Text = Resource.NoDataToShow, Value = @"-1" };
                    ddlAssignmtName.Items.Insert(0, li1);
                }
            }
        }



    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLAreaID control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaIdCode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaName.SelectedValue = ddlAreaIdCode.SelectedValue;
        FillddlCustomer();

    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaIdCode.SelectedValue = ddlAreaName.SelectedValue;
        FillddlCustomer();

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlCustomerCode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlCustomerName.SelectedValue = ddlCustomerCode.SelectedValue;
        FillddlAssignment();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlCustomerName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlCustomerCode.SelectedValue = ddlCustomerName.SelectedValue;
        FillddlAssignment();
    }



    /// <summary>
    /// Fillddls the area incharge details.
    /// </summary>
    private void FillddlAreaInchargeDetails()
    {
        var employeeNumber = String.Empty;

        if (BaseUserIsAreaIncharge == "0" && BaseUserID != "system")
        {
            employeeNumber = BaseUserEmployeeNumber;
        }
        var objHrManagement = new HRManagement();
        ddlAreaInchargeCode.Items.Clear();
        ddlAreaInchargeName.Items.Clear();

        using (var ds = objHrManagement.AreaInchargeGetBasedonUserID(ddlBranch.SelectedValue != string.Empty ? ddlBranch.SelectedItem.Value : BaseLocationAutoID, employeeNumber, BaseUserID))
        {
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
        }
        if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
        {
            FillddlAreaIdCode();
        }
    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {

        var objSales = new Sales();
        using (var ds = objSales.ClientAreaInchargeWiseGet(BaseLocationAutoID, ddlAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, BaseLocationCode, txtFromDate.Text, txtToDate.Text))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientCode.DataSource = ds.Tables[0];
                ddlClientCode.DataTextField = "ClientNameCode";
                ddlClientCode.DataValueField = "ClientCode";
                ddlClientCode.DataBind();

                var li1 = new ListItem { Text = Resource.All, Value = @"ALL" };
                ddlClientCode.Items.Insert(0, li1);

                if (ddlClientCode.SelectedItem.Value != null)
                {
                    FillddlAsmt();
                }
            }
        }
    }
    /// <summary>
    /// Fillddls the client identifier.
    /// </summary>
    private void FillddlClientId()
    {

        var objSales = new Sales();
        using (var ds = objSales.ClientsLocationWiseGet(BaseLocationAutoID))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlClientId.DataSource = ds.Tables[0];
                ddlClientId.DataTextField = "ClientNameCode";
                ddlClientId.DataValueField = "ClientCode";
                ddlClientId.DataBind();

                var li1 = new ListItem { Text = Resource.All, Value = @"ALL" };
                ddlClientId.Items.Insert(0, li1);
            }
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    private void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();
        var objOperationManagement = new OperationManagement();
        if (ddlClientCode.SelectedValue == "ALL")
        {
            var li = new ListItem { Text = Resource.All, Value = "" };
            ddlAsmtCode.Items.Insert(0, li);

        }
        else
        {
            using (
                var dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID),
                    ddlClientCode.SelectedItem.Value, HFStartDate.Value, HFEndDate.Value, BaseUserEmployeeNumber,
                    BaseUserIsAreaIncharge, ""))
            {
                if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
                {
                    ddlAsmtCode.DataSource = dsAsmt.Tables[0];
                    ddlAsmtCode.DataTextField = "AsmtDetail";
                    ddlAsmtCode.DataValueField = "AsmtCode";
                    ddlAsmtCode.DataBind();

                    var li = new ListItem { Text = Resource.All, Value = "" };
                    ddlAsmtCode.Items.Insert(0, li);
                }
                else
                {
                    var li = new ListItem { Text = Resource.NoDataToShow, Value = @"-1" };
                    ddlAsmtCode.Items.Insert(0, li);
                }
            }
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

            var dtNextMonthFirstDay = new DateTime(int.Parse(strYear), int.Parse(nextMonth.ToString(CultureInfo.InvariantCulture)), 1);
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
            var count = 1;
            var rowIndex = 1;
            var nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
            while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
            {
                var dr = dtDates.NewRow();
                dr["Date"] = nextDate;
                dr["WeekNo"] = count;
                nextDate = nextDate.AddDays(1);
                if (nextDate.DayOfWeek.ToString().Trim().ToLower() == BaseScheduleStartDay.Trim().ToLower())
                {
                    count = count + 1;
                }
                rowIndex = rowIndex + 1;
                dtDates.Rows.Add(dr);
            }
            var status = 1;
            while (status < count)
            {
                var li = new ListItem
                {
                    Text = status.ToString(CultureInfo.InvariantCulture),
                    Value = status.ToString(CultureInfo.InvariantCulture)
                };
                ddlWeek.Items.Add(li);
                status = status + 1;
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
        var dv = new DataView(dtDates) { RowFilter = "[WeekNo]='" + (ddlWeek.SelectedValue) + "'" };
        using (var dtStartEndDate = dv.ToTable())
        {
            HFFromDate.Value = DateFormat(dtStartEndDate.Rows[0]["Date"].ToString());
            HFToDate.Value = DateFormat(dtStartEndDate.Rows[6]["Date"].ToString());
        }
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

        if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
        {
            FillDivision();
            FillBranch();
            FillddlAreaInchargeDetails();
            FillddlCustomer();
            FillddlAssignment();
            txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));

        }
        else
        {
            txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
        }


    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDivisionName.SelectedValue = ddlDivision.SelectedValue;
        FillBranch();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivisionName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivisionName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivision.SelectedValue = ddlDivisionName.SelectedValue;
        FillBranch();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBranchName.SelectedValue = ddlBranch.SelectedValue;

        if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
        {
            FillddlAreaInchargeDetails();
            FillddlCustomer();
            FillddlAssignment();
        }

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranchName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranchName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {

        ddlBranch.SelectedValue = ddlBranchName.SelectedValue;
        if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
        {
            FillddlAreaInchargeDetails();
            FillddlCustomer();
            FillddlAssignment();
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeName.SelectedValue = ddlAreaInchargeCode.SelectedValue;
        if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
        {
            FillddlAreaIdCode();
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeCode.SelectedValue = ddlAreaInchargeName.SelectedValue;

        if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
        {
            FillddlAreaIdCode();
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
        if (!string.IsNullOrEmpty(txtYear.Text))
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
        if (ViewState["MonthChangeStatus"].ToString() == "0")
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
        if (txtYear.Text == "")
        {
            txtYear.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);

        }
        FillHiddenDate();
        FillddlAsmt();
        ViewState["MonthChangeStatus"] = 0;

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
        if (ddlClientCode.SelectedItem.Value != null)
        {
            FillddlAsmt();
        }
    }
    /// <summary>
    /// Fills the hidden date.
    /// </summary>
    private void FillHiddenDate()
    {
        //// *******  modified by Manish on 16-mar-2010 added new common bl function SetDatesFromPayPeriod *********
        //// ******* due to getting dates according to pay period ***********************************************
        string[] strArray = GetPayPeriods(BasePayPeriodFromDay, BasePayPeriodToDay, int.Parse(ddlMonth.SelectedItem.Value), int.Parse(txtYear.Text));
        HFStartDate.Value = strArray[0];
        HFEndDate.Value = strArray[1];
    }

    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        var strReportName = ddlReportName.SelectedItem.Value;
        HideAllControles();
        switch (strReportName)
        {
            case "ActualScheduleContractedHrs.rpt":
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

            case "RedHour.rpt":
                PanelDates.Visible = true;
                break;

            case "HourAnalysis.rpt":
                PanelClientId.Visible = true;
                PanelTypeOfService.Visible = true;
                PanelMonth.Visible = true;
                PanelVariance.Visible = true;
                break;
            case "ExceptionsActualVsTeken.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = false;
                PanelDates.Visible = true;
                PanelDetailSummary.Visible = true;
                break;

            case "MIS.rpt":
                PanelBranch.Visible = true;
                PanelClientName.Visible = true;
                PanelMonth.Visible = true;
                PanelAsmt.Visible = true;
                PanelDivision.Visible = true;
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
                PanelDivision.Visible = true;
                PanelDates.Visible = true;
                PanelBranch.Visible = true;
                PanelWorking.Visible = true;
                break;

            case "ScheduleControl.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelDates.Visible = true;
                PanelAreaIdCode.Visible = true;
                PanelCustomerCode.Visible = true;
                PanelAssignment.Visible = true;
                PanelFlexiSaleOrder.Visible = true;
                PanelOutPut.Visible = true;

                break;

            case "MISInd.rpt":
                PanelDates.Visible = true;
                PanelAsmt.Visible = true;
                PanelClientName.Visible = true;
                HFStartDate.Value = txtFromDate.Text;
                HFEndDate.Value = txtToDate.Text;
                break;

            case "rotaStatusAsmtwisenewInd.rpt":
                PanelDates.Visible = true;
                PanelVariation.Visible = true;
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
        PanelAreaIncharge.Visible = false;
        PanelAreaID.Visible = false;
        PanelDetailSummary.Visible = false;
        PanelAreaIdCode.Visible = false;
        PanelCustomerCode.Visible = false;
        PanelFlexiSaleOrder.Visible = false;
        PanelAssignment.Visible = false;
        PanelOutPut.Visible = false;
    }


    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAssignmtCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAssignmtCode_OnSelectedIndexChanged(object o, EventArgs e)
    {
        ddlAssignmtName.SelectedValue = ddlAssignmtCode.SelectedValue;
    }


    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAssignmtName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAssignmtName_OnSelectedIndexChanged(object o, EventArgs e)
    {
        ddlAssignmtCode.SelectedValue = ddlAssignmtName.SelectedValue;
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
        if (!ValidateControles(ddlReportName.SelectedItem.Value)) return;

        var strReportName = ddlReportName.SelectedItem.Value;
        if (strReportName == "ExceptionsActualVsTeken.rpt" && rdbSummary.Checked)
        {
            strReportName = "ExceptionsActualVsTekenSummary.rpt";
        }

        const string strReportPagePath = "../Reports/Rostering/";

        Context.Items.Add("cxtReportFileName", strReportName);
        var hshRptParameters = ReportParameter_Get(strReportName);

        Context.Items.Add("cxtHashParameters", hshRptParameters);
        Context.Items.Add("cxtReportID", "ReportID");
        Context.Items.Add("cxtReportPagePath", strReportPagePath);
        Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Hours.aspx?ReportName=" + ddlReportName.SelectedItem.Value;
        if (ddlReportName.SelectedItem.Value == @"ScheduleControl.rpt")
        {
            Context.Items.Remove("cxtHashParameters");
            Session["cxtHashParameters"] = hshRptParameters;
            Server.Transfer("../Transactions/ScheduleControlReport.aspx");
        }
        else
        {
            Server.Transfer("../Reports/ViewReport1.aspx");
        }
    }
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    private void FillddlAreaId()
    {
        ddlAreaID.Items.Clear();
        var objSale = new OperationManagement();
        //Added by Manoj on 03/09/12
        using (var dsArea = objSale.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID))
        {
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataSource = dsArea;
        }
        ddlAreaID.DataBind();

        var li = new ListItem { Text = @"All", Value = @"All" };
        ddlAreaID.Items.Insert(0, li);

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
            case "ActualScheduleContractedHrs.rpt":

                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.Client, ddlClientId.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.PriceOption, ddlPriceOption.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                if (ddlVariance.SelectedItem.Value == @"1")
                {
                    Context.Items.Remove("cxtReportFileName");
                    Context.Items.Add("cxtReportFileName", "ActualScheduleContractedBreakUpHrs.rpt");
                    hshRptParameters.Add(DL.Properties.Resources.Variance, ddlVariance.SelectedItem.Value);
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.Variance, ddlVariance.SelectedItem.Value);
                }

                return hshRptParameters;
            case "ScheduleContractedHrs.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.Client, ddlClientId.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.PriceOption, ddlPriceOption.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Variance, ddlVariance.SelectedItem.Value);
                return hshRptParameters;
            case "RedHour.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.DivisionCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.BranchCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, "");
                hshRptParameters.Add(DL.Properties.Resources.Variance, "");
                hshRptParameters.Add(DL.Properties.Resources.TypeOfService, "");
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedItem.Value);

                return hshRptParameters;

            case "ExceptionsActualVsTeken.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(ddlBranch.SelectedValue));
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, (ddlDivision.SelectedValue));
                return hshRptParameters;

            case "ExceptionsActualVsTekenSummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(ddlBranch.SelectedValue));
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedValue);
                return hshRptParameters;

            case "rotaStatusAsmtwisenewInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Option, ddlVariation.SelectedValue.ToString());
                return hshRptParameters;


            case "ScheduleControl.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch.SelectedValue != "" ? int.Parse(ddlBranch.SelectedValue) : 0);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaIdCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlCustomerCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAssignmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.SaleOrderTypeCode, chkFlexiSale.Checked.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.OutputFld, ddlOutput.SelectedItem.Value);

                return hshRptParameters;
            case "HourAnalysis.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.BranchCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.DivisionCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientId.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Variance, ddlVariance.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.TypeOfService, ddlTypeOfService.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(HFStartDate.Value, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(HFEndDate.Value, ""));

                if (BaseCountryName == "Egypt")
                {
                    Context.Items["cxtReportFileName"] = BaseCountryName + "_" + ddlReportName.SelectedItem.Value;
                }
                return hshRptParameters;

            case "MIS.rpt":


                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.BranchCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.DivisionCode, ddlDivision.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(HFStartDate.Value, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(HFEndDate.Value, ""));

                return hshRptParameters;

            case "MISInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.DivisionCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.BranchCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(HFStartDate.Value, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(HFEndDate.Value, ""));
                return hshRptParameters;
            case "rostrpt_WeekHrs.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DateTime.Parse(HFFromDate.Value));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DateTime.Parse(HFToDate.Value));

                return hshRptParameters;
            case "ContVsActual_Greece.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;
            case "ActualVsscheduleMonthly.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;
            case "TotalVsOvertime.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));

                return hshRptParameters;

            case "ContractualVsScheduledVsActual.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.ReportId, int.Parse("1"));
                return hshRptParameters;
            case "ScheduledOTVsActualOT.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.ReportId, int.Parse("2"));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                return hshRptParameters;
            case "HoursGreaterThanRules.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AttendanceType, ddlAttendType.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AttendanceFor, ddlReportType.SelectedItem.Value);
                return hshRptParameters;
            default: return hshRptParameters;
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
            case "ExceptionsActualVsTeken.rpt":
                return ValidateFromToDate();
            case "rpt_WeeklySchedule_EmpWise.rpt":
                return ValidateFromToDate();
            case "ScheduleControl.rpt":
                return ValidateFromToDate();
            case "rotaStatusAsmtwisenewInd.rpt":
                return ValidateFromToDate();

            case "ActualScheduleContractedHrs.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }


                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ScheduleContractedHrs.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }


                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "RedHour.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ActualScheduleContractedBreakUpHrs.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "HourAnalysis.rpt":
                return true;

            case "MIS.rpt":
                return true;

            case "MISInd.rpt":
                return ValidateFromToDate();

            case "rostrpt_WeekHrs.rpt":
                return true;
            case "ContVsActual_Greece.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ActualVsscheduleMonthly.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "TotalVsOvertime.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ContractualVsScheduledVsActual.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ScheduledOTVsActualOT.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "HoursGreaterThanRules.rpt":
                if (txtToDate.Text != "" && txtFromDate.Text != "")
                {
                    var objCommon = new BL.Common();
                    if (objCommon.IsValidDate(txtFromDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtFromDate.Focus();
                        return false;
                    }
                    if (objCommon.IsValidDate(txtToDate.Text) != true)
                    {
                        lblErrorMsg.Text = Resource.InvalidDate;
                        txtToDate.Focus();
                        return false;
                    }
                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                        return false;
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }

            default:
                return false;
        }
    }
    #endregion

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
            else
            {
                lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                return false;
            }
        }
        else
        {
            lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
            return false;
        }
    }
}
