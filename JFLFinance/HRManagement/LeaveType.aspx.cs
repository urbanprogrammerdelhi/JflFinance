// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// DESCRIPTION : HRManagement_LeaveType is used to handle the Leave Type event/actions and communicate to and UI Screen.
// ***********************************************************************
// <copyright file="LeaveType.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class HRManagement_LeaveType
/// </summary>


public partial class HRManagement_LeaveType : BasePage //System.Web.UI.Page
{
    #region Property
    /// <summary>
    /// Gets a value indicating whether this instance is read access.
    /// </summary>
    /// <value><c>true</c> if this instance is read access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">t.Request.Url.Abs</exception>
    /// =============================
    /// ==============
    /// </summary>
    private bool IsReadAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght =
                    int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return
                    IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
    /// <exception cref="System.Exception">.Request.Url.Abso</exception>
    /// g());
    /// return IsReadAllowed(Syste
    /// HttpContext.Cu
    /// Returns User Write Rights.
    /// </summary>
    private bool IsWriteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght =
                    int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return
                    IsWriteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0,
                                                                                                  VirtualDirNameLenght));
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
    /// <exception cref="System.Exception">Request.Url.Absol</exception>
    /// ());
    /// return IsWriteAllowed(System
    /// ttpContext.Cur
    /// Returns User Modify Rights.
    /// </summary>
    private bool IsModifyAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght =
                    int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return
                    IsModifyAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0,
                                                                                                   VirtualDirNameLenght));
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
    /// <exception cref="System.Exception">Request.Url.Absol</exception>
    /// ));
    /// return IsModifyAllowed(System
    /// ttpContext.Cur
    /// Returns User Delete Rights.
    /// </summary>
    private bool IsDeleteAccess
    {
        get
        {
            try
            {
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght =
                    int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return
                    IsDeleteAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0,
                                                                                                   VirtualDirNameLenght));
            }
            catch (Exception ex)
            {
                throw new Exception("Have not Rights", ex);
            }
        }
    }

#endregion

    #region Page Functions
    /// <summary>
    /// Function called on Page Load Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Code added by Manoj on 16 Jan 2012
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.LeaveType + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                txtLeaveType.Attributes["onKeyUp"] = "javascript:validateString(this," + Resources.Resource.ValidationExpressionString + ");";
                txtLeaveType.Attributes["onblur"] = "javascript:validateString(this," + Resources.Resource.ValidationExpressionString + ");";

                txtLeaveDesc.Attributes["onKeyUp"] = "javascript:validateString(this," + Resources.Resource.ValidationExpressionString + ");";
                txtLeaveDesc.Attributes["onblur"] = "javascript:validateString(this," + Resources.Resource.ValidationExpressionString + ");";

                FillLeaveUnits();

                btnSave.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                //btnEdit.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnDelete.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnCancel.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";
                btnUpdate.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsg.ClientID.ToString() + "');";

                if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                }
                FillFrequency();

                //Added Code to Set Units Value based on Unit Type by  on 21-Mar-2014
                if (ddlUnits.SelectedItem.Value == @"Hours")
                {
                    txtHoursPerUnit.Text = @"60";
                    txtHoursPerUnit.Enabled = false;
                }
                else
                {
                    txtHoursPerUnit.Text = @"480";
                    txtHoursPerUnit.Enabled = true;
                }
                //End
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

            ImgLTCode.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=LTCCH&ControlId=" + txtLeaveType.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation= &Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=750,Height=350,help=no')");

        }

    }
    #endregion
    #region Fill Details

    /// <summary>
    /// Fills the frequency.
    /// </summary>
    private void FillFrequency()
    {

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ds = objMastersManagement.RateFrequencyGetAll(BaseCompanyCode);
        ddlFreqency.DataSource = ds;
        ddlFreqency.DataTextField = "WRfDesc";
        ddlFreqency.DataValueField = "WRfCode";
        ddlFreqency.DataBind();
        ds.Dispose();
    }
    #endregion

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

        int postingUnitSource = int.Parse(ddlPostingUnitSource.SelectedValue.ToString());

        if (txtHoursPerUnit.Text == "" && ddlUnits.SelectedValue == "Hours")
        { txtHoursPerUnit.Text = "60"; }
        else if (txtHoursPerUnit.Text == "" && ddlUnits.SelectedValue == "Days")
        { txtHoursPerUnit.Text = "480"; }
        else
        { txtHoursPerUnit.Text = "0"; }

        int unitInMinutes = int.Parse(txtHoursPerUnit.Text);

        if (Double.Parse(txtMinUnits.Text) <= Double.Parse(txtMaxUnits.Text))
        {
            if (cbCarryOver.Checked)
            {
                if ((txtCarryOverRule.Text.Trim() == "" && txtCarryOverUnits.Text == "00.00") || (txtCarryOverRule.Text.Trim() != "" && txtCarryOverUnits.Text != "00.00"))
                {
                    DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineCarryOverRuleorUnit);
                    ToolkitScriptManager1.SetFocus(txtCarryOverRule);
                    txtCarryOverRule.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
                else
                {
                    if (cbEncashableLeave.Checked)
                    {
                        if ((txtEncashmentRule.Text.Trim() == "" && txtEncashmentUnits.Text == "00.00") || (txtEncashmentRule.Text.Trim() != "" && txtEncashmentUnits.Text != "00.00"))
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefinedEncashmentRuleorUnit);
                            ToolkitScriptManager1.SetFocus(txtEncashmentRule);
                            txtEncashmentRule.BackColor = System.Drawing.Color.Aqua;
                            return;
                        }
                        else
                        {
                            if (cbWithoutEntitlement.Checked)
                            {
                                if (txtEntitlementRule.Text.Trim() != "" || txtEntitlementUnits.Text != "00.00")
                                {
                                    DisplayMessageString(lblErrorMsg, Resources.Resource.MsgNotDefineEntitlementRuleorUnit);
                                    ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                    txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                    return;
                                }
                                else
                                {
                                    ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedItem.Value.ToString(), txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(),unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "A", BaseUserID, postingUnitSource);
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                        clearFields();
                                    }
                                }
                            }
                            else
                            {
                                if (txtEntitlementRule.Text.Trim() == "" && txtEntitlementUnits.Text == "00.00")
                                {
                                    DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                                    ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                    txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                    return;
                                }
                                else
                                {
                                    ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(),unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "A", BaseUserID, postingUnitSource);
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                        clearFields();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cbWithoutEntitlement.Checked)
                        {
                            if (txtEntitlementRule.Text.Trim() != "" || txtEntitlementUnits.Text != "00.00")
                            {

                                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgNotDefineEntitlementRuleorUnit);
                                ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                return;
                            }
                            else
                            {
                                ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(),unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "A", BaseUserID, postingUnitSource);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                    clearFields();
                                }
                            }
                        }
                        else
                        {
                            if (txtEntitlementRule.Text.Trim() == "" && txtEntitlementUnits.Text == "00.00")
                            {

                                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                                ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                return;
                            }
                            else
                            {
                                ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(),unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "A", BaseUserID, postingUnitSource);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                    clearFields();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (cbEncashableLeave.Checked)
                {
                    if ((txtEncashmentRule.Text.Trim() == "" && txtEncashmentUnits.Text == "00.00") || (txtEncashmentRule.Text.Trim() != "" && txtEncashmentUnits.Text != "00.00"))
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefinedEncashmentRuleorUnit);
                        ToolkitScriptManager1.SetFocus(txtEncashmentRule);
                        txtEncashmentRule.BackColor = System.Drawing.Color.Aqua;
                        return;
                    }
                    else
                    {
                        if (cbWithoutEntitlement.Checked)
                        {
                            if (txtEntitlementRule.Text.Trim() != "" || txtEntitlementUnits.Text != "00.00")
                            {
                                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgNotDefineEntitlementRuleorUnit);
                                ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                return;
                            }
                            else
                            {
                                ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(),unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "A", BaseUserID, postingUnitSource);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                    clearFields();
                                }
                            }
                        }
                        else
                        {
                            if (txtEntitlementRule.Text.Trim() == "" && txtEntitlementUnits.Text == "00.00")
                            {
                                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                                ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                return;
                            }
                            else
                            {
                                ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(),unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "A", BaseUserID, postingUnitSource);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                    clearFields();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (cbWithoutEntitlement.Checked)
                    {
                        if (txtEntitlementRule.Text.Trim() != "" || txtEntitlementUnits.Text != "00.00")
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.MsgNotDefineEntitlementRuleorUnit);
                            ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                            txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                            return;
                        }
                        else
                        {
                            ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(),unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "A", BaseUserID, postingUnitSource);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                clearFields();
                            }
                        }
                    }
                    else
                    {
                        if (txtEntitlementRule.Text.Trim() == "" && txtEntitlementUnits.Text == "00.00")
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                            ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                            txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                            return;
                        }
                        else
                        {
                            ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(),unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "A", BaseUserID, postingUnitSource);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                clearFields();
                            }
                        }
                    }
                }
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgLeaveMinUnitsCantBeGreaterThanMaxUnits;
            ToolkitScriptManager1.SetFocus(txtMaxUnits);

            return;
        }

    }
    /// <summary>
    /// Called when [text changed_txt leave type].
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void OnTextChanged_txtLeaveType(object sender, EventArgs e)
    {
        if (txtLeaveType.Text != "")
        {
            BL.Leave objLeave = new BL.Leave();
            DataSet ds = new DataSet();
            ds = objLeave.LeaveTypeGet(txtLeaveType.Text, BaseCompanyCode);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtLeaveDesc.Text = ds.Tables[0].Rows[0]["Leave_Desc"].ToString();
                txtEntitlementUnits.Text = double.Parse(ds.Tables[0].Rows[0]["Leave_Entitled_unit"].ToString()).ToString("00.00");
                txtEncashmentUnits.Text = double.Parse(ds.Tables[0].Rows[0]["Encashment_Unit"].ToString()).ToString("00.00");
                txtMaxUnits.Text = double.Parse(ds.Tables[0].Rows[0]["Maximum_Unit"].ToString()).ToString("00.00");
                txtMinUnits.Text = double.Parse(ds.Tables[0].Rows[0]["Minimum_Unit"].ToString()).ToString("00.00");
                txtPostingRule.Text = ds.Tables[0].Rows[0]["Posting_Rule"].ToString();
                txtEncashmentRule.Text = ds.Tables[0].Rows[0]["Encashment_Rule"].ToString();
                txtEntitlementRule.Text = ds.Tables[0].Rows[0]["Leave_Entitlement_Rule"].ToString();
                txtCarryOverRule.Text = ds.Tables[0].Rows[0]["Carryover_rule"].ToString();
                txtCarryOverUnits.Text = double.Parse(ds.Tables[0].Rows[0]["Carryover_days"].ToString()).ToString("00.00");
                ddlFreqency.SelectedValue = ds.Tables[0].Rows[0]["EntitleMent_Frequency"].ToString().ToUpper().Trim();
                if (ds.Tables[0].Rows[0]["Leave_Unit"].ToString().ToLower().Trim() == "Days".ToLower().ToString())
                {
                    ddlUnits.SelectedValue = "Days";
                }
                else
                {
                    ddlUnits.SelectedValue = "Hours";
                }
                if (bool.Parse(ds.Tables[0].Rows[0]["Carryover_flag"].ToString()) == true)
                {
                    cbCarryOver.Checked = true;
                    cbCarryOver_OnCheckedChanged(sender, e);
                }
                else
                {
                    cbCarryOver.Checked = false;
                }
                if (bool.Parse(ds.Tables[0].Rows[0]["Holiday_Inclusive_flag"].ToString()) == true)
                {
                    cbHolidayInclusive.Checked = true;
                }
                else
                {
                    cbHolidayInclusive.Checked = false;
                }
                if (bool.Parse(ds.Tables[0].Rows[0]["Affects_Service_Growth"].ToString()) == true)
                {
                    cbAffectsServiceGrowth.Checked = true;
                }
                else
                {
                    cbAffectsServiceGrowth.Checked = false;
                }
                if (bool.Parse(ds.Tables[0].Rows[0]["Encash_flag"].ToString()) == true)
                {
                    cbEncashableLeave.Checked = true;
                }
                else
                {
                    cbEncashableLeave.Checked = false;
                }
                if (bool.Parse(ds.Tables[0].Rows[0]["Medical_Certification_flag"].ToString()) == true)
                {
                    cbMedicalCertification.Checked = true;
                }
                else
                {
                    cbMedicalCertification.Checked = false;
                }
                if (bool.Parse(ds.Tables[0].Rows[0]["Without_Entitlement_flag"].ToString()) == true)
                {
                    cbWithoutEntitlement.Checked = true;
                }
                else
                {
                    cbWithoutEntitlement.Checked = false;
                }
                if (bool.Parse(ds.Tables[0].Rows[0]["IsActive"].ToString()) == true)
                {
                    chkIsActive.Checked = true;
                }
                else
                {
                    chkIsActive.Checked = false;
                }
                ddlPostingUnitSource.SelectedValue = ds.Tables[0].Rows[0]["PostingUnitSource"].ToString();
                txtHoursPerUnit.Text = ds.Tables[0].Rows[0]["Hours_Per_Unit"].ToString();

                //Added Code to Set Units Value based on Unit Type by  on 21-Mar-2014
                txtHoursPerUnit.Enabled = ddlUnits.SelectedItem.Value != @"Hours";
                //End

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                //DisplayMessageString(lblErrorMsg, Resources.Resource.NoDataToShow);
            }
        }
    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();

        int postingUnitSource = int.Parse(ddlPostingUnitSource.SelectedValue.ToString());
        // refer task id 716
        //Manish 
        /*if (txtHoursPerUnit.Text == "" && ddlUnits.SelectedValue == "Hours")
        { txtHoursPerUnit.Text = "60"; }
        else if (txtHoursPerUnit.Text == "" && ddlUnits.SelectedValue == "Days")
        { txtHoursPerUnit.Text = "480"; }
        else
        { txtHoursPerUnit.Text = "0"; }
        */
        if (ddlUnits.SelectedValue == "Hours")
        {
            { txtHoursPerUnit.Text = "60"; }
        }
        else if (txtHoursPerUnit.Text== "" || int.Parse(txtHoursPerUnit.Text.ToString()) <= 0 && ddlUnits.SelectedValue == "Days")
        {
            System.Windows.Forms.MessageBox.Show(MessageString_Get(96));
            
            txtHoursPerUnit.Focus();
            return;
        }
         
        int unitInMinutes = int.Parse(txtHoursPerUnit.Text);


        if (Double.Parse(txtMinUnits.Text) <= Double.Parse(txtMaxUnits.Text))
        {

            if (cbCarryOver.Checked)
            {
                if ((txtCarryOverRule.Text.Trim() == "" && txtCarryOverUnits.Text == "00.00") || (txtCarryOverRule.Text.Trim() != "" && txtCarryOverUnits.Text != "00.00"))
                {

                    DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineCarryOverRuleorUnit);
                    ToolkitScriptManager1.SetFocus(txtCarryOverRule);
                    txtCarryOverRule.BackColor = System.Drawing.Color.Aqua;
                    return;
                }
                else
                {
                    if (cbEncashableLeave.Checked)
                    {
                        if ((txtEncashmentRule.Text.Trim() == "" && txtEncashmentUnits.Text == "00.00") || (txtEncashmentRule.Text.Trim() != "" && txtEncashmentUnits.Text != "00.00"))
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefinedEncashmentRuleorUnit);
                            ToolkitScriptManager1.SetFocus(txtEncashmentRule);
                            txtEncashmentRule.BackColor = System.Drawing.Color.Aqua;
                            return;
                        }
                        else
                        {
                            if (cbWithoutEntitlement.Checked)
                            {
                                if (txtEntitlementRule.Text.Trim() != "" || txtEntitlementUnits.Text != "00.00")
                                {

                                    DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                                    ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                    txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                    return;
                                }
                                else
                                {
                                    ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "M", BaseUserID, postingUnitSource);
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                        clearFields();
                                    }
                                }
                            }
                            else
                            {
                                if (txtEntitlementRule.Text.Trim() == "" && txtEntitlementUnits.Text == "00.00")
                                {
                                    DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                                    ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                    txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                    return;
                                }
                                else
                                {
                                    ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "M", BaseUserID, postingUnitSource);
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                        clearFields();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cbWithoutEntitlement.Checked)
                        {
                            if (txtEntitlementRule.Text.Trim() != "" || txtEntitlementUnits.Text != "00.00")
                            {
                                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgNotDefineEntitlementRuleorUnit);
                                ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                return;
                            }
                            else
                            {
                                ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "M", BaseUserID, postingUnitSource);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                    clearFields();
                                }
                            }
                        }
                        else
                        {
                            if (txtEntitlementRule.Text.Trim() == "" && txtEntitlementUnits.Text == "00.00")
                            {
                                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                                ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                return;
                            }
                            else
                            {
                                ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "M", BaseUserID, postingUnitSource);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                    clearFields();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (cbEncashableLeave.Checked)
                {
                    if ((txtEncashmentRule.Text.Trim() == "" && txtEncashmentUnits.Text == "00.00") || (txtEncashmentRule.Text.Trim() != "" && txtEncashmentUnits.Text != "00.00"))
                    {
                        DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefinedEncashmentRuleorUnit);
                        ToolkitScriptManager1.SetFocus(txtEncashmentRule);
                        txtEncashmentRule.BackColor = System.Drawing.Color.Aqua;
                        return;
                    }
                    else
                    {
                        if (cbWithoutEntitlement.Checked)
                        {
                            if (txtEntitlementRule.Text.Trim() != "" || txtEntitlementUnits.Text != "00.00")
                            {
                                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgNotDefineEntitlementRuleorUnit);
                                ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                return;
                            }
                            else
                            {
                                ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "M", BaseUserID, postingUnitSource);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                    clearFields();
                                }
                            }
                        }
                        else
                        {
                            if (txtEntitlementRule.Text.Trim() == "" && txtEntitlementUnits.Text == "00.00")
                            {
                                DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                                ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                                txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                                return;
                            }
                            else
                            {
                                ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "M", BaseUserID, postingUnitSource);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                    clearFields();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (cbWithoutEntitlement.Checked)
                    {
                        if (txtEntitlementRule.Text.Trim() != "" || txtEntitlementUnits.Text != "00.00")
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.MsgNotDefineEntitlementRuleorUnit);
                            ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                            txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                            return;
                        }
                        else
                        {
                            ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "M", BaseUserID, postingUnitSource);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                clearFields();
                            }
                        }
                    }
                    else
                    {
                        if (txtEntitlementRule.Text.Trim() == "" && txtEntitlementUnits.Text == "00.00")
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.MsgEitherDefineEntitlementRuleorUnit);
                            ToolkitScriptManager1.SetFocus(txtEntitlementRule);
                            txtEntitlementRule.BackColor = System.Drawing.Color.Aqua;
                            return;
                        }
                        else
                        {
                            ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "M", BaseUserID, postingUnitSource);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                clearFields();
                            }
                        }
                    }
                }
            }
        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.MsgLeaveMinUnitsCantBeGreaterThanMaxUnits;
            ToolkitScriptManager1.SetFocus(txtMaxUnits);

            return;
        }


    }
    /// <summary>
    /// Handles the Click event of the btnDelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtHoursPerUnit.Text == "" && ddlUnits.SelectedValue == "Hours")
        { txtHoursPerUnit.Text = "60"; }
        else if (txtHoursPerUnit.Text == "" && ddlUnits.SelectedValue == "Days")
        { txtHoursPerUnit.Text = "480"; }
        else
        { txtHoursPerUnit.Text = "0"; }

        int unitInMinutes = int.Parse(txtHoursPerUnit.Text);

        BL.Leave objLeave = new BL.Leave();
        DataSet ds = new DataSet();
        int postingUnitSource = int.Parse(ddlPostingUnitSource.SelectedValue.ToString());
        ds = objLeave.LeaveTypeInsert(BaseCompanyCode, txtLeaveType.Text.ToString(), ddlFreqency.SelectedValue, txtLeaveDesc.Text.ToString(), ddlUnits.SelectedValue.ToString(), unitInMinutes, txtEntitlementRule.Text.ToString(), txtEntitlementUnits.Text.ToString(), cbCarryOver.Checked.ToString(), txtCarryOverRule.Text.ToString(), txtCarryOverUnits.Text.ToString(), txtPostingRule.Text.ToString(), txtMinUnits.Text.ToString(), txtMaxUnits.Text.ToString(), txtEncashmentRule.Text.ToString(), txtEncashmentUnits.Text.ToString(), cbAffectsServiceGrowth.Checked.ToString(), cbEncashableLeave.Checked.ToString(), cbHolidayInclusive.Checked.ToString(), cbMedicalCertification.Checked.ToString(), cbWithoutEntitlement.Checked.ToString(), chkIsActive.Checked.ToString(), "D", BaseUserID, postingUnitSource);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageId"].ToString());
            clearFields();
        }
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearFields();
    }
    /// <summary>
    /// Fills the leave units.
    /// </summary>
    protected void FillLeaveUnits()
    {
        ListItem ddlItem1 = new ListItem();
        ddlItem1.Text = Resources.Resource.Hours;
        ddlItem1.Value = "Hours";
        ddlUnits.Items.Add(ddlItem1);
        ListItem ddlItem2 = new ListItem();
        ddlItem2.Text = Resources.Resource.Days;
        ddlItem2.Value = "Days";
        ddlUnits.Items.Add(ddlItem2);
    }

    /// <summary>
    /// Clears the fields.
    /// </summary>
    protected void clearFields()
    {
        txtLeaveType.Text = "";
        txtLeaveDesc.Text = "";
        chkIsActive.Checked = false;
        txtCarryOverRule.Text = "";
        txtCarryOverUnits.Text = "00.00";
        txtPostingRule.Text = "";
        txtMaxUnits.Text = "00.00";
        txtMinUnits.Text = "00.00";
        txtEncashmentRule.Text = "";
        txtEncashmentUnits.Text = "00.00";
        txtEntitlementRule.Text = "";
        txtEntitlementUnits.Text = "00.00";
        cbAffectsServiceGrowth.Checked = false;
        cbEncashableLeave.Checked = false;
        cbHolidayInclusive.Checked = false;
        cbMedicalCertification.Checked = false;
        cbWithoutEntitlement.Checked = false;
        cbCarryOver.Checked = false;
    }

    /// <summary>
    /// Handles the OnCheckedChanged event of the cbCarryOver control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void cbCarryOver_OnCheckedChanged(object sender, EventArgs e)
    {
        if (cbCarryOver.Checked == true)
        {
            txtCarryOverRule.Enabled = true;
            txtCarryOverUnits.Enabled = true;
        }
        else
        {
            txtCarryOverRule.Enabled = false;
            txtCarryOverUnits.Enabled = false;
        }
    }

    /// <summary>
    /// Function called on Drop Down Unit Selected Index Changed event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Added Code to Set Units Value based on Unit Type by  on 21-Mar-2014
        if (ddlUnits.SelectedItem.Value == @"Hours")
        {
            txtHoursPerUnit.Text = @"60";
            txtHoursPerUnit.Enabled = false;
        }
        else
        {
            txtHoursPerUnit.Text = @"480";
            txtHoursPerUnit.Enabled = true;
        }
    }
}
