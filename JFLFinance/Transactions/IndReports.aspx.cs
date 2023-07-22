// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="IndReports.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_IndReports.
/// </summary>
public partial class Transactions_IndReports : BasePage
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
            {
                throw new Exception("Have not Rights", ex);
            }
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
            {
                throw new Exception("Have not Rights", ex);
            }
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
            {
                throw new Exception("Have not Rights", ex);
            }
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
            {
                throw new Exception("Have not Rights", ex);
            }
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
                FillddlEmployeeNumber();
                FillddlVariation();
                FillddlClient();
                FillDutyType();
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
        
        //li = new ListItem();
        //li.Text = Resources.Resource.ClockRegister.ToString();
        //li.Value = "Clockregister.rpt";
        //ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.AsmtWiseConsolidatedHrs.ToString();
        li.Value = "ConsolidatedHoursAssignmentWise.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = "unit Register Excel";
        li.Value = "UnitRegisterExcel";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptLeaveConfliction.ToString();
        li.Value = "leaveconfliction.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptDesignationMismatch.ToString();
        li.Value = "desgmismatchInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = "Duty Performed";
        li.Value = "dutyperformInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptDutyonOtherLocation.ToString();
        li.Value = "DutyOnOtherLocationInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.OTReport.ToString();
        li.Value = "OTReportInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptShiftWiseAttendance.ToString();
        li.Value = "ShiftwiseAttendanceReport.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptEmployeesHours.ToString();
        li.Value = "EmployeeHoursInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptManpowerDetails.ToString();
        li.Value = "MapowerStatusInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptMusterRoll.ToString();
        li.Value = "MusterrollInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptDesignationWiseTotalHours.ToString();
        li.Value = "DesgtothrsSummaryInd.rpt";
        ddlReportName.Items.Add(li);
        
        //li = new ListItem();
        //li.Text = Resources.Resource.rptRotaEntryStatusBasedonContractedHours.ToString();
        //li.Value = "rotaStatusAsmtwisenewInd.rpt";
        //ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.AsmtWiseDesigWiseRpt.ToString();
        li.Value = "AsmtDesgwiseHrsInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.ClientWiseDutydaysRpt.ToString();
        li.Value = "ClientWiseDaysWorkedInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.ClientWiseDutyHrsRpt.ToString();
        li.Value = "ClientWiseDutyHrsInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.ClockSummary.ToString();
        li.Value = "ClocksummaryInd.rpt";
        ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.rptMusterRollCW.ToString();
        li.Value = "EmployeeAbsenseInd.rpt";
        ddlReportName.Items.Add(li);
        
        //li = new ListItem();
        //li.Text = Resources.Resource.rptMIS.ToString();
        //li.Value = "MISInd.rpt";
        //ddlReportName.Items.Add(li);
        
        li = new ListItem();
        li.Text = Resources.Resource.PaysumMismatchRpt.ToString();
        li.Value = "PaysumMismatchReportInd.rpt";
        ddlReportName.Items.Add(li);
        //li = new ListItem();
        //li.Text = Resources.Resource.rptUnitSummary.ToString();
        //li.Value = "UnitSummary.rpt";
        //ddlReportName.Items.Add(li);
        //li = new ListItem();
        //li.Text = Resources.Resource.rptUnitSummaryAsgnBreakUp.ToString();
        //li.Value = "unitsummary_Breakup.rpt";
        //ddlReportName.Items.Add(li);
        //li = new ListItem();
        //li.Text = Resources.Resource.AdjustmentHours;
        //li.Value = "AdjustmentHrsRpt.rpt";
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
        DataSet dsBranch = new DataSet();
        BL.UserManagement objblUserManagement = new BL.UserManagement();
        dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedItem.Value.ToString());
        if (dsBranch.Tables[0].Rows.Count > 0)
        {
            // ******** code commented by Manish on 1-apr-2010 for multiselection drop down list *****************
            //ddlBranch.DataSource = dsBranch.Tables[0];
            //ddlBranch.DataValueField = "LocationCode";
            //ddlBranch.DataTextField = "LocationDesc";
            //ddlBranch.DataBind();
            //ListItem li = new ListItem();
            //li.Text = Resources.Resource.All.ToString();
            //li.Value = "ALL";
            //ddlBranch.Items.Insert(0, li);
            // ******** code Added by Manish on 1-apr-2010 for multiselection drop down list *****************
            DataRow dr = dsBranch.Tables[0].NewRow();
            dr["LocationCode"] = "All";
            dr["LocationDesc"] = "All";
            dsBranch.Tables[0].Rows.InsertAt(dr, 0);
            msddlBranch.CreateCheckBox(dsBranch.Tables[0], "LocationDesc", "LocationCode");
            
            int msddlBranchselectedIndex;
            msddlBranchselectedIndex = 0;
            for (int i = 0; i < dsBranch.Tables[0].Rows.Count; i++)
            {
                if (dsBranch.Tables[0].Rows[i]["LocationCode"].ToString() == BaseLocationCode.ToString())
                {
                    msddlBranch.selectedIndex = i.ToString();
                    i = dsBranch.Tables[0].Rows.Count;
                }
            }
                
            if (msddlBranchselectedIndex != 0)
            {
                msddlBranch.selectedIndex = "1";
            }
        }
    }

    /// <summary>
    /// Fillddls the employee number.
    /// </summary>
    private void FillddlEmployeeNumber()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        //commented by Manish 9-mar-2010
        //ds = objHRManagement.blEmployeeName_GetAll(BaseLocationAutoID);
        //added by Manish 9-mar-2010
        ds = objHRManagement.EmployeesOfLocationGetAll(msddlBranch.sValue, BaseHrLocationCode, txtFromDate.Text, txtToDate.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlEmployeeNumber.DataSource = ds.Tables[0];
            ddlEmployeeNumber.DataTextField = "Name";
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataBind();
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlEmployeeNumber.Items.Insert(0, li);
        }
    }

    /// <summary>
    /// Fillddls the client.
    /// </summary>
    private void FillddlClient()
    {
        BL.Sales objSales = new BL.Sales();
        DataSet ds = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSales.ClientGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objSales.ClientsLocationWiseGet(BaseLocationAutoID);
        }
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

    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    /// <param name="strClientCode">The string client code.</param>
    private void FillddlAsmt(string strClientCode)
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

    /// <summary>
    /// Fills the type of the duty.
    /// </summary>
    private void FillDutyType()
    {
        BL.MastersManagement objMasterManagement = new BL.MastersManagement();
        ddlDutyType.DataSource = objMasterManagement.DutyTypeGetAll(BaseCompanyCode);
        ddlDutyType.DataTextField = "DutyTypeDesc";
        ddlDutyType.DataValueField = "DutyTypeCode";
        ddlDutyType.DataBind();
        ListItem li1 = new ListItem();
        li1.Text = "All";
        li1.Value = "All";
        ddlDutyType.Items.Insert(0, li1);
        
        ListItem li2 = new ListItem();
        li2.Text = "Normal And TSO";
        li2.Value = "Normal";
        ddlDutyType.Items.Insert(1, li2);
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
            case "TimeSheet.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                break;
            case "Clockregister.rpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                PanelLocation.Visible = true;
                break;
            case "ConsolidatedHoursAssignmentWise.rpt":
                PanelDates.Visible = true;
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
                break;
            case "UnitRegisterExcel":
                PanelDates.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                PanelDutyType.Visible = true;
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
                break;
            case "DeploymentDetail.rpt":
                PanelDates.Visible = true;
                PanelEmployee.Visible = true;
                break;
            case "leaveconfliction.rpt":
                PanelDates.Visible = true;
                break;
            case "desgmismatchInd.rpt":
                PanelDates.Visible = true;
                break;
            case "dutyperformInd.rpt":
                PanelDates.Visible = true;
                PanelDutyPerform.Visible = true;
                break;
            case "DutyOnOtherLocationInd.rpt":
                PanelDates.Visible = true;
                break;
            case "OTReportInd.rpt":
                PanelDates.Visible = true;
                break;
            case "ShiftwiseAttendanceReport.rpt":
                PanelDates.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                break;
            case "EmployeeHoursInd.rpt":
                PanelDates.Visible = true;
                PanelFromToHours.Visible = true;
                break;
            case "MapowerStatusInd.rpt":
                PanelDates.Visible = true;
                break;
            case "MusterrollInd.rpt":
                PanelDates.Visible = true;
                PnlCategory.Visible = true;
                break;
            case "DesgtothrsSummaryInd.rpt":
                PanelDesignation.Visible = true;
                PanelDates.Visible = true;
                PanelddlReportType.Visible = true;
                break;
            case "rotaStatusAsmtwisenewInd.rpt":
                PanelDates.Visible = true;
                PanelVariation.Visible = true;
                break;
            case "AsmtDesgwiseHrsInd.rpt":
                PanelDates.Visible = true;
                break;
            case "ClientWiseDaysWorkedInd.rpt":
                PanelDates.Visible = true;
                PanelClientCode.Visible = true;
                break;
            case "ClientWiseDutyHrsInd.rpt":
                PanelDates.Visible = true;
                PanelClientCode.Visible = true;
                break;
            case "ClocksummaryInd.rpt":
                PanelDates.Visible = true;
                PanelAreaID.Visible = true;
                break;
            case "EmployeeAbsenseInd.rpt":
                PanelDates.Visible = true;
                break;
            case "MISInd.rpt":
                PanelDates.Visible = true;
                PanelAsmtCode.Visible = true;
                PanelClientCode.Visible = true;
                break;
            case "PaysumMismatchReportInd.rpt":
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
        PanelAreaID.Visible = false;
        PanelDutyType.Visible = false;
        PanelDutyPerform.Visible = false;
        PanelFromToHours.Visible = false;
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
        string reportName = ddlReportName.SelectedItem.Value.ToString();
            
        if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
        {
            string strReportPagePath = "../Reports/Rostering/";
                
            if (ddlReportName.SelectedItem.Value.ToString().Equals("UnitRegisterExcel"))
            {
                if (ddlClientCode.SelectedValue.ToString() == "All")
                {
                    lblErrorMsg.Text = Resources.Resource.SelectClient ;
                    return;
                }

                Context.Items.Add("FromDate", txtFromDate.Text);
                Context.Items.Add("ToDate", txtToDate.Text);
                Context.Items.Add("ClientCode", ddlClientCode.SelectedValue.ToString());
                Context.Items.Add("AsmtCode", ddlAsmtCode.SelectedValue.ToString());
                Context.Items.Add("DutyType", ddlDutyType.SelectedValue.ToString());
                
                //if (ddlAsmtCode.SelectedValue.ToString() == "" || ddlAsmtCode.SelectedValue.ToString() == "All")
                //{
                //    lblErrorMsg.Text = "please select an assignment!";
                //}
                //else
                {
                    Server.Transfer("RptRostering_UnitRegisterExcel.aspx");
                }
                //Server.Transfer("RptRostering_UnitRegisterExcel.aspx");
                return;
            }
            if (ddlReportName.SelectedItem.Value.ToString().Equals("DesgtothrsSummaryInd.rpt") && ddlReportStatus.SelectedItem.Value.ToString().Equals("Detailed"))
            {
                reportName = "DesgtothrsdetailInd.rpt";
            }

            Hashtable hshRptParameters = new Hashtable();
            hshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value.ToString());
            Context.Items.Remove("cxtReportFileName");
            //Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value.ToString());
            
            Context.Items.Add("cxtReportFileName", reportName);
            
            //Comment Date: (15/01/2012)
            //Comment By	: (Manoj Kumar)
            //Changes done: (A New Report Added for New Column(Post) and Two New Radio Buton added for Selection only)               
            if (ddlReportName.SelectedItem.Value == "UnitRegister.rpt" && rdoAssigmentWise.Checked)
            {
                Context.Items.Remove("cxtReportFileName");
                Context.Items.Add("cxtReportFileName", ddlReportName.SelectedItem.Value.ToString());
            }
            else if (ddlReportName.SelectedItem.Value == "UnitRegister.rpt" && rdoPostWise.Checked)
            {
                Context.Items.Remove("cxtReportFileName");
                Context.Items.Add("cxtReportFileName", "UnitRegisterPostWise.rpt");
                hshRptParameters = ReportParameter_Get("UnitRegisterPostWise.rpt");
            }
            //End Added by Manoj Kumar

            Context.Items.Add("cxtHashParameters", hshRptParameters);
            Context.Items.Add("cxtReportID", "ReportID");
            Context.Items.Add("cxtReportPagePath", strReportPagePath);
            Context.Items["cxtReturnPage"] = "../Transactions/IndReports.aspx?ReportName=" + ddlReportName.SelectedItem.Value.ToString();
    
            Server.Transfer("../Reports/ViewReport1.aspx");
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
        //dsArea = objSale.blAreaID_Get((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString());
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
    /// <returns>Hashtable.</returns>
    private Hashtable ReportParameter_Get(string strReportName)
    {
        Hashtable hshRptParameters = new Hashtable();
        switch (strReportName)
        {
            case "AttendanceRegister.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value.ToString());
                return hshRptParameters;
                //case "DesgtothrsSummary.rpt":
                //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                //    hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                //    hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                //    hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                //    hshRptParameters.Add(DL.Properties.Resources.Designationcode, ddlDesignation.SelectedItem.Value.ToString());
                //    hshRptParameters.Add(DL.Properties.Resources.Option, ddlReportStatus.SelectedItem.Value.ToString());
                
                //    if (ddlReportStatus.SelectedValue.ToString() == "Summary")
                //    {
                //        Context.Items["cxtReportFileName"] = "DesgtothrsSummary.rpt";
                //    }
                //    else
                //    {
                //        Context.Items["cxtReportFileName"] = "Desgtothrsdetail.rpt";
                //    }
                //    return hshRptParameters;
            case "TimeSheet.rpt":
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.OptionParam, "");
                return hshRptParameters;
            case "EmployeeAbsense.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.PresentOption, bool.Parse(chkPresent.Checked.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.AbsentOption, bool.Parse(chkAbsent.Checked.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.LeaveOption, bool.Parse(chkLeave.Checked.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.WeekOffOption, bool.Parse(chkWeekOff.Checked.ToString()));
                hshRptParameters.Add(DL.Properties.Resources.Emp, ddlEmployeeNumber.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.Designationcode, ddlDesignation.SelectedItem.Value.ToString());
                
                return hshRptParameters;
                //case "RotaStatusAsmtwise.rpt":
                //    hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                //    hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                //    hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                //    hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                //    hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                //    hshRptParameters.Add(DL.Properties.Resources.Variation, ddlVariation.SelectedValue.ToString());
                //return hshRptParameters;
            case "Clockregister.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.EmpNo, ddlEmployeeNumber.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "ConsolidatedHoursAssignmentWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Option, "");
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationDesc, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationDesc, BaseLocationCode);
                //hshRptParameters.Add(DL.Properties.Resources.HrLocationDesc, BaseHrLocationCode);
                //hshRptParameters.Add(DL.Properties.Resources.LocationDesc, BaseLocationCode);
                
                return hshRptParameters;
                
            case "Clocksummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                return hshRptParameters;
                
            case "UnitRegister.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                //hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                hshRptParameters.Add("@ReportOption", 1);//Assignment Wise
                
                return hshRptParameters;
                //Added by Manoj(Unit Register Report(Assignment Wise/Post Wise))27/02/2012
            case "UnitRegisterPostWise.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                //hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                hshRptParameters.Add("@ReportOption", 0);//Post Wise                                
                
                return hshRptParameters;
                //End Added by Manoj(Unit Register Report(Assignment Wise/Post Wise))27/02/2012
                
            case "UnitSummary.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.Variation, ddlVariation.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                if (BaseCompanyCode == "AMSSKW")
                {
                    hshRptParameters.Add(DL.Properties.Resources.InvType, ddlInvoiceType.SelectedValue.ToString());
                    Context.Items.Remove("cxtReportFileName");
                    Context.Items.Add("cxtReportFileName", "UnitSummary_KWT.rpt");
                }
                
                if (ddlReportStatus1.SelectedValue.ToString() == "Summary")
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
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.Variation, ddlVariation.SelectedValue.ToString());
                return hshRptParameters;
                
            case "MonthlyAttendance.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue.ToString());
                return hshRptParameters;
                
            case "ManpowerDetails.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
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
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedItem.Value.ToString());
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
                hshRptParameters.Add(DL.Properties.Resources.HrLocation, ddlDivision.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, msddlBranch.sValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AdjCode, "all");
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedValue);
                return hshRptParameters;
            case "DeploymentDetail.rpt":
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
                hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, ddlEmployeeNumber.SelectedItem.Value.ToString());
                return hshRptParameters;
                
            case "leaveconfliction.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Division, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.Branch, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));           
                return hshRptParameters;
                
            case "desgmismatchInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "dutyperformInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.nHrs, txtNHours.Text);
                hshRptParameters.Add(DL.Properties.Resources.ContinuityDays, txtContDays.Text);
                return hshRptParameters;
                
            case "DutyOnOtherLocationInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocation, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "OTReportInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "ShiftwiseAttendanceReport.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "EmployeeHoursInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocation, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.FromHours, txtFromHours.Text.ToString());
                hshRptParameters.Add(DL.Properties.Resources.ToHours, txtToHours.Text.ToString());
                return hshRptParameters;
                
            case "MapowerStatusInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "MusterrollInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.CategoryCode, DDLCategory.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "DesgtothrsSummaryInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Division, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.Branch, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.Designation, ddlDesignation.SelectedItem.Value.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Option, ddlReportStatus.SelectedItem.Value.ToString());
                if (ddlReportStatus.SelectedValue.ToString() == "Detailed")
                {
                    Context.Items["cxtReportFileName"] = "DesgtothrsdetailInd.rpt";
                    //Context.Items["cxtReportFileName"] = "DesgtothrsSummaryInd.rpt";
                }
                else
                {
                    // Context.Items["cxtReportFileName"] = "DesgtothrsdetailInd.rpt";
                    Context.Items["cxtReportFileName"] = "DesgtothrsSummaryInd.rpt";
                }
                return hshRptParameters;
                
            case "rotaStatusAsmtwisenewInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.Option, ddlVariation.SelectedValue.ToString());
                return hshRptParameters;
                
            case "AsmtDesgwiseHrsInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocation, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "ClientWiseDaysWorkedInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                return hshRptParameters;
                
            case "ClientWiseDutyHrsInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                return hshRptParameters;
                
            case "ClocksummaryInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.AreaId, ddlAreaID.SelectedItem.Value.ToString());
                return hshRptParameters;
                
            case "EmployeeAbsenseInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.Location, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "MISInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.DivisionCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.BranchCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.ClientCode, ddlClientCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.AsmtCode, ddlAsmtCode.SelectedValue.ToString());
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;
                
            case "PaysumMismatchReportInd.rpt":
                hshRptParameters.Add(DL.Properties.Resources.Company, BaseCompanyCode);
                hshRptParameters.Add(DL.Properties.Resources.HrLocationCode, BaseHrLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.LocationCode, BaseLocationCode);
                hshRptParameters.Add(DL.Properties.Resources.FromDate, DL.Common.DateFormat(txtFromDate.Text, ""));
                hshRptParameters.Add(DL.Properties.Resources.ToDate, DL.Common.DateFormat(txtToDate.Text, ""));
                return hshRptParameters;

            default:
                return hshRptParameters;
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
        if (msddlBranch.sValue.ToString() == "")
        {
            lblErrorMsg.Text = Resources.Resource.Location + " " + Resources.Resource.CannotBeLeftBlank;
            return false;
        }
            
        switch (strReportName)
        {
            case "AttendanceRegister.rpt":
                return validateFromToDate();
            case "DesgtothrsSummary.rpt":
                return validateFromToDate();
            case "TimeSheet.rpt":
                return validateFromToDate();
            case "EmployeeAbsense.rpt":
                return validateFromToDate();
            case "RotaStatusAsmtwise.rpt":
                return validateFromToDate();
            case "Clockregister.rpt":
                return validateFromToDate();
                
            case "ConsolidatedHoursAssignmentWise.rpt":
                return validateFromToDate();
            
            case "Clocksummary.rpt":
                return validateFromToDate();
            case "UnitRegister.rpt":
                return validateFromToDate();
            case "UnitRegisterExcel":
                return validateFromToDate();
            case "UnitSummary.rpt":
                return validateFromToDate();
            case "unitsummary_Breakup.rpt":
                return validateFromToDate();
            case "MonthlyAttendance.rpt":
                return validateFromToDate();
            case "ManpowerDetails.rpt":
                return validateShift();
            case "ManpowerDetailsGreece.rpt":
                return validateShift();
            case "AdjustmentHrsRpt.rpt":
                return validateFromToDate();
            case "DeploymentDetail.rpt":
                return validateFromToDate();
            case "leaveconfliction.rpt":
                return validateFromToDate();
            case "desgmismatchInd.rpt":
                return validateFromToDate();
            case "dutyperformInd.rpt":
                return validateFromToDate();
            case "DutyOnOtherLocationInd.rpt":
                return validateFromToDate();
            case "OTReportInd.rpt":
                return validateFromToDate();
                
            case "ShiftwiseAttendanceReport.rpt":
                return validateFromToDate();
                
            case "EmployeeHoursInd.rpt":
                return validateFromToDate();
                
            case "MapowerStatusInd.rpt":
                return validateFromToDate();
                
            case "MusterrollInd.rpt":
                return validateFromToDate();
                
            case "DesgtothrsSummaryInd.rpt":
                return validateFromToDate();
                
            case "DesgtothrsdetailInd.rpt":
                return validateFromToDate();
                
            case "rotaStatusAsmtwisenewInd.rpt":
                return validateFromToDate();
                
            case "AsmtDesgwiseHrsInd.rpt":
                return validateFromToDate();
                
            case "ClientWiseDaysWorkedInd.rpt":
                return validateFromToDate();
                
            case "ClientWiseDutyHrsInd.rpt":
                return validateFromToDate();
                
            case "ClocksummaryInd.rpt":
                return validateFromToDate();
                
            case "EmployeeAbsenseInd.rpt":
                return validateFromToDate();
                
            case "MISInd.rpt":
                return validateFromToDate();
                
            case "PaysumMismatchReportInd.rpt":
                return validateFromToDate();
    
            default:
                return false;
        }
    }

    #endregion
}