// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="IncidentTracking.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;

/// <summary>
/// Class OperationManagement_IncidentTracking.
/// </summary>
public partial class OperationManagement_IncidentTracking : BasePage//System.Web.UI.Page
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
    /// <summary>
    /// Returns User Authorization Rights.
    /// </summary>
    /// <value><c>true</c> if this instance is authorization access; otherwise, <c>false</c>.</value>
    /// <exception cref="System.Exception">Have not Rights</exception>
    private bool IsAuthorizationAccess
    {
        get
        {
            try
            {
                BasePage bp = new BasePage();
                int VirtualDirNameLenght = 0;
                VirtualDirNameLenght = int.Parse(System.Web.HttpContext.Current.Request.Url.AbsolutePath.IndexOf(@"/", 1).ToString());
                return bp.IsAuthorizationAllowed(System.Web.HttpContext.Current.Request.Url.AbsolutePath.Remove(0, VirtualDirNameLenght));
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
        if (!Page.IsPostBack)
        {
            if (IsReadAccess == true)
            {               
                
                //Page Title from resource file
                System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
                javaScript.Append("<script type='text/javascript'>");
                javaScript.Append("window.document.body.onload = function ()");
                javaScript.Append("{\n");
                javaScript.Append("PageTitle('" + Resources.Resource.IncidentTracking + "');");
                javaScript.Append("};\n");
                javaScript.Append("// -->\n");
                javaScript.Append("</script>");
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());
                hideshowButton("");
                enabledisableField("");
                // imgIncSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=INCIDENTCCH&ControlId=" + txtIncidentNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                imgIncSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=INCIDENTCCH&ControlId=" + txtIncidentNo.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,Height=450,help=no')");
                // imgEmpSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=EMPCCH&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=" + BaseLocationCode.ToString() + "',null,'status=off,center=yes,scrollbars=1,resizeable=1,Width=700px,Height=350,help=no')");
                imgEmpSearch.Attributes.Add("onClick", "window.open('../search/commonSearch.aspx?SearchId=CCH01&ControlId=" + txtEmployeeID.ClientID.ToString() + "&Company=" + BaseCompanyCode.ToString() + "&HrLocation=" + BaseHrLocationCode.ToString() + "&Location=',null,'status=off,center=yes,scrollbars=0,resizeable=1,Width=850px,help=no')");
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    /// <summary>
    /// Clears the fields.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    private void ClearFields(string strParam)
    {
        if (strParam == "")
        {
            lblStatus.Text = "";
            txtIncidentNo.Text = "";
            txtIncidentTrackingDt.Text = "";
            txtAssignNo.Text = "";
            txtIncidentNo.Text = "";
            txtIncidentType.Text = "";
            txtCustomerID.Text = "";
            txtCustomerDesc.Text = "";
            txtAddressID.Text = "";
            txtAddressDesc.Text = "";
            txtAreaID.Text = "";
            txtAreaDesc.Text = "";
            txtNatureofInc.Text = "";
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtEmpDesignation.Text = "";
            txtDetails.Text = "";
            txtReportedDate.Text = "";
            txtTimeFrom.Text = "";
            txtIncStatus.Text = "";
            txtActionTaken.Text = "";
        }
    }
    /// <summary>
    /// Hideshows the button.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    private void hideshowButton(string strParam)
    {
        if (strParam == "RESET")
        {
            btnAuthorize.Visible = false;
            btnEdit.Visible = false;
            btnUpdate.Visible = false ;
            //btnAddNew.Visible = true;
            if (IsWriteAccess == true)
            {
                btnReset.Visible = true;
                btnSave.Visible = true;
            }
            else
            {
                btnReset.Visible = false;
                btnSave.Visible = false;
            }
        }
        else
        {
            if (lblStatus.Text == Resources.Resource.Fresh)
            {
                if (IsAuthorizationAccess == true)
                {
                    btnAuthorize.Visible = true;
                }
                else
                {
                    btnAuthorize.Visible = false;
                }
                if (IsModifyAccess == true)
                {
                    btnUpdate.Visible = true;
                }
                btnEdit.Visible = false;
                //btnAddNew.Visible = true;
                btnReset.Visible = true;
                btnSave.Visible = false;
            }
            else if (lblStatus.Text == Resources.Resource.Amend)
            {
                if (IsAuthorizationAccess == true)
                {
                    btnAuthorize.Visible = true;
                }
                else
                {
                    btnAuthorize.Visible = false;
                }
                btnEdit.Visible = false;
                if (IsModifyAccess == true)
                {
                    btnUpdate.Visible = true;
                }
                //btnAddNew.Visible = true;
                btnReset.Visible = true;
                btnSave.Visible = false;
               
            }
            else if (lblStatus.Text == Resources.Resource.Authorized)
            {
                //if (IsAuthorizationAccess == true)
                //{
                //    btnAuthorize.Visible = true;
                //}
                //else
                //{
                //    btnAuthorize.Visible = false;
                //}
                if (IsModifyAccess == true)
                {
                    btnEdit.Visible = true;
                }
                btnUpdate.Visible = false;
                //btnAddNew.Visible = true;
                btnReset.Visible = true;
                btnSave.Visible = false;
                btnAuthorize.Visible = false;
            }
            else
            {
                btnAuthorize.Visible = false;
                btnEdit.Visible = false;
                btnUpdate.Visible = false;
                //btnAddNew.Visible = true;
                btnReset.Visible = true;
                if (IsModifyAccess == true)
                {
                    btnSave.Visible = true;
                }
            }
        }
    }
    /// <summary>
    /// Enabledisables the field.
    /// </summary>
    /// <param name="strParam">The string parameter.</param>
    private void enabledisableField(string strParam)
    {
        if (strParam == "RESET")
        {
            txtIncidentNo.Enabled = true;
            txtIncidentTrackingDt.Enabled = true;
            txtAssignNo.Enabled = false;
            txtIncidentType.Enabled = false;
            txtNatureofInc.Enabled = false;
            txtEmployeeID.Enabled = true;
            txtEmployeeName.Enabled = false;
            txtEmpDesignation.Enabled = false;
            //Commented by  on 5-Apr-2013
            //txtReportedDate.Enabled = true;
            txtTimeFrom.Enabled = true;
            txtIncStatus.Enabled = true;
            txtActionTaken.Enabled = true;
            imgEmpSearch.Enabled = true;
            imgIncSearch.Enabled = true;
        }
        else
        {
            if (lblStatus.Text == Resources.Resource.Fresh)
            {
                txtIncidentNo.Enabled = true;
                txtIncidentTrackingDt.Enabled = true;
                txtAssignNo.Enabled = false;
                txtIncidentType.Enabled = false;
                txtNatureofInc.Enabled = false;
                txtEmployeeID.Enabled = true;
                txtEmployeeName.Enabled = false;
                txtEmpDesignation.Enabled = false;
                //Commented by  on 5-Apr-2013
                //txtReportedDate.Enabled = true;
                txtTimeFrom.Enabled = true;
                txtIncStatus.Enabled = true;
                txtActionTaken.Enabled = true;
                imgEmpSearch.Enabled = true;
                imgIncSearch.Enabled = true;
            }
            else if (lblStatus.Text == Resources.Resource.Amend)
            {
                txtIncidentNo.Enabled = true;
                txtIncidentTrackingDt.Enabled = false;
                txtAssignNo.Enabled = false;
                txtIncidentType.Enabled = false;
                txtNatureofInc.Enabled = false;
                txtEmployeeID.Enabled = true;
                txtEmployeeName.Enabled = false;
                txtEmpDesignation.Enabled = false;
                //Commented by  on 5-Apr-2013
                //txtReportedDate.Enabled = true;
                txtTimeFrom.Enabled = true;
                txtIncStatus.Enabled = true;
                txtActionTaken.Enabled = true;
                imgEmpSearch.Enabled = true;
                imgIncSearch.Enabled = true;
            }
            else if (lblStatus.Text == Resources.Resource.Authorized)
            {
                txtIncidentNo.Enabled = true;
                txtIncidentTrackingDt.Enabled = false;
                txtAssignNo.Enabled = false;
                txtIncidentType.Enabled = false;
                txtNatureofInc.Enabled = false;
                txtEmployeeID.Enabled = false;
                txtEmployeeName.Enabled = false;
                txtEmpDesignation.Enabled = false;
                txtReportedDate.Enabled = false;
                txtTimeFrom.Enabled = false;
                txtIncStatus.Enabled = false;
                txtActionTaken.Enabled = false;
                imgEmpSearch.Enabled = false;
                imgIncSearch.Enabled = true;
            }
            else
            {
                txtIncidentNo.Enabled = true;
                txtIncidentTrackingDt.Enabled = true;
                txtAssignNo.Enabled = false;
                txtIncidentType.Enabled = false;
                txtNatureofInc.Enabled = false;
                txtEmployeeID.Enabled = true;
                txtEmployeeName.Enabled = false;
                txtEmpDesignation.Enabled = false;
                //Commented by  on 5-Apr-2013
                //txtReportedDate.Enabled = true;
                txtTimeFrom.Enabled = true;
                txtIncStatus.Enabled = true;
                txtActionTaken.Enabled = true;
                imgEmpSearch.Enabled = true;
                imgIncSearch.Enabled = true;
            }
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtIncCompNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtIncCompNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.IncidentDetailsGet(txtIncidentNo.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAssignNo.Text = ds.Tables[0].Rows[0]["AsmtCode"].ToString();
            txtIncidentType.Text = ds.Tables[0].Rows[0]["IncidentDesc"].ToString();
            //txtOccDate.Text = DateFormat(ds.Tables[0].Rows[0]["OccuranceDate"].ToString());
            txtAssignNo_TextChanged(sender, e);
            txtEmployeeID.Text = ds.Tables[0].Rows[0]["ReportedBy"].ToString();
            txtEmployeeID_TextChanged1(sender, e);
            txtReportedDate.Text = ds.Tables[0].Rows[0]["ReportedDate"].ToString();
            txtTimeFrom.Text = ds.Tables[0].Rows[0]["ReportedTime"].ToString();
            //ddlCustInvolved.Focus();
        }
        else
        {
            lblError.Text = Resources.Resource.NoDataToShow;
            ClearFields("");
        }
        hideshowButton("");
        enabledisableField("");

    }
    /// <summary>
    /// Handles the TextChanged event of the txtAssignNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtAssignNo_TextChanged(object sender, EventArgs e)
    {
        FillAsmtDetails();
    }
    /// <summary>
    /// Fills the asmt details.
    /// </summary>
    private void FillAsmtDetails()
    {
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        DataSet ds = new DataSet();
        //Commented and Modify by  on 22-May-2013
        //ds = objOperationManagement.AsmtIncidentDetailGet(txtAssignNo.Text, BaseLocationAutoID);
        ds = objOperationManagement.AsmtIncidentDetailGet(hdClientCode.Value, txtAssignNo.Text, BaseLocationAutoID);
        if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                //EnableFields();
                //EnableButton();
                txtCustomerID.Text = ds.Tables[0].Rows[0]["ClientCode"].ToString();
                txtCustomerDesc.Text = ds.Tables[0].Rows[0]["ClientName"].ToString();
                txtAreaID.Text = ds.Tables[0].Rows[0]["AreaId"].ToString();
                txtAreaDesc.Text = ds.Tables[0].Rows[0]["AreaDesc"].ToString();
                txtAddressID.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();
                txtAddressDesc.Text = ds.Tables[0].Rows[0]["AsmtAddress"].ToString();
            }
            else
            {
                // DisableFields();
                //ClearFields("");
                //DisableButtons();

            }

        }
        else
        {
            lblErrorMsg.Text = Resources.Resource.NoDataToShow;
            ClearFields("");
            hideshowButton("");
            enabledisableField("");
        }

    }
    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strStatus;
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        strStatus = getStatusFromResource(lblStatus.Text.ToString().Trim());
        ds = objOperationManagement.IncidentTrackingInsert(strStatus, DateTime.Parse(txtIncidentTrackingDt.Text), txtIncidentNo.Text.ToString(),txtEmployeeID.Text.ToString(),DateTime.Parse(txtReportedDate.Text),DateTime.Parse(txtTimeFrom.Text),txtIncStatus.Text,txtActionTaken.Text, BaseLocationAutoID, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        if (int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString()) == 0)
        {
            //txtIncidentNo.Text = ds.Tables[0].Rows[0]["IncidentNo"].ToString();
            lblStatus.Text = Resources.Resource.Fresh.ToString();
            hideshowButton("");
        }
    }
    /// <summary>
    /// Gets the status from resource.
    /// </summary>
    /// <param name="strStatus">The string status.</param>
    /// <returns>System.String.</returns>
    protected string getStatusFromResource(string strStatus)
    {
        if (strStatus == "" || strStatus == Resources.Resource.Fresh.ToString())
        {
            return "FRESH";
        }
        else if (lblStatus.Text.ToString().Trim() == Resources.Resource.Authorized.ToString())
        {
            return "AUTHORIZED";
        }
        else if (lblStatus.Text.ToString().Trim() == Resources.Resource.Amend.ToString())
        {
            return "AMEND";
        }
        return "0";
    }
    /// <summary>
    /// Handles the Click event of the btnReset control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        ClearFields("");
        hideshowButton("RESET");
        enabledisableField("RESET");

    }
    /// <summary>
    /// Handles the TextChanged event of the txtIncidentNo control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtIncidentNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.IncidentDetailsGet(txtIncidentNo.Text, BaseCompanyCode);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            hdClientCode.Value = ds.Tables[0].Rows[0]["ClientCode"].ToString();         //Added by  on 22-May-2013
            txtAssignNo.Text = ds.Tables[0].Rows[0]["AsmtId"].ToString();               //Modify by  on 22-May-2013
            txtAssignNo_TextChanged(sender, e);
            txtDetails.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            txtIncidentType.Text = ds.Tables[0].Rows[0]["IncidentDesc"].ToString();
            txtNatureofInc.Text = ds.Tables[0].Rows[0]["NatureofIncidentDesc"].ToString();
            txtIncidentTrackingDt.Text = DateFormat(ds.Tables[0].Rows[0]["IncidentTrackingDate"].ToString());
            txtEmployeeID.Text = ds.Tables[0].Rows[0]["ReportedBy"].ToString();
            txtEmployeeID_TextChanged1(sender, e);
            txtReportedDate.Text = DateFormat(ds.Tables[0].Rows[0]["ReportedDate"].ToString());
            txtIncStatus.Text = ds.Tables[0].Rows[0]["IncidentTrackStatus"].ToString();
            txtActionTaken.Text = ds.Tables[0].Rows[0]["IncidentTrackAction"].ToString();
            lblStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            if (ds.Tables[0].Rows[0]["ReportedTime"].ToString() != "")
            {
                txtTimeFrom.Text = DateTime.Parse(ds.Tables[0].Rows[0]["ReportedTime"].ToString()).ToString("HH:mm");
            }
            else
            {
                txtTimeFrom.Text = "";
            }
           
            hideshowButton("");
            enabledisableField("");
        }
        else
        {
            lblError.Text = Resources.Resource.RecordNotAuthorized;
        }

    }
    /// <summary>
    /// Handles the Click event of the btnUpdate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.IncidentTrackingUpdate(txtIncidentNo.Text.ToString(), DateTime.Parse(txtIncidentTrackingDt.Text), txtEmployeeID.Text.ToString(), DateTime.Parse(txtReportedDate.Text.ToString()), DateTime.Parse(txtTimeFrom.Text.ToString()), txtIncStatus.Text.ToString(), txtActionTaken.Text.ToString(), BaseLocationAutoID, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        hideshowButton("");
        enabledisableField("");
    }
    /// <summary>
    /// Handles the Click event of the btnAuthorize control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAuthorize_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.IncidentTrackingAuthorize(txtIncidentNo.Text.ToString(), Resources.Resource.Authorized.ToString(), BaseLocationAutoID, BaseUserID);
        DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "2")
        {
            lblStatus.Text = Resources.Resource.Authorized.ToString();
            hideshowButton("");
            enabledisableField("");
        }
    }
    /// <summary>
    /// Handles the Click event of the btnEdit control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.OperationManagement objOperationManagement = new BL.OperationManagement();
        ds = objOperationManagement.IncidentTrackingAmend(txtIncidentNo.Text.ToString(), Resources.Resource.Amend.ToString(), BaseLocationAutoID, BaseUserID);
        //DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
        if (ds.Tables[0].Rows[0]["MessageID"].ToString() == "2")
        {
            lblStatus.Text = Resources.Resource.Amend.ToString();
            hideshowButton("");
            enabledisableField("");
        }
    }
    /// <summary>
    /// Handles the TextChanged1 event of the txtEmployeeID control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEmployeeID_TextChanged1(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHRManagement = new BL.HRManagement();
        if (txtEmployeeID.Text != "")
        {
            ds = objHRManagement.EmployeeNameAndDesignationGet(txtEmployeeID.Text, BaseCompanyCode);
            if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
            {
                txtEmployeeName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                txtEmpDesignation.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.InvalidEmpCode;
                txtEmpDesignation.Text = "";
                txtEmployeeName.Text = "";
                //DisableButtons();
            }
            hideshowButton("");
            enabledisableField("");
        }
    }
    /// <summary>
    /// Handles the TextChanged event of the txtIncidentTrackingDt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtIncidentTrackingDt_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ConvertStringToDateFormat(txtIncidentTrackingDt,lblErrorMsg );
        ToolkitScriptManager2.SetFocus(txtIncidentNo);
    }
    /// <summary>
    /// Handles the TextChanged event of the txtReportedDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtReportedDate_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        ConvertStringToDateFormat(txtReportedDate,lblErrorMsg );
        //ToolkitScriptManager2.SetFocus(txtTimeFrom);
    }
    
}