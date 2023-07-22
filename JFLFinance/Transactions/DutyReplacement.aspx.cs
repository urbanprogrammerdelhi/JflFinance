// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 04-02-2014
// ***********************************************************************
// <copyright file="DutyReplacement.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Class Transactions_DutyReplacement.
/// </summary>
public partial class Transactions_DutyReplacement : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HFFromDate.Value = Request.QueryString["FromDate"];
            HFToDate.Value = Request.QueryString["ToDate"];
            HFArea.Value = Request.QueryString["Area"];
            HFSelectedSchRosterAutoID.Value = Request.QueryString["AutoID"];
            HFWeekNo.Value = Request.QueryString["WeekNo"];
            HFClientCode.Value = Request.QueryString["ClientCode"];
            HFAsmtID.Value = Request.QueryString["AsmtID"];
            HFPostAutoID.Value = Request.QueryString["PostAutoID"];
            FillSelectedEmployeeDetails();
            FillReplacedEmployeeDetails();
            FillDutyReplacedReason();
        }


    }

    /// <summary>
    /// Fills the duty replaced reason.
    /// </summary>
    private void FillDutyReplacedReason()
    {
        var objQuickCode = new BL.MastersManagement();
        using (DataSet ds = objQuickCode.GetDutyReplacedReason(BaseCompanyCode))
        {
            ddlReason.DataSource = ds.Tables[0];
            ddlReason.DataTextField = "ItemDesc";
            ddlReason.DataValueField = "ItemCode";
            ddlReason.DataBind();
            ddlReason.SelectedIndex = 0;
        }
    }
    /// <summary>
    /// Fills the selected employee details.
    /// </summary>
    private void FillSelectedEmployeeDetails()
    {
        FillgvDutyDetails(HFSelectedSchRosterAutoID.Value);
    }
    /// <summary>
    /// Fills the replaced employee details.
    /// </summary>
    private void FillReplacedEmployeeDetails()
    {
        var objHRManagement = new BL.HRManagement();
        using (DataSet ds = objHRManagement.EmployeesScheduleGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, HFFromDate.Value, HFToDate.Value, HFArea.Value, BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString()))
        {
            ddlReplacedEmployee.DataSource = ds.Tables[0];
            ddlReplacedEmployee.DataValueField = "EmployeeNumber";
            ddlReplacedEmployee.DataTextField = "EmployeeFullDetail";
            ddlReplacedEmployee.DataBind();
            ddlReplacedEmployee.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvDutyDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvDutyDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    /// <summary>
    /// Handles the RowDataBound event of the gvDutyDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvDutyDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
            if (IBDelete != null)
            {
                IBDelete.Attributes["onclick"] = "javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
            }
        }
    }

    /// <summary>
    /// Handles the CheckedChanged event of the cbCheck control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void cbCheck_CheckedChanged(object sender, EventArgs e)
    {
        if (ddlReplacedEmployee.SelectedValue == "")
        {
            Show("No Employee Selected");
            FillgvDutyDetails(HFSelectedSchRosterAutoID.Value);
            return;
        }
        var objCheckBox = (CheckBox)sender;
        var row = (GridViewRow)objCheckBox.NamingContainer;
        var cbCheck = (CheckBox)gvDutyDetails.Rows[row.RowIndex].FindControl("cbCheck");
        var HFAutoID = (HiddenField)gvDutyDetails.Rows[row.RowIndex].FindControl("HFAutoID");
        var HFOldEmployeeNumber = (HiddenField)gvDutyDetails.Rows[row.RowIndex].FindControl("HFOldEmployeeNumber");
        if (cbCheck != null)
        {
            //if (cbCheck.Checked)
            //{

            var reasonType = string.Empty;
            var employeeNumber = string.Empty;
            if (cbCheck.Checked)
            {
                reasonType = ddlReason.SelectedValue.ToString();
                employeeNumber = ddlReplacedEmployee.SelectedValue.ToString();
            }
            else
            {
                reasonType = "";
                employeeNumber = HFOldEmployeeNumber.Value;
            }


            var objRoster = new BL.Roster();
            if (employeeNumber != "")
            {
                using (DataSet ds = objRoster.CheckEmployeeValidityAndInsertForEntryInDutyReplaced(HFAutoID.Value, employeeNumber, reasonType, HFWeekNo.Value, BaseUserID, "Check"))
                {
                    if (ds.Tables[0].Rows[0]["MessageID"].ToString() != "1")
                    {
                        lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                        cbCheck.Checked = false;
                    }
                }
            }
            //}
        }
    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlReplacedEmployee control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs"/> instance containing the event data.</param>
    protected void ddlReplacedEmployee_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (ddlReplacedEmployee.SelectedValue != "")
        {
            FillgvDutyDetails(HFSelectedSchRosterAutoID.Value);
        }
    }

    /// <summary>
    /// Fillgvs the duty details.
    /// </summary>
    /// <param name="SelectedSchRosterAutoID">The selected SCH roster automatic identifier.</param>
    private void FillgvDutyDetails(string SelectedSchRosterAutoID)
    {
        var objRoster = new BL.Roster();
        var dt = new DataTable();
        int dtflag;
        dtflag = 1;

        using (DataSet ds = objRoster.RosterDetailBasedOnAutoID(SelectedSchRosterAutoID, HFFromDate.Value, HFToDate.Value))
        {
            dt = ds.Tables[0];

            //to fix empety gridview
            if (dt.Rows.Count == 0)
            {
                dtflag = 0;
                dt.Rows.Add(dt.NewRow());
            }

            gvDutyDetails.DataSource = dt;
            gvDutyDetails.DataBind();
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                lblEmployeeName.Text = ds.Tables[1].Rows[0]["EmployeeName"].ToString();
                lblDesignation.Text = ds.Tables[1].Rows[0]["DesignationDesc"].ToString();
            }
            if (dtflag == 0)//to fix empety gridview
            {
                gvDutyDetails.Rows[0].Visible = false;
            }
        }
    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlReplacedEmployee.SelectedValue != "")
        {
            for (int i = 0; i < gvDutyDetails.Rows.Count; i++)
            {
                var cbCheck = (CheckBox)gvDutyDetails.Rows[i].FindControl("cbCheck");
                var HFAutoID = (HiddenField)gvDutyDetails.Rows[i].FindControl("HFAutoID");
                var HFOldEmployeeNumber = (HiddenField)gvDutyDetails.Rows[i].FindControl("HFOldEmployeeNumber");

                if (cbCheck != null)
                {
                    var reasonType = string.Empty;
                    var employeeNumber = string.Empty;
                    if (cbCheck.Checked)
                    {
                        reasonType = ddlReason.SelectedValue.ToString();
                        employeeNumber = ddlReplacedEmployee.SelectedValue.ToString();
                    }
                    else
                    {
                        reasonType = "";
                        employeeNumber = HFOldEmployeeNumber.Value;
                    }
                    var objRoster = new BL.Roster();
                    if (employeeNumber != "")
                    {
                        using (DataSet ds = objRoster.CheckEmployeeValidityAndInsertForEntryInDutyReplaced(HFAutoID.Value, employeeNumber, reasonType, HFWeekNo.Value, BaseUserID, "Save"))
                        {
                            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "100")
                            {

                                lblErrorMsg.Text = "Week Off Exists";
                            }
                            else
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }
                        }
                    }

                }
            }
        }
        else
        {

            FillgvDutyDetails(HFSelectedSchRosterAutoID.Value);
        }
    }

    /// <summary>
    /// Handles the Click event of the IBDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void IBDelete_Click(object sender, EventArgs e)
    {
        var objIBDelete = (ImageButton)sender;
        var row = (GridViewRow)objIBDelete.NamingContainer;
        var HFAutoID = (HiddenField)gvDutyDetails.Rows[row.RowIndex].FindControl("HFAutoID");
        var totalgridCount = gvDutyDetails.Rows.Count;
        var objRoster = new BL.Roster();
        using (DataSet ds = objRoster.CheckEmployeeValidityAndInsertForEntryInDutyReplaced(HFAutoID.Value, ddlReplacedEmployee.SelectedValue.ToString(), ddlReason.SelectedValue.ToString(), HFWeekNo.Value, BaseUserID, "DELETE"))
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            for (int i = 0; i < totalgridCount; i++)
            {
                if (row.RowIndex != i)
                {
                    var HFAutoID1 = (HiddenField)gvDutyDetails.Rows[i].FindControl("HFAutoID");
                    HFSelectedSchRosterAutoID.Value = HFAutoID1.Value;
                    break;
                }
            }


            FillgvDutyDetails(HFSelectedSchRosterAutoID.Value);
        }

    }
}