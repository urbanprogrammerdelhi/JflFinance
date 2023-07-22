// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-27-2014
// ***********************************************************************
// <copyright file="RptGroup_ScheduleKenya.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Threading;
using DL;
using Microsoft.Reporting.WebForms;
using Resources;
using HRManagement = BL.HRManagement;
using MastersManagement = BL.MastersManagement;
using OperationManagement = BL.OperationManagement;
using Sales = BL.Sales;
using UserManagement = BL.UserManagement;
using System.Text.RegularExpressions;

/// <summary>
/// Class Transactions_RptGroup_ScheduleKenya.
/// </summary>
public partial class Transactions_RptGroup_ScheduleKenya : BasePage
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
                var VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1, System.StringComparison.Ordinal).ToString());
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
                VirtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
            var javaScript = new StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resource.Schedules + "');");
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
                txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                txtToDate.Text = LastDateOfCurrentMonth_Get();
                txtAsOnDate.Text = FirstDateOfCurrentMonth_Get();
                FillddlReportName();
                FillDivision();
                FillDDlAreaID();
                FillddlClient();
                FillDDLShiftCode();
                FillAreaIncharge();
                btnViewReport.Enabled = true;
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != string.Empty)
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

    #region Fill Controles
    /// <summary>
    /// Fillddls the name of the report.
    /// </summary>
    private void FillddlReportName()
    {
        var Li = new ListItem {Text = Resource.rptPostingSheet, Value = @"WeeklyPostingSheetKenya"};
        ddlReportName.Items.Add(Li);

        Li = new ListItem {Text = Resource.rptManpowerDetails, Value = @"ManpowerDetail"};
        ddlReportName.Items.Add(Li);

        
    }

    /// <summary>
    /// Fills the DDL shift code.
    /// </summary>
    private void FillDDLShiftCode()
    {
        DDLShiftCode.Items.Clear();
        var ObjMasterManagement = new MastersManagement();
        var Ds = ObjMasterManagement.StandardSiftsGetAll(BaseLocationAutoID);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DDLShiftCode.DataSource = Ds.Tables[0];
            DDLShiftCode.DataTextField = "ShiftCode";
            DDLShiftCode.DataValueField = "ShiftCode";

            DDLShiftCode.DataBind();
        }
        var Li2 = new ListItem {Text = Resource.All, Value = @"ALL"};
        DDLShiftCode.Items.Insert(0, Li2);
    }
    /// <summary>
    /// Fills the area incharge.
    /// </summary>
    private void FillAreaIncharge()
    {
        var Obj = new OperationManagement();
      
        DataSet Ds = Obj.AreaInchargeGet(BaseLocationCode, BaseHrLocationCode, BaseCompanyCode, "All");

        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            ddlAreaIncharge.DataSource = Ds.Tables[0];
            ddlAreaIncharge.DataTextField = "AreaInchargeName";
            ddlAreaIncharge.DataValueField = "AreaIncharge";
            ddlAreaIncharge.DataBind();
            var Li2 = new ListItem {Text = Resource.All, Value = @"ALL"};
            ddlAreaIncharge.Items.Insert(0, Li2);
        }

    }
    /// <summary>
    /// Fills the DDL post.
    /// </summary>
    private void FillDDLPost()
    {
        DDLPost.Items.Clear();
        var ObjMasterManagement = new MastersManagement();
        DataSet Ds = ObjMasterManagement.AsmtPostGet(BaseLocationAutoID, BaseUserEmployeeNumber, DDLAreaID.SelectedValue, ddlClientCode.SelectedValue, ddlAsmtCode.SelectedItem.Value);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DDLPost.DataSource = Ds.Tables[0];
            DDLPost.DataTextField = "Site";
            DDLPost.DataValueField = "Site";
            DDLPost.DataBind();
        }
        var Li2 = new ListItem {Text = Resource.All, Value = @"ALL"};
        DDLPost.Items.Insert(0, Li2);

    }
    /// <summary>
    /// Fills the shift time from to.
    /// </summary>
    private void FillShiftTimeFromTo()
    {

        var ObjMasterManagement = new MastersManagement();
        DataSet Ds = ObjMasterManagement.StandardSiftsGet(BaseLocationAutoID, DDLShiftCode.SelectedValue);

        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DataTable Dt = Ds.Tables[0];
            TxtTimeFrom.Text = Dt.Rows[0]["TimeFrom"].ToString();
            TxtTimeTo.Text = Dt.Rows[0]["TimeTo"].ToString();
        }

    }
    /// <summary>
    /// Fillddls the name of the employee.
    /// </summary>
    protected void FillddlEmployeeName()
    {
        var ObjHRManagement = new HRManagement();

        //ds = objHRManagement.EmployeesOfLocationAreaWiseGet(BaseLocationAutoID, BaseHrLocationCode, txtFromDate.Text, txtToDate.Text, DDLAreaID.SelectedValue);
        DataSet Ds = ObjHRManagement.EmployeesScheduleGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, txtFromDate.Text, txtToDate.Text, DDLAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            ddlEmployeeNumber.DataSource = Ds.Tables[0];
            ddlEmployeeNumber.DataTextField = "EmployeeName";
            ddlEmployeeNumber.DataValueField = "EmployeeNumber";
            ddlEmployeeNumber.DataBind();

            var Li2 = new ListItem {Text = Resource.SelectAll, Value = @"ALL"};
            ddlEmployeeNumber.Items.Insert(0, Li2);

        }

    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {

        var ObjSales = new Sales();
        DataSet ds = BaseIsAdmin.Trim().ToLower() == @"C".Trim().ToLower() ? ObjSales.ClientGet(BaseLocationAutoID, BaseUserID) : ObjSales.ClientsLocationWiseGet(BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClientCode.DataSource = ds.Tables[0];
            ddlClientCode.DataTextField = "ClientNameCode";
            ddlClientCode.DataValueField = "ClientCode";
            ddlClientCode.DataBind();
            var Li1 = new ListItem {Text = Resource.All, Value = @"ALL"};

            ddlClientCode.Items.Insert(0, Li1);
            FillddlAsmt();
        }

    }
    /// <summary>
    /// Fills the branch.
    /// </summary>
    private void FillBranch()
    {
        var ObjblUserManagement = new UserManagement();
        DataSet DsBranch = ObjblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, ddlDivision.SelectedValue);
        if (DsBranch.Tables[0].Rows.Count > 0)
        {
            ddlBranch.DataSource = DsBranch.Tables[0];
            ddlBranch.DataValueField = "LocationCode";
            ddlBranch.DataTextField = "LocationDesc";
            ddlBranch.DataBind();
            var Li = new ListItem {Text = Resource.All, Value = @"ALL"};
            ddlBranch.Items.Insert(0, Li);
        }
    }
    /// <summary>
    /// Fills the division.
    /// </summary>
    private void FillDivision()
    {
        var ObjblUserManagement = new UserManagement();
        DataSet DsDivision = ObjblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (DsDivision.Tables[0].Rows.Count > 0)
        {
            ddlDivision.DataSource = DsDivision.Tables[0];
            ddlDivision.DataValueField = "HrLocationCode";
            ddlDivision.DataTextField = "HrLocationDesc";
            ddlDivision.DataBind();
            FillBranch();
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ddlAsmtCode.Items.Clear();

        string StrClientCode = ddlClientCode.SelectedItem.Value == @"ALL" ? "" : ddlClientCode.SelectedItem.Value;

        if (ddlReportName.SelectedValue == "DailyPostingSheet.rpt" || ddlReportName.SelectedValue == "DailyDispositionSheet.rpt")
        {
            StrClientCode = "ALL";
            txtFromDate.Text = txtAsOnDate.Text;
            txtToDate.Text = txtAsOnDate.Text;
        }

        var ObjOperationManagement = new OperationManagement();



        if (ddlClientCode.SelectedValue == "All")
        {
            var Li = new ListItem {Text = Resource.All, Value = @"All"};
            ddlAsmtCode.Items.Insert(0, Li);
        }
        else
        {
            DataSet DsAsmt = ObjOperationManagement.AssignmentsOfClientGet(int.Parse(BaseLocationAutoID), StrClientCode, txtFromDate.Text, txtToDate.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, "");

            if (DsAsmt != null && DsAsmt.Tables.Count > 0 && DsAsmt.Tables[0].Rows.Count > 0)
            {
                ddlAsmtCode.DataSource = DsAsmt.Tables[0];
                ddlAsmtCode.DataTextField = "AsmtDetail";
                ddlAsmtCode.DataValueField = "AsmtCode";
                ddlAsmtCode.DataBind();

                var Li1 = new ListItem {Text = Resource.All, Value = @"ALL"};
                ddlAsmtCode.Items.Insert(0, Li1);
            }
            else
            {
                var Li1 = new ListItem {Text = Resource.NoDataToShow, Value = @"-1"};
                ddlAsmtCode.Items.Insert(0, Li1);
            }
        }
        FillDDLPost();
    }

    /// <summary>
    /// Fills the DDL client post.
    /// </summary>
    private void FillDDLClientPost()
    {
        //string strAreaId = DDLAreaID.SelectedValue == "ALL" ? "" : DDLAreaID.SelectedValue;
        DDLClientDetail.Items.Clear();

        var ObjSales = new Sales();
        DataSet Ds = ObjSales.ClientAreaInchargeWiseGet(BaseLocationAutoID, DDLAreaID.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, BaseLocationCode, txtFromDate.Text, txtToDate.Text);

        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DDLClientDetail.DataSource = Ds;
            DDLClientDetail.DataTextField = "ClientNameCode";
            DDLClientDetail.DataValueField = "ClientCode";
            DDLClientDetail.DataBind();

            var Li1 = new ListItem {Text = Resource.All, Value = @"ALL"};
            DDLClientDetail.Items.Insert(0, Li1);
            DDLClientDetail.SelectedIndex = 0;
        }
        else
        {
            var Li1 = new ListItem();
            Li1.Text = Resource.NoDataToShow;
            Li1.Value = @"-1";
            DDLClientDetail.Items.Insert(0, Li1);
        }
        FillddlAsmtPost();
    }
    /// <summary>
    /// Fillddls the asmt post.
    /// </summary>
    private void FillddlAsmtPost()
    {
        string StrClientCode = DDLClientDetail.SelectedValue == "ALL" ? "" : DDLClientDetail.SelectedValue;
        string StrAreaId = DDLAreaID.SelectedValue == "ALL" ? "" : DDLAreaID.SelectedValue;
        var ObjOperationManagement = new OperationManagement();
        DDLAsmtID.Items.Clear();

        if (DDLClientDetail.SelectedValue == "ALL")
        {
            var Li = new ListItem {Text = Resource.All, Value = @"All"};
            DDLAsmtID.Items.Insert(0, Li);
        }
        else
        {
            DDLAsmtID.DataSource = ObjOperationManagement.AssignmentGet(BaseLocationAutoID, StrClientCode, StrAreaId);
            DDLAsmtID.DataTextField = "AsmtNameCode";
            DDLAsmtID.DataValueField = "AsmtCode";
            DDLAsmtID.DataBind();

            var Li = new ListItem {Text = Resource.All, Value = @"ALL"};
            DDLAsmtID.Items.Insert(0, Li);
            DDLAsmtID.SelectedIndex = 0;
        }

        FillDDlShift();
    }
    /// <summary>
    /// Fills the d dl area identifier.
    /// </summary>
    private void FillDDlAreaID()
    {
        DDLAreaID.Items.Clear();
        var ObjOps = new OperationManagement();
        //Added by Manoj on 03/09/12
        DataSet Ds = ObjOps.AreaIdGetUserWise(BaseLocationAutoID, BaseUserID);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            DDLAreaID.DataSource = Ds;
            DDLAreaID.DataTextField = "AreaDesc";
            DDLAreaID.DataValueField = "AreaID";
            DDLAreaID.DataBind();
        }

        var Li = new ListItem {Text = @"All", Value = @"All"};
        DDLAreaID.Items.Insert(0, Li);

        FillDDLClientPost();
        FillddlAsmtPost();
        FillddlEmployeeName();
    }
    /// <summary>
    /// Fills the d dl shift.
    /// </summary>
    private void FillDDlShift()
    {
        ddlShift.Items.Clear();

        var ObjOps = new OperationManagement();

        //ds = objOPS.blShift_Get(DDLAsmtID.SelectedValue, BaseLocationAutoID);
        DataSet Ds = ObjOps.ShiftOnAsmtOfClientGet(BaseLocationAutoID, DDLClientDetail.SelectedItem.Value, DDLAsmtID.SelectedItem.Value);
        if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
        {
            ddlShift.DataSource = Ds;
            ddlShift.DataTextField = "Shift";
            ddlShift.DataValueField = "Shift";
            ddlShift.DataBind();
        }
        var Li2 = new ListItem {Text = Resource.All, Value = @"ALL"};
        ddlShift.Items.Insert(0, Li2);

        var Li3 = new ListItem {Text = @"0", Value = @"0"};
        ddlShift.Items.Insert(1, Li3);
        ddlShift.SelectedIndex = 0;


    }
    #endregion

    #region Controles Events

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlAsmtCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAsmtCode_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDLPost();

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlClientCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlClientCode_SelectedIndexChanged(object sender, EventArgs e)
    {
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
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDLClientPost();
        FillDDlShift();
        FillddlEmployeeName();
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
            if (ddlReportName.SelectedItem.Value == @"WeeklyDailyPostingSheet" || ddlReportName.SelectedItem.Value == @"Weeklyscheduleroster.rpt" || ddlReportName.SelectedItem.Value == @"WeeklyPostingSheetISRN.rpt")
            {
                txtToDate.Text = DateFormat(DateTime.Parse(txtFromDate.Text).AddDays(6));
            }
            else
            {
                txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);
            }
            // FillddlAsmt();
        }
        else
        {
            btnViewReport.Enabled = false;
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        btnViewReport.Enabled = ConvertStringToDateFormat(txtToDate, lblErrorMsg);
    }

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
    /// Handles the SelectedIndexChanged event of the DDLShiftCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void DDLShiftCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillShiftTimeFromTo();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlDivision control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBranch();
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlBranch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt();
    }
    /// <summary>
    /// Handles the TextChanged event of the txtAsOnDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAsOnDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtAsOnDate, lblErrorMsg);
        //DateFormat(txtAsOnDate.Text.ToString(),
    }
    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        var StrReportName = ddlReportName.SelectedItem.Value;
        
        HideAllControles();
        switch (StrReportName)
        {

            case "SchEmpWiseRpt":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                break;

            case "SchAsmtWiseRpt":
                //PanelClientCode.Visible = true;
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelDates.Visible = true;
                //PanelAsmt.Visible = true;
                break;

            case "DailyPostingSheet":
                PanelClientDetail.Visible = true;
                PanelAsmtId.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelShift.Visible = true;
                PanelAreaID.Visible = true;
                PanelSource.Visible = true;
                break;
            case "ManpowerDetail":
                //PanelDivision.Visible = true;
                //PanelBranch.Visible = true;
                //PanelClientCode.Visible = true;
                //PanelAsmt.Visible = true;
                PanelAsOnDate.Visible = true;
                PanelDayShift.Visible = true;
                PanelNightShift.Visible = true;
                break;
            case "WeeklyPostingSheetKenya":
                PanelAreaIncharge.Visible = true;
                PanelShiftCode.Visible = true;
                PanelSource.Visible = true;
                PanelDates.Visible = true;
                txtBlankRows.Visible = true;
                break;
            case "SiteRoster":
                PanelClientCode.Visible = true;
                PanelDates.Visible = true;
                PanelAsmt.Visible = true;
                break;

            case "PersonnelRoster":
                PanelEmployee.Visible = true;
                PanelDates.Visible = true;
                break;
        }
    }
    /// <summary>
    /// Hides all controles.
    /// </summary>
    private void HideAllControles()
    {

        //PanelAreaID.Visible = false;
        PanelDates.Visible = false;
        PanelSource.Visible = false;
        PanelShiftCode.Visible = false;
        //Manish 20Jun2012
        PanelAreaIncharge.Visible = false;
        txtBlankRows.Text = @"0";
        txtBlankRows.Visible = false;

        PanelShift.Visible = false;
        //PanelAreaID.Visible = false;
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
        pnlShiftType.Visible = false;
        //Manish 18-12-2012
        PanelGropOnShift.Visible = false;
        PanelAreaID.Visible = false;
        PanelGroupOnPost.Visible = false;
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
        Regex regexDt = new Regex("(^(((([1-9])|([0][1-9])|([1-2][0-9])|(30))\\-([A,a][P,p][R,r]|[J,j][U,u][N,n]|[S,s][E,e][P,p]|[N,n][O,o][V,v]))|((([1-9])|([0][1-9])|([1-2][0-9])|([3][0-1]))\\-([J,j][A,a][N,n]|[M,m][A,a][R,r]|[M,m][A,a][Y,y]|[J,j][U,u][L,l]|[A,a][U,u][G,g]|[O,o][C,c][T,t]|[D,d][E,e][C,c])))\\-[0-9]{4}$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-8]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][1235679])|([13579][01345789]))$)|(^(([1-9])|([0][1-9])|([1][0-9])|([2][0-9]))\\-([F,f][E,e][B,b])\\-[0-9]{2}(([02468][048])|([13579][26]))$)");

        Match mtStartDt = Regex.Match(txtAsOnDate.Text.ToString(), regexDt.ToString());
        if (mtStartDt.Success)
        {
            var StrRptName = ddlReportName.SelectedValue;

            Context.Items.Remove("cxtReportName");
            Context.Items.Add("cxtReportName", ddlReportName.SelectedItem.Value);

            //if (ValidateControles(ddlReportName.SelectedItem.Value.ToString()))
            if (ValidateControles(StrRptName))
            {
                const string StrReportPagePath = "../Reports/Rostering/";
                // Context.Items.Add("cxtReportFileName", ddlReportName.SelectedValue.ToString(),
                Context.Items.Add("cxtReportFileName", StrRptName);

                List<ReportParameter> HshRptParameters = ReportParameter_Get(ddlReportName.SelectedItem.Value);
                lblErrorMsg.Text = "";
                lblErrorMsg.Visible = true;
                lblErrorMsg.Text = @"Loading....";
                Context.Items.Add("cxtHashParameters", HshRptParameters);
                Context.Items.Add("cxtReportID", "ReportID");
                Context.Items.Add("cxtReportPagePath", StrReportPagePath);
                // Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Schedule.aspx?ReportName=" + ddlReportName.SelectedValue.ToString();
                Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_ScheduleKenya.aspx?ReportName=" + ddlReportName.SelectedValue;
                //Server.Transfer("../Reports/ViewReport1.aspx");
                Server.Transfer("~/Transactions/ViewReport.aspx");

            }
        }
        else 
        {
            DisplayMessageString(lblErrorMsg, Resources.Resource.InvalidDate);
        }
    }
    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <param name="strReportName">Name of the string report.</param>
    /// <returns>List&lt;ReportParameter&gt;.</returns>
    private List<ReportParameter> ReportParameter_Get(string strReportName)
    {

        //int PostGroup = 0;
        var HshRptParameters = new Hashtable();
        var Connectionstring = BaseCountryCode;
        var ObjCon = new ConnectionString();
        var Dt = ObjCon.ConnectionStringGet(Connectionstring, "1");
        var aParamList = new List<ReportParameter>();
        switch (strReportName)
        {
            case "WeeklyPostingSheetKenya":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0, 1), BaseHrLocationCode),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), BaseLocationCode),
                new ReportParameter(DL.Properties.Resources.AreaIncharge.Remove(0, 1), ddlAreaIncharge.SelectedItem.Value),
                new ReportParameter(DL.Properties.Resources.ShiftCode.Remove(0, 1), DDLShiftCode.SelectedValue),
                new ReportParameter("BlankRows", txtBlankRows.Text),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()),
                new ReportParameter("UserName", Dt.Rows[0][4].ToString()),
                new ReportParameter("Password", Dt.Rows[0][5].ToString())
                };
                return aParamList;

            case "ManpowerDetail":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0, 1), BaseHrLocationCode),
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), BaseLocationCode),
                new ReportParameter(DL.Properties.Resources.DutyDate.Remove(0, 1), Common.DateFormat(txtAsOnDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.DayStartTime.Remove(0, 1), Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayStartTime.Text, new CultureInfo("en-US")))),
                new ReportParameter(DL.Properties.Resources.DayEndTime.Remove(0, 1), Common.DateFormat(DateTime.Parse("01-01-1900 " + txtDayEndTime.Text, new CultureInfo("en-US")))),
                new ReportParameter(DL.Properties.Resources.NightStartTime.Remove(0, 1), Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightStartTime.Text, new CultureInfo("en-US")))),
                new ReportParameter(DL.Properties.Resources.NightEndTime.Remove(0, 1), Common.DateFormat(DateTime.Parse("01-01-1900 " + txtNightEndTime.Text, new CultureInfo("en-US")))),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                new ReportParameter("RptServerName", Dt.Rows[0][2].ToString()),
                new ReportParameter("RptDatabaseName", Dt.Rows[0][3].ToString()),
                new ReportParameter("UserName", Dt.Rows[0][4].ToString()),
                new ReportParameter("Password", Dt.Rows[0][5].ToString())
                };
                return aParamList;

            case "SchEmpWiseRpt":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter("CompanyCode", BaseCompanyCode),
                new ReportParameter("LocationCode", BaseLocationCode),
                new ReportParameter("EmployeeNumber", ddlEmployeeNumber.SelectedItem.Value),
                new ReportParameter("StartDate", Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("EndDate", Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("AreaId", DDLAreaID.SelectedItem.Value),
                new ReportParameter("UserId", BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name)
                };
                return aParamList;

            case "SchAsmtWiseRpt":
                aParamList = new List<ReportParameter>
                {            
                new ReportParameter("CompanyCode", BaseCompanyCode),
                new ReportParameter("LocationCode", BaseLocationCode),
                new ReportParameter("AsmtId", DDLAsmtID.SelectedValue),
                new ReportParameter("StartDate", Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("EndDate", Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("AreaId", DDLAreaID.SelectedItem.Value),
                new ReportParameter("ClientCode", DDLClientDetail.SelectedValue),
                new ReportParameter("UserId", BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name),
                };
                return aParamList;

            case "DailyPostingSheet":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter("CompanyCode", BaseCompanyCode),
                new ReportParameter("LocationCode", BaseLocationCode),
                new ReportParameter("AreaId", DDLAreaID.SelectedItem.Value),
                new ReportParameter("DutyDate", Common.DateFormat(txtAsOnDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("Client", DDLClientDetail.SelectedValue),
                new ReportParameter("Assign", DDLAsmtID.SelectedValue),
                new ReportParameter("Source", ddlRptType.SelectedValue),
                new ReportParameter("Shift", ddlShift.SelectedValue),
                new ReportParameter("UserID", BaseUserID),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name)
                };
                return aParamList;

            case "SiteRoster":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter("LocationAutoID", BaseLocationAutoID),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ClientCode.Remove(0, 1), ddlClientCode.SelectedValue),
                new ReportParameter("AsmtID", DDLAsmtID.SelectedValue),
                new ReportParameter(DL.Properties.Resources.AreaId.Remove(0, 1), DDLAreaID.SelectedItem.Value),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name)
                };
                return aParamList;

            case "PersonnelRoster":
                aParamList = new List<ReportParameter>
                {
                new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0, 1), BaseCompanyCode),
                new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0, 1), BaseLocationCode),
                new ReportParameter(DL.Properties.Resources.EmployeeNumber.Remove(0, 1), ddlEmployeeNumber.SelectedValue),
                new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1), Common.DateFormat(txtFromDate.Text, new CultureInfo("en-US"))),
                new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1), Common.DateFormat(txtToDate.Text, new CultureInfo("en-US"))),
                new ReportParameter("ReportCulture", Thread.CurrentThread.CurrentCulture.Name)
                };
                return aParamList;
            default: return aParamList;
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
            lblErrorMsg.Text = Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
            return false;
        }
        lblErrorMsg.Text = Resource.DateFieldsCantBeLeftBlank;
        return false;
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
            case "WeeklyPostingSheetKenya":
                return validateFromToDate();
            case "SiteRoster":
                return validateFromToDate();
            case "PersonnelRoster":
                return validateFromToDate();
            case "SchEmpWiseRpt":
                return validateFromToDate();
            case "SchAsmtWiseRpt":
                return validateFromToDate();
            case "DailyPostingSheet":
                return validateFromToDate();
            case "ManpowerDetail":
                
                if (txtDayStartTime.Text == "__:__" || txtDayEndTime.Text == "__:__" || txtNightStartTime.Text == "__:__" || txtNightEndTime.Text == "__:__")
                {
                    lblErrorMsg.Text = Resource.TimeisNotInValidFormat;
                    return false;
                }
                else if (txtDayStartTime.Text == "" || txtDayEndTime.Text == "" || txtNightStartTime.Text == "" || txtNightEndTime.Text == "")
                {
                    lblErrorMsg.Text = Resource.TimeisNotInValidFormat;
                    return false;
                }
                TimeSpan t1 = TimeSpan.Parse(txtDayStartTime.Text);
                TimeSpan t2 = TimeSpan.Parse(txtDayEndTime.Text);
                if ( t1>=t2)
                {
                    lblErrorMsg.Text = Resources.Resource.DayShiftTimeTo + " " + "Should not be Less than" +" " + Resources.Resource.DayShiftTimeFrom;
                }
                return false;
            default:
                return false;
        }
    }


    #endregion
}
