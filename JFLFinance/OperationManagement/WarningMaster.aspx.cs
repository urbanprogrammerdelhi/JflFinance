// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="WarningMaster.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class OperationManagement_WarningMaster.
/// </summary>
public partial class OperationManagement_WarningMaster : BasePage//System.Web.UI.Page
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

            
            //Page Title from resource file
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.WarningMaster + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());

            if (IsReadAccess == true)
            {
                txtStatusChgDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                if (IsWriteAccess == true)
                {
                    btnSave.Visible = true;
                }
                btnCancel.Visible = false;
                lblddlAmendNo.Visible = false;
                ddlAmendNo.Visible = false;
                //  txtStatusChgDate.Attributes.Add("readonly", "readonly");
                // txtAmendDate.Attributes.Add("readonly", "readonly");
                //txtAssignNo.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                //txtAssignNo.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtEmployeeID.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtEmployeeID.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionCode + ");";
                txtFinancialImplication.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtFinancialImplication.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtBriefOfProblem.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtBriefOfProblem.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtBriefOfResolution.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                txtBriefOfResolution.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");";
                IMGAmendDate.Visible = false;
                FillddlStatus();
                FillddlReason4Change();
                FillddlComfortStatusOf();
                IMGStatusChgNo.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EWDC_CCH&ControlId=" + txtStatusChgNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                imgAssignSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=ASMTCCH&ControlId=" + txtAssignNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,Height=450,help=no')");
                // IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + "" + "&Location=" + "" + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                IMGEmployeeNumber.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=850,help=no')");

                if (ddlIncidentNo.Text == "")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.Select;
                    li.Value = "0";
                    ddlIncidentNo.Items.Insert(0, li);
                }
                if (ddlMeetingNo.Text == "")
                {
                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.Select;
                    li.Value = "0";
                    ddlIncidentNo.Items.Insert(0, li);
                }
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    /// <summary>
    /// Fillddls the comfort status of.
    /// </summary>
    private void FillddlComfortStatusOf()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        EnableButtons();
        ddlComfortStatusOf.DataSource = objOperationManagement.DamageAndWarningComfortStatusGet(BaseCompanyCode);
        ddlComfortStatusOf.DataTextField = "ItemDesc";
        ddlComfortStatusOf.DataValueField = "ItemCode";
        ddlComfortStatusOf.DataBind();
        if (ddlComfortStatusOf.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoDataToShow;
            li.Value = "0";
            ddlComfortStatusOf.Items.Add(li);
            DisableButtons();
        }
    }
    /// <summary>
    /// Fillddls the reason4 change.
    /// </summary>
    private void FillddlReason4Change()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        EnableButtons();
        ddlReason4Change.DataSource = objOperationManagement.ReasonForChangingDamageAndWarningGet(BaseCompanyCode);
        ddlReason4Change.DataTextField = "ItemDesc";
        ddlReason4Change.DataValueField = "ItemCode";
        ddlReason4Change.DataBind();
        if (ddlReason4Change.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoDataToShow;
            li.Value = "0";
            ddlReason4Change.Items.Add(li);
            DisableButtons();
        }
    }
    /// <summary>
    /// Fillddls the status.
    /// </summary>
    private void FillddlStatus()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        EnableButtons();
        ddlStatus.DataSource = objOperationManagement.DamageAndWarningStatusGet(BaseCompanyCode);
        ddlStatus.DataTextField = "ItemDesc";
        ddlStatus.DataValueField = "ItemCode";
        ddlStatus.DataBind();
        if (ddlStatus.Text == "")
        {
            ListItem li = new ListItem();
            li.Text =  Resources.Resource.NoDataToShow;
            li.Value = "0";
            ddlStatus.Items.Add(li);
            DisableButtons();
        }
        else
        {
            ddlStatus.SelectedIndex = 1;
        }

    }
    /// <summary>
    /// Handles the Click event of the btnAddNew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        txtStatusChgDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        ddlMeetingNo.Items.Clear();
        ddlIncidentNo.Items.Clear();
        txtStatusChgNo.Text = "";
        lblddlAmendNo.Visible = false;
        ddlAmendNo.Visible = false;
        EnableFields();
        ClearFields();
        HideButtons();
        btnSave.Visible = true;
        btnCancel.Visible = false;
        lblWarningDamageStatus.Text = "";
        IMGAmendDate.Visible = false;
    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strMeetingNumber;
        string strIncidentNumber;
        lblWarningDamageStatus.Text = Resources.Resource.Fresh;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        int AmendNo = 0;
        if (DateTime.Parse(txtStatusChgDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
        {
            txtStatusChgDate.BackColor = System.Drawing.Color.Empty;
            if (ddlMeetingNo.SelectedValue.ToString() == "0")
            {
                strMeetingNumber = "";
            }
            else
            {
                strMeetingNumber = ddlMeetingNo.SelectedValue.ToString();
            }
            if (ddlIncidentNo.SelectedValue.ToString() == "0")
            {
                strIncidentNumber = "";
            }
            else
            {
                strIncidentNumber = ddlIncidentNo.SelectedValue.ToString();
            }
            ds = objOperationManagement.DamageAndWarningInsert(DateTime.Parse(txtStatusChgDate.Text), ddlStatus.SelectedValue.ToString(), txtAssignNo.Text, strMeetingNumber, ddlReason4Change.SelectedValue.ToString(), ddlComfortStatusOf.SelectedValue.ToString(), strIncidentNumber, txtEmployeeID.Text, txtFinancialImplication.Text, txtBriefOfProblem.Text, txtBriefOfResolution.Text, BaseLocationAutoID, BaseUserID, AmendNo, lblWarningDamageStatus.Text, txtInvestigationStatus.Text);
            DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
                {
                    btnAuthorize.Visible = true;
                    btnAddNew.Visible = true;
                    txtStatusChgNo.Text = ds.Tables[0].Rows[0]["WDControlNo"].ToString();
                    FillddlAmendNo(txtStatusChgNo.Text);
                    ddlAmendNo.Visible = true;
                    lblddlAmendNo.Visible = true;
                    btnSave.Visible = false;
                    DisableFields();
                }
            }
        }
        else
        {
            lblErrorMsg.Text = "Status Change Date Should Always be greater than or equal to the assignment start date";
            txtStatusChgDate.BackColor = System.Drawing.Color.Aqua;
            ToolkitScriptManager2.SetFocus(txtStatusChgDate);
        }

    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string strMeetingNumber;
        string strIncidentNumber;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        if (DateTime.Parse(txtStatusChgDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
        {
            txtStatusChgDate.BackColor = System.Drawing.Color.Empty;

            if (txtAmendDate.Text != "")
            {
                txtAmendDate.BackColor = System.Drawing.Color.Empty;
                if (DateTime.Parse(txtAmendDate.Text) >= DateTime.Parse(txtStatusChgDate.Text))
                {
                    if (ddlMeetingNo.SelectedValue.ToString() == "0")
                    {
                        strMeetingNumber = "";
                    }
                    else
                    {
                        strMeetingNumber = ddlMeetingNo.SelectedValue.ToString();
                    }
                    if (ddlIncidentNo.SelectedValue.ToString() == "0")
                    {
                        strIncidentNumber = "";
                    }
                    else
                    {
                        strIncidentNumber = ddlIncidentNo.SelectedValue.ToString();
                    }
                    txtStatusChgDate.BackColor = System.Drawing.Color.Empty;
                    ds = objOperationManagement.DamageAndWarningUpdate(txtStatusChgNo.Text, DateTime.Parse(txtStatusChgDate.Text), ddlStatus.SelectedValue.ToString(), txtAssignNo.Text, strMeetingNumber, ddlReason4Change.SelectedValue.ToString(), ddlComfortStatusOf.SelectedValue.ToString(), strIncidentNumber, txtEmployeeID.Text, txtFinancialImplication.Text, txtBriefOfProblem.Text, txtBriefOfResolution.Text, BaseLocationAutoID, BaseUserID, int.Parse(ddlAmendNo.SelectedValue.ToString()), lblWarningDamageStatus.Text, DateTime.Parse(txtAmendDate.Text), txtInvestigationStatus.Text);
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                    DisableFields();
                    HideButtonsBasedOnStatus();
                }
                else
                {
                    // this.ToolkitScriptManager2.SetFocus(txtStatusChgDate);
                    txtStatusChgDate.BackColor = System.Drawing.Color.Aqua;
                    lblErrorMsg.Text = Resources.Resource.AmendmentDateShouldbeGreaterThanorEqualStatusChangeDate;
                }
            }
            else
            {
                ToolkitScriptManager2.SetFocus(txtAmendDate);
                txtAmendDate.BackColor = System.Drawing.Color.Aqua;
                lblErrorMsg.Text = Resources.Resource.AmendmentDateRequired;
            }
        }
        else
        {
            lblErrorMsg.Text = "Status Change Date Should Always be greater than or equal to the assignment start date";
            txtStatusChgDate.BackColor = System.Drawing.Color.Aqua;
            ToolkitScriptManager2.SetFocus(txtStatusChgDate);
        }
    }
    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        FillDetail(int.Parse(ddlAmendNo.SelectedItem.Text));
        HideButtonsBasedOnStatus();
        DisableFields();
    }
    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        string strMeetingNumber;
        string strIncidentNumber;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        if (DateTime.Parse(txtStatusChgDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
        {
            txtStatusChgDate.BackColor = System.Drawing.Color.Empty;
            if (ddlMeetingNo.SelectedValue.ToString() == "0")
            {
                strMeetingNumber = "";
            }
            else
            {
                strMeetingNumber = ddlMeetingNo.SelectedValue.ToString();
            }
            if (ddlIncidentNo.SelectedValue.ToString() == "0")
            {
                strIncidentNumber = "";
            }
            else
            {
                strIncidentNumber = ddlIncidentNo.SelectedValue.ToString();
            }
            // ds = objOperationManagement.blDamageAndWarning_Authorize(txtStatusChgNo.Text, DateTime.Parse(txtStatusChgDate.Text), ddlStatus.SelectedValue.ToString(), txtAssignNo.Text, strMeetingNumber, ddlReason4Change.SelectedValue.ToString(), ddlComfortStatusOf.SelectedValue.ToString(), strIncidentNumber, txtEmployeeID.Text, txtFinancialImplication.Text, txtBriefOfProblem.Text, txtBriefOfResolution.Text, BaseLocationAutoID, BaseUserID, int.Parse(ddlAmendNo.SelectedValue.ToString()), Resources.Resource.Authorized, CheckDateNull(txtAmendDate.Text), txtInvestigationStatus.Text);
            ds = objOperationManagement.DamageAndWarningAuthorize(BaseUserID, int.Parse(ddlAmendNo.SelectedValue.ToString()), Resources.Resource.Authorized, txtStatusChgNo.Text);
            if (GetSuccessResult(int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString())) == true)
            {
                btnAmend.Visible = true;
                lblWarningDamageStatus.Text = Resources.Resource.Authorized;
                btnAuthorize.Visible = false;
                IMGAmendDate.Visible = true;
                lblAmendDate.Visible = true;
                txtAmendDate.Visible = true;
                FillDetailBasedOnWarningNo(sender, e);
                HideButtonsBasedOnStatus();

            }
        }
        else
        {
            lblErrorMsg.Text = "Status Change Date Should Always be greater than or equal to the assignment start date";
            txtStatusChgDate.BackColor = System.Drawing.Color.Aqua;
            ToolkitScriptManager2.SetFocus(txtStatusChgDate);
        }

    }
    /// <summary>
    /// Handles the Click event of the btnAmend control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAmend_Click(object sender, EventArgs e)
    {
        string strMeetingNumber;
        string strIncidentNumber;
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (DateTime.Parse(txtStatusChgDate.Text) >= DateTime.Parse(hfAsmtStartDate.Value))
        {
            txtStatusChgDate.BackColor = System.Drawing.Color.Empty;
            if (txtAmendDate.Text != "")
            {
                txtAmendDate.BackColor = System.Drawing.Color.Empty;
                if (DateTime.Parse(txtAmendDate.Text) >= DateTime.Parse(txtStatusChgDate.Text))
                {
                    int AmendNo = GetMaxAmendNo();
                    AmendNo = AmendNo + 1;
                    if (ddlMeetingNo.SelectedValue.ToString() == "0")
                    {
                        strMeetingNumber = "";
                    }
                    else
                    {
                        strMeetingNumber = ddlMeetingNo.SelectedValue.ToString();
                    }
                    if (ddlIncidentNo.SelectedValue.ToString() == "0")
                    {
                        strIncidentNumber = "";
                    }
                    else
                    {
                        strIncidentNumber = ddlIncidentNo.SelectedValue.ToString();
                    }
                    txtStatusChgDate.BackColor = System.Drawing.Color.Empty;
                    ds = objOperationManagement.DamageAndWarningAmend(txtStatusChgNo.Text, DateTime.Parse(txtStatusChgDate.Text), ddlStatus.SelectedValue.ToString(), txtAssignNo.Text, strMeetingNumber, ddlReason4Change.SelectedValue.ToString(), ddlComfortStatusOf.SelectedValue.ToString(), strIncidentNumber, txtEmployeeID.Text, txtFinancialImplication.Text, txtBriefOfProblem.Text, txtBriefOfResolution.Text, BaseLocationAutoID, BaseUserID, AmendNo, Resources.Resource.Amend, DateTime.Parse(txtAmendDate.Text), txtInvestigationStatus.Text);
                    btnAmend.Visible = false;
                    lblWarningDamageStatus.Text = Resources.Resource.Amend;
                    FillddlAmendNo(txtStatusChgNo.Text);

                    HideButtonsBasedOnStatus();
                    //DisableFields();
                }
                else
                {
                    ToolkitScriptManager2.SetFocus(txtStatusChgDate);
                    txtStatusChgDate.BackColor = System.Drawing.Color.Aqua;
                    lblErrorMsg.Text = Resources.Resource.AmendmentDateShouldbeGreaterThanorEqualStatusChangeDate;
                }
            }
            else
            {
                ToolkitScriptManager2.SetFocus(txtAmendDate);
                txtAmendDate.BackColor = System.Drawing.Color.Aqua;
                lblErrorMsg.Text = Resources.Resource.AmendmentDateRequired;
            }
        }
        else
        {
            lblErrorMsg.Text = "Status Change Date Should Always be greater than or equal to the assignment start date";
            ToolkitScriptManager2.SetFocus(txtStatusChgDate);
            txtStatusChgDate.BackColor = System.Drawing.Color.Aqua;
        }
    }
    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        btnEdit.Visible = false;
        btnUpdate.Visible = true;
        btnCancel.Visible = true;
        if (ddlAmendNo.Text != "")
        {
            FillDetail(int.Parse(ddlAmendNo.SelectedValue.ToString()));
        }
        // FillddlIncidentNumber();
        //  FillddlMeetingNumber();
        EnableFields();
        btnAuthorize.Visible = false;
    }
    /// <summary>
    /// Handles the TextChanged event of the txtStatusChgNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtStatusChgNo_TextChanged(object sender, EventArgs e)
    {

        FillDetailBasedOnWarningNo(sender, e);
        //try
        //{
        //    int MaxAmendNo = GetMaxAmendNo();
        //    FillDetail(MaxAmendNo);
        //    FillddlAmendNo(txtStatusChgNo.Text);
        //    if (lblWarningDamageStatus.Text == Resources.Resource.Fresh)
        //    {
        //        EnableFields();
        //    }
        //    else
        //    {
        //        DisableFields();
        //    }
        //    lblddlAmendNo.Visible = true;
        //    ddlAmendNo.Visible = true;
        //    txtAssignNo_TextChanged(sender, e);
        //    txtEmployeeID_TextChanged(sender, e);
        //    FillDetail(int.Parse(ddlAmendNo.SelectedValue.ToString()));
        //    HideButtonsBasedOnStatus();
        //}
        //catch (Exception)
        //{
        //    lblErrorMsg.Text = "No Data to Show";
        //}

    }
    /// <summary>
    /// Fills the detail based on warning no.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void FillDetailBasedOnWarningNo(object sender, EventArgs e)
    {
        try
        {
            int MaxAmendNo = GetMaxAmendNo();
            FillDetail(MaxAmendNo);
            FillddlAmendNo(txtStatusChgNo.Text);
            if (lblWarningDamageStatus.Text == Resources.Resource.Fresh)
            {
                EnableFields();
            }
            else
            {
                DisableFields();
            }
            lblddlAmendNo.Visible = true;
            ddlAmendNo.Visible = true;

            //  FillDetail(int.Parse(ddlAmendNo.SelectedValue.ToString()));
            HideButtonsBasedOnStatus();
        }
        catch (Exception)
        {
            lblErrorMsg.Text = "No Data to Show";
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtAssignNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAssignNo_TextChanged(object sender, EventArgs e)
    {
        FillAsmtDetails();
        FillddlMeetingNumber();
        FillddlIncidentNumber();
    }
    /// <summary>
    /// Fillddls the incident number.
    /// </summary>
    private void FillddlIncidentNumber()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ListItem li = new ListItem();
        ds = objOperationManagement.IncidentGetAll(txtAssignNo.Text, BaseLocationAutoID, BaseCompanyCode, Resources.Resource.Authorized);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0 && ds != null)
        {
            ddlIncidentNo.DataSource = ds;
            ddlIncidentNo.DataTextField = "IncidentNumber";
            ddlIncidentNo.DataValueField = "IncidentNumber";
            ddlIncidentNo.DataBind();
            if (ddlIncidentNo.SelectedValue.ToString() != "0")
            {
                if (hfIncidentNumber.Value != "")
                {
                    ddlIncidentNo.SelectedValue = hfIncidentNumber.Value;
                    txtIncidentType.Text = ds.Tables[0].Rows[0]["ItemDesc"].ToString();
                }
                else
                {
                    ddlIncidentNo.SelectedIndex = 0;
                    txtIncidentType.Text = "";
                }
            }
            else
            {
                ddlIncidentNo.SelectedIndex = 0;
                txtIncidentType.Text = "";
            }
            if (ddlIncidentNo.Text == "")
            {
                if (ddlIncidentNo.SelectedValue.ToString() == "0")
                {
                    ddlIncidentNo.Items.RemoveAt(0);
                }
                else
                {

                    li.Text = Resources.Resource.Select;
                    li.Value = "0";
                    ddlIncidentNo.Items.Insert(0, li);
                    ddlIncidentNo.SelectedIndex = 0;
                }

            }
            else
            {
                if (ddlIncidentNo.SelectedValue.ToString() == "0")
                {
                    ddlIncidentNo.Items.RemoveAt(0);
                }
                else
                {
                    li.Text = "Select";
                    li.Value = "0";
                    ddlIncidentNo.Items.Insert(0, li);
                    ddlIncidentNo.SelectedIndex = 0;
                }
            }
        }
        else
        {
            if (ddlIncidentNo.SelectedValue.ToString() == "0")
            {
                ddlIncidentNo.Items.RemoveAt(0);
            }
            else
            {
                li.Text = "Select";
                li.Value = "0";
                ddlIncidentNo.Items.Insert(0, li);
                txtIncidentType.Text = "";
            }
        }
        FilltxtInvestigationStatus();
    }
    /// <summary>
    /// Filltxts the investigation status.
    /// </summary>
    private void FilltxtInvestigationStatus()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.InvestigationStatusGet(ddlIncidentNo.SelectedValue.ToString(), BaseLocationAutoID, Resources.Resource.Authorized);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["InvStatus"].ToString() == "0")
            {
                txtInvestigationStatus.Text = Resources.Resource.Pending;
            }
            else if (ds.Tables[0].Rows[0]["InvStatus"].ToString() == "1")
            {
                txtInvestigationStatus.Text = Resources.Resource.Completed;
            }
        }
        else
        {
            txtInvestigationStatus.Text = Resources.Resource.NotRequested;
        }
    }
    /// <summary>
    /// Fillddls the meeting number.
    /// </summary>
    private void FillddlMeetingNumber()
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        //if (hfMeetingNumber.Value != "")
        //{
        ds = objOperationManagement.MeetingNumberGet(txtAssignNo.Text, BaseLocationAutoID, Resources.Resource.Authorized);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["MeetingNumber"].ToString() != "")
            {
                ddlMeetingNo.DataSource = ds;
                ddlMeetingNo.DataTextField = "MeetingNumber";
                ddlMeetingNo.DataValueField = "MeetingNumber";
                ddlMeetingNo.DataBind();

                if (ddlMeetingNo.Text == "")
                {
                    if (ddlMeetingNo.SelectedValue.ToString() == "0")
                    {
                        ddlMeetingNo.Items.RemoveAt(0);
                    }
                    else
                    {
                        ListItem li = new ListItem();
                        li.Text = "Select";
                        li.Value = "0";
                        ddlMeetingNo.Items.Insert(0, li);
                    }
                }
                else
                {
                    if (ddlMeetingNo.SelectedValue.ToString() == "0")
                    {
                        ddlMeetingNo.Items.RemoveAt(0);
                    }
                    else
                    {
                        ListItem li1 = new ListItem();
                        li1.Text = "Select";
                        li1.Value = "0";
                        ddlMeetingNo.Items.Insert(0, li1);
                    }
                }
            }
        }
        else
        {
            if (ddlMeetingNo.SelectedValue.ToString() == "0")
            {
                ddlMeetingNo.Items.RemoveAt(0);
            }
            else
            {
                ListItem li = new ListItem();
                li.Text = "Select";
                li.Value = "0";
                ddlMeetingNo.Items.Add(li);
            }
        }
        //ddlMeetingNo.SelectedValue = "0";
        //}
        //else
        //{
        //    ListItem li = new ListItem();
        //    li.Text =  Resources.Resource.NoDataToShow;
        //    li.Value = "0";
        //    ddlMeetingNo.Items.Add(li);
        //}
    }
    /// <summary>
    /// Handles the TextChanged event of the txtEmployeeID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeID_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeID.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                txtEmployeeID.BackColor = System.Drawing.Color.Empty;
                EnableButtons();
                txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
                ToolkitScriptManager2.SetFocus(txtFinancialImplication);
            }
            else
            {
                DisableButtons();
                txtEmployeeName.Text = "";
                txtDesignation.Text = "";
                lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
                ToolkitScriptManager2.SetFocus(txtEmployeeID);
                txtEmployeeID.BackColor = System.Drawing.Color.Aqua;
            }
        }
    }
    /// <summary>
    /// Fills the asmt details.
    /// </summary>
    private void FillAsmtDetails()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ds = objOperationManagement.AsmtIncidentDetailGet(txtCustomerID.Text,txtAssignNo.Text, BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0 && ds != null)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                txtAssignNo.BackColor = System.Drawing.Color.Empty;
                EnableButtons();
                txtCustomerID.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                txtAddressID.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                txtAddressDesc.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
                hfAsmtStartDate.Value = ds.Tables[0].Rows[0]["AsmtStartDate"].ToString();
                ToolkitScriptManager2.SetFocus(ddlMeetingNo);
            }
            else
            {
                ToolkitScriptManager2.SetFocus(txtAssignNo);
                txtAssignNo.BackColor = System.Drawing.Color.Aqua;
                lblErrorMsg.Text = Resources.Resource.NoDataToShow;
                DisableButtons();
            }

        }
        else
        {
            ToolkitScriptManager2.SetFocus(txtAssignNo);
            txtAssignNo.BackColor = System.Drawing.Color.Aqua;
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            DisableButtons();
        }
    }
    /// <summary>
    /// Clears the fields.
    /// </summary>
    private void ClearFields()
    {
        txtAddressDesc.Text = "";
        txtAddressID.Text = "";
        txtAmendDate.Text = "";
        txtAreaDesc.Text = "";
        txtAreaID.Text = "";
        txtAssignNo.Text = "";
        txtBriefOfProblem.Text = "";
        txtBriefOfResolution.Text = "";
        txtCustomerDesc.Text = "";
        txtCustomerID.Text = "";
        txtDesignation.Text = "";
        txtEmployeeID.Text = "";
        txtEmployeeName.Text = "";
        txtIncidentType.Text = "";
        txtInvestigationStatus.Text = "";
        txtStatusChgDate.Text = "";
        txtFinancialImplication.Text = "";
        //txtStatusChgNo.Text = "";
    }
    /// <summary>
    /// Disables the buttons.
    /// </summary>
    private void DisableButtons()
    {
        btnAddNew.Enabled = false;
        btnAmend.Enabled = false;
        btnAuthorize.Enabled = false;
        btnCancel.Enabled = false;
        btnSave.Enabled = false;
        btnUpdate.Enabled = false;
        btnEdit.Enabled = false;
    }
    /// <summary>
    /// Enables the buttons.
    /// </summary>
    private void EnableButtons()
    {
        btnAddNew.Enabled = true;
        btnAmend.Enabled = true;
        btnAuthorize.Enabled = true;
        btnCancel.Enabled = true;
        btnSave.Enabled = true;
        btnUpdate.Enabled = true;
        btnEdit.Enabled = true;
    }
    /// <summary>
    /// Fillddls the amend no.
    /// </summary>
    /// <param name="strWDControlNo">The string wd control no.</param>
    private void FillddlAmendNo(string strWDControlNo)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ddlAmendNo.DataSource = objOperationManagement.DamageAndWarningAmendNumberGet(strWDControlNo);
        ddlAmendNo.DataTextField = "WDAmendNo";
        ddlAmendNo.DataValueField = "WDAmendNo";
        ddlAmendNo.DataBind();
        if (ddlAmendNo.Text == "")
        {

        }

    }
    /// <summary>
    /// Disables the fields.
    /// </summary>
    private void DisableFields()
    {
        // txtStatusChgNo.Enabled = false;
        txtAssignNo.Enabled = false;
        IMGAmendDate.Visible = false;
        IMGStatusChgDate.Visible = false;
        ddlStatus.Enabled = false;
        ddlReason4Change.Enabled = false;
        ddlComfortStatusOf.Enabled = false;
        txtEmployeeID.Enabled = false;
        txtFinancialImplication.Enabled = false;
        txtBriefOfProblem.Enabled = false;
        txtBriefOfResolution.Enabled = false;
        ddlIncidentNo.Enabled = false;
        ddlMeetingNo.Enabled = false;
        txtAmendDate.Enabled = false;
        txtStatusChgDate.Enabled = false;


    }
    /// <summary>
    /// Enables the fields.
    /// </summary>
    private void EnableFields()
    {
        //txtStatusChgNo.Enabled = true;
        txtAssignNo.Enabled = true;
        IMGAmendDate.Visible = true;
        txtAmendDate.Visible = true;
        lblAmendDate.Visible = true;
        IMGStatusChgDate.Visible = true;
        ddlStatus.Enabled = true;
        ddlReason4Change.Enabled = true;
        ddlComfortStatusOf.Enabled = true;
        txtEmployeeID.Enabled = true;
        txtFinancialImplication.Enabled = true;
        txtBriefOfProblem.Enabled = true;
        txtBriefOfResolution.Enabled = true;
        ddlIncidentNo.Enabled = true;
        ddlMeetingNo.Enabled = true;
        txtAmendDate.Enabled = true;
        txtStatusChgDate.Enabled = true;
    }
    /// <summary>
    /// Hides the buttons.
    /// </summary>
    private void HideButtons()
    {
        btnAddNew.Visible = false;
        btnAmend.Visible = false;
        btnAuthorize.Visible = false;
        btnCancel.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnEdit.Visible = false;
    }
    /// <summary>
    /// Shows the buttons.
    /// </summary>
    private void ShowButtons()
    {
        btnAddNew.Visible = true;
        btnAmend.Visible = true;
        btnAuthorize.Visible = true;
        btnCancel.Visible = true;
        btnSave.Visible = true;
        btnUpdate.Visible = true;
        btnEdit.Visible = false;
    }
    /// <summary>
    /// Gets the maximum amend no.
    /// </summary>
    /// <returns>System.Int32.</returns>
    private int GetMaxAmendNo()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.DamageAndWarningMaximumAmendNumberGet(txtStatusChgNo.Text);
        if (ds.Tables[0].Rows[0]["WDAmendNo"].ToString() != "")
        {
            return int.Parse(ds.Tables[0].Rows[0]["WDAmendNo"].ToString());
        }
        else
        {
            return 0;
        }

    }
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlAmendNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlAmendNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisableFields();
        FillddlIncidentNumber();
        FillddlMeetingNumber();
        FillDetail(int.Parse(ddlAmendNo.SelectedValue.ToString()));
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        ds = objOperationManagement.DamageAndWarningMaximumAmendNumberGet(txtStatusChgNo.Text);
        if (int.Parse(ds.Tables[0].Rows[0]["WDAmendNo"].ToString()) != int.Parse(ddlAmendNo.SelectedValue.ToString()))
        {
            HideButtons();
        }
        else
        {

            HideButtonsBasedOnStatus();
        }
    }
    /// <summary>
    /// Fills the detail.
    /// </summary>
    /// <param name="AmendNo">The amend no.</param>
    private void FillDetail(int AmendNo)
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        object sender = new object();
        EventArgs e = new EventArgs();
        ds = objOperationManagement.DamageAndWarningDetailGet(AmendNo, txtStatusChgNo.Text);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != null)
        {
            txtStatusChgDate.Text = ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["StatusChangeDate"].ToString()));
            txtAmendDate.Text = ConvertDateToNull(CheckDateNull(ds.Tables[0].Rows[0]["AmendmentDate"].ToString()));
            ddlStatus.SelectedValue = (ds.Tables[0].Rows[0]["Status"].ToString());
            txtAssignNo.Text = (ds.Tables[0].Rows[0]["AsmtCode"].ToString());

            txtAssignNo_TextChanged(sender, e);
            
            if (ds.Tables[0].Rows[0]["MeetingNo"].ToString() != "")
            {
                ddlMeetingNo.SelectedValue = (ds.Tables[0].Rows[0]["MeetingNo"].ToString());
                hfMeetingNumber.Value = ds.Tables[0].Rows[0]["MeetingNo"].ToString();
            }
            else
            {
                if (ddlMeetingNo.SelectedValue.ToString() == "0")
                {
                    // ddlMeetingNo.Items.RemoveAt(0);
                }
                else
                {
                    ListItem li1 = new ListItem();
                    li1.Text = "Select";
                    li1.Value = "0";
                    ddlMeetingNo.Items.Insert(0, li1);
                    hfMeetingNumber.Value = "0";
                }
            }
            ddlReason4Change.SelectedValue = (ds.Tables[0].Rows[0]["ReasonForChange"].ToString());
            ddlComfortStatusOf.SelectedValue = (ds.Tables[0].Rows[0]["ComfortStatus"].ToString());
            if (ds.Tables[0].Rows[0]["IncidentNo"].ToString() != "")
            {
                ddlIncidentNo.SelectedValue = (ds.Tables[0].Rows[0]["IncidentNo"].ToString());
                hfIncidentNumber.Value = ds.Tables[0].Rows[0]["IncidentNo"].ToString();
            }
            else
            {
                if (ddlIncidentNo.SelectedValue.ToString() == "0")
                {
                    ddlIncidentNo.SelectedIndex = 0;
                    // ddlIncidentNo.Items.RemoveAt(0);
                }
                else
                {
                    ListItem li1 = new ListItem();
                    li1.Text = "Select";
                    li1.Value = "0";
                    ddlIncidentNo.Items.Insert(0, li1);
                    hfIncidentNumber.Value = "0";
                }
            }
            txtEmployeeID.Text = (ds.Tables[0].Rows[0]["EnteredBy"].ToString());
            txtEmployeeID_TextChanged(sender, e);
            txtFinancialImplication.Text = (ds.Tables[0].Rows[0]["FinancialImplication"].ToString());
            txtBriefOfProblem.Text = (ds.Tables[0].Rows[0]["BriefOfProblem"].ToString());
            txtBriefOfResolution.Text = (ds.Tables[0].Rows[0]["BriefOfResolution"].ToString());
            lblWarningDamageStatus.Text = ds.Tables[0].Rows[0]["WDStatus"].ToString();
        }
        else
        {
            ClearFields();
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
        }

    }
    /// <summary>
    /// Hides the buttons based on status.
    /// </summary>
    private void HideButtonsBasedOnStatus()
    {
        HideButtons();
        if (lblWarningDamageStatus.Text == Resources.Resource.Authorized)
        {
            DisableFields();
            int flag = 0;
            lblAmendDate.Visible = true;
            txtAmendDate.Visible = true;
            IMGAmendDate.Visible = true;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnAmend.Visible = true;
                txtAmendDate.Visible = true;
                lblAmendDate.Visible = true;
                IMGAmendDate.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnAmend.Visible = true;
                }
            }
        }

        if (lblWarningDamageStatus.Text == Resources.Resource.Amend)
        {
            int flag = 0;
            EnableFields();
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnAuthorize.Visible = true;
                btnUpdate.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnAuthorize.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
        }
        if (lblWarningDamageStatus.Text == Resources.Resource.Fresh)
        {
            int flag = 0;
            if (IsWriteAccess == true && IsModifyAccess == true && IsDeleteAccess == true)
            {
                btnAddNew.Visible = true;
                btnAuthorize.Visible = true;
                btnUpdate.Visible = true;
                flag = 1;
            }
            if (flag == 0)
            {
                if (IsWriteAccess == true)
                {
                    btnAddNew.Visible = true;
                }
                if (IsModifyAccess == true)
                {
                    btnAuthorize.Visible = true;
                    btnUpdate.Visible = true;
                }
            }
        }
    }
    #region Function to Convert date to null if date=01/01/0001
    /// <summary>
    /// Converts the date to null.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>System.String.</returns>
    private string ConvertDateToNull(string date)
    {
        string strDate = "01/01/0001";
        if ((DateTime.Parse(date)) == (DateTime.Parse(strDate)))
        {
            return null;
        }
        else
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(date);
            string formatedDate = dt.ToString("d-MMM-yyyy");
            return formatedDate;
        }
    }
    #endregion
    #region Function to check whether date is null or not
    /// <summary>
    /// Checks the date null.
    /// </summary>
    /// <param name="strDate">The string date.</param>
    /// <returns>System.String.</returns>
    private string CheckDateNull(string strDate)
    {
        if (strDate == "")
        {
            DateTime dt = Convert.ToDateTime(null);
            return dt.ToString();
        }
        else
        {
            return strDate;
        }
    }
    #endregion
    /// <summary>
    /// Handles the SelectedIndexChanged event of the ddlIncidentNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void ddlIncidentNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.IncidentTypeGet(ddlIncidentNo.SelectedValue.ToString(), BaseLocationAutoID, BaseCompanyCode);
        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            // hfIncidentNumber.Value = "0";
            if (ddlIncidentNo.SelectedValue.ToString() != "0")
            {
                txtIncidentType.Text = ds.Tables[0].Rows[0]["ItemDesc"].ToString();
                FilltxtInvestigationStatus();
                // FillddlIncidentNumber();
            }
            else
            {
                txtIncidentType.Text = "";
            }
        }
        else
        {
            txtIncidentType.Text = "";
        }

    }
    /// <summary>
    /// Handles the TextChanged event of the txtStatusChgDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtStatusChgDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtStatusChgDate,lblErrorMsg );
    }
    /// <summary>
    /// Handles the TextChanged event of the txtAmendDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAmendDate_TextChanged(object sender, EventArgs e)
    {
        ConvertStringToDateFormat(txtAmendDate,lblErrorMsg );
    }
    
}
