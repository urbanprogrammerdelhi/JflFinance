// ***********************************************************************
// Author           : Manish.
// Created          : 06-11-2013
//
// Last Modified By : Manish.
// Last Modified On : 03-14-2014
// ***********************************************************************
// <copyright file="ScheduleRosterEmpWise.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
/// <summary>
/// ScheduleRosterEmpWise class
/// </summary>
public partial class Transactions_ScheduleRosterEmpWise : BasePage
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
                int virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception("Have not Rights", ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is write access.
    /// </summary>
    /// <value><c>true</c> if this instance is write access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsWriteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception("Have not Rights", ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is modify access.
    /// </summary>
    /// <value><c>true</c> if this instance is modify access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght;
                virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsModifyAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception("Have not Rights", ex);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is delete access.
    /// </summary>
    /// <value><c>true</c> if this instance is delete access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int virtualDirNameLenght = int.Parse(HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsDeleteAllowed(HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception("Have not Rights", ex);
            }
        }
    }

    #endregion Properties

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (IsReadAccess)
            {
                hfSelectedGridPageCount.Value = "1"; // Set The First Page Number
                hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
                HFCurrentSessionID.Value = HttpContext.Current.Session.SessionID;
                txtYear.Text = DateTime.Now.Year.ToString();
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

                if (Request.QueryString["ClientCode"] != "" && Request.QueryString["ClientCode"] != null)
                {
                    ddlMonth.SelectedValue = Request.QueryString["Month"].Trim();//DateTime.Parse((Request.QueryString["Month"].ToString())).ToString("MM");
                    txtYear.Text = DateTime.Parse((Request.QueryString["DutyDate"])).ToString("yyyy");
                    hfParentDate.Value = Request.QueryString["DutyDate"].Trim();
                    hfParentClientCode.Value = Request.QueryString["ClientCode"].Trim();
                    hfParentAsmtID.Value = Request.QueryString["AsmtCode"].Trim();
                    hfParentPostCode.Value = Request.QueryString["Post"].Trim();

                }

                var objRoster = new BL.Roster();
                btnBack.Attributes["OnClick"] = "javascript:if(event.keyCode==13){return false;}else{LoadScheduleDetailsOnClientClick('" + "Back" + "')};";

                using (DataSet ds = objRoster.GetOTAndMaxDutyMinutesInWeekGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        HFDutyMinCheck.Value = ds.Tables[0].Rows[0]["SchEmpMaxDutyMinInWeek"].ToString() == "" ? "0" : ds.Tables[0].Rows[0]["SchEmpMaxDutyMinInWeek"].ToString();
                        HFOTReason.Value = ds.Tables[1].Rows[0]["OTReason"].ToString() == "" ? "0" : ds.Tables[1].Rows[0]["OTReason"].ToString();
                        HFActualDutyReplacement.Value = ds.Tables[2].Rows[0]["ActualDutyReplacement"].ToString() == "" ? "0" : ds.Tables[2].Rows[0]["ActualDutyReplacement"].ToString();


                    }
                    else
                    {
                        HFDutyMinCheck.Value = "0";
                        HFActualDutyReplacement.Value = "0";
                    }
                }

                FillAdjustmentHeads();

                if (ddlAttendanceType.SelectedValue == "SCH")
                {
                    ddlScheduleType.Enabled = true;
                }
                else{
                    FillDutyReplacedReason();
                    ddlScheduleType.Enabled = false;
                }
               
                HidCon.Value = BaseCountryCode;
                //HidCon.Value = new EncryptDecrypt(SysParam.GetSaltkey).Encrypt(BaseCountryCode);
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }

    }


    /// <summary>
    /// To Get All Employees Based on Area ID
    /// </summary>

    protected void FillEmployeeList()
    {
        var objHrManagement = new BL.HRManagement();
        ddlEmployees.Items.Clear();
        using (var ds = objHrManagement.EmployeesScheduleGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, HFFromDate.Value, HFToDate.Value, ddlArea.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge))
        {
            ds.Tables[0].DefaultView.Sort = "EmployeeName";
            ddlEmployees.DataSource = ds.Tables[0];
        }
        ddlEmployees.DataValueField = "EmployeeNumber";
        ddlEmployees.DataTextField = "EmployeeName";
        ddlEmployees.DataBind();

    }

    /// <summary>
    /// Handles the Click event of the btnProceed control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnProceed_Click(object sender, EventArgs e)
    {

        if (ddAssignment.SelectedValue != "")
        {
            if (txtYear.Text == "")
            {
                txtYear.Text = DateTime.Now.ToString("yyyy");
            }
            FillMenu();
            FillGridDetails("Proceed");
            gvScheduleRoster.Style["display"] = "block";
            HFEditColumnIndex.Value = HFColumnIndex.Value;
            if (BaseIsAdmin.Trim().ToLower() != "c")
            {
                if (IsWriteAccess && IsModifyAccess && IsDeleteAccess)
                {
                    RowsInEditMode("ColumnClick", HFRowIndex.Value, HFColumnIndex.Value);
                }
            }
        }
        else
        {
            gvScheduleRoster.Style["display"] = "none";
        }
    }

    /// <summary>
    /// Handles the OnClick event of the btnEditMode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnEditMode_OnClick(object sender, EventArgs e)
    {
        if (ddlPost.SelectedValue != "")
        {
            HFEditColumnIndex.Value = HFColumnIndex.Value;
            if (BaseIsAdmin.Trim().ToLower() != "c")
            {
                if (IsWriteAccess && IsModifyAccess && IsDeleteAccess)
                {
                    RowsInEditMode("ColumnClick", HFRowIndex.Value, HFColumnIndex.Value);
                }
            }
        }
        else
        {
            gvScheduleRoster.Style["display"] = "none";
        }
    }

    /// <summary>
    /// Fill Employee List on Search employee click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFillEmployee_OnClick(object sender, EventArgs e)
    {
        if (hfOldWeek.Value != "")
        {
            if (hfOldWeek.Value != ddlWeek.SelectedValue)
            {
                gvScheduleRoster.DataSource = null;
                gvScheduleRoster.DataBind();
                btnProceed.Enabled = true;


            }
        }
        hfOldWeek.Value = "";
        FillEmployeeList();
    }

    /// <summary>
    /// Fills the grid details.
    /// </summary>
    /// <param name="strControlId">The STR control ID.</param>
    private void FillGridDetails(string strControlId)
    {
        FormatDataSet(HFEmployeeSearch.Value);
        try
        {
            var txtEmployeeSearch = (TextBox)gvScheduleRoster.HeaderRow.FindControl("txtEmployeeSearch");
            if (txtEmployeeSearch != null)
            {
                txtEmployeeSearch.Text = HFEmployeeSearch.Value;
            }
        }
        catch (Exception ex)
        {
            ExceptionLog(ex);
        }
    }

    /// <summary>
    /// Formats the data set to bind the Grid.
    /// </summary>
    private void FormatDataSet(string searchEmployeeNumber)
    {
        var objRoster = new BL.Roster();
        DataSet ds;
        if (txtYear.Text == "")
        {
            txtYear.Text = DateTime.Now.ToString("yyyy");
        }
        if (txtYear.Text == "" || int.Parse(txtYear.Text) < int.Parse("1900") || int.Parse(txtYear.Text) > int.Parse("2999"))
        {
            txtYear.Text = "";
            Show("Invalid Year");
            txtYear.Text = DateTime.Now.ToString("yyyy");
            return;
        }

        if ((hfAreaNewValue.Value != hfAreaOldValue.Value) || (hfAreaNewValue.Value == "" && hfAreaOldValue.Value == ""))
        {
            if (hfAreaNewValue.Value == "" && hfAreaOldValue.Value == "" && ddlEmployees.Items.Count == 0)
            {
                FillEmployeeList();
                UpdatePanel2.Update();
            }
            else
            {
                if (hfAreaNewValue.Value != hfAreaOldValue.Value)
                {
                    FillEmployeeList();
                    UpdatePanel2.Update();
                }

            }
        }
        if (ddAssignment.SelectedValue != "" && ddlPost.SelectedValue != "")
        {
            var row = gvScheduleRoster.BottomPagerRow;
            if (row == null)
            {
                hfSelectedGridPageCount.Value = hfSelectedGridPageCountFinal.Value;
            }
            else
            {
                if (row.Visible == false)
                    row.Visible = true;

                var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");

                hfSelectedGridPageCount.Value = hfSelectedGridPageCountFinal.Value != "0" ? hfSelectedGridPageCountFinal.Value : ddlPages.SelectedItem.Text;
            }

            if (ddlAttendanceType.SelectedValue.Trim().ToLower() == "Act".Trim().ToLower())
            {
                ds = objRoster.RosterEmployeeWiseGetAll(ddlClient.SelectedValue, ddAssignment.SelectedValue, BaseLocationAutoID, HFFromDate.Value, HFToDate.Value, ddlPost.SelectedValue, ddlScheduleType.SelectedValue, searchEmployeeNumber, hfSelectedGridPageCount.Value, ddlArea.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
            }
            else
            {
                ds = objRoster.EmployeeWiseScheduleRosterGetAll(ddlClient.SelectedValue, ddAssignment.SelectedValue, BaseLocationAutoID, HFFromDate.Value, HFToDate.Value, ddlPost.SelectedValue, ddlScheduleType.SelectedValue, searchEmployeeNumber, hfSelectedGridPageCount.Value, ddlArea.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
            }
        }
        else
        {
            return;
        }

        hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {

            HFSoType.Value = ds.Tables[6].Rows[0]["SoType"].ToString();
            HFSOBillable.Value = Convert.ToString(ds.Tables[6].Rows[0]["SoBillable"]);      //Added for SAT#036
            try
            {
                gvScheduleRoster.PageSize = int.Parse(ds.Tables[7].Rows[0]["PageSize"].ToString());
            }
            catch (Exception ex)
            {
                gvScheduleRoster.PageSize = 20;
                ExceptionLog(ex);
            }

            hfGridPageCount.Value = ds.Tables[3].Rows[0]["TotalRecords"].ToString();
            DataTable dsResult = ds.Tables[5].Copy();
            dsResult.Columns.Add("WageRateStatus");


            var ts = DateTime.Parse(HFToDate.Value).Subtract(DateTime.Parse(HFFromDate.Value));
            var t = int.Parse(ts.Days.ToString()) + 1;

            var dttempDate = DateTime.Parse(HFFromDate.Value);

            ViewState["ReqSch"] = ds.Tables[1];

            for (int j = 0; j < t; j++)
            {
                string strColName = Convert.ToString(dttempDate.ToString(Resources.Resource.ScheduleDefaultDateFormat));
                var strColNo = new DataColumn(strColName);
                dsResult.Columns.Add(strColNo);
                dttempDate = dttempDate.AddDays(double.Parse("1"));
            }
            var totalRecordsCount = ds.Tables[4].Rows[0]["SortExp"].ToString();
            var dv = new DataView(ds.Tables[2]);
            var dutyMin = "0";
            var strWageRateStatus = string.Empty;
            dsResult.DefaultView.Sort = "tmpEmployeeNumber Asc";
            ds.Tables[0].DefaultView.Sort = "tmpEmployeeNumber Asc";
            for (var j = 0; j < dsResult.Rows.Count; j++)
            {

                var dv1 = new DataView(ds.Tables[0]);
                var filterCondition = "[tmpEmployeeNumber]='" + (dsResult.Rows[j]["tmpEmployeeNumber"]) + "' AND " + "[PatternPosition]='" + dsResult.Rows[j]["PatternPosition"] + "' AND " + "[ShiftPatternCode]='" + dsResult.Rows[j]["ShiftPatternCode"] + "'";
                dv1.RowFilter = filterCondition;

                foreach (DataRowView drV1 in dv1)
                {
                    var str = DateTime.Parse(drV1["DutyDate"].ToString()).ToString(Resources.Resource.ScheduleDefaultDateFormat);
                    if (dsResult.Rows[j]["tmpEmployeeNumber"].ToString() == "" && drV1["tmpEmployeeNumber"].ToString() == "")
                    {
                        if (dsResult.Rows[j]["SoRank"].ToString().Trim() == drV1["SoRank"].ToString().Trim())
                        {
                            dsResult.Rows[j][DateTime.Parse(str).ToString(Resources.Resource.ScheduleDefaultDateFormat).ToLower()] = drV1["EmpDetails"].ToString();
                        }
                    }
                    else if (dsResult.Rows[j]["RowNumber"].ToString().Trim() == drV1["RowNumber"].ToString().Trim() &&
                             dsResult.Rows[j]["PatternPosition"].ToString().Trim() == drV1["PatternPosition"].ToString().Trim() &&
                             dsResult.Rows[j]["ShiftPatternCode"].ToString().Trim() == drV1["ShiftPatternCode"].ToString().Trim() &&
                             dsResult.Rows[j]["tmpEmployeeNumber"].ToString().ToLower().Trim() == drV1["tmpEmployeeNumber"].ToString().ToLower().Trim()
                    )
                    {
                        dsResult.Rows[j][DateTime.Parse(str).ToString(Resources.Resource.ScheduleDefaultDateFormat).ToLower()] = drV1["EmpDetails"].ToString();
                        dv.RowFilter = "[EmployeeNumber]='" + (dsResult.Rows[j]["EmployeeNumber"]) + "'";
                        foreach (DataRowView drV in dv)
                        {
                            dutyMin = (drV["DutyMin"].ToString());
                            strWageRateStatus = drV["WageRateStatus"].ToString();
                        }
                        dsResult.Rows[j]["DutyMin"] = dutyMin;
                        dsResult.Rows[j]["WageRateStatus"] = strWageRateStatus;
                    }
                }



            }
            ds.Dispose();
            var z = 12; //  INCREASE THIS VALUE IF NEW COLUMN IS ADDED IN DATASET dsResult
            const int intRemainingColumn = 12; //  INCREASE THIS VALUE IF NEW COLUMN IS ADDED IN DATASET dsResult
            if (ddlScheduleType.SelectedValue.Trim().ToLower() == "Weekly".Trim().ToLower())
            {
                for (var k = 1; k <= int.Parse(dsResult.Columns.Count.ToString()) - intRemainingColumn; k++)
                {
                    dsResult.Columns[z].ColumnName = k.ToString();
                    z++;
                }
            }
            else
            {
                var strStartDay = HFFromDate.Value.Substring(0, 2);
                var strEndDay = HFToDate.Value.Substring(0, 2);
                int daysDiff;
                if (int.Parse(strEndDay) >= int.Parse(strStartDay))
                {
                    daysDiff = (int.Parse(strEndDay) - int.Parse(strStartDay));
                    daysDiff = daysDiff + 2;
                }
                else
                {
                    int daysCount = 0;
                    for (int m = 1; m <= int.Parse(strEndDay); m++)
                    {
                        daysCount = daysCount + 1;
                    }
                    daysDiff = daysCount + (31 - int.Parse(strStartDay) + 1) + 1;
                }
                for (int r = daysDiff; r <= 31; r++)
                {
                    string strColName = r.ToString();
                    var strColNo = new DataColumn(strColName);
                    dsResult.Columns.Add(strColNo);
                }
                for (var k = 1; k <= int.Parse(dsResult.Columns.Count.ToString()) - intRemainingColumn; k++)
                {
                    dsResult.Columns[z].ColumnName = k.ToString();
                    z++;
                }
                if (int.Parse(dsResult.Columns.Count.ToString()) - intRemainingColumn == 28)
                {
                    const string strColName29 = "29";
                    var strColNo29 = new DataColumn(strColName29);
                    dsResult.Columns.Add(strColNo29);
                    const string strColName30 = "30";
                    var strColNo30 = new DataColumn(strColName30);
                    dsResult.Columns.Add(strColNo30);
                    const string strColName31 = "31";
                    var strColNo31 = new DataColumn(strColName31);
                    dsResult.Columns.Add(strColNo31);
                }
                else if (int.Parse(dsResult.Columns.Count.ToString()) - intRemainingColumn == 30)
                {
                    const string strColName31 = "31";
                    var strColNo31 = new DataColumn(strColName31);
                    dsResult.Columns.Add(strColNo31);
                }
                else if (int.Parse(dsResult.Columns.Count.ToString()) - intRemainingColumn == 29)
                {
                    const string strColName30 = "30";
                    var strColNo30 = new DataColumn(strColName30);
                    dsResult.Columns.Add(strColNo30);
                    const string strColName31 = "31";
                    var strColNo31 = new DataColumn(strColName31);
                    dsResult.Columns.Add(strColNo31);
                }
            }

            DataTable dsFinal = dsResult.Copy();
            dsResult.Dispose();
            dsFinal.DefaultView.Sort = totalRecordsCount;
            ds.Dispose();
            if (dsFinal.Rows.Count > 0)
            {
                if (hfSelectedGridPageCountFinal.Value != "0")
                {
                    gvScheduleRoster.PageIndex = int.Parse(hfSelectedGridPageCountFinal.Value);
                }

                gvScheduleRoster.DataSource = dsFinal;
                gvScheduleRoster.DataBind();
                HFNumberOfRowsInGrid.Value = gvScheduleRoster.Rows.Count.ToString();
            }
            else
            {
                gvScheduleRoster.DataSource = null;
                gvScheduleRoster.DataBind();
            }
        }
        else
        {
            gvScheduleRoster.DataSource = null;
            gvScheduleRoster.DataBind();
        }
        int gridViewWidth;
        if (ddlScheduleType.SelectedValue.Trim().ToLower() == "Monthly".Trim().ToLower())
        {
            gridViewWidth = 350 * 1 + 100 * 34;
        }
        else if (ddlScheduleType.SelectedValue.Trim().ToLower() == "Weekly".Trim().ToLower())
        {
            gridViewWidth = 350 * 1 + 100 * 8;
        }
        else
        {
            var strStartDay = HFFromDate.Value.Substring(0, 2);
            var strEndDay = HFToDate.Value.Substring(0, 2);
            int daysDiff;
            if (int.Parse(strEndDay) >= int.Parse(strStartDay))
            {
                daysDiff = (int.Parse(strEndDay) - int.Parse(strStartDay));

                daysDiff = daysDiff + 2;
            }
            else
            {
                var daysCount = 0;

                for (int m = 1; m <= int.Parse(strEndDay); m++)
                {
                    daysCount = daysCount + 1;
                }

                daysDiff = daysCount + (31 - int.Parse(strStartDay) + 1) + 1;

                var totalDays = DateTime.DaysInMonth(int.Parse(txtYear.Text), int.Parse(ddlMonth.SelectedValue));
                switch (totalDays)
                {
                    case 30:
                        daysDiff = daysDiff - 1;
                        break;
                    case 28:
                        daysDiff = daysDiff - 3;
                        break;
                    case 29:
                        daysDiff = daysDiff - 2;
                        break;
                }
            }

            gridViewWidth = 350 * 1 + daysDiff * 100;
        }
        gvScheduleRoster.Width = gridViewWidth;

    }

    /// <summary>
    /// Fills the menu.
    /// </summary>
    private void FillMenu()
    {
        FillRadContextMenu();
    }

    /// <summary>
    /// Adds the sub main item in menu.
    /// </summary>
    /// <param name="dr">The dr.</param>
    /// <param name="node">The node.</param>
    private void AddSubMainItemInMenu(DataRow dr, RadMenuItem node)
    {
        foreach (DataRow subMainItem in dr.GetChildRows("Parent"))
        {
            var menuItemNameFromSql = subMainItem["MenuItemName"].ToString().Trim();
            var menuItemName = menuItemNameFromSql.Replace(" ", "");

            var subParentItem = new RadMenuItem(ResourceValueOfKey_Get(menuItemName.Trim()));
            subParentItem.Attributes.Add("OnClick", subMainItem["FuncationName"].ToString());
            node.Items.Add(subParentItem);
            AddSubMainItemInMenu(subMainItem, subParentItem);
        }
    }

    /// <summary>
    /// Fills the RAD context menu.
    /// </summary>
    private void FillRadContextMenu()
    {
        RadContextMenu.Items.Clear();
        var rosterObj = new BL.Roster();
        using (DataSet ds = rosterObj.MenuItemPopupGet(BaseLocationAutoID, ddlAttendanceType.SelectedValue))
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ds.Relations.Add("Parent", ds.Tables[0].Columns["MenuAutoID"], ds.Tables[0].Columns["ParentMenuAutoID"]);

                foreach (DataRow parentItem in ds.Tables[0].Rows)
                {
                    if (parentItem["ParentMenuAutoID"].ToString() == "")
                    {
                        var menuItemNameFromSql = parentItem["MenuItemName"].ToString().Trim();

                        var menuItemName = menuItemNameFromSql.Replace(" ", "");
                        switch (menuItemName)
                        {
                            case "DutyReplacement":
                                if (HFActualDutyReplacement.Value == "1")
                                {
                                    var mainItem = new RadMenuItem(ResourceValueOfKey_Get(menuItemName.Trim()));
                                    mainItem.Attributes.Add("OnClick", parentItem["FuncationName"].ToString());
                                    RadContextMenu.Items.Add(mainItem);
                                    AddSubMainItemInMenu(parentItem, mainItem);
                                }
                                break;
                            default:
                                {
                                    var mainItem = new RadMenuItem(ResourceValueOfKey_Get(menuItemName.Trim()));
                                    mainItem.Attributes.Add("OnClick", parentItem["FuncationName"].ToString());
                                    RadContextMenu.Items.Add(mainItem);
                                    AddSubMainItemInMenu(parentItem, mainItem);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Rows the in edit mode.
    /// </summary>
    /// <param name="strClickStatus">The STR click status.</param>
    /// <param name="strCommandArgument">The STR command argument.</param>
    /// <param name="strColumnIndex">Index of the STR column.</param>
    private void RowsInEditMode(string strClickStatus, string strCommandArgument, string strColumnIndex)
    {
        btnProceed.Enabled = false;
        DataSet dsBorrowedEmployee = null;
        ViewState["ReqSch"] = null;
        try
        {
            if (HFRowIndex.Value != "" || ddlAttendanceType.SelectedValue == "Act")
            {
                if (HFRowIndex.Value == "")
                {
                    return;
                }
                if (strClickStatus == "ColumnClick")
                {
                    int selectedRowIndex;
                    int selectedColumnIndex;
                    try
                    {
                        selectedRowIndex = Int32.TryParse(strCommandArgument, out selectedRowIndex) ? Convert.ToInt32(strCommandArgument) : 1;
                        selectedColumnIndex = Int32.TryParse(strColumnIndex, out selectedColumnIndex) ? Convert.ToInt32(strColumnIndex) : 2;
                    }
                    catch (Exception ex)
                    {
                        if (ddlAttendanceType.SelectedValue == "Act")
                        {
                            selectedRowIndex = 1;
                            selectedColumnIndex = 2;
                            ExceptionLog(ex);
                        }
                        else
                        {
                            ExceptionLog(ex);
                            return;
                        }

                    }
                    var txtEmpNumberDutyDate = (TextBox)gvScheduleRoster.Rows[selectedRowIndex].FindControl("txtEmpNumberDutyDate");
                    if (txtEmpNumberDutyDate.Text != "" || ddlAttendanceType.SelectedValue == "Act")
                    {

                        var ts1 = DateTime.Parse(HFToDate.Value).Subtract(DateTime.Parse(HFFromDate.Value));
                        var t1 = int.Parse(ts1.Days.ToString()) + 3;
                        for (var columnIndex = 2; columnIndex < t1; columnIndex++) // Header Rows
                        {
                            var regHeaderIndex1 = columnIndex - 1;
                            var lblReqSch = "lblReqSch" + regHeaderIndex1;
                            var lblReqSch1 = (Label)gvScheduleRoster.HeaderRow.FindControl(lblReqSch);
                            var hfReqSch = "HFReqSch" + regHeaderIndex1;
                            var hfReqSch1 = (HiddenField)gvScheduleRoster.HeaderRow.FindControl(hfReqSch);
                            if (lblReqSch1 != null)
                            {
                                if (hfReqSch1.Value != "")
                                {
                                    lblReqSch1.Text = hfReqSch1.Value;
                                }
                            }
                        }

                        int RegColIndex;
                        if (ddlAttendanceType.SelectedValue != "Act")
                        {
                            foreach (GridViewRow r in gvScheduleRoster.Rows)
                            {
                                if (r.RowType == DataControlRowType.DataRow)
                                {
                                    var ts = DateTime.Parse(HFToDate.Value).Subtract(DateTime.Parse(HFFromDate.Value));
                                    var t = int.Parse(ts.Days.ToString()) + 3;
                                    for (var columnIndex = 2; columnIndex < t; columnIndex++) // To Hide Rows
                                    {
                                        RegColIndex = columnIndex - 1;
                                        var txtHideEmpShiftDutyDate = "txtEmpShiftDutyDate" + RegColIndex;
                                        var txtHideTimeFrom = "txtTimeFrom" + RegColIndex;
                                        var txtHideTimeTo = "txtTimeTo" + RegColIndex;
                                        var lblShowDutyDate = "lblDutyDate" + RegColIndex;
                                        var txtEmpShiftDutyDate2 = (TextBox)r.Cells[columnIndex].FindControl(txtHideEmpShiftDutyDate);
                                        var txtEmpTimeFrom2 = (TextBox)r.Cells[columnIndex].FindControl(txtHideTimeFrom);
                                        var txtEmpTimeTo2 = (TextBox)r.Cells[columnIndex].FindControl(txtHideTimeTo);
                                        var lblShowDutyDate2 = (Label)r.Cells[columnIndex].FindControl(lblShowDutyDate);
                                        var imgbtnUpdateTran = (ImageButton)r.Cells[columnIndex].FindControl("ImgbtnUpdateTran");

                                        if (lblShowDutyDate2.Text == @"00:00-00:00" && txtEmpShiftDutyDate2.Text == @"0")
                                        {
                                            lblShowDutyDate2.Text = @"WO";
                                            r.Cells[columnIndex].BackColor = Color.Gold;
                                        }
                                        else
                                        {
                                            if (txtEmpTimeFrom2.Text != "" && txtEmpTimeTo2.Text != "" && txtEmpShiftDutyDate2.Text != "")
                                            {
                                                lblShowDutyDate2.Text = txtEmpTimeFrom2.Text + @"-" + txtEmpTimeTo2.Text;
                                                if (r.Cells[columnIndex].BackColor == Color.Empty)
                                                {
                                                    if (ddlAttendanceType.SelectedValue.ToLower().Trim() == "SCH".ToLower().Trim())
                                                    {
                                                        if (txtEmpTimeFrom2.Text != @"00:00" && txtEmpTimeTo2.Text != @"00:00" && txtEmpShiftDutyDate2.Text != @"0")
                                                        {
                                                            r.Cells[columnIndex].BackColor = Color.Orange;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        r.Cells[columnIndex].BackColor = Color.White;
                                                    }

                                                }
                                                else
                                                {
                                                    r.Cells[columnIndex].BackColor = r.Cells[columnIndex].BackColor;
                                                }
                                            }
                                        }

                                        if (txtEmpShiftDutyDate2.Visible == false)
                                        {
                                            break;
                                        }
                                        if (imgbtnUpdateTran.Visible)
                                        {
                                            imgbtnUpdateTran.Visible = false;
                                        }
                                        txtEmpShiftDutyDate2.Style["display"] = "none";
                                        txtEmpTimeFrom2.Style["display"] = "none";
                                        txtEmpTimeTo2.Style["display"] = "none";
                                        lblShowDutyDate2.Style["display"] = "block";


                                    }
                                }
                            }
                        }
                        HFColumnIndex.Value = selectedColumnIndex.ToString();
                        HFRowIndex.Value = selectedRowIndex.ToString();

                        var gridRowCount = gvScheduleRoster.Rows.Count;
                        if (ddlAttendanceType.SelectedValue != "Act")
                        {
                            gridRowCount = 1;
                        }
                        for (int p = 0; p < gridRowCount; p++)
                        {
                            if (ddlAttendanceType.SelectedValue == "Act")
                            {
                                selectedRowIndex = p;
                            }
                            var ts = DateTime.Parse(HFToDate.Value).Subtract(DateTime.Parse(HFFromDate.Value));
                            var t = int.Parse(ts.Days.ToString()) + 3;
                            for (var columnIndex = 2; columnIndex < t; columnIndex++)     //// To Make Row In Edit Mode
                            {
                                RegColIndex = columnIndex - 1;

                                var txtEmpShiftDutyDate = "txtEmpShiftDutyDate" + RegColIndex;
                                var txtEmpTimeFrom = "txtTimeFrom" + RegColIndex;
                                var txtEmpTimeTo = "txtTimeTo" + RegColIndex;
                                var lblEmpDutyDate = "lblDutyDate" + RegColIndex;

                                var txtEmpShiftDutyDate1 = (TextBox)gvScheduleRoster.Rows[selectedRowIndex].Cells[columnIndex].FindControl(txtEmpShiftDutyDate);
                                var txtEmpTimeFrom1 = (TextBox)gvScheduleRoster.Rows[selectedRowIndex].Cells[columnIndex].FindControl(txtEmpTimeFrom);
                                var txtEmpTimeTo1 = (TextBox)gvScheduleRoster.Rows[selectedRowIndex].Cells[columnIndex].FindControl(txtEmpTimeTo);
                                var lblEmpDutyDate1 = (Label)gvScheduleRoster.Rows[selectedRowIndex].Cells[columnIndex].FindControl(lblEmpDutyDate);
                                var imgbtnUpdateTran = (ImageButton)gvScheduleRoster.Rows[selectedRowIndex].Cells[columnIndex].FindControl("ImgbtnUpdateTran");
                                imgbtnUpdateTran.Visible = true;
                                imgbtnUpdateTran.Enabled = true;

                                txtEmpShiftDutyDate1.Style["display"] = "block";
                                txtEmpTimeFrom1.Style["display"] = "block";
                                txtEmpTimeTo1.Style["display"] = "block";
                                lblEmpDutyDate1.Style["display"] = "none";

                                if (lblEmpDutyDate1.Text == @"WO")
                                {
                                    gvScheduleRoster.Rows[selectedRowIndex].Cells[columnIndex].BackColor = Color.Gold;
                                }


                                switch (txtEmpShiftDutyDate1.Enabled)
                                {
                                    case false:
                                        txtEmpShiftDutyDate1.Enabled = false;
                                        txtEmpTimeFrom1.Enabled = false;
                                        txtEmpTimeTo1.Enabled = false;
                                        break;
                                }
                            }
                        }

                        if (HFEditColumnIndex.Value != "")
                        {
                            try
                            {
                                RegColIndex = int.Parse(HFEditColumnIndex.Value);
                                var ts = DateTime.Parse(HFToDate.Value).Subtract(DateTime.Parse(HFFromDate.Value));
                                var t = int.Parse(ts.Days.ToString()) + 3;
                                if (RegColIndex < t && RegColIndex >= 2)
                                {
                                    var txtEmpNextShiftDutyDate = "txtEmpShiftDutyDate" + (RegColIndex);

                                    var txtEmpNextShiftDutyDate1 = (TextBox)gvScheduleRoster.Rows[selectedRowIndex].Cells[selectedColumnIndex].FindControl(txtEmpNextShiftDutyDate);
                                    txtEmpNextShiftDutyDate1.Focus();
                                }

                            }
                            catch (Exception ex) { ExceptionLog(ex); }
                        }
                    }
                }
            }
        }
        catch (Exception ex) { ExceptionLog(ex); }
        finally
        {
            if (dsBorrowedEmployee != null)
            {
                dsBorrowedEmployee.Dispose();
            }
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlPages control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
    {
        var row = gvScheduleRoster.BottomPagerRow;
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        gvScheduleRoster.PageIndex = int.Parse(ddlPages.SelectedItem.Text);
        hfSelectedGridPageCount.Value = ddlPages.SelectedItem.Text;
        hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
        FormatDataSet(HFEmployeeSearch.Value);
    }

    /// <summary>
    /// Handles the RowDataBound event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                {
                    var ts = DateTime.Parse(HFToDate.Value).Subtract(DateTime.Parse(HFFromDate.Value));
                    var t = int.Parse(ts.Days.ToString()) + 3;

                    for (var i = 0; i < t; i++)
                    {
                        DataTable reqSchTable;
                        var tempDataTable = new DataTable();
                        var strHeaderDutyDate1 = "lblHeaderDutyDate" + (i + 1);
                        var strTempHeaderDutyDate1 = "lblTempHeaderDutyDate" + (i + 1);
                        var reqSchDiv = "reqDiv" + (i + 1);
                        var reqSch = "lblReqSch" + (i + 1);
                        var reqSch1 = (Label)e.Row.FindControl(reqSch);
                        var reqSchDiv1 = (Panel)e.Row.FindControl(reqSchDiv);


                        var lblHeaderDutyDate1 = (Label)e.Row.FindControl(strHeaderDutyDate1);
                        var lblTempHeaderDutyDate1 = (Label)e.Row.FindControl(strTempHeaderDutyDate1);
                        if (lblHeaderDutyDate1 != null)
                        {
                            //lblHeaderDutyDate1.Text = DateTime.Parse(HFFromDate.Value).AddDays(i).ToString(Resources.Resource.ScheduleDefaultDateFormat);
                            lblHeaderDutyDate1.Text = DateTime.Parse(HFFromDate.Value).AddDays(i).ToString("dd-MMM-yyyy");
                            lblTempHeaderDutyDate1.Text = @"[ " + DateTime.Parse(lblHeaderDutyDate1.Text).ToString("ddd") + @" ]";
                        }

                        if (reqSchDiv1 != null)
                        {
                            reqSchTable = (DataTable)ViewState["ReqSch"];
                            if (lblHeaderDutyDate1 != null)
                            {
                                var dvreqSchTable = new DataView(reqSchTable)
                                {
                                    RowFilter =
                                        "[DutyDate]='" +DateTime.Parse(lblHeaderDutyDate1.Text) + "'"
                                };
                                tempDataTable = dvreqSchTable.ToTable();
                            }
                            if (double.Parse(tempDataTable.Rows[0]["Sch"].ToString()) == 0.0)
                            {
                                reqSchDiv1.BackColor = Color.Gray;
                            }
                            else if (double.Parse(tempDataTable.Rows[0]["Req"].ToString()) == double.Parse(tempDataTable.Rows[0]["Sch"].ToString()))
                            {
                                reqSchDiv1.BackColor = Color.Green;
                            }
                            else if (double.Parse(tempDataTable.Rows[0]["Req"].ToString()) < double.Parse(tempDataTable.Rows[0]["Sch"].ToString()))
                            {
                                reqSchDiv1.BackColor = Color.Red;
                            }
                            else if (double.Parse(tempDataTable.Rows[0]["Req"].ToString()) > double.Parse(tempDataTable.Rows[0]["Sch"].ToString()))
                            {
                                reqSchDiv1.BackColor = Color.Yellow;
                            }
                            reqSch1.Text = tempDataTable.Rows[0]["Req"] + @" / " + tempDataTable.Rows[0]["Sch"];

                            reqSchTable.Dispose();
                            tempDataTable.Dispose();
                        }
                    }
                    ViewState["ReqSch"] = null;
                }
                break;
            case DataControlRowType.DataRow:
                {



                    var lblSerialNumber = (Label)e.Row.FindControl("lblSerialNumber");

                    if (lblSerialNumber != null)
                    {
                        var serialNo = gvScheduleRoster.PageIndex * gvScheduleRoster.PageSize + int.Parse(e.Row.RowIndex.ToString());
                        lblSerialNumber.Text = Convert.ToString((serialNo + 1));
                    }

                    var ibSearchEmployee = (LinkButton)e.Row.FindControl("IBSearchEmployee");
                    var hgPayrateStatus = (HiddenField)e.Row.FindControl("HGPayrateStatus");
                    var lblDutyMin = (Label)e.Row.FindControl("lblDutyMin");
                    var txtEmpNumberDutyDate = (TextBox)e.Row.FindControl("txtEmpNumberDutyDate");
                    var txtPatternPosition = (TextBox)e.Row.FindControl("txtPatternPosition");
                    var txtShiftPatternCode = (TextBox)e.Row.FindControl("txtShiftPatternCode");
                    var hfOrgEmployeeNumber = (HiddenField)e.Row.FindControl("HFOrgEmployeeNumber");
                    var txtEmpNameDutyDate = (TextBox)e.Row.FindControl("txtEmpNameDutyDate");
                    var txtEmpDesignationDesc = (TextBox)e.Row.FindControl("txtEmpDesignationDesc");
                    var hfBorrowedEmployeeStatus = (HiddenField)e.Row.FindControl("hfBorrowedEmployeeStatus");
                    if (hfOrgEmployeeNumber != null)
                    {
                        e.Row.ToolTip = Resources.Resource.EmployeeName + @" : " + txtEmpNameDutyDate.Text + @" [ " + txtEmpNumberDutyDate.Text + @" ] ";
                    }

                    if (ddlAttendanceType.SelectedValue.Trim().ToLower() == "Act".Trim().ToLower())
                    {
                        if (txtPatternPosition != null)
                        {
                            txtPatternPosition.Attributes["readonly"] = "readonly";

                        }
                        if (txtShiftPatternCode != null)
                        {
                            txtShiftPatternCode.Attributes["readonly"] = "readonly";
                        }
                    }


                    if (ibSearchEmployee != null)
                    {
                        ibSearchEmployee.Attributes["OnClick"] = "javascript:SearchEmployeeSkillWise('" + txtEmpNumberDutyDate.ClientID + "');";
                    }

                    if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
                    {
                        if (ibSearchEmployee != null) ibSearchEmployee.Visible = false;
                        if (txtPatternPosition != null) txtPatternPosition.Enabled = false;
                        if (txtShiftPatternCode != null) txtShiftPatternCode.Enabled = false;
                        txtEmpDesignationDesc.Enabled = false;
                        txtEmpNameDutyDate.Enabled = false;
                        txtEmpNumberDutyDate.Enabled = false;
                    }
                    if (txtEmpNumberDutyDate != null)
                    {
                        if (txtEmpNumberDutyDate.Text != "")
                        {
                            txtEmpNameDutyDate.Enabled = false;
                        }
                    }
                    if (hgPayrateStatus != null)
                    {
                        if (hgPayrateStatus.Value.Trim().ToLower() != "OK".Trim().ToLower() && hgPayrateStatus.Value != "")
                        {
                            if (txtEmpNumberDutyDate != null)
                            {
                                txtEmpNumberDutyDate.ForeColor = Color.Red;

                            }
                            if (txtEmpNameDutyDate != null)
                            {
                                txtEmpNameDutyDate.ForeColor = Color.Red;
                            }
                            if (txtEmpDesignationDesc != null)
                            {
                                txtEmpDesignationDesc.ForeColor = Color.Red;
                            }
                            if (txtPatternPosition != null)
                            {
                                txtPatternPosition.ForeColor = Color.Red;
                            }
                            if (txtShiftPatternCode != null)
                            {
                                txtShiftPatternCode.ForeColor = Color.Red;
                            }
                        }
                    }
                    var singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                    string jsSingle = ClientScript.GetPostBackClientHyperlink(singleClickButton, "");
                    // Add events to each editable cell
                    var ts = DateTime.Parse(HFToDate.Value).Subtract(DateTime.Parse(HFFromDate.Value));
                    var t = int.Parse(ts.Days.ToString()) + 3;
                    //  var gridWidth = double.Parse("0");
                    for (var columnIndex = 2; columnIndex < t; columnIndex++)
                    {
                        var hfSchRosterAutoId11 = "HFSchRosterAutoID" + (columnIndex - 1);
                        var txtTimeFrom11 = "txtTimeFrom" + (columnIndex - 1);
                        var txtTimeTo11 = "txtTimeTo" + (columnIndex - 1);
                        var txtEmpShiftDutyDate11 = "txtEmpShiftDutyDate" + (columnIndex - 1);
                        var dutyDate1 = "lblDutyDate" + (columnIndex - 1);
                        var otherAssignmentAutoId = "lblOtherAssignmentAutoId" + (columnIndex - 1);
                        var strLeaveType = string.Empty;
                        var leaveTypeFullPartial = string.Empty;
                        var attendanceConfirmStatus = string.Empty;

                        var hfSchRosterAutoId1 = (HiddenField)e.Row.FindControl(hfSchRosterAutoId11);
                        var txtTimeFrom1 = (TextBox)e.Row.FindControl(txtTimeFrom11);
                        var txtTimeTo1 = (TextBox)e.Row.FindControl(txtTimeTo11);
                        var txtEmpShiftDutyDate1 = (TextBox)e.Row.FindControl(txtEmpShiftDutyDate11);
                        var lblDutyDate1 = (Label)e.Row.FindControl(dutyDate1);
                        var lblotherAssignmentAutoId1 = (Label)e.Row.FindControl(otherAssignmentAutoId);
                        const int flag = 0;
                        //  string allowanceStatus = "0";
                        if (hfSchRosterAutoId1 != null && lblDutyDate1 != null)
                        {

                            txtEmpShiftDutyDate1.BackColor = Color.Empty;
                            var img = new HtmlImage();
                            var jobBreakDownImage = new HtmlImage();
                            var img1 = new HtmlImage();

                            if (lblDutyDate1.Text != "")
                            {
                                string[] empDetails = lblDutyDate1.Text.Split('|');
                                lblotherAssignmentAutoId1.Text = empDetails[2];

                                if (empDetails[8] == "1") // Converted Case
                                {
                                    ibSearchEmployee.Visible = false;
                                    txtPatternPosition.Enabled = false;
                                   // txtShiftPatternCode.Enabled = false;
                                    txtEmpShiftDutyDate1.Enabled = false;
                                    txtEmpNumberDutyDate.Enabled = false;
                                    txtTimeFrom1.Enabled = false;
                                    txtTimeTo1.Enabled = false;
                                }
                                else
                                {
                                    e.Row.Cells[columnIndex].BackColor = Color.Empty;
                                }
                                if (empDetails[22] != "")
                                {
                                    HFSolineStartDate.Value = empDetails[22];
                                    HFSolineEndDate.Value = empDetails[23];
                                }
                                if ((DateTime.Parse(HFSolineStartDate.Value) != DateTime.Parse("01-jan-1900")) && (DateTime.Parse(HFSolineEndDate.Value) != DateTime.Parse("01-jan-1900")))
                                {
                                    var strHeaderDutyDate1 = "lblHeaderDutyDate" + (columnIndex - 1);
                                    var lblHeaderDutyDate1 = (Label)gvScheduleRoster.HeaderRow.FindControl(strHeaderDutyDate1);
                                    if (DateTime.Parse(lblHeaderDutyDate1.Text) < DateTime.Parse(HFSolineStartDate.Value)) // SoLineStartDate Check
                                    {
                                        txtEmpShiftDutyDate1.Enabled = false;
                                        txtTimeFrom1.Enabled = false;
                                        txtTimeTo1.Enabled = false;
                                        txtEmpShiftDutyDate1.BackColor = Color.Gray;
                                        txtTimeFrom1.BackColor = Color.Gray;
                                        txtTimeTo1.BackColor = Color.Gray;
                                    }

                                    if (DateTime.Parse(lblHeaderDutyDate1.Text) > DateTime.Parse(HFSolineEndDate.Value)) // SoLineEndDate Check
                                    {
                                        txtEmpShiftDutyDate1.Enabled = false;
                                        txtTimeFrom1.Enabled = false;
                                        txtTimeTo1.Enabled = false;
                                        txtEmpShiftDutyDate1.BackColor = Color.Gray;
                                        txtTimeFrom1.BackColor = Color.Gray;
                                        txtTimeTo1.BackColor = Color.Gray;
                                    }
                                }

                                var adjustmentHours = empDetails[17];
                                img.ID = "adjustmentImage" + e.Row.RowIndex + columnIndex;
                                img.Src = "../Images/adj.png";
                                img.Height = 10;
                                img.Width = 10;
                                e.Row.Cells[columnIndex].Controls.Add(img);
                                img.Attributes["OnClick"] = "javascript:funcHoursAdjustment('R');";
                                img.Style["display"] = "none";
                                if (adjustmentHours == "1")
                                {
                                    img.Style["display"] = "block";
                                }

                                var dutyReplacement = empDetails[25];
                                img1.ID = "dutyReplacementImage" + e.Row.RowIndex + columnIndex;
                                img1.Src = "../Images/delete.png";
                                img1.Height = 10;
                                img1.Width = 10;
                                e.Row.Cells[columnIndex].Controls.Add(img1);
                                img1.Attributes["OnClick"] = "javascript:OpenDutyReplacement('" + dutyReplacement + "','" + hfSchRosterAutoId1.ClientID + "')";

                                img1.Style["display"] = "none";
                                if (dutyReplacement != "")
                                {
                                    img1.Style["display"] = "block";
                                }

                                var jobBreakDown = empDetails[15];
                                jobBreakDownImage.ID = "jobBreakDownImage" + e.Row.RowIndex + columnIndex;
                                jobBreakDownImage.Src = "../Images/info.gif";
                                jobBreakDownImage.Height = 10;
                                jobBreakDownImage.Width = 10;
                                e.Row.Cells[columnIndex].Controls.Add(jobBreakDownImage);
                                jobBreakDownImage.Attributes["OnClick"] = "javascript:OpenJobBreakDown('" + jobBreakDownImage.ClientID + "');";

                                jobBreakDownImage.Style["display"] = "none";
                                if (jobBreakDown == "1")
                                {
                                    jobBreakDownImage.Style["display"] = "block";
                                }
                                hfSchRosterAutoId1.Value = empDetails[13];
                                if (txtTimeFrom1 != null && txtTimeTo1 != null && txtEmpDesignationDesc != null && txtEmpNameDutyDate != null && txtEmpNumberDutyDate != null && txtEmpShiftDutyDate1 != null)
                                {
                                    txtEmpShiftDutyDate1.Text = empDetails[4];
                                    txtTimeFrom1.Text = empDetails[11];
                                    txtTimeTo1.Text = empDetails[12];
                                }
                                if (txtEmpNumberDutyDate.Text.Trim() != "")
                                {
                                    strLeaveType = empDetails[14];
                                    leaveTypeFullPartial = empDetails[20];
                                    attendanceConfirmStatus = empDetails[21];
                                    if (empDetails[14] == "")   // Leave Type Check
                                    {
                                        if (empDetails[2].Trim() == ddlPost.SelectedValue.Trim())
                                        {
                                            if (txtTimeFrom1.Text != @"0" && txtTimeTo1.Text != @"0")
                                            {
                                                if (txtTimeFrom1.Text == @"00:00" && txtTimeTo1.Text == @"00:00" && txtEmpShiftDutyDate1.Text==@"0")
                                                {
                                                    lblDutyDate1.Text = @"WO";
                                                }
                                                else
                                                {
                                                    lblDutyDate1.Text = txtTimeFrom1.Text + @"-" + txtTimeTo1.Text;
                                                }
                                            }
                                            else
                                            {
                                                lblDutyDate1.Text = "";
                                            }
                                        }
                                        else
                                        {
                                            if (empDetails[2] != "0")
                                            {
                                                lblDutyDate1.Text = empDetails[24]; //To Show Other Post in Grid Cell
                                                lblDutyDate1.Attributes["OnClick"] = "javascript:if(event.keyCode==13){return false;}else{LoadScheduleDetailsOnClientClick('" + lblDutyDate1.ClientID + "')};";
                                                lblDutyDate1.ToolTip = empDetails[16];
                                            }
                                            else
                                            {
                                                lblDutyDate1.Text = "";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (hfSchRosterAutoId1.Value != "0" && hfSchRosterAutoId1.Value != "")
                                        {
                                            lblDutyDate1.Text = txtTimeFrom1.Text + @"-" + txtTimeTo1.Text + '[' + strLeaveType + ']';
                                        }
                                        else
                                        {
                                            lblDutyDate1.Text = strLeaveType;
                                        }
                                    }
                                }
                                else
                                {
                                    lblDutyDate1.Text = "";
                                }


                                if (hfSchRosterAutoId1 != null)
                                {
                                    if (hfSchRosterAutoId1.Value != "0" && hfSchRosterAutoId1.Value != "")
                                    {
                                        if (ibSearchEmployee != null)
                                        {
                                            ibSearchEmployee.Visible = false;
                                        }

                                        if (lblDutyDate1.Text != @"WO")
                                        {
                                            if (ddlAttendanceType.SelectedValue.ToLower().Trim() == "SCH".ToLower().Trim())
                                            {
                                                if (empDetails[2].Trim() == ddlPost.SelectedValue.Trim())
                                                {
                                                    e.Row.Cells[columnIndex].BackColor = Color.Orange;
                                                }
                                            }
                                            else
                                            {
                                                e.Row.Cells[columnIndex].BackColor = Color.White;
                                            }

                                            try
                                            {
                                                if (empDetails[18] != "")
                                                {

                                                    if (ddlAttendanceType.SelectedValue.ToLower().Trim() == "SCH".ToLower().Trim())
                                                    {
                                                        e.Row.Cells[columnIndex].BackColor = Color.FromName(empDetails[18]);
                                                    }
                                                    else
                                                    {
                                                        e.Row.Cells[columnIndex].BackColor = Color.FromName(empDetails[18]);
                                                        if (e.Row.Cells[columnIndex].BackColor == Color.Orange)
                                                        {
                                                            e.Row.Cells[columnIndex].BackColor = Color.White;
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                e.Row.Cells[columnIndex].BackColor = ddlAttendanceType.SelectedValue.ToLower().Trim() == "SCH".ToLower().Trim() ? Color.Orange : Color.White;
                                                ExceptionLog(ex);
                                            }
                                        }
                                        else
                                        {
                                            e.Row.Cells[columnIndex].BackColor = Color.Gold;
                                        }

                                        if (empDetails[9] == "DT00010")
                                        {
                                            e.Row.Cells[columnIndex].Enabled = false;
                                            txtEmpNumberDutyDate.Enabled = false;
                                            txtPatternPosition.Enabled = false;
                                            txtShiftPatternCode.Enabled = false;
                                            txtEmpNameDutyDate.Enabled = false;
                                            txtEmpDesignationDesc.Enabled = false;
                                        }
                                    }
                                }

                                if (hfBorrowedEmployeeStatus != null)
                                {
                                    if (ddlAttendanceType.SelectedValue.ToUpper() == "ACT")
                                    {
                                        txtShiftPatternCode.Enabled = false;
                                    }
                                    //else
                                    //{
                                    //    txtShiftPatternCode.Enabled = hfBorrowedEmployeeStatus.Value != "1";
                                    //}
                                }
                                if (columnIndex >= 2 && columnIndex < e.Row.Cells.Count)
                                {
                                    if (strLeaveType != "")
                                    {
                                        if (strLeaveType.Contains("["))
                                        {
                                            //Leave Cancel Case
                                            e.Row.Cells[columnIndex].BackColor = Color.LawnGreen;
                                        }
                                        else
                                        {
                                            e.Row.Cells[columnIndex].BackColor = leaveTypeFullPartial == "P" ? Color.LightBlue : Color.DeepSkyBlue;
                                        }
                                    }
                                    else
                                    {
                                        if (e.Row.Cells[columnIndex].BackColor == Color.Empty)
                                        {
                                            e.Row.Cells[columnIndex].BackColor = Color.Empty;
                                        }
                                    }
                                }

                                if (ddlAttendanceType.SelectedValue.Trim().ToLower() == "ACT".Trim().ToLower())
                                {
                                    e.Row.Cells[columnIndex].Font.Bold = attendanceConfirmStatus == "1";
                                }

                                if (lblDutyMin != null)
                                {
                                    if (lblDutyMin.Text != "")
                                    {
                                        string[] empDutyMin = lblDutyMin.Text.Split('(');
                                        lblDutyDate1.ForeColor = double.Parse(empDutyMin[0]) > double.Parse(HFDutyMinCheck.Value) ? Color.Red : Color.Empty;
                                    }
                                }
                                if (txtEmpShiftDutyDate1.Enabled == false && txtEmpShiftDutyDate1.BackColor == Color.Gray)
                                {
                                    e.Row.Cells[columnIndex].BackColor = Color.Empty;
                                    txtEmpShiftDutyDate1.Text = string.Empty;
                                    txtTimeFrom1.Text = string.Empty;
                                    txtTimeTo1.Text = string.Empty;
                                }
                            }
                            else
                            {

                                img.ID = "adjustmentImage" + e.Row.RowIndex + columnIndex;
                                img.Src = "../Images/adj.png";
                                img.Height = 10;
                                img.Width = 10;
                                e.Row.Cells[columnIndex].Controls.Add(img);
                                img.Attributes["OnClick"] = "javascript:funcHoursAdjustment('R');";
                                img.Style["display"] = "none";

                                jobBreakDownImage.ID = "jobBreakDownImage" + e.Row.RowIndex + columnIndex;
                                jobBreakDownImage.Src = "../Images/info.gif";
                                jobBreakDownImage.Height = 10;
                                jobBreakDownImage.Width = 10;
                                e.Row.Cells[columnIndex].Controls.Add(jobBreakDownImage);
                                jobBreakDownImage.Style["display"] = "none";
                            }


                        }
                        if (flag == 0)
                        {
                            string js = jsSingle.Insert(jsSingle.Length - 2, columnIndex.ToString());
                            e.Row.Cells[columnIndex].Attributes.Add("onmousedown", "javascript:GetColumnIndexOnMouseClick('" + e.Row.Cells.GetCellIndex(e.Row.Cells[columnIndex]) + "');");
                            e.Row.Cells[columnIndex].Attributes["ondblclick"] = js;
                            e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
                        }
                        string lblSchAutoId11 = "lblSchAutoId" + (columnIndex - 1);
                        var lblSchAutoId1 = (Label)e.Row.FindControl(lblSchAutoId11);
                        lblSchAutoId1.Text = @"$" + hfSchRosterAutoId1.Value + @"#" + DateTime.Parse(HFFromDate.Value).AddDays(columnIndex - 2).ToString(Resources.Resource.ScheduleDefaultDateFormat) + @"$";
                    }
                }
                break;
        }
    }

    /// <summary>
    /// Handles the RowCreated event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_RowCreated(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.DataRow:
                string rowID = "row" + e.Row.RowIndex.ToString(CultureInfo.InvariantCulture);
                e.Row.Attributes.Add("id", rowID);
                e.Row.Attributes.Add("onmousedown", "javascript:GetRowIDOnMouseClick('" + e.Row.RowIndex + "');");
                break;
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument.ToString() == "First" || e.CommandArgument.ToString() == "Prev" || e.CommandArgument.ToString() == "Next" || e.CommandArgument.ToString() == "Last")
        {
            switch (e.CommandArgument.ToString())
            {
                case "First":
                    break;
                case "Prev":
                    HFPagingIndex.Value = "1";
                    break;
                case "Next":
                    HFPagingIndex.Value = "0";
                    break;
                case "Last":
                    HFPagingIndex.Value = "2";
                    if (hfGridPageCount.Value == "")
                    {
                        var row = gvScheduleRoster.BottomPagerRow;
                        var lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
                        hfGridPageCount.Value = lblPageCount.Text;
                    }
                    gvScheduleRoster.PageIndex = int.Parse(hfGridPageCount.Value);
                    hfSelectedGridPageCount.Value = hfGridPageCount.Value;
                    hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
                    break;
            }
        }
        else
        {

            HFRowIndex.Value = e.CommandArgument.ToString();
            HFColumnIndex.Value = Request.Form["__EVENTARGUMENT"];
            if (BaseIsAdmin.Trim().ToLower() != "c")
            {
                if (IsWriteAccess && IsModifyAccess && IsDeleteAccess)
                {
                    if (e.CommandName != "UpdateFooter")
                    {
                        RowsInEditMode(e.CommandName, e.CommandArgument.ToString(), Request.Form["__EVENTARGUMENT"]);
                    }
                    else
                    {
                        FormatDataSet(HFEmployeeSearch.Value);
                        var txtEmployeeSearch = (TextBox)gvScheduleRoster.HeaderRow.FindControl("txtEmployeeSearch");
                        if (txtEmployeeSearch != null)
                        {
                            txtEmployeeSearch.Text = HFEmployeeSearch.Value;
                        }
                        if (gvScheduleRoster.FooterRow.Visible)
                        {
                            gvScheduleRoster.FooterRow.Visible = false;
                        }

                    }
                }
            }
        }


    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        var gvrPager = gvScheduleRoster.BottomPagerRow;
        var ddlPages = (DropDownList)gvrPager.Cells[0].FindControl("ddlPages");
        var lblPageCount = (Label)gvrPager.Cells[0].FindControl("lblPageCount");
        var currentIndex = int.Parse(ddlPages.SelectedItem.Text);
        switch (HFPagingIndex.Value)
        {
            case "1":
                if (currentIndex > 0)
                {
                    hfSelectedGridPageCount.Value = (currentIndex - 1).ToString();
                    hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
                    gvScheduleRoster.PageIndex = (currentIndex - 1);
                    FillGridDetails("Paging");
                }
                else
                {
                    hfSelectedGridPageCount.Value = (currentIndex).ToString();
                    hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
                    gvScheduleRoster.PageIndex = (currentIndex);
                    FillGridDetails("Paging");
                }
                HFPagingIndex.Value = "-1";
                break;
            case "0":
                if (lblPageCount.Text != ddlPages.SelectedItem.Text)
                {
                    hfSelectedGridPageCount.Value = (currentIndex + 1).ToString();
                    hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
                    gvScheduleRoster.PageIndex = (currentIndex + 1);
                    FillGridDetails("Paging");

                }
                else
                {
                    hfSelectedGridPageCount.Value = (lblPageCount.Text);
                    hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
                    gvScheduleRoster.PageIndex = int.Parse(lblPageCount.Text);
                    FillGridDetails("Paging");
                }
                HFPagingIndex.Value = "-1";
                break;
            case "2":
                hfSelectedGridPageCountFinal.Value = hfSelectedGridPageCount.Value;
                gvScheduleRoster.PageIndex = int.Parse(hfSelectedGridPageCount.Value);
                FillGridDetails("Paging");
                HFPagingIndex.Value = "-1";
                break;
            default:
                gvScheduleRoster.PageIndex = int.Parse(hfSelectedGridPageCount.Value);
                break;
        }
        HFRowIndex.Value = "";
        HFColumnIndex.Value = "";
    }

    /// <summary>
    /// Handles the OnRowUpdating event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        hfSelectedGridPageCountFinal.Value = "0";

        FillGridDetails("Proceed");
        HFRowIndex.Value = "";
        HFColumnIndex.Value = "";
    }
    /// <summary>
    /// Handles the DataBound event of the gvScheduleRoster control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void gvScheduleRoster_DataBound(object sender, EventArgs e)
    {
        // HFPost.Value = HFPostPaging.Value;
        var row = gvScheduleRoster.BottomPagerRow;
        if (row == null)
        {
            return;
        }
        if (row.Visible == false)
            row.Visible = true;
        var ddlPages = (DropDownList)row.Cells[0].FindControl("ddlPages");
        var lblPageCount = (Label)row.Cells[0].FindControl("lblPageCount");
        if (ddlPages != null)
        {
            int totalPageCount;
            if (hfGridPageCount.Value == "0")
            {
                totalPageCount = 1;
            }
            else
            {
                if (hfGridPageCount.Value == "")
                {
                    hfGridPageCount.Value = lblPageCount.Text;
                }
                totalPageCount = int.Parse(hfGridPageCount.Value);
            }
            for (var i = 0; i < totalPageCount; i++)
            {
                var intPageNumber = i + 1;
                var lstItem = new ListItem(intPageNumber.ToString());
                if (intPageNumber == int.Parse(hfSelectedGridPageCount.Value))
                {
                    lstItem.Selected = true;
                }
                ddlPages.Items.Add(lstItem);
            }
        }
        if (lblPageCount != null)
        {
            lblPageCount.Text = hfGridPageCount.Value;
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtEmployeeSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeSearch_TextChanged(object sender, EventArgs e)
    {
        var txtEmployeeSearch = (TextBox)gvScheduleRoster.HeaderRow.FindControl("txtEmployeeSearch");
        if (txtEmployeeSearch != null)
        {
            HFEmployeeSearch.Value = txtEmployeeSearch.Text;
            FormatDataSet(HFEmployeeSearch.Value);

            btnProceed.Enabled = false;
            if (gvScheduleRoster.Rows.Count > 0)
            {
                var txtEmployeeSearch1 = (TextBox)gvScheduleRoster.HeaderRow.FindControl("txtEmployeeSearch");
                txtEmployeeSearch1.Text = HFEmployeeSearch.Value;
                gvScheduleRoster.FooterRow.Visible = false;
                var txtEmpNumberDutyDate = (TextBox)gvScheduleRoster.Rows[0].FindControl("txtEmpNumberDutyDate");
                txtEmpNumberDutyDate.Focus();
            }
        }

    }

    /// <summary>
    /// Handles the OnClick event of the btnUnScheduledEmp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnUnScheduledEmp_OnClick(object sender, EventArgs e)
    {
        //if (HFUnSchEmployeeClickStatus.Value != "")
        //{
            gvUnScheduledEmployees.DataSource = null;
            gvUnScheduledEmployees.DataBind();
            FillEmployeeDetail("Bind", "NoBorrow");
        //}
    }

    /// <summary>
    /// To Get Employee Who are not scheduled between the selected date based on the area ID Selected
    /// </summary>
    protected void FillEmployeeDetail(string bindStatus, string borrowEmployeeStatus)
    {
        DataSet ds;

        var objRost = new BL.Roster();
        if (borrowEmployeeStatus == "Borrow")
        {
            using (DataSet dsborrow = objRost.BorrowedEmployeesGetAll(BaseCompanyCode, BaseLocationAutoID, ddlClient.SelectedValue, ddAssignment.SelectedValue, ddlPost.SelectedValue, HFFromDate.Value, HFToDate.Value, ddlArea.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge))
            {
                gvUnScheduledEmployees.DataSource = dsborrow.Tables[0];
                if (bindStatus == "Bind")
                {
                    gvUnScheduledEmployees.DataBind();

                }
            }
            HFUnSchEmployeeClickStatus.Value = "";
            UP3.Update();
            return;
        }

        if (ddlAttendanceType.SelectedValue.Trim().ToLower() == "Sch".Trim().ToLower())
        {
            //Added Area ID option to search only those employee that belongs to that Area
            ds = objRost.EmployeesNotScheduleBetweenDatesGetAll(BaseCompanyCode, BaseLocationAutoID, HFFromDate.Value, HFToDate.Value, HFMaxDate.Value, "Sch", ddlArea.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
        }
        else
        {
            //Added Area ID option to search only those employee that belongs to that Area
            ds = objRost.EmployeesNotScheduleBetweenDatesGetAll(BaseCompanyCode, BaseLocationAutoID, HFFromDate.Value, HFToDate.Value, HFMaxDate.Value, "Act", ddlArea.SelectedValue, BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
        }
        gvUnScheduledEmployees.DataSource = ds.Tables[0];
        if (bindStatus == "Bind")
        {
            gvUnScheduledEmployees.DataBind();
        }
        HFUnSchEmployeeClickStatus.Value = "";
        UP3.Update();
    }

    /// <summary>
    /// Handles the NeedDataSource event of the gvUnScheduledEmployees control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
    protected void gvUnScheduledEmployees_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        if (HFUnSchEmployeeClickStatus.Value != "")
        {
            FillEmployeeDetail("NoBind", "NoBorrow");
        }
    }

    /// <summary>
    /// Handles the Click event of the btnExportToExcel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        gvUnScheduledEmployees.ExportSettings.ExportOnlyData = true;
        gvUnScheduledEmployees.ExportSettings.IgnorePaging = true;
        gvUnScheduledEmployees.ExportSettings.OpenInNewWindow = true;

        gvUnScheduledEmployees.ExportSettings.Excel.Format = GridExcelExportFormat.ExcelML;
        HFUnSchEmployeeClickStatus.Value = "1";
        gvUnScheduledEmployees.MasterTableView.ExportToExcel();
    }

    protected void RadWindowBorrow_Unload()
    {

    }

    /// <summary>
    /// Handles the OnClick event of the btnBorrowedEmp control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnBorrowedEmp_OnClick(object sender, EventArgs e)
    {
        //if (HFUnSchEmployeeClickStatus.Value != "")
        //{
        //    if (btnBorrowedEmp.Text != @"Employees Not Scheduled")
        //    {
                gvUnScheduledEmployees.DataSource = null;
                gvUnScheduledEmployees.DataBind();
                FillEmployeeDetail("Bind", "Borrow");
    //            btnBorrowedEmp.Text = @"Employees Not Scheduled";
    //        }
    //        else
    //        {
    //            gvUnScheduledEmployees.DataSource = null;
    //            gvUnScheduledEmployees.DataBind();
    //            FillEmployeeDetail("Bind", "NoBorrow");
    //            btnBorrowedEmp.Text = @"Borrowed Employees";
    //        }
    //    }
    }

    /// <summary>
    /// Fills the adjustment heads.
    /// </summary>
    private void FillAdjustmentHeads()
    {
        var objMastersManagement = new BL.MastersManagement();
        // DataSet ds = new DataSet();
        using (DataSet ds = objMastersManagement.AdjustmentHeadGetAll(BaseCompanyCode))
        {
            if (ds != null && ds.Tables.Count > 0)
            {
                AdjType.DataSource = ds.Tables[0].DefaultView;
                AdjType.DataTextField = "AdjHeadDesc";
                AdjType.DataValueField = "AdjHeadCode";
                AdjType.DataBind();
            }
        }
    }
    /// <summary>
    /// Fill Duty Replacement
    /// </summary>
    private void FillDutyReplacedReason()
    {
        var objQuickCode = new BL.MastersManagement();
        using (DataSet ds = objQuickCode.GetDutyReplacedReason(BaseCompanyCode))
        {
            ddlDutyReplacement.DataSource = ds.Tables[0];
            ddlDutyReplacement.DataTextField = "ItemDesc";
            ddlDutyReplacement.DataValueField = "ItemCode";
            ddlDutyReplacement.DataBind();
        }
    }

    protected void ddlPost_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        HFRowIndex.Value = "";
    }
}