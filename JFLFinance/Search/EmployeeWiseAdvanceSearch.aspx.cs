// ***********************************************************************
// Assembly         : 
// Author           : Manish.
// Created          : 06-11-2013
//
// Last Modified By : Manish.
// Last Modified On : 08-30-2013
// ***********************************************************************
// <copyright file="EmployeeWiseAdvanceSearch.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using BL;
using Resources;
/// <summary>
/// EmployeeWiseAdvanceSearch class
/// </summary>
public partial class Search_EmployeeWiseAdvanceSearch : BasePage //System.Web.UI.Page
{

    /// <summary>
    /// The is sort
    /// </summary>
    private static bool _isSort = false;
    /// <summary>
    /// The is ascend
    /// </summary>
    private static bool _isAscend = false;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //            string strpostCode = Request.QueryString["PostCode"];

            lblClientCode.Text = Request.QueryString["ClientCode"];
            lblClientName.Text = Request.QueryString["ClientName"];
            lblAsmtCode.Text = Request.QueryString["AsmtID"];
            lblAsmtName.Text = Request.QueryString["AsmtName"];
            lblPostName.Text = Request.QueryString["PostName"];
            HFStatus.Value = "1";

            txtNoOfMonths.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
            txtNoOfMonths.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";

            FillgvEmployeeList(HFStatus.Value);

            var objdlUserManagement = new BL.UserManagement();
            DataSet ds = objdlUserManagement.SystemParameterValuesGetAll("WorkHistoryMonth");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                txtNoOfMonths.Text = Convert.ToString(ds.Tables[0].Rows[0]["ParamValue1"]);
            }
        }
    }

    /// <summary>
    /// Handles the RowCreated event of the gvEmployeeList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        var sortColumnIndex = 0;

        if (e.Row.RowType == DataControlRowType.Header)
            sortColumnIndex = GetSortColumnIndex();

        if (sortColumnIndex != 1)
        {
            AddSortImage(sortColumnIndex, e.Row);
        }

    }
    // 2) Adding a method which will return the Index of the column selected
    /// <summary>
    /// Gets the index of the sort column.
    /// </summary>
    /// <returns>integer value</returns>
    protected int GetSortColumnIndex()
    {

        foreach (DataControlField field in gvEmployeeList.Columns)
        {
            if (field.SortExpression == gvEmployeeList.SortExpression)
                return gvEmployeeList.Columns.IndexOf(field);
            return -1;
        }
        return -1;
    }
    //3) Adding the SortImage Method
    /// <summary>
    /// Adds the sort image.
    /// </summary>
    /// <param name="columnIndex">Index of the column.</param>
    /// <param name="headerRow">The header row.</param>
    protected void AddSortImage(int columnIndex, GridViewRow headerRow)
    {

        //if (showImage) // this is a boolean variable which should be false 
        //{            //  on page load so that image wont show up initially.

        //    if (ViewState["sortDirection"].ToString() == "Ascending")
        //    {
        //        sortImage.ImageUrl = "~/Images/up.gif";
        //        sortImage.AlternateText = " Ascending Order";
        //    }

        //    else
        //    {
        //        sortImage.ImageUrl = "~/Images/down.gif";
        //        sortImage.AlternateText = " Descending Order";
        //    }

        //    HeaderRow.Cells[0].Controls.Add(sortImage);
        //}
    }


    /// <summary>
    /// Sorts the grid view.
    /// </summary>
    /// <param name="sortExpression">The sort expression.</param>
    /// <param name="direction">The direction.</param>
    protected void SortGridView(string sortExpression, string direction)
    {

      var  dt = (DataTable)ViewState["EmployeeList"];



        if (dt != null)
        {
            var dataView = new DataView(dt) {Sort = sortExpression + " " + direction};

            gvEmployeeList.DataSource = dataView;
            gvEmployeeList.DataBind();
        }
        else
        {
            FillgvEmployeeList(HFStatus.Value);
        }

    }
    /// <summary>
    /// Handles the Sorting event of the gvEmployeeList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewSortEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
    {
        _isSort = true;

        var sortExpression = e.SortExpression;

        ViewState["SortExpression"] = sortExpression;

        if (GridViewSortDirection == SortDirection.Ascending)
        {
            _isAscend = true;
            HFSortExpression.Value = sortExpression;
            SortGridView(sortExpression, "ASC");
            GridViewSortDirection = SortDirection.Descending;

        }

        else
        {
            _isAscend = false;
            HFSortExpression.Value = sortExpression;
            SortGridView(sortExpression, "DESC");
            GridViewSortDirection = SortDirection.Ascending;

        }

    }



    /// <summary>
    /// Handles the PageIndexChanging event of the gvEmployeeList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeList.PageIndex = e.NewPageIndex;

        try
        {
            // this will get exectued if user clicks paging
            // before sorting istelf
            if (!_isSort) 
            {            
               var dt = (DataTable)ViewState["Employeelist"];
                if (dt != null)
                {
                    gvEmployeeList.DataSource = dt; 
                    gvEmployeeList.DataBind();     
                }
                else
                {
                    FillgvEmployeeList(HFStatus.Value);
                }
            }
            // this will get exectued if user clicks paging
            // after cliclking ascending order
            else if (_isAscend)
           
            {

                SortGridView(HFSortExpression.Value, "ASC");

            }
            else // this will get exectued if user clicks paging
            {
                SortGridView(HFSortExpression.Value, "DESC");

            }
        }
        catch (Exception)
        {
           var dt = (DataTable)ViewState["Employeelist"];
            if (dt != null)
            {

                gvEmployeeList.DataSource = dt; // I gave Datasource as null for
                gvEmployeeList.DataBind();     //instance. Provide your datasource
                // to bind the data
            }
            else
            {
                FillgvEmployeeList(HFStatus.Value);
            }
        }

        //FillgvEmployeeList(HFStatus.Value);
    }

    /// <summary>
    /// Handles the CheckedChanged event of the cbPreferred control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void cbPreferred_CheckedChanged(object sender, EventArgs e)
    {
        var objOperationManagement = new OperationManagement();
        var objCheckBox = (CheckBox)sender;
        var row = (GridViewRow)objCheckBox.NamingContainer;
        var cbPreferred = (CheckBox)gvEmployeeList.Rows[row.RowIndex].FindControl("cbPreferred");
        var lblEmpNo = (Label)gvEmployeeList.Rows[row.RowIndex].FindControl("lblEmpNo");
        var hfpreferred = (HiddenField)gvEmployeeList.Rows[row.RowIndex].FindControl("hfpreferred");
        var hfBackup = (HiddenField)gvEmployeeList.Rows[row.RowIndex].FindControl("hfBackup");
        if (cbPreferred.Checked)
        {
            if (hfpreferred.Value == "0" && hfBackup.Value == "0")
            {
                objOperationManagement.AsmtEmployeePreferencesInsert(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], lblEmpNo.Text, "P", BaseUserID);
                FillgvEmployeeList(HFStatus.Value);
            }
            else
            {
                if (hfBackup.Value == "1")
                {
                     objOperationManagement.AsmtEmployeePreferencesUpdate(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], lblEmpNo.Text, "P", BaseUserID);
                    FillgvEmployeeList(HFStatus.Value);
                }
            }
        }
        else
        {
             objOperationManagement.AsmtEmployeePreferencesDelete(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], lblEmpNo.Text);
            FillgvEmployeeList(HFStatus.Value);
        }
    }

    /// <summary>
    /// Back up check box checked click
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">event object</param>
    protected void cbBackup_CheckedChanged(object sender, EventArgs e)
    {
        var objOperationManagement = new OperationManagement();
        var objCheckBox = (CheckBox)sender;
        var row = (GridViewRow)objCheckBox.NamingContainer;
        var cbBackup = (CheckBox)gvEmployeeList.Rows[row.RowIndex].FindControl("cbBackup");
        var lblEmpNo = (Label)gvEmployeeList.Rows[row.RowIndex].FindControl("lblEmpNo");
        var hfpreferred = (HiddenField)gvEmployeeList.Rows[row.RowIndex].FindControl("hfpreferred");
        var hfBackup = (HiddenField)gvEmployeeList.Rows[row.RowIndex].FindControl("hfBackup");
        if (cbBackup.Checked)
        {
            if (hfpreferred.Value == "0" && hfBackup.Value == "0")
            {
                objOperationManagement.AsmtEmployeePreferencesInsert(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], lblEmpNo.Text, "B", BaseUserID);
                FillgvEmployeeList(HFStatus.Value);
            }
            else
            {
                if (hfpreferred.Value == "1")
                {
                    objOperationManagement.AsmtEmployeePreferencesUpdate(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], lblEmpNo.Text, "B",  BaseUserID);
                    FillgvEmployeeList(HFStatus.Value);
                }
            }
        }
        else
        {
            objOperationManagement.AsmtEmployeePreferencesDelete(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], lblEmpNo.Text);
            FillgvEmployeeList(HFStatus.Value);
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvEmployeeList control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var lblEmpNo = (Label)e.Row.FindControl("lblEmpNo");
            var lblEmpAvailability = (Label)e.Row.FindControl("lblEmpAvailability");
            var lblEmpName = (Label)e.Row.FindControl("lblEmpName");
            var hfpreferred = (HiddenField)e.Row.FindControl("hfpreferred");
            var hfBackup = (HiddenField)e.Row.FindControl("hfBackup");
            var hfWorkHistory = (HiddenField)e.Row.FindControl("hfWorkHistory");
            var cbPreferred = (CheckBox)e.Row.FindControl("cbPreferred");
            var cbBackup = (CheckBox)e.Row.FindControl("cbBackup");
            var cbWorkHistory = (CheckBox)e.Row.FindControl("cbWorkHistory");

            if (hfpreferred != null && hfBackup != null && cbPreferred != null && cbBackup != null)
            {
                cbPreferred.Checked = hfpreferred.Value == "1";
                cbBackup.Checked = hfBackup.Value == "1";
            }

            if (hfWorkHistory != null && cbWorkHistory != null)
            {
                cbWorkHistory.Checked = hfWorkHistory.Value == "1";
            }
            var hfEmployeeSiteType = (HiddenField)e.Row.FindControl("HFEmployeeSiteType");
            if (hfEmployeeSiteType != null)
            {
                if (hfEmployeeSiteType.Value.Trim().ToLower() == "P".Trim().ToLower())
                {
                    e.Row.BackColor = Color.Aqua;
                }
                else if (hfEmployeeSiteType.Value.Trim().ToLower() == "B".Trim().ToLower())
                {
                    e.Row.BackColor = Color.Yellow;
                }
                else
                {
                    e.Row.BackColor = Color.Empty;
                }
            }
            var strControlId = Request.QueryString["ControlId"];
            var strFromDate = Request.QueryString["FromDate"];
            var strToDate = Request.QueryString["ToDate"];
            var strAttendanceType = Request.QueryString["AttendanceType"];
            lblEmpNo.Attributes["ondblclick"] = "javascript:ReturnEmpNo('" + lblEmpNo.Text + "','" + strControlId +  "');";
            lblEmpName.Attributes["ondblclick"] = "javascript:ReturnEmpNo('" + lblEmpNo.Text + "','" + strControlId + "');";
            lblEmpAvailability.Attributes["onclick"] = "javascript:EmpAvailabilityAjax('" + lblEmpNo.Text + "','" + strFromDate + "','" + strToDate + "','" + strAttendanceType + "');";


        }
    }

    /// <summary>
    /// Handles the Click event of the btnDefaultSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnDefaultSearch_Click(object sender, EventArgs e)
    {
        ViewState["EmployeeList"] = string.Empty;
        HFStatus.Value = "1";
        FillgvEmployeeList(HFStatus.Value);
        up1.Update();
    }

    /// <summary>
    /// Handles the Click event of the btnAllEmployee control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnAllEmployee_Click(object sender, EventArgs e)
    {
        ViewState["EmployeeList"] = string.Empty;
        HFStatus.Value = "2";
        FillgvEmployeeList(HFStatus.Value);
        up1.Update();
    }

    /// <summary>
    /// Handles the Click event of the btnZipCodeSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnZipCodeSearch_Click(object sender, EventArgs e)
    {
        HFStatus.Value = "3";
        MPEZipCode.Show();
    }

    /// <summary>
    /// Handles the Click event of the btnZipSearch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnZipSearch_Click(object sender, EventArgs e)
    {
        HFStatus.Value = "3";
        ViewState["EmployeeList"] = string.Empty;
        FillgvEmployeeList(HFStatus.Value);
        MPEZipCode.Hide();
        lblErrorMsg.Text = string.Empty;
        up1.Update();
    }

    /// <summary>
    /// Handles the Click event of the btnClose control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnClose_Click(object sender, EventArgs e)
    {
        MPEZipCode.Hide();
    }

    /// <summary>
    /// Mandatory skill click check
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">event object</param>
    protected void lbMandatorySkillMatch_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lblEmpNo = (Label)gvEmployeeList.Rows[row.RowIndex].FindControl("lblEmpNo");

        var objSearch = new Search();
        using (var list = objSearch.TotalMatchedSkillSummary(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], int.Parse(BaseLocationAutoID), Request.QueryString["FromDate"], Request.QueryString["ToDate"], Request.QueryString["AreaID"], BaseUserEmployeeNumber, BaseUserIsAreaIncharge, lblEmpNo.Text, "M"))
        {
            if (list.Tables[0].Rows.Count > 0)
            {

                gvSkills.DataSource = list.Tables[0];
                gvSkills.DataBind();
                MPEPopUp.Show();
            }
            else
            {
                MPEPopUp.Hide();
            }
        }

    }

    /// <summary>
    /// Handles the Click event of the lbRecommendedSkillMatch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void lbRecommendedSkillMatch_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lblEmpNo = (Label)gvEmployeeList.Rows[row.RowIndex].FindControl("lblEmpNo");

        var objSearch = new Search();
        using (var list = objSearch.TotalMatchedSkillSummary(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], int.Parse(BaseLocationAutoID), Request.QueryString["FromDate"], Request.QueryString["ToDate"], Request.QueryString["AreaID"], BaseUserEmployeeNumber, BaseUserIsAreaIncharge, lblEmpNo.Text, "R"))
        {

            if (list.Tables[0].Rows.Count > 0)
            {
                gvSkills.DataSource = list.Tables[0];
                gvSkills.DataBind();
                MPEPopUp.Show();
            }
            else
            {
                MPEPopUp.Hide();
            }
        }

    }

    /// <summary>
    /// Handles the Click event of the lbInformativeSkillMatch control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void lbInformativeSkillMatch_Click(object sender, EventArgs e)
    {
        var objLinkButton = (LinkButton)sender;
        var row = (GridViewRow)objLinkButton.NamingContainer;
        var lblEmpNo = (Label)gvEmployeeList.Rows[row.RowIndex].FindControl("lblEmpNo");
        var objSearch = new Search();
        using (var list = objSearch.TotalMatchedSkillSummary(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], int.Parse(BaseLocationAutoID), Request.QueryString["FromDate"], Request.QueryString["ToDate"], Request.QueryString["AreaID"], BaseUserEmployeeNumber, BaseUserIsAreaIncharge, lblEmpNo.Text, "I"))
        {
            if (list.Tables[0].Rows.Count > 0)
            {

                gvSkills.DataSource = list.Tables[0];
                gvSkills.DataBind();
                MPEPopUp.Show();
            }
            else
            {
                MPEPopUp.Hide();
            }
        }

    }

    /// <summary>
    /// Handles the onClick event of the btnOk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void btnOk_onClick(object sender, EventArgs e)
    {
        MPEPopUp.Hide();
    }

    /// <summary>
    /// Gets or sets the grid view sort direction.
    /// </summary>
    /// <value>The grid view sort direction.</value>
    private SortDirection GridViewSortDirection
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;


            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }

    /// <summary>
    /// Fillgvs the employee list.
    /// </summary>
    /// <param name="strStatus">The STR status.</param>
    private void FillgvEmployeeList(string strStatus)
    {
        var objSearch = new Search();
        var noOfMonths = 0;
        if (string.IsNullOrEmpty(txtNoOfMonths.Text))
        {
            noOfMonths = 12;
        }
        else
        {
            noOfMonths = Convert.ToInt32(txtNoOfMonths.Text);
        }
        // Area ID Added to show only those employee who belongs to that area
        var dsEmpList = objSearch.AllEmployeeListGet(Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], int.Parse(BaseLocationAutoID), BaseHrLocationCode, Request.QueryString["FromDate"], Request.QueryString["ToDate"], int.Parse(strStatus), txtZipCode.Text, Request.QueryString["AreaID"], BaseUserEmployeeNumber, BaseUserIsAreaIncharge, noOfMonths);
        if (dsEmpList != null && dsEmpList.Tables.Count > 0 && dsEmpList.Tables[0].Rows.Count > 0)
        {
            ViewState["EmployeeList"] = dsEmpList.Tables[0];
            gvEmployeeList.DataSource = dsEmpList.Tables[0];
            gvEmployeeList.DataBind();
        }
        else
        {
            ViewState["EmployeeList"] = null;
            gvEmployeeList.DataSource = null;
            gvEmployeeList.DataBind();
            lblErrorMsg.Text = Resource.MandatorySkillsNotMet;
        }
    }
}
