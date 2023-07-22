// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="RptGroup_Israel.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;


/// <summary>
/// Class RptGroup_Israel.
/// </summary>
public partial class RptGroup_Israel : BasePage
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
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, System.StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
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
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, System.StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
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
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, System.StringComparison.Ordinal).ToString(CultureInfo.InvariantCulture));
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
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
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, System.StringComparison.Ordinal).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
            }
            catch (Exception Ex)
            { throw new Exception("Have not Rights", Ex); }
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
            // Button1.Attributes["onMouseDown"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= 'ViewReport1.aspx';";
            // this.Form.Attributes["onMouseOver"] = "javascript:document.getElementById('" + this.Form.ClientID + "').target= '';";
            //this.Button1.Attributes.Add("onclick","this.form.target='_blank'");

            /* code added by Manish to Open report in New Page*/
            //======================================================

            //Label lblPageHdrTitle = (Label)Master.FindControl("lblPageHdrTitle");
            //if (lblPageHdrTitle != null)
            //{ lblPageHdrTitle.Text = Resources.Resource.Schedules; }

            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file

            #region Added by  For Weekly Rest

            #endregion

            var JavaScript = new System.Text.StringBuilder();
            JavaScript.Append("<script type='text/javascript'>");
            JavaScript.Append("window.document.body.onload = function ()");
            JavaScript.Append("{\n");
            JavaScript.Append("PageTitle('" + Resources.Resource.Schedules + "');");
            JavaScript.Append("};\n");
            JavaScript.Append("// -->\n");
            JavaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "BodyLoadUnloadScript", JavaScript.ToString());


            if (IsReadAccess)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID + "');";
                ImgAsOnDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtAsOnDate.ClientID + "');";

                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                txtAsOnDate.Attributes.Add("readonly", "readonly");
                //ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientName.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
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

                FillddlReportTypeMain();
                FillddlReportName();



                txtYear.Text = DateTime.Now.Year.ToString();
                txtYear1.Text = DateTime.Now.Year.ToString();
                txtYear2.Text = DateTime.Now.Year.ToString();
                txtForNextNDays.Text = @"10";
                txtForNextNDays.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) ){return true;}else{return false;}");
                btnViewReport.Enabled = true;

                if (ddlReportName.SelectedItem.Value == @"WeeklyPostingSheet.rpt"
                || ddlReportName.SelectedItem.Value == @"Weeklyscheduleroster.rpt"
                || ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyActualReport ||
                            ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyScheduleReport
                    )
                {
                    txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                }
                else
                {
                    txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
                }

                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != "")
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }

                ShowHideReportParameterControles();
                FillDivision();
                FillBranch();
                FillddlAreaInchargeDetails();
                // FillDDlAreaID();
                // FillddlEmployeeNumber();
                // FillddlClient();

                FillDDlShift();
                FillDDLShiftCode();
                FillShiftTimeFromTo();
                FillddlVariation();
                FillAllTrainings();
                FillAllConstraint();
                FillAllIdType();
                FillAllLanguage();
                FillAllQualification();
                FillAllSkill();
                ViewState["MonthChangeStatus"] = 0;
                ViewState["MonthChangeStatus2"] = 0;

                if (ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyRest)
                {
                    GetDatebasedOnSystemParameters();
                    GetDatebasedOnSystemParameters2();
                    GetWeekStartDay();
                    GetStartEndDate();

                    txtFromDate.Text = HFFromDate.Value;
                    GetWeekStartDay2();
                    GetStartEndDate2();

                    //txtFromDate.Text = HFFromDate.Value;
                    txtToDate.Text = HFToDate2.Value;
                }


                //FillParametersBasedOnReportName();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    private void FillParametersBasedOnReportName()
    {
        //FillDivision();
        //if (ddlReportTypeMain.SelectedValue == "Rostering")
        //{
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyScheduleReport)
        //    {


        //        FillddlAreaInchargeDetails();
        //        // FillDDlAreaID();

        //        //FillddlEmployeeNumber();
        //        //FillddlClient();

        //        //FillDDlShift();
        //        //FillDDLShiftCode();
        //        //FillShiftTimeFromTo();
        //        //FillddlVariation();
        //        //FillAllTrainings();
        //        //FillAllConstraint();
        //        //FillAllIdType();
        //        //FillAllLanguage();
        //        //FillAllQualification();
        //        //FillAllSkill();
        //    }
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.MonthlyScheduleReport)
        //    {
        //        FillddlAreaInchargeDetails();
        //    }

        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyActualReport)
        //    {
        //        FillddlAreaInchargeDetails();
        //    }

        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.MonthlyActualReport)
        //    {
        //        FillddlAreaInchargeDetails();
        //    }
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.ScheduleandActuals)
        //    {
        //        FillddlAreaInchargeDetails();
        //    }
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.EmployeeWiseScheduleandActuals)
        //    {
        //        FillddlAreaInchargeDetails();
        //    }
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.EmployeeWiseHoursReport)
        //    {
        //        FillddlAreaInchargeDetails();
        //    }


        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.UnscheduledEmployees)
        //    {
        //        FillddlAreaInchargeDetails();
        //    }

        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.NonOccupied)
        //    {
        //        ddlDivisionName.SelectedValue = ddlDivision.SelectedValue;
        //        //  FillddlAreaInchargeDetails();
        //        FillddlVariation();
        //    }

        if (ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyRest)
        {
            try
            {
                GetDatebasedOnSystemParameters();
                GetDatebasedOnSystemParameters2();
                GetWeekStartDay();
                GetStartEndDate();

                txtFromDate.Text = HFFromDate.Value;
                GetWeekStartDay2();
                GetStartEndDate2();

                //txtFromDate.Text = HFFromDate.Value;
                txtToDate.Text = HFToDate2.Value;
            }
            catch (Exception) { }
        }
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.BarredEmployees)
        //    {
        //    }

        //}

        //if (ddlReportTypeMain.SelectedValue == "Training")
        //{
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.dailyRefresherTrainingDue)
        //    {
        //    }

        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.RefresherTrainingDue)
        //    {
        //    }
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.RefresherTrainingSchedule)
        //    {

        //    }
        //}


        //if (ddlReportTypeMain.SelectedValue == "YLM")
        //{
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.YLMAttendance)
        //    {
        //    }

        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.YLMAttendanceOnline)
        //    {
        //    }

        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.YLMAttendanceNoshow)
        //    {
        //    }

        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.YLMAttendanceVacant)
        //    {
        //    }
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.YLMContactDetails)
        //    {
        //    }

        //}


        //if (ddlReportTypeMain.SelectedValue == @"SaleOrder")
        //{
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.SaleOrderDetails)
        //    {
        //    }
        //}


        //if (ddlReportTypeMain.SelectedValue == @"Constraint")
        //{
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.EmployeeConstraint)
        //    {
        //    }
        //    if (ddlReportName.SelectedItem.Text == Resources.Resource.ClientConstraints)
        //    {
        //    }

        //}
    }
    #endregion

    #region Fill Controles
    /// <summary>
    /// Function used to fill Report Type Drop Down List.
    /// </summary>
    private void FillddlReportTypeMain()
    {
        var LI = new RadComboBoxItem { Text = Resources.Resource.Rostering, Value = @"Rostering" };
        ddlReportTypeMain.Items.Add(LI);

        //Removing Training From Israel Group and Putting It Under HR Reports
        //li = new RadComboBoxItem();
        //li.Text = Resources.Resource.Training.ToString();
        //li.Value = "Training";
        //ddlReportTypeMain.Items.Add(li);

        LI = new RadComboBoxItem { Text = Resources.Resource.YLM, Value = @"YLM" };
        ddlReportTypeMain.Items.Add(LI);

        #region Added New Report Type for Isreal SaleOrder by  on 18-Feb-2014
        //LI = new RadComboBoxItem { Text = Resources.Resource.SalesManagement, Value = @"SaleOrder" };
        //ddlReportTypeMain.Items.Add(LI);
        #endregion
        //LI = new RadComboBoxItem { Text = Resources.Resource.Constraint, Value = @"Constraint" };
        //ddlReportTypeMain.Items.Add(LI);




    }

    //private void FillRestCombo()
    //{
    //    var li = new RadComboBoxItem {Text = @"Yes", Value = @"Yes"};
    //    Restcombo.Items.Add(li);

    //    var li1 = new RadComboBoxItem();
    //    li.Text = @"No";
    //    li1.Value = @"No";
    //    Restcombo.Items.Add(li1);
    //}

    /// <summary>
    /// Function used to fill Report Name Drop Down List.
    /// </summary>
    private void FillddlReportName()
    {
        ddlReportName.Items.Clear();
        var LI = new RadComboBoxItem();
        if (ddlReportTypeMain.SelectedValue == "Rostering")
        {
            //li = new ListItem();
            LI.Text = Resources.Resource.WeeklyScheduleReport;
            LI.Value = @"rpt_ActualSchedule_AsmtWise.rpt1";
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem
                     {
                         Text = Resources.Resource.MonthlyScheduleReport,
                         Value = @"rpt_ActualSchedule_AsmtWise.rpt2"
                     };
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem
                     {
                         Text = Resources.Resource.WeeklyActualReport,
                         Value = @"rpt_ActualSchedule_AsmtWise.rpt3"
                     };
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem
                     {
                         Text = Resources.Resource.MonthlyActualReport,
                         Value = @"rpt_ActualSchedule_AsmtWise.rpt4"
                     };
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem { Text = Resources.Resource.ScheduleandActuals, Value = @"rpt_ActualSchedule_AsmtWiseNew.rpt" };
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem
                     {
                         Text = Resources.Resource.EmployeeWiseScheduleandActuals,
                         Value = @"rpt_WeeklySchedule_EmpWise.rpt"
                     };
            ddlReportName.Items.Add(LI);


            LI = new RadComboBoxItem { Text = Resources.Resource.EmployeeWiseHoursReport, Value = @"EmployeeWiseHoursReport" };
            ddlReportName.Items.Add(LI);


            //Commented By Ajay Datta On 16-Aug-2013 Report Moved To Hours Group
            //li = new RadComboBoxItem();
            //li.Text = Resources.Resource.ExceptionScheduleVsActual;
            //li.Value = "ExceptionsActualVsTeken.rpt";
            //ddlReportName.Items.Add(li);

            //LI = new RadComboBoxItem { Text = Resources.Resource.UnscheduledEmployees, Value = @"UnscheduledEmployees" };
            //ddlReportName.Items.Add(LI);

            //Manish 23/04/2013 Add new report non occupied report
            LI = new RadComboBoxItem { Text = Resources.Resource.NonOccupied, Value = @"NonOccupied.rpt" };
            ddlReportName.Items.Add(LI);

            // 24/12/2013 Add new report for rest
            //LI = new RadComboBoxItem { Text = Resources.Resource.WeeklyRest, Value = @"WeeklyRest" };
            //ddlReportName.Items.Add(LI);

            // 11/03/2013 Add new report for Barred Employees
            //LI = new RadComboBoxItem { Text = Resources.Resource.BarredEmployees, Value = @"BarredEmployees" };
            //ddlReportName.Items.Add(LI);

        }

        if (ddlReportTypeMain.SelectedValue == "Training")
        {
            //li = new ListItem();
            LI.Text = Resources.Resource.dailyRefresherTrainingDue;
            LI.Value = @"dailyRefresherTrainingDue.rpt";
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem();
            LI.Text = Resources.Resource.RefresherTrainingDue;
            LI.Value = @"dateRangeRefresherTrainingDue.rpt";
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem
                     {
                         Text = Resources.Resource.RefresherTrainingSchedule,
                         Value = @"dateRangeRefresherTrainingSchedule.rpt"
                     };
            ddlReportName.Items.Add(LI);
        }


        if (ddlReportTypeMain.SelectedValue == "YLM")
        {
            LI = new RadComboBoxItem { Text = Resources.Resource.YLMAttendance, Value = @"YLMAttendance" };
            ddlReportName.Items.Add(LI);


            LI = new RadComboBoxItem { Text = Resources.Resource.YLMAttendanceOnline, Value = @"YLMAttendanceOnline" };
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem { Text = Resources.Resource.YLMAttendanceNoshow, Value = @"YLMAttendanceNoshow" };
            ddlReportName.Items.Add(LI);


            LI = new RadComboBoxItem { Text = Resources.Resource.YLMAttendanceVacant, Value = @"YLMAttendanceVacant" };
            ddlReportName.Items.Add(LI);

            LI = new RadComboBoxItem { Text = Resources.Resource.YLMContactDetails, Value = @"YLMContactDetails" };
            ddlReportName.Items.Add(LI);


        }

        #region Added New Report Name for Isreal SaleOrder by  on 18-Feb-2014

        if (ddlReportTypeMain.SelectedValue == @"SaleOrder")
        {
            LI = new RadComboBoxItem { Text = Resources.Resource.SaleOrderDetails, Value = @"SaleOrderDetail_Isreal.rpt" };
            ddlReportName.Items.Add(LI);
            FillddlClient();
        }

        #endregion

        if (ddlReportTypeMain.SelectedValue == @"Constraint")
        {

            LI = new RadComboBoxItem { Text = Resources.Resource.EmployeeConstraint, Value = @"EmployeeConstraint" };
            ddlReportName.Items.Add(LI);
            LI = new RadComboBoxItem { Text = Resources.Resource.ClientConstraints, Value = @"CustomerConstraint" };
            ddlReportName.Items.Add(LI);
        }
    }

    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision()
    {
        ddlDivision.Items.Clear();
        ddlBranch.Items.Clear();
        var ObjblUserManagement = new BL.UserManagement();
        var DsDivision = ObjblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (DsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = DsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationCode";
            ddlDivision.DataBind();

            ddlDivisionName.DataSource = DsDivision.Tables[0];
            ddlDivisionName.DataValueField = "HrLocationCode";
            ddlDivisionName.DataTextField = "HrLocationDesc";
            ddlDivisionName.DataBind();

            if (PanelDivision.Visible == false)
            {
                ddlDivision.SelectedValue = BaseHrLocationCode;
                ddlDivisionName.SelectedValue = ddlDivision.SelectedValue;
            }
            FillBranch();
        }
    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        var ObjblUserManagement = new BL.UserManagement();
        //Added By  for Weekly Rest Report


        var DsBranch = ObjblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue);

        if (DsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = DsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationAutoId";
            ddlBranch.DataTextField = "LocationCode";
            ddlBranch.DataBind();

            ddlBranchName.DataSource = DsBranch.Tables[0];
            ddlBranchName.DataValueField = "LocationAutoId";
            ddlBranchName.DataTextField = "LocationDesc";
            ddlBranchName.DataBind();

            if (PanelBranch.Visible == false)
            {
                ddlBranch.SelectedValue = BaseLocationAutoID;
                ddlBranchName.SelectedValue = BaseLocationAutoID;
            }




        }
    }

    //Added By  For Binding Weeks

    #region Code for Panel Week For Weekly Rest
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlMonth1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlMonth1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        // FillddlWeek();
        //  SetFromAndToDate(GetDatebasedOnSystemParameters());
        // ddlMonth.Focus();
        try
        {
            ViewState["MonthChangeStatus"] = 0;
            GetWeekStartDay();
            GetStartEndDate();

            txtFromDate.Text = HFFromDate.Value;
        }
        catch (Exception) { }
        //txtToDate.Text = HFToDate.Value;
        //weekStartDate.Value = txtFromDate.Text;
        //weekEndDate.Value = txtToDate.Text;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlWeek control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlWeek_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //SetFromAndToDate(GetDatebasedOnSystemParameters());
        //ddlWeek.Focus();
        try
        {
            ViewState["MonthChangeStatus"] = 1;
            if ((string)ViewState["MonthChangeStatus"] == "0")
            {
                GetWeekStartDay();
            }
            GetStartEndDate();

            txtFromDate.Text = HFFromDate.Value;
        }
        catch (Exception) { }
        //txtToDate.Text = HFToDate.Value;
        //weekStartDate.Value = txtFromDate.Text;
        //weekEndDate.Value = txtToDate.Text;
        //FillddlClient();
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
            txtYear1.Text = DateTime.Now.Year.ToString();
        }
        if (txtYear1.Text.Length < 4)
        {
            Show("Invalid Year");
            txtYear1.Text = DateTime.Now.Year.ToString();
        }
        try
        {
            FillddlWeek();
            SetFromAndToDate(GetDatebasedOnSystemParameters());
            txtYear1.Focus();
        }
        catch (Exception Ex)
        {
            Show("Invalid Year");
            txtYear1.Text = DateTime.Now.Year.ToString();
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
                var DtDates = (DataTable)ViewState["Dates"];
                DtDates.Clear();
                // dtDates.Clear();
                ddlWeek.Items.Clear();
                var DtSelectedMonthFirstDay = new DateTime(int.Parse(txtYear1.Text), int.Parse(ddlMonth1.SelectedValue), 1);
                int NextMonth;
                string StrYear = txtYear1.Text;
                if (int.Parse(ddlMonth1.SelectedValue) == 12)
                {
                    StrYear = Convert.ToString(int.Parse(txtYear1.Text) + 1);
                    NextMonth = 1;
                }
                else
                {
                    NextMonth = int.Parse(ddlMonth1.SelectedValue) + 1;
                }

                var DtNextMonthFirstDay = new DateTime(int.Parse(StrYear), int.Parse(NextMonth.ToString()), 1);
                var DtCurrentMonthLastDay = new DateTime(int.Parse(txtYear1.Text), int.Parse(ddlMonth1.SelectedValue), 1).AddMonths(1).AddDays(-1);
                // while (dtSelectedMonthFirstDay.DayOfWeek != DayOfWeek.Sunday)
                var StrScheduleWeeklyStartDay = string.Empty;
                var StrScheduleWeeklyEndDay = string.Empty;
                if (ViewState["ScheduleWeeklyStartDay"] != null && ViewState["ScheduleWeeklyStartDay"].ToString() != "")
                {
                    StrScheduleWeeklyStartDay = ViewState["ScheduleWeeklyStartDay"].ToString();
                    StrScheduleWeeklyEndDay = ViewState["ScheduleWeeklyEndDay"].ToString();
                }
                else
                {
                    if (ViewState["ScheduleWeeklyFromDay"] != null && ViewState["ScheduleWeeklyFromDay"].ToString() != "")
                    {
                        string StrCurrentMonthStartDate = ViewState["ScheduleWeeklyFromDay"].ToString();
                        var CultureInfo = new CultureInfo("en-us");
                        StrScheduleWeeklyStartDay = DateTime.Parse(StrCurrentMonthStartDate).ToString("dddd", CultureInfo);
                        StrScheduleWeeklyEndDay = DateTime.Parse(DateTime.Parse(StrCurrentMonthStartDate).AddDays(double.Parse("-1")).ToString()).ToString("dddd", CultureInfo);
                    }
                }

                while (DtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != StrScheduleWeeklyStartDay.Trim().ToLower())
                {
                    if (StrScheduleWeeklyStartDay == "")
                    {
                        break;
                    }
                    DtSelectedMonthFirstDay = DtSelectedMonthFirstDay.AddDays(1);
                }
                if (DtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != StrScheduleWeeklyEndDay.Trim().ToLower())
                {
                    while (DtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != StrScheduleWeeklyEndDay.Trim().ToLower())
                    {
                        if (StrScheduleWeeklyEndDay == "")
                        {
                            break;
                        }
                        DtNextMonthFirstDay = DtNextMonthFirstDay.AddDays(1);
                    }
                }
                else
                {
                    DtNextMonthFirstDay = DtCurrentMonthLastDay;
                }

                var DtSelectedMonthFirstDate = DtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
                var DtNextMonthFirstDate = DtNextMonthFirstDay.ToString("dd-MMM-yyyy");
                var Count = 1;
                var RowIndex = 1;

                var NextDate = DateTime.Parse(DtSelectedMonthFirstDate);
                while (NextDate <= DateTime.Parse(DtNextMonthFirstDate))
                {
                    var Dr = DtDates.NewRow();
                    Dr["Date"] = NextDate.ToString("dd-MMM-yyyy");
                    Dr["WeekNo"] = Count;
                    NextDate = NextDate.AddDays(1);
                    if (NextDate.DayOfWeek.ToString().Trim().ToLower() == StrScheduleWeeklyStartDay.Trim().ToLower())
                    {
                        Count = Count + 1;
                    }
                    RowIndex = RowIndex + 1;
                    DtDates.Rows.Add(Dr);
                }

                var Status = 1;

                while (Status < Count)
                {
                    var WeekNumberAndRange = "";
                    var DvDates = new DataView(DtDates) { RowFilter = "[WeekNo]='" + Status + "'" };
                    var TableDates = DvDates.ToTable();
                    try
                    {
                        WeekNumberAndRange = DateTime.Parse(TableDates.Rows[0]["Date"].ToString()).ToString("dd-MMM-yy") + " - " + DateTime.Parse(TableDates.Rows[6]["Date"].ToString()).ToString("dd-MMM-yy");
                    }
                    catch (Exception Ex)
                    {
                        lblErrorMsg.Text = Resources.Resource.ErrorMessage;
                    }
                    var LI = new RadComboBoxItem
                    {
                        Text = Status + @"   [" + WeekNumberAndRange + @"]",
                        Value = Status.ToString()
                    };
                    ddlWeek.Items.Add(LI);
                    Status = Status + 1;
                    TableDates.Dispose();
                }
                ViewState["Dates"] = DtDates;
            }
        }
        catch (Exception) { }

    }
    /// <summary>
    /// Gets the start end date.
    /// </summary>
    private void GetStartEndDate()
    {
        var DtDates = (DataTable)ViewState["Dates"];
        var Dv = new DataView(DtDates);
        if (ddlWeek != null && ddlWeek.SelectedValue != "")
        {
            Dv.RowFilter = "[WeekNo]='" + (ddlWeek.SelectedValue) + "'";
            var DtStartEndDate = Dv.ToTable();
            HFFromDate.Value = DateTime.Parse(DtStartEndDate.Rows[0]["Date"].ToString()).ToString("dd-MMM-yyyy");
            //HFToDate.Value = DateTime.Parse(dtStartEndDate.Rows[6]["Date"].ToString()).ToString("dd-MMM-yyyy");
        }
    }
    /// <summary>
    /// Fillddls the week.
    /// </summary>
    protected void FillddlWeek()
    {
        ddlWeek.Items.Clear();
        var IntMonth = int.Parse(ddlMonth1.SelectedItem.Value);
        var IntYear = int.Parse(txtYear1.Text);
        var IntDays = decimal.Parse(System.DateTime.DaysInMonth(IntYear, IntMonth).ToString());
        var DecNoOfWeeks = (IntDays - GetDatebasedOnSystemParameters().Day) / 7;
        int IntNoOfWeek;
        if (DecNoOfWeeks < 1) { IntNoOfWeek = 1; }
        if (DecNoOfWeeks > 1 && DecNoOfWeeks < 2) { IntNoOfWeek = 2; }
        if (DecNoOfWeeks > 2 && DecNoOfWeeks < 3) { IntNoOfWeek = 3; }
        if (DecNoOfWeeks > 3 && DecNoOfWeeks < 4) { IntNoOfWeek = 4; }
        else if (DecNoOfWeeks > 4 && DecNoOfWeeks < 5) { IntNoOfWeek = 5; }
        else { IntNoOfWeek = 6; }
        var I = 1;
        while (IntNoOfWeek >= I)
        {
            var LI = new RadComboBoxItem { Text = I.ToString(), Value = I.ToString() };
            ddlWeek.Items.Add(LI);
            I++;
        }

        SetFromAndToDate(GetDatebasedOnSystemParameters());
        //weekStartDate.Value = txtFromDate.Text;
        //weekEndDate.Value = txtToDate.Text;
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
            //dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
            //txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
            //weekStartDate.Value = txtFromDate.Text;
            //weekEndDate.Value = txtToDate.Text;
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
            var ObjRoster = new BL.Roster();
            var StrSelectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth1.SelectedValue)) + "-" + txtYear1.Text);
            var Dt = ObjRoster.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, StrSelectedMonthStartDate, "Weekly".Trim().ToLower());
            var DtSelectedMonthFirstDate = new DateTime(int.Parse(txtYear1.Text), int.Parse(ddlMonth1.SelectedValue), 1);

            if (Dt != null && Dt.Rows.Count > 0)
            {
                //ViewState["ScheduleWeeklyFromDay"] = dt.Rows[0]["ScheduleWeeklyFromDay"].ToString();
                var StrScheduleWeeklyStartDay = Dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();

                //// while condition modified by Manish. new CultureInfo("en-US") is used to compare  
                while (DtSelectedMonthFirstDate.ToString("dddd", new CultureInfo("en-US")).ToUpper() != StrScheduleWeeklyStartDay.ToUpper())
                {
                    DtSelectedMonthFirstDate = DtSelectedMonthFirstDate.AddDays(1);
                }
                //dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays((int.Parse(ddlWeek.SelectedItem.Value.ToString()) - 1) * 7);
                //txtFromDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
                //dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
                //txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");

                if (int.Parse(ViewState["MonthChangeStatus"].ToString()) == 0)
                {
                    MakeTempTable();
                    ViewState["ScheduleWeeklyFromDay"] = Dt.Rows[0]["ScheduleWeeklyFromDay"].ToString();
                    ViewState["ScheduleWeeklyStartDay"] = Dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();
                    ViewState["ScheduleWeeklyEndDay"] = Dt.Rows[0]["ScheduleWeeklyEndDay"].ToString();
                    GetWeekStartDay();
                }
            }
            return DtSelectedMonthFirstDate;
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
        var DtDates = new DataTable();
        var DCol1 = new DataColumn("Date", typeof(System.String));
        var DCol2 = new DataColumn("WeekNo", typeof(System.Int32));
        DtDates.Columns.Add(DCol1);
        DtDates.Columns.Add(DCol2);
        ViewState["Dates"] = DtDates;
    }

    #endregion


    #region Code for Panel Week For Weekly Rest 2
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlMonth2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlMonth2_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        // FillddlWeek();
        //  SetFromAndToDate(GetDatebasedOnSystemParameters());
        // ddlMonth.Focus();
        ViewState["MonthChangeStatus2"] = 0;
        GetWeekStartDay2();
        GetStartEndDate2();

        //txtFromDate.Text = HFFromDate.Value;
        txtToDate.Text = HFToDate2.Value;
        //weekStartDate.Value = txtFromDate.Text;
        //weekEndDate.Value = txtToDate.Text;

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DdlWeek2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlWeek2_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //SetFromAndToDate(GetDatebasedOnSystemParameters());
        //ddlWeek.Focus();

        ViewState["MonthChangeStatus2"] = 1;
        if (ViewState["MonthChangeStatus2"].ToString() == @"0")
        {
            GetWeekStartDay2();
        }
        GetStartEndDate2();

        // txtFromDate.Text = HFFromDate2.Value;
        txtToDate.Text = HFToDate2.Value;
        // weekStartDate2.Value = txtFromDate.Text;
        // weekEndDate2.Value = txtToDate.Text;

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
            txtYear2.Text = DateTime.Now.Year.ToString();
        }
        if (txtYear2.Text.Length < 4)
        {
            Show("Invalid Year");
            txtYear2.Text = DateTime.Now.Year.ToString();
        }
        try
        {
            FillddlWeek2();
            SetFromAndToDate2(GetDatebasedOnSystemParameters2());
            txtYear2.Focus();
        }
        catch (Exception Ex)
        {
            Show("Invalid Year");
            txtYear2.Text = DateTime.Now.Year.ToString();
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
            // lblErrorMsg.Text = "Hi";
            var DtDates = (DataTable)ViewState["Dates2"];
            DtDates.Clear();
            // dtDates.Clear();
            ddlWeek2.Items.Clear();
            var DtSelectedMonthFirstDay = new DateTime(int.Parse(txtYear2.Text), int.Parse(ddlMonth2.SelectedValue), 1);
            int NextMonth;
            var StrYear = txtYear2.Text;
            if (int.Parse(ddlMonth2.SelectedValue) == 12)
            {
                StrYear = (int.Parse(txtYear2.Text) + 1).ToString();
                NextMonth = 1;
            }
            else
            {
                NextMonth = int.Parse(ddlMonth2.SelectedValue) + 1;
            }

            var DtNextMonthFirstDay = new DateTime(int.Parse(StrYear), int.Parse(NextMonth.ToString()), 1);
            var DtCurrentMonthLastDay = new DateTime(int.Parse(txtYear2.Text), int.Parse(ddlMonth2.SelectedValue), 1).AddMonths(1).AddDays(-1);
            // while (dtSelectedMonthFirstDay.DayOfWeek != DayOfWeek.Sunday)
            var StrScheduleWeeklyStartDay = string.Empty;
            var StrScheduleWeeklyEndDay = string.Empty;
            if (ViewState["ScheduleWeeklyStartDay2"] != null && ViewState["ScheduleWeeklyStartDay2"].ToString() != "")
            {
                StrScheduleWeeklyStartDay = ViewState["ScheduleWeeklyStartDay2"].ToString();
                StrScheduleWeeklyEndDay = ViewState["ScheduleWeeklyEndDay2"].ToString();
            }
            else
            {
                if (ViewState["ScheduleWeeklyFromDay2"] != null && ViewState["ScheduleWeeklyFromDay2"].ToString() != "")
                {
                    var strCurrentMonthStartDate = ViewState["ScheduleWeeklyFromDay2"].ToString();
                    var cultureInfo = new CultureInfo("en-us");
                    StrScheduleWeeklyStartDay = DateTime.Parse(strCurrentMonthStartDate).ToString("dddd", cultureInfo);
                    StrScheduleWeeklyEndDay = DateTime.Parse(DateTime.Parse(strCurrentMonthStartDate).AddDays(double.Parse("-1")).ToString()).ToString("dddd", cultureInfo);
                }
            }

            while (DtSelectedMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != StrScheduleWeeklyStartDay.Trim().ToLower())
            {
                if (StrScheduleWeeklyStartDay == "")
                {
                    break;
                }
                DtSelectedMonthFirstDay = DtSelectedMonthFirstDay.AddDays(1);
            }
            if (DtCurrentMonthLastDay.DayOfWeek.ToString().Trim().ToLower() != StrScheduleWeeklyEndDay.Trim().ToLower())
            {
                while (DtNextMonthFirstDay.DayOfWeek.ToString().Trim().ToLower() != StrScheduleWeeklyEndDay.Trim().ToLower())
                {
                    if (StrScheduleWeeklyEndDay == "")
                    {
                        break;
                    }
                    DtNextMonthFirstDay = DtNextMonthFirstDay.AddDays(1);
                }
            }
            else
            {
                DtNextMonthFirstDay = DtCurrentMonthLastDay;
            }

            var dtSelectedMonthFirstDate = DtSelectedMonthFirstDay.ToString("dd-MMM-yyyy");
            var dtNextMonthFirstDate = DtNextMonthFirstDay.ToString("dd-MMM-yyyy");
            var count = 1;
            var rowIndex = 1;

            var nextDate = DateTime.Parse(dtSelectedMonthFirstDate);
            while (nextDate <= DateTime.Parse(dtNextMonthFirstDate))
            {
                var dr = DtDates.NewRow();
                dr["Date"] = nextDate.ToString("dd-MMM-yyyy");
                dr["WeekNo"] = count;
                nextDate = nextDate.AddDays(1);
                if (nextDate.DayOfWeek.ToString().Trim().ToLower() == StrScheduleWeeklyStartDay.Trim().ToLower())
                {
                    count = count + 1;
                }
                rowIndex = rowIndex + 1;
                DtDates.Rows.Add(dr);
            }

            var status = 1;

            while (status < count)
            {
                var weekNumberAndRange = "";
                var dvDates = new DataView(DtDates) { RowFilter = "[WeekNo]='" + status + "'" };
                var tableDates = dvDates.ToTable();
                try
                {
                    weekNumberAndRange = DateTime.Parse(tableDates.Rows[0]["Date"].ToString()).ToString("dd-MMM-yy") + " - " + DateTime.Parse(tableDates.Rows[6]["Date"].ToString()).ToString("dd-MMM-yy");
                }
                catch (Exception ex)
                {
                }
                var li = new RadComboBoxItem { Text = status + @"   [" + weekNumberAndRange + @"]", Value = status.ToString() };
                ddlWeek2.Items.Add(li);
                status = status + 1;
                tableDates.Dispose();
            }
            ViewState["Dates2"] = DtDates;
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
            // HFFromDate.Value = DateTime.Parse(dtStartEndDate.Rows[0]["Date"].ToString()).ToString("dd-MMM-yyyy");
            HFToDate2.Value = DateTime.Parse(dtStartEndDate.Rows[6]["Date"].ToString()).ToString("dd-MMM-yyyy");
            //HFMaxDate.Value = DateTime.Parse(dtDates.Rows[dtDates.Rows.Count - 1]["Date"].ToString()).ToString("dd-MMM-yyyy");
        }
    }
    /// <summary>
    /// Fillddls the week2.
    /// </summary>
    protected void FillddlWeek2()
    {
        ddlWeek2.Items.Clear();
        var intMonth = int.Parse(ddlMonth2.SelectedItem.Value);
        var intYear = int.Parse(txtYear2.Text);
        var intDays = decimal.Parse(DateTime.DaysInMonth(intYear, intMonth).ToString());
        var decNoOfWeeks = (intDays - GetDatebasedOnSystemParameters2().Day) / 7;
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
            var li = new RadComboBoxItem { Text = i.ToString(), Value = i.ToString() };
            ddlWeek2.Items.Add(li);
            i++;
        }

        SetFromAndToDate2(GetDatebasedOnSystemParameters2());
        //weekStartDate2.Value = txtFromDate.Text;
        // weekEndDate2.Value = txtToDate.Text;
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
            // txtFromDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
            dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
            txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
            //  weekStartDate2.Value = txtFromDate.Text;
            // weekEndDate2.Value = txtToDate.Text;
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
            var objRoster = new BL.Roster();
            var strSelectedMonthStartDate = ("1-" + GetMonthName(int.Parse(ddlMonth2.SelectedValue)) + "-" + txtYear2.Text);
            var dt = objRoster.SystemParametersGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strSelectedMonthStartDate, "Weekly".Trim().ToLower());
            var dtSelectedMonthFirstDate = new DateTime(int.Parse(txtYear2.Text), int.Parse(ddlMonth2.SelectedValue), 1);

            if (dt != null && dt.Rows.Count > 0)
            {
                //ViewState["ScheduleWeeklyFromDay"] = dt.Rows[0]["ScheduleWeeklyFromDay"].ToString();
                var strScheduleWeeklyStartDay = dt.Rows[0]["ScheduleWeeklyStartDay"].ToString();

                //// while condition modified by Manish. new CultureInfo("en-US") is used to compare  
                while (dtSelectedMonthFirstDate.ToString("dddd", new CultureInfo("en-US")).ToUpper() != strScheduleWeeklyStartDay.ToUpper())
                {
                    dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(1);
                }
                //dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays((int.Parse(ddlWeek.SelectedItem.Value.ToString()) - 1) * 7);
                //txtFromDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");
                //dtSelectedMonthFirstDate = dtSelectedMonthFirstDate.AddDays(6);
                //txtToDate.Text = dtSelectedMonthFirstDate.ToString("dd-MMM-yyyy");

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

    /// <summary>
    /// Fill AreaIncharge Dropdown on Location Basis
    /// </summary>
    private void FillddlAreaInchargeDetails()
    {
        var employeeNumber = String.Empty;

        if (BaseUserIsAreaIncharge == "0" && BaseUserID != "system")
        {
            employeeNumber = BaseUserEmployeeNumber;
        }
        var objHRManagement = new BL.HRManagement();


        // ds = objHRManagement.AreaInchargeGet(BaseCompanyCode, EmployeeNumber);
        // Added By Kamal 15-Nov-2012 
        //if (ddlReportTypeMain.SelectedValue == "YLMAttendance")
        //{

        ddlAreaInchargeCode.Items.Clear();
        ddlAreaInchargeName.Items.Clear();

        var Ds = objHRManagement.AreaInchargeGetBasedonUserID(ddlBranch.SelectedValue != string.Empty ? ddlBranch.SelectedItem.Value : BaseLocationAutoID, employeeNumber, BaseUserID);


        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaInchargeCode.DataSource = Ds.Tables[0];
            ddlAreaInchargeCode.DataTextField = "EmployeeCode";
            ddlAreaInchargeCode.DataValueField = "EmployeeCode";
            ddlAreaInchargeCode.DataBind();

            ddlAreaInchargeName.DataSource = Ds.Tables[0];
            ddlAreaInchargeName.DataTextField = "Employee";
            ddlAreaInchargeName.DataValueField = "EmployeeCode";
            ddlAreaInchargeName.DataBind();

            var LI2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
            ddlAreaInchargeCode.Items.Insert(0, LI2);

            LI2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
            ddlAreaInchargeName.Items.Insert(0, LI2);

        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAreaInchargeCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAreaInchargeName.Items.Insert(0, li1);
        }
        //if (BaseUserID == "system" || BaseUserIsAreaIncharge == "0")
        //{
        //    var LI2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
        //    ddlAreaInchargeCode.Items.Insert(0, LI2);

        //    LI2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
        //    ddlAreaInchargeName.Items.Insert(0, LI2);
        //}

        FillDDlAreaID();
    }




    /// <summary>
    /// Fill AreaId Dropdown on AreaIncharge Basis
    /// </summary>
    private void FillDDlAreaID()
    {
        DDLAreaID.Items.Clear();
        ddlAreaName.Items.Clear();


        var ObjOPS = new BL.OperationManagement();

        DataSet Ds = ObjOPS.AreaIdGet(ddlBranch.SelectedValue != string.Empty ? ddlBranch.SelectedItem.Value : BaseLocationAutoID, ddlAreaInchargeCode.SelectedValue);

        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DDLAreaID.DataSource = Ds;
            DDLAreaID.DataTextField = "AreaID";
            DDLAreaID.DataValueField = "AreaID";
            DDLAreaID.DataBind();

            ddlAreaName.DataSource = Ds;
            ddlAreaName.DataTextField = "AreaDesc";
            ddlAreaName.DataValueField = "AreaID";
            ddlAreaName.DataBind();

            var li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            DDLAreaID.Items.Insert(0, li);

            li = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
            ddlAreaName.Items.Insert(0, li);




        }
        else
        {
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            DDLAreaID.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAreaName.Items.Insert(0, li1);
        }

        FillddlClient(); //Code Added By Ajay Datta On 01-Nov-2012 To refill Client for Training Report
        FillDDLClientPost();
        FillddlAsmtPost();
        FillddlEmployeeNumber();


    }

    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    protected void FillddlEmployeeNumber()
    {
        ddlEmployeeNumber.Items.Clear();
        ddlEmployeeName.Items.Clear();
        var ObjHRManagement = new HRManagement();

        if (ddlDivision.SelectedValue == @"ALL")
        {
            var liEmp = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlEmployeeNumber.Items.Insert(0, liEmp);

            liEmp = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlEmployeeName.Items.Insert(0, liEmp);
        }
        else
        {
            DataSet Ds;
            if (ddlReportTypeMain.SelectedValue == "Constraint")
            {

                Ds = ObjHRManagement.EmployeesOfLocationAreaWiseGetForTraining(BaseCompanyCode,
                    ddlDivision.SelectedValue, ddlBranch.SelectedItem.Text, DateTime.Now.ToString("dd-MMM-yyyy"),
                    DateTime.Now.ToString("dd-MMM-yyyy"),
                    DDLAreaID.SelectedValue, ddlAreaInchargeCode.SelectedValue, BaseUserIsAreaIncharge);

                if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                {
                    ddlEmployeeNumber.DataSource = Ds.Tables[0];
                    ddlEmployeeNumber.DataTextField = "EmployeeNumber";
                    ddlEmployeeNumber.DataValueField = "EmployeeNumber";
                    ddlEmployeeNumber.DataBind();

                    ddlEmployeeName.DataSource = Ds.Tables[0];
                    ddlEmployeeName.DataTextField = "EmployeeName";
                    ddlEmployeeName.DataValueField = "EmployeeNumber";
                    ddlEmployeeName.DataBind();

                    var LI2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
                    ddlEmployeeNumber.Items.Insert(0, LI2);

                    LI2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
                    ddlEmployeeName.Items.Insert(0, LI2);

                    FillAllConstraint();
                    FillAllIdType();
                    FillAllLanguage();
                    FillAllQualification();
                    FillAllSkill();
                    FillAllTrainings();
                }
                else
                {
                    var LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                    ddlEmployeeNumber.Items.Insert(0, LI2);


                    LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                    ddlEmployeeName.Items.Insert(0, LI2);

                    DdlConstraint.Items.Clear();
                    LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                    DdlConstraint.Items.Insert(0, LI2);

                    DdlIdType.Items.Clear();
                    LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                    DdlIdType.Items.Insert(0, LI2);

                    DdlLanguage.Items.Clear();
                    LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                    DdlLanguage.Items.Insert(0, LI2);

                    DdlQual.Items.Clear();
                    LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                    DdlQual.Items.Insert(0, LI2);

                    DdlSkill.Items.Clear();
                    LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                    DdlSkill.Items.Insert(0, LI2);

                    if (ddlReportName.SelectedValue == @"EmployeeConstraint")
                    {
                        ddlTraining.Items.Clear();
                        LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = string.Empty };
                        ddlTraining.Items.Insert(0, LI2);
                    }
                }
            }
            else
            {

                try
                {
                    Ds = ObjHRManagement.EmployeesOfLocationAreaWiseGetForTraining(BaseCompanyCode,
                        ddlDivision.SelectedValue, ddlBranch.SelectedItem.Text, txtFromDate.Text, txtToDate.Text,
                        DDLAreaID.SelectedValue, ddlAreaInchargeCode.SelectedValue, BaseUserIsAreaIncharge);


                    if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
                    {
                        ddlEmployeeNumber.DataSource = Ds.Tables[0];
                        ddlEmployeeNumber.DataTextField = "EmployeeNumber";
                        ddlEmployeeNumber.DataValueField = "EmployeeNumber";
                        ddlEmployeeNumber.DataBind();

                        ddlEmployeeName.DataSource = Ds.Tables[0];
                        ddlEmployeeName.DataTextField = "EmployeeName";
                        ddlEmployeeName.DataValueField = "EmployeeNumber";
                        ddlEmployeeName.DataBind();

                        var li2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
                        ddlEmployeeNumber.Items.Insert(0, li2);

                        li2 = new RadComboBoxItem { Text = Resources.Resource.SelectAll, Value = @"ALL" };
                        ddlEmployeeName.Items.Insert(0, li2);
                    }
                    else
                    {
                        var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
                        ddlEmployeeNumber.Items.Insert(0, li1);

                        li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
                        ddlEmployeeName.Items.Insert(0, li1);
                    }
                }
                catch (Exception) { }
            }
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        ddlClientCode.Items.Clear();
        ddlClientName.Items.Clear();
        var objSales = new BL.Sales();
        DataSet ds;
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSales.ClientGet(BaseLocationAutoID, BaseUserID);

        }
        else
        {
            // Added on 15-Nov-2012 By Kamal
            //if (ddlReportTypeMain.SelectedValue.ToString() == "YLMAttendance")
            if (ddlReportName.SelectedItem.Value == @"YLMAttendance")
            {
                ddlClientCode.Items.Clear();
                ddlClientName.Items.Clear();
                ds = objSales.ClientAreaWiseGet(ddlBranch.SelectedItem.Value, ddlAreaInchargeCode.SelectedItem.Value, DDLAreaID.SelectedItem.Value);
            }
            if (ddlReportName.SelectedItem.Value == @"SaleOrderDetail_Isreal.rpt")
            {
                ddlClientCode.Items.Clear();
                ddlClientName.Items.Clear();
                ds = objSales.ClientListARegisterGet(ddlBranch.SelectedValue, chkCentralize.Checked == true ? false : true);
            }
            else
            {
                ds = objSales.ClientAreaWiseGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value, DDLAreaID.SelectedItem.Value);
            }
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();

            ddlClientName.DataSource = ds.Tables[0];
            ddlClientName.DataTextField = "ClientName";
            ddlClientName.DataValueField = "ClientCode";
            ddlClientName.DataBind();

            var li1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlClientCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlClientName.Items.Insert(0, li1);

            FillddlAsmt();
        }
        else
        {
            ddlAsmtCode.Items.Clear();
            ddlAsmtName.Items.Clear();
            var li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlClientCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlClientName.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAsmtName.Items.Insert(0, li1);

            li1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            ddlAsmtCode.Items.Insert(0, li1);
        }

    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();
        ddlAsmtName.Items.Clear();
        DDLPost.Items.Clear();
        DdlPostCode.Items.Clear();

        if (chkCentralize.Checked)
        {
            var LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmtCode.Items.Insert(0, LI1);

            LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmtName.Items.Insert(0, LI1);

            LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            DDLPost.Items.Insert(0, LI1);

            LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            DdlPostCode.Items.Insert(0, LI1);
            return;

        }

        if (ddlClientCode.SelectedItem.Value == @"ALL")
        {
            var LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmtCode.Items.Insert(0, LI1);

            LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAsmtName.Items.Insert(0, LI1);

            LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            DDLPost.Items.Insert(0, LI1);

            LI1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            DdlPostCode.Items.Insert(0, LI1);
        }
        else
        {
            string strClientCode = ddlClientCode.SelectedValue;
            var dsAsmt = new DataSet();
            var objOperationManagement = new BL.OperationManagement();

            if (ddlReportName.SelectedValue == "DailyPostingSheet.rpt")
            {
                strClientCode = "ALL";
                txtFromDate.Text = txtAsOnDate.Text;
                txtToDate.Text = txtAsOnDate.Text;
            }
            //dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
            //dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString());

            if (ddlReportName.SelectedItem.Value == "YLMAttendance")
            {
                dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(ddlBranch.SelectedItem.Value), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value, DDLAreaID.SelectedItem.Value);
            }
            else
            {
                dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value, DDLAreaID.SelectedItem.Value);
            }

            if (dsAsmt != null && dsAsmt.Tables.Count > 0 && dsAsmt.Tables[0].Rows.Count > 0)
            {
                ddlAsmtCode.DataSource = dsAsmt.Tables[0];
                ddlAsmtCode.DataTextField = "AsmtCode";
                ddlAsmtCode.DataValueField = "AsmtCode";
                ddlAsmtCode.DataBind();

                ddlAsmtName.DataSource = dsAsmt.Tables[0];
                ddlAsmtName.DataTextField = "AsmtAddress";
                ddlAsmtName.DataValueField = "AsmtCode";
                ddlAsmtName.DataBind();

                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.All;
                li1.Value = @"ALL";
                ddlAsmtCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem { Text = Resources.Resource.All, Value = "ALL" };
                ddlAsmtName.Items.Insert(0, li1);
            }
            else
            {
                var LI1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = "-1" };
                ddlAsmtCode.Items.Insert(0, LI1);

                LI1 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = "-1" };
                ddlAsmtName.Items.Insert(0, LI1);
            }
            FillDDLPost();
        }





    }
    /// <summary>
    /// Fills the DDL client post.
    /// </summary>
    private void FillDDLClientPost()
    {
        string strAreaId;
        if (DDLAreaID.SelectedValue == "ALL")
        {
            strAreaId = "";
        }
        else
        {
            strAreaId = DDLAreaID.SelectedValue;
        }
        DDLClientDetail.Items.Clear();

        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        ds = objSales.ClientAreaWiseGet(BaseLocationAutoID, strAreaId);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLClientDetail.DataSource = ds;
            DDLClientDetail.DataTextField = "ClientNameCode";
            DDLClientDetail.DataValueField = "ClientCode";
            DDLClientDetail.DataBind();

            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            DDLClientDetail.Items.Insert(0, li1);
            DDLClientDetail.SelectedIndex = 0;
        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            DDLClientDetail.Items.Insert(0, li1);
        }
        FillddlAsmtPost();
    }
    /// <summary>
    /// Fillddls the asmt post.
    /// </summary>
    private void FillddlAsmtPost()
    {
        string strClientCode;
        if (DDLClientDetail.SelectedValue == "ALL")
        {
            strClientCode = "";
        }
        else
        {
            strClientCode = DDLClientDetail.SelectedValue;
        }
        string strAreaId;
        if (DDLAreaID.SelectedValue == "ALL")
        {
            strAreaId = "";
        }
        else
        {
            strAreaId = DDLAreaID.SelectedValue;
        }
        var objOperationManagement = new BL.OperationManagement();
        DDLAsmtID.Items.Clear();
        var DsAsmt = objOperationManagement.AssignmentGet(BaseLocationAutoID, strClientCode, strAreaId);
        if (DsAsmt != null && DsAsmt.Tables.Count > 0 && DsAsmt.Tables[0].Rows.Count > 0)
        {
            DDLAsmtID.DataSource = DsAsmt.Tables[0];
            DDLAsmtID.DataTextField = "AsmtNameCode";
            DDLAsmtID.DataValueField = "AsmtCode";
            DDLAsmtID.DataBind();

            var li = new ListItem { Text = Resources.Resource.All, Value = "ALL" };
            DDLAsmtID.Items.Insert(0, li);
            DDLAsmtID.SelectedIndex = 0;
        }
        else
        {
            var li = new ListItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            DDLAsmtID.Items.Insert(0, li);
            DDLAsmtID.SelectedIndex = 0;

        }
        FillDDlShift();
    }

    /// <summary>
    /// Fills the d dl shift.
    /// </summary>
    private void FillDDlShift()
    {
        ddlShift.Items.Clear();
        var objOPS = new BL.OperationManagement();
        var ds = new DataSet();
        try
        {

            //ds = objOPS.blShift_Get(DDLAsmtID.SelectedValue, BaseLocationAutoID);
            ds = objOPS.ShiftOnAsmtOfClientGet(BaseLocationAutoID, DDLClientDetail.SelectedValue,
                DDLAsmtID.SelectedValue);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlShift.DataSource = ds;
                ddlShift.DataTextField = "Shift";
                ddlShift.DataValueField = "Shift";
                ddlShift.DataBind();
            }
            var li2 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlShift.Items.Insert(0, li2);

            var li3 = new RadComboBoxItem { Text = @"0", Value = @"0" };
            ddlShift.Items.Insert(1, li3);
            ddlShift.SelectedIndex = 0;
        }
        catch (Exception)
        {
            lblErrorMsg.Text = string.Empty;
        }


    }
    /// <summary>
    /// Fills the DDL shift code.
    /// </summary>
    private void FillDDLShiftCode()
    {
        DDLShiftCode.Items.Clear();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.StandardSiftsGetAll(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLShiftCode.DataSource = ds.Tables[0];
            DDLShiftCode.DataTextField = "ShiftCode";
            DDLShiftCode.DataValueField = "ShiftCode";

            DDLShiftCode.DataBind();
        }
        var li2 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
        DDLShiftCode.Items.Insert(0, li2);

        var li3 = new RadComboBoxItem { Text = @"0", Value = @"0" };
        DDLShiftCode.Items.Insert(1, li3);
    }

    /// <summary>
    /// Fills the DDL post.
    /// </summary>
    private void FillDDLPost()
    {
        DdlPostCode.Items.Clear();
        DDLPost.Items.Clear();
        var ObjMasterManagement = new BL.MastersManagement();

        var Ds = ObjMasterManagement.AsmtPostGet(BaseLocationAutoID, ddlAreaInchargeCode.SelectedItem.Value, DDLAreaID.SelectedItem.Value, ddlClientCode.SelectedItem.Value, ddlAsmtCode.SelectedItem.Value);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DdlPostCode.DataSource = Ds.Tables[0];
            DdlPostCode.DataTextField = "Site";
            DdlPostCode.DataValueField = "Site";
            DdlPostCode.DataBind();

            DDLPost.DataSource = Ds.Tables[0];
            DDLPost.DataTextField = "SiteDesc";
            DDLPost.DataValueField = "Site";
            DDLPost.DataBind();

            var LI2 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            DdlPostCode.Items.Insert(0, LI2);

            LI2 = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
            DDLPost.Items.Insert(0, LI2);

        }
        else
        {
            var LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            DdlPostCode.Items.Insert(0, LI2);

            LI2 = new RadComboBoxItem { Text = Resources.Resource.NoDataToShow, Value = @"-1" };
            DDLPost.Items.Insert(0, LI2);

        }

    }
    /// <summary>
    /// Fills the shift time from to.
    /// </summary>
    private void FillShiftTimeFromTo()
    {

        //BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        //DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        //ds = objMasterManagement.StandardSiftsGet(BaseLocationAutoID, DDLShiftCode.SelectedValue.ToString());

        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    dt = ds.Tables[0];
        //    TxtTimeFrom.Text = dt.Rows[0]["TimeFrom"].ToString();
        //    TxtTimeTo.Text = dt.Rows[0]["TimeTo"].ToString();
        //}

    }

    /// <summary>
    /// Function used to fill Training Drop Down List.
    /// </summary>
    private void FillAllTrainings()
    {
        ddlTraining.Items.Clear();

        var ObjMastersManagement = new MastersManagement();
        var Ds = ObjMastersManagement.TrainingMasterGetAll(BaseCompanyCode);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            ddlTraining.DataSource = Ds.Tables[0];
            ddlTraining.DataValueField = "TrainingCode";
            ddlTraining.DataTextField = "TrainingDesc";
            ddlTraining.DataBind();
        }

        var LI = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
        ddlTraining.Items.Insert(0, LI);

    }


    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllQualification()
    {
        var ObjMastersManagement = new MastersManagement();
        var Ds = ObjMastersManagement.QualificationMasterGetAll();
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DdlQual.DataSource = Ds.Tables[0];
            DdlQual.DataValueField = "QualificationCode";
            DdlQual.DataTextField = "QualificationDesc";
            DdlQual.DataBind();
        }
        var LI = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
        DdlQual.Items.Insert(0, LI);

    }

    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllLanguage()
    {
        var ObjMastersManagement = new MastersManagement();
        var Ds = ObjMastersManagement.LanguageMasterGetAll();
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DdlLanguage.DataSource = Ds.Tables[0];
            DdlLanguage.DataValueField = "LanguageCode";
            DdlLanguage.DataTextField = "LanguageDesc";
            DdlLanguage.DataBind();
        }
        var LI = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
        DdlLanguage.Items.Insert(0, LI);

    }

    /// <summary>
    /// Function used to fill Qualification Drop Down List.
    /// </summary>
    private void FillAllIdType()
    {
        var ObjMastersManagement = new MastersManagement();
        var Ds = ObjMastersManagement.IdTypeGetAll();
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DdlIdType.DataSource = Ds.Tables[0];
            DdlIdType.DataValueField = "IDTypeCode";
            DdlIdType.DataTextField = "IDTypeDesc";
            DdlIdType.DataBind();
        }
        var LI = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
        DdlIdType.Items.Insert(0, LI);

    }

    /// <summary>
    /// Function used to fill Skill Drop Down List.
    /// </summary>
    private void FillAllSkill()
    {
        var ObjMastersManagement = new HRManagement();
        var Ds = ObjMastersManagement.SkillTypeMasterGet(BaseCompanyCode);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DdlSkill.DataSource = Ds;
            DdlSkill.DataTextField = "ItemDesc";
            DdlSkill.DataValueField = "ItemCode";
            DdlSkill.DataBind();

        }
        var LI = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"ALL" };
        DdlSkill.Items.Insert(0, LI);

    }

    /// <summary>
    /// Function used to fill Skill Drop Down List.
    /// </summary>
    private void FillAllConstraint()
    {
        DdlConstraint.Items.Clear();

        var ObjMastersManagement = new MastersManagement();
        DataSet Ds = ObjMastersManagement.ConstraintGetAll(BaseCompanyCode, null, Page.ID);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DdlConstraint.DataSource = Ds.Tables[0];
            DdlConstraint.DataTextField = "ConstraintDesc";
            DdlConstraint.DataValueField = "ConstraintCode";
            DdlConstraint.DataBind();
        }


        var LI = new RadComboBoxItem { Text = Resources.Resource.All, Value = @"All" };
        DdlConstraint.Items.Insert(0, LI);

    }
    #endregion

    #region Controles Events

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtName.SelectedValue = ddlAsmtCode.SelectedValue;
        FillDDLPost();

    }
    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtName_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAsmtCode.SelectedValue = ddlAsmtName.SelectedValue;
        FillDDLPost();

    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the DdlPostCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DdlPostCode_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {

        DDLPost.SelectedValue = DdlPostCode.SelectedValue;
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the DDlPost control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DDlPost_OnSelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {

        DdlPostCode.SelectedValue = DDLPost.SelectedValue;
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientName.SelectedValue = ddlClientCode.SelectedValue;
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlClientName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlClientCode.SelectedValue = ddlClientName.SelectedValue;
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
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DDLAreaID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaName.SelectedValue = DDLAreaID.SelectedValue;
        FillddlClient();
        FillDDLClientPost();
        FillDDlShift();
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        DDLAreaID.SelectedValue = ddlAreaName.SelectedValue;
        FillddlClient();
        FillDDLClientPost();
        FillDDlShift();
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployeeNumber control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeNumber_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeName.SelectedValue = ddlEmployeeNumber.SelectedValue;
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlEmployeeName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlEmployeeName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlEmployeeNumber.SelectedValue = ddlEmployeeName.SelectedValue;
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
            // DateFormat(txtFromDate.Text);
            if (ddlReportName.SelectedItem.Value == "WeeklyPostingSheet.rpt"
                || ddlReportName.SelectedItem.Value == "Weeklyscheduleroster.rpt"
                || ddlReportName.SelectedItem.Value == "EmployeeWiseHoursReport"
                || ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyActualReport
                || ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyScheduleReport
               )
            {
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
            }
            else
            {
                txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
            }
            FillddlAsmt();
        }
        else
        {
            btnViewReport.Enabled = false;
            return;
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtToDate, lblErrorMsg))
        {
            btnViewReport.Enabled = true;
            //DateFormat(txtToDate.Text);
            FillddlAsmt();
        }
        else
        {
            btnViewReport.Enabled = false;
            return;
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlReportName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ShowHideReportParameterControles();
        FillParametersBasedOnReportName();
        if (ddlReportName.SelectedValue == @"CustomerConstraint")
        {
            FillAllTrainings();
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReportTypeMain control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlReportTypeMain_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        FillddlReportName();
        ShowHideReportParameterControles();
        FillParametersBasedOnReportName();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlDivisionName.SelectedValue = ddlDivision.SelectedValue;
        FillBranch();
        FillddlAreaInchargeDetails();
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
        FillddlAreaInchargeDetails();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranchName.SelectedValue = ddlBranch.SelectedValue;

        // Added By Kamal 15-Nov-2012 
        FillddlAreaInchargeDetails();
        FillddlClient();
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeName.SelectedValue = ddlAreaInchargeCode.SelectedValue;
        FillDDlAreaID();
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaInchargeName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAreaInchargeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAreaInchargeCode.SelectedValue = ddlAreaInchargeName.SelectedValue;
        FillDDlAreaID();
        FillddlEmployeeNumber();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranchName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranchName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranch.SelectedValue = ddlBranchName.SelectedValue;
        // Added By Kamal 15-Nov-2012 
        FillddlAreaInchargeDetails();
        FillddlClient();
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLShiftCode control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DDLShiftCode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
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
        //DateFormat(txtAsOnDate.Text.ToString());
    }

    /// <summary>
    /// Handles the SelectedIndexchanged event of the GetFirstDayOfWeek control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void GetFirstDayOfWeek_SelectedIndexchanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        GetFirstDayOfWeek(2010, 43, System.Globalization.CultureInfo.CurrentCulture);
        ShowHideReportParameterControles();

    }
    /// <summary>
    /// Gets the first day of week.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="weekNumber">The week number.</param>
    /// <param name="culture">The culture.</param>
    /// <returns>DateTime.</returns>
    protected DateTime GetFirstDayOfWeek(int year, int weekNumber,
        System.Globalization.CultureInfo culture)
    {
        System.Globalization.Calendar calendar = culture.Calendar;
        DateTime firstOfYear = new DateTime(year, 1, 1, calendar);
        DateTime targetDay = calendar.AddWeeks(firstOfYear, weekNumber);
        DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;

        while (targetDay.DayOfWeek != firstDayOfWeek)
        {
            targetDay = targetDay.AddDays(-1);
        }

        return targetDay;

    }



    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value;
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
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                PanelAsmt.Visible = true;
                break;

            case "Postingsheet.rpt":
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelShift.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelSource.Visible = true;
                break;

            case "WeeklyPostingSheet.rpt":
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelShift.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
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
                //PanelAsOnDate.Visible = true;
                //PanelLAType.Visible = true;
                //PanelShiftCode.Visible = true;
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

            case "rpt_ActualSchedule_AsmtWise.rpt":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelReportGrid.Visible = true;
                break;

            case "rpt_ActualSchedule_AsmtWiseNew.rpt":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelReportGrid.Visible = true;
                PanelRosterOrSchedule.Visible = true;
                break;

            case "EmployeeWiseHoursReport":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                StartEndDayoftheWeek();
                //txtToDate.Enabled = false;

                break;

            case "UnscheduledEmployees":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                //PanelEmployee.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelRosterOrSchedule.Visible = true;
                //pnlEmpGrouping.Visible = true;
                break;

            case "dailyRefresherTrainingDue.rpt":
                //PanelDivision.Visible = true;
                //PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                ForNextNDays.Visible = true;
                break;

            case "dateRangeRefresherTrainingDue.rpt":
                //PanelDivision.Visible = true;
                //PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                break;

            case "dateRangeRefresherTrainingSchedule.rpt":
                //PanelDivision.Visible = true;
                //PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                break;
            case "ExceptionsActualVsTeken.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelDates.Visible = true;
                break;

            case "rpt_WeeklySchedule_EmpWise.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelRosterOrSchedule.Visible = true;
                pnlEmpGrouping.Visible = true;
                break;

            //Manish 23/04/2013 NON Occupied Report 
            case "NonOccupied.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                pnlNonOccupied.Visible = true;

                break;


            //Manish 10/07/2012
            case "YLMAttendance":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelAttendanceType.Visible = true;
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                // PanelReportGrid.Visible = true;
                break;

            case "YLMAttendanceOnline":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelAttendanceType.Visible = false;
                // PanelReportGrid.Visible = true;
                break;


            case "YLMAttendanceNoshow":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelAttendanceType.Visible = false;
                // PanelReportGrid.Visible = true;
                break;
            //Manish 10-Jan-2013
            case "YLMAttendanceVacant":
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelDates.Visible = true;
                PanelAttendanceType.Visible = false;
                // PanelReportGrid.Visible = true;
                break;

            // 14-mar-14
            case "YLMContactDetails":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelPost.Visible = true;
                break;

            case "WeeklyRest":
                PanelBranch.Visible = true;
                PanelAreaID.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelEmployee.Visible = true;
                Panelrest.Visible = true;

                PanelDivision.Visible = true;
                PanelWeek.Visible = true;
                break;
            //PanelDates.Visible = true;

            case "BarredEmployees":
                PanelBranch.Visible = true;
                PanelAreaID.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelEmployee.Visible = true;
                PanelDivision.Visible = true;
                break;


            //#region For From Date
            //ViewState["MonthChangeStatus"] = 0;
            //txtYear1.Text = DateTime.Now.Year.ToString();
            //ddlMonth1.SelectedValue = DateTime.Now.Month.ToString();
            //SetFromAndToDate(GetDatebasedOnSystemParameters());
            //GetDatebasedOnSystemParameters();
            //txtYear1.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            //txtYear1.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            //#endregion
            //#region For From Date
            //ViewState["MonthChangeStatus2"] = 0;
            //txtYear2.Text = DateTime.Now.Year.ToString();
            //ddlMonth2.SelectedValue = DateTime.Now.Month.ToString();
            //SetFromAndToDate2(GetDatebasedOnSystemParameters2());
            //GetDatebasedOnSystemParameters2();
            //txtYear2.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            //txtYear2.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            //#endregion
            //break;

            // Added New Report Case for Isreal SaleOrder by  on 18-Feb-2014
            case "SaleOrderDetail_Isreal.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PnlCentralized.Visible = true;

                if (BaseUserIsAreaIncharge.ToString() == "1")
                {
                    chkCentralize.Enabled = false;
                    chkCentralize.Checked = false;
                }

                //PanelShift.Visible = true;
                //PanelReportGrid.Visible = true;
                break;
            case "EmployeeConstraint":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelEmployee.Visible = true;
                PnlConstraint.Visible = true;
                PnlIdType.Visible = true;
                PnlLang.Visible = true;
                PnlQual.Visible = true;
                PnlSkill.Visible = true;
                pnlTraining.Visible = true;
                break;

            case "CustomerConstraint":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelPost.Visible = true;
                PnlIsMandatory.Visible = true;
                pnlTraining.Visible = true;
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
        PanelShift.Visible = false;
        PanelAreaID.Visible = false;
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
        PanelMonth.Visible = false;
        ForNextNDays.Visible = false;
        PanelRosterOrSchedule.Visible = false;
        PanelReportGrid.Visible = false;
        PanelAttendanceType.Visible = false;
        pnlEmpGrouping.Visible = false;
        pnlNonOccupied.Visible = false;
        Panelrest.Visible = false;
        PanelWeek.Visible = false;
        PnlConstraint.Visible = false;
        PnlIdType.Visible = false;
        PnlLang.Visible = false;
        PnlQual.Visible = false;
        PnlSkill.Visible = false;
        pnlTraining.Visible = false;
        PnlCentralized.Visible = false;
        PnlIsMandatory.Visible = false;
        //PanelStartweek.Visible = false;
        //PanelEndWeekNo.Visible = false;
    }

    //Manish 23/04/2013 Non Occupied report 
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


    //End Manish 23/04/2013 Non Occupied report 
    #endregion

    #region Function Button event
    /// <summary>
    /// Function used to handle button View Report Click event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        string strReportGridExport = ddlReportGrid.SelectedItem.Value;
        string strReportName = ddlReportName.SelectedItem.Value;
        if (strReportName == "rpt_ActualSchedule_AsmtWise.rpt1" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt2" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt3" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt4")
        {
            strReportName = "rpt_ActualSchedule_AsmtWise.rpt";
        }

        //Manish 27-11-2012 to Handel grouping on Employee Number if Checkbox is true esle we have to show report with out grouping 
        //Created 2 Report, One with grouping and another with out grouping.If check box is true then groupwise report else with out group. 
        if (chkEmpGroping.Checked == true && ddlReportName.SelectedItem.Value == "rpt_WeeklySchedule_EmpWise.rpt")
        {

            strReportName = "rpt_WeeklySchedule_EmpWiseGroup.rpt";
        }


        if (ValidateControles(ddlReportName.SelectedItem.Value))
        {
            const string strReportPagePath = "../Reports/Rostering/";
            Context.Items.Add("cxtReportFileName", strReportName);
            Context.Items.Add("cxtReportGridExport", strReportGridExport);
            Hashtable hshRptParameters = new Hashtable();
            hshRptParameters = ReportParameter_Get(strReportName);

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Israel.aspx?ReportName=" + ddlReportName.SelectedValue;

            if (ddlReportName.SelectedItem.Value == "UnscheduledEmployees")
            {
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                Server.Transfer("../Transactions/UnscheduledEmployeesRpt.aspx");
            }

            if (ddlEmployeeNumber.SelectedValue != string.Empty)
            {

                if (ddlReportName.SelectedItem.Value == @"EmployeeConstraint")
                {
                    Context.Items.Remove("cxtHashParameters");
                    Session["cxtHashParameters"] = hshRptParameters;
                    Server.Transfer("../Transactions/ConstraintGridReport.aspx");
                }
            }
            else
            {
                return;
            }

            if (ddlClientCode.SelectedValue != @"-1" || ddlClientCode.SelectedValue != string.Empty)
            {
                if (ddlReportName.SelectedItem.Value == @"CustomerConstraint")
                {
                    Context.Items.Remove("cxtHashParameters");
                    Session["cxtHashParameters"] = hshRptParameters;
                    Server.Transfer("../Transactions/ConstraintGridReport.aspx");
                }
            }
            else
            {

                return;
            }
            if (ddlReportName.SelectedItem.Value == "EmployeeWiseHoursReport")
            {
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                Server.Transfer("../Transactions/EmployeeWiseHoursReport.aspx");
            }

            //Manish YLM Attendance Report
            if (ddlReportName.SelectedItem.Value == "YLMAttendance")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/YLMAttendanceReport.aspx");
            }


            //Manish YLM Attendance raw data  Report 18-10-2012
            if
                      (ddlReportName.SelectedItem.Value == "YLMAttendanceOnline")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/YLMRawDataRpt.aspx");
            }

            //Manish YLM Attendance No Show Data   Report 10-12-2012
            if
                      (ddlReportName.SelectedItem.Value == "YLMAttendanceNoshow")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/YLMAttendanceNoshow.aspx");
            }



            //Manish YLM Attendance Vacant   Report 10-JAN-2013
            if
                      (ddlReportName.SelectedItem.Value == "YLMAttendanceVacant")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/YLMAttendanceVacantPost.aspx");
            }

            // YLM Contact Details Report 14-march-2014
            if
                      (ddlReportName.SelectedItem.Value == "YLMContactDetails")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/YLMContactDetails.aspx");
            }
            //code ends 
            // Code ends
            // Comment  code to redirect On RPT now we redirecting to SaleOrderDetailISR.aspx page  
            if
              (ddlReportName.SelectedItem.Value == @"SaleOrderDetail_Isreal.rpt")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/SaleOrderDetailISR.aspx");
            }

            //For Grid View Reports
            if (
                (ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyScheduleReport
                || ddlReportName.SelectedItem.Text == Resources.Resource.MonthlyScheduleReport
                || ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyActualReport
                || ddlReportName.SelectedItem.Text == Resources.Resource.MonthlyActualReport
                || ddlReportName.SelectedItem.Value == "rpt_ActualSchedule_AsmtWiseNew.rpt"
                )
               && ddlReportGrid.SelectedItem.Value == "Grid"
              )
            {
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                if (ddlReportName.SelectedItem.Value == "rpt_ActualSchedule_AsmtWiseNew.rpt")
                {
                    Server.Transfer("../Transactions/AsmtWiseSchAct.aspx?ReportName=" + ddlOption.SelectedItem.Text);
                }
                else
                {
                    Server.Transfer("../Transactions/AsmtWiseSchAct.aspx?ReportName=" + ddlReportName.SelectedItem.Text);
                }
            }
            else if (ddlReportName.SelectedValue == "WeeklyRest")
            {
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/WeeklyRest.aspx?");
            }
            // Added by  on 11-march-2014 for New Barred Employees Report.
            else if (ddlReportName.SelectedValue == "BarredEmployees")
            {
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/BarredEmployees.aspx?");
            }

            else
            {
                Server.Transfer("../Reports/ViewReport1.aspx");
            }
        }

        // Added New Report Type for Isreal SaleOrder by  on 24-Feb-2014
        //if (ddlReportName.SelectedItem.Value == @"SaleOrderDetail_Isreal.rpt")
        //{
        //    const string strReportPagePath = @"../Reports/Sales/";
        //    Context.Items.Add("cxtReportFileName", strReportName);
        //    Context.Items.Add("cxtReportGridExport", strReportGridExport);
        //    var hshRptParameters = ReportParameter_Get(strReportName);

        //    Context.Items.Add("cxtHashParameters", hshRptParameters);
        //    Context.Items.Add("cxtReportID", "ReportID");
        //    Context.Items.Add("cxtReportPagePath", strReportPagePath);
        //    Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Israel.aspx?ReportName=" + ddlReportName.SelectedValue;
        //    Server.Transfer("../Reports/ViewReport1.aspx");
        //}


    }

    /// <summary>
    /// Fillgvs the weekly rest.
    /// </summary>
    protected void FillgvWeeklyRest()
    {

        BL.Roster Roster = new BL.Roster();
        DataSet dsRoster = new DataSet();
        //DataTable dsRoster = new DataTable();

        dsRoster = Roster.WeeklyRest(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text), ddlEmployeeNumber.SelectedValue, "2", DDLAreaID.SelectedValue, ddlAreaInchargeCode.SelectedValue, Restcombo.SelectedValue);

        if (dsRoster != null && dsRoster.Tables.Count > 0 && dsRoster.Tables[0].Rows.Count > 0)
        {
            RadGrid1.DataSource = dsRoster;
            RadGrid1.DataBind();
            RadGrid1.Visible = true;
        }
        else
        {
            RadGrid1.DataSource = null;
            RadGrid1.DataBind();
            RadGrid1.Visible = false;
            lblErrorMsg.Text = Resources.Resource.NoRecordFound;
        }

    }
    /// <summary>
    /// function used to set parameter list for reports based on report name.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {

        string strCulture = BaseLanguageCode;

        if (strReportName == "rpt_ActualSchedule_AsmtWise.rpt1" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt2" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt3" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt4")
        {
            strReportName = "rpt_ActualSchedule_AsmtWise.rpt";
        }

        //Manish 27-11-2012 to Handel grouping on Employee Number if Checkbox is true esle we have to show report with out grouping             

        //Created 2 Report, One with grouping and another with out grouping.If check box is true then groupwise report else with out group. 
        if (chkEmpGroping.Checked == true && ddlReportName.SelectedItem.Value == "rpt_WeeklySchedule_EmpWise.rpt")
        {

            strReportName = "rpt_WeeklySchedule_EmpWiseGroup.rpt";
        }
        Hashtable hshRptParameters = new Hashtable();
        switch (strReportName)
        {
            //case "schempwise.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.StartDate, DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
            //    hshRptParameters.Add(DL.Properties.Resources.EndDate, DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
            //    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
            //    return hshRptParameters;
            //case "schasmtwise.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Assigncode, ddlAsmtCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.StartDate, DL.Common.DateFormat(txtFromDate.Text.ToString(), ""));
            //    hshRptParameters.Add(DL.Properties.Resources.EndDate, DL.Common.DateFormat(txtToDate.Text.ToString(), ""));
            //    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
            //    return hshRptParameters;
            //case "Postingsheet.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.Client, DDLClientDetail.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.Assign, DDLAsmtID.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.Source, ddlRptType.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.Shift, ddlShift.SelectedValue);
            //    return hshRptParameters;
            //case "WeeklyPostingSheet.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.ClientCode, DDLClientDetail.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.AsmtCode, DDLAsmtID.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.Shift, ddlShift.SelectedValue);

            //    //if (Session["Country"].ToString().Trim().ToLower() == "Kuwait-AlMulla".Trim().ToLower() || Session["Country"].ToString().Trim().ToLower() == "Saudi".Trim().ToLower())
            //    if (Session["Country"].ToString().Trim().ToLower() == "Kuwait-AlMulla".Trim().ToLower())
            //    {
            //        hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
            //        Context.Items["cxtReportFileName"] = Session["Country"].ToString() + "_" + ddlReportName.SelectedItem.Value.ToString();
            //    }
            //    else
            //    {
            //        hshRptParameters.Add(DL.Properties.Resources.Country, Session["Country"].ToString());
            //    }
            //    return hshRptParameters;

            //case "Actualvsschedule.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.Assign, ddlAsmtCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ReportType, ddlReporttype.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    return hshRptParameters;
            //case "leaveconfliction.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Branch, ddlBranch.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.Division, ddlDivision.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    return hshRptParameters;
            //case "deploymentexception.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.nHrs, txtHours.Text);
            //    hshRptParameters.Add(DL.Properties.Resources.Option, ddlOption.SelectedValue.ToString());
            //    return hshRptParameters;
            //case "mismatch.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    return hshRptParameters;
            //case "siteroster.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            //    hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
            //    return hshRptParameters;
            //case "Personnelroster.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedValue.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
            //    return hshRptParameters;
            //case "availpersonnel_Greece.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

            //    //hshRptParameters.Add(DL.Properties.Resources.ShiftCode, DDLShiftCode.SelectedValue);
            //    //hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtAsOnDate.Text));
            //    //hshRptParameters.Add(DL.Properties.Resources.Option, DDLAType.SelectedValue);
            //    return hshRptParameters;
            //case "availpersonnel_Barbados.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.ShiftCode, DDLShiftCode.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.StartTime, TxtTimeFrom.Text);
            //    hshRptParameters.Add(DL.Properties.Resources.ToTime, TxtTimeTo.Text);
            //    hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.Option, DDLAType.SelectedValue);
            //    hshRptParameters.Add(DL.Properties.Resources.Condition, ddlOptionAvailPersonnel.SelectedItem.ToString());
            //    return hshRptParameters;
            //case "ManpowerDetails.rpt":
            //    hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
            //    hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
            //    hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
            //    hshRptParameters.Add(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
            //    hshRptParameters.Add(DL.Properties.Resources.DayStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayStartTime.Text)));
            //    hshRptParameters.Add(DL.Properties.Resources.DayEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayEndTime.Text)));
            //    hshRptParameters.Add(DL.Properties.Resources.NightStartTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightStartTime.Text)));
            //    hshRptParameters.Add(DL.Properties.Resources.NightEndTime, DL.Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightEndTime.Text)));
            //    return hshRptParameters;

            case "Weeklyscheduleroster.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Source, ddlRptType.SelectedValue);
                return hshRptParameters;

            case "DailyPostingSheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value);
                return hshRptParameters;

            case "rpt_ActualSchedule_AsmtWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                if (ddlReportGrid.SelectedItem.Value == "Grid")
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                }

                if (ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyScheduleReport
                    || ddlReportName.SelectedItem.Text == Resources.Resource.MonthlyScheduleReport)
                {
                    hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "SCH");
                }
                else if (ddlReportName.SelectedItem.Text == Resources.Resource.WeeklyActualReport
                        || ddlReportName.SelectedItem.Text == Resources.Resource.MonthlyActualReport)
                {
                    hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                }
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Option, strCulture);
                return hshRptParameters;
            case "rpt_ActualSchedule_AsmtWiseNew.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                if (ddlReportGrid.SelectedItem.Value == "Grid")
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                }

                hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, ddlRosterOrSchedule.SelectedItem.Value.Substring(0, 3));
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Option, strCulture);
                return hshRptParameters;

            case "dailyRefresherTrainingDue.rpt":

                //string areaID_dailyRefresherTrainingDue = DDLAreaID.SelectedItem.Value.ToString();
                //if (areaID_dailyRefresherTrainingDue == "All")
                //{
                //    areaID_dailyRefresherTrainingDue = areaID_dailyRefresherTrainingDue + "-" + BaseUserID;
                //}

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.nDays, int.Parse(txtForNextNDays.Text));

                //hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());

                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);

                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);

                return hshRptParameters;

            case "dateRangeRefresherTrainingDue.rpt":

                //string areaID_dateRangeRefresherTrainingDue = DDLAreaID.SelectedItem.Value.ToString();
                //if (areaID_dateRangeRefresherTrainingDue == "All")
                //{
                //    areaID_dateRangeRefresherTrainingDue = areaID_dateRangeRefresherTrainingDue + "-" + BaseUserID;
                //}

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_dateRangeRefresherTrainingDue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                return hshRptParameters;

            case "dateRangeRefresherTrainingSchedule.rpt":

                //string areaID_dateRangeRefresherTrainingSchedule = DDLAreaID.SelectedItem.Value.ToString();
                //if (areaID_dateRangeRefresherTrainingSchedule == "All")
                //{
                //    areaID_dateRangeRefresherTrainingSchedule = areaID_dateRangeRefresherTrainingSchedule + "-" + BaseUserID;
                //}

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_dateRangeRefresherTrainingSchedule.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);

                return hshRptParameters;

            case "rpt_WeeklySchedule_EmpWise.rpt":

                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.RosterOrSchedule, ddlRosterOrSchedule.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Option, strCulture);
                return hshRptParameters;

            //Manish to Handel grouping on Employee Number if Checkbox is true esle we have to show report with out grouping
            //Created 2 Report, One with grouping and another with out grouping.If check box is true then groupwise report else with out group. 
            case "rpt_WeeklySchedule_EmpWiseGroup.rpt":

                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.RosterOrSchedule, ddlRosterOrSchedule.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.Option, strCulture);
                return hshRptParameters;


            case "ExceptionsActualVsTeken.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;


            case "UnscheduledEmployees":

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(ddlBranch.SelectedItem.Value));
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.RosterOrSchedule, ddlRosterOrSchedule.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.IsAreaIncharge, BaseUserIsAreaIncharge);

                return hshRptParameters;


            case "EmployeeWiseHoursReport":

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch.SelectedValue != "" ? int.Parse(ddlBranch.SelectedValue) : 0);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.IsAreaIncharge, BaseUserIsAreaIncharge);

                return hshRptParameters;

            //Manish 23/04/2013 Non Occupied Shift

            case "NonOccupied.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                // hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(ddlBranch.SelectedItem.Value.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                //hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Text);

                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                hshRptParameters.Add(DL.Properties.Resources.Variation, ddlVariation.SelectedValue);
                return hshRptParameters;

            //End Manish 23/04/2013 Non Occupied Shift


            //Manish YLMAttendance

            case "YLMAttendance":

                string areaID_YLMAttendance = DDLAreaID.SelectedItem.Value;
                //Code Commented And Added By Ajay Datta On 10-May-2013
                //For Handling AreaID, AreaIncharge Selection
                //if (areaID_YLMAttendance == "All")
                //{
                //    areaID_YLMAttendance = areaID_YLMAttendance + "-" + BaseUserID;
                //}
                string areaIncharge_YLMAttendance = ddlAreaInchargeCode.SelectedItem.Value;
                areaID_YLMAttendance = areaID_YLMAttendance + "~" + BaseUserID + "~" + areaIncharge_YLMAttendance;

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                //hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(ddlBranch.SelectedItem.Value));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_YLMAttendance);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.AttendanceType, ddlAttendanceType.SelectedItem.Value);

                return hshRptParameters;



            case "YLMAttendanceOnline":

                string areaID_YLMAttendanceYLMRaw = DDLAreaID.SelectedItem.Value;
                if (areaID_YLMAttendanceYLMRaw == "All")
                {
                    areaID_YLMAttendanceYLMRaw = areaID_YLMAttendanceYLMRaw + "-" + BaseUserID;
                }

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_YLMAttendanceYLMRaw);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                // hshRptParameters.Add(DL.Properties.Resources.AttendanceType, ddlAttendanceType.SelectedItem.Value.ToString());

                return hshRptParameters;

            case "YLMContactDetails":


                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(ddlBranch.SelectedItem.Value));
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.PostCode, DDLPost.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);

                return hshRptParameters;

            case "YLMAttendanceNoshow":

                string areaID_YLMNoshow = DDLAreaID.SelectedItem.Value;
                if (areaID_YLMNoshow == "All")
                {
                    areaID_YLMNoshow = areaID_YLMNoshow + "-" + BaseUserID;
                }

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_YLMNoshow);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                // hshRptParameters.Add(DL.Properties.Resources.AttendanceType, ddlAttendanceType.SelectedItem.Value.ToString());

                return hshRptParameters;

            //Manish 10/jan/2012 Vacant Post

            case "YLMAttendanceVacant":

                string areaID_YLMVacant = DDLAreaID.SelectedItem.Value;
                if (areaID_YLMVacant == "All")
                {
                    areaID_YLMVacant = areaID_YLMVacant + "-" + BaseUserID;
                }

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_YLMVacant);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                // hshRptParameters.Add(DL.Properties.Resources.AttendanceType, ddlAttendanceType.SelectedItem.Value.ToString());

                return hshRptParameters;

            case "WeeklyRest":

                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch.SelectedValue);

                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.WeeklyRest, Restcombo.SelectedValue);
                return hshRptParameters;

            // Added New Report Type for Isreal SaleOrder by  on 24-Feb-2014
            case "SaleOrderDetail_Isreal.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(ddlBranch.SelectedItem.Value));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeName.SelectedItem.Value);
                hshRptParameters.Add(DL.Properties.Resources.CenterlizeBilling, chkCentralize.Checked);
                return hshRptParameters;
            //End

            //Added For new Report Barred Assignment by  on 11-Mar-2014
            case "BarredEmployees":

                hshRptParameters.Add(DL.Properties.Resources.FromDate, System.DateTime.Now);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, System.DateTime.Now);
                hshRptParameters.Add(DL.Properties.Resources.DivisionCode, ddlDivision.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Division, ddlDivisionName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.BranchCode, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.Branch, ddlBranchName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaDesc, ddlAreaName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNameCondition, ddlEmployeeName.SelectedValue);
                return hshRptParameters;

            case "EmployeeConstraint":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedValue);
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
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, ddlBranch.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AsmtId, DDLAsmtID.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.PostCode, DDLPost.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaName.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.ConstraintCode, DdlIsMandatory.SelectedValue);
                hshRptParameters.Add(DL.Properties.Resources.TrainingCode, ddlTraining.SelectedValue);
                return hshRptParameters;

            default: return hshRptParameters;
        }
    }

    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool validateFromToDate()
    {
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
    /// Implements  from date and to date according to system parameters
    /// </summary>
    /// <returns></returns>
    protected bool StartEndDayoftheWeek()
    {
        DataSet dsBool = new DataSet();
        BL.Roster obj = new BL.Roster();
        var locationAutoId = string.Empty;
        if (ddlBranch.SelectedValue == "")
        {
            locationAutoId = BaseLocationAutoID;
        }
        else
        {
            locationAutoId = ddlBranch.SelectedValue;
        }
        //exec udp_GetStartEndDayWeek_rpt @Locationautoid=N'6',@FromDate=N'04-01-2014 00:00',@ToDate=N'04-07-2014 00:00'
        dsBool = obj.GetStartEndDayWeek(locationAutoId, "01-01-1900 00:00", "01-01-1900 00:00");
        if (dsBool != null && dsBool.Tables.Count > 0)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime startOfCalendar = FirstDayOfWeek(firstDayOfMonth, dsBool.Tables[0].Rows[0].Field<String>("ParamValue1").Trim());
            txtFromDate.Text = startOfCalendar.ToString("dd-MMM-yyyy");
            txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
            var resorceValue1 = ResourceValueOfKey_Get(dsBool.Tables[0].Rows[0].Field<String>("ParamValue1"));
            var resorceValue2 = ResourceValueOfKey_Get(dsBool.Tables[0].Rows[0].Field<String>("ParamValue2"));

            lblObjectFrom.Text = @"(" + Resources.Resource.Select + @"  " + resorceValue1 + @")";
            lblObjectTo.Text = @"(" + Resources.Resource.Select + @"  " + resorceValue2 + @")";
            return false;
        }
        return false;
    }


    /// <summary>
    /// To calculate first month date accoeding to the week day
    /// </summary>
    /// <param name="date"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime FirstDayOfWeek(DateTime date, String dayOfWeek)
    {
        while (date.DayOfWeek.ToString() != dayOfWeek)
        {
            date = date.AddDays(+1);
        }
        return date;
    }

    /// <summary>
    /// Validates the start end date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    protected bool ValidateStartEndDate()
    {
        if (ddlBranch.SelectedItem != null)
        {
            if (txtToDate.Text != "" && txtFromDate.Text != "")
            {
                if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                {
                    DataSet dsBool = new DataSet();
                    BL.Roster obj = new BL.Roster();
                    dsBool = obj.GetStartEndDayWeek(ddlBranch.SelectedItem.Value, txtFromDate.Text, txtToDate.Text);
                    if (dsBool != null && dsBool.Tables.Count > 0)
                    {
                        if (Convert.ToInt32(dsBool.Tables[0].Rows[0].Field<int>("CountValue")) != 0)
                            return true;
                        else
                            lblErrorMsg.Text = Resources.Resource.StartEndDayMsg;
                        return false;

                    }
                    else
                        lblErrorMsg.Text = Resources.Resource.StartEndDayMsg;
                    return false;
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
        else
            return true;

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
                return validateFromToDate();
            case "schasmtwise.rpt":
                return validateFromToDate();
            case "Postingsheet.rpt":
                return true;
            case "WeeklyPostingSheet.rpt":
                return validateFromToDate();
            case "Actualvsschedule.rpt":
                return validateFromToDate();
            case "leaveconfliction.rpt":
                return validateFromToDate();
            case "mismatch.rpt":
                return validateFromToDate();
            case "deploymentexception.rpt":
                return validateFromToDate();
            case "siteroster.rpt":
                return validateFromToDate();
            case "Personnelroster.rpt":
                return validateFromToDate();
            case "availpersonnel_Barbados.rpt":
                return true;
            case "availpersonnel_Greece.rpt":
                return validateFromToDate();
            case "DailyPostingSheet.rpt":
                return validateFromToDate();
            case "Weeklyscheduleroster.rpt":
                return validateFromToDate();

            case "rpt_ActualSchedule_AsmtWise.rpt":
                return validateFromToDate();
            case "rpt_ActualSchedule_AsmtWiseNew.rpt":
                return validateFromToDate();

            case "dateRangeRefresherTrainingDue.rpt":
                return validateFromToDate();

            case "dateRangeRefresherTrainingSchedule.rpt":
                return validateFromToDate();

            case "dailyRefresherTrainingDue.rpt":
                if (txtFromDate.Text != "")
                {
                    if (txtForNextNDays.Text != "")
                    {
                        return true;
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.CannotBeLeftBlank;
                        return false;
                    }

                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }


            case "ManpowerDetails.rpt":
                if (txtAsOnDate.Text != "" && txtDayStartTime.Text != "" && txtDayEndTime.Text != "" && txtNightStartTime.Text != "" && txtNightEndTime.Text != "")
                {
                    return true;
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return false;
                }
            case "ExceptionsActualVsTeken.rpt":
                return validateFromToDate();
            case "rpt_WeeklySchedule_EmpWise.rpt":
                return validateFromToDate();
            case "EmployeeWiseHoursReport":

                return ValidateStartEndDate();
            case "UnscheduledEmployees":
                return validateFromToDate();
            //Manish 23/04/2013 Non Occupied Shift
            case "NonOccupied.rpt":
                return validateFromToDate();
            //End Manish 23/04/2013 Non Occupied Shift
            case "YLMAttendance":
                return validateFromToDate();
            // YlM Contact details report 14-mar-14
            case "YLMContactDetails":
                return validateFromToDate();
            // code ends
            case "YLMAttendanceOnline":
                return validateFromToDate();
            case "YLMAttendanceNoshow":
                return validateFromToDate();
            //Manish 10/jan/2013
            case "YLMAttendanceVacant":
                return validateFromToDate();
            case "WeeklyRest":
                return validateFromToDate();
            case "BarredEmployees":
                return validateFromToDate();
            case "SaleOrderDetail_Isreal.rpt":
                return true;
            case "EmployeeConstraint":
                return true;
            case "CustomerConstraint":
                return true;
            default:
                return false;
        }
    }
    #endregion

    /// <summary>
    /// To Disable the AreaIncharge, Area Name, Assignment Dropdown on Centralize Checked
    /// </summary>
    /// <param name="sender">CheckBox IsCentralized</param>
    /// <param name="e">Checked / Unchecked </param>
    protected void chkCentralize_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCentralize.Checked)
        {
            ddlAreaInchargeCode.SelectedValue = "@All";
            ddlAreaInchargeName.SelectedValue = @"All";
            DDLAreaID.SelectedValue = @"All";
            ddlAreaName.SelectedValue = @"All";
            ddlAsmtCode.SelectedValue = @"All";
            ddlAsmtName.SelectedValue = @"All";

            PanelAreaID.Enabled = false;
            PanelAreaIncharge.Enabled = false;
            PanelAsmt.Enabled = false;
            FillddlClient();
        }
        else
        {
            PanelAreaID.Enabled = true;
            PanelAreaIncharge.Enabled = true;
            PanelAsmt.Enabled = true;
        }
    }
}
