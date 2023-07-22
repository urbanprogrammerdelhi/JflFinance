// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="LeaveApplicationAndPosting.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

/// <summary>
/// Class HRManagement_LeaveApplicationAndPosting
/// </summary>
public partial class HRManagement_LeaveApplicationAndPosting : BasePage
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
    /// The BLN default
    /// </summary>
    bool blnDefault = false;
    /*Code added by Manish */
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (IsReadAccess)
            {

                txtNotifiedDate.Attributes.Add("readonly", "readonly");
                txtFromDate.Attributes.Add("readonly", "readonly");
                txtToDate.Attributes.Add("readonly", "readonly");


                FillSession(ddlFromSession);
                FillSession(ddlToSession);
                FillLeaveType();
                FillLeaveCalendarDefault();
                lbtnAddNew.Attributes["OnClick"] = "javascript:OpenEntitlement('" + txtLeaveBalanceUnits.ClientID + "');";
                if (Request.QueryString["EmployeeNumber"] != null && Request.QueryString["DutyDate"] != null)
                {
                    HFEmployeeNumber.Value = Request.QueryString["EmployeeNumber"];
                    txtEmployeeNumber.Text = HFEmployeeNumber.Value;
                    HFDutyDate.Value = Request.QueryString["DutyDate"];
                    txtFromDate.Text = HFDutyDate.Value;
                    txtToDate.Text = HFDutyDate.Value;


                    HFAsmtCode.Value = Request.QueryString["AsmtCode"];
                    HFShiftPatternCode.Value = Request.QueryString["ShiftPatternCode"];
                    HFPatternPosition.Value = Request.QueryString["PatternCode"];
                    HFIsDefaultSite.Value = Request.QueryString["DefaultSite"];
                    HFRowNumber.Value = Request.QueryString["RowNumber"];
                    HFAttendanceType.Value = Request.QueryString["AttendanceType"];
                    HFPost.Value = Request.QueryString["Post"];

                    if (HFIsDefaultSite.Value == "on")
                    { blnDefault = true; }
                    else
                    {
                        blnDefault = false;
                    }

                    txtEmployeeNumber_OnTextChanged(sender, e);
                    txtEmployeeNumber.Attributes.Add("readonly", "readonly");
                    txtFromDate_OnTextChanged(sender, e);
                    txtToDate_OnTextChanged(sender, e);
                    txtNotifiedDate.Text = HFDutyDate.Value;
                    imgEmployeeNumberSearch.Visible = false;
                    btnCancel.Visible = false;
                }
                else
                {
                    imgEmployeeNumberSearch.Visible = true;
                    HFDutyDate.Value = "";
                    HFEmployeeNumber.Value = "";
                    HFAsmtCode.Value = "";
                    HFShiftPatternCode.Value = "";
                    HFPatternPosition.Value = "";
                    HFIsDefaultSite.Value = "";
                    HFRowNumber.Value = "";
                    HFAttendanceType.Value = "";
                    HFPost.Value = "";
                }

                if (HFAttendanceType.Value.Trim().ToLower() == "Act".Trim().ToLower())
                {
                    if (HFAttendanceType.Value != "")
                    {
                        btnDelete.Visible = false;
                        btnLeaveCancelation.Visible = true;
                    }
                    else
                    {
                        btnDelete.Visible = true;
                        btnLeaveCancelation.Visible = true;
                    }
                }
                else
                {
                    if (HFAttendanceType.Value != "")
                    {
                        btnDelete.Visible = true;
                        btnLeaveCancelation.Visible = false;
                    }
                    else
                    {
                        btnDelete.Visible = true;
                        btnLeaveCancelation.Visible = true;
                    }
                }
                if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
            ImgLCCode.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=LCCCH&ControlId=" + txtLeaveCalendarCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=750,Height=350,help=no')");
            imgEmployeeNumberSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
        }
    }

    /// <summary>
    /// Handles the Click event of the lbtnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void lbtnAddNew_Click(object sender, EventArgs e)
    {

        if (HFDutyDate.Value == "")
        {
            Response.Redirect("../HRManagement/LeaveEntitlement.Aspx?BackOption=Back");
        }
        else
        {
            Response.Redirect("../HRManagement/LeaveEntitlement.Aspx?BackOption=" + "Back" + "&EmployeeNumber=" + txtEmployeeNumber.Text + "&FromDate=" + HFDutyDate.Value + "&AsmtCode=" + Request.QueryString["AsmtCode"] + "&ShiftPatternCode=" + Request.QueryString["ShiftPatternCode"] + "&PatternCode=" + Request.QueryString["PatternCode"] + "&DefaultSite=" + Request.QueryString["DefaultSite"] + "&RowNumber=" + Request.QueryString["RowNumber"] + "&AttendanceType=" + Request.QueryString["AttendanceType"] + "&Post=" + Request.QueryString["Post"]);
        }
    }

    /// <summary>
    /// Fills the leave calendar default.
    /// </summary>
    protected void FillLeaveCalendarDefault()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();

        ds = objLeave.LeaveCalendarGet(BaseCompanyCode);

        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            txtLeaveCalendarCode.Text = ds.Tables[1].Rows[0]["Leave_cal_code"].ToString();
            lblLeaveCalendarDesc.Text = ds.Tables[1].Rows[0]["Leave_cal_desc"].ToString();
            lblEffectiveFrom.Text = DateFormat(ds.Tables[1].Rows[0]["EffectiveFromDate"].ToString());
            lblEffectiveTo.Text = DateFormat(ds.Tables[1].Rows[0]["EffectiveTodate"].ToString());
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            txtLeaveCalendarCode.Text = "";
        }

    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtLeaveCalendarCode control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtLeaveCalendarCode_OnTextChanged(object sender, EventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeaveCalendarGet(BaseCompanyCode, txtLeaveCalendarCode.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblLeaveCalendarDesc.Text = ds.Tables[0].Rows[0]["Leave_cal_desc"].ToString();
            lblEffectiveFrom.Text = DateFormat(ds.Tables[0].Rows[0]["EffectiveFromDate"].ToString());
            lblEffectiveTo.Text = DateFormat(ds.Tables[0].Rows[0]["EffectiveTodate"].ToString());
            FillApplicationNo();
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            txtLeaveCalendarCode.Text = "";
        }

    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtEmployeeNumber control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeNumber_OnTextChanged(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        ds = objHRManagement.EmployeeDesignationGetLocation(txtEmployeeNumber.Text.ToString(), BaseCompanyCode, BaseLocationAutoID);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                lblEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                lblEmpJoiningDate.Text = DateFormat(ds.Tables[0].Rows[0]["DateOfJoining"].ToString());
                ddlLeaveType.SelectedIndex = 0;
                txtNotifiedDate.Text = "";
                if (HFDutyDate.Value == "")
                {
                    txtFromDate.Text = "";
                    txtToDate.Text = "";
                }
                txtExpectedDate.Text = "";
                txtFollowUpDate.Text = "";
                ddlFromSession.SelectedIndex = 0;
                ddlToSession.SelectedIndex = 0;
                txtLeaveUnits.Text = "";
                lblUnits.Text = "";
                txtLeaveBalanceUnits.Text = "";
                FillApplicationNo();

            }
            else
            {
                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                txtEmployeeNumber.Text = "";
                txtEmployeeNumber.Focus();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.InvalidEmployee;
            txtEmployeeNumber.Text = "";
            txtEmployeeNumber.Focus();
        }

    }


    /// <summary>
    /// Handles the TextChanged event of the txtFromTime control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromTime_TextChanged(object sender, EventArgs e)
    {

        if (txtFromDate.Text != "" && txtToDate.Text != "" && txtFromTime.Text != "" && txtToTime.Text != "")
        {
            CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtToDate, txtLeaveUnits, lblErrorMsg);
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the txtToTime control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToTime_TextChanged(object sender, EventArgs e)
    {

        if (txtFromDate.Text != "" && txtToDate.Text != "" && txtFromTime.Text != "" && txtToTime.Text != "")
        {
            CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtToDate, txtLeaveUnits, lblErrorMsg);
        }

    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtFromDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtFromDate_OnTextChanged(object sender, EventArgs e)
    {
        if (txtToDate.Text != "")
        {
            txtFollowUpDate.Text = DateFormat(txtToDate.Text);
            txtExpectedDate.Text = DateFormat(DateTime.Parse(txtToDate.Text).Date.AddDays(1).ToString());
            if (int.Parse(ddlApplicationNo.SelectedValue.ToString()) > 0)
            {
                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);
            }
            CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtToDate, txtLeaveUnits, lblErrorMsg);
        }
    }

    /// <summary>
    /// Handles the OnTextChanged event of the txtToDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtToDate_OnTextChanged(object sender, EventArgs e)
    {
        if (txtToDate.Text != "")
        {
            txtFollowUpDate.Text = DateFormat(txtToDate.Text);
            txtExpectedDate.Text = DateFormat(DateTime.Parse(txtToDate.Text).Date.AddDays(1).ToString());
            if (int.Parse(ddlApplicationNo.SelectedValue.ToString()) > 0)
            {
                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);
            }
            CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtToDate, txtLeaveUnits, lblErrorMsg);
        }
        else
        {

        }
    }

    /// <summary>
    /// Fills the session.
    /// </summary>
    /// <param name="ddlAdd">The DDL add.</param>
    protected void FillSession(DropDownList ddlAdd)
    {
        ListItem ddlItem1 = new ListItem();
        ddlItem1.Text = Resources.Resource.WholeDay;
        ddlItem1.Value = "W";
        ddlAdd.Items.Add(ddlItem1);
        ListItem ddlItem2 = new ListItem();
        ddlItem2.Text = Resources.Resource.FirstSession;
        ddlItem2.Value = "F";
        ddlAdd.Items.Add(ddlItem2);
        ListItem ddlItem3 = new ListItem();
        ddlItem3.Text = Resources.Resource.SecondSession;
        ddlItem3.Value = "S";
        ddlAdd.Items.Add(ddlItem3);
    }

    /// <summary>
    /// Fills the type of the leave.
    /// </summary>
    protected void FillLeaveType()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeaveTypeGet(BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlLeaveType.DataSource = ds;
            ddlLeaveType.DataTextField = "Leave_Desc";
            ddlLeaveType.DataValueField = "Leave_Code";
            ddlLeaveType.DataBind();
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.Select ;
            li.Value = "0";
            ddlLeaveType.Items.Insert(0, li);
            ddlLeaveType.SelectedIndex = 0;

        }
        else
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoData ;
            li.Value = "0";
            ddlLeaveType.Items.Insert(0, li);

        }
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlApplicationNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlApplicationNo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        if (ddlApplicationNo.SelectedIndex != 0)
        {
            ds = objLeave.LeavePostingApplicationDetailGet(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString().Trim(), ddlApplicationNo.SelectedValue);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                txtLeaveUnits.Text = double.Parse(ds.Tables[0].Rows[0]["Leave_Taken_Units"].ToString()).ToString("00.00");
                txtNotifiedDate.Text = DateFormat(ds.Tables[0].Rows[0]["Notified_Date"].ToString());
                txtFromDate.Text = DateFormat(ds.Tables[0].Rows[0]["Start_Date"].ToString());
                txtToDate.Text = DateFormat(ds.Tables[0].Rows[0]["End_Date"].ToString());
                HFLeaveCancelFromDate.Value = txtFromDate.Text;
                HFLeaveCancelToDate.Value = txtToDate.Text;
                ddlFromSession.SelectedValue = ds.Tables[0].Rows[0]["Start_AN_FN_Session"].ToString().ToUpper();
                ddlToSession.SelectedValue = ds.Tables[0].Rows[0]["End_AN_FN_Session"].ToString().ToUpper();
                txtExpectedDate.Text = DateFormat(ds.Tables[0].Rows[0]["Expected_Return_Date"].ToString());
                txtFollowUpDate.Text = DateFormat(ds.Tables[0].Rows[0]["Followup_Date"].ToString());
                txtFromTime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["Start_Date"].ToString()).ToString("HH:mm");
                txtToTime.Text = DateTime.Parse(ds.Tables[0].Rows[0]["End_Date"].ToString()).ToString("HH:mm");
                BL.Leave objSubLeave = new BL.Leave();
                DataSet dsSubLeave = new DataSet();
                dsSubLeave = objSubLeave.SubLeaveTypeExists(BaseCompanyCode, ddlLeaveType.SelectedValue.ToString().Trim());
                if (dsSubLeave != null && dsSubLeave.Tables.Count > 0 && dsSubLeave.Tables[0].Rows.Count > 0)
                {
                    if (dsSubLeave.Tables[0].Rows[0]["SubLeaveExists"].ToString().ToUpper().Trim() == "Y")
                    {
                        ddlSubLeaveType.SelectedValue = ds.Tables[0].Rows[0]["SubLeaveCode"].ToString().ToUpper();
                    }

                }

                if (bool.Parse(ds.Tables[0].Rows[0]["Medical_Cerification"].ToString()) == true)
                {
                    cbMedicalCerificationProv.Checked = true;
                }

                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);
            }
            else
            {
                HFLeaveCancelFromDate.Value = "";
                HFLeaveCancelToDate.Value = "";
            }
        }
        else
        {
            HFLeaveCancelFromDate.Value = "";
            HFLeaveCancelToDate.Value = "";
            clearFieldsonApplicationNo();
        }

    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlLeaveType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        FillSubLeaveType();
        txtFromTime.Text = "";
        txtToTime.Text = "";

        ds = objLeave.LeaveTypeGet(BaseCompanyCode);
        if (ddlLeaveType.SelectedIndex != 0)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "Leave_Code='" + ddlLeaveType.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            if (dv.Count > 0)
            {
                dt = dv.ToTable();
            }

            lblUnits.Text = "";
            lblUnits.Text = dt.Rows[0]["Leave_Unit"].ToString();

            if (dt.Rows[0]["EntitleMent_Frequency"].ToString().Trim() == "H")
            {
                //txtFromTime.Visible = true;
                txtToTime.Visible = true;
                txtFromTime.Style["display"] = "block";
                txtToTime.Style["display"] = "block";

                ddlFromSession.Visible = false;
                ddlToSession.Visible = false;
                txtFromTime.Text = "00:00";
                txtToTime.Text = "00:00";
            }
            else
            {
                //txtFromTime.Visible = false;
                //txtToTime.Visible = false;

                txtFromTime.Style["display"] = "none";
                txtToTime.Style["display"] = "none";

                ddlFromSession.Visible = true;
                ddlToSession.Visible = true;
                txtFromTime.Text = "";
                txtToTime.Text = "";
            }

            if (txtEmployeeNumber.Text != "")
            {

                txtLeaveBalanceUnits.Text = "";
                FillApplicationNo();
                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);
                CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtToDate, txtLeaveUnits, lblErrorMsg);

            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber;
                txtEmployeeNumber.Focus();
            }
        }
        else
        {
            lblUnits.Text = "";
            txtLeaveBalanceUnits.Text = "";
            txtNotifiedDate.Text = "";
            txtFromDate.Text = "";
            txtToDate.Text = "";
            ddlFromSession.SelectedIndex = 0;
            ddlToSession.SelectedIndex = 0;
            txtExpectedDate.Text = "";
            txtFollowUpDate.Text = "";
            txtLeaveUnits.Text = "00.00";
        }

    }

    /// <summary>
    /// Fills the type of the sub leave.
    /// </summary>
    protected void FillSubLeaveType()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = objLeave.SubLeaveTypeGet(ddlLeaveType.SelectedValue.ToString(), BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlSubLeaveType.DataSource = ds.Tables[0];
            ddlSubLeaveType.DataValueField = "SubLeaveCode";
            ddlSubLeaveType.DataTextField = "SubLeaveDesc";
            ddlSubLeaveType.DataBind();
            lblSubLeaveType.Visible = true;
            ddlSubLeaveType.Visible = true;
        }
        else
        {
            ddlSubLeaveType.Items.Clear();
            ListItem Li = new ListItem();
            Li.Text = ddlLeaveType.SelectedValue.ToString();
            Li.Value = ddlLeaveType.SelectedValue.ToString();
            ddlSubLeaveType.Items.Insert(0, Li);
            lblSubLeaveType.Visible = false;
            ddlSubLeaveType.Visible = false;
        }


        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            HFRequestedLeaveUnitSource.Value = ds.Tables[1].Rows[0]["PostingUnitSource"].ToString();
            HFAssociatedLeaveCode.Value = ds.Tables[1].Rows[0]["AssociatedLeaveCode"].ToString();
        }

        if (HFAttendanceType.Value.ToString().Length > 0 && HFAttendanceType.Value.ToString() != "0" && HFRequestedLeaveUnitSource.Value.ToString() != "0")
        {
            if (HFAttendanceType.Value.ToString().ToUpper() == "SCH")
            {
                HFRequestedLeaveUnitSource.Value = "1";
            }
            else if (HFAttendanceType.Value.ToString().ToUpper() == "ACT")
            {
                HFRequestedLeaveUnitSource.Value = "2";
            }
        }


    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlFromSession control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlFromSession_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtToDate, txtLeaveUnits, lblErrorMsg);
    }

    /// <summary>
    /// Handles the OnSelectedIndexChanged event of the ddlToSession control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlToSession_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtToDate, txtLeaveUnits, lblErrorMsg);
    }

    /// <summary>
    /// Calculates the leave units.
    /// </summary>
    /// <param name="ddlFrom">The DDL from.</param>
    /// <param name="ddlTo">The DDL to.</param>
    /// <param name="txtFromDate">The TXT from date.</param>
    /// <param name="txtToDate">The TXT to date.</param>
    /// <param name="txtUnits">The TXT units.</param>
    /// <param name="lblErrorMsg">The LBL error MSG.</param>
    protected void CalculateLeaveUnits(DropDownList ddlFrom, DropDownList ddlTo, TextBox txtFromDate, TextBox txtToDate, TextBox txtUnits, Label lblErrorMsg)
    {
        DateTime dtFrom = new DateTime();
        DateTime dtTo = new DateTime();
        if (txtFromDate.Text != "" && txtToDate.Text != "")
        {

            if (DateTime.Parse(txtToDate.Text) >= DateTime.Parse(txtFromDate.Text))
            {
                dtFrom = Convert.ToDateTime(txtFromDate.Text);
                dtTo = Convert.ToDateTime(txtToDate.Text);
                #region Partial Leave
                if (!HFRequestedLeaveUnitSource.Value.ToString().Equals("0"))
                {
                    if (txtToTime.Text != "" && txtFromTime.Text != "")
                    {
                        Regex checktime = new Regex(@"^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$");
                        if (checktime.IsMatch(txtFromTime.Text) && checktime.IsMatch(txtToTime.Text))
                        {
                            var FromTimeSplit = txtFromTime.Text.Split(':');
                            var ToTimeSplit = txtToTime.Text.Split(':');
                            DateTime dtFromDate = Convert.ToDateTime(txtFromDate.Text).AddHours(Convert.ToInt32(FromTimeSplit[0])).AddMinutes(Convert.ToInt32(FromTimeSplit[1]));
                            DateTime dtToDate = Convert.ToDateTime(txtToDate.Text).AddHours(Convert.ToInt32(ToTimeSplit[0])).AddMinutes(Convert.ToInt32(ToTimeSplit[1]));
                            if (((txtFromDate.Text != txtToDate.Text && (txtFromTime.Text != "00:00" || txtToTime.Text != "00:00"))
                                && dtToDate.Subtract(dtFromDate).Hours >= 24) || dtToDate.Subtract(dtFromDate).Hours < 0)
                            {
                                lblErrorMsg.Text = Resources.Resource.FromTimeorToTimenotValid;
                                txtUnits.Text = "0";
                            }
                            else
                            {
                                BL.Roster objRost = new BL.Roster();

                                DataSet dsLeaveUnit = objRost.TotalDutyHoursOfEmployeeGet(txtEmployeeNumber.Text, txtFromDate.Text, txtToDate.Text, txtFromTime.Text, txtToTime.Text, HFRequestedLeaveUnitSource.Value);
                                int leaveUnit = 0;
                                if (dsLeaveUnit != null && dsLeaveUnit.Tables.Count > 0 && dsLeaveUnit.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dsLeaveUnit.Tables[0].Rows.Count; i++)
                                    {
                                        leaveUnit = leaveUnit + int.Parse(dsLeaveUnit.Tables[0].Rows[i]["DutyMinutes"].ToString());
                                    }
                                }

                                HFRequestedLeaveUnitSourceXml.Value = dsLeaveUnit.GetXml(); //xml.ToString();
                                txtUnits.Text = (leaveUnit / 60.00).ToString();

                                lblErrorMsg.Text = "";
                                if (txtUnits.Text == "0" && ddlLeaveType.SelectedValue != "0" && txtEmployeeNumber.Text.Length > 0)
                                {
                                    lblErrorMsg.Text = Resources.Resource.FromTimeorToTimenotValid;
                                    txtUnits.Text="0";
                                }
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.InvalidTime;
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = "";
                    }

                    return;

                }
                #endregion
                BL.HRManagement objHRManagement = new BL.HRManagement();
                DataSet ds = new DataSet();
                ds = objHRManagement.EmployeeLeaveUnitGet(BaseCompanyCode, txtEmployeeNumber.Text, ddlLeaveType.SelectedValue.ToString().Trim(), txtFromDate.Text, txtToDate.Text, BaseLocationAutoID);
                TimeSpan ts = new TimeSpan();
                if (double.Parse(ds.Tables[0].Rows[0]["Days"].ToString()) >= -1)
                {

                    ts = TimeSpan.Parse(ds.Tables[0].Rows[0]["Days"].ToString());
                }
                else
                {
                    ts = dtTo - dtFrom;
                }
                Double days = new double();
                if (ddlFrom.SelectedValue == "W")
                {
                    if (ddlTo.SelectedValue == "W")
                    {
                        days = ts.Days + 1.00;
                        txtUnits.Text = days.ToString("00.00");
                    }
                    else if (ddlTo.SelectedValue == "F")
                    {
                        if (ts.Days >= 1)
                        {
                            days = ts.Days + 0.50;
                            txtUnits.Text = days.ToString("00.00");
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgLeaveConflicationBetweenFromAndToSession;
                            ddlTo.Focus();
                        }
                    }
                    else if (ddlTo.SelectedValue == "S")
                    {
                        if (ts.Days >= 1)
                        {
                            days = ts.Days + 1.00;
                            txtUnits.Text = days.ToString("00.00");
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgLeaveConflicationBetweenFromAndToSession;
                            ddlTo.Focus();
                        }
                    }
                }
                else if (ddlFrom.SelectedValue == "F")
                {
                    if (ddlTo.SelectedValue == "W")
                    {
                        if (ts.Days >= 1)
                        {
                            days = ts.Days + 1.00;
                            txtUnits.Text = days.ToString("00.00");
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgLeaveConflicationBetweenFromAndToSession;
                            ddlTo.Focus();
                        }

                    }
                    else if (ddlTo.SelectedValue == "F")
                    {
                        days = ts.Days + 0.50;
                        txtUnits.Text = days.ToString("00.00");
                    }
                    else if (ddlTo.SelectedValue == "S")
                    {
                        days = ts.Days + 1.00;
                        txtUnits.Text = days.ToString("00.00");
                    }

                }
                else if (ddlFrom.SelectedValue == "S")
                {

                    if (ddlTo.SelectedValue == "W")
                    {
                        if (ts.Days >= 1)
                        {
                            days = ts.Days + 0.50;
                            txtUnits.Text = days.ToString("00.00");
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgLeaveConflicationBetweenFromAndToSession;
                            ddlTo.Focus();
                        }

                    }
                    else if (ddlTo.SelectedValue == "F")
                    {
                        if (ts.Days >= 1)
                        {
                            days = ts.Days;
                            txtUnits.Text = days.ToString("00.00");
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgLeaveConflicationBetweenFromAndToSession;
                            ddlTo.Focus();
                        }

                    }
                    else if (ddlTo.SelectedValue == "S")
                    {
                        days = ts.Days + 0.50;
                        txtUnits.Text = days.ToString("00.00");

                    }

                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                txtToDate.Text = "";
                txtToDate.Focus();

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

        try
        {

            txtLeaveBalanceUnits.Enabled = false;
            if (txtLeaveBalanceUnits.Text.ToString() == "")
            {

                BL.Leave objLeaves = new BL.Leave();
                DataSet dsleave = new DataSet();
                dsleave = objLeaves.GetLeaveEntitlementFlag(BaseCompanyCode, ddlLeaveType.SelectedValue);

                if (dsleave.Tables[0].Rows[0]["MsgID"].ToString() == "True")
                {
                    goto outer;
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgLeaveBalanceIsNotDefinedForEmployee;
                    return;
                }
            }
            if (double.Parse(txtLeaveUnits.Text) > double.Parse(txtLeaveBalanceUnits.Text) && HFRequestedLeaveUnitSource.Value.Equals("0"))
            {
                lblErrorMsg.Text = "Leave Balance is less than Leave Units ";
                txtToDate.Text = "";
                return;
            }
        }
        catch (Exception ex) { }

    outer:
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dsrost = new DataSet();

        if (txtLeaveCalendarCode.Text != "")
        {
            if (txtEmployeeNumber.Text != "")
            {


                if (ddlLeaveType.SelectedIndex != 0)
                {

                    if (txtFromDate.Text != "" && txtToDate.Text != "" && txtNotifiedDate.Text != "")
                    {
                        dsrost = objLeave.RosterInformationGet(BaseCompanyCode, BaseLocationAutoID, txtEmployeeNumber.Text, txtFromDate.Text, txtToDate.Text, ddlApplicationNo.SelectedValue.ToString(), ddlLeaveType.SelectedValue.ToString().Trim());

                        if (dsrost.Tables.Count > 0 && dsrost.Tables[0].Rows.Count > 0 && HFRequestedLeaveUnitSource.Value.ToString().Equals("0"))
                        {
                            if (dsrost.Tables[0].Rows[0]["MsgID"].ToString() == "200")
                            {
                                DisplayMessageString(lblErrorMsg, dsrost.Tables[0].Rows[0]["MessageDesc"].ToString());
                            }
                            else if (dsrost.Tables[0].Rows[0]["MsgID"].ToString() == "201")
                            {
                                DisplayMessageString(lblErrorMsg, dsrost.Tables[0].Rows[0]["MessageDesc"].ToString());
                            }
                            else
                            {
                                FillgvMulRosterResult();
                            }


                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtLeaveUnits.Text) || txtLeaveUnits.Text=="0")
                            {
                                lblErrorMsg.Text = Resources.Resource.FromTimeorToTimenotValid;
                                return;
                            }
                            if (CompareDates(txtNotifiedDate, lblEffectiveFrom, lblEffectiveTo, txtFromDate, txtToDate, txtFollowUpDate, txtExpectedDate, lblErrorMsg))
                            {
                                string txtFromDateTemp = txtFromDate.Text;
                                string txtToDateTemp = txtToDate.Text;

                                if (txtFromTime.Text.Length > 0)
                                {
                                    Regex checktime = new Regex(@"^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$");
                                    if (checktime.IsMatch(txtFromTime.Text))
                                    {
                                        txtFromDate.Text = txtFromDate.Text + " " + txtFromTime.Text;
                                    }
                                    else
                                    {
                                        lblErrorMsg.Text = Resources.Resource.InvalidTime;
                                    }
                                }

                                if (txtToTime.Text.Length > 0)
                                {
                                    Regex checktime = new Regex(@"^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$");
                                    if (checktime.IsMatch(txtToTime.Text))
                                    {
                                        txtToDate.Text = txtToDate.Text + " " + txtToTime.Text;
                                    }
                                    else
                                    {
                                        lblErrorMsg.Text = Resources.Resource.InvalidTime;
                                    }
                                }
                                ds = objLeave.LeavePostingInsert(BaseCompanyCode, BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString().Trim(), "0", "0", "", txtNotifiedDate.Text, txtFollowUpDate.Text, txtExpectedDate.Text, txtFromDate.Text, ddlFromSession.SelectedValue, txtToDate.Text, ddlToSession.Text, txtLeaveUnits.Text, "0", "0.00", "", "", "", "", "", "", "0.00", "", "", "", "", BaseUserID, HttpContext.Current.Session.SessionID.ToString(), cbOverwriteWeekOFF.Checked, HFShiftPatternCode.Value, HFPatternPosition.Value, blnDefault, HFAsmtCode.Value, HFRowNumber.Value, HFAttendanceType.Value, HFPost.Value, HFRequestedLeaveUnitSourceXml.Value, ddlSubLeaveType.SelectedValue.ToString());

                                txtFromDate.Text = txtFromDateTemp;
                                txtToDate.Text = txtToDateTemp;
                                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);

                                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "117")
                                    {
                                        lblErrorMsg.Text = ds.Tables[0].Rows[0]["Comment"].ToString();

                                    }
                                    else
                                    {
                                        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "98")
                                        {
                                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                            btnWeekOFF.Visible = true;
                                        }
                                        else
                                        {
                                            btnWeekOFF.Visible = false;
                                        }
                                    }

                                }
                                ds1 = objLeave.LeavePostingApplicationResultGet(HttpContext.Current.Session.SessionID.ToString());

                                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                                {

                                    lblErrorMsg.Text = ds1.Tables[0].Rows[0]["MessageString"].ToString();
                                    HFLeaveCancelFromDate.Value = txtFromDate.Text;
                                    HFLeaveCancelToDate.Value = txtToDate.Text;
                                    clearFieldsonApplicationNo();
                                    if (HFDutyDate.Value == "")
                                    {
                                        FillApplicationNo();
                                        txtEmployeeNumber.Text = "";
                                        lblEmployeeName.Text = "";
                                        ddlLeaveType.SelectedIndex = 0;
                                        lblUnits.Text = "";
                                    }
                                    else
                                    {
                                        FillApplicationNo();
                                    }
                                    btnWeekOFF.Visible = false;
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveDates;
                        txtNotifiedDate.Focus();
                    }
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveType;

                    ddlLeaveType.Focus();

                }

            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber;
                txtEmployeeNumber.Focus();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveCalender;
            txtLeaveCalendarCode.Focus();
        }
    }

    /// <summary>
    /// Checks the leave units validity.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
    private bool CheckLeaveUnitsValidity()
    {
        if (txtFromDate.Text != "" && txtToDate.Text != "")
        {
            if (txtLeaveBalanceUnits.Text == "")
            {
                return true;
            }
            TimeSpan tsFromTimeDiff = new TimeSpan();
            TimeSpan tsToTimeDiff = new TimeSpan();
            if (DateTime.Parse(txtFromDate.Text) < DateTime.Parse(HFLeaveCancelFromDate.Value))
            {
                tsFromTimeDiff = DateTime.Parse(HFLeaveCancelFromDate.Value).Subtract(DateTime.Parse(txtFromDate.Text));
            }
            if (DateTime.Parse(txtToDate.Text) > DateTime.Parse(HFLeaveCancelToDate.Value))
            {
                tsToTimeDiff = DateTime.Parse(txtToDate.Text).Subtract(DateTime.Parse(HFLeaveCancelToDate.Value));
            }
            int status = 0;
            if (tsFromTimeDiff > tsToTimeDiff)
            {
                status = 0;
            }
            else
            {
                if (tsFromTimeDiff == tsToTimeDiff)
                {
                    status = 2;
                }
                else
                {
                    status = 1;
                }
            }

            if (DateTime.Parse(txtFromDate.Text) < DateTime.Parse(HFLeaveCancelFromDate.Value) && status == 0)
            {
                if (double.Parse(txtLeaveUnits.Text) > double.Parse(txtLeaveBalanceUnits.Text))
                {

                    txtChangedToDate.Text = DateTime.Parse(HFLeaveCancelFromDate.Value).AddDays(double.Parse("-1")).ToString();
                    CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtChangedToDate, txtNewLeaveUnits, lblErrorMsg);
                    if (double.Parse(txtNewLeaveUnits.Text) > double.Parse(txtLeaveBalanceUnits.Text))
                    {

                        lblErrorMsg.Text = "Leave Balance is Less than Leave Units ";
                        txtToDate.Text = "";
                        return false;
                    }
                    else
                    {
                        if (txtLeaveBalanceUnits.Text == "0")
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }

            }
            else if (DateTime.Parse(txtFromDate.Text) == DateTime.Parse(HFLeaveCancelFromDate.Value) || DateTime.Parse(txtFromDate.Text) > DateTime.Parse(HFLeaveCancelFromDate.Value) || status == 1)
            {
                if (double.Parse(txtLeaveUnits.Text) > double.Parse(txtLeaveBalanceUnits.Text))
                {
                    if (DateTime.Parse(txtToDate.Text) > DateTime.Parse(HFLeaveCancelToDate.Value))
                    {
                        txtChangedToDate.Text = DateTime.Parse(HFLeaveCancelToDate.Value).AddDays(double.Parse("1")).ToString();
                        CalculateLeaveUnits(ddlFromSession, ddlToSession, txtChangedToDate, txtToDate, txtNewLeaveUnits, lblErrorMsg);
                        if (double.Parse(txtNewLeaveUnits.Text) > double.Parse(txtLeaveBalanceUnits.Text))
                        {

                            lblErrorMsg.Text = "Leave Balance is Less than Leave Units ";
                            txtToDate.Text = "";
                            return false;
                        }
                        else
                        {
                            if (txtLeaveBalanceUnits.Text == "0")
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }

            }
            else if (status == 2)
            {
                txtChangedToDate.Text = DateTime.Parse(HFLeaveCancelFromDate.Value).AddDays(double.Parse("-1")).ToString();
                CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtChangedToDate, txtNewLeaveUnits, lblErrorMsg);

                string strFromLeaveUnits = txtNewLeaveUnits.Text;
                txtChangedToDate.Text = DateTime.Parse(HFLeaveCancelToDate.Value).AddDays(double.Parse("1")).ToString();
                CalculateLeaveUnits(ddlFromSession, ddlToSession, txtChangedToDate, txtToDate, txtNewLeaveUnits, lblErrorMsg);
                string strToLeaveUnits = txtNewLeaveUnits.Text;

                double TotalLeaveUnits = double.Parse(strFromLeaveUnits) + double.Parse(strToLeaveUnits);
                if (TotalLeaveUnits > double.Parse(txtLeaveBalanceUnits.Text))
                {
                    lblErrorMsg.Text = "Leave Balance is Less than Leave Units ";
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
        else
        {
            return false;
        }
        return false;
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        CalculateLeaveUnits(ddlFromSession, ddlToSession, txtFromDate, txtToDate, txtLeaveUnits, lblErrorMsg);
        if (string.IsNullOrEmpty(txtLeaveUnits.Text) || txtLeaveUnits.Text == "0")
        {
            lblErrorMsg.Text = Resources.Resource.FromTimeorToTimenotValid;
            return;
        }
        try
        {
            if (!CheckLeaveUnitsValidity())
            {
                return;
            }
        }
        catch (Exception ex) { return; }

        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsrost = new DataSet();


        if (txtLeaveCalendarCode.Text != "")
        {
            if (txtEmployeeNumber.Text != "")
            {

                if (ddlLeaveType.SelectedIndex != 0)
                {

                    if (ddlApplicationNo.SelectedValue != "0")
                    {


                        if (txtFromDate.Text != "" && txtToDate.Text != "" && txtNotifiedDate.Text != "")
                        {

                            dsrost = objLeave.RosterInformationGet(BaseCompanyCode, BaseLocationAutoID, txtEmployeeNumber.Text, txtFromDate.Text, txtToDate.Text, ddlApplicationNo.SelectedValue.ToString(), ddlLeaveType.SelectedValue.ToString().Trim());
                            if (dsrost.Tables.Count > 0 && dsrost.Tables[0].Rows.Count > 0 && (HFAssociatedLeaveCode.Value.ToString().Length == 0 || HFAssociatedLeaveCode.Value.ToString().ToUpper().Equals(ddlLeaveType.SelectedValue.ToString().ToUpper())))
                            {
                                if (dsrost.Tables[0].Rows[0]["MsgID"].ToString() == "200")
                                {
                                    DisplayMessageString(lblErrorMsg, dsrost.Tables[0].Rows[0]["MessageDesc"].ToString());
                                }
                                else if (dsrost.Tables[0].Rows[0]["MsgID"].ToString() == "201")
                                {
                                    DisplayMessageString(lblErrorMsg, dsrost.Tables[0].Rows[0]["MessageDesc"].ToString());
                                }
                                else
                                {
                                    FillgvMulRosterResult();
                                }


                            }
                            else
                            { //Bal1
                                string txtFromDateTemp = txtFromDate.Text;
                                string txtToDateTemp = txtToDate.Text;

                                if (txtFromTime.Text.Length > 0)
                                {
                                    txtFromDate.Text = txtFromDate.Text + " " + txtFromTime.Text;
                                }

                                if (txtToTime.Text.Length > 0)
                                {
                                    txtToDate.Text = txtToDate.Text + " " + txtToTime.Text;
                                }

                                ds = objLeave.LeavePostingUpdate(BaseCompanyCode, BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString().Trim(), ddlApplicationNo.SelectedValue, "0", "", txtNotifiedDate.Text, txtFollowUpDate.Text, txtExpectedDate.Text, txtFromDate.Text, ddlFromSession.SelectedValue, txtToDate.Text, ddlToSession.Text, txtLeaveUnits.Text, "0", "0.00", "", "", "", "", "", "", "0.00", "", "", "", "", BaseUserID, HttpContext.Current.Session.SessionID.ToString(), cbOverwriteWeekOFF.Checked, HFShiftPatternCode.Value, HFPatternPosition.Value, blnDefault, HFAsmtCode.Value, HFRowNumber.Value, HFAttendanceType.Value, HFPost.Value, HFRequestedLeaveUnitSourceXml.Value, ddlSubLeaveType.SelectedValue.ToString());

                                txtFromDate.Text = txtFromDateTemp;
                                txtToDate.Text = txtToDateTemp;
                                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);

                                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "117")
                                    {
                                        lblErrorMsg.Text = ds.Tables[0].Rows[0]["Comment"].ToString();
                                    }
                                    else
                                    {
                                        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "98")
                                        {
                                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                            btnWeekOFF.Visible = true;
                                        }
                                        else
                                        {
                                            btnWeekOFF.Visible = false;
                                        }
                                    }
                                }

                                ds1 = objLeave.LeavePostingApplicationResultGet(HttpContext.Current.Session.SessionID.ToString());



                                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                                {
                                    lblErrorMsg.Text = ds1.Tables[0].Rows[0]["MessageString"].ToString();

                                    clearFieldsonApplicationNo();
                                    if (HFDutyDate.Value == "")
                                    {
                                        FillApplicationNo();
                                        txtEmployeeNumber.Text = "";
                                        lblEmployeeName.Text = "";
                                        ddlLeaveType.SelectedIndex = 0;
                                        lblUnits.Text = "";
                                    }
                                    else
                                    {
                                        FillApplicationNo();
                                    }

                                    btnWeekOFF.Visible = false;


                                }
                                else
                                {

                                }
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveDates;
                            txtNotifiedDate.Focus();


                        }


                    }

                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveApplicationNo;
                        txtNotifiedDate.Focus();
                    }



                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveType;
                    ddlLeaveType.Focus();

                }

            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber;
                txtEmployeeNumber.Focus();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveCalender;
            txtLeaveCalendarCode.Focus();
        }


    }

    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {


        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        DataSet dsrost = new DataSet();
        if (txtLeaveCalendarCode.Text != "")
        {
            if (txtEmployeeNumber.Text != "")
            {
                if (ddlLeaveType.SelectedIndex != 0)
                {

                    if (ddlApplicationNo.SelectedValue != "0")
                    {



                        if (txtFromDate.Text != "" && txtToDate.Text != "" && txtNotifiedDate.Text != "")
                        {
                            ds = objLeave.LeavePostingDelete(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString().Trim(), ddlApplicationNo.SelectedValue, "0", "", txtNotifiedDate.Text, txtFollowUpDate.Text, txtExpectedDate.Text, txtFromDate.Text, ddlFromSession.SelectedValue, txtToDate.Text, ddlToSession.Text, txtLeaveUnits.Text, "0", "0.00", "", "", "", "", "", "", "0.00", "", "", "", "", BaseUserID);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                                clearFieldsonApplicationNo();
                                if (HFDutyDate.Value == "")
                                {
                                    FillApplicationNo();
                                    txtEmployeeNumber.Text = "";
                                    lblEmployeeName.Text = "";
                                }
                                else
                                {
                                    FillApplicationNo();
                                }
                                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);
                                ddlLeaveType.SelectedIndex = 0;
                                lblUnits.Text = "";


                            }
                            else
                            {

                            }
                            //}

                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveDates;
                            txtNotifiedDate.Focus();
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveApplicationNo;
                        ddlApplicationNo.Focus();


                    }



                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveType;
                    ddlLeaveType.Focus();

                }

            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber;
                txtEmployeeNumber.Focus();
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveCalender;
            txtLeaveCalendarCode.Focus();
        }

    }

    /// <summary>
    /// Handles the Click event of the btnLeaveCancelation control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnLeaveCancelation_Click(object sender, EventArgs e)
    {
        if (txtToDate.Text != "" && txtFromDate.Text != "" && HFLeaveCancelFromDate.Value != "" && HFLeaveCancelToDate.Value != "")
        {
            if (DateTime.Parse(txtFromDate.Text) == DateTime.Parse(HFLeaveCancelFromDate.Value) && DateTime.Parse(txtToDate.Text) == DateTime.Parse(HFLeaveCancelToDate.Value))
            {
                DataTable dt = new DataTable();
                BL.Leave objLeave = new BL.Leave();
                if (ddlApplicationNo.SelectedValue.ToString() != "0")
                {
                    dt = objLeave.CancelLeave(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString().Trim(), ddlApplicationNo.SelectedValue.ToString(), HFLeaveCancelFromDate.Value, HFLeaveCancelToDate.Value, txtLeaveUnits.Text);
                    if (dt.Rows[0]["MessageID"].ToString() == "200")
                    {
                        lblErrorMsg.Text = "Authorized Rota exists in between the date range";
                    }
                    else
                    {
                        DisplayMessage(lblErrorMsg, dt.Rows[0]["MessageID"].ToString());
                        FillApplicationNo();
                        GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);
                    }

                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveApplicationNo;
                    ddlApplicationNo.Focus();
                }
            }
            else
            {
                lblErrorMsg.Text = "Invalid From/To Date";
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearFieldsonApplicationNo();
        txtEmployeeNumber.Text = "";
        lblEmployeeName.Text = "";
        ddlLeaveType.SelectedIndex = 0;
        lblUnits.Text = "";
        txtLeaveBalanceUnits.Text = "";
        FillApplicationNo();
    }

    /// <summary>
    /// Fills the application no.
    /// </summary>
    protected void FillApplicationNo()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeavePostingApplicationNumberGet(txtEmployeeNumber.Text, ddlLeaveType.SelectedValue.ToString().Trim(), BaseLocationAutoID, txtLeaveCalendarCode.Text);
        ddlApplicationNo.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlApplicationNo.DataSource = ds;
            ddlApplicationNo.DataTextField = "Application_No";
            ddlApplicationNo.DataValueField = "Application_No";
            ddlApplicationNo.DataBind();

            ListItem li2 = new ListItem();
            li2.Text =  Resources.Resource.Select ;
            li2.Value = "0";
            ddlApplicationNo.Items.Insert(0, li2);
            ddlApplicationNo.SelectedIndex = 0;
        }
        else
        {
            ListItem li1 = new ListItem();
            li1.Text =  Resources.Resource.NoData ;
            li1.Value = "0";
            ddlApplicationNo.Items.Insert(0, li1);
        }
    }



    /// <summary>
    /// Compares the dates.
    /// </summary>
    /// <param name="txtNotifiedDate">The TXT notified date.</param>
    /// <param name="txtEffectiveFrom">The TXT effective from.</param>
    /// <param name="txtEffectiveTo">The TXT effective to.</param>
    /// <param name="txtFromDate">The TXT from date.</param>
    /// <param name="txtToDate">The TXT to date.</param>
    /// <param name="txtFollowUpDate">The TXT follow up date.</param>
    /// <param name="txtReturnDate">The TXT return date.</param>
    /// <param name="lblErrorMsg">The LBL error MSG.</param>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
    private bool CompareDates(TextBox txtNotifiedDate, Label txtEffectiveFrom, Label txtEffectiveTo, TextBox txtFromDate, TextBox txtToDate, TextBox txtFollowUpDate, TextBox txtReturnDate, Label lblErrorMsg)
    {
        DateTime dtNotifiedDate = Convert.ToDateTime(txtNotifiedDate.Text);
        DateTime dtFromDate = Convert.ToDateTime(txtFromDate.Text);
        DateTime dtTodate = Convert.ToDateTime(txtToDate.Text);
        DateTime dtFollowupDate = Convert.ToDateTime(txtFollowUpDate.Text);
        DateTime dtReturnDate = Convert.ToDateTime(txtReturnDate.Text);
        DateTime dtEffectiveFrom = Convert.ToDateTime(txtEffectiveFrom.Text);
        DateTime dtEffectiveTo = Convert.ToDateTime(txtEffectiveTo.Text);
        bool bReturnValue;

        if (dtNotifiedDate <= dtFromDate)
        {

            if (dtFromDate >= dtEffectiveFrom)
            {

                if (dtFromDate <= dtEffectiveTo)
                {

                    if (dtTodate >= dtEffectiveFrom)
                    {

                        if (dtTodate <= dtEffectiveTo)
                        {
                            if (dtFromDate > dtTodate)
                            {
                                lblErrorMsg.Text = Resources.Resource.MsgLeaveApplicationToDateShouldBeGreaterOrEqualToFromDate;
                                txtFromDate.Text = "";
                                txtFromDate.Focus();
                                bReturnValue = false;
                            }
                            else
                            {
                                bReturnValue = true;
                            }
                        }
                        else
                        {

                            lblErrorMsg.Text = Resources.Resource.MsgLeaveToDateShouldBeSmallerToLeaveCalendarEffectiveToDate;
                            txtToDate.Text = "";
                            txtToDate.Focus();
                            bReturnValue = false;
                        }
                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgLeaveToDateShouldbeGreaterThanLeaveCalendarFromDate;
                        txtFromDate.Text = "";
                        txtToDate.Focus();
                        bReturnValue = false;

                    }

                }

                else
                {

                    lblErrorMsg.Text = Resources.Resource.MsgLeaveFromDateShouldBeSmallerThanLeaveCalendarToDate;
                    txtToDate.Text = "";
                    txtFromDate.Focus();
                    bReturnValue = false;
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgLeaveFromDateShouldBeGreaterThanLeaveCalendarFromDate;
                txtFromDate.Text = "";
                txtFromDate.Focus();
                bReturnValue = false;
            }
        }
        else
        {

            lblErrorMsg.Text = Resources.Resource.MsgLeaveNotifiedDateShouldBeGreaterThanLeaveFromDate;
            txtNotifiedDate.Text = "";
            txtNotifiedDate.Focus();
            bReturnValue = false;
        }
        return bReturnValue;
    }

    /// <summary>
    /// Clears the fieldson application no.
    /// </summary>
    protected void clearFieldsonApplicationNo()
    {
        if (HFDutyDate.Value == "")
        {
            txtNotifiedDate.Text = "";
            txtExpectedDate.Text = "";
            txtFollowUpDate.Text = "";
            txtFromDate.Text = "";
            txtToDate.Text = "";
            cbMedicalCerificationProv.Checked = false;
            txtLeaveUnits.Text = "00.00";
            txtLeaveBalanceUnits.Text = "";
        }
        ddlFromSession.SelectedIndex = 0;
        ddlToSession.SelectedIndex = 0;

    }

    /// <summary>
    /// Gets the leave balances.
    /// </summary>
    /// <param name="txtLeaveCalendarCode">The TXT leave calendar code.</param>
    /// <param name="ddlLeaveCode">The DDL leave code.</param>
    /// <param name="txtEmployeeNumber">The TXT employee number.</param>
    /// <param name="txtLeaveBalance">The TXT leave balance.</param>
    protected void GetLeaveBalances(TextBox txtLeaveCalendarCode, DropDownList ddlLeaveCode, TextBox txtEmployeeNumber, TextBox txtLeaveBalance)
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        bool blCheck = false;

        ds2 = objLeave.LeaveTypeGet(BaseCompanyCode);
        if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                if (ddlLeaveCode.Text == ds2.Tables[0].Rows[i]["Leave_Code"].ToString())
                {
                    if (bool.Parse(ds2.Tables[0].Rows[i]["Without_Entitlement_flag"].ToString()))
                    {
                        blCheck = true;
                    }
                }
            }
        }
        ds = objLeave.EmployeeLeaveBalanceGet(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveCode.Text.ToString().Trim());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtLeaveBalance.Text = double.Parse(ds.Tables[0].Rows[0]["Leave_Balance_Days"].ToString()).ToString("00.00");
        }
        else
        {
            if (!blCheck)
            {
                lblErrorMsg.Text = Resources.Resource.MsgLeaveBalanceIsNotDefinedForEmployee;
                txtEmployeeNumber.Focus();
            }

        }

    }

    /// <summary>
    /// Fillgvs the mul roster result.
    /// </summary>
    protected void FillgvMulRosterResult()
    {
        BL.Leave objLeave = new BL.Leave();
        DataTable dtResult = new DataTable();
        DataSet ds = new DataSet();
        ds = objLeave.RosterInformationGet(BaseCompanyCode, BaseLocationAutoID, txtEmployeeNumber.Text, txtFromDate.Text, txtToDate.Text, ddlApplicationNo.SelectedValue.ToString(), ddlLeaveType.SelectedValue.ToString().Trim());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["MsgID"].ToString() == "200")
            {
                DisplayMessageString(lblErrorMsg, ds.Tables[0].Rows[0]["MessageDesc"].ToString());
            }
            else if (ds.Tables[0].Rows[0]["MsgID"].ToString() == "201")
            {
                DisplayMessageString(lblErrorMsg, ds.Tables[0].Rows[0]["MessageDesc"].ToString());
            }
            else
            {
                dtResult = ds.Tables[0];
                gvMulRosterResult.DataKeyNames = new string[] { "MsgID" };
                gvMulRosterResult.DataSource = dtResult;
                gvMulRosterResult.DataBind();
            }

        }
        else if (ds != null && ds.Tables.Count > 0)
        {
            dtResult = ds.Tables[0];
            dtResult.Rows.Add(dtResult.NewRow());
            gvMulRosterResult.DataSource = dtResult;
            gvMulRosterResult.DataBind();
            gvMulRosterResult.Rows[0].Cells.Clear();
            gvMulRosterResult.Rows[0].Cells.Add(new TableCell());
            gvMulRosterResult.Rows[0].Cells[0].ColumnSpan = 2;
            gvMulRosterResult.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
        MPE.Show();
    }

    /// <summary>
    /// Handles the onClick event of the btnOk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnOk_onClick(object sender, EventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dsRostDel = new DataSet();


        if (txtLeaveCalendarCode.Text != "")
        {
            if (txtEmployeeNumber.Text != "")
            {


                if (ddlLeaveType.SelectedIndex != 0)
                {

                    if (txtFromDate.Text != "" && txtToDate.Text != "" && txtNotifiedDate.Text != "")
                    {


                        if (CompareDates(txtNotifiedDate, lblEffectiveFrom, lblEffectiveTo, txtFromDate, txtToDate, txtFollowUpDate, txtExpectedDate, lblErrorMsg))
                        {

                            string txtFromDateTemp = txtFromDate.Text;
                            string txtToDateTemp = txtToDate.Text;

                            if (txtFromTime.Text.Length > 0)
                            {
                                txtFromDate.Text = txtFromDate.Text + " " + txtFromTime.Text;
                            }

                            if (txtToTime.Text.Length > 0)
                            {
                                txtToDate.Text = txtToDate.Text + " " + txtToTime.Text;
                            }

                            if (ddlApplicationNo.SelectedValue.ToString() == "0")
                            {
                                ds = objLeave.LeavePostingInsert(BaseCompanyCode, BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString().Trim(), "0", "0", "", txtNotifiedDate.Text, txtFollowUpDate.Text, txtExpectedDate.Text, txtFromDate.Text, ddlFromSession.SelectedValue, txtToDate.Text, ddlToSession.Text, txtLeaveUnits.Text, "0", "0.00", "", "", "", "", "", "", "0.00", "", "", "", "", BaseUserID, HttpContext.Current.Session.SessionID.ToString(), cbOverwriteWeekOFF.Checked, HFShiftPatternCode.Value, HFPatternPosition.Value, blnDefault, HFAsmtCode.Value, HFRowNumber.Value, HFAttendanceType.Value, HFPost.Value, HFRequestedLeaveUnitSourceXml.Value, ddlSubLeaveType.SelectedValue.ToString());
                            }
                            else
                            {
                                ds = objLeave.LeavePostingUpdate(BaseCompanyCode, BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString().Trim(), ddlApplicationNo.SelectedValue, "0", "", txtNotifiedDate.Text, txtFollowUpDate.Text, txtExpectedDate.Text, txtFromDate.Text, ddlFromSession.SelectedValue, txtToDate.Text, ddlToSession.Text, txtLeaveUnits.Text, "0", "0.00", "", "", "", "", "", "", "0.00", "", "", "", "", BaseUserID, HttpContext.Current.Session.SessionID.ToString(), cbOverwriteWeekOFF.Checked, HFShiftPatternCode.Value, HFPatternPosition.Value, blnDefault, HFAsmtCode.Value, HFRowNumber.Value, HFAttendanceType.Value, HFPost.Value, HFRequestedLeaveUnitSourceXml.Value, ddlSubLeaveType.SelectedValue.ToString());
                            }

                            txtFromDate.Text = txtFromDateTemp;
                            txtToDate.Text = txtToDateTemp;

                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "117")
                                {
                                    lblErrorMsg.Text = ds.Tables[0].Rows[0]["Comment"].ToString();
                                }
                                else
                                {

                                    if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "98")
                                    {
                                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                        btnWeekOFF.Visible = true;
                                    }
                                    else
                                    {
                                        btnWeekOFF.Visible = false;
                                    }
                                }
                            }

                            ds1 = objLeave.LeavePostingApplicationResultGet(HttpContext.Current.Session.SessionID.ToString());

                            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                            {
                                if (ds1.Tables[0].Rows[0]["MessageID"].ToString() == "0" || ds1.Tables[0].Rows[0]["MessageID"].ToString() == "2")
                                {
                                    dsRostDel = objLeave.RosterInformationDelete(BaseCompanyCode, BaseLocationAutoID, txtEmployeeNumber.Text, txtFromDate.Text, txtToDate.Text);
                                }
                                lblErrorMsg.Visible = true;
                                lblErrorMsg.Text = ds1.Tables[0].Rows[0]["MessageString"].ToString();
                                clearFieldsonApplicationNo();
                                if (HFDutyDate.Value == "")
                                {
                                    txtEmployeeNumber.Text = "";
                                    lblEmployeeName.Text = "";
                                    ddlLeaveType.SelectedIndex = 0;
                                    lblUnits.Text = "";
                                }
                                btnWeekOFF.Visible = false;

                            }
                        }

                    }
                    else
                    {
                        lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveDates;
                        txtNotifiedDate.Focus();


                    }


                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveType;
                    ddlLeaveType.Focus();
                }

            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber;
                txtEmployeeNumber.Focus();
            }




        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgRequiredLeaveCalender;
            txtLeaveCalendarCode.Focus();
        }


        MPE.Hide();
    }

    /// <summary>
    /// Handles the onClick event of the btnCancel2 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel2_onClick(object sender, EventArgs e)
    {
        MPE.Hide();
    }
}