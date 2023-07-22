// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// Purpose          : Added New Tab Allowance Details and It's functionality for Unit Type (Unit/Time).
// ***********************************************************************
// <copyright file="JobBreakDownSummary.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class Transactions_JobBreakDownSummary.
/// </summary>
public partial class Transactions_JobBreakDownSummary : BasePage ////System.Web.UI.Page
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

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ScheduleRosterAutoID"].Trim().ToLower() != "-1".Trim().ToLower())
            {
                FillgvBreakHrsDetails();
                FillgvRoleDetails();
                FillgvTaskDetails();
            }
            if (Request.QueryString["AttendanceType"].Trim().ToLower() == "ACT".Trim().ToLower())
            {
                //Added Code for Allowance Details Tab
                TabPanelAllowancesDetails.Visible = true;
                FillgvEmpAllowanceDetails();
                //End
            }
            EmpDetails.ActiveTabIndex = 0;
            if (Request.QueryString["Allowance"] != null)
            {
                if (Request.QueryString["Allowance"] == "1")
                {
                    EmpDetails.ActiveTabIndex = 2;
                }
            }
            if (Request.QueryString["ScheduleRosterAutoID"].Trim().ToLower() != "-1".Trim().ToLower())
            {
                if (Request.QueryString["Converted"] == "1")
                {
                    gvBreakHrsDetails.Columns[0].Visible = false;
                    gvRole.Columns[0].Visible = false;
                    gvBreakHrsDetails.FooterRow.Visible = false;
                    gvRole.FooterRow.Visible = false;
                }
                else
                {
                    gvBreakHrsDetails.Columns[0].Visible = true;
                    gvRole.Columns[0].Visible = true;
                    gvBreakHrsDetails.FooterRow.Visible = true;
                    gvRole.FooterRow.Visible = true;
                }
            }
            if (Request.QueryString["ScheduleRosterAutoID"].Trim().ToLower() == "-1".Trim().ToLower())
            {
                TabPanelBreakHrs.Visible = false;
                TabPanelRole.Visible = false;
                TabPanelTask.Visible = false;
            }
            else
            {
                TabPanelBreakHrs.Visible = true;
                TabPanelRole.Visible = true;
                TabPanelTask.Visible = true;
            }
            // Set The Decimal Place System Parameter to a Hidden Field to Apply on the Numeric Values
            hfspDecimalPlace.Value = "{0:F" + BaseDigitsAfterDecimalPlaces + "}";
        }
    }

    #region Tab Role Functions
    /// <summary>
    /// Handles the PageIndexChanging event of the gvRole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void GvRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvRole.PageIndex = e.NewPageIndex;
            FillgvRoleDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvRole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void GvRole_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvRole.EditIndex = -1;
            FillgvRoleDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvRole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void GvRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            var ds = new DataSet();
            var objRoster = new BL.Roster();
            var hdRoleAutoId = (HiddenField)gvRole.Rows[e.RowIndex].FindControl("HFRoleAutoID");
            ds = objRoster.RoleDelete(Request.QueryString["ScheduleRosterAutoID"], lblRoleDutyDate.Text, Request.QueryString["AttendanceType"], hdRoleAutoId.Value);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                FillgvRoleDetails();
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvRole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void GvRole_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvRole.EditIndex = e.NewEditIndex;
            FillgvRoleDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvRole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void GvRole_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            var ds = new DataSet();
            var objRoster = new BL.Roster();

            var ddlRoleCode = (DropDownList)gvRole.Rows[e.RowIndex].FindControl("ddlRoleCode");
            var txtTimeFrom = (TextBox)gvRole.Rows[e.RowIndex].FindControl("txtTimeFrom");
            var txtTimeTo = (TextBox)gvRole.Rows[e.RowIndex].FindControl("txtTimeTo");
            //var HFRoleCode = (HiddenField)gvRole.Rows[e.RowIndex].FindControl("HFRoleCode");
            var hdRoleAutoId = (HiddenField)gvRole.Rows[e.RowIndex].FindControl("HFRoleAutoID");
            if (ddlRoleCode.SelectedValue != "")
            {
                if (CheckTimeValidity(txtTimeFrom, txtTimeTo))
                {
                    ds = objRoster.RoleUpdate(Request.QueryString["ScheduleRosterAutoID"], ddlRoleCode.SelectedValue, HFRoleFromTime.Value, HFRoleToTime.Value, lblRoleDutyDate.Text, BaseLocationAutoID, BaseUserID, Request.QueryString["AttendanceType"], hdRoleAutoId.Value);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "200")
                        {
                            lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                        }
                        else
                        {
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                        gvRole.EditIndex = -1;
                        FillgvRoleDetails();
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.InvalidTime;
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvRole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void GvRole_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvRole.Columns[0].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (IsModifyAccess == false)
                {
                    var IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                    if (IBEdit != null)
                    { IBEdit.Visible = false; }
                }
                else
                {
                    var ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                    if (ImgbtnUpdate != null)
                    {
                        ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }

                }
                if (IsDeleteAccess == false)
                {
                    var IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                    if (IBDelete != null)
                    { IBDelete.Visible = false; }
                }
                else
                {
                    var IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                    if (IBDelete != null)
                    {
                        IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                    }

                }
                var ddlRoleCode = (DropDownList)e.Row.FindControl("ddlRoleCode");
                var HFRoleCode = (HiddenField)e.Row.FindControl("HFRoleCode");
                if (ddlRoleCode != null)
                {
                    FillRole(ddlRoleCode);
                    if (HFRoleCode != null && HFRoleCode.Value != string.Empty)
                    {
                        ddlRoleCode.SelectedValue = HFRoleCode.Value;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (IsWriteAccess == false)
                {
                    gvRole.ShowFooter = false;
                }
                else
                {
                    var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                    if (lbADD != null)
                    {
                        lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }
                    var ddlFooterRoleCode = (DropDownList)e.Row.FindControl("ddlFooterRoleCode");
                    if (ddlFooterRoleCode != null)
                    {
                        FillRole(ddlFooterRoleCode);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvRole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void GvRole_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                var ddlFooterRoleCode = (DropDownList)gvRole.FooterRow.FindControl("ddlFooterRoleCode");
                var txtFooterTimeFrom = (TextBox)gvRole.FooterRow.FindControl("txtFooterTimeFrom");
                var txtFooterTimeTo = (TextBox)gvRole.FooterRow.FindControl("txtFooterTimeTo");
                if (ddlFooterRoleCode.SelectedValue != "")
                {
                    if (CheckTimeValidity(txtFooterTimeFrom, txtFooterTimeTo) && txtFooterTimeFrom.Text != "" && txtFooterTimeTo.Text != "")
                    {
                        var ds = new DataSet();
                        var objRoster = new BL.Roster();
                        ds = objRoster.RoleInsert(Request.QueryString["ScheduleRosterAutoID"], ddlFooterRoleCode.SelectedValue, HFRoleFromTime.Value, HFRoleToTime.Value, lblRoleDutyDate.Text, BaseLocationAutoID, BaseUserID, Request.QueryString["AttendanceType"]);

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "200")
                            {
                                lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                            }
                            else
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }
                            FillgvRoleDetails();
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidTime;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion

    #region Task Grid
    /// <summary>
    /// Handles the PageIndexChanging event of the gvTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void GvTask_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvTask.PageIndex = e.NewPageIndex;
            FillgvTaskDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void GvTask_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvTask.EditIndex = -1;
            FillgvTaskDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void GvTask_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            var ds = new DataSet();
            var objRoster = new BL.Roster();
            var HFTaskAutoID = (HiddenField)gvTask.Rows[e.RowIndex].FindControl("HFTaskAutoID");
            var HFtrnTaskAutoID = (HiddenField)gvTask.Rows[e.RowIndex].FindControl("HFtrnTaskAutoID");

            ds = objRoster.TaskDelete(Request.QueryString["ScheduleRosterAutoID"], lblRoleDutyDate.Text, Request.QueryString["AttendanceType"], HFTaskAutoID.Value, HFtrnTaskAutoID.Value);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                FillgvTaskDetails();
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void GvTask_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvTask.EditIndex = e.NewEditIndex;
            FillgvTaskDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void GvTask_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            var ds = new DataSet();
            var objRoster = new BL.Roster();
            var txtTimeFrom = (TextBox)gvTask.Rows[e.RowIndex].FindControl("txtTimeFrom");
            var txtTimeTo = (TextBox)gvTask.Rows[e.RowIndex].FindControl("txtTimeTo");
            var HFTaskAutoId = (HiddenField)gvTask.Rows[e.RowIndex].FindControl("HFTaskAutoId");
            var HFtrnTaskAutoID = (HiddenField)gvTask.Rows[e.RowIndex].FindControl("HFtrnTaskAutoID");

            if (CheckTimeValidity(txtTimeFrom, txtTimeTo))
            {
                ds = objRoster.TaskUpdate(Request.QueryString["ScheduleRosterAutoID"], HFRoleFromTime.Value, HFRoleToTime.Value, lblRoleDutyDate.Text, BaseUserID, Request.QueryString["AttendanceType"], HFTaskAutoId.Value, HFtrnTaskAutoID.Value);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    gvTask.EditIndex = -1;
                    FillgvTaskDetails();
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.InvalidTime;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void GvTask_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
            {
                gvTask.Columns[0].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (IsModifyAccess == false)
                {
                    var IBEdit = (ImageButton)e.Row.FindControl("IBEdit");
                    if (IBEdit != null)
                    { IBEdit.Visible = false; }
                }
                else
                {
                    var ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                    if (ImgbtnUpdate != null)
                    {
                        ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }

                }
                if (IsDeleteAccess == false)
                {
                    var IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                    if (IBDelete != null)
                    { IBDelete.Visible = false; }
                }
                else
                {
                    var IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                    if (IBDelete != null)
                    {
                        IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                    }

                }
                var ddlTaskAutoId = (DropDownList)e.Row.FindControl("ddlTaskAutoId");
                var HFTaskAutoId = (HiddenField)e.Row.FindControl("HFTaskAutoId");
                if (ddlTaskAutoId != null)
                {
                    FillTask(ddlTaskAutoId);
                    if (HFTaskAutoId != null && HFTaskAutoId.Value != string.Empty)
                    {
                        ddlTaskAutoId.SelectedValue = HFTaskAutoId.Value;
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (IsWriteAccess == false)
                {
                    gvTask.ShowFooter = false;
                }
                else
                {
                    var lbADD = (ImageButton)e.Row.FindControl("lbADD");
                    if (lbADD != null)
                    {
                        lbADD.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                    }
                    var ddlFooterTaskAutoId = (DropDownList)e.Row.FindControl("ddlFooterTaskAutoId");
                    if (ddlFooterTaskAutoId != null)
                    {
                        FillTask(ddlFooterTaskAutoId);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvTask control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void GvTask_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                var ddlFooterTaskAutoId = (DropDownList)gvTask.FooterRow.FindControl("ddlFooterTaskAutoId");
                var txtFooterTimeFrom = (TextBox)gvTask.FooterRow.FindControl("txtFooterTimeFrom");
                var txtFooterTimeTo = (TextBox)gvTask.FooterRow.FindControl("txtFooterTimeTo");
                if (ddlFooterTaskAutoId.SelectedValue != "")
                {
                    if (CheckTimeValidity(txtFooterTimeFrom, txtFooterTimeTo))
                    {
                        var ds = new DataSet();
                        var objRoster = new BL.Roster();
                        ds = objRoster.TaskInsert(Request.QueryString["ScheduleRosterAutoID"], HFRoleFromTime.Value, HFRoleToTime.Value, lblRoleDutyDate.Text, BaseUserID, Request.QueryString["AttendanceType"], ddlFooterTaskAutoId.SelectedValue);

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            FillgvTaskDetails();
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidTime;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    #endregion

    #region Tab Break Hours
    /// <summary>
    /// Handles the RowDataBound event of the gvBreakHrsDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void GvBreakHrsDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddlEmployeeNumberRep = (DropDownList)e.Row.FindControl("ddlEmployeeNumberRep");
                var HFEmployeeNumberRep = (HiddenField)e.Row.FindControl("HFEmployeeNumberRep");
                var ibDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (ibDelete != null)
                {
                    ibDelete.Attributes["onclick"] = "javascript:Timerf('" + lblBreakHrsErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
                if (ddlEmployeeNumberRep != null)
                {
                    FillEmployeeList(ddlEmployeeNumberRep);
                    if (HFEmployeeNumberRep != null)
                    {
                        if (HFEmployeeNumberRep.Value != string.Empty)
                        {
                            ddlEmployeeNumberRep.SelectedValue = HFEmployeeNumberRep.Value;
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                var ddlFooterEmployeeNumberRep = (DropDownList)e.Row.FindControl("ddlFooterEmployeeNumberRep");
                if (ddlFooterEmployeeNumberRep != null)
                {
                    FillEmployeeList(ddlFooterEmployeeNumberRep);
                    ddlFooterEmployeeNumberRep.SelectedValue = lblEmployeeNumber.Text;
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the gvBreakHrsDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void GvBreakHrsDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                var ddlFooterEmployeeNumberRep = (DropDownList)gvBreakHrsDetails.FooterRow.FindControl("ddlFooterEmployeeNumberRep");
                var txtFooterTimeFrom = (TextBox)gvBreakHrsDetails.FooterRow.FindControl("txtFooterTimeFrom");
                var txtFooterTimeTo = (TextBox)gvBreakHrsDetails.FooterRow.FindControl("txtFooterTimeTo");
                var CBFooterIsPayable = (CheckBox)gvBreakHrsDetails.FooterRow.FindControl("CBFooterIsPayable");

                if (txtFooterTimeFrom.Text != string.Empty && txtFooterTimeTo.Text != string.Empty)
                {
                    if (CheckTimeValidity(txtFooterTimeFrom, txtFooterTimeTo))
                    {
                        var ds = new DataSet();
                        var objRoster = new BL.Roster();
                        //string strFromTime = "01-01-1900" + " " + txtFooterTimeFrom.Text;
                        //string strTimeTo = "01-01-1900" + " " + txtFooterTimeTo.Text;
                        string strFromTime = HFRoleFromTime.Value;
                        string strTimeTo = HFRoleToTime.Value;
                        string strNewEmpSchRosterAutoID = string.Empty;
                        strNewEmpSchRosterAutoID = lblEmployeeNumber.Text == ddlFooterEmployeeNumberRep.SelectedValue ? Request.QueryString["ScheduleRosterAutoID"] : @"0";
                        string breakHourAutoID = @"0";

                        var dsBreak = new DataSet();

                        if (hfMaxBreakHours.Value == "-1.00")
                        {
                            lblBreakHrsErrorMsg.Text = Resources.Resource.BreakRuleMismatch;
                            return;
                        }

                        dsBreak = objRoster.CheckBreakHoursRule(Request.QueryString["ScheduleRosterAutoID"], strFromTime, strTimeTo, hfMaxBreakHours.Value, "0", Request.QueryString["AttendanceType"]);

                        if (dsBreak != null && dsBreak.Tables.Count > 0)
                        {
                            lblBreakHrsErrorMsg.Text = Resources.Resource.BreakRuleMismatch;
                            return;
                        }

                        ds = objRoster.BreakHoursInsert(Request.QueryString["ScheduleRosterAutoID"], strNewEmpSchRosterAutoID, lblEmployeeNumber.Text,
                                                        ddlFooterEmployeeNumberRep.SelectedValue, lblDutyDate.Text, strFromTime, strTimeTo, "Break",
                                                        CBFooterIsPayable.Checked, BaseUserID, Request.QueryString["AttendanceType"], "I", breakHourAutoID,
                                                        Request.QueryString["ClientCode"], Request.QueryString["AsmtID"],
                                                        Request.QueryString["PostCode"], Request.QueryString["ClientName"],
                                                        Request.QueryString["AssignmentName"], Request.QueryString["PostDesc"],
                                                        Request.QueryString["WeekNo"]
                                                        );
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            FillgvBreakHrsDetails();
                            lblBreakHrsErrorMsg.Text = ResourceValueOfKey_Get(ds.Tables[0].Rows[0]["MessageString"].ToString());
                        }
                    }
                    else
                    {
                        lblBreakHrsErrorMsg.Text = Resources.Resource.InvalidTime;
                    }
                }
            }
            if (e.CommandName.Equals("Reset"))
            {
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the gvBreakHrsDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void GvBreakHrsDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvBreakHrsDetails.EditIndex = e.NewEditIndex;
            FillgvBreakHrsDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvBreakHrsDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void GvBreakHrsDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            var ddlEmployeeNumberRep = (DropDownList)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("ddlEmployeeNumberRep");
            var txtTimeFrom = (TextBox)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("txtTimeFrom");
            var txtTimeTo = (TextBox)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("txtTimeTo");
            var CBIsPayable = (CheckBox)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("CBIsPayable");
            var HFBreakHourAutoID = (HiddenField)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("HFBreakHourAutoID");
            var HFReplacedSchRosterAutoID = (HiddenField)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("HFReplacedSchRosterAutoID");
            var HFEmployeeNumberRep = (HiddenField)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("HFEmployeeNumberRep");
            if (txtTimeFrom.Text != string.Empty && txtTimeTo.Text != string.Empty)
            {
                if (CheckTimeValidity(txtTimeFrom, txtTimeTo))
                {
                    var dsBreakUpdate = new DataSet();
                    var objRoster = new BL.Roster();
                    //string strFromTime = "01-01-1900" + " " + txtTimeFrom.Text;
                    //string strTimeTo = "01-01-1900" + " " + txtTimeTo.Text;
                    string strFromTime = HFRoleFromTime.Value;
                    string strTimeTo = HFRoleToTime.Value;
                    string strNewEmpSchRosterAutoID = Request.QueryString["ScheduleRosterAutoID"];
                    string breakHourAutoID = HFBreakHourAutoID.Value;

                    var dsBreak = new DataSet();

                    if (hfMaxBreakHours.Value == "-1.00")
                    {
                        lblBreakHrsErrorMsg.Text = Resources.Resource.BreakRuleMismatch;
                        return;
                    }
                    dsBreak = objRoster.CheckBreakHoursRule(Request.QueryString["ScheduleRosterAutoID"], strFromTime, strTimeTo, hfMaxBreakHours.Value, breakHourAutoID, Request.QueryString["AttendanceType"]);

                    if (dsBreak != null && dsBreak.Tables.Count > 0)
                    {
                        lblBreakHrsErrorMsg.Text = Resources.Resource.BreakRuleMismatch;
                        return;
                    }


                    if (HFEmployeeNumberRep.Value == lblEmployeeNumber.Text && lblEmployeeNumber.Text != ddlEmployeeNumberRep.SelectedValue) // if user is trying to change existing employee and selecting different employee
                    {
                        strNewEmpSchRosterAutoID = "0";



                        dsBreakUpdate = objRoster.BreakHoursInsert(Request.QueryString["ScheduleRosterAutoID"], strNewEmpSchRosterAutoID,
                                                                    lblEmployeeNumber.Text, ddlEmployeeNumberRep.SelectedValue,
                                                                    lblDutyDate.Text, strFromTime, strTimeTo, "Break", CBIsPayable.Checked,
                                                                    BaseUserID, Request.QueryString["AttendanceType"], "U",
                                                                    breakHourAutoID, Request.QueryString["ClientCode"],
                                                                    Request.QueryString["AsmtID"],
                                                                    Request.QueryString["PostCode"], Request.QueryString["ClientName"],
                                                                    Request.QueryString["AssignmentName"], Request.QueryString["PostDesc"],
                                                                    Request.QueryString["WeekNo"]
                                                                    );

                    }
                    else
                    {
                        dsBreakUpdate = objRoster.BreakHoursUpdate(Request.QueryString["ScheduleRosterAutoID"], HFReplacedSchRosterAutoID.Value, ddlEmployeeNumberRep.SelectedValue, strFromTime, strTimeTo, CBIsPayable.Checked, BaseUserID, Request.QueryString["AttendanceType"], breakHourAutoID, lblDutyDate.Text);
                    }

                    if (dsBreakUpdate != null && dsBreakUpdate.Tables.Count > 0 && dsBreakUpdate.Tables[0].Rows.Count > 0)
                    {
                        gvBreakHrsDetails.EditIndex = -1;
                        FillgvBreakHrsDetails();
                        lblBreakHrsErrorMsg.Text = ResourceValueOfKey_Get(dsBreakUpdate.Tables[0].Rows[0]["MessageString"].ToString());
                    }
                }
                else
                {
                    lblBreakHrsErrorMsg.Text = Resources.Resource.InvalidTime;
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvBreakHrsDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void GvBreakHrsDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            var HFBreakHourAutoID = (HiddenField)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("HFBreakHourAutoID");
            var HFReplacedSchRosterAutoID = (HiddenField)gvBreakHrsDetails.Rows[e.RowIndex].FindControl("HFReplacedSchRosterAutoID");

            var dsDelete = new DataSet();
            var objRoster = new BL.Roster();
            dsDelete = objRoster.BreakHoursDelete(HFBreakHourAutoID.Value, Request.QueryString["ScheduleRosterAutoID"], HFReplacedSchRosterAutoID.Value, Request.QueryString["AttendanceType"]);
            DisplayMessage(lblBreakHrsErrorMsg, dsDelete.Tables[0].Rows[0]["MessageID"].ToString());
            FillgvBreakHrsDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvBreakHrsDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void GvBreakHrsDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvBreakHrsDetails.PageIndex = e.NewPageIndex;
            FillgvBreakHrsDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvBreakHrsDetails control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void GvBreakHrsDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvBreakHrsDetails.EditIndex = -1;
            FillgvBreakHrsDetails();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Checks the time validity.
    /// </summary>
    /// <param name="txtFromTime">The TXT from time.</param>
    /// <param name="txtToTime">The TXT to time.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    private bool CheckTimeValidity(TextBox txtFromTime, TextBox txtToTime)
    {
        string strDutyFromTime = lblRoleDutyDate.Text + " " + lblRoleTimeFrom.Text;
        string strDutyToTime = lblRoleDutyDate.Text + " " + lblRoleTimeTo.Text;

        string strRoleTimeFrom = lblRoleDutyDate.Text + " " + txtFromTime.Text;
        string strRoleTimeTo = lblRoleDutyDate.Text + " " + txtToTime.Text;

        if (Convert.ToDateTime(DateTime.Parse(strDutyFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")))
        {
            if (Convert.ToDateTime(DateTime.Parse(strDutyToTime).ToString("HH:mm")) >= Convert.ToDateTime("00:00"))
            {
                strDutyToTime = DateTime.Parse(lblRoleDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + lblRoleTimeTo.Text;
            }
        }

        if (Convert.ToDateTime(DateTime.Parse(strDutyFromTime).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strRoleTimeFrom).ToString("HH:mm")))
        {
            strRoleTimeFrom = DateTime.Parse(lblRoleDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtFromTime.Text).ToString("HH:mm");
        }

        HFRoleFromTime.Value = strRoleTimeFrom;
        if (Convert.ToDateTime(DateTime.Parse(strRoleTimeFrom).ToString("dd-MMMM-yyyy")) > Convert.ToDateTime(DateTime.Parse(strRoleTimeTo).ToString("dd-MMMM-yyyy")))
        {
            strRoleTimeTo = DateTime.Parse(lblRoleDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMMM-yyyy") + " " + DateTime.Parse(txtToTime.Text).ToString("HH:mm");
        }
        else if (Convert.ToDateTime(DateTime.Parse(strRoleTimeFrom).ToString("HH:mm")) > Convert.ToDateTime(DateTime.Parse(strRoleTimeTo).ToString("HH:mm")))
        {
            if (Convert.ToDateTime(DateTime.Parse(strRoleTimeTo).ToString("HH:mm")) >= Convert.ToDateTime("00:00"))
            {
                strRoleTimeTo = DateTime.Parse(lblRoleDutyDate.Text).AddDays(double.Parse("1")).ToString("dd-MMM-yyyy") + " " + txtToTime.Text;

            }
        }
        HFRoleToTime.Value = strRoleTimeTo;
        if (DateTime.Parse(strRoleTimeFrom) >= DateTime.Parse(strDutyFromTime)
                && DateTime.Parse(strRoleTimeFrom) <= DateTime.Parse(strDutyToTime)
                && DateTime.Parse(strRoleTimeTo) <= DateTime.Parse(strDutyToTime)
                && DateTime.Parse(strRoleTimeTo) >= DateTime.Parse(strDutyFromTime)
                && DateTime.Parse(strRoleTimeFrom) < DateTime.Parse(strRoleTimeTo)
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Fill Employees
    /// <summary>
    /// Fills the employee list.
    /// </summary>
    /// <param name="ddlEmployees">The DDL employees.</param>
    private void FillEmployeeList(DropDownList ddlEmployees)
    {
        var objHRManagement = new BL.HRManagement();
        var ds = new DataSet();
        // Added Area ID to Get only those employees which belongs to the selected Area
        ds = objHRManagement.EmployeesScheduleGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, lblDutyDate.Text, lblDutyDate.Text, Request.QueryString["AreaID"], BaseUserEmployeeNumber, BaseUserIsAreaIncharge);
        ddlEmployees.DataSource = ds.Tables[0];
        ddlEmployees.DataValueField = "EmployeeNumber";
        ddlEmployees.DataTextField = "EmployeeName";
        ddlEmployees.DataBind();
    }
    #endregion

    /// <summary>
    /// Fill grid view with role details.
    /// </summary>
    private void FillgvRoleDetails()
    {
        var objRoster = new BL.Roster();
        var ds = new DataSet();
        int dtflag = 1;
        ds = objRoster.RoleGetAll(Request.QueryString["ScheduleRosterAutoID"], BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, Request.QueryString["AttendanceType"], Request.QueryString["AreaID"], BaseUserEmployeeNumber, BaseUserIsAreaIncharge, Request.QueryString["FromDate"]);
        if (ds.Tables.Count > 1)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                FillDetails(ds.Tables[1], "Role");
            }
        }
        ////to fix empety gridview
        if (ds.Tables[0].Rows.Count == 0)
        {
            dtflag = 0;
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        }

        gvRole.DataSource = ds.Tables[0];
        gvRole.DataBind();
        ////to fix empety gridview
        if (dtflag == 0)
        {
            gvRole.Rows[0].Visible = false;
        }
        if (HFIsConverted.Value != string.Empty)
        {
            try
            {
                if (bool.Parse(HFIsConverted.Value) == true)
                {
                    gvRole.FooterRow.Visible = false;
                    gvRole.Columns[0].Visible = false;
                }
                else
                {
                    gvRole.FooterRow.Visible = true;
                    gvRole.Columns[0].Visible = true;
                }
            }
            catch (Exception) { }
        }
    }
    /// <summary>
    /// Fill grid view with task details.
    /// </summary>
    private void FillgvTaskDetails()
    {
        var objRoster = new BL.Roster();
        var ds = new DataSet();
        int dtflag = 1;
        ds = objRoster.TaskGetAll(Request.QueryString["ScheduleRosterAutoID"], BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, Request.QueryString["AttendanceType"], Request.QueryString["AreaID"], BaseUserEmployeeNumber, BaseUserIsAreaIncharge, Request.QueryString["FromDate"]);
        if (ds.Tables.Count > 1)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                FillDetails(ds.Tables[1], "Task");
            }
        }

        ////to fix empety gridview
        if (ds.Tables[0].Rows.Count == 0)
        {
            dtflag = 0;
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        }

        gvTask.DataSource = ds.Tables[0];
        gvTask.DataBind();

        ////to fix empety gridview
        if (dtflag == 0)
        {
            gvTask.Rows[0].Visible = false;
        }
        if (HFIsConverted.Value != string.Empty)
        {
            try
            {
                if (bool.Parse(HFIsConverted.Value) == true)
                {
                    gvTask.FooterRow.Visible = false;
                    gvTask.Columns[0].Visible = false;
                }
                else
                {
                    gvTask.FooterRow.Visible = true;
                    gvTask.Columns[0].Visible = true;
                }
            }
            catch (Exception) { }
        }
    }
    /// <summary>
    /// Fill grid view with break HRS details.
    /// </summary>
    private void FillgvBreakHrsDetails()
    {
        var objRoster = new BL.Roster();
        var ds = new DataSet();
        int dtflag = 1;
        ds = objRoster.BreakHoursGetAll(Request.QueryString["ScheduleRosterAutoID"], BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, Request.QueryString["AttendanceType"], Request.QueryString["AreaID"], BaseUserEmployeeNumber, BaseUserIsAreaIncharge, Request.QueryString["FromDate"]);
        if (ds.Tables.Count > 1)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                FillDetails(ds.Tables[1], "Break");
                hfMaxBreakHours.Value = ds.Tables[1].Rows[0]["MaxBreakHours"].ToString();
                if (hfMaxBreakHours.Value == "")
                {
                    hfMaxBreakHours.Value = "0";
                }

                if (hfMaxBreakHours.Value == "-1.00")
                {
                    lblBreakHrsErrorMsg.Text = Resources.Resource.BreakRuleMismatch;
                    //  return;
                }
            }
        }
        ////to fix empety gridview
        if (ds.Tables[0].Rows.Count == 0)
        {
            dtflag = 0;
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        }

        gvBreakHrsDetails.DataSource = ds.Tables[0];
        gvBreakHrsDetails.DataBind();
        try
        {
            var lblEmployeeNumberRep = (Label)gvBreakHrsDetails.Rows[0].FindControl("lblEmployeeNumberRep");
            if (lblEmployeeNumberRep.Text == string.Empty)
            {
                gvBreakHrsDetails.Rows[0].Visible = false;
            }
        }
        catch (Exception) { }
        ////to fix empety gridview
        if (dtflag == 0)
        {
            gvBreakHrsDetails.Rows[0].Visible = false;
        }
    }
    /// <summary>
    /// Fills the Task.
    /// </summary>
    /// <param name="ddlTask">The DDL Task.</param>
    private void FillTask(DropDownList ddlTask)
    {
        var objMasterManagement = new BL.MastersManagement();
        ddlTask.DataSource = objMasterManagement.TaskMasterGet(BaseLocationAutoID).Tables[0];
        ddlTask.DataValueField = "TaskAutoId";
        ddlTask.DataTextField = "TaskDesc";
        ddlTask.DataBind();
    }
    /// <summary>
    /// Fills the role.
    /// </summary>
    /// <param name="ddlRole">The DDL role.</param>
    private void FillRole(DropDownList ddlRole)
    {
        var objMasterManagement = new BL.MastersManagement();
        ddlRole.DataSource = objMasterManagement.RoleGet(BaseCompanyCode).Tables[0];
        ddlRole.DataValueField = "RoleCode";
        ddlRole.DataTextField = "RoleDesc";
        ddlRole.DataBind();
    }

    /// <summary>
    /// Fills the details.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <param name="strCallType">Type of the STR call.</param>
    private void FillDetails(DataTable dt, string strCallType)
    {
        if (strCallType == "Break")
        {
            lblEmployeeNumber.Text = dt.Rows[0]["EmployeeNumber"].ToString();
            lblEmployeeName.Text = dt.Rows[0]["EmployeeName"].ToString();
            lblDutyDate.Text = DateTime.Parse(dt.Rows[0]["DutyDate"].ToString()).ToString("dd-MMM-yyyy");
            lblFromTime.Text = DateTime.Parse(dt.Rows[0]["TimeFrom"].ToString()).ToString("HH:mm");
            lblToTime.Text = DateTime.Parse(dt.Rows[0]["TimeTo"].ToString()).ToString("HH:mm");

            lblRoleEmployeeNumber.Text = dt.Rows[0]["EmployeeNumber"].ToString();
            lblRoleEmployeeName.Text = dt.Rows[0]["EmployeeName"].ToString();
            lblRoleDutyDate.Text = DateTime.Parse(dt.Rows[0]["DutyDate"].ToString()).ToString("dd-MMM-yyyy");
            lblRoleTimeFrom.Text = DateTime.Parse(dt.Rows[0]["TimeFrom"].ToString()).ToString("HH:mm");
            lblRoleTimeTo.Text = DateTime.Parse(dt.Rows[0]["TimeTo"].ToString()).ToString("HH:mm");

            lblTaskEmployeeNumber.Text = dt.Rows[0]["EmployeeNumber"].ToString();
            lblTaskEmployeeName.Text = dt.Rows[0]["EmployeeName"].ToString();
            lblTaskDutyDate.Text = DateTime.Parse(dt.Rows[0]["DutyDate"].ToString()).ToString("dd-MMM-yyyy");
            lblTaskTimeFrom.Text = DateTime.Parse(dt.Rows[0]["TimeFrom"].ToString()).ToString("HH:mm");
            lblTaskTimeTo.Text = DateTime.Parse(dt.Rows[0]["TimeTo"].ToString()).ToString("HH:mm");
            HFIsConverted.Value = dt.Rows[0]["IsConverted"].ToString();
        }
    }
    /// <summary>
    /// Function used to Sorting grid data.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewSortEventArgs"/> instance containing the event data.</param>
    protected void gvBreakHrsDetails_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    #region Tab Allowance Details for Both Unit Types (Unit/Time).
    /// <summary>
    /// Function used to fill employee details for allowance.
    /// </summary>
    private void FillgvEmpAllowanceDetails()
    {
        try
        {
            var objRoster = new BL.Roster();
            if (Request.QueryString["ScheduleRosterAutoID"].Trim().ToLower() != "-1".Trim().ToLower())
            {
                GetEmployeeDetailsBasedOnRosterAutoId(Request.QueryString["ScheduleRosterAutoID"]);
            }
            else
            {
                string empNo = Request.QueryString["EmployeeNumber"];
                lblEmployeeNumberAllowanceDetails.Text = empNo;
                lblEmployeeNameAllowanceDetails.Text = Request.QueryString["EmployeeName"] + @" ( " + empNo + @" )";
                lblDutyDateAllowanceDetails.Text = DateTime.Parse(Request.QueryString["DutyDate"]).ToString("dd-MMM-yyyy");
                lblFromTimeAllowanceDetails.Text = "";
                lblToTimeAllowanceDetails.Text = "";
            }
            DataSet ds = objRoster.RosterAllowanceDetailsGet(Request.QueryString["ScheduleRosterAutoID"], BaseLocationAutoID, Request.QueryString["ClientCode"], Request.QueryString["AsmtID"], Request.QueryString["PostCode"], Request.QueryString["RowNumber"], lblDutyDateAllowanceDetails.Text);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                gvAllowanceDetails.DataSource = dt;
                gvAllowanceDetails.DataBind();
                gvAllowanceDetails.Rows[0].Visible = false;
            }
            else
            {
                gvAllowanceDetails.DataKeyNames = new string[] { "TrnAllowanceAutoId" };
                gvAllowanceDetails.DataSource = dt;
                gvAllowanceDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }
    /// <summary>
    /// Function used to fill employee details based on RosterAutoId.
    /// </summary>
    /// <param name="strRosterAutoId">The string roster automatic identifier.</param>
    private void GetEmployeeDetailsBasedOnRosterAutoId(string strRosterAutoId)
    {
        try
        {
            var objRoster = new BL.Roster();
            DataSet ds = objRoster.TranRosterEmployeeWiseGetAllBasedOnRosterAutoId(strRosterAutoId, BaseLocationAutoID);
            if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                string empNo = ds.Tables[0].Rows[0]["EmployeeNumber"].ToString();
                lblEmployeeNumberAllowanceDetails.Text = empNo;
                lblEmployeeNameAllowanceDetails.Text = ds.Tables[0].Rows[0]["EmployeeName"].ToString() + @" ( " + empNo + @" )";
                lblDutyDateAllowanceDetails.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DutyDate"].ToString()).ToString("dd-MMM-yyyy");
                lblFromTimeAllowanceDetails.Text = DateTime.Parse(ds.Tables[0].Rows[0]["TimeFrom"].ToString()).ToString("HH:mm");
                lblToTimeAllowanceDetails.Text = DateTime.Parse(ds.Tables[0].Rows[0]["TimeTo"].ToString()).ToString("HH:mm");
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on Grid Allowance Details RowCommand event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                var ddlAllowanceDetailsDescription =
                    (DropDownList)gvAllowanceDetails.FooterRow.FindControl("ddlAllowanceDetailsDescription");
                //var lblElementDetails = (Label)gvAllowanceDetails.FooterRow.FindControl("lblElementDetails");
                var lblElementTypeDetails = (Label)gvAllowanceDetails.FooterRow.FindControl("lblElementTypeDetails");
                var txtFooterTimeFromDetails =
                    (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtFooterTimeFromDetails");
                var txtFooterTimeToDetails =
                    (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtFooterTimeToDetails");
                var lblMeasurement = (Label)gvAllowanceDetails.FooterRow.FindControl("lblMeasurement");
                var hfUnitTypeDetails = (HiddenField)gvAllowanceDetails.FooterRow.FindControl("hfUnitTypeDetails");
                var txtUnitDetails = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtUnitDetails");
                var txtAmountPaid = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtAmountPaid");
                var ddlBillable = (DropDownList)gvAllowanceDetails.FooterRow.FindControl("ddlBillable");
                var txtComment = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtComment");
                var lblRateIdDetails = (Label)gvAllowanceDetails.FooterRow.FindControl("lblRateIdDetails");

                String dutyMin = @"0";

                if (string.IsNullOrEmpty(txtUnitDetails.Text))
                {
                    txtUnitDetails.Text = @"0.0";
                }
                if (string.IsNullOrEmpty(txtAmountPaid.Text))
                {
                    txtAmountPaid.Text = @"0.0";
                }

                if (hfUnitTypeDetails.Value.Trim() == @"Unit" && lblElementTypeDetails.Text == @"Calculated" &&
                    txtUnitDetails.Text == @"0.0")
                {
                    txtUnitDetails.Text = @"1.0";
                    txtAmountPaid.Text = lblRateIdDetails.Text;
                }

                if (hfUnitTypeDetails.Value.Trim() == @"Time" && lblElementTypeDetails.Text == @"Fixed")
                {
                    txtUnitDetails.Text = @"1.0";
                    txtAmountPaid.Text = lblRateIdDetails.Text;
                }

                if (hfUnitTypeDetails.Value.Trim() == @"Time" && lblElementTypeDetails.Text == @"Calculated" && (string.IsNullOrEmpty(txtFooterTimeFromDetails.Text) || string.IsNullOrEmpty(txtFooterTimeToDetails.Text)))
                {
                    lblAllowanceDetailsErrorMsg.Text = Resources.Resource.MsgFromTimeToTimeRequired;
                }
                else
                {
                    var ds = new DataSet();
                    var objRoster = new BL.Roster();
                    if (!string.IsNullOrEmpty(txtFooterTimeFromDetails.Text))
                    {
                        DateTime fromTime = DateTime.Parse("1901-01-01 " + txtFooterTimeFromDetails.Text + ":00");
                        DateTime toTime = DateTime.Parse("1901-01-01 " + txtFooterTimeToDetails.Text + ":00");
                        if (fromTime > toTime)
                        {
                            toTime = DateTime.Parse("1901-01-02 " + txtFooterTimeToDetails.Text + ":00");
                        }
                        TimeSpan ts = toTime.Subtract(fromTime);
                        dutyMin = ((ts.Hours * 60) + ((ts.Minutes))).ToString();
                    }
                    if (lblElementTypeDetails.Text.ToLower() == "Fixed".ToLower() ||
                        Request.QueryString["ScheduleRosterAutoID"] == "-1")
                    {
                        ds = objRoster.RosterAllowanceDetailsInsert(Request.QueryString["ScheduleRosterAutoID"],
                                                                    lblEmployeeNumberAllowanceDetails.Text,
                                                                    ddlAllowanceDetailsDescription.SelectedValue,
                                                                    lblDutyDateAllowanceDetails.Text,
                                                                    txtFooterTimeFromDetails.Text,
                                                                    txtFooterTimeToDetails.Text, dutyMin, BaseUserID,
                                                                    BaseLocationAutoID, Request.QueryString["ClientCode"],
                                                                    Request.QueryString["AsmtID"],
                                                                    Request.QueryString["PostCode"],
                                                                    Request.QueryString["RowNumber"], lblMeasurement.Text,
                                                                    Convert.ToDecimal(txtUnitDetails.Text),
                                                                    Convert.ToDecimal(txtAmountPaid.Text),
                                                                    Convert.ToBoolean(
                                                                        Convert.ToInt32(ddlBillable.SelectedItem.Value)),
                                                                    txtComment.Text);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DisplayMessage(lblAllowanceDetailsErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                        FillgvEmpAllowanceDetails();
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtFooterTimeFromDetails.Text) &&
                            !String.IsNullOrEmpty(txtFooterTimeToDetails.Text))
                        {
                            if (CheckTimeValidity(txtFooterTimeFromDetails, txtFooterTimeToDetails))
                            {
                                ds = objRoster.RosterAllowanceDetailsInsert(Request.QueryString["ScheduleRosterAutoID"],
                                                                            lblEmployeeNumberAllowanceDetails.Text,
                                                                            ddlAllowanceDetailsDescription.SelectedValue,
                                                                            lblDutyDateAllowanceDetails.Text,
                                                                            txtFooterTimeFromDetails.Text,
                                                                            txtFooterTimeToDetails.Text, dutyMin,
                                                                            BaseUserID, BaseLocationAutoID,
                                                                            Request.QueryString["ClientCode"],
                                                                            Request.QueryString["AsmtID"],
                                                                            Request.QueryString["PostCode"],
                                                                            Request.QueryString["RowNumber"],
                                                                            lblMeasurement.Text,
                                                                            Convert.ToDecimal(txtUnitDetails.Text),
                                                                            Convert.ToDecimal(txtAmountPaid.Text),
                                                                            Convert.ToBoolean(
                                                                                Convert.ToInt32(
                                                                                    ddlBillable.SelectedItem.Value)),
                                                                            txtComment.Text);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblAllowanceDetailsErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                }
                                FillgvEmpAllowanceDetails();
                            }
                            else
                            {
                                lblAllowanceDetailsErrorMsg.Text = Resources.Resource.InvalidTime;
                            }
                        }
                        else
                        {
                            ds = objRoster.RosterAllowanceDetailsInsert(Request.QueryString["ScheduleRosterAutoID"],
                                                                        lblEmployeeNumberAllowanceDetails.Text,
                                                                        ddlAllowanceDetailsDescription.SelectedValue,
                                                                        lblDutyDateAllowanceDetails.Text,
                                                                        txtFooterTimeFromDetails.Text,
                                                                        txtFooterTimeToDetails.Text, dutyMin, BaseUserID,
                                                                        BaseLocationAutoID,
                                                                        Request.QueryString["ClientCode"],
                                                                        Request.QueryString["AsmtID"],
                                                                        Request.QueryString["PostCode"],
                                                                        Request.QueryString["RowNumber"],
                                                                        lblMeasurement.Text,
                                                                        Convert.ToDecimal(txtUnitDetails.Text),
                                                                        Convert.ToDecimal(txtAmountPaid.Text),
                                                                        Convert.ToBoolean(
                                                                            Convert.ToInt32(ddlBillable.SelectedItem.Value)),
                                                                        txtComment.Text);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                DisplayMessage(lblAllowanceDetailsErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }
                            FillgvEmpAllowanceDetails();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on Grid AllowanceDetails RowUpdating event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            var ds = new DataSet();
            var objRoster = new BL.Roster();
            var ddlAllowanceDetailsDescription = (DropDownList)gvAllowanceDetails.Rows[e.RowIndex].FindControl("ddlAllowanceDetailsDescription");
            //var lblElementDetails = (Label)gvAllowanceDetails.Rows[e.RowIndex].FindControl("lblElementDetails");
            var lblElementTypeDetails = (Label)gvAllowanceDetails.Rows[e.RowIndex].FindControl("lblElementTypeDetails");
            var txtTimeFromDetails = (TextBox)gvAllowanceDetails.Rows[e.RowIndex].FindControl("txtTimeFromDetails");
            var txtTimeToDetails = (TextBox)gvAllowanceDetails.Rows[e.RowIndex].FindControl("txtTimeToDetails");
            var hfRosterAllowanceDetailsAutoId = (HiddenField)gvAllowanceDetails.Rows[e.RowIndex].FindControl("hfRosterAllowanceDetailsAutoId");
            var lblMeasurement = (Label)gvAllowanceDetails.Rows[e.RowIndex].FindControl("lblMeasurement");
            var hfUnitTypeDetails = (HiddenField)gvAllowanceDetails.Rows[e.RowIndex].FindControl("hfUnitTypeDetails");
            var txtUnitDetails = (TextBox)gvAllowanceDetails.Rows[e.RowIndex].FindControl("txtUnitDetails");
            var txtAmountPaid = (TextBox)gvAllowanceDetails.Rows[e.RowIndex].FindControl("txtAmountPaid");
            var ddlBillable = (DropDownList)gvAllowanceDetails.Rows[e.RowIndex].FindControl("ddlBillable");
            var txtComment = (TextBox)gvAllowanceDetails.Rows[e.RowIndex].FindControl("txtComment");
            var lblRateIdDetails = (Label)gvAllowanceDetails.Rows[e.RowIndex].FindControl("lblRateIdDetails");

            String dutyMin = @"0";

            if (string.IsNullOrEmpty(txtUnitDetails.Text))
            {
                txtUnitDetails.Text = @"0.0";
            }
            if (string.IsNullOrEmpty(txtAmountPaid.Text))
            {
                txtAmountPaid.Text = @"0.0";
            }

            if (hfUnitTypeDetails.Value.Trim() == @"Unit" && lblElementTypeDetails.Text == @"Calculated" &&
                txtUnitDetails.Text == @"0.0")
            {
                txtUnitDetails.Text = @"1.0";
                txtAmountPaid.Text = lblRateIdDetails.Text;
            }

            if (hfUnitTypeDetails.Value.Trim() == @"Time" && lblElementTypeDetails.Text == @"Fixed")
            {
                txtUnitDetails.Text = @"1.0";
                txtAmountPaid.Text = lblRateIdDetails.Text;
            }
            if (hfUnitTypeDetails.Value.Trim() == @"Time" && lblElementTypeDetails.Text == @"Calculated" && (string.IsNullOrEmpty(txtTimeFromDetails.Text) || string.IsNullOrEmpty(txtTimeToDetails.Text)))
            {
                lblAllowanceDetailsErrorMsg.Text = Resources.Resource.MsgFromTimeToTimeRequired;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtTimeFromDetails.Text))
                {
                    DateTime fromTime = DateTime.Parse("1901-01-01 " + txtTimeFromDetails.Text + ":00");
                    DateTime toTime = DateTime.Parse("1901-01-01 " + txtTimeToDetails.Text + ":00");
                    if (fromTime > toTime)
                    {
                        toTime = DateTime.Parse("1901-01-02 " + txtTimeToDetails.Text + ":00");
                    }
                    TimeSpan ts = toTime.Subtract(fromTime);
                    dutyMin = ((ts.Hours * 60) + ((ts.Minutes))).ToString();
                }
                if (lblElementTypeDetails.Text.ToLower() == "Fixed".ToLower())
                {
                    ds = objRoster.RosterAllowanceDetailsUpdate(hfRosterAllowanceDetailsAutoId.Value,
                                                                Request.QueryString["ScheduleRosterAutoID"],
                                                                lblEmployeeNumberAllowanceDetails.Text,
                                                                ddlAllowanceDetailsDescription.SelectedValue,
                                                                lblDutyDateAllowanceDetails.Text, txtTimeFromDetails.Text,
                                                                txtTimeToDetails.Text, dutyMin, BaseUserID,
                                                                BaseLocationAutoID, Request.QueryString["ClientCode"],
                                                                Request.QueryString["AsmtID"],
                                                                Request.QueryString["PostCode"],
                                                                Request.QueryString["RowNumber"], lblMeasurement.Text,
                                                                Convert.ToDecimal(txtUnitDetails.Text),
                                                                Convert.ToDecimal(txtAmountPaid.Text),
                                                                Convert.ToBoolean(
                                                                    Convert.ToInt32(ddlBillable.SelectedItem.Value)),
                                                                txtComment.Text);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DisplayMessage(lblAllowanceDetailsErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    }
                    gvAllowanceDetails.EditIndex = -1;
                    FillgvEmpAllowanceDetails();
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtTimeFromDetails.Text) && !String.IsNullOrEmpty(txtTimeFromDetails.Text))
                    {
                        if (CheckTimeValidity(txtTimeFromDetails, txtTimeToDetails))
                        {
                            ds = objRoster.RosterAllowanceDetailsUpdate(hfRosterAllowanceDetailsAutoId.Value,
                                                                        Request.QueryString["ScheduleRosterAutoID"],
                                                                        lblEmployeeNumberAllowanceDetails.Text,
                                                                        ddlAllowanceDetailsDescription.SelectedValue,
                                                                        lblDutyDateAllowanceDetails.Text,
                                                                        txtTimeFromDetails.Text, txtTimeToDetails.Text,
                                                                        dutyMin, BaseUserID, BaseLocationAutoID,
                                                                        Request.QueryString["ClientCode"],
                                                                        Request.QueryString["AsmtID"],
                                                                        Request.QueryString["PostCode"],
                                                                        Request.QueryString["RowNumber"],
                                                                        lblMeasurement.Text,
                                                                        Convert.ToDecimal(txtUnitDetails.Text),
                                                                        Convert.ToDecimal(txtAmountPaid.Text),
                                                                        Convert.ToBoolean(
                                                                            Convert.ToInt32(ddlBillable.SelectedItem.Value)),
                                                                        txtComment.Text);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                DisplayMessage(lblAllowanceDetailsErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            }
                            gvAllowanceDetails.EditIndex = -1;
                            FillgvEmpAllowanceDetails();
                        }
                        else
                        {
                            lblAllowanceDetailsErrorMsg.Text = Resources.Resource.InvalidTime;
                        }
                    }
                    else
                    {
                        ds = objRoster.RosterAllowanceDetailsUpdate(hfRosterAllowanceDetailsAutoId.Value,
                                                                    Request.QueryString["ScheduleRosterAutoID"],
                                                                    lblEmployeeNumberAllowanceDetails.Text,
                                                                    ddlAllowanceDetailsDescription.SelectedValue,
                                                                    lblDutyDateAllowanceDetails.Text,
                                                                    txtTimeFromDetails.Text, txtTimeToDetails.Text, dutyMin,
                                                                    BaseUserID, BaseLocationAutoID,
                                                                    Request.QueryString["ClientCode"],
                                                                    Request.QueryString["AsmtID"],
                                                                    Request.QueryString["PostCode"],
                                                                    Request.QueryString["RowNumber"], lblMeasurement.Text,
                                                                    Convert.ToDecimal(txtUnitDetails.Text),
                                                                    Convert.ToDecimal(txtAmountPaid.Text),
                                                                    Convert.ToBoolean(
                                                                        Convert.ToInt32(ddlBillable.SelectedItem.Value)),
                                                                    txtComment.Text);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DisplayMessage(lblAllowanceDetailsErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                        }
                        gvAllowanceDetails.EditIndex = -1;
                        FillgvEmpAllowanceDetails();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on AllowanceDetails Grid on CancelEditing event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            gvAllowanceDetails.EditIndex = -1;
            FillgvEmpAllowanceDetails();
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on AllowanceDetails Grid on PageIndex Editing event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAllowanceDetails.PageIndex = e.NewPageIndex;
            FillgvEmpAllowanceDetails();
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on AllowanceDetails Grid on RowEditing event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvAllowanceDetails.EditIndex = e.NewEditIndex;
            FillgvEmpAllowanceDetails();
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on AllowanceDetails Grid on RowDeleting event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            var objRoster = new BL.Roster();
            var hfRosterAllowanceDetailsAutoId = (HiddenField)gvAllowanceDetails.Rows[e.RowIndex].FindControl("hfRosterAllowanceDetailsAutoId");
            DataSet ds = objRoster.RosterAllowanceDetailsDelete(hfRosterAllowanceDetailsAutoId.Value, BaseLocationAutoID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DisplayMessage(lblAllowanceDetailsErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            FillgvEmpAllowanceDetails();
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on AllowanceDetails Grid on RowDataBound event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvAllowanceDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddlAllowanceDetailsDescription = (DropDownList)e.Row.FindControl("ddlAllowanceDetailsDescription");
                var hfAllowanceDetailsAutoId = (HiddenField)e.Row.FindControl("hfAllowanceDetailsAutoId");

                var hfBillable = (HiddenField)e.Row.FindControl("hfBillable");
                var lblElementTypeDetails = (Label)e.Row.FindControl("lblElementTypeDetails");
                var hfUnitTypeDetails = (HiddenField)e.Row.FindControl("hfUnitTypeDetails");
                var txtTimeFromDetails = (TextBox)e.Row.FindControl("txtTimeFromDetails");
                var txtTimeToDetails = (TextBox)e.Row.FindControl("txtTimeToDetails");
                var lblRateIdDetails = (Label)e.Row.FindControl("lblRateIdDetails");
                var txtUnitDetails = (TextBox)e.Row.FindControl("txtUnitDetails");
                var txtAmountPaid = (TextBox)e.Row.FindControl("txtAmountPaid");
                var ddlBillable = (DropDownList)e.Row.FindControl("ddlBillable");
                var txtComment = (TextBox)e.Row.FindControl("txtComment");

                if (ddlAllowanceDetailsDescription != null)
                {
                    FillAllowanceDescription(ddlAllowanceDetailsDescription);
                    ddlAllowanceDetailsDescription.SelectedValue = hfAllowanceDetailsAutoId.Value;
                }
                if (ddlBillable != null)
                {
                    ddlBillable.SelectedValue = hfBillable.Value.Trim() == @"Yes" ? @"1" : @"0";
                }
                if (txtTimeFromDetails != null && txtTimeToDetails != null && txtUnitDetails != null && txtAmountPaid != null && txtComment != null && hfUnitTypeDetails != null && lblElementTypeDetails != null && ddlBillable != null)
                {
                    //Added Code for UnitType Unit Enable/Disable Columns based on UnitType
                    if (hfUnitTypeDetails.Value.Trim() == "Unit")
                    {
                        txtTimeFromDetails.Enabled = false;
                        txtTimeToDetails.Enabled = false;
                        txtUnitDetails.Enabled = true;
                        txtAmountPaid.Enabled = true;
                        ddlBillable.Enabled = true;
                        //txtComment.Enabled = true;
                    }
                    else
                    {
                        txtTimeFromDetails.Enabled = true;
                        txtTimeToDetails.Enabled = true;
                        txtUnitDetails.Enabled = false;
                        txtAmountPaid.Enabled = false;
                        ddlBillable.Enabled = false;
                        //txtComment.Enabled = false;
                    }
                    if (hfUnitTypeDetails.Value.Trim() == @"Unit" && lblElementTypeDetails.Text == @"Fixed")
                    {
                        txtUnitDetails.Enabled = false;
                    }
                    if (hfUnitTypeDetails.Value.Trim() == @"Time" && lblElementTypeDetails.Text == @"Fixed")
                    {
                        txtTimeFromDetails.Text = "";
                        txtTimeToDetails.Text = "";
                        txtTimeFromDetails.Enabled = false;
                        txtTimeToDetails.Enabled = false;
                    }
                    //End
                }

                var ImgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (ImgbtnUpdate != null)
                {
                    //                ImgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                }

                var IBDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (IBDelete != null)
                {
                    //                IBDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                var ddlAllowanceDetailsDescription = (DropDownList)e.Row.FindControl("ddlAllowanceDetailsDescription");
                var lblElementDetails = (Label)e.Row.FindControl("lblElementDetails");
                var lblElementTypeDetails = (Label)e.Row.FindControl("lblElementTypeDetails");
                var lblRateIdDetails = (Label)e.Row.FindControl("lblRateIdDetails");
                var txtFooterTimeFromDetails = (TextBox)e.Row.FindControl("txtFooterTimeFromDetails");
                var txtFooterTimeToDetails = (TextBox)e.Row.FindControl("txtFooterTimeToDetails");
                var lblMeasurement = (Label)e.Row.FindControl("lblMeasurement");
                var hfUnitTypeDetails = (HiddenField)e.Row.FindControl("hfUnitTypeDetails");
                var txtUnitDetails = (TextBox)e.Row.FindControl("txtUnitDetails");
                var txtAmountPaid = (TextBox)e.Row.FindControl("txtAmountPaid");
                var ddlBillable = (DropDownList)e.Row.FindControl("ddlBillable");
                var txtComment = (TextBox)e.Row.FindControl("txtComment");

                if (ddlAllowanceDetailsDescription != null)
                {
                    FillAllowanceDescription(ddlAllowanceDetailsDescription);
                    GetElementDetailsByAllowanceDetailsAutoId(ddlAllowanceDetailsDescription, lblElementDetails, lblElementTypeDetails, hfUnitTypeDetails, txtUnitDetails, txtAmountPaid, lblMeasurement, lblRateIdDetails);
                }
                if (txtFooterTimeFromDetails != null)
                {
                    if (lblElementTypeDetails.Text == @"Calculated")
                    {
                        txtFooterTimeFromDetails.Enabled = true;
                        txtFooterTimeToDetails.Enabled = true;
                    }
                    else
                    {
                        if (Request.QueryString["ScheduleRosterAutoID"].Trim().ToLower() != "-1".Trim().ToLower())
                        {
                            txtFooterTimeFromDetails.Enabled = false;
                            txtFooterTimeToDetails.Enabled = false;
                        }
                        else
                        {
                            txtFooterTimeFromDetails.Enabled = true;
                            txtFooterTimeToDetails.Enabled = true;
                        }
                    }
                }

                if (txtFooterTimeFromDetails != null && txtFooterTimeToDetails != null && txtUnitDetails != null && txtAmountPaid != null && txtComment != null && hfUnitTypeDetails != null && ddlBillable != null)
                {
                    //Added Code for UnitType Enable/Disable Columns based on UnitType
                    if (hfUnitTypeDetails.Value.Trim() == @"Unit")
                    {
                        txtFooterTimeFromDetails.Enabled = false;
                        txtFooterTimeToDetails.Enabled = false;
                        txtUnitDetails.Enabled = true;
                        txtAmountPaid.Enabled = true;
                        ddlBillable.Enabled = true;
                        //txtComment.Enabled = true;
                    }
                    else
                    {
                        txtFooterTimeFromDetails.Enabled = true;
                        txtFooterTimeToDetails.Enabled = true;
                        txtUnitDetails.Enabled = false;
                        txtAmountPaid.Enabled = false;
                        ddlBillable.Enabled = false;
                        //txtComment.Enabled = false;
                    }
                    //End
                    if (hfUnitTypeDetails.Value.Trim() == @"Time" && lblElementTypeDetails.Text == @"Fixed")
                    {
                        txtFooterTimeFromDetails.Text = "";
                        txtFooterTimeToDetails.Text = "";
                        txtFooterTimeFromDetails.Enabled = false;
                        txtFooterTimeToDetails.Enabled = false;
                    }
                    if (hfUnitTypeDetails.Value.Trim() == @"Unit" && lblElementTypeDetails.Text == @"Fixed")
                    {
                        txtUnitDetails.Enabled = false;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on AllowanceDetails Description DropDown on SelectChange event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAllowanceDetailsDescription_OnSelectedChange(object sender, EventArgs e)
    {
        try
        {
            var ddlAllowanceDetailsDescription = (DropDownList)sender;
            var gvRow = (GridViewRow)ddlAllowanceDetailsDescription.NamingContainer;
            var lblElementDetails = (Label)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("lblElementDetails");
            var lblElementTypeDetails = (Label)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("lblElementTypeDetails");
            var lblRateIdDetails = (Label)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("lblRateIdDetails");
            var txtTimeFromDetails = (TextBox)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("txtTimeFromDetails");
            var txtTimeToDetails = (TextBox)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("txtTimeToDetails");
            var lblMeasurement = (Label)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("lblMeasurement");
            var hfUnitTypeDetails = (HiddenField)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("hfUnitTypeDetails");
            var txtUnitDetails = (TextBox)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("txtUnitDetails");
            var txtAmountPaid = (TextBox)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("txtAmountPaid");
            var ddlBillable = (DropDownList)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("ddlBillable");

            GetElementDetailsByAllowanceDetailsAutoId(ddlAllowanceDetailsDescription, lblElementDetails, lblElementTypeDetails, hfUnitTypeDetails, txtUnitDetails, txtAmountPaid, lblMeasurement, lblRateIdDetails);
            if (txtTimeFromDetails != null)
            {
                if (lblElementTypeDetails.Text == @"Calculated")
                {
                    txtTimeFromDetails.Enabled = true;
                    txtTimeToDetails.Enabled = true;
                }
                else
                {
                    txtTimeFromDetails.Text = "";
                    txtTimeToDetails.Text = "";

                    if (Request.QueryString["ScheduleRosterAutoID"].Trim().ToLower() != "-1".Trim().ToLower())
                    {
                        txtTimeFromDetails.Enabled = false;
                        txtTimeToDetails.Enabled = false;
                    }
                    else
                    {
                        txtTimeFromDetails.Enabled = true;
                        txtTimeToDetails.Enabled = true;
                    }
                }
                //Added Code for UnitType Unit Enable/Disable Columns based on UnitType
                if (hfUnitTypeDetails.Value.Trim() == "Unit")
                {
                    txtTimeFromDetails.Enabled = false;
                    txtTimeToDetails.Enabled = false;
                    //txtUnitDetails.Enabled = true;
                    txtAmountPaid.Enabled = true;
                    ddlBillable.Enabled = true;
                }
                else
                {
                    txtTimeFromDetails.Enabled = true;
                    txtTimeToDetails.Enabled = true;
                    txtUnitDetails.Enabled = false;
                    txtAmountPaid.Enabled = false;
                    ddlBillable.Enabled = false;
                }
                //End
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function called on AllowanceDetails Description DropDownList on SelectedIndexChange event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAllowanceDetailsDescription_SelectedIndexChange(object sender, EventArgs e)
    {
        try
        {
            var lblElementDetails = (Label)gvAllowanceDetails.FooterRow.FindControl("lblElementDetails");
            var lblElementTypeDetails = (Label)gvAllowanceDetails.FooterRow.FindControl("lblElementTypeDetails");
            var ddlAllowanceDetailsDescription = (DropDownList)gvAllowanceDetails.FooterRow.FindControl("ddlAllowanceDetailsDescription");
            var lblRateIdDetails = (Label)gvAllowanceDetails.FooterRow.FindControl("lblRateIdDetails");
            var txtFooterTimeFromDetails = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtFooterTimeFromDetails");
            var txtFooterTimeToDetails = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtFooterTimeToDetails");
            var lblMeasurement = (Label)gvAllowanceDetails.FooterRow.FindControl("lblMeasurement");
            var hfUnitTypeDetails = (HiddenField)gvAllowanceDetails.FooterRow.FindControl("hfUnitTypeDetails");
            var txtUnitDetails = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtUnitDetails");
            var txtAmountPaid = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtAmountPaid");
            var ddlBillable = (DropDownList)gvAllowanceDetails.FooterRow.FindControl("ddlBillable");

            GetElementDetailsByAllowanceDetailsAutoId(ddlAllowanceDetailsDescription, lblElementDetails, lblElementTypeDetails, hfUnitTypeDetails, txtUnitDetails, txtAmountPaid, lblMeasurement, lblRateIdDetails);
            if (txtFooterTimeFromDetails != null)
            {
                if (lblElementTypeDetails.Text == @"Calculated")
                {
                    txtFooterTimeFromDetails.Enabled = true;
                    txtFooterTimeToDetails.Enabled = true;
                }
                else
                {
                    if (Request.QueryString["ScheduleRosterAutoID"].Trim().ToLower() != "-1".Trim().ToLower())
                    {
                        txtFooterTimeFromDetails.Enabled = false;
                        txtFooterTimeToDetails.Enabled = false;
                    }
                    else
                    {
                        txtFooterTimeFromDetails.Enabled = true;
                        txtFooterTimeToDetails.Enabled = true;
                    }
                }
                //Added Code for UnitType Unit Enable/Disable Columns based on UnitType
                if (hfUnitTypeDetails.Value.Trim() == "Unit")
                {
                    txtFooterTimeFromDetails.Text = "";
                    txtFooterTimeToDetails.Text = "";
                    txtFooterTimeFromDetails.Enabled = false;
                    txtFooterTimeToDetails.Enabled = false;
                    //txtUnitDetails.Enabled = true;
                    txtAmountPaid.Enabled = true;
                    ddlBillable.Enabled = true;
                }
                else
                {
                    txtUnitDetails.Text = "";
                    txtAmountPaid.Text = "";
                    ddlBillable.SelectedIndex = 0;
                    txtFooterTimeFromDetails.Enabled = true;
                    txtFooterTimeToDetails.Enabled = true;
                    txtUnitDetails.Enabled = false;
                    txtAmountPaid.Enabled = false;
                    ddlBillable.Enabled = false;
                }
                if (hfUnitTypeDetails.Value.Trim() == @"Time" && lblElementTypeDetails.Text == @"Fixed")
                {
                    txtFooterTimeFromDetails.Text = "";
                    txtFooterTimeToDetails.Text = "";
                    txtFooterTimeFromDetails.Enabled = false;
                    txtFooterTimeToDetails.Enabled = false;
                }
                //End
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function used to Get the details of Elements based on AllowanceDescription.
    /// </summary>
    /// <param name="ddlAllowanceDesc">The DDL allowance desc.</param>
    /// <param name="lblElem">The label elem.</param>
    /// <param name="lblElemType">Type of the label elem.</param>
    /// <param name="hfUnitTypeDetails">The hf unit type details.</param>
    /// <param name="txtUnitDetails">The text unit details.</param>
    /// <param name="txtAmountPaid">The text amount paid.</param>
    /// <param name="lblMeasurement">The label measurement.</param>
    /// <param name="lblRateIdDetails">The label rate identifier details.</param>
    protected void GetElementDetailsByAllowanceDetailsAutoId(DropDownList ddlAllowanceDesc, Label lblElem, Label lblElemType, HiddenField hfUnitTypeDetails, TextBox txtUnitDetails, TextBox txtAmountPaid, Label lblMeasurement, Label lblRateIdDetails)
    {
        try
        {
            var objRoster = new BL.Roster();
            if (ddlAllowanceDesc.SelectedValue != string.Empty)
            {
                DataSet dsAllowance = objRoster.ElementDetailsByAllowanceAutoIdGet(ddlAllowanceDesc.SelectedValue);
                if (dsAllowance != null && dsAllowance.Tables.Count > 0 && dsAllowance.Tables[0].Rows.Count > 0)
                {
                    lblElem.Text = dsAllowance.Tables[0].Rows[0]["Element"].ToString();
                    lblElemType.Text = dsAllowance.Tables[0].Rows[0]["ElementType"].ToString();
                    lblRateIdDetails.Text = String.Format(hfspDecimalPlace.Value, dsAllowance.Tables[0].Rows[0]["RateID"]);
                    lblMeasurement.Text = dsAllowance.Tables[0].Rows[0]["Measurement"].ToString();
                    hfUnitTypeDetails.Value = dsAllowance.Tables[0].Rows[0]["UnitType"].ToString();

                    //Added Code to Check UnitType and perform AmountPaid accordingly.
                    if (hfUnitTypeDetails.Value.Trim() == @"Unit")
                    {
                        DataSet dsUnitDetails = objRoster.UnitDetailsByAllowanceAutoIdGet(ddlAllowanceDesc.SelectedValue);
                        if (dsUnitDetails != null && dsUnitDetails.Tables.Count > 0 && dsUnitDetails.Tables[0].Rows.Count > 0)
                        {
                            txtUnitDetails.Text = String.Format(hfspDecimalPlace.Value, dsUnitDetails.Tables[0].Rows[0]["Unit"]);
                            txtAmountPaid.Text = String.Format(hfspDecimalPlace.Value, dsUnitDetails.Tables[0].Rows[0]["AmountPaid"]);

                            txtUnitDetails.Enabled = lblElemType.Text.Trim() != @"Fixed";
                        }
                    }
                    //End
                }
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function used to Get the details of Allowance.
    /// </summary>
    /// <param name="ddlAllowanceDesc">The DDL allowance desc.</param>
    protected void FillAllowanceDescription(DropDownList ddlAllowanceDesc)
    {
        try
        {
            var objRoster = new BL.Roster();
            DataSet dsAllowance = objRoster.AllowanceDescriptionGet(BaseLocationAutoID);
            if (dsAllowance != null && dsAllowance.Tables.Count > 0 && dsAllowance.Tables[0].Rows.Count > 0)
            {
                ddlAllowanceDesc.DataSource = dsAllowance.Tables[0];
                ddlAllowanceDesc.DataTextField = "AllowanceDescription";
                ddlAllowanceDesc.DataValueField = "AllowanceAutoID";
                ddlAllowanceDesc.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function call on Textbox txtUnitDetails OnTextChanged Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtUnitDetails_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            var lblRateIdDetails = (Label)gvAllowanceDetails.FooterRow.FindControl("lblRateIdDetails");
            var txtUnitDetails = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtUnitDetails");
            var txtAmountPaid = (TextBox)gvAllowanceDetails.FooterRow.FindControl("txtAmountPaid");
            if (!String.IsNullOrEmpty(lblRateIdDetails.Text) && !String.IsNullOrEmpty(txtUnitDetails.Text))
            {
                txtAmountPaid.Text = String.Format(hfspDecimalPlace.Value, (Convert.ToDecimal(lblRateIdDetails.Text) * Convert.ToDecimal(txtUnitDetails.Text)));
                txtAmountPaid.Focus();
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }

    /// <summary>
    /// Function call on Textbox txtUnitDetails On Edit TextChanged Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtUnitDetails_OnEditTextChanged(object sender, EventArgs e)
    {
        try
        {
            var ddlAllowanceDetailsDescription = (TextBox)sender;
            var gvRow = (GridViewRow)ddlAllowanceDetailsDescription.NamingContainer;

            var lblRateIdDetails = (Label)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("lblRateIdDetails");
            var txtUnitDetails = (TextBox)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("txtUnitDetails");
            var txtAmountPaid = (TextBox)gvAllowanceDetails.Rows[gvRow.RowIndex].FindControl("txtAmountPaid");
            if (!String.IsNullOrEmpty(lblRateIdDetails.Text) && !String.IsNullOrEmpty(txtUnitDetails.Text))
            {
                txtAmountPaid.Text = String.Format(hfspDecimalPlace.Value, (Convert.ToDecimal(lblRateIdDetails.Text) * Convert.ToDecimal(txtUnitDetails.Text)));
                txtAmountPaid.Focus();
            }
        }
        catch (Exception ex)
        {
            lblAllowanceDetailsErrorMsg.Text = ex.Message;
        }
    }
    #endregion
}