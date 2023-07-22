// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="RptGroup_Training.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telerik.Web.UI;

/// <summary>
/// Class RptGroup_Training
/// </summary>
public partial class RptGroup_Training : BasePage
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
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.Schedules + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                ImgFromDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtFromDate.ClientID.ToString() + "');";
                ImgToDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtToDate.ClientID.ToString() + "');";
                ImgAsOnDate.NavigateUrl = "javascript:calendarPicker('aspnetForm." + txtAsOnDate.ClientID.ToString() + "');";

                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");
                txtAsOnDate.Attributes.Add("readonly", "readonly");
                //ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientName.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");
                txtDayStartTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtDayStartTime.ClientID.ToString() + "');";
                txtDayStartTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtDayStartTime.ClientID.ToString() + "');";

                txtDayEndTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtDayEndTime.ClientID.ToString() + "');";
                txtDayEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtDayEndTime.ClientID.ToString() + "');";

                txtNightStartTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtNightStartTime.ClientID.ToString() + "');";
                txtNightStartTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtNightStartTime.ClientID.ToString() + "');";

                txtNightEndTime.Attributes["onKeyUp"] = "javascript:Timevalnum('" + txtNightEndTime.ClientID.ToString() + "');";
                txtNightEndTime.Attributes["onblur"] = "javascript:IsValidTime('" + txtNightEndTime.ClientID.ToString() + "');";

                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();
                txtAsOnDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                FillddlReportTypeMain();
                FillddlReportName();

                FillDivision();
                FillBranch();

                FillddlAreaInchargeDetails();
                FillDDlAreaID();

                FillddlEmployeeNumber();
                FillddlClient();
                FillddlTraining();

                //FillDDlShift();
                //FillDDLShiftCode();
                //FillShiftTimeFromTo();

                txtYear.Text = DateTime.Now.Year.ToString();
                txtForNextNDays.Text = "10";
                txtForNextNDays.Attributes.Add("onKeyDown", "if((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105)||(event.keyCode == 8 ) ||(event.keyCode == 9) || (event.keyCode == 12) || (event.keyCode == 27) || (event.keyCode == 37) || (event.keyCode == 39) || (event.keyCode == 46) ){return true;}else{return false;}");
                btnViewReport.Enabled = true;

                if (ddlReportName.SelectedItem.Value.ToString() == "WeeklyPostingSheet.rpt"
                || ddlReportName.SelectedItem.Value.ToString() == "Weeklyscheduleroster.rpt"
                || ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.WeeklyActualReport.ToString() ||
                            ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.WeeklyScheduleReport.ToString()
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
    /// Fillddls the report type main.
    /// </summary>
    private void FillddlReportTypeMain()
    {
        var li = new RadComboBoxItem();
        //li.Text = Resources.Resource.Rostering.ToString();
        //li.Value = "Rostering";
        //ddlReportTypeMain.Items.Add(li);

        //li = new RadComboBoxItem();
        li.Text = Resources.Resource.Training.ToString();
        li.Value = "Training";
        ddlReportTypeMain.Items.Add(li);

        //li = new RadComboBoxItem();
        //li.Text = Resources.Resource.YLMAttendance.ToString();
        //li.Value = "YLMAttendance";
        //ddlReportTypeMain.Items.Add(li);

        //li = new RadComboBoxItem();
        //li.Text = Resources.Resource.YLMAttendanceOnline.ToString();
        //li.Value = "YLMAttendanceOnline";
        //ddlReportTypeMain.Items.Add(li);

        //li = new RadComboBoxItem();
        //li.Text = Resources.Resource.YLMAttendanceNoshow.ToString();
        //li.Value = "YLMAttendanceNoshow";
        //ddlReportTypeMain.Items.Add(li);

        //li = new RadComboBoxItem();
        //li.Text = Resources.Resource.PostingSheet.ToString();
        //li.Value = "Postingsheet.rpt";
        //ddlReportName.Items.Add(li);

    }
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        ddlReportName.Items.Clear();
        var li = new RadComboBoxItem();
        if (ddlReportTypeMain.SelectedValue.ToString() == "Rostering")
        {
            //li = new ListItem();
            li.Text = Resources.Resource.WeeklyScheduleReport.ToString();
            li.Value = "rpt_ActualSchedule_AsmtWise.rpt1";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.MonthlyScheduleReport.ToString();
            li.Value = "rpt_ActualSchedule_AsmtWise.rpt2";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.WeeklyActualReport.ToString();
            li.Value = "rpt_ActualSchedule_AsmtWise.rpt3";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.MonthlyActualReport.ToString();
            li.Value = "rpt_ActualSchedule_AsmtWise.rpt4";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.ScheduleandActuals;
            li.Value = "rpt_ActualSchedule_AsmtWiseNew.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.EmployeeWiseScheduleandActuals;
            li.Value = "rpt_WeeklySchedule_EmpWise.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.ExceptionScheduleVsActual;
            li.Value = "ExceptionsActualVsTeken.rpt";
            ddlReportName.Items.Add(li);

        }

        if (ddlReportTypeMain.SelectedValue.ToString() == "Training")
        {
            //li = new ListItem();
            li.Text = Resources.Resource.dailyRefresherTrainingDue.ToString();
            li.Value = "dailyRefresherTrainingDue.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.RefresherTrainingDue.ToString();
            li.Value = "dateRangeRefresherTrainingDue.rpt";
            ddlReportName.Items.Add(li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.RefresherTrainingSchedule.ToString();
            li.Value = "dateRangeRefresherTrainingSchedule.rpt";
            ddlReportName.Items.Add(li);
        }

        if (ddlReportTypeMain.SelectedValue.ToString() == "YLMAttendance")
        {
            // Manish YLMattendance Report

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.YLMAttendance;
            li.Value = "YLMAttendance";
            ddlReportName.Items.Add(li);

        }

        //Manish YLM Attendance Raw data Report 


        if (ddlReportTypeMain.SelectedValue.ToString() == "YLMAttendanceOnline")
        {
            // Manish YLMattendance Report 18/10/2012

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.YLMAttendanceOnline;
            li.Value = "YLMAttendanceOnline";
            ddlReportName.Items.Add(li);

        }


        if (ddlReportTypeMain.SelectedValue.ToString() == "YLMAttendanceNoshow")
        {
            // Manish YLMattendance Report 18/10/2012

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.YLMAttendanceNoshow;
            li.Value = "YLMAttendanceNoshow";
            ddlReportName.Items.Add(li);

        }



    }

    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision()
    {
        DataSet dsDivision = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
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

            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlDivision.Items.Insert(0, li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlDivisionName.Items.Insert(0, li);

            FillBranch();
        }
    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        ddlBranch.Items.Clear();
        ddlBranchName.Items.Clear();
        if (ddlDivision.SelectedItem.Value.ToString() == "ALL")
        {
            var li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlBranch.Items.Insert(0, li);

            li = new RadComboBoxItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlBranchName.Items.Insert(0, li);
        }
        else
        {
            DataSet dsBranch = new DataSet();
            BL.UserManagement objblUserManagement = new BL.UserManagement();
            dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue.ToString());
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
            }
        }
    }

    /// <summary>
    /// Fillddls the area incharge details.
    /// </summary>
    private void FillddlAreaInchargeDetails()
    {
        String EmployeeNumber = String.Empty;

        if (BaseUserIsAreaIncharge == "0" && BaseUserID != "system")
        {
            EmployeeNumber = BaseUserInformation.EmployeeNumber;
        }
        BL.HRManagement objHRManagement = new BL.HRManagement();

        ddlAreaInchargeCode.Items.Clear();
        ddlAreaInchargeName.Items.Clear();

        if (ddlDivision.SelectedItem.Value.ToString() == "ALL")
        {
            var liAI = new RadComboBoxItem();
            liAI.Text = Resources.Resource.All;
            liAI.Value = "ALL";
            ddlAreaInchargeCode.Items.Insert(0, liAI);

            liAI = new RadComboBoxItem();
            liAI.Text = Resources.Resource.All;
            liAI.Value = "ALL";
            ddlAreaInchargeName.Items.Insert(0, liAI);
        }
        else
        {
            var ds = new DataSet();
            ds = objHRManagement.AreaInchargeGetBasedonUserID(ddlBranch.SelectedItem.Value.ToString(), EmployeeNumber, BaseUserID);

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

                if (BaseUserID == "system" || BaseUserIsAreaIncharge == "0")
                {
                    var li2 = new RadComboBoxItem();
                    li2.Text = Resources.Resource.SelectAll;
                    li2.Value = "ALL";
                    ddlAreaInchargeCode.Items.Insert(0, li2);

                    li2 = new RadComboBoxItem();
                    li2.Text = Resources.Resource.SelectAll;
                    li2.Value = "ALL";
                    ddlAreaInchargeCode.Items.Insert(0, li2);
                    ddlAreaInchargeName.Items.Insert(0, li2);
                }
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlAreaInchargeCode.Items.Insert(0, li1);

            }
        }

        FillDDlAreaID();
    }
    /// <summary>
    /// Fills the D dl area ID.
    /// </summary>
    private void FillDDlAreaID()
    {
        DDLAreaID.Items.Clear();
        ddlAreaName.Items.Clear();

        if (ddlDivision.SelectedItem.Value.ToString() == "ALL")
        {
            var liAID = new RadComboBoxItem();
            liAID.Text = Resources.Resource.All;
            liAID.Value = "ALL";
            DDLAreaID.Items.Insert(0, liAID);

            liAID = new RadComboBoxItem();
            liAID.Text = Resources.Resource.All;
            liAID.Value = "ALL";
            ddlAreaName.Items.Insert(0, liAID);
        }
        else
        {
            DataSet ds = new DataSet();
            BL.OperationManagement objOPS = new BL.OperationManagement();

            ds = objOPS.AreaIdGet(ddlBranch.SelectedItem.Value.ToString(), ddlAreaInchargeCode.SelectedValue);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DDLAreaID.DataSource = ds;
                DDLAreaID.DataTextField = "AreaID";
                DDLAreaID.DataValueField = "AreaID";
                DDLAreaID.DataBind();

                ddlAreaName.DataSource = ds;
                ddlAreaName.DataTextField = "AreaDesc";
                ddlAreaName.DataValueField = "AreaID";
                ddlAreaName.DataBind();

                //if (ddlAreaInchargeCode.SelectedItem.Value.ToString() == "ALL")
                //{
                var li = new RadComboBoxItem();
                li.Text = Resources.Resource.All;
                li.Value = "All";
                DDLAreaID.Items.Insert(0, li);

                li = new RadComboBoxItem();
                li.Text = Resources.Resource.All;
                li.Value = "All";
                ddlAreaName.Items.Insert(0, li);
                //}
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                DDLAreaID.Items.Insert(0, li1);

                li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlAreaName.Items.Insert(0, li1);
            }
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

        if (ddlDivision.SelectedItem.Value.ToString() == "ALL")
        {
            var liEmp = new RadComboBoxItem();
            liEmp.Text = Resources.Resource.All;
            liEmp.Value = "ALL";
            ddlEmployeeNumber.Items.Insert(0, liEmp);

            liEmp = new RadComboBoxItem();
            liEmp.Text = Resources.Resource.All;
            liEmp.Value = "ALL";
            ddlEmployeeName.Items.Insert(0, liEmp);
        }
        else
        {
            BL.HRManagement objHRManagement = new BL.HRManagement();
            DataSet ds = new DataSet();

            ds = objHRManagement.EmployeesOfLocationAreaWiseGetForTraining(BaseCompanyCode, ddlDivision.SelectedItem.Value.ToString(), ddlBranch.SelectedItem.Text, txtFromDate.Text, txtToDate.Text, DDLAreaID.SelectedValue.ToString(), ddlAreaInchargeCode.SelectedItem.Value, BaseUserIsAreaIncharge.ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlEmployeeNumber.DataSource = ds.Tables[0];
                ddlEmployeeNumber.DataTextField = "EmployeeNumber";
                ddlEmployeeNumber.DataValueField = "EmployeeNumber";
                ddlEmployeeNumber.DataBind();

                ddlEmployeeName.DataSource = ds.Tables[0];
                ddlEmployeeName.DataTextField = "EmployeeName";
                ddlEmployeeName.DataValueField = "EmployeeNumber";
                ddlEmployeeName.DataBind();

                var li2 = new RadComboBoxItem();
                li2.Text = Resources.Resource.SelectAll;
                li2.Value = "ALL";
                ddlEmployeeNumber.Items.Insert(0, li2);

                li2 = new RadComboBoxItem();
                li2.Text = Resources.Resource.SelectAll;
                li2.Value = "ALL";
                ddlEmployeeName.Items.Insert(0, li2);
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlEmployeeNumber.Items.Insert(0, li1);

                li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlEmployeeName.Items.Insert(0, li1);
            }
        }
    }

    /// <summary>
    /// Fillddls the training.
    /// </summary>
    protected void FillddlTraining()
    {
        ddlTrainingCode.Items.Clear();
        ddlTrainingName.Items.Clear();

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        ds = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlTrainingCode.DataSource = ds.Tables[0];
            ddlTrainingCode.DataTextField = "TrainingCode";
            ddlTrainingCode.DataValueField = "TrainingCode";
            ddlTrainingCode.DataBind();

            ddlTrainingName.DataSource = ds.Tables[0];
            ddlTrainingName.DataTextField = "TrainingDesc";
            ddlTrainingName.DataValueField = "TrainingCode";
            ddlTrainingName.DataBind();

            var li2 = new RadComboBoxItem();
            li2.Text = Resources.Resource.SelectAll;
            li2.Value = "ALL";
            ddlTrainingCode.Items.Insert(0, li2);

            li2 = new RadComboBoxItem();
            li2.Text = Resources.Resource.SelectAll;
            li2.Value = "ALL";
            ddlTrainingName.Items.Insert(0, li2);
        }
        else
        {
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlTrainingCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            ddlTrainingName.Items.Insert(0, li1);
        }

    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        ddlClientCode.Items.Clear();
        ddlClientName.Items.Clear();

        if (ddlDivision.SelectedItem.Value.ToString() == "ALL")
        {
            var liClt = new RadComboBoxItem();
            liClt.Text = Resources.Resource.All;
            liClt.Value = "ALL";
            ddlClientCode.Items.Insert(0, liClt);

            liClt = new RadComboBoxItem();
            liClt.Text = Resources.Resource.All;
            liClt.Value = "ALL";
            ddlClientName.Items.Insert(0, liClt);

            FillddlAsmt();
        }
        else
        {
            BL.Sales objSales = new BL.Sales();
            DataSet ds = new DataSet();
            if (BaseUserInformation.UserRole.Trim().ToLower() == "C".Trim().ToLower())
            {
                ds = objSales.ClientGet(BaseLocationAutoID, BaseUserID);
            }
            else
            {
                ddlClientCode.Items.Clear();
                ddlClientName.Items.Clear();
                ds = objSales.ClientAreaWiseGet(ddlBranch.SelectedItem.Value.ToString(), ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString());
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

                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.All;
                li1.Value = "ALL";
                ddlClientCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.All;
                li1.Value = "ALL";
                ddlClientName.Items.Insert(0, li1);

                FillddlAsmt();
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlClientCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlClientName.Items.Insert(0, li1);
            }
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
        string strClientCode;
        //if (ddlClientCode.SelectedItem.Value.ToString() == "ALL")
        if (ddlDivision.SelectedItem.Value.ToString() == "ALL")
        {
            strClientCode = "";
            var li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlAsmtCode.Items.Insert(0, li1);

            li1 = new RadComboBoxItem();
            li1.Text = Resources.Resource.All;
            li1.Value = "ALL";
            ddlAsmtName.Items.Insert(0, li1);

            ListItem li2 = new ListItem();
            li2.Text = Resources.Resource.All;
            li2.Value = "ALL";
            DDLPost.Items.Insert(0, li2);

        }
        else
        {
            strClientCode = ddlClientCode.SelectedValue.ToString();
            DataSet dsAsmt = new DataSet();
            BL.OperationManagement objOperationManagement = new BL.OperationManagement();

            if (ddlReportName.SelectedValue.ToString() == "DailyPostingSheet.rpt")
            {
                strClientCode = "ALL";
                txtFromDate.Text = txtAsOnDate.Text;
                txtToDate.Text = txtAsOnDate.Text;
            }
            //dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");
            //dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString());

            dsAsmt = objOperationManagement.AssignmentsOfClientGet(int.Parse(ddlBranch.SelectedItem.Value.ToString()), strClientCode, txtFromDate.Text, txtToDate.Text, ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString());

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
                li1.Value = "ALL";
                ddlAsmtCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.All;
                li1.Value = "ALL";
                ddlAsmtName.Items.Insert(0, li1);
            }
            else
            {
                var li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlAsmtCode.Items.Insert(0, li1);

                li1 = new RadComboBoxItem();
                li1.Text = Resources.Resource.NoDataToShow;
                li1.Value = "-1";
                ddlAsmtName.Items.Insert(0, li1);
            }
            //FillDDLPost();
        }

    }
    /// <summary>
    /// Fills the DDL client post.
    /// </summary>
    private void FillDDLClientPost()
    {
        string strAreaId;
        if (DDLAreaID.SelectedValue.ToString() == "ALL")
        {
            strAreaId = "";
        }
        else
        {
            strAreaId = DDLAreaID.SelectedValue.ToString();
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
        //FillddlAsmtPost();
    }
    /// <summary>
    /// Fillddls the asmt post.
    /// </summary>
    private void FillddlAsmtPost()
    {
        string strClientCode;
        if (DDLClientDetail.SelectedValue.ToString() == "ALL")
        {
            strClientCode = "";
        }
        else
        {
            strClientCode = DDLClientDetail.SelectedValue.ToString();
        }
        string strAreaId;
        if (DDLAreaID.SelectedValue.ToString() == "ALL")
        {
            strAreaId = "";
        }
        else
        {
            strAreaId = DDLAreaID.SelectedValue.ToString();
        }
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DDLAsmtID.Items.Clear();
        var ds = new DataSet();
         ds = objOperationManagement.AssignmentGet(BaseLocationAutoID, strClientCode, strAreaId);
         if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLAsmtID.DataSource = ds.Tables[0];
            DDLAsmtID.DataTextField = "AsmtNameCode";
            DDLAsmtID.DataValueField = "AsmtCode"; //Code Commented By Ajay Datta On 19-Jul-2013
            //DDLAsmtID.DataValueField = "AsmtID";
            DDLAsmtID.DataBind();

            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            DDLAsmtID.Items.Insert(0, li);
            DDLAsmtID.SelectedIndex = 0;
        }

        else {
            DDLAsmtID.DataSource = ds.Tables[0];
            ListItem li1 = new ListItem();
            li1.Text = Resources.Resource.NoDataToShow;
            li1.Value = "-1";
            //DDLAsmtID.SelectedIndex = 0;
            DDLAsmtID.Items.Insert(0, li1);
        
        
        }
        FillDDlShift();
    }

    /// <summary>
    /// Fills the D dl shift.
    /// </summary>
    private void FillDDlShift()
    {
        ddlShift.Items.Clear();
        BL.OperationManagement objOPS = new BL.OperationManagement();
        DataSet ds = new DataSet();

        //ds = objOPS.blShift_Get(DDLAsmtID.SelectedValue, BaseLocationAutoID);
        ds = objOPS.ShiftOnAsmtOfClientGet(BaseLocationAutoID.ToString(), DDLClientDetail.SelectedItem.Value.ToString(), DDLAsmtID.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlShift.DataSource = ds;
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Shift";
            ddlShift.DataBind();
        }
        var li2 = new RadComboBoxItem();
        li2.Text = Resources.Resource.All;
        li2.Value = "ALL";
        ddlShift.Items.Insert(0, li2);

        var li3 = new RadComboBoxItem();
        li3.Text = "0";
        li3.Value = "0";
        ddlShift.Items.Insert(1, li3);
        ddlShift.SelectedIndex = 0;


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
        var li2 = new RadComboBoxItem();
        li2.Text = Resources.Resource.All;
        li2.Value = "ALL";
        DDLShiftCode.Items.Insert(0, li2);

        var li3 = new RadComboBoxItem();
        li3.Text = "0";
        li3.Value = "0";
        DDLShiftCode.Items.Insert(1, li3);
    }

    /// <summary>
    /// Fills the DDL post.
    /// </summary>
    private void FillDDLPost()
    {
        DDLPost.Items.Clear();
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMasterManagement.AsmtPostGet(BaseLocationAutoID.ToString(), ddlAreaInchargeCode.SelectedItem.Value.ToString(), DDLAreaID.SelectedItem.Value.ToString(), ddlClientCode.SelectedItem.Value.ToString(), ddlAsmtCode.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DDLPost.DataSource = ds.Tables[0];
            DDLPost.DataTextField = "Site";
            DDLPost.DataValueField = "Site";
            DDLPost.DataBind();
        }
        ListItem li2 = new ListItem();
        li2.Text = Resources.Resource.All;
        li2.Value = "ALL";
        DDLPost.Items.Insert(0, li2);

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
            if (ddlReportName.SelectedItem.Value.ToString() == "WeeklyPostingSheet.rpt"
                || ddlReportName.SelectedItem.Value.ToString() == "Weeklyscheduleroster.rpt"
                || ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.WeeklyActualReport.ToString()
                || ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.WeeklyScheduleReport.ToString()
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
        FillDDlAreaID();

        FillddlEmployeeNumber();
        FillddlClient();
        FillddlTraining();

        //FillDDlShift();
        //FillDDLShiftCode();
        //FillShiftTimeFromTo();

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
        FillDDlAreaID();

        FillddlEmployeeNumber();
        FillddlClient();
        FillddlTraining();

        //FillDDlShift();
        //FillDDLShiftCode();
        //FillShiftTimeFromTo();

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
    }


    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlTrainingCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlTrainingCode_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTrainingName.SelectedValue = ddlTrainingCode.SelectedValue;
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlTrainingName control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlTrainingName_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTrainingCode.SelectedValue = ddlTrainingName.SelectedValue;
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
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
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

            case "dailyRefresherTrainingDue.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelEmployee.Visible = true;
                PanelTraining.Visible = true;
                PanelDates.Visible = true;
                ForNextNDays.Visible = true;
                break;

            case "dateRangeRefresherTrainingDue.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelEmployee.Visible = true;
                PanelTraining.Visible = true;
                PanelDates.Visible = true;
                break;

            case "dateRangeRefresherTrainingSchedule.rpt":
                PanelDivision.Visible = true;
                PanelBranch.Visible = true;
                PanelClientCode.Visible = true;
                PanelAsmt.Visible = true;
                PanelAreaIncharge.Visible = true;
                PanelAreaID.Visible = true;
                PanelEmployee.Visible = true;
                PanelTraining.Visible = true;
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
        PanelTraining.Visible = false;
    }
    #endregion

    #region Function Button event

    /// <summary>
    /// Handles the Click event of the btnExport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //string url = "../HRManagement/HrReportsExport.aspx?type=TRAINING&eType=rpt_DailyRefresherTrainingDue";

        if (ddlReportName.SelectedItem.Value.ToString() == "dailyRefresherTrainingDue.rpt")
        {
            string url = "../HRManagement/HrReportsExport.aspx?type=TRAINING&eType=" + ddlReportName.SelectedItem.Value.ToString() +
                        "&AreaId=" + DDLAreaID.SelectedItem.Value.ToString() +
                        "&FromDate=" + txtFromDate.Text +
                        "&nDays=" + txtForNextNDays.Text.ToString() +
                        "&LocationCode=" + ddlBranch.SelectedItem.Text.ToString() +
                        "&HrLocationCode=" + ddlDivision.SelectedItem.Value.ToString() +
                        "&ClientCode=" + ddlClientCode.SelectedItem.Value.ToString() +
                        "&AsmtCode=" + ddlAsmtCode.SelectedItem.Value.ToString() +
                        "&AreaIncharge=" + ddlAreaInchargeCode.SelectedItem.Value.ToString() +
                        "&EmpNo=" + ddlEmployeeNumber.SelectedValue.ToString() +
                        "&TrainingCode=" + ddlTrainingCode.SelectedValue.ToString();

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);

        }

        if (ddlReportName.SelectedItem.Value.ToString() == "dateRangeRefresherTrainingDue.rpt")
        {

            string url = "../HRManagement/HrReportsExport.aspx?type=TRAINING&eType=" + ddlReportName.SelectedItem.Value.ToString() +
                        "&AreaId=" + DDLAreaID.SelectedItem.Value.ToString() +
                        "&FromDate=" + txtFromDate.Text +
                        "&ToDate=" + txtToDate.Text +
                        "&LocationCode=" + ddlBranch.SelectedItem.Text.ToString() +
                        "&HrLocationCode=" + ddlDivision.SelectedItem.Value.ToString() +
                        "&ClientCode=" + ddlClientCode.SelectedItem.Value.ToString() +
                        "&AsmtCode=" + ddlAsmtCode.SelectedItem.Value.ToString() +
                        "&AreaIncharge=" + ddlAreaInchargeCode.SelectedItem.Value.ToString() +
                        "&EmpNo=" + ddlEmployeeNumber.SelectedValue.ToString() +
                        "&TrainingCode=" + ddlTrainingCode.SelectedValue.ToString();

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);

        }

        if (ddlReportName.SelectedItem.Value.ToString() == "dateRangeRefresherTrainingSchedule.rpt")
        {

            string url = "../HRManagement/HrReportsExport.aspx?type=TRAINING&eType=" + ddlReportName.SelectedItem.Value.ToString() +
                        "&AreaId=" + DDLAreaID.SelectedItem.Value.ToString() +
                        "&FromDate=" + txtFromDate.Text +
                        "&ToDate=" + txtToDate.Text +
                        "&LocationCode=" + ddlBranch.SelectedItem.Text.ToString() +
                        "&HrLocationCode=" + ddlDivision.SelectedItem.Value.ToString() +
                        "&ClientCode=" + ddlClientCode.SelectedItem.Value.ToString() +
                        "&AsmtCode=" + ddlAsmtCode.SelectedItem.Value.ToString() +
                        "&AreaIncharge=" + ddlAreaInchargeCode.SelectedItem.Value.ToString() +
                        "&EmpNo=" + ddlEmployeeNumber.SelectedValue.ToString() +
                        "&TrainingCode=" + ddlTrainingCode.SelectedValue.ToString();

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "window.open( '" + url + "', null, 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no,resizable=no' );", true);

        }


    }

    /// <summary>
    /// Handles the Click event of the btnViewReport control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnViewReport_Click(object sender, EventArgs e)
    {
        string strReportName = ddlReportName.SelectedItem.Value.ToString();
        if (strReportName == "rpt_ActualSchedule_AsmtWise.rpt1" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt2" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt3" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt4")
        {
            strReportName = "rpt_ActualSchedule_AsmtWise.rpt";
        }

        //Manish 27-11-2012 to Handel grouping on Employee Number if Checkbox is true esle we have to show report with out grouping 
        //Created 2 Report, One with grouping and another with out grouping.If check box is true then groupwise report else with out group. 
        if (chkEmpGroping.Checked == true && ddlReportName.SelectedItem.Value.ToString() == "rpt_WeeklySchedule_EmpWise.rpt")
        {

            strReportName = "rpt_WeeklySchedule_EmpWiseGroup.rpt";
        }


        if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
        {
            string strReportPagePath = "../Reports/Rostering/";
            Context.Items.Add("cxtReportFileName", strReportName);

            Hashtable hshRptParameters = new Hashtable();
            hshRptParameters = ReportParameter_Get(strReportName);

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../HRManagement/RptGroup_Training.aspx?ReportName=" + ddlReportName.SelectedValue.ToString();


            //Manish YLM Attendance Report
            if(ddlReportName.SelectedItem.Value == @"YLMAttendance")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/YLMAttendanceReport.aspx");
            }


            //Manish YLM Attendance raw data  Report 18-10-2012
            if(ddlReportName.SelectedItem.Value == @"YLMAttendanceOnline")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/YLMRawDataRpt.aspx");
            }

            //Manish YLM Attendance No Show Data   Report 10-12-2012
            if(ddlReportName.SelectedItem.Value == @"YLMAttendanceNoshow")
            {
                Context.Items.Remove("cxtHashParameters");
                // hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                Session["cxtHashParameters"] = hshRptParameters;

                Server.Transfer("../Transactions/YLMAttendanceNoshow.aspx");
            }



            //For Grid View Reports
            if (
                (ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.WeeklyScheduleReport.ToString()
                || ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.MonthlyScheduleReport.ToString()
                || ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.WeeklyActualReport.ToString()
                || ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.MonthlyActualReport.ToString()
                || ddlReportName.SelectedItem.Value.ToString() == "rpt_ActualSchedule_AsmtWiseNew.rpt"
                )
               && ddlReportGrid.SelectedItem.Value.ToString() == "Grid"
              )
            {
                Context.Items.Remove("cxtHashParameters");
                Session["cxtHashParameters"] = hshRptParameters;
                if (ddlReportName.SelectedItem.Value.ToString() == "rpt_ActualSchedule_AsmtWiseNew.rpt")
                {
                    Server.Transfer("../Transactions/AsmtWiseSchAct.aspx?ReportName=" + ddlOption.SelectedItem.Text.ToString());
                }
                else
                {
                    Server.Transfer("../Transactions/AsmtWiseSchAct.aspx?ReportName=" + ddlReportName.SelectedItem.Text.ToString());
                }
            }
            else
            {
                Server.Transfer("../Reports/ViewReport1.aspx");
            }
        }
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the STR report.</param>
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        if (strReportName == "rpt_ActualSchedule_AsmtWise.rpt1" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt2" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt3" || strReportName == "rpt_ActualSchedule_AsmtWise.rpt4")
        {
            strReportName = "rpt_ActualSchedule_AsmtWise.rpt";
        }

        //Manish 27-11-2012 to Handel grouping on Employee Number if Checkbox is true esle we have to show report with out grouping 
        //Created 2 Report, One with grouping and another with out grouping.If check box is true then groupwise report else with out group. 
        if (chkEmpGroping.Checked == true && ddlReportName.SelectedItem.Value.ToString() == "rpt_WeeklySchedule_EmpWise.rpt")
        {

            strReportName = "rpt_WeeklySchedule_EmpWiseGroup.rpt";
        }

        string txtLocationCode;

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
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.Source, ddlRptType.SelectedValue.ToString());
                return hshRptParameters;

            case "DailyPostingSheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtAsOnDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Post, DDLPost.SelectedItem.Value.ToString());
                return hshRptParameters;

            case "rpt_ActualSchedule_AsmtWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                if (ddlReportGrid.SelectedItem.Value.ToString() == "Grid")
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                }

                if (ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.WeeklyScheduleReport.ToString()
                    || ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.MonthlyScheduleReport.ToString())
                {
                    hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "SCH");
                }
                else if (ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.WeeklyActualReport.ToString()
                        || ddlReportName.SelectedItem.Text.ToString() == Resources.Resource.MonthlyActualReport.ToString())
                {
                    hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, "ACT");
                }
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value.ToString());
                return hshRptParameters;
            case "rpt_ActualSchedule_AsmtWiseNew.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                if (ddlReportGrid.SelectedItem.Value.ToString() == "Grid")
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                }
                else
                {
                    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                }

                hshRptParameters.Add(DL.Properties.Resources.ScheduleActual, ddlRosterOrSchedule.SelectedItem.Value.ToString().Substring(0, 3));
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value.ToString());
                return hshRptParameters;

            case "dailyRefresherTrainingDue.rpt":

                //string areaID_dailyRefresherTrainingDue = DDLAreaID.SelectedItem.Value.ToString();
                //if (areaID_dailyRefresherTrainingDue == "All")
                //{
                //    areaID_dailyRefresherTrainingDue = areaID_dailyRefresherTrainingDue + "-" + BaseUserID;
                //}


                if (ddlBranch.SelectedItem.Text.ToString() == Resources.Resource.All)
                {
                    txtLocationCode = "ALL";
                }
                else
                {
                    txtLocationCode = ddlBranch.SelectedItem.Text.ToString();
                }


                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.nDays, int.Parse(txtForNextNDays.Text.ToString()));

                //hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Text.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, txtLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());

                //hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                //hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);

                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.TrainingCode, ddlTrainingCode.SelectedValue.ToString());

                return hshRptParameters;

            case "dateRangeRefresherTrainingDue.rpt":

                if (ddlBranch.SelectedItem.Text.ToString() == Resources.Resource.All)
                {
                    txtLocationCode = "ALL";
                }
                else
                {
                    txtLocationCode = ddlBranch.SelectedItem.Text.ToString();
                }


                //string areaID_dateRangeRefresherTrainingDue = DDLAreaID.SelectedItem.Value.ToString();
                //if (areaID_dateRangeRefresherTrainingDue == "All")
                //{
                //    areaID_dateRangeRefresherTrainingDue = areaID_dateRangeRefresherTrainingDue + "-" + BaseUserID;
                //}

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));

                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Text.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, txtLocationCode);

                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_dateRangeRefresherTrainingDue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);

                hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.TrainingCode, ddlTrainingCode.SelectedValue.ToString());
                return hshRptParameters;

            case "dateRangeRefresherTrainingSchedule.rpt":

                if (ddlBranch.SelectedItem.Text.ToString() == Resources.Resource.All)
                {
                    txtLocationCode = "ALL";
                }
                else
                {
                    txtLocationCode = ddlBranch.SelectedItem.Text.ToString();
                }

                //string areaID_dateRangeRefresherTrainingSchedule = DDLAreaID.SelectedItem.Value.ToString();
                //if (areaID_dateRangeRefresherTrainingSchedule == "All")
                //{
                //    areaID_dateRangeRefresherTrainingSchedule = areaID_dateRangeRefresherTrainingSchedule + "-" + BaseUserID;
                //}

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));

                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.LocationCode, ddlBranch.SelectedItem.Text.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, txtLocationCode);

                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_dateRangeRefresherTrainingSchedule.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));

                hshRptParameters.Add(DL.Properties.Resources.AreaIncharge, ddlAreaInchargeCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.UserId, BaseUserID);
                hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.TrainingCode, ddlTrainingCode.SelectedValue.ToString());
                return hshRptParameters;

            case "rpt_WeeklySchedule_EmpWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.RosterOrSchedule, ddlRosterOrSchedule.SelectedItem.Value.ToString());
                return hshRptParameters;

            //Manish to Handel grouping on Employee Number if Checkbox is true esle we have to show report with out grouping
            //Created 2 Report, One with grouping and another with out grouping.If check box is true then groupwise report else with out group. 
            case "rpt_WeeklySchedule_EmpWiseGroup.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.RosterOrSchedule, ddlRosterOrSchedule.SelectedItem.Value.ToString());
                return hshRptParameters;


            case "ExceptionsActualVsTeken.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;

            //Manish YLMAttendance

            case "YLMAttendance":

                string areaID_YLMAttendance = DDLAreaID.SelectedItem.Value.ToString();
                if (areaID_YLMAttendance == "All")
                {
                    areaID_YLMAttendance = areaID_YLMAttendance + "-" + BaseUserID;
                }

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                //hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(ddlBranch.SelectedItem.Value.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_YLMAttendance.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.AttendanceType, ddlAttendanceType.SelectedItem.Value.ToString());

                return hshRptParameters;



            case "YLMAttendanceOnline":

                string areaID_YLMAttendanceYLMRaw = DDLAreaID.SelectedItem.Value.ToString();
                if (areaID_YLMAttendanceYLMRaw == "All")
                {
                    areaID_YLMAttendanceYLMRaw = areaID_YLMAttendanceYLMRaw + "-" + BaseUserID;
                }

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_YLMAttendanceYLMRaw.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                // hshRptParameters.Add(DL.Properties.Resources.AttendanceType, ddlAttendanceType.SelectedItem.Value.ToString());

                return hshRptParameters;

            case "YLMAttendanceNoshow":

                string areaID_YLMNoshow = DDLAreaID.SelectedItem.Value.ToString();
                if (areaID_YLMNoshow == "All")
                {
                    areaID_YLMNoshow = areaID_YLMNoshow + "-" + BaseUserID;
                }

                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, int.Parse(BaseLocationAutoID.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
                //hshRptParameters.Add(DL.Properties.Resources.AreaId, DDLAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, areaID_YLMNoshow.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, txtFromDate.Text);
                hshRptParameters.Add(DL.Properties.Resources.ToDate, txtToDate.Text);
                // hshRptParameters.Add(DL.Properties.Resources.AttendanceType, ddlAttendanceType.SelectedItem.Value.ToString());

                return hshRptParameters;



            default: return hshRptParameters;
        }
    }

    /// <summary>
    /// Validates from to date.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
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
    /// Validates the controles.
    /// </summary>
    /// <param name="strReportName">Name of the STR report.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
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

            case "YLMAttendance":
                return validateFromToDate();

            case "YLMAttendanceOnline":
                return validateFromToDate();
            case "YLMAttendanceNoshow":
                return validateFromToDate();

            default:
                return false;
        }
    }
    #endregion
}