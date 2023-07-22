// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="RptGroup_Thailand.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using DL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_RptGroup_Thailand.
/// </summary>
public partial class Transactions_RptGroup_Thailand : BasePage
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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
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
                var virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            { throw new Exception("Have not Rights", ex); }
        }
    }

    #endregion
    /// <summary>
    /// Loads the Page
    /// </summary>
    /// <param name="sender">Page</param>
    /// <param name="e">Load</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.HoursComparison + "');");
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
                ////  ImgBtnSearchClient.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH006&ControlId=" + ddlClientName.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850px,Height=450,help=no')");

                FillddlReportName();
                btnViewReport.Enabled = true;
                //On Back Button Of Report Set The Same report in Drop Down List
                if (Request.QueryString["ReportName"] != null && Request.QueryString["ReportName"] != string.Empty)
                {
                    ddlReportName.SelectedValue = Request.QueryString["ReportName"];
                }
                HFStartDate.Value = FirstDateOfCurrentMonth_Get();
                HFEndDate.Value = LastDateOfCurrentMonth_Get();
                DdlMonth.SelectedValue = DateTime.Parse(HFStartDate.Value).Month.ToString();
                txtYear.Text = DateTime.Now.Year.ToString();
                txtYear.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                txtYear.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                ViewState["MonthChangeStatus"] = 0;
                GetStartEndDate();
                //txtFromDate.Text = FirstDateOfCurrentMonth_Get();
                //txtToDate.Text = LastDateOfCurrentMonth_Get();

                FillDivision();
                //FillAttendanceType();
                ShowHideReportParameterControles();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            lblErrorMsg.Text = string.Empty;
        }
    }

    #region Fill Controles
    /// <summary>
    /// Gets Last date of the Month
    /// </summary>
    /// <param name="date1">Gets the Date</param>
    /// <returns>Last Date of Month</returns>
    protected new string LastDateOfMonth(string date1)
    {
        string totalDays = DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(DdlMonth.SelectedValue)).ToString();
        return totalDays;
    }
    /// <summary>
    /// Fills ReportName DropDown
    /// </summary>
    private void FillddlReportName()
    {
        ddlReportName.Items.Clear();
        //var li = new RadComboBoxItem
        //             {
        //                 Text = Resources.Resource.RptUnitRegSummaryCompContractHrs,
        //                 Value = @"UnitRegSummaryComparisionFss"
        //             };
        //ddlReportName.Items.Add(li);

        var li = new RadComboBoxItem { Text = Resources.Resource.LocationCategoryWOHrs, Value = @"LocationwiseWOReport" };
        ddlReportName.Items.Add(li);

        li = new RadComboBoxItem { Text = Resources.Resource.ClientWiseOTReport, Value = @"ClientWiseOTFss" };
        ddlReportName.Items.Add(li);

        li = new RadComboBoxItem
        {
            Text = Resources.Resource.RptUnitRegSummaryComp3Mnth,
            Value = @"UnitReg3mnthComparision"
        };
        ddlReportName.Items.Add(li);
    }

    /// <summary>
    /// Fills DdlDivision DropDown
    /// </summary>
    private void FillDivision()
    {

        var objblUserManagement = new BL.UserManagement();
        DataSet dsDivision = objblUserManagement.UserHRLocationAccessGet(BaseUserID, BaseCompanyCode);
        if (dsDivision.Tables[0].Rows.Count <= 0) return;
        DdlDivision.DataSource = dsDivision.Tables[0];
        DdlDivision.DataValueField = "HrLocationCode";
        DdlDivision.DataTextField = "HrLocationDesc";
        DdlDivision.DataBind();
        if (!IsPostBack)
        {
            foreach (RadComboBoxItem item in DdlDivision.Items)
            {
                if (item.Value == BaseHrLocationCode)
                {
                    item.Checked = true;
                }
            }

            var loc = DdlDivision.CheckedItems;
            //For Branch

            string hrLocCode = string.Empty;
            if (loc.Count > 0)
            {
                loc.Aggregate(hrLocCode, (current, item) => current + item.Value + ",");
            }

        }



        FillBranch();
    }

    /// <summary>
    /// Fills DdlBranch Dropdown
    /// </summary>
    private void FillBranch()
    {

        var objblUserManagement = new BL.UserManagement();
        DataSet dsBranch = objblUserManagement.UserLocationAccessGet(BaseUserID, BaseCompanyCode, DdlDivision.SelectedValue);
        if (dsBranch.Tables[0].Rows.Count > 0)
        {

            DdlBranch.DataSource = dsBranch.Tables[0];
            DdlBranch.DataValueField = "LocationCode";
            DdlBranch.DataTextField = "LocationDesc";
            DdlBranch.DataBind();
            if (!IsPostBack)
            {
                foreach (RadComboBoxItem item in DdlBranch.Items)
                {
                    if (item.Value == BaseLocationCode)
                    {
                        item.Checked = true;
                    }
                }

                var loc = DdlBranch.CheckedItems;
                //For Branch

                string locationCode = string.Empty;
                if (loc.Count > 0)
                {
                    loc.Aggregate(locationCode, (current, item) => current + item.Value + ",");
                }

            }
        }
    }

    /// <summary>
    /// Fills the Dropdown Attendance Type
    /// </summary>
    private void FillAttendanceType()
    {
        var li = new RadComboBoxItem();
        if (ddlReportName.SelectedValue != @"UnitReg3mnthComparision")
        {
            li = new RadComboBoxItem { Text = Resources.Resource.Attendance, Value = @"Attendance" };
            ddlAttendaneType.Items.Add(li);
        }
        li = new RadComboBoxItem { Text = Resources.Resource.Processing, Value = @"Processing" };
        ddlAttendaneType.Items.Add(li);
    }

    /// <summary>
    /// Fills the Dropdown for Hours Type Based on Attendance Type
    /// </summary>
    private void FillHoursType()
    {
        ddlHourType.Items.Clear();
        if (ddlAttendaneType.SelectedItem.Text == Resources.Resource.Attendance)
        {
            var liHrsType = new RadComboBoxItem { Text = Resources.Resource.PerformedHours, Value = @"PerformedHours" };
            ddlHourType.Items.Add(liHrsType);

            liHrsType = new RadComboBoxItem { Text = Resources.Resource.LeaveHours, Value = @"LeaveHours" };
            ddlHourType.Items.Add(liHrsType);

            liHrsType = new RadComboBoxItem { Text = Resources.Resource.HolidayHours, Value = @"HolidayHours" };
            ddlHourType.Items.Add(liHrsType);

            liHrsType = new RadComboBoxItem { Text = Resources.Resource.AdjustmentHours, Value = @"AdjustmentHours" };
            ddlHourType.Items.Add(liHrsType);


            liHrsType = new RadComboBoxItem { Text = Resources.Resource.PermanentHours, Value = @"PermanentHours" };
            ddlHourType.Items.Add(liHrsType);

            liHrsType = new RadComboBoxItem { Text = Resources.Resource.TemporaryHours, Value = @"TemporaryHours" };
            ddlHourType.Items.Add(liHrsType);

            liHrsType = new RadComboBoxItem { Text = Resources.Resource.WeeklyOff, Value = @"WeeklyOff" };
            ddlHourType.Items.Add(liHrsType);
            return;
        }

        var obj = new DL.Report();
        DataTable dt = obj.ProcessingHoursType(BaseCompanyCode);
        ddlHourType.DataSource = dt;
        ddlHourType.DataTextField = "HeadCodeDesc";
        ddlHourType.DataValueField = "HoursHeadCode";
        ddlHourType.DataBind();


    }

    /// <summary>
    /// fills first and last date of the month
    /// </summary>
    private void GetStartEndDate()
    {
        //DateTime now = DateTime.Now;

        var month = new DateTime(Convert.ToInt32(txtYear.Text), Convert.ToInt32(DdlMonth.SelectedValue), 1);
        var first = month.AddMonths(0);

        var last = first.AddMonths(1).AddDays(-1);

        HFStartDate.Value = first.ToString("dd-MMM-yyyy");
        HFEndDate.Value = last.ToString("dd-MMM-yyyy");


    }

    /// <summary>
    /// Shows the hide report parameter controles.
    /// </summary>
    private void ShowHideReportParameterControles()
    {
        var strReportName = ddlReportName.SelectedValue;
        HideAllControles();
        switch (strReportName)
        {
            case "UnitRegSummaryComparisionFss":
                PanelDates.Visible = false;
                PanelMonth.Visible = true;
                PanelBranch.Visible = true;
                PanelDivision.Visible = true;
                break;
            case "UnitReg3mnthComparision":
                PanelMonth.Visible = false;
                PanelDates.Visible = false;
                PanelBranch.Visible = true;
                PanelDivision.Visible = true;
                PanelAttendanceType.Visible = true;
                PanelHoursType.Visible = true;
                break;
            case "LocationwiseWOReport":
                PanelMonth.Visible = false;
                PanelDates.Visible = true;
                PanelBranch.Visible = true;
                PanelDivision.Visible = true;
                PanelAttendanceType.Visible = true;
                PanelHoursType.Visible = true;
                break;
            case "ClientWiseOTFss":
                PanelMonth.Visible = false;
                PanelBranch.Visible = true;
                PanelAttendanceType.Visible = false;
                PanelHoursType.Visible = false;
                PanelDivision.Visible = true;
                PanelDates.Visible = true;
                break;
        }
    }

    /// <summary>
    /// Hides the Control events
    /// </summary>
    private void HideAllControles()
    {


        PanelDates.Visible = false;
        PanelDivision.Visible = false;
        PanelBranch.Visible = false;
        PanelMonth.Visible = false;
        PanelAttendanceType.Visible = false;
        PanelHoursType.Visible = false;


    }

    /// <summary>
    /// Gets the Month Name against the Month Value in Integer
    /// </summary>
    /// <param name="month">Month Value</param>
    /// <returns>Month Name</returns>
    private static new string GetMonthName(int month)
    {
        var date = new DateTime(1900, month, 1);
        return date.ToString("MMMM");
    }
    #endregion

    #region ControlEvents

    /// <summary>
    /// Fills the HoursType dropdown based on Attendance Type
    /// </summary>
    /// <param name="sender">DdlAttendanceType</param>
    /// <param name="e">Index Change</param>
    protected void DdlAttendaneType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillHoursType();
    }

    /// <summary>
    /// Fills the HoursType dropdown based on Attendance Type
    /// </summary>
    /// <param name="sender">DdlAttendanceType</param>
    /// <param name="e">Index Change</param>
    protected void ddlHourType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ModalPopup.Visible = true;
        if (ddlReportName.SelectedValue == "UnitReg3mnthComparision")
        {

            lblErrorMsgPop.Text = "";
            TxtFromDatePop.Text = "";
            TxtName.Text = "";
            TxtToDatePop.Text = "";
        }
    }

    /// <summary>
    /// Calls on BtnRptView Click
    /// </summary>
    /// <param name="sender">BtnRptView</param>
    /// <param name="e">Click</param>
    protected void BtnRptView_Click(object sender, EventArgs e)
    {
        lblErrorMsg.Text = string.Empty;
        switch (ddlReportName.SelectedItem.Value)
        {
            case "UnitReg3mnthComparision":
                if (ValidateControles("UnitReg3mnthComparision"))
                {
                    const string StrReportPagePath = "../Transactions/";
                    Context.Items.Add("cxtReportFileName", "UnitReg3mnthComparision");

                    List<ReportParameter> hshRptParameters = ReportParameter_Get();
                    Context.Items.Remove("cxtReportName");
                    Context.Items.Add("cxtReportName", "UnitReg3mnthComparision");

                    Context.Items.Add("cxtHashParameters", hshRptParameters);
                    Context.Items.Add("cxtReportID", "ReportID");
                    Context.Items.Add("cxtReportPagePath", StrReportPagePath);
                    Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Thailand.aspx";

                    Context.Items.Add("cxtReportScreenType", "Default");
                    Server.Transfer("~/Transactions/ViewReport.aspx");


                }

                break;
            case "UnitRegSummaryComparisionFss":

                break;
            case "LocationwiseWOReport":
                if (ValidateControles("LocationwiseWOReport"))
                {
                    const string StrReportPagePath = "../Transactions/";
                    Context.Items.Add("cxtReportFileName", "LocationwiseWOReport");

                    List<ReportParameter> hshRptParameters = ReportParameter_Get();
                    Context.Items.Remove("cxtReportName");
                    Context.Items.Add("cxtReportName", "LocationwiseWOReport");

                    Context.Items.Add("cxtHashParameters", hshRptParameters);
                    Context.Items.Add("cxtReportID", "ReportID");
                    Context.Items.Add("cxtReportPagePath", StrReportPagePath);
                    Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Thailand.aspx";


                    Context.Items.Add("cxtReportScreenType", "Default");
                    Server.Transfer("~/Transactions/ViewReport.aspx");


                }
                break;

            case "ClientWiseOTFss":
                if (ValidateControles("ClientWiseOTFss"))
                {
                    const string StrReportPagePath = "../Transactions/";
                    Context.Items.Add("cxtReportFileName", "ClientWiseOTFss");

                    List<ReportParameter> hshRptParameters = ReportParameter_Get();
                    Context.Items.Remove("cxtReportName");
                    Context.Items.Add("cxtReportName", "ClientWiseOTFss");

                    Context.Items.Add("cxtHashParameters", hshRptParameters);
                    Context.Items.Add("cxtReportID", "ReportID");
                    Context.Items.Add("cxtReportPagePath", StrReportPagePath);
                    Context.Items["cxtReturnPage"] = "../Transactions/RptGroup_Thailand.aspx";


                    Context.Items.Add("cxtReportScreenType", "Default");
                    Server.Transfer("~/Transactions/ViewReport.aspx");


                }
                break;
        }
    }

    /// <summary>
    /// This will allow to save the Value assigned to the Hidden Field
    /// </summary>
    /// <param name="sender">ButtonOK</param>
    /// <param name="e">Click</param>
    protected void BtnOK_Click(object sender, EventArgs e)
    {

        if (TxtToDatePop.Text != string.Empty && TxtFromDatePop.Text != string.Empty)
        {
            var objCommon = new BL.Common();
            if (objCommon.IsValidDate(TxtFromDatePop.Text) != true)
            {
                lblErrorMsgPop.Text = Resources.Resource.InvalidDate;
                TxtFromDatePop.Focus();
                return;
            }
            if (objCommon.IsValidDate(TxtToDatePop.Text) != true)
            {
                lblErrorMsgPop.Text = Resources.Resource.InvalidDate;
                TxtToDatePop.Focus();
                return;
            }
            //=====================================================================

            if (GetGreaterDate(Convert.ToDateTime(TxtFromDatePop.Text), Convert.ToDateTime(TxtToDatePop.Text)))
            {
                lblErrorMsgPop.Text = Resources.Resource.FromDateCannotGrtToDate;
                return;
            }

        }

        if (TxtToDatePop.Text == string.Empty || TxtFromDatePop.Text == string.Empty)
        {
            lblErrorMsgPop.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
            return;
        }
        var hour = ddlHourType.CheckedItems;
        var ddlHour = string.Empty;
        var ItemsVal = string.Empty;

        foreach (RadComboBoxItem IHour in hour)
        {
            ItemsVal = ItemsVal + IHour.Value + @",";
            ddlHour = ddlHour + IHour.Value + @"~" + TxtName.Text + @"~" + TxtFromDatePop.Text + @"~" + TxtToDatePop.Text + ",";
            ddlHourType.Items.Remove(IHour);

        }
        TxtAssign.Text = TxtAssign.Text + ddlHour;
        GVHoursType.Visible = true;
        /********************Code here fills the data in Grid View to be visible to the User*****************************/
        var dt = new DataTable();
        DataRow dr;

        dt.Columns.Add("Name");
        dt.Columns.Add("HoursType");
        dt.Columns.Add("FromDate");
        dt.Columns.Add("ToDate");
        //lblErrorMsg.Text = GVHoursType.Rows.Count.ToString();
        for (int intCnt = 0; intCnt < GVHoursType.Rows.Count ; intCnt++)
        {
            if (GVHoursType.Rows[intCnt].RowType == DataControlRowType.DataRow)
            {
                dr = dt.NewRow();
                dr["Name"] = GVHoursType.Rows[intCnt].Cells[0].Text;/// at this point
                dr["HoursType"] = GVHoursType.Rows[intCnt].Cells[1].Text;
                dr["FromDate"] = GVHoursType.Rows[intCnt].Cells[2].Text;
                dr["ToDate"] = GVHoursType.Rows[intCnt].Cells[2].Text;
                dt.Rows.Add(dr);
            }
        }

        dr = dt.NewRow();
        dr["Name"] = TxtName.Text;
        dr["HoursType"] = ItemsVal;
        dr["FromDate"] = TxtFromDatePop.Text;
        dr["ToDate"] = TxtToDatePop.Text;
        dt.Rows.Add(dr);
        GVHoursType.DataSource = dt;
        GVHoursType.DataBind();

        lblErrorMsgPop.Text = "";
        TxtFromDatePop.Text = "";
        TxtName.Text = "";
        TxtToDatePop.Text = "";
    }
    /// <summary>
    /// Change Event for DdlMonth
    /// </summary>
    /// <param name="sender">DdlMonth</param>
    /// <param name="e">Index Change</param>
    protected void DdlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

        GetStartEndDate();

        txtFromDate.Text = HFStartDate.Value;
        txtToDate.Text = HFEndDate.Value;

    }

    /// <summary>
    /// Text Change of TxtYeart
    /// </summary>
    /// <param name="sender">txtYear</param>
    /// <param name="e">Text Change</param>
    protected void TxtYear_OnTextChanged(object sender, EventArgs e)
    {
        txtFromDate.Text = DateFormat(DateTime.Parse("01" + "-" + GetMonthName(int.Parse(DdlMonth.SelectedValue)) + "-" + txtYear.Text).ToString("dd-MMM-yyyy"));
        txtToDate.Text = DateFormat(DateTime.Parse(LastDateOfMonth(txtFromDate.Text) + "-" + GetMonthName(int.Parse(DdlMonth.SelectedValue)) + "-" + txtYear.Text).ToString("dd-MMM-yyyy"));
    }

    /// <summary>
    /// Index change of DdlReportName
    /// </summary>
    /// <param name="sender">DdlReportName</param>
    /// <param name="e">Index Change</param>
    protected void DdlReportName_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAttendanceType();
        ShowHideReportParameterControles();
        DdlBranch.CheckBoxes = ddlReportName.SelectedValue == "LocationwiseWOReport" || ddlReportName.SelectedValue == "UnitReg3mnthComparision";
        ddlHourType.AutoPostBack = ddlReportName.SelectedValue == "UnitReg3mnthComparision";
    }

    /// <summary>
    /// Index change of DdlDivision
    /// </summary>
    /// <param name="sender">DdlDivision</param>
    /// <param name="e">Change</param>
    protected void DdlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBranch();
    }

    /// <summary>
    /// BtnViewReport Click
    /// </summary>
    /// <param name="sender">BtnViewReport</param>
    /// <param name="e">Click event</param>
    protected void BtnViewReport_Click(object sender, EventArgs e)
    {
        if (ddlReportName.SelectedIndex < 0)
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            ddlReportName.Focus();
            return;
        }

        lblErrorMsg.Text = string.Empty;
        if (ValidateControles(ddlReportName.SelectedItem.Value))
        {

            BtnRptView_Click(null, null);
        }
    }

    /// <summary>
    /// Click Event of BtnReturn
    /// </summary>
    /// <param name="sender">BtnReturn</param>
    /// <param name="e">Click</param>
    protected void BtnReturn_Click(object sender, EventArgs e)
    {

        PanelReportType.Visible = true;
        FillddlReportName();
        FillDivision();
        FillBranch();
        ShowHideReportParameterControles();
    }

    /// <summary>
    /// Validates the control events
    /// </summary>
    /// <param name="strReportName">Validates Report Elements</param>
    /// <returns>true/false</returns>
    private bool ValidateControles(string strReportName)
    {
        switch (strReportName)
        {
            case "UnitReg3mnthComparision":
                if (ddlAttendaneType.SelectedIndex < 0)
                {
                    lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                    ddlAttendaneType.Focus();
                    return false;
                }

                if (TxtAssign.Text == string.Empty)
                {

                    lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                    ddlHourType.Focus();
                    return false;
                }

                if (DdlDivision.SelectedIndex < 0)
                {
                    lblErrorMsg.Text = Resources.Resource.PleaseSelectDivision;
                    DdlDivision.Focus();
                    return false;
                }

                var loc1 = DdlBranch.CheckedItems;

                var ddlLoc1 = string.Empty;

                if (loc1.Count > 0)
                {
                    ddlLoc1 = loc1.Aggregate(ddlLoc1, (current, item) => current + item.Value.ToString() + ",");
                }

                if (ddlLoc1 == string.Empty)
                {
                    lblErrorMsg.Text = Resources.Resource.PleaseSelectBranch;
                    DdlBranch.Focus();
                    return false;
                }
                return true;

            case "UnitRegSummaryComparisionFss":
                return true;

            case "LocationwiseWOReport":
                if (ddlAttendaneType.SelectedIndex < 0)
                {
                    lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                    ddlAttendaneType.Focus();
                    return false;
                }

                var hour = ddlHourType.CheckedItems;

                var ddlHour = string.Empty;

                if (hour.Count > 0)
                {
                    ddlHour = hour.Aggregate(ddlHour, (current, item) => current + item.Value.ToString() + ",");
                }

                if (ddlHour == string.Empty)
                {
                    lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                    ddlHourType.Focus();
                    return false;
                }

                if (DdlDivision.SelectedIndex < 0)
                {
                    lblErrorMsg.Text = Resources.Resource.PleaseSelectDivision;
                    DdlDivision.Focus();
                    return false;
                }

                var loc = DdlBranch.CheckedItems;

                var ddlLoc = string.Empty;

                if (loc.Count > 0)
                {
                    ddlLoc = loc.Aggregate(ddlLoc, (current, item) => current + item.Value.ToString() + ",");
                }

                if (ddlLoc == string.Empty)
                {
                    lblErrorMsg.Text = Resources.Resource.PleaseSelectBranch;
                    DdlBranch.Focus();
                    return false;
                }

                if (txtToDate.Text != string.Empty && txtFromDate.Text != string.Empty)
                {
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
                    //=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    lblErrorMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                    return false;
                }
                lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                return false;
            case "ClientWiseOTFss":

                if (DdlDivision.SelectedIndex < 0)
                {
                    lblErrorMsg.Text = Resources.Resource.PleaseSelectDivision;
                    DdlDivision.Focus();
                    return false;
                }

                if (DdlBranch.SelectedIndex < 0)
                {
                    lblErrorMsg.Text = Resources.Resource.PleaseSelectBranch;
                    DdlBranch.Focus();
                    return false;
                }

                if (txtToDate.Text != string.Empty && txtFromDate.Text != string.Empty)
                {
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
                    //=====================================================================

                    if (!GetGreaterDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text)))
                    {
                        return true;
                    }
                    lblErrorMsg.Text = Resources.Resource.FromDateCannotGrtToDate;
                    return false;
                }
                lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                return false;
            default:
                return false;
        }
    }

    /// <summary>
    /// Reports the parameter_ get.
    /// </summary>
    /// <returns>System.Collections.Generic.List{ReportParameter}.</returns>
    private List<ReportParameter> ReportParameter_Get()
    {
        //Comma seprated value for Branch(multiple selection )
        var loc = DdlBranch.CheckedItems;

        var ddlLoc = string.Empty;

        if (loc.Count > 0)
        {
            ddlLoc = loc.Aggregate(ddlLoc, (current, item) => current + item.Value.ToString() + ",");
        }

        var hour = ddlHourType.CheckedItems;

        var ddlHour = string.Empty;

        if (hour.Count > 0)
        {
            ddlHour = hour.Aggregate(ddlHour, (current, item) => current + item.Value.ToString() + ",");
        }
        var connectionstring = BaseCountryCode;

        var objCon = new ConnectionString();
        DataTable dt = objCon.ConnectionStringGet(connectionstring, "1");

        switch (ddlReportName.SelectedValue)
        {
            case "UnitReg3mnthComparision":
                var rptParamList2 = new List<ReportParameter>
                                     {
                                         new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0,1),
                                                             BaseCompanyCode),
                                         new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0,1),
                                                             DdlDivision.SelectedValue),
                                         new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0,1), ddlLoc),
                                         new ReportParameter("HoursType", TxtAssign.Text),
                                         new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                                         new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                                         new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),
                                                             dt.Rows[0][4].ToString()),
                                         new ReportParameter("Password", dt.Rows[0][5].ToString()),
                                         new ReportParameter("ReportCulture",CultureInfo.CurrentCulture.Name)

                                     };
                return rptParamList2;
            case "ClientWiseOTFss":
                var rptParamList = new List<ReportParameter>
                                     {
                                         new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0,1),
                                                             BaseCompanyCode),
                                         new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0,1),
                                                             DdlDivision.SelectedValue),
                                         new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0,1), DdlBranch.SelectedValue),
                                         new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1),
                                                             Common.DateFormat(txtFromDate.Text,
                                                                                  new CultureInfo("en-US"))),
                                         new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1),
                                                             Common.DateFormat(txtToDate.Text,
                                                                                  new CultureInfo("en-US"))),

                                         new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                                         new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                                         new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),
                                                             dt.Rows[0][4].ToString()),
                                         new ReportParameter("Password", dt.Rows[0][5].ToString()),
                                         new ReportParameter("ReportCulture",CultureInfo.CurrentCulture.Name)

                                     };
                return rptParamList;
            case "LocationwiseWOReport":
                var rptParamList1 = new List<ReportParameter>
                                     {
                                         new ReportParameter(DL.Properties.Resources.CompanyCode.Remove(0,1),
                                                             BaseCompanyCode),
                                         new ReportParameter(DL.Properties.Resources.HrLocationCode.Remove(0,1),
                                                             DdlDivision.SelectedValue),
                                         new ReportParameter(DL.Properties.Resources.LocationCode.Remove(0,1), ddlLoc),
                                         new ReportParameter(DL.Properties.Resources.FromDate.Remove(0, 1),
                                                             Common.DateFormat(txtFromDate.Text,
                                                                                  new CultureInfo("en-US"))),
                                         new ReportParameter(DL.Properties.Resources.ToDate.Remove(0, 1),
                                                             Common.DateFormat(txtToDate.Text,
                                                                                  new CultureInfo("en-US"))),
                                        new ReportParameter("AttendanceType", ddlAttendaneType.SelectedValue),
                                         new ReportParameter("Type", ddlHour),

                                         new ReportParameter("RptServerName", dt.Rows[0][2].ToString()),
                                         new ReportParameter("RptDatabaseName", dt.Rows[0][3].ToString()),
                                         new ReportParameter(DL.Properties.Resources.UserName.Remove(0,1),
                                                             dt.Rows[0][4].ToString()),
                                         new ReportParameter("Password", dt.Rows[0][5].ToString()),
                                         new ReportParameter("ReportCulture",CultureInfo.CurrentCulture.Name)

                                     };
                return rptParamList1;
        }
        return null;
    }

    #endregion

}


