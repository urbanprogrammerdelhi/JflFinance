// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="SystemParameter.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class Masters_SystemParameter
/// </summary>
public partial class Masters_SystemParameter : BasePage
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
            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.SystemParameter + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            FillDetails(sender ,e);
            
          btnSave.Attributes.Add("OnClick","javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');");
        }
    }

    /// <summary>
    /// Fills the details.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void FillDetails(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.BusinessRule objPayRate = new BL.BusinessRule();
        ds = objPayRate.SystemParameterGet(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                ddlAttendanceType.SelectedValue = ds.Tables[0].Rows[0]["ScheduleType"].ToString();
                ShowPanelbasedOnAttendanceType(ds, sender, e);
            }
            catch (Exception ex)
            {
                ShowPanelbasedOnAttendanceType(ds, sender, e);
            }
        }
        else
        {
            ddlAttendanceType.SelectedValue = "Select";
            ShowPanelbasedOnAttendanceType();
        }

    }


    /// <summary>
    /// Handles the OnClick event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Select".Trim().ToLower())
        {
            txtMaxDutyMinInDay.Text = "";
            txtMaxHoursInMonth.Text = "";
            txtMaxHoursInWeek.Text = "";
            txtMinBreakBtwDuty.Text = "";
            return;
        }
        else
        {
            BL.BusinessRule objBusinessRule = new BL.BusinessRule();
            DataSet ds = new DataSet();
            string strWeekStartDay = string.Empty;
            string strWeekEndDay = string.Empty;
            string strMonthStartDay = string.Empty;
            string strNoOfDayInFirstFortnight = string.Empty;
            string strFromDate = string.Empty;
            string strToDate = string.Empty;
            string strFromDay = string.Empty;
            string strToDay = string.Empty;
            string strMaxDutyMinInWeek = string.Empty;
            string strMaxDutyMinInMonth = string.Empty;
            string strHrsBtwDuty = string.Empty;
            string strPatternType = string.Empty;
            string strAttendanceType = string.Empty;
            string strMaxDutyMinInDay = string.Empty;
            string strMonthlyScheduleType = string.Empty;
            strAttendanceType = ddlAttendanceType.SelectedValue.ToString();
            strMaxDutyMinInMonth = txtMaxHoursInMonth.Text;
            strMaxDutyMinInWeek = txtMaxHoursInWeek.Text;
            strHrsBtwDuty = txtMinBreakBtwDuty.Text;
            strPatternType = ddlApplyPatternType.SelectedValue.ToString();
            strMaxDutyMinInDay = txtMaxDutyMinInDay.Text;
            if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Weekly".ToString().Trim().ToLower())
            {
                if (RBLWeekly.SelectedValue.ToString().Trim().ToLower() == "WeekDay".ToString().Trim().ToLower())
                {
                    strWeekStartDay = ddlWeekStartDay.SelectedValue.ToString();
                    strWeekEndDay = ddlWeekEndDay.SelectedValue.ToString();
                    strMonthStartDay = "";
                    strNoOfDayInFirstFortnight = "";
                    strFromDate = "";
                    strToDate = "";
                    strFromDay = "";
                    strToDay = "";
                    strMonthlyScheduleType = "";
                }
                else
                {
                    strWeekStartDay = "";
                    strWeekEndDay = "";
                    if (txtStartDay.Text == "")
                    {
                        lblErrorMsg.Text = Resources.Resource.StartDayCannotbeleftBlank;// "Start Day Cannot be left Blank";
                        return;
                    }
                    strMonthStartDay = txtStartDay.Text;
                    strNoOfDayInFirstFortnight = "";
                    strFromDate = "";
                    strToDate = "";
                    strFromDay = "";
                    strToDay = "";
                    strMonthlyScheduleType = "";
                }
            }
            else if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Fortnightly".ToString().Trim().ToLower())
            {
                if (RBLWeekly.SelectedValue.ToString().Trim().ToLower() == "WeekDay".ToString().Trim().ToLower())
                {
                    strWeekStartDay = ddlWeekStartDay.SelectedValue.ToString();
                    strWeekEndDay = "";
                    strMonthStartDay = "";
                    strNoOfDayInFirstFortnight = ddlNoOfDayInFirstFortnight.SelectedValue.ToString();//txtNoOfDayInFirstFortnight.Text;
                    strFromDate = "";
                    strToDate = "";
                    strFromDay = "";
                    strToDay = "";
                    strMonthlyScheduleType = "";
                }
                else
                {
                    strWeekStartDay = "";
                    strWeekEndDay = "";
                    strMonthlyScheduleType = "";
                    if (txtStartDay.Text == "")
                    {
                        lblErrorMsg.Text = Resources.Resource.StartDayCannotbeleftBlank;//"Start Day Cannot be left Blank";
                        return;
                    }
                    strMonthStartDay = txtStartDay.Text;
                    strNoOfDayInFirstFortnight = ddlNoOfDayInFirstFortnight.SelectedValue.ToString();//txtNoOfDayInFirstFortnight.Text;
                    strFromDate = "";
                    strToDate = "";
                    strFromDay = "";
                    strToDay = "";
                }
            }
            else if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Monthly".ToString().Trim().ToLower())
            {
                // if (RBLMonthly.SelectedValue.ToString().Trim().ToLower() == "PayPeriod".ToString().Trim().ToLower())
                //  {
                strWeekStartDay = "";
                strWeekEndDay = "";
                strMonthStartDay = "";
                strNoOfDayInFirstFortnight = "";
                strMonthlyScheduleType = RBLMonthly.SelectedValue.ToString();
                strFromDate = "";
                strToDate = "";
                strFromDay = ddlFromDay.SelectedValue.ToString();
                strToDay = ddlToDay.SelectedValue.ToString();
                // }


            }
            else
            {
                strWeekStartDay = "";
                strWeekEndDay = "";
                strMonthStartDay = "";
                strNoOfDayInFirstFortnight = "";
                strMonthlyScheduleType = "";
                if (txtFromDate.Text == "" || txtToDate.Text == "")
                {
                    lblErrorMsg.Text = Resources.Resource.DateCannotbeleftBlank;// "Date Cannot be left Blank";
                    return;
                }
                strFromDate = txtFromDate.Text;
                strToDate = txtToDate.Text;
                strFromDay = ddlFromDay.SelectedValue.ToString();
                strToDay = ddlToDay.SelectedValue.ToString();
            }


//            ds = objBusinessRule.blSystemParameter_ScheduleInsert(BaseCompanyCode, BaseHrLocationCode, BaseLocationCode, strWeekStartDay, strWeekEndDay, strMonthStartDay, strFromDate, strToDate, strFromDay, strToDay, strMaxDutyMinInWeek, strMaxDutyMinInMonth, strHrsBtwDuty, strPatternType, strAttendanceType, strMaxDutyMinInDay, strMonthlyScheduleType, BaseUserID);

            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }

    /// <summary>
    /// Handles the OnClick event of the btnLoadDefault control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnLoadDefault_OnClick(object sender, EventArgs e)
    {
        FillDetails(sender, e);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtToDate,lblErrorMsg );
    }
    /// <summary>
    /// Handles the TextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtFromDate,lblErrorMsg );
    }


    /// <summary>
    /// Handles the SelectedIndexChanged event of the RBLMonthly control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void RBLMonthly_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBLMonthly.SelectedValue.ToString().Trim().ToLower() == "PayPeriod".ToString().Trim().ToLower())
        {
            ddlFromDay.SelectedValue = BasePayPeriodFromDay;
            ddlToDay.SelectedValue = BasePayPeriodToDay;
            ddlFromDay.Enabled = false;
            ddlToDay.Enabled = false;
        }
        else
        {
            ddlFromDay.Enabled = true;
            ddlToDay.Enabled = true;
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the RBLWeekly control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void RBLWeekly_SelectedIndexChanged(object sender, EventArgs e)
    {
       // panelmonthly.Visible = false;
        if (RBLWeekly.SelectedValue.ToString().Trim().ToLower() == "WeekDay".ToString().Trim().ToLower())
        {
            if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Weekly".ToString().Trim().ToLower())
            {
                //lblWeekStartDay.Visible = true;
                //lblWeekEndDay.Visible = true;
                //ddlWeekStartDay.Visible = true;
                //ddlWeekEndDay.Visible = true;
                panelWeekStartDay.Visible = true;
                PanelWeekEndDay.Visible = true;
                PanelFortnight.Visible = false;
            }
            else
            {
                panelWeekStartDay.Visible = true;
                PanelWeekEndDay.Visible = false;
                PanelFortnight.Visible = true;
                lblStartDay.Visible = false;
                txtStartDay.Visible = false;
                lblDaysInFirstFortnight.Visible = true;
               // txtNoOfDayInFirstFortnight.Visible = true;
                ddlNoOfDayInFirstFortnight.Visible = true;

            }
        }
        else
        {
            if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Weekly".ToString().Trim().ToLower())
            {
                //panelWeekDay.Visible = false;
                //lblWeekStartDay.Visible = false;
                //lblWeekEndDay.Visible = false;
                //ddlWeekStartDay.Visible = false;
                //ddlWeekEndDay.Visible = false;
                //lblStartDay.Visible = true;
                //txtStartDay.Visible = true;
                panelWeekStartDay.Visible = false;
                PanelWeekEndDay.Visible = false;
                PanelFortnight.Visible = true;
                 lblStartDay.Visible = true;
                 txtStartDay.Visible = true;
                lblDaysInFirstFortnight.Visible = false;
                //txtNoOfDayInFirstFortnight.Visible = false;
                ddlNoOfDayInFirstFortnight.Visible = false;
            }
            else
            {
                panelWeekStartDay.Visible = false;
                PanelWeekEndDay.Visible = false;
                PanelFortnight.Visible = true;
                lblStartDay.Visible = true;
                txtStartDay.Visible = true;
                lblDaysInFirstFortnight.Visible = true;
                //txtNoOfDayInFirstFortnight.Visible = true;
                ddlNoOfDayInFirstFortnight.Visible = true;
            }
        }
    }
    /// <summary>
    /// Shows the type of the panelbased on attendance.
    /// </summary>
    private void ShowPanelbasedOnAttendanceType()
    {
        RBLWeekly.ClearSelection();
        RBLMonthly.ClearSelection();
        RBLWeekly.Visible = false;
        panelWeekStartDay.Visible = false;
        panelmonthly.Visible = false;
        PanelWeekEndDay.Visible = false;
        PanelFortnight.Visible = false;
        paneldateRange.Visible = false;
        if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Weekly".ToString().Trim().ToLower())
        {
            PanelControls.Visible = true;
            RBLWeekly.Visible = true;
            //lblWeekStartDay.Visible = true;
            //lblWeekEndDay.Visible = true;
            //lblDaysInFirstFortnight.Visible = true;
            //lblStartDay.Visible = true;
        }
        else if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Fortnightly".ToString().Trim().ToLower())
        {
            PanelControls.Visible = true;
            RBLWeekly.Visible = true;
        }
        else if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Monthly".ToString().Trim().ToLower())
        {
            RBLWeekly.Visible = false;
            panelmonthly.Visible = true;
            RBLMonthly.Visible = true;
        }
        else
        {
            paneldateRange.Visible = true;
        }
    }
    /// <summary>
    /// Shows the type of the panelbased on attendance.
    /// </summary>
    /// <param name="ds">The ds.</param>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void ShowPanelbasedOnAttendanceType(DataSet ds, object sender, EventArgs e)
    {
        RBLWeekly.ClearSelection();
        RBLMonthly.ClearSelection();
        RBLWeekly.Visible = false;
        panelWeekStartDay.Visible = false;
        panelmonthly.Visible = false;
        PanelWeekEndDay.Visible = false;
        PanelFortnight.Visible = false;
        paneldateRange.Visible = false;
        if (ds.Tables[0].Rows[0]["ScheduleApplyPatternType"].ToString() == "" || ds.Tables[0].Rows[0]["ScheduleApplyPatternType"].ToString() == null)
        {
            ddlAttendanceType.SelectedValue = "Select";
            ShowPanelbasedOnAttendanceType();
            return;
        }
        else
        {
            if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Weekly".ToString().Trim().ToLower())
            {
                PanelControls.Visible = true;
                RBLWeekly.Visible = true;
                if (ds.Tables[0].Rows[0]["ScheduleStartDay"].ToString() == "" && ds.Tables[0].Rows[0]["ScheduleEndDay"].ToString() == "")
                {
                    RBLWeekly.SelectedValue = "Day";
                    txtStartDay.Text = ds.Tables[0].Rows[0]["ScheduleFromDay"].ToString();
                    RBLWeekly_SelectedIndexChanged(sender, e);
                }
                else
                {
                    RBLWeekly.SelectedValue = "WeekDay";
                    ddlWeekStartDay.SelectedValue = ds.Tables[0].Rows[0]["ScheduleStartDay"].ToString();
                    ddlWeekEndDay.SelectedValue = ds.Tables[0].Rows[0]["ScheduleEndDay"].ToString();
                    RBLWeekly_SelectedIndexChanged(sender, e);
                }
                //lblWeekStartDay.Visible = true;
                //lblWeekEndDay.Visible = true;
                //lblDaysInFirstFortnight.Visible = true;
                //lblStartDay.Visible = true;
            }
            else if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Fortnightly".ToString().Trim().ToLower())
            {
                PanelControls.Visible = true;
                RBLWeekly.Visible = true;
                if (ds.Tables[0].Rows[0]["ScheduleStartDay"].ToString() == "" && ds.Tables[0].Rows[0]["ScheduleEndDay"].ToString() == "")
                {
                    RBLWeekly.SelectedValue = "Day";
                    txtStartDay.Text = ds.Tables[0].Rows[0]["ScheduleFromDay"].ToString();
                    // txtNoOfDayInFirstFortnight.Text = ds.Tables[0].Rows[0]["ScheduleNoOfDaysInFirstFortNight"].ToString();
                    ddlNoOfDayInFirstFortnight.SelectedValue = ds.Tables[0].Rows[0]["ScheduleNoOfDaysInFirstFortNight"].ToString();
                    RBLWeekly_SelectedIndexChanged(sender, e);
                }
                else
                {
                    RBLWeekly.SelectedValue = "WeekDay";
                    ddlWeekStartDay.SelectedValue = ds.Tables[0].Rows[0]["ScheduleStartDay"].ToString();
                    //txtNoOfDayInFirstFortnight.Text = ds.Tables[0].Rows[0]["ScheduleNoOfDaysInFirstFortNight"].ToString();
                    ddlNoOfDayInFirstFortnight.SelectedValue = ds.Tables[0].Rows[0]["ScheduleNoOfDaysInFirstFortNight"].ToString();
                    RBLWeekly_SelectedIndexChanged(sender, e);
                }
            }
            else if (ddlAttendanceType.SelectedValue.ToString().Trim().ToLower() == "Monthly".ToString().Trim().ToLower())
            {
                PanelControls.Visible = true;
                RBLWeekly.Visible = false;
                panelmonthly.Visible = true;
                RBLMonthly.Visible = true;
                RBLMonthly.SelectedValue = ds.Tables[0].Rows[0]["MonthlyScheduleType"].ToString();
                ddlFromDay.SelectedValue = ds.Tables[0].Rows[0]["ScheduleMonthlyFromDay"].ToString();
                ddlToDay.SelectedValue = ds.Tables[0].Rows[0]["ScheduleMonthlyToDay"].ToString();
                RBLMonthly_SelectedIndexChanged(sender, e);
            }
            else
            {
                PanelControls.Visible = true;
                paneldateRange.Visible = true;
                txtFromDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["ScheduleMonthlyStartDate"].ToString()).ToString("dd-MMM-yyyy");
                txtFromDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["ScheduleMonthlyEndDate"].ToString()).ToString("dd-MMM-yyyy");

            }
            txtMaxHoursInWeek.Text = ds.Tables[0].Rows[0]["SchEmpMaxDutyMin"].ToString();
            txtMaxHoursInMonth.Text = ds.Tables[0].Rows[0]["SchEmpMaxDutyMinInMonth"].ToString();
            txtMaxDutyMinInDay.Text = ds.Tables[0].Rows[0]["SchEmpMaxDutyMinInDay"].ToString();
            txtMinBreakBtwDuty.Text = ds.Tables[0].Rows[0]["SchMinBreakBetweenDuty"].ToString();
            ddlApplyPatternType.SelectedValue = ds.Tables[0].Rows[0]["ScheduleApplyPatternType"].ToString();
        }
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAttendanceType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAttendanceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowPanelbasedOnAttendanceType();
       
    }
}
