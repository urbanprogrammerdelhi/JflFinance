// ***********************************************************************
// Assembly         :
// Author           : 
// Created          : 09-13-2013
//
// Last Modified By : 
// Last Modified On : 02-26-2014
// ***********************************************************************
// <copyright file="DutyCaping.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Duty Capping Screen Code behind
/// </summary>
public partial class UserManagement_DutyCaping : BasePage
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
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillCappingHeader();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }

    /// <summary>
    /// Handles the RowDataBound event of the CappingHeader control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void CappingHeader_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            CappingHeader.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsModifyAccess == false)
            {
                var imgbtnEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (imgbtnEdit != null)
                {
                    imgbtnEdit.Visible = false;
                }

            }
            else
            {
                var imgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (imgbtnUpdate != null)
                {
                    imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }
                var cappingHeaderLevel = (Label)e.Row.FindControl("CappingHeaderLevel");
                if (cappingHeaderLevel != null)
                {
                    cappingHeaderLevel.Text = cappingHeaderLevel.Text == @"U" ? Resources.Resource.User : Resources.Resource.UserGroupCode;
                }
                var cappingHeaderLevelDesc = (RadComboBox)e.Row.FindControl("CappingHeaderLevelDesc");
                var hfCappingHeaderLevel = (HiddenField)e.Row.FindControl("hfCappingHeaderLevel");
                var cappingHeaderCode = (LinkButton)e.Row.FindControl("CappingHeaderCode");

                var cappingHeaderDescription = (TextBox)e.Row.FindControl("CappingHeaderDescription");
                if (cappingHeaderDescription != null)
                {
                    cappingHeaderDescription.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    cappingHeaderDescription.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                if (cappingHeaderLevelDesc != null)
                {
                    FillCappingHeaderLevelDesc(hfCappingHeaderLevel.Value, cappingHeaderLevelDesc, "ROW", cappingHeaderCode.Text);
                }
            }

            if (IsDeleteAccess == false)
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (imgbtnDelete != null)
                {
                    imgbtnDelete.Visible = false;
                }
            }
            else
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (imgbtnDelete != null)
                {
                    imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                CappingHeader.ShowFooter = false;
            }
            else
            {
                var lbAdd = (ImageButton)e.Row.FindControl("lbADD");
                if (lbAdd != null)
                {
                    lbAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }
                var cappingHeaderLevel = (DropDownList)e.Row.FindControl("CappingHeaderLevel");
                var cappingHeaderLevelDesc = (RadComboBox)e.Row.FindControl("CappingHeaderLevelDesc");
                var cappingHeaderCode = (TextBox)e.Row.FindControl("CappingHeaderCode");

                var cappingHeaderDescription = (TextBox)e.Row.FindControl("CappingHeaderDescription");
                if (cappingHeaderDescription != null)
                {
                    cappingHeaderDescription.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                    cappingHeaderDescription.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                }

                if (cappingHeaderCode != null)
                {
                    cappingHeaderCode.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                    cappingHeaderCode.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                }

                if (cappingHeaderLevel != null && cappingHeaderLevelDesc != null)
                {
                    if (cappingHeaderCode != null)
                        FillCappingHeaderLevelDesc(cappingHeaderLevel.SelectedValue, cappingHeaderLevelDesc, "FOOTER", cappingHeaderCode.Text);
                }
            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the CappingHeader control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void CappingHeader_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var userManagement = new BL.UserManagement();

        var cappingHeaderCode = (TextBox)CappingHeader.FooterRow.FindControl("CappingHeaderCode");
        var cappingHeaderDescription = (TextBox)CappingHeader.FooterRow.FindControl("CappingHeaderDescription");
        var cappingHeaderLevel = (DropDownList)CappingHeader.FooterRow.FindControl("CappingHeaderLevel");
        var cappingHeaderLevelDesc = (RadComboBox)CappingHeader.FooterRow.FindControl("CappingHeaderLevelDesc");


        if (e.CommandName.Equals("AddNew"))
        {
            if (cappingHeaderCode.Text == string.Empty)
            {
                lblErrorMsg.Text = Resources.Resource.CannotBeLeftBlank;
                cappingHeaderCode.Focus();
                return;
            }
            var collection = cappingHeaderLevelDesc.CheckedItems;
            var checkedItems = string.Empty;
            if (collection.Count != 0)
            {
                foreach (var item in collection)
                {
                    checkedItems = checkedItems + "," + item.Value;
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.CannotBeLeftBlank;
                cappingHeaderLevelDesc.Focus();
                return;
            }


            using (var dsCaping = userManagement.CappingHeaderInsert(cappingHeaderCode.Text, cappingHeaderDescription.Text, cappingHeaderLevel.SelectedValue, checkedItems, BaseUserID))
            {
                CappingHeader.EditIndex = -1;
                cappingHeaderLevelDesc.Items.Clear();
                FillCappingHeader();
                DisplayMessage(lblErrorMsg, dsCaping.Tables[0].Rows[0]["MessageID"].ToString());

            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            cappingHeaderCode.Text = string.Empty;
            cappingHeaderDescription.Text = string.Empty;
        }

    }

    /// <summary>
    /// Handles the RowEditing event of the CappingHeader control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void CappingHeader_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CappingHeader.EditIndex = e.NewEditIndex;
        FillCappingHeader();
    }

    /// <summary>
    /// Handles the RowUpdating event of the CappingHeader control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void CappingHeader_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var userManagement = new BL.UserManagement();

        var cappingHeaderCode = (LinkButton)CappingHeader.Rows[e.RowIndex].FindControl("CappingHeaderCode");
        var cappingHeaderDescription = (TextBox)CappingHeader.Rows[e.RowIndex].FindControl("CappingHeaderDescription");
        var hfCappingHeaderLevel = (HiddenField)CappingHeader.Rows[e.RowIndex].FindControl("hfCappingHeaderLevel");
        var cappingHeaderLevelDesc = (RadComboBox)CappingHeader.Rows[e.RowIndex].FindControl("CappingHeaderLevelDesc");
        var collection = cappingHeaderLevelDesc.CheckedItems;
        var checkedItems = string.Empty;
        if (collection.Count != 0)
        {
            foreach (var item in collection)
            {
                checkedItems = checkedItems + "," + item.Value;
            }
        }
        using (userManagement.CappingHeaderUpdate(cappingHeaderCode.Text, cappingHeaderDescription.Text, hfCappingHeaderLevel.Value, checkedItems, BaseUserID))
        {
            CappingHeader.EditIndex = -1;
            FillCappingHeader();
        }

    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the CappingHeader control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void CappingHeader_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        CappingHeader.EditIndex = -1;
        FillCappingHeader();
    }

    /// <summary>
    /// Handles the RowDeleting event of the CappingHeader control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void CappingHeader_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var cappingHeaderCode = (LinkButton)CappingHeader.Rows[e.RowIndex].FindControl("CappingHeaderCode");
        var userManagement = new BL.UserManagement();
        using (var dsCaping = userManagement.CappingHeaderDelete(cappingHeaderCode.Text))
        {
            FillCappingHeader();
            CappingDetail.DataSource = null;
            CappingDetail.DataBind();
            DisplayMessage(lblErrorMsg, dsCaping.Tables[0].Rows[0]["MessageID"].ToString());
        }

        
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the CappingHeader control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void CappingHeader_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CappingHeader.PageIndex = e.NewPageIndex;
        CappingHeader.EditIndex = -1;
        FillCappingHeader();
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the CappingHeaderLevel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void CappingHeaderLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        var cappingHeaderLevel = (DropDownList)CappingHeader.FooterRow.FindControl("CappingHeaderLevel");
        var cappingHeaderLevelDesc = (RadComboBox)CappingHeader.FooterRow.FindControl("CappingHeaderLevelDesc");
        var cappingHeaderCode = (TextBox)CappingHeader.FooterRow.FindControl("CappingHeaderCode");
        FillCappingHeaderLevelDesc(cappingHeaderLevel.SelectedValue, cappingHeaderLevelDesc, "FOOTER", cappingHeaderCode.Text);
    }

    /// <summary>
    /// Handles the Click event of the CappingHeaderCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void CappingHeaderCode_Click(object sender, EventArgs e)
    {
        var linkButton = (LinkButton)sender;
        var row = (GridViewRow)linkButton.NamingContainer;
        var cappingHeaderCode = (LinkButton)CappingHeader.Rows[row.RowIndex].FindControl("CappingHeaderCode");
        HFCappingCode.Value = cappingHeaderCode.Text;
        FillCappingDetail(HFCappingCode.Value);
        CappingDetail.Visible = true;
        //var CappingHeaderCodeDetail = (Label)CappingDetail.FooterRow.FindControl("CappingHeaderCode");
        //CappingHeaderCodeDetail.Text = HFCappingCode.Value;
    }

    /// <summary>
    /// Handles the RowDataBound event of the CappingDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs" /> instance containing the event data.</param>
    protected void CappingDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            CappingDetail.Columns[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsModifyAccess == false)
            {
                var imgbtnEdit = (ImageButton)e.Row.FindControl("IBEdit");
                if (imgbtnEdit != null)
                {
                    imgbtnEdit.Visible = false;
                }

            }
            else
            {
                var imgbtnUpdate = (ImageButton)e.Row.FindControl("ImgbtnUpdate");
                if (imgbtnUpdate != null)
                {
                    imgbtnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }

                var hfCappingDetailMaxNightShiftInWeek = (HiddenField)e.Row.FindControl("HFCappingDetailMaxNightShiftInWeek");
                var hfCappingDetailMaxWorkingDaysInWeek = (HiddenField)e.Row.FindControl("HFCappingDetailMaxWorkingDaysInWeek");
                var hfCappingDetailContractDays = (HiddenField)e.Row.FindControl("HFCappingDetailContractDays");
                var hfCappingDetailAttendanceType = (HiddenField)e.Row.FindControl("HFCappingDetailAttendanceType");
                var cappingDetailMaxNightShiftInWeek = (DropDownList)e.Row.FindControl("CappingDetailMaxNightShiftInWeek");
                var cappingDetailMaxWorkingDaysInWeek = (DropDownList)e.Row.FindControl("CappingDetailMaxWorkingDaysInWeek");
                var cappingDetailContractDays = (DropDownList)e.Row.FindControl("CappingDetailContractDays");
                var cappingDetailAttendanceType = (DropDownList)e.Row.FindControl("CappingDetailAttendanceType");
                var ddlProfitability = (DropDownList)e.Row.FindControl("ddlProfitability");
                var hfProfitabilityCheck = (HiddenField)e.Row.FindControl("HFProfitabilityCheck");
                var lblProfitability = (Label)e.Row.FindControl("lblProfitability");
                if (cappingDetailMaxNightShiftInWeek != null && cappingDetailMaxWorkingDaysInWeek != null && cappingDetailContractDays != null && hfCappingDetailMaxNightShiftInWeek != null && hfCappingDetailMaxWorkingDaysInWeek != null && hfCappingDetailContractDays != null)
                {
                    cappingDetailMaxNightShiftInWeek.SelectedValue = hfCappingDetailMaxNightShiftInWeek.Value;
                    cappingDetailMaxWorkingDaysInWeek.SelectedValue = hfCappingDetailMaxWorkingDaysInWeek.Value;
                    cappingDetailContractDays.SelectedValue = hfCappingDetailContractDays.Value;
                    cappingDetailAttendanceType.SelectedValue = hfCappingDetailAttendanceType.Value;
                }

                if (lblProfitability != null)
                {
                    lblProfitability.Text = hfProfitabilityCheck.Value == "0" ? Resources.Resource.No : Resources.Resource.Yes;
                }
                if (ddlProfitability != null)
                {
                    if (hfProfitabilityCheck != null)
                    {
                        ddlProfitability.SelectedValue = hfProfitabilityCheck.Value;
                    }

                }


            }

            if (IsDeleteAccess == false)
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (imgbtnDelete != null)
                {
                    imgbtnDelete.Visible = false;
                }
            }
            else
            {
                var imgbtnDelete = (ImageButton)e.Row.FindControl("IBDelete");
                if (imgbtnDelete != null)
                {
                    imgbtnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                CappingDetail.ShowFooter = false;
            }
            else
            {
                var lbAdd = (ImageButton)e.Row.FindControl("lbADD");
                if (lbAdd != null)
                {
                    lbAdd.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID + "');";
                }

            }
        }
    }

    /// <summary>
    /// Handles the RowCommand event of the CappingDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void CappingDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var userManagement = new BL.UserManagement();

        var cappingHeaderCode = (Label)CappingDetail.FooterRow.FindControl("CappingHeaderCode");
        var cappingDetailContractDays = (DropDownList)CappingDetail.FooterRow.FindControl("CappingDetailContractDays");
        var cappingDetailAttendanceType = (DropDownList)CappingDetail.FooterRow.FindControl("CappingDetailAttendanceType");
        var cappingDetailMaxNumberOfHoursPerDay = (TextBox)CappingDetail.FooterRow.FindControl("CappingDetailMaxNumberOfHoursPerDay");
        var cappingDetailBreakBetweenShift = (TextBox)CappingDetail.FooterRow.FindControl("CappingDetailBreakBetweenShift");
        var cappingDetailMaxWorkingDaysInWeek = (DropDownList)CappingDetail.FooterRow.FindControl("CappingDetailMaxWorkingDaysInWeek");
        var cappingDetailMaxNightShiftInWeek = (DropDownList)CappingDetail.FooterRow.FindControl("CappingDetailMaxNightShiftInWeek");
        var cappingDetailMaxWeekHours = (TextBox)CappingDetail.FooterRow.FindControl("CappingDetailMaxWeekHours");
        var cappingDetailWeeklyRest = (TextBox)CappingDetail.FooterRow.FindControl("CappingDetailWeeklyRest");
        var cappingDetailMaxHoursInShift = (TextBox)CappingDetail.FooterRow.FindControl("CappingDetailMaxHoursInShift");
        var ddlProfitability = (DropDownList)CappingDetail.FooterRow.FindControl("ddlProfitability");

        if (e.CommandName.Equals("AddNew"))
        {
            string cappingDetailMaxNumberOfHoursPerDayInMin;
            if (CheckValidMin(cappingDetailMaxNumberOfHoursPerDay.Text) == false || CheckValidHrs(cappingDetailMaxNumberOfHoursPerDay.Text) == false)
            {

                cappingDetailMaxNumberOfHoursPerDay.Focus();
                return;
            }
            else
            {
                cappingDetailMaxNumberOfHoursPerDayInMin = ConvertTimeToMin(cappingDetailMaxNumberOfHoursPerDay.Text);

            }
            string cappingDetailBreakBetweenShiftInMin ;
            switch (CheckValidMin(cappingDetailBreakBetweenShift.Text))
            {
                case false:
                    cappingDetailBreakBetweenShift.Focus();
                    return;
                default:
                    cappingDetailBreakBetweenShiftInMin = ConvertTimeToMin(cappingDetailBreakBetweenShift.Text);
                    break;
            }
            string cappingDetailMaxWeekHoursInMin ;
            switch (CheckValidMin(cappingDetailMaxWeekHours.Text))
            {
                case false:
                    cappingDetailMaxWeekHours.Focus();
                    return;
                default:
                    cappingDetailMaxWeekHoursInMin = ConvertTimeToMin(cappingDetailMaxWeekHours.Text);
                    break;
            }
            string cappingDetailWeeklyRestInMin;
            switch (CheckValidMin(cappingDetailWeeklyRest.Text))
            {
                case false:
                    cappingDetailWeeklyRest.Focus();
                    return;
                default:
                    cappingDetailWeeklyRestInMin = ConvertTimeToMin(cappingDetailWeeklyRest.Text);
                    break;
            }

            string cappingDetailMaxHoursInShiftInMin;
            switch (CheckValidMin(cappingDetailMaxHoursInShift.Text))
            {
                case false:
                    cappingDetailMaxHoursInShift.Focus();
                    return;
                default:
                    cappingDetailMaxHoursInShiftInMin = ConvertTimeToMin(cappingDetailMaxHoursInShift.Text);
                    break;
            }

            using (var dsCaping = userManagement.CappingDetailInsert(cappingHeaderCode.Text, cappingDetailContractDays.SelectedValue, cappingDetailAttendanceType.SelectedValue,
                cappingDetailMaxNumberOfHoursPerDayInMin, cappingDetailBreakBetweenShiftInMin, cappingDetailMaxWorkingDaysInWeek.SelectedValue,
                cappingDetailMaxNightShiftInWeek.SelectedValue, cappingDetailMaxWeekHoursInMin, cappingDetailWeeklyRestInMin, cappingDetailMaxHoursInShiftInMin, BaseUserID, ddlProfitability.SelectedValue))
            {
                CappingDetail.EditIndex = -1;
                FillCappingDetail(HFCappingCode.Value);
                DisplayMessage(lblErrorMsg, dsCaping.Tables[0].Rows[0]["MessageID"].ToString());

            }
        }
        if (e.CommandName.Equals("Reset"))
        {
            cappingDetailMaxNumberOfHoursPerDay.Text = string.Empty;
            cappingDetailBreakBetweenShift.Text = string.Empty;
            cappingDetailMaxWeekHours.Text = string.Empty;
            cappingDetailWeeklyRest.Text = string.Empty;
            cappingDetailMaxHoursInShift.Text = string.Empty;
        }

    }

    /// <summary>
    /// Handles the RowEditing event of the CappingDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void CappingDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CappingDetail.EditIndex = e.NewEditIndex;
        FillCappingDetail(HFCappingCode.Value);
    }

    /// <summary>
    /// Handles the RowUpdating event of the CappingDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void CappingDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var userManagement = new BL.UserManagement();
        var cappingHeaderCode = (Label)CappingDetail.Rows[e.RowIndex].FindControl("CappingHeaderCode");
        var cappingDetailContractDays = (DropDownList)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailContractDays");
        var cappingDetailAttendanceType = (DropDownList)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailAttendanceType");
        var cappingDetailMaxNumberOfHoursPerDay = (TextBox)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailMaxNumberOfHoursPerDay");
        var cappingDetailBreakBetweenShift = (TextBox)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailBreakBetweenShift");
        var cappingDetailMaxWorkingDaysInWeek = (DropDownList)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailMaxWorkingDaysInWeek");
        var cappingDetailMaxNightShiftInWeek = (DropDownList)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailMaxNightShiftInWeek");
        var cappingDetailMaxWeekHours = (TextBox)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailMaxWeekHours");
        var cappingDetailWeeklyRest = (TextBox)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailWeeklyRest");
        var cappingDetailMaxHoursInShift = (TextBox)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailMaxHoursInShift");
        var ddlProfitability = (DropDownList)CappingDetail.Rows[e.RowIndex].FindControl("ddlProfitability");
        string cappingDetailMaxNumberOfHoursPerDayInMin;
        string cappingDetailBreakBetweenShiftInMin;
        string cappingDetailMaxWeekHoursInMin;
        string cappingDetailWeeklyRestInMin;
        string cappingDetailMaxHoursInShiftInMin;

        if (CheckValidMin(cappingDetailMaxNumberOfHoursPerDay.Text) == false || CheckValidHrs(cappingDetailMaxNumberOfHoursPerDay.Text) == false)
        {
            cappingDetailMaxNumberOfHoursPerDay.Focus();
            return;
        }
        else
        {

            cappingDetailMaxNumberOfHoursPerDayInMin = ConvertTimeToMin(cappingDetailMaxNumberOfHoursPerDay.Text);

        }
        switch (CheckValidMin(cappingDetailBreakBetweenShift.Text))
        {
            case false:
                cappingDetailBreakBetweenShift.Focus();
                return;
            default:
                cappingDetailBreakBetweenShiftInMin = ConvertTimeToMin(cappingDetailBreakBetweenShift.Text);
                break;
        }
        switch (CheckValidMin(cappingDetailMaxWeekHours.Text))
        {
            case false:
                cappingDetailMaxWeekHours.Focus();
                return;
            default:
                cappingDetailMaxWeekHoursInMin = ConvertTimeToMin(cappingDetailMaxWeekHours.Text);
                break;
        }
        switch (CheckValidMin(cappingDetailWeeklyRest.Text))
        {
            case false:
                cappingDetailWeeklyRest.Focus();
                return;
            default:
                cappingDetailWeeklyRestInMin = ConvertTimeToMin(cappingDetailWeeklyRest.Text);
                break;
        }

        switch (CheckValidMin(cappingDetailMaxHoursInShift.Text))
        {
            case false:
                cappingDetailMaxHoursInShift.Focus();
                return;
            default:
                cappingDetailMaxHoursInShiftInMin = ConvertTimeToMin(cappingDetailMaxHoursInShift.Text);
                break;
        }
        using (var dsCaping = userManagement.CappingDetailUpdate(cappingHeaderCode.Text, cappingDetailContractDays.SelectedValue, cappingDetailAttendanceType.SelectedValue,
                cappingDetailMaxNumberOfHoursPerDayInMin, cappingDetailBreakBetweenShiftInMin, cappingDetailMaxWorkingDaysInWeek.SelectedValue,
                cappingDetailMaxNightShiftInWeek.SelectedValue, cappingDetailMaxWeekHoursInMin, cappingDetailWeeklyRestInMin, cappingDetailMaxHoursInShiftInMin, BaseUserID,ddlProfitability.SelectedValue))
        {
            CappingDetail.EditIndex = -1;
            FillCappingDetail(HFCappingCode.Value);
            DisplayMessage(lblErrorMsg, dsCaping.Tables[0].Rows[0]["MessageID"].ToString());
        }

    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the CappingDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void CappingDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        CappingDetail.EditIndex = -1;
        FillCappingDetail(HFCappingCode.Value);
    }

    /// <summary>
    /// Handles the RowDeleting event of the CappingDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void CappingDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var userManagement = new BL.UserManagement();
        var cappingDetailContractDays = (Label)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailContractDays1");
        var cappingDetailAttendanceType = (Label)CappingDetail.Rows[e.RowIndex].FindControl("CappingDetailAttendanceType1");

        using (userManagement.CappingDetailDelete(HFCappingCode.Value, cappingDetailContractDays.Text, cappingDetailAttendanceType.Text))
        {
            FillCappingDetail(HFCappingCode.Value);
        }

    }

    /// <summary>
    /// Handles the PageIndexChanging event of the CappingDetail control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs" /> instance containing the event data.</param>
    protected void CappingDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CappingDetail.PageIndex = e.NewPageIndex;
        CappingDetail.EditIndex = -1;
        FillCappingDetail(HFCappingCode.Value);
    }

    /// <summary>
    /// Fills the capping header.
    /// </summary>
    private void FillCappingHeader()
    {
        var userManagement = new BL.UserManagement();

        var dtflag = 1;

        using (var dsCaping = userManagement.GetCappingHeader())
        {
            var dtCaping = dsCaping.Tables[0];
            //to fix empety gridview
            if (dtCaping.Rows.Count == 0)
            {
                dtflag = 0;
                dtCaping.Rows.Add(dtCaping.NewRow());
            }
            CappingHeader.DataSource = dtCaping;
            CappingHeader.DataBind();
            //to fix empety gridview
            if (dtflag == 0)
            {
                CappingHeader.Rows[0].Visible = false;
            }
        }
    }

    /// <summary>
    /// Fill Capping header level description
    /// </summary>
    /// <param name="cappingHeaderLevel">Capping Header level value</param>
    /// <param name="cappingHeaderLevelDesc">Capping Header level description</param>
    /// <param name="operationType">operation type</param>
    /// <param name="cappingHeaderCode">capping header code</param>
    private void FillCappingHeaderLevelDesc(string cappingHeaderLevel, RadComboBox cappingHeaderLevelDesc, string operationType, string cappingHeaderCode)
    {
        var user = new BL.UserManagement();
        if (operationType != "ROW")
        {
            cappingHeaderCode = string.Empty;
        }

        using (var dsCaping = user.GetCappingHeaderUsers(cappingHeaderLevel, cappingHeaderCode, operationType))
        {
            cappingHeaderLevelDesc.DataSource = dsCaping.Tables[0];
            cappingHeaderLevelDesc.DataTextField = "UserName";
            cappingHeaderLevelDesc.DataValueField = "UserID";
            if (operationType != null && operationType == "ROW")
            {
                cappingHeaderLevelDesc.DataCheckedField = "SelectedUser";
            }
            cappingHeaderLevelDesc.DataBind();
        }
    }

    /// <summary>
    /// Fills the capping detail.
    /// </summary>
    /// <param name="cappingCode">The capping code.</param>
    private void FillCappingDetail(string cappingCode)
    {
        var userManagement = new BL.UserManagement();

        var dtflag = 1;

        using (var dsCaping = userManagement.GetCappingDetails(cappingCode))
        {
            var dtCaping = dsCaping.Tables[0];
            //to fix empety gridview
            if (dtCaping.Rows.Count == 0)
            {
                dtflag = 0;
                dtCaping.Rows.Add(dtCaping.NewRow());
            }
            CappingDetail.DataSource = dtCaping;
            CappingDetail.DataBind();

            //to fix empety gridview
            if (dtflag == 0)
            {
                CappingDetail.Rows[0].Visible = false;
            }
        }
        try
        {
            // CappingDetail.Columns[10].Visible = false;
            var cappingHeaderCodeDetail = (Label)CappingDetail.FooterRow.FindControl("CappingHeaderCode");
            cappingHeaderCodeDetail.Text = HFCappingCode.Value;
        }
        // ReSharper disable EmptyGeneralCatchClause
        catch (Exception)
        // ReSharper restore EmptyGeneralCatchClause
        { }
    }

    /// <summary>
    /// To Check hours validation
    /// </summary>
    /// <param name="hrsValue">Hours Value</param>
    /// <returns>boolean value</returns>
    private bool CheckValidHrs(string hrsValue)
    {
        if (hrsValue != string.Empty)
        {
            string[] hrs = hrsValue.Split(':');
            if (int.Parse(hrs[0]) > 24)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// To convert hours to minutes
    /// </summary>
    /// <param name="time">Time Value</param>
    /// <returns>string value</returns>
    private string ConvertTimeToMin(string time)
    {
        if (time != string.Empty)
        {
            string[] dutyMin = time.Split(':');
            return (int.Parse(dutyMin[0]) * 60 + int.Parse(dutyMin[1])).ToString();
        }
        return "0";
    }

    /// <summary>
    /// Check Valid minute
    /// </summary>
    /// <param name="minValue">minute value</param>
    /// <returns>boolean value</returns>
    private bool CheckValidMin(string minValue)
    {
        if (minValue != string.Empty)
        {
            string[] min = minValue.Split(':');
            if (int.Parse(min[1]) > 59)
            {
                return false;
            }
        }

        return true;

    }
}