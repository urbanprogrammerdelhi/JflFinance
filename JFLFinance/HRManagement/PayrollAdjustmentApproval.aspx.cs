// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="HRManagement_PayrollAdjustmentApproval.aspx.cs" company="Magnon">
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


public partial class HRManagement_PayrollAdjustmentApproval : BasePage
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

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = FirstDateOfCurrentMonth_Get();
            txtToDate.Text = LastDateOfCurrentMonth_Get();
            FillDivision();
            lblErrorMsg.Text = string.Empty;
        }
    }

    #region Fill DropDown
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


            FillddlAreaInchargeDetails();

        }
    }

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

    }

    protected void FillGrid()
    {
        gvApproval.Visible = false;
        btnApply.Visible = false;
        lblErrorMsg.Text = "";
        var ObjOPS = new BL.Roster();
        var loc = ddlBranch.CheckedItems;
        var ddlLoc = string.Empty;

        try
        {
            DataSet Ds = ObjOPS.GetAdjustmentStatus(BaseCompanyCode, ddlDivision.SelectedItem.Value, ddlBranch.SelectedValue.ToString(), DDLAreaID.SelectedValue, ddlStatus.SelectedItem.Value.ToString(), txtFromDate.Text.ToString(), txtToDate.Text.ToString());

            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                gvApproval.Visible = true;
                gvApproval.DataSource = Ds.Tables[0];
                gvApproval.DataBind();
                btnApply.Visible = true;
            }
            else
            {
                gvApproval.Visible = false;
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                btnApply.Visible = false;
            }
        }
        catch (Exception e)
        {
            lblErrorMsg.Text = e.Message.ToString();
        }
    }

    #endregion

    /// <summary>
    /// Handles the TextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        if (ConvertStringToDateFormat(txtFromDate, lblErrorMsg))
        {
            btnOk.Enabled = true;

            txtToDate.Text = LastDateOfTheMonthOfGivenDate_Get(txtFromDate.Text);

        }
        else
        {
            btnOk.Enabled = false;
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
            btnOk.Enabled = true;

        }
        else
        {
            btnOk.Enabled = false;
            return;
        }
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


        FillddlAreaInchargeDetails();

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
    /// Handles the SelectedIndexChanged event of the ddlBranchName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlBranchName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlBranch.SelectedValue = ddlBranchName.SelectedValue;

        FillddlAreaInchargeDetails();

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the DDLAreaID control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void DDLAreaID_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ddlAreaName.SelectedValue = DDLAreaID.SelectedValue;

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAreaName control.
    /// </summary>
    /// <param name="o">The source of the event.</param>
    /// <param name="e">The <see cref="RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlAreaName_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        DDLAreaID.SelectedValue = ddlAreaName.SelectedValue;

    }

    /// <summary>
    /// Handles the click event of Btn Submit
    /// </summary>
    /// <param name="sender">Source of event</param>
    /// <param name="e">instance containing the event data</param>
    protected void btnOk_Click(object sender, EventArgs e)
    {
  
        FillGrid();
    }

    /// <summary>
    /// Handles the click event of Btn Submit
    /// </summary>
    /// <param name="sender">Source of event</param>
    /// <param name="e">instance containing the event data</param>
    protected void btnApply_Click(object sender, EventArgs e)
    {
        var _dtAdjust = new DataTable();
        
        _dtAdjust.Columns.Add("ClientCode");
        _dtAdjust.Columns.Add("AsmtId");
        _dtAdjust.Columns.Add("EmployeeNumber");
        _dtAdjust.Columns.Add("AdjHrsFromdate");
        _dtAdjust.Columns.Add("AdjustmentHrs");
                 
        foreach (GridViewRow dtrow in gvApproval.Rows)
        {
            if (dtrow.RowType == DataControlRowType.DataRow)
            {
              
                var chkRow = (CheckBox)dtrow.Cells[13].FindControl("chkRow");
                var status = (Label)dtrow.Cells[12].FindControl("lblStatus");
                var hdClientCode = (HiddenField)dtrow.Cells[0].FindControl("hdClientCode");
                var lblAsmtId = (Label)dtrow.Cells[1].FindControl("lblAsmtId");
                var lblEmployeeNumber = (Label)dtrow.Cells[3].FindControl("lblEmployeeNumber");
                var lblAdjustHrs = (Label)dtrow.Cells[7].FindControl("lblAdjustHrs");
                var lblAdjustDate = (Label)dtrow.Cells[10].FindControl("lblAdjustDate");
                if (status.Text == "UnAuthorised" && chkRow.Checked == true)
                {

                    var _dr = _dtAdjust.NewRow();
                    _dr["ClientCode"] = hdClientCode.Value;
                    _dr["AsmtId"] = lblAsmtId.Text;
                    _dr["EmployeeNumber"] = lblEmployeeNumber.Text;
                    _dr["AdjHrsFromdate"] = DateFormat(DateTime.Parse(lblAdjustDate.Text.ToString()));
                    _dr["AdjustmentHrs"] = lblAdjustHrs.Text;
                    _dtAdjust.Rows.Add(_dr);
                }
            }          
        }
        if (_dtAdjust.Rows.Count > 0)
        {
            var obj = new BL.Roster();
            var dt = new DataSet();
            dt = obj.PaysymAjustmentAuthorizeUpdate(ddlBranch.SelectedItem.Value, _dtAdjust, BaseUserName);
            DisplayMessage(lblErrorMsg,dt.Tables[0].Rows[0]["MessageID"].ToString());

        }
        else
        {
           lblErrorMsg.Text= Resources.Resource.NodatatoAuthorize;
        }
        FillGrid();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        var chkAll = (CheckBox)gvApproval.HeaderRow.FindControl("chkhdrAll");
       
        foreach (GridViewRow dtrow in gvApproval.Rows)
        {
            if (dtrow.RowType == DataControlRowType.DataRow)
            {
                var chkRow = (CheckBox)dtrow.Cells[13].FindControl("chkRow");
                var status = (Label)dtrow.Cells[12].FindControl("lblStatus");
                if (status.Text == "UnAuthorised")
                {
                    chkRow.Checked = chkAll.Checked;
                }
                else
                {
                    chkRow.Visible = false;
                }
            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvApproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        var ObjOPS = new BL.Roster();

        DataSet Ds = ObjOPS.GetAdjustmentStatus(BaseCompanyCode, ddlDivision.SelectedItem.Value, ddlBranch.SelectedValue.ToString(), DDLAreaID.SelectedValue, ddlStatus.SelectedItem.Value.ToString(), txtFromDate.Text.ToString(), txtToDate.Text.ToString());


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Ds != null && Ds.Tables.Count > 0 && Ds.Tables[0].Rows.Count > 0)
            {
                var chkRow = (CheckBox)e.Row.FindControl("chkRow");
                var lblStatus = (Label)e.Row.FindControl("lblStatus");

                if (lblStatus.Text == "UnAuthorised")
                {
                    chkRow.Visible = true;
                }
                else
                {
                    chkRow.Visible = false;
                }


            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            }
        }
    }
    
}