// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-13-2014
// ***********************************************************************
// <copyright file="EmployeeCompensationHistory.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class HRManagement_EmployeeCompensationHistory
/// </summary>
public partial class HRManagement_EmployeeCompensationHistory : BasePage
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
                var virtualDirNameLenght = 0;
                virtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return IsReadAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, virtualDirNameLenght));
            }
            catch (Exception ex)
            {
                var ds = new DataSet();
                var objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex);
            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose(); throw new Exception("Have not Rights", ex);
            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose(); throw new Exception("Have not Rights", ex);
            }
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
            {
                DataSet ds = new DataSet();
                BL.ExceptionLogs objEx = new BL.ExceptionLogs();
                objEx.ExceptionLog(ex.ToString(), BaseUserID);
                ds.Dispose();
                throw new Exception("Have not Rights", ex);
            }
        }
    }

    #endregion

    #region Page function
    /// <summary>
    /// Function called on Page Initialization.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }
    /// <summary>
    /// Function called on Page Load event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EmployeeCompensationHistory + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
            txtValue.Attributes.Add("onchange", "TextBoxChange(this.id)");


            if (IsReadAccess == true)
            {
                string EmployeeNumber = Request.QueryString["EmployeeNumber"];
                string FirstName = Request.QueryString["FirstName"];
                string LastName = Request.QueryString["LastName"];
                txtEmployeeNumber.Text = EmployeeNumber.ToString();
                txtEmployeeName.Text = FirstName.ToString() + " " + LastName.ToString();
                AddAttributes();
                DataSet ds = new DataSet();
                BL.MastersManagement objMastersManagement = new BL.MastersManagement();

                ds = objMastersManagement.ComponentTypeGet(BaseCompanyCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlComponent.DataSource = ds.Tables[0];
                    ddlComponent.DataValueField = "ComponentCode";
                    ddlComponent.DataTextField = "ComponentDesc";
                    ddlComponent.DataBind();
                }
                ListItem li1 = new ListItem();
                if (ddlComponent.Text == "")
                {
                    li1 = new ListItem {Text = Resources.Resource.NoDataToShow, Value = ""};
                    ddlComponent.Items.Add(li1);
                    DisableButtons();
                }

                var li1CU = new ListItem();
                li1CU = new ListItem {Text = Resources.Resource.Correct, Value = "Correct"};
                ddlSelCorrectORUpdate.Items.Add(li1CU);
                li1CU = new ListItem {Text = Resources.Resource.Update, Value = "Update"};

                ddlSelCorrectORUpdate.Items.Add(li1CU);

                ds = objMastersManagement.PercentageValueGet(BaseCompanyCode);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlPercentageValue.DataSource = ds.Tables[0];
                    ddlPercentageValue.DataValueField = "PercentageValueCode";
                    ddlPercentageValue.DataTextField = "PercentageValueDesc";
                    ddlPercentageValue.DataBind();
                }
                var li2 = new ListItem();
                if (ddlPercentageValue.Text == "")
                {
                    li2 = new ListItem {Text = Resources.Resource.NoDataToShow, Value = ""};
                    ddlPercentageValue.Items.Add(li2);
                    DisableButtons();
                }

                FillRateFrequency();
                FillCurrency();
                FillPercentageOf();
                if (txtEmployeeNumber.Text.ToString() != null)
                {
                    var objHrManagement = new BL.HRManagement();
                    ds = objHrManagement.CompensationHistoryGetByComponent(txtEmployeeNumber.Text, BaseCompanyCode, ddlComponent.SelectedItem.Value);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "Update")
                        {
                            txtStatus.Text = "Modify";

                            ddlPercentageValue.SelectedValue = ds.Tables[0].Rows[0]["PercentageValueType"].ToString();
                            ddlFrequency.SelectedValue = ds.Tables[0].Rows[0]["Frequency"].ToString();

                            if (ddlComponent.SelectedItem.Value == "ContDays")
                            {
                                string strContDays = ds.Tables[0].Rows[0]["ComponentValue"].ToString();

                                int ContDays = int.Parse(strContDays.Substring(0, strContDays.IndexOf(".")));

                                txtValue.Text = Convert.ToString(ContDays);
                            }
                            else
                            {
                                txtValue.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["ComponentValue"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                            }

                            ddlCurrency.SelectedValue = ds.Tables[0].Rows[0]["WageCurrencyCode"].ToString();
                            ddlPercentageof.SelectedValue = ds.Tables[0].Rows[0]["PercentageofComponent"].ToString();

                            EnableDisableFields();

                        }
                        else
                        {
                            txtStatus.Text = "Add";
                            EnableDisableFields();
                            FillDefaultEffectiveFromDate();
                            EnableButtons();
                        }
                    }
                }
                else
                {
                    DisableButtons();
                }

                System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                ToolkitScriptManager2.SetFocus(ddlComponent);
                ShowHideControls();

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    /// <summary>
    /// Function used to fill percentage Drop Down List.
    /// </summary>
    private void FillPercentageOf()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();
        ddlPercentageof.Items.Clear();
        ds = objMastersManagement.PercentageGet(BaseCompanyCode, ddlComponent.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlPercentageof.DataSource = ds.Tables[0];
            ddlPercentageof.DataValueField = "PercentageofCode";
            ddlPercentageof.DataTextField = "PercentageofDesc";
            ddlPercentageof.DataBind();
        }
        ListItem li4 = new ListItem();
        if (ddlPercentageof.Text == "")
        {
            li4 = new ListItem();
            li4.Text = Resources.Resource.NoDataToShow;
            li4.Value = "";
            ddlPercentageof.Items.Add(li4);
            DisableButtons();
        }
    }
    /// <summary>
    /// Function used to fill Effective from Date.
    /// </summary>
    private void FillDefaultEffectiveFromDate()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        ds = objHRManagement.EmployeeDefaultEffectiveFromDateGet(BaseCompanyCode, txtEmployeeNumber.Text, ddlComponent.SelectedItem.Value.ToString());
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(ds.Tables[0].Rows[0]["DateOfJoining"].ToString());
            txtAddEffectiveFrom.Text = dt.ToString("dd-MMM-yyyy");
        }
        else
        {
            txtAddEffectiveFrom.Text = "";
        }
    }

    /// <summary>
    /// Function used to Enable/Disable Controls
    /// </summary>
    private void EnableDisableFields()
    {
        if (txtStatus.Text == "Modify")
        {
            lblAddEffectiveFrom.Visible = false;
            txtAddEffectiveFrom.Visible = false;
            ImgAddEffectiveFrom.Visible = false;
            lblSelCorrectORUpdate.Visible = true;
            ddlSelCorrectORUpdate.Visible = true;
            ddlSelCorrectORUpdate.SelectedValue = "Correct";
            lblUpdateEffectiveFrom.Visible = false;
            txtUpdateEffectiveFrom.Visible = false;
            ImgUpdateEffectiveFrom.Visible = false;
            getAllRecordsNOnEditable();
        }
        else
        {
            lblAddEffectiveFrom.Visible = true;
            txtAddEffectiveFrom.Visible = true;
            ImgAddEffectiveFrom.Visible = true;
            lblSelCorrectORUpdate.Visible = false;
            ddlSelCorrectORUpdate.Visible = false;
            ddlSelCorrectORUpdate.SelectedValue = "Correct";
            lblUpdateEffectiveFrom.Visible = false;
            txtUpdateEffectiveFrom.Visible = false;
            ImgUpdateEffectiveFrom.Visible = false;
            getAllRecordsEditable();
        }

        if (ddlComponent.SelectedItem.Value == "WageRate" || ddlComponent.SelectedItem.Value == "ContHours" || ddlComponent.SelectedItem.Value == "ContDays")
        {
            if (ddlComponent.SelectedItem.Value == "WageRate")
            {
                lblChkDisable.Visible = false;
                chkDisable.Checked = false;
                chkDisable.Visible = false;
                lblWEFDate.Visible = false;
                txtWEFDate.Visible = false;
                ImgWEFDate.Visible = false;

                ddlPercentageValue.Enabled = false;
                ddlFrequency.Enabled = false;
                txtValue.Enabled = true;
                ddlCurrency.Enabled = true;
                ddlPercentageof.Enabled = false;
            }

            if (ddlComponent.SelectedItem.Value == "ContHours")
            {
                lblChkDisable.Visible = false;
                chkDisable.Checked = false;
                chkDisable.Visible = false;
                lblWEFDate.Visible = false;
                txtWEFDate.Visible = false;
                ImgWEFDate.Visible = false;

                ddlPercentageValue.Enabled = false;
                ddlFrequency.Enabled = true;
                txtValue.Enabled = true;
                ddlCurrency.Enabled = false;
                ddlPercentageof.Enabled = false;
            }

            if (ddlComponent.SelectedItem.Value.ToString() == "ContDays")
            {
                lblChkDisable.Visible = false;
                chkDisable.Checked = false;
                chkDisable.Visible = false;
                lblWEFDate.Visible = false;
                txtWEFDate.Visible = false;
                ImgWEFDate.Visible = false;

                ddlPercentageValue.Enabled = false;
                ddlFrequency.Enabled = false;
                txtValue.Enabled = true;
                ddlCurrency.Enabled = false;
                ddlPercentageof.Enabled = false;
            }
        }
        else
        {
            if (txtStatus.Text == "Add")
            {
                lblChkDisable.Visible = false;
                chkDisable.Checked = false;
                chkDisable.Visible = false;
                lblWEFDate.Visible = false;
                txtWEFDate.Visible = false;
                ImgWEFDate.Visible = false;

                ddlPercentageValue.Enabled = true;
                if (ddlPercentageValue.SelectedItem.Value.ToString() == "VAL")
                {
                    ddlFrequency.Enabled = true;
                    txtValue.Text = "0.000000";
                    txtValue.Enabled = true;
                    ddlCurrency.Enabled = true;
                    ddlPercentageof.SelectedValue = "NONE";
                    ddlPercentageof.Enabled = false;
                }
                else if (ddlPercentageValue.SelectedItem.Value.ToString() == "PER")
                {
                    ddlFrequency.SelectedValue = "NONE";
                    ddlFrequency.Enabled = false;
                    txtValue.Text = "0.000000";
                    txtValue.Enabled = true;
                    ddlCurrency.SelectedValue = "NONE";
                    ddlCurrency.Enabled = false;
                    ddlPercentageof.Enabled = true;
                }
                else
                {
                    ddlFrequency.SelectedValue = "NONE";
                    ddlFrequency.Enabled = false;
                    txtValue.Text = "0.000000";
                    txtValue.Enabled = false;
                    ddlCurrency.SelectedValue = "NONE";
                    ddlCurrency.Enabled = false;
                    ddlCurrency.SelectedValue = "NONE";
                    ddlCurrency.Enabled = false;
                }
            }
            else
            {
                lblChkDisable.Visible = true;
                chkDisable.Checked = false;
                chkDisable.Visible = true;
                lblWEFDate.Visible = true;
                txtWEFDate.Visible = true;
                ImgWEFDate.Visible = true;

                ddlPercentageValue.Enabled = true;
                if (ddlPercentageValue.SelectedItem.Value.ToString() == "VAL")
                {
                    ddlFrequency.Enabled = true;
                    txtValue.Enabled = true;
                    ddlCurrency.Enabled = true;
                    ddlPercentageof.SelectedValue = "NONE";
                    ddlPercentageof.Enabled = false;
                }
                else if (ddlPercentageValue.SelectedItem.Value.ToString() == "PER")
                {
                    ddlFrequency.SelectedValue = "NONE";
                    ddlFrequency.Enabled = false;
                    txtValue.Enabled = true;
                    ddlCurrency.SelectedValue = "NONE";
                    ddlCurrency.Enabled = false;
                    ddlPercentageof.Enabled = true;
                }
                else
                {
                    ddlFrequency.SelectedValue = "NONE";
                    ddlFrequency.Enabled = false;
                    txtValue.Enabled = false;
                    ddlCurrency.SelectedValue = "NONE";
                    ddlCurrency.Enabled = false;
                    ddlCurrency.SelectedValue = "NONE";
                    ddlCurrency.Enabled = false;
                }
            }
        }
    }

    /// <summary>
    /// Function used to Disable Button Controls
    /// </summary>
    private void DisableButtons()
    {
        btnCancel.Enabled = true;
        btnSubmit.Enabled = false;
    }

    /// <summary>
    /// Function used to Enable Button Controls
    /// </summary>
    private void EnableButtons()
    {
        btnCancel.Enabled = true;
        btnSubmit.Enabled = true;
    }

    /// <summary>
    /// Function used to Add Attributes
    /// </summary>
    private void AddAttributes()
    {
        txtEmployeeNumber.ReadOnly = true;
        txtEmployeeName.ReadOnly = true;
        txtStatus.ReadOnly = true;
    }
    #endregion

    #region Controles Events
    /// <summary>
    /// Function called on Cancel Button Click Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string Status = Resources.Resource.Update;
        Response.Redirect("EmployeeMaster.aspx?strStatus=" + Status + "&strEmployeeNumber=" + txtEmployeeNumber.Text);
    }

    /// <summary>
    /// Function called on Submit Button Click Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.Common objCommon = new BL.Common();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        if (txtStatus.Text == "Modify")
        {
            if (ddlSelCorrectORUpdate.SelectedItem.Value.ToString() == "Correct")
            {
                if (ddlComponent.SelectedItem.Value.ToString() != "WageRate" && ddlComponent.SelectedItem.Value.ToString() != "ContHours" && ddlComponent.SelectedItem.Value.ToString() != "ContDays")
                {
                    if (chkDisable.Checked == true)
                    {
                        if (txtWEFDate.Text != "")
                        {
                            if (objCommon.IsValidDate(txtWEFDate.Text) != true)
                            {
                                lblErrorMsg.Text = Resources.Resource.InvalidDate;
                                txtWEFDate.Focus();
                                return;
                            }
                            else
                            {
                                ds = objHRManagement.SaveInModifyDisable(BaseCompanyCode, txtEmployeeNumber.Text.ToString(), ddlComponent.SelectedItem.Value.ToString(), DateTime.Parse(txtWEFDate.Text), BaseUserID);

                                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                                ChangeScreenDetails();
                                return;
                            }
                        }
                        else
                        {
                            lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                            return;
                        }
                    }

                    if (ddlPercentageValue.SelectedItem.Value.ToString() == "VAL")
                    {
                        if (ddlFrequency.SelectedItem.Value.ToString() == "NONE")
                        {
                            lblErrorMsg.Text = "Frequency Cannot Be None Incase of Value. Please Select The Frequency...";
                            return;
                        }

                        if ((txtValue.Text.Length == 0) || (float.Parse(txtValue.Text) <= 0))
                        {
                            lblErrorMsg.Text = "Entered Value Cannot Be Less Than Or Equal To Zero...";
                            return;
                        }

                        if (ddlCurrency.SelectedItem.Value.ToString() == "NONE")
                        {
                            lblErrorMsg.Text = "Currency Cannot Be None Incase of Value. Please Select The Frequency...";
                            return;
                        }
                    }
                    else
                    {
                        if ((txtValue.Text.Length == 0) || (float.Parse(txtValue.Text) <= 0))
                        {
                            lblErrorMsg.Text = "Entered Value Cannot Be Less Than Or Equal To Zero...";
                            return;
                        }

                        if (ddlPercentageof.SelectedItem.Value.ToString() == "NONE")
                        {
                            lblErrorMsg.Text = "PercentageOf Cannot Be None Incase of Percentage. Please Select The Percentage Of...";
                            return;
                        }
                    }
                }
                else
                {
                    if (ddlComponent.SelectedItem.Value.ToString() == "WageRate")
                    {
                        if (ddlCurrency.SelectedItem.Value.ToString() == "NONE")
                        {
                            lblErrorMsg.Text = "Currency Cannot Be None Incase of Pay Rate Per Hour... Please Select The Currency...";
                            return;
                        }
                    }
                    if (ddlComponent.SelectedItem.Value.ToString() == "ContHours")
                    {
                        if (ddlFrequency.SelectedItem.Value.ToString() == "NONE")
                        {
                            lblErrorMsg.Text = "Frequency Cannot Be None Incase of Contracted Hours... Please Select The Frequency...";
                            return;
                        }
                    }
                    if (ddlComponent.SelectedItem.Value.ToString() == "ContDays")
                    {
                        if (int.Parse(txtValue.Text) <= 0 || int.Parse(txtValue.Text) > 7)
                        {
                            lblErrorMsg.Text = "Contract Days Value Should Be Between 1 and 7...";
                            return;
                        }
                    }
                }

                ds = objHRManagement.SaveInModifyCorrect(BaseCompanyCode, txtEmployeeNumber.Text.ToString(), ddlComponent.SelectedItem.Value.ToString(), ddlPercentageValue.SelectedItem.Value.ToString(), ddlFrequency.SelectedItem.Value.ToString(), decimal.Parse(txtValue.Text).ToString("0.00"), ddlCurrency.SelectedItem.Value.ToString(), ddlPercentageof.SelectedItem.Value.ToString(), BaseUserID);

                DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                ChangeScreenDetails();
            }
            else
            {
                if (txtUpdateEffectiveFrom.Text != "")
                {
                    if (objCommon.IsValidDate(txtUpdateEffectiveFrom.Text) != true)
                    {
                        lblErrorMsg.Text = Resources.Resource.InvalidDate;
                        txtUpdateEffectiveFrom.Focus();
                        return;
                    }


                    if (ddlComponent.SelectedItem.Value.ToString() != "WageRate" && ddlComponent.SelectedItem.Value.ToString() != "ContHours" && ddlComponent.SelectedItem.Value.ToString() != "ContDays")
                    {
                        if (ddlPercentageValue.SelectedItem.Value.ToString() == "VAL")
                        {
                            if (ddlFrequency.SelectedItem.Value.ToString() == "NONE")
                            {
                                lblErrorMsg.Text = "Frequency Cannot Be None Incase of Value. Please Select The Frequency...";
                                return;
                            }

                            if ((txtValue.Text.Length == 0) || (float.Parse(txtValue.Text) <= 0))
                            {
                                lblErrorMsg.Text = "Entered Value Cannot Be Less Than Or Equal To Zero...";
                                return;
                            }

                            if (ddlCurrency.SelectedItem.Value.ToString() == "NONE")
                            {
                                lblErrorMsg.Text = "Currency Cannot Be None Incase of Value. Please Select The Frequency...";
                                return;
                            }
                        }
                        else
                        {
                            if ((txtValue.Text.Length == 0) || (float.Parse(txtValue.Text) <= 0))
                            {
                                lblErrorMsg.Text = "Entered Value Cannot Be Less Than Or Equal To Zero...";
                                return;
                            }

                            if (ddlPercentageof.SelectedItem.Value.ToString() == "NONE")
                            {
                                lblErrorMsg.Text = "PercentageOf Cannot Be None Incase of Percentage. Please Select The Percentage Of...";
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (ddlComponent.SelectedItem.Value.ToString() == "WageRate")
                        {
                            if (ddlCurrency.SelectedItem.Value.ToString() == "NONE")
                            {
                                lblErrorMsg.Text = "Currency Cannot Be None Incase of Pay Rate Per Hour... Please Select The Currency...";
                                return;
                            }
                        }
                        if (ddlComponent.SelectedItem.Value.ToString() == "ContHours")
                        {
                            if (ddlFrequency.SelectedItem.Value.ToString() == "NONE")
                            {
                                lblErrorMsg.Text = "Frequency Cannot Be None Incase of Contracted Hours... Please Select The Frequency...";
                                return;
                            }
                        }
                        if (ddlComponent.SelectedItem.Value.ToString() == "ContDays")
                        {
                            if (int.Parse(txtValue.Text) <= 0 || int.Parse(txtValue.Text) > 7)
                            {
                                lblErrorMsg.Text = "Contract Days Value Should Be Between 1 and 7...";
                                return;
                            }
                        }

                    }
                    //Check for the Max Effective Date Bug 1039 Rectification By  on 07/08/14
                     DataTable dt = objHRManagement.CheckEffectiveFrom(BaseCompanyCode, txtEmployeeNumber.Text.ToString(), DateTime.Parse(txtUpdateEffectiveFrom.Text));
                    if (dt.Rows[0]["MessageID"].ToString() == "0")
                    {
                        lblErrorMsg.Text = dt.Rows[0]["MessageString"].ToString();
                    }
                    else
                    {
                        ds = objHRManagement.SaveInModifyUpdate(BaseCompanyCode, txtEmployeeNumber.Text.ToString(), ddlComponent.SelectedItem.Value.ToString(), ddlPercentageValue.SelectedItem.Value.ToString(), ddlFrequency.SelectedItem.Value.ToString(), decimal.Parse(txtValue.Text).ToString("0.00"), ddlCurrency.SelectedItem.Value.ToString(), ddlPercentageof.SelectedItem.Value.ToString(), DateTime.Parse(txtUpdateEffectiveFrom.Text), BaseUserID);
                        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "401")
                        {
                            lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                        }
                        else
                        {
                            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                            ChangeScreenDetails();
                        }
                    }
                    //Change Ends
                }
                else
                {
                    lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                    return;
                }
                    
               }
            }
        else
        {
            if (txtAddEffectiveFrom.Text != "")
            {
                if (objCommon.IsValidDate(txtAddEffectiveFrom.Text) != true)
                {
                    lblErrorMsg.Text = Resources.Resource.InvalidDate;
                    txtAddEffectiveFrom.Focus();
                    return;
                }

                if (ddlPercentageValue.SelectedItem.Value.ToString() == "VAL")
                {
                    if (ddlFrequency.SelectedItem.Value.ToString() == "NONE")
                    {
                        lblErrorMsg.Text = "Frequency Cannot Be None Incase of Value. Please Select The Frequency...";
                        return;
                    }

                    if ((txtValue.Text.Length == 0) || (float.Parse(txtValue.Text) <= 0))
                    {
                        lblErrorMsg.Text = "Entered Value Cannot Be Less Than Or Equal To Zero...";
                        return;
                    }

                    if (ddlCurrency.SelectedItem.Value.ToString() == "NONE")
                    {
                        lblErrorMsg.Text = "Currency Cannot Be None Incase of Value. Please Select The Frequency...";
                        return;
                    }
                }
                else
                {
                    if ((txtValue.Text.Length == 0) || (float.Parse(txtValue.Text) <= 0))
                    {
                        lblErrorMsg.Text = "Entered Value Cannot Be Less Than Or Equal To Zero...";
                        return;
                    }

                    if (ddlPercentageof.SelectedItem.Value.ToString() == "NONE")
                    {
                        lblErrorMsg.Text = "PercentageOf Cannot Be None Incase of Percentage. Please Select The Percentage Of...";
                        return;
                    }

                }

                ds = objHRManagement.SaveInAddInsert(BaseCompanyCode, txtEmployeeNumber.Text.ToString(), ddlComponent.SelectedItem.Value.ToString(), ddlPercentageValue.SelectedItem.Value.ToString(), ddlFrequency.SelectedItem.Value.ToString(), decimal.Parse(txtValue.Text).ToString("0.00"), ddlCurrency.SelectedItem.Value.ToString(), ddlPercentageof.SelectedItem.Value.ToString(), DateTime.Parse(txtAddEffectiveFrom.Text), BaseUserID);
                if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "401")
                {
                    lblErrorMsg.Text = ds.Tables[0].Rows[0]["MessageString"].ToString();
                }
                else
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    ChangeScreenDetails();
                }
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.DateFieldsCantBeLeftBlank;
                return;
            }
        }
    }

    /// <summary>
    /// Function called on Drop Down List Component SelectIndexChange Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlComponent_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChangeScreenDetails();
    }

    /// <summary>
    /// Function called on Drop Down List Percentage SelectIndexChange Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlPercentageValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        EnableDisableFields();
    }

    /// <summary>
    /// Function called on Drop Down List CorrectORUpdate SelectIndexChange Event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlSelCorrectORUpdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideControls();
        
    }

    /// <summary>
    /// Function used to Show/Hide Controls.
    /// </summary>
    private void ShowHideControls()
    {
        if (ddlSelCorrectORUpdate.SelectedItem.Value.ToString() == "Correct")
        {
            lblUpdateEffectiveFrom.Visible = false;
            txtUpdateEffectiveFrom.Visible = false;
            ImgUpdateEffectiveFrom.Visible = false;
        }
        else
        {
            lblUpdateEffectiveFrom.Visible = true;
            txtUpdateEffectiveFrom.Visible = true;
            ImgUpdateEffectiveFrom.Visible = true;
        }
    }

    /// <summary>
    /// Function used to fill Frequency Drop Down List.
    /// </summary>
    private void FillRateFrequency()
    {

        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet ds = new DataSet();

        ds = objMastersManagement.RateFrequencyGetAll(BaseCompanyCode);
        ddlFrequency.DataSource = ds;
        ddlFrequency.DataTextField = "WRfDesc";
        ddlFrequency.DataValueField = "WRfCode";
        ddlFrequency.DataBind();

        ListItem li3None = new ListItem();
        li3None = new ListItem();
        li3None.Text = Resources.Resource.NONE;
        li3None.Value = "NONE";
        ddlFrequency.Items.Add(li3None);

        ListItem li3 = new ListItem();
        if (ddlFrequency.Text == "")
        {
            li3 = new ListItem();
            li3.Text = Resources.Resource.NoDataToShow;
            li3.Value = "";
            ddlFrequency.Items.Add(li3);
            DisableButtons();
        }

        ds.Dispose();
    }

    /// <summary>
    /// Function used to fill Currency Drop Down List.
    /// </summary>
    private void FillCurrency()
    {
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ddlCurrency.DataSource = objMastersManagement.CurrencyMasterGetAll();
        ddlCurrency.DataTextField = "CurrencyDesc";
        ddlCurrency.DataValueField = "CurrencyCode";
        ddlCurrency.DataBind();
        ListItem li3None = new ListItem();
        li3None = new ListItem();
        li3None.Text = Resources.Resource.NONE;
        li3None.Value = "NONE";
        ddlCurrency.Items.Add(li3None);

        ListItem li3 = new ListItem();
        if (ddlCurrency.Text == "")
        {
            li3 = new ListItem();
            li3.Text = Resources.Resource.NoDataToShow;
            li3.Value = "";
            ddlCurrency.Items.Add(li3);
            DisableButtons();
        }
    }

    /// <summary>
    /// Function used to get the details based on system parameter.
    /// </summary>
    private void ChangeScreenDetails()
    {
        FillPercentageOf();
        if (txtEmployeeNumber.Text.ToString() != null)
        {
            if (ddlComponent.SelectedItem.Value.ToString() == "ContDays")
            {
                txtValue.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtValue.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }
            else
            {
                txtValue.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
                txtValue.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            }

            DataSet ds = new DataSet();
            BL.HRManagement objHRManagement = new BL.HRManagement();
            ds = objHRManagement.CompensationHistoryGetByComponent(txtEmployeeNumber.Text.ToString(), BaseCompanyCode, ddlComponent.SelectedItem.Value.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Status"].ToString() == "Update")
                {
                    txtStatus.Text = "Modify";

                    ddlPercentageValue.SelectedValue = ds.Tables[0].Rows[0]["PercentageValueType"].ToString();
                    ddlFrequency.SelectedValue = ds.Tables[0].Rows[0]["Frequency"].ToString();
                    if (ddlComponent.SelectedItem.Value.ToString() == "ContDays")
                    {
                        string strContDays = ds.Tables[0].Rows[0]["ComponentValue"].ToString();

                        int ContDays = int.Parse(strContDays.Substring(0, strContDays.IndexOf(".")));

                        txtValue.Text = Convert.ToString(ContDays);

                    }
                    else
                    {
                        txtValue.Text = GetValueAsPerSystemParameters(ds.Tables[0].Rows[0]["ComponentValue"].ToString(), int.Parse(BaseDigitsAfterDecimalPlaces), int.Parse(BaseRoundOffCheck));
                    }
                    ddlCurrency.SelectedValue = ds.Tables[0].Rows[0]["WageCurrencyCode"].ToString();
                    ddlPercentageof.SelectedValue = ds.Tables[0].Rows[0]["PercentageofComponent"].ToString();

                    EnableDisableFields();
                }
                else
                {
                    txtStatus.Text = "Add";
                    EnableDisableFields();
                    FillDefaultEffectiveFromDate();
                    EnableButtons();
                }
            }
            else
            {
                txtStatus.Text = "Add";
                EnableDisableFields();
                FillDefaultEffectiveFromDate();
                EnableButtons();
            }
        }
        else
        {
            DisableButtons();
        }
    }

    /// <summary>
    /// Function used to clear fields.
    /// </summary>
    private void ClearFields()
    {
        txtValue.Text = "";
    }

    #endregion

    /// <summary>
    /////Make Control Non Editable for update Manish 14-06-2012
    /// </summary>
    protected void getAllRecordsNOnEditable()
    {
        var ds = new DataSet();
        BL.Interface objInterface = new BL.Interface();
        ds = objInterface.GetAllRecordsOnScreenNameAndTableName("Employee Master", "mstHrEmployeeCompensationDetail");
        InterfacePage objInterfacePage = new InterfacePage();
        objInterfacePage.ControlsNonEditable(ds, this.Page);
    }

    /// <summary>
    /////Make Control  Editable for Adding new records
    /// </summary>
    protected void getAllRecordsEditable()
    {
        DataSet ds = new DataSet();
        BL.Interface objInterface = new BL.Interface();
        ds = objInterface.GetAllRecordsOnScreenNameAndTableName("Employee Master", "mstHrEmployeeCompensationDetail");
        InterfacePage objInterfacePage = new InterfacePage();
        objInterfacePage.ControlsEditable(ds, this.Page);
    }
}
