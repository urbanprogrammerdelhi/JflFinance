// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="LeaveAdjustment.Aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Class HRManagement_LeaveAdjustment
/// </summary>
public partial class HRManagement_LeaveAdjustment : BasePage
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
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (IsReadAccess == true)
            {
                System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resources.Resource.LeaveAdjustment + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


                FillLeaveType();
                FillAdjustmentType();
                FillLeaveCalendarDefault();

                imgEmployeeNumberSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeNumber.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                ImgLCCode.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=LCCCH&ControlId=" + txtLeaveCalendarCode.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");

                if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
                {
                    btnSave.Visible = false;
                    btnCancel.Visible = false;  
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
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
            lblErrMsg.Text = Resources.Resource.NoDataToShow;
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
        }
        else
        {
            lblErrMsg.Text = Resources.Resource.NoDataToShow;
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
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeNumber.Text.ToString(), BaseCompanyCode);
        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            lblEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
            FillApplicationNo();

        }
        else
        {
            DisplayMessage(lblErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            txtEmployeeNumber.Text = "";
            ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
        }
        ddlAdjustmentType.SelectedIndex = 0;
        ddlLeaveType.SelectedIndex = 0;
        txtLeaveBalanceUnits.Text = "";
        lblUnits.Text = "";
        txtAdjustedUnits.Text = "00.00";
        txtReason.Text = "";
        FillApplicationNo();

    }

    /// <summary>
    /// Fills the application no.
    /// </summary>
    protected void FillApplicationNo()
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeaveAdjustmentApplicationNumberGet(txtEmployeeNumber.Text, ddlLeaveType.SelectedValue.ToString(), txtLeaveCalendarCode.Text, BaseLocationAutoID);
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
    /// Handles the OnSelectedIndexChanged event of the ddlLeaveType control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlLeaveType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeaveTypeGet(BaseCompanyCode);
        if (ddlLeaveType.SelectedIndex != 0)
        {
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "Leave_Code='" + ddlLeaveType.SelectedValue.ToString() + "'";
            lblUnits.Text = "";
            lblUnits.Text = dv.Table.Rows[0]["Leave_Unit"].ToString();

            if (txtEmployeeNumber.Text != "")
            {
                txtAdjustedUnits.Text = "00.00";
                txtLeaveBalanceUnits.Text = "";
                txtReason.Text = "";
                ddlAdjustmentType.SelectedIndex = 0;
                FillApplicationNo();
                GetLeaveBalances(txtLeaveCalendarCode, ddlLeaveType, txtEmployeeNumber, txtLeaveBalanceUnits);
            }
            else
            {
                lblErrMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber ;
                ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
            }
        }
        else
        {
            lblUnits.Text = "";
            txtLeaveBalanceUnits.Text = "";
            txtAdjustedUnits.Text = "00.00";
            txtReason.Text = "";
        }
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
            DataView dv = new DataView(ds.Tables[0]);
            dv.RowFilter = "Without_Entitlement_flag <> true";
            ddlLeaveType.DataSource = dv;
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
    /// Gets the leave balances.
    /// </summary>
    /// <param name="txtLeaveCalendarCode">The TXT leave calendar code.</param>
    /// <param name="ddlLeaveCode">The DDL leave code.</param>
    /// <param name="txtEmployeeNumber">The TXT employee number.</param>
    /// <param name="txtLeaveBalance">The TXT leave balance.</param>
    protected void GetLeaveBalances(TextBox txtLeaveCalendarCode, DropDownList ddlLeaveCode, TextBox txtEmployeeNumber, TextBox txtLeaveBalance)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.EmployeeLeaveBalanceGet(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveCode.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtLeaveBalance.Text = double.Parse(ds.Tables[0].Rows[0]["Leave_Balance_Days"].ToString()).ToString("00.00");

        }
        else
        {
            lblErrMsg.Text = Resources.Resource.MsgLeaveBalanceIsNotDefinedForEmployee;
            ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
        }

    }

    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();

        if (txtLeaveCalendarCode.Text != "")
        {
            if (txtEmployeeNumber.Text != "")
            {

                if (ddlLeaveType.SelectedValue != "0")
                {
                    if (ddlAdjustmentType.SelectedValue != "0")
                    {

                        if (txtLeaveBalanceUnits.Text != "")
                        {
                            if (ddlApplicationNo.SelectedValue == "0")
                            {
                                if (double.Parse(txtAdjustedUnits.Text) % 0.25 == 0 && double.Parse(txtAdjustedUnits.Text) > 0.0)
                                {
                                    ds = objLeave.LeaveAdjustmentInsert(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString(), "0", txtAdjustedUnits.Text, txtReason.Text, ddlAdjustmentType.SelectedValue, "A", BaseUserID);
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {

                                        DisplayMessage(lblErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {
                                    lblErrMsg.Text = Resources.Resource.MsgLeaveAdustmentUnitsShouldBeMultipleOf ;
                                    ToolkitScriptManager1.SetFocus("txtAdjustedUnits");
                                }
                            }
                            else
                            {
                                lblErrMsg.Text = Resources.Resource.MsgLeaveOldAdjustmentcantBeUpdated;
                            }
                        }
                        else
                        {
                            lblErrMsg.Text = Resources.Resource.MsgLeaveAdjustmentCantbeDoneWithoutEntitlement ;
                            ToolkitScriptManager1.SetFocus("txtLeaveBalanceUnits");
                        }


                    }
                    else
                    {
                        lblErrMsg.Text = Resources.Resource.MsgRequiredAdjustmentType ;
                        ToolkitScriptManager1.SetFocus("ddlAdjustmentType");
                    }


                }
                else
                {
                    lblErrMsg.Text = Resources.Resource.MsgRequiredLeaveType;
                    ToolkitScriptManager1.SetFocus("ddlLeaveType");
                }

            }
            else
            {
                lblErrMsg.Text = Resources.Resource.MsgRequiredEmployeeNumber ;
                ToolkitScriptManager1.SetFocus("txtEmployeeNumber");
            }




        }
        else
        {
            lblErrMsg.Text = Resources.Resource.MsgRequiredLeaveCalender;
            ToolkitScriptManager1.SetFocus("txtLeaveCalendarCode");
        }

    }

    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        ds = objLeave.LeaveAdjustmentInsert(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString(), ddlApplicationNo.SelectedValue, txtAdjustedUnits.Text, txtReason.Text, ddlAdjustmentType.SelectedValue, "M", BaseUserID);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();

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
        ds = objLeave.LeaveAdjustmentInsert(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue.ToString(), ddlApplicationNo.SelectedValue, txtAdjustedUnits.Text, txtReason.Text, ddlAdjustmentType.SelectedValue, "D", BaseUserID);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblErrMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();

        }
    }

    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtEmployeeNumber.Text = "";
        lblEmployeeName.Text = "";
        ddlLeaveType.SelectedIndex = 0;
        lblUnits.Text = "";
        FillApplicationNo();
        txtLeaveBalanceUnits.Text = "";
        ddlAdjustmentType.SelectedIndex = 0;
        txtAdjustedUnits.Text = "00.00";
        txtReason.Text = "";
    }

    /// <summary>
    /// Fills the type of the adjustment.
    /// </summary>
    protected void FillAdjustmentType()
    {
        ListItem ddlItem3 = new ListItem();
        ddlItem3.Text = Resources.Resource.Select;
        ddlItem3.Value = "0";
        ddlAdjustmentType.Items.Add(ddlItem3);
        ListItem ddlItem1 = new ListItem();
        ddlItem1.Text = Resources.Resource.Incremental;
        ddlItem1.Value = "I";
        ddlAdjustmentType.Items.Add(ddlItem1);
        ListItem ddlItem2 = new ListItem();
        ddlItem2.Text = Resources.Resource.Decremental;
        ddlItem2.Value = "D";
        ddlAdjustmentType.Items.Add(ddlItem2);

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
        if (ddlApplicationNo.SelectedValue != "0")
        {
            ds = objLeave.LeaveAdjustmentApplicationDetailGet(BaseLocationAutoID, txtEmployeeNumber.Text, txtLeaveCalendarCode.Text, ddlLeaveType.SelectedValue, ddlApplicationNo.SelectedValue);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAdjustmentType.SelectedValue = ds.Tables[0].Rows[0]["Adjustment_Type"].ToString().ToUpper();
                txtReason.Text = ds.Tables[0].Rows[0]["Adjustment_Reason"].ToString();
                txtAdjustedUnits.Text = double.Parse(ds.Tables[0].Rows[0]["Adjusted_Units"].ToString()).ToString("00.00");
            }
            else
            {
                txtReason.Text = "";
                ddlAdjustmentType.SelectedValue = "";
                txtAdjustedUnits.Text = "00.00";
            }
        }
        else
        {
            txtReason.Text = "";
            ddlAdjustmentType.SelectedIndex = 0;
            txtAdjustedUnits.Text = "00.00";
        }
    }

}
